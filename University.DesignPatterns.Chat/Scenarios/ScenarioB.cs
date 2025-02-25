using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Chat.Chat;
using University.DesignPatterns.Chat.Commands;
using University.DesignPatterns.Chat.Models;

namespace University.DesignPatterns.Chat.Scenarios
{
    public class ScenarioB : IScenario
    {
        private ChatRoom _chat;
        private List<IClient> _allUsers;

        public ScenarioB()
        {
            _chat = new ChatRoom();
        }

        public void Run()
        {
            var mainClient = new Client("Александр");

            _allUsers =
                [
                    mainClient,
                    new Client("Женя"),
                    new Client("Сергей"),
                    new Client("Мария"),
                ];

            _chat.RegisterClient(mainClient);

            CommandProcessor commandProcessor = new CommandProcessor(_chat, _allUsers);

            bool isChatting = true;
            string? message;

            do
            {
                Console.Write("\n> ");
                string? input = Console.ReadLine();

                ClearLastInput();

                if (string.IsNullOrWhiteSpace(input)) continue;

                if (input.StartsWith("/"))
                    commandProcessor.ProcessCommand(input);
                else
                {
                    _chat.SendMessage(new Message(mainClient.Name, input));
                }

                if (!_chat.Clients.Contains(mainClient))
                {
                    isChatting = false;
                }
                
            } while (isChatting);
        }

        private void ClearLastInput()
        {
            Console.CursorTop--;
            Console.Write($"\r{new string(' ', Console.BufferWidth)}\r");
        }
    }
}
