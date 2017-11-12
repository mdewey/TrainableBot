using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Core
{
    public class Environment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // condititions
        public bool? IsDay { get; set; }
        public bool? IsOwnerHome { get; set; }
        public bool? IsOwnerSleeping { get; set; }
        public bool? IsStrangerOutside { get; set; }
        public bool? IsStrangerInside { get; set; }
        public bool? IsOwnerSayingStayCommand { get; set; }
        public bool? DidOwnerThroughToy { get; set; }
        public bool? AmIInside { get; set; }

        private static bool? SeedRandomBool()
        {
            var rand = new Random().Next(0, 3);
            switch (rand)
            {
                case (0):
                    return null;
                case (1):
                    return true;
                case (2):
                    return false;
                default:
                    return null;
            }
        }

        public Environment Random()
        {

            this.IsDay = SeedRandomBool();
            this.IsOwnerHome = SeedRandomBool();
            this.IsOwnerSleeping = SeedRandomBool();
            this.IsStrangerOutside = SeedRandomBool();
            this.IsStrangerInside = SeedRandomBool();
            this.IsOwnerSayingStayCommand = SeedRandomBool();
            this.DidOwnerThroughToy = SeedRandomBool();
            this.AmIInside = SeedRandomBool();
            return this;
        }
    }
}
