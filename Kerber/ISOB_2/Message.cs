using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ISOB_2
{
    public class Message
    {
        public Message(MessageType messageType = 0)
        {
            Type = messageType;
            Data = new List<List<byte>>();
        }
        public Message() { Data = new List<List<byte>>(); }
        public MessageType Type { get; set; }
        public List<List<byte>> Data { get; set; }

        // отпарвляем сообщение на удаленный адрес
        public void Send(IPEndPoint remoteIP)
        {
            UdpClient sender = new UdpClient();

            try
            {
                byte[] dgram = Serialiser<Message>.Serialise(this);
                sender.Send(dgram, dgram.Length, remoteIP);
            }
            finally
            {
                sender.Close();
            }
        }
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    //sb.AppendLine($"Message Type: {Type}");

        //    if (Data != null && Data.Count > 0)
        //    {
        //        //sb.AppendLine("Data:");
        //        //foreach (var dataItem in Data)
        //        //{
        //        //    sb.AppendLine(BitConverter.ToString(dataItem.ToArray()));
        //        //}
        //    }
        //    else
        //    {
        //        sb.AppendLine("No data present.");
        //    }

        //    return sb.ToString();
        //}
    }
}
