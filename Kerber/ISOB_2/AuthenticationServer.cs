using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ISOB_2
{
    class AuthenticationServer
    {
        // создаем список пользователей
        private List<string> Users = new List<string>();

        // в конструкторе класса добавляем одного пользователя - данный логин после будет являться идентификатором с
        public AuthenticationServer()
        {
            Users.Add("user");
        }

        // метод прослушивания входящих соединений на сервере
        public void Listen()
        {
            // экземпляр будет прослушивать порт, который указан
            UdpClient receiver = new UdpClient(Config.AS_port);
            Console.WriteLine($"AS started on 127.0.0.1:{Config.AS_port}");
            // в данной переменной храним адрес IP клиента
            IPEndPoint remoteIP = null;
            try
            {
                while (true)
                {
                    // получаем входящие данные в виде массива байтов и сохраняем IP адрес отправителя в переменной remoteID
                    byte[] data = receiver.Receive(ref remoteIP);
                    // устанавливаем порт отправителя в порт клиента
                    remoteIP.Port = Config.C_port;
                    // экземпляр для формирования ответа на сервер
                    Message responseMessage = new Message();
                    
                    // исходные данные протокола
                    Console.WriteLine("---- INFORMATION (AS) ----");
                    Console.WriteLine($"Config.AS_port: {Config.AS_port}");
                    Console.WriteLine($"Config.C_port: {Config.C_port}");
                    Console.WriteLine($"Config.K_AS_TGS: {Convert.ToBase64String(Config.K_AS_TGS)}");
                    Console.WriteLine($"Config.K_C_TGS: {Convert.ToBase64String(Config.K_C_TGS)}");
                    Console.WriteLine($"Config.K_C: {Convert.ToBase64String(Config.K_C)}");


                    Console.WriteLine("---- STEP 1 ----");
                    Console.WriteLine("C->AS: {c}");

                    // десериализуем массив байтов data в объект типа mess
                    var message = Serialiser<Message>.Deserialise(data);

                    Console.WriteLine($"Received message type: {message.Type}");

                    if (message.Type == MessageType.CToAs)
                    {
                        Console.WriteLine("---- STEP 2 ----");
                        Console.WriteLine("AS->C: {{TGT}KAS_TGS, KC_TGS}KC");
                       
                        // получаем идентификатор клиента из данных.
                        var id = Encoding.UTF8.GetString(message.Data[0].ToArray());

                        // проверяем в списке клиентов
                        if (Users.Contains(id))
                        {
                            responseMessage.Type = MessageType.AsToC;
                            Console.WriteLine($"Received message type: {responseMessage.Type}");

                            // создаем билетик
                            TicketGranting ticket = new TicketGranting()
                            {
                                ClientIdentity = id,
                                Duration = Config.ASTicketDuration.Ticks,
                                IssuingTime = DateTime.Now,
                                ServiceIdentity = Config.tgs,
                                Key = Encoding.UTF8.GetString(Config.K_C_TGS)
                            };

                            // сериализуем билетик в массив байтов и расширяем его
                            var ticket_bytes = Helper.ExtendData(Serialiser<TicketGranting>.Serialise(ticket));
                            // расширфем ключ для шифрования
                            var k_c_tgs_bytes = Helper.ExtendData(Config.K_C_TGS);


                            // шифруем билетик сначала с использованием 1го ключа, а затем с исползованием 2го ключа
                            var tb_enc = DES.Encrypt(ticket_bytes, Config.K_AS_TGS);
                            tb_enc = DES.Encrypt(tb_enc, Config.K_C);

                            // шифруем ключ с исползованием ключа шифрования между сервером аутентификации и клиентом 
                            var k_c_tgs_enc = DES.Encrypt(k_c_tgs_bytes, Config.K_C);

                            responseMessage.Data.Add(new List<byte>(tb_enc));
                            responseMessage.Data.Add(new List<byte>(k_c_tgs_enc));

                            // Вывод зашифрованного билета и ключа
                            //Console.WriteLine("Encrypted Ticket Granting Ticket (TGT):");
                            //Console.WriteLine(BitConverter.ToString(tb_enc));
                            //Console.WriteLine("Encrypted Session Key (K_C_TGS):");
                            //Console.WriteLine(BitConverter.ToString(k_c_tgs_enc));
                        }
                        else
                        {
                            responseMessage.Type = MessageType.AccessDenied;
                            Console.WriteLine("Access Denied in Authentication Server");
                        }
                        // отправляем ответку клиенту
                        responseMessage.Send(remoteIP);
                        Console.WriteLine($"Message sent from AS to {remoteIP.Address}:{remoteIP.Port}!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
