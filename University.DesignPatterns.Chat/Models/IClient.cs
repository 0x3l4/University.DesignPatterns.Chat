using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DesignPatterns.Chat.Models
{
    public interface IClient
    {
        Guid Id { get; }
        string Name { get; }
        void ReceiveMessage(IMessage message);
    }
}
