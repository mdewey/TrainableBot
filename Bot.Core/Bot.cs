using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot.Core
{
    public class Bot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public IList<BotActions> Actions { get; set; } = new List<BotActions>();

        public override string ToString()
        {
            return $"Training {Id}, {Name}";
        }

        public void PopulateActions(int numberOfActions = 10)
        {
            for (int i = 0; i < 10; i++)
            {
                this.Actions.Add(new BotActions().Random());
            }
        }

    }
}
