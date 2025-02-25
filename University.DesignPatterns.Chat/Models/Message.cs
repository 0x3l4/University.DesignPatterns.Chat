using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DesignPatterns.Chat.Models
{
    public class Message : IMessage
    {
        public DateTime SendingTime { get; private set; }
        public string Sender { get; private set; }
        public string Body { get; private set; }

        public Message(string sender, string body)
        {
            SendingTime = DateTime.Now;
            Sender = sender;
            Body = body;
        }

        public override string ToString()
        {
            string message = $"[{SendingTime.ToShortTimeString()}], {Sender} > {Body}";
            return message;
        }
    }
}
