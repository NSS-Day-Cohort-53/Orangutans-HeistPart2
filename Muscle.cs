using System;

namespace Heist
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }


        public void PerformSkill(Bank bank)
        {
            bank.SecurityGaurdScore = bank.SecurityGaurdScore - SkillLevel;
            Console.WriteLine($"{Name} is beating the security gaurds to a pulp. Decreased security guard {SkillLevel} points");
            if (bank.SecurityGaurdScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the lonely rent a cop!");
            }
        }
    }
}