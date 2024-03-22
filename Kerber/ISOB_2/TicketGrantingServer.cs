using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ISOB_2
{
    class TicketGrantingServer
    {
        public void Listen()
        {
            UdpClient reciever = new UdpClient(Config.TGS_port);
            Console.WriteLine($"TGS started on 127.0.0.1:{Config.TGS_port}");
            IPEndPoint remoteIP = null;
            try
            {
                while (true)
                {
                    byte[] data = reciever.Receive(ref remoteIP);
                    remoteIP.Port = Config.C_port;

                    // Исходные данные протокола
                    Console.WriteLine("---- INFORMATION (TGS) ----");
                    Console.WriteLine($"Config.TGS_port: {Config.TGS_port}");
                    Console.WriteLine($"Config.C_port: {Config.C_port}");
                    Console.WriteLine($"Config.K_AS_TGS: {Convert.ToBase64String(Config.K_AS_TGS)}");
                    Console.WriteLine($"Config.K_C_TGS: {Convert.ToBase64String(Config.K_C_TGS)}");
                    Console.WriteLine($"Config.K_TGS_SS: {Convert.ToBase64String(Config.K_TGS_SS)}");
                    Console.WriteLine($"Config.K_C_SS: {Convert.ToBase64String(Config.K_C_SS)}");
                    Console.WriteLine($"Config.TGSTicketDuration: {Config.TGSTicketDuration}");

                    Console.WriteLine("---- STEP 3 ----");
                    Console.WriteLine("C->TGS: {TGT}KAS_TGS, {Aut1} KC_TGS, {ID}");
                    // Данные, передаваемые по сети каждой из сторон
                    ///Console.WriteLine("---- Data transmitted over the network ----");
                    //Console.WriteLine($"Received data from {remoteIP.Address}:{remoteIP.Port}: {BitConverter.ToString(data)}");

                    var message = Serialiser<Message>.Deserialise(data);

                    // Проверки, выполняемые каждым из участников
                    Console.WriteLine($"Received message type: {message.Type}");

                    if (message.Type == MessageType.СToTgs)
                    {
                        var tgt_json = Helper.RecoverData(
                            new List<byte>(DES.Decrypt(message.Data[0].ToArray(), Config.K_AS_TGS)));
                        var tgt = Serialiser<TicketGranting>.Deserialise(tgt_json);

                        Console.WriteLine("---- TGT ----");
                        Console.WriteLine($"Client Identity: {tgt.ClientIdentity}");
                        Console.WriteLine($"Service Identity: {tgt.ServiceIdentity}");
                        Console.WriteLine($"Issuing Time: {tgt.IssuingTime}");

                        var aut1_json = Helper.RecoverData(
                            new List<byte>(DES.Decrypt(message.Data[1].ToArray(), Config.K_C_TGS)));
                        var a = Encoding.UTF8.GetString(aut1_json);
                        var aut1 = Serialiser<TimeMark>.Deserialise(aut1_json);

                        Console.WriteLine("---- Authentication Block (Aut1) ----");
                        Console.WriteLine($"Client Identity: {aut1.C}");
                        Console.WriteLine($"Time Mark: {aut1.T}");

                        var ID = Encoding.UTF8.GetString(message.Data[2].ToArray());

                        Message ReMessage = new Message();

                        // Проверка времени действия билета
                        if (Helper.CheckTime(tgt.IssuingTime, aut1.T, tgt.Duration))
                        {
                            Console.WriteLine("---- STEP 4 ----");
                            Console.WriteLine("TGS->C: {{TGS}KTGS_SS,KC_SS}KC_TGS");

                            ReMessage.Type = MessageType.TgsToC;

                            var TGS = new TicketGranting()
                            {
                                ClientIdentity = aut1.C,
                                ServiceIdentity = ID,
                                Duration = Config.TGSTicketDuration.Ticks,
                                IssuingTime = DateTime.Now,
                                Key = Encoding.UTF8.GetString(Config.K_C_SS)
                            };

                            // расширяем билет tgs, но сначала сериализуем в массив байтов
                            var ticket_bytes = Helper.ExtendData(Serialiser<TicketGranting>.Serialise(TGS));
                            // ключик тоже
                            var k_c_ss_bytes = Helper.ExtendData(Config.K_C_SS);

                            var tb_enc = DES.Encrypt(ticket_bytes, Config.K_TGS_SS);
                            tb_enc = DES.Encrypt(tb_enc, Config.K_C_TGS);

                            var k_c_ss_enc = DES.Encrypt(k_c_ss_bytes, Config.K_C_TGS);

                            ReMessage.Data.Add(new List<byte>(tb_enc));
                            ReMessage.Data.Add(new List<byte>(k_c_ss_enc));
                        }
                        else
                        {
                            ReMessage.Type = MessageType.TicketNotValid;
                            Console.WriteLine("TicketNotValid in TGS;");
                        }

                        Console.WriteLine($"Received message type: {ReMessage.Type}");
                        //Console.WriteLine($"Sending message from TGS to {remoteIP.Address}:{remoteIP.Port}!");

                        ReMessage.Send(remoteIP);
                        Console.WriteLine($"Message sent from TGS to {remoteIP.Address}:{remoteIP.Port}!");
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
