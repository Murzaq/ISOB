using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ISOB_2
{
    class Server
    {
        public void Listen()
        {
            Console.WriteLine($"SS started on 127.0.0.1:{Config.SS_port}");
            UdpClient receiver = new UdpClient(Config.SS_port);
            IPEndPoint remoteIP = null;
            try
            {
                while (true)
                {
                    // принимаем входящие сообщения
                    byte[] data = receiver.Receive(ref remoteIP);
                    remoteIP.Port = Config.C_port;

                    var message = Serialiser<Message>.Deserialise(data);
                    Console.WriteLine(message.ToString() + $"from {remoteIP.Address}:{remoteIP.Port};");

                    if (message.Type == MessageType.CToSs)
                    {
                        Console.WriteLine("---- INFORMATION (SS) ----");
                        // Вывод исходных данных протокола
                        Console.WriteLine($"Config.SS_port: {Config.SS_port}");
                        Console.WriteLine($"Config.C_port: {Config.C_port}");
                        Console.WriteLine($"Config.K_TGS_SS: {Convert.ToBase64String(Config.K_TGS_SS)}");
                        Console.WriteLine($"Config.K_C_SS: {Convert.ToBase64String(Config.K_C_SS)}");

                        Console.WriteLine("---- STEP 5 ----");
                        Console.WriteLine("C->SS: {TGS}KTGS_SS, {Aut2} KC_SS");
                        Console.WriteLine($"Received message type: {message.Type}");

                        // преобразуем список байтов в массив и выполняем расшифровку данных при поиощи ключа
                        var tgs_bytes = Helper.RecoverData(
                            new List<byte>(DES.Decrypt(message.Data[0].ToArray(), Config.K_TGS_SS)));
                        var tgs = Serialiser<TicketGranting>.Deserialise(tgs_bytes);

                        Console.WriteLine("---- Ticket Granting Service Ticket (TGS Ticket) ----");
                        Console.WriteLine($"Client Identity: {tgs.ClientIdentity}");
                        Console.WriteLine($"Service Identity: {tgs.ServiceIdentity}");
                        Console.WriteLine($"Issuing Time: {tgs.IssuingTime}");

                        var aut2_bytes = Helper.RecoverData(
                            new List<byte>(DES.Decrypt(message.Data[1].ToArray(), Config.K_C_SS)));
                        var aut2 = Serialiser<TimeMark>.Deserialise(aut2_bytes);

                        Console.WriteLine("---- Authentication Block (Aut2) ----");
                        Console.WriteLine($"Client Identity: {aut2.C}");
                        Console.WriteLine($"Time Mark: {aut2.T}");

                        Message ReMessage = new Message();
                        if (Helper.CheckTime(tgs.IssuingTime, aut2.T, tgs.Duration))
                        {
                            Console.WriteLine("---- STEP 6 ----");
                            Console.WriteLine("SS->C: {t4+1}KC_SS");

                            ReMessage.Type = MessageType.SsToC;
                            Console.WriteLine($"Received message type: {ReMessage.Type}");
                            
                            DateTime reTime = aut2.T;
                            // в шаге 6 увеличиваем метку времени на 1
                            var time_bytes = Serialiser<long>.Serialise(aut2.T.Ticks + 1);
                            var bytes = DES.Encrypt(Helper.ExtendData(time_bytes), Config.K_C_SS);
                            ReMessage.Data.Add(new List<byte>(bytes));

                            // Вывод успешного отправления сообщения
                            Console.WriteLine($"Message sent from SS to {remoteIP.Address}:{remoteIP.Port}");                 

                            //// Вывод данных, передаваемых по сети
                            //Console.WriteLine($"Received data from {remoteIP.Address}:{remoteIP.Port}: {BitConverter.ToString(data)}");
                            
                        }
                        else
                        {
                            ReMessage.Type = MessageType.TicketNotValid;

                            // Вывод сообщения о недействительности билета
                            Console.WriteLine("TicketNotValid in SS;");
                        }

                        ReMessage.Send(remoteIP);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
