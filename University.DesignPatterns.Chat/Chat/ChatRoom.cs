using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Chat.Models;

namespace University.DesignPatterns.Chat.Chat
{
    public class ChatRoom : IChat
    {
        protected LinkedList<IClient> _clients;

        public IEnumerable<IClient> Clients => _clients;

        public ChatRoom()
        {
            SendMessage(new Message($"Чат", $"Добро пожаловать!"));
            _clients = new LinkedList<IClient>();
        }

        public void RegisterClient(IClient client)
        {
            if (!_clients.Contains(client))
            {
                _clients.AddLast(client);
                SendMessage(new Message($"Чат", $"{client.Name} присоединяется к чату!"));
            }
        }

        public void UnregisterClient(IClient client)
        {
            if (_clients.Remove(client))
            {
                SendMessage(new Message($"Чат", $"{client.Name} выходит из чата!"));
            }
        }

        public void NotifyClients(IMessage message)
        {
            if (_clients is null)
                return;

            foreach (var client in _clients)
                client.ReceiveMessage(message);
        }

        public void SendMessage(IMessage message)
        {
            Console.WriteLine(message);
            NotifyClients(message);
        }
    }
}
