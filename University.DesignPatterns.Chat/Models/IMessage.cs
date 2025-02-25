using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DesignPatterns.Chat.Models
{
    public interface IMessage
    {
        public string Sender { get; }
        public DateTime SendingTime { get; }
        public string Body { get; }
    }
}
