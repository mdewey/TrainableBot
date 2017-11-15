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

        private void RemoveLowestAction()
        {
            var _lowest = this.Actions.OrderBy(w => w.Strength).First().Id;
            this.Actions = this.Actions.Where(w => w.Id != _lowest).ToList();
        }

        private void ChangeActionStrength(Guid id, int weightModifier)
        {
            var _action = this.Actions.First(f => f.Id == id);
            if (_action.Strength < 100)
            {
                _action.Strength += weightModifier;
            }
        }

        public void WeakenAction(BotActions selectAction)
        {
            this.ChangeActionStrength(selectAction.Id, -10);
        }
        public void StrengthenAction(BotActions selectAction)
        {
            this.ChangeActionStrength(selectAction.Id, 10);
        }

        public void RemoveBadActions()
        {
            this.Actions = this.Actions.Where(w => w.Strength > 20).ToList();
            while(this.Actions.Count < 10)
            {
                this.Actions.Add(new BotActions().Random());
            }
        }

    }
}
