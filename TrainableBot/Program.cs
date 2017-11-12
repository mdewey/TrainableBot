using System;
using Bot.Core;
namespace TrainableBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to trainer, name your bot");
            var name = Console.ReadLine();
            var bot = new Bot.Core.Bot { Name = name };
            Console.WriteLine(bot);
            // give bot random actions
            bot.PopulateActions();
            // get env
            // select action
            // determin is action is any good
            // train
            Console.ReadLine();
        }
    }
}
