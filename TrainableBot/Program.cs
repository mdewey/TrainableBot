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
            // get env
            var currentConditions = new Bot.Core.Environment();
            var input = String.Empty;
            Console.WriteLine("Is day out?");
            input = Console.ReadLine();
            currentConditions.IsDay = ConvertStringToBool(input);

            Console.WriteLine("Is my owner home?");
            input = Console.ReadLine();
            currentConditions.IsOwnerHome = ConvertStringToBool(input);

            if (currentConditions.IsOwnerHome.GetValueOrDefault())
            {
                Console.WriteLine("Is my owner sleeping");
                input = Console.ReadLine();
                currentConditions.IsOwnerSleeping = ConvertStringToBool(input);
            }

            Console.WriteLine("Is there a stranger outside");
            input = Console.ReadLine();
            currentConditions.IsStrangerOutside = ConvertStringToBool(input);

            Console.WriteLine("Is there a stranger inside");
            input = Console.ReadLine();
            currentConditions.IsStrangerInside = ConvertStringToBool(input);

            Console.WriteLine("Is Owner trying to get my to sit");
            input = Console.ReadLine();
            currentConditions.IsOwnerSayingSitCommand = ConvertStringToBool(input);

            Console.WriteLine("Did my owner give toy?");
            input = Console.ReadLine();
            currentConditions.DidOwnerGiveToy = ConvertStringToBool(input);
            Console.WriteLine(currentConditions);
            // select action
            var selectAction = bot.SelectAction(currentConditions);

            // determin is action is any good
            // train
            Console.ReadLine();
        }
    }
}
