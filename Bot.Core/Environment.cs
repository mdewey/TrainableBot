using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public bool? IsOwnerSayingSitCommand { get; set; }
        public bool? DidOwnerGiveToy { get; set; }

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

        private string DeterStringForProperty(bool? value, string yesString, string wildcardString, string noString)
        {
            if (value == null)
            {
                return wildcardString;
            } else
            {
                if (value.GetValueOrDefault()) return yesString;
                else return noString;
            }
        }

        public Environment Random()
        {

            this.IsDay = SeedRandomBool();
            this.IsOwnerHome = SeedRandomBool();
            this.IsOwnerSleeping = SeedRandomBool();
            this.IsStrangerOutside = SeedRandomBool();
            this.IsStrangerInside = SeedRandomBool();
            this.IsOwnerSayingSitCommand = SeedRandomBool();
            this.DidOwnerGiveToy = SeedRandomBool();
            return this;
        }
        
        public static bool CompareProperties(bool? thisValue, bool? otherValue)
        {

            if (otherValue == null || thisValue == null)
            {
               return true;
            }
            else
            {
              return (otherValue == thisValue);
            }
        }
        
        public bool DoesMatch(Environment other)
        {
            var rv = new List<bool>();

            rv.Add(CompareProperties(this.IsDay, other.IsDay));

            rv.Add(CompareProperties(this.DidOwnerGiveToy, other.DidOwnerGiveToy));
            rv.Add(CompareProperties(this.IsOwnerHome, other.IsOwnerHome));
            rv.Add(CompareProperties(this.IsOwnerSleeping, other.IsOwnerSleeping));
            rv.Add(CompareProperties(this.IsStrangerOutside, other.IsStrangerOutside));
            rv.Add(CompareProperties(this.IsStrangerInside, other.IsStrangerInside));
            rv.Add(CompareProperties(this.IsOwnerSayingSitCommand, other.IsOwnerSayingSitCommand));



            return rv.All(a => a);
        }

        public override string ToString()
        {
            var rv = new StringBuilder();
            rv.Append("The current conditions are");
            rv.Append(System.Environment.NewLine);
            rv.Append(DeterStringForProperty(IsDay, "Is is day", "Daytime doesnt matter", "It is night"));
            rv.Append(System.Environment.NewLine);
            rv.Append(DeterStringForProperty(IsOwnerHome, "Owner is home", "Owner at home doesnt matter", "Onwer is away"));
            rv.Append(System.Environment.NewLine);
            rv.Append(DeterStringForProperty(IsOwnerSleeping, "Owner is sleeping", "Owner sleeping doesnt matter", "owner is awake"));
            rv.Append(System.Environment.NewLine);
            rv.Append(DeterStringForProperty(IsStrangerInside, "there is a Stragner is inside", "stranger inside status doesnt matter", "No stragner inside"));
            rv.Append(System.Environment.NewLine);
            rv.Append(DeterStringForProperty(IsStrangerOutside, "there is a Stranger is outside", "stranger outside doesnt matter", "no stranger outside"));
            rv.Append(System.Environment.NewLine);
            rv.Append(DeterStringForProperty(IsOwnerSayingSitCommand, "Owner is trying to get me to sit", "Doesnt matter is owner is trying to get me to sit", "Owner is not trying to get me to sit"));
            rv.Append(System.Environment.NewLine);
            rv.Append(DeterStringForProperty(DidOwnerGiveToy, "owner gave mea  toy", "toy is irrellivant", "no toy"));
            rv.Append(System.Environment.NewLine);
            return rv.ToString();
        }
    }
}
