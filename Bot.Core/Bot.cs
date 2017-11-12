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


        public BotActions SelectAction(Environment currentConditions)
        {
            BotActions rv = null;
            var i = 0;
            var attempts = 0;
            while (rv == null && attempts <= 10)
            {
                if (i >= this.Actions.Count)
                {
                    i = 0;
                    attempts++;
                }
                var testing = this.Actions[i];
                if (testing.Conditions.DoesMatch(currentConditions))
                {
                    rv = testing;
                }
                i++;
            }
            if (rv == null)
            {
                var random = new BotActions().Random();
                this.Actions.Add(random);
                rv = random;
            }
            return rv;

        }
    }
}
