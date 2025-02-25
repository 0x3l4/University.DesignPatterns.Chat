using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Chat.Models;

namespace University.DesignPatterns.Chat.Chat
{
    public interface IChat
    {
        void RegisterClient(IClient client);
        void UnregisterClient(IClient client);
        void NotifyClients(IMessage message);
    }
}
