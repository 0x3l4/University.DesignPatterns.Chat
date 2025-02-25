using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Chat.Chat;
using University.DesignPatterns.Chat.Models;

namespace University.DesignPatterns.Chat.Scenarios
{
    public class ScenarioA : IScenario
    {
        public void Run()
        {
            ChatRoom chat = new ChatRoom();
            IClient[] clients =
                [
                    new Client("Александр"),
                    new Client("Илон"),
                    new Client("Цукерберг")
                ];

            Random random = new Random();
            foreach (IClient client in clients)
            {
                Thread.Sleep(random.Next(800, 2000));
                chat.RegisterClient(client);
            }

            Thread.Sleep(random.Next(800, 2000));
            chat.SendMessage(new Message(clients.First(name => name.Name == "Александр").Name, "Всем привет!"));

            Thread.Sleep(random.Next(800, 2000));
            chat.UnregisterClient(clients.First(client => client.Name == "Илон"));

            Thread.Sleep(random.Next(800, 2000));
            chat.UnregisterClient(clients.First(client => client.Name == "Цукерберг"));

            Thread.Sleep(random.Next(800, 2000));
            chat.UnregisterClient(clients.First(client => client.Name == "Александр"));
        }
    }
}
