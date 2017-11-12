using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Core
{
    public class BotActions
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Strength { get; set; }
        public string Action { get; set; }
        public Environment Conditions { get; set; }

        private string ReturnRandomPossibleAction()
        {
            var _actions = new List<string> { "bark", "sit", "stay", "play", "sleep", "nothing", "poop" };
            var rv = String.Empty;
            var rand = new Random();
            // TODO: add weights to base actions so its not that completely random
            while (rv == String.Empty)
            {
                var next = rand.Next(0, _actions.Count);

                rv = _actions[next];
            }
            return rv;
        }


        public BotActions Random()
        {
            var ran = new Random();
            this.Strength = ran.Next(0, 101);
            this.Action = this.ReturnRandomPossibleAction();
            this.Conditions = new Environment().Random();
            return this;
        }
    }
}
