using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DesignPatterns.Chat.Models
{
    public class Client : IClient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Client(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void ReceiveMessage(IMessage message)
        {
            // Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" ^ {Name}: Я получил это сообщение!");
            Console.ResetColor();
        }
    }
}
