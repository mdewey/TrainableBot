using System;
using Bot.Core;
namespace TrainableBot
{
    class Program
    {

        private static bool? ConvertStringToBool(string input)
        {
            if (input == "y")
                return true;
            else if (input == "n")
                return false;
            else
                return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to trainer, name your bot");
            var name = Console.ReadLine();
            var bot = new Bot.Core.Bot { Name = name };
            Console.WriteLine(bot);
            // give bot random actions
            bot.PopulateActions();
            var count = 0;
            while (true)
            {
                count++;
                Console.WriteLine($"giving the {count} command");
                // get env
                var currentConditions = new Bot.Core.Environment().Random();
                Console.WriteLine(currentConditions);
                // select action
                var selectAction = bot.SelectAction(currentConditions);
                Console.WriteLine($"{bot.Name} is going to do {selectAction.Action}");
                // determin is action is any good

                if (selectAction.Action == "sit")
                {
                    bot.StrengthenAction(selectAction);
                }
                else
                {
                    bot.WeakenAction(selectAction);
                }

                Console.WriteLine("removing bad actions");
                bot.RemoveBadActions();
                //Console.ReadLine();
            }

            // train
        }
    }
}
