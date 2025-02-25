using University.DesignPatterns.Chat.Chat;
using University.DesignPatterns.Chat.Models;
using University.DesignPatterns.Chat.Scenarios;

namespace University.DesignPatterns.Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IScenario scenario = new ScenarioB();
            scenario.Run();
        }
    }
}
