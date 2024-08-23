using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Pokemon_API.Entities
{
    public class Mascot
    {
        public string? name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public List<AbilityWrapper>? abilities { get; set; }

        public override string ToString()
        {
            string abilityname = "";

            foreach (var abilityWrapper in abilities)
            {
                abilityname += "- " + abilityWrapper.Ability.name + Environment.NewLine;
            }

            return Environment.NewLine + "-------POKEMON INFORMATIONS-----------" + Environment.NewLine + "Pokemon Name: " + name + Environment.NewLine
                + "Height: " + height + Environment.NewLine
                + "Weight: " + weight + Environment.NewLine
                + "Abilities: " + Environment.NewLine
                + abilityname + "-------------------------------------";
        }

    }
}
