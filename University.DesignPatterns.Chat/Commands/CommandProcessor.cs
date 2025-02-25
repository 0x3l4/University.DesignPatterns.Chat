using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Chat.Chat;
using University.DesignPatterns.Chat.Models;

namespace University.DesignPatterns.Chat.Commands
{
    public class CommandProcessor
    {
        private ChatRoom _chatRoom;
        private List<IClient> _allClients;

        public CommandProcessor(ChatRoom chatRoom, List<IClient> allUsers)
        {
            _chatRoom = chatRoom;
            _allClients = allUsers;
        }

        public void ProcessCommand(string input)
        {
            string[] parts = input.Split(' ', 2);
            if (parts.Length < 1) return;

            string command = parts[0].ToLower();
            string argument = parts.Length > 1 ? parts[1] : "";

            switch (command)
            {
                case "/kick":
                    if (Guid.TryParse(argument, out Guid kickId))
                        _chatRoom.UnregisterClient(_allClients.First(client => client.Id == kickId));
                    else
                        Console.WriteLine("Неверный формат ID.");
                    break;
                case "/add":
                    if (Guid.TryParse(argument, out Guid addId) && _allClients.Contains(_allClients.First(client => client.Id == addId)))
                        if (!_chatRoom.Clients.Contains(_allClients.First(client => client.Id == addId)))
                        {
                            _chatRoom.RegisterClient(_allClients.First(client => client.Id == addId));
                        }
                        else
                        {
                            Console.WriteLine("Пользователь уже находится в чате!");
                        }
                    else
                        Console.WriteLine("Пользователь не найден или неверный ID.");
                    break;
                case "/list":
                    if (argument == "-a")
                    {
                        foreach (var client in _allClients)
                        {
                            Console.WriteLine($"[{client.Id}], {client.Name}");
                        }
                    }
                    else if (argument == "-lc")
                    {
                        foreach (var client in _chatRoom.Clients)
                        {
                            Console.WriteLine($"[{client.Id}], {client.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный параметр!");
                    }                    
                    break;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }

}
