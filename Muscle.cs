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
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            Console.WriteLine($"{Name} is beating the security gaurds to a pulp. Decreased security guard {SkillLevel} points");
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the lonely rent a cop!");
            }
        }

        public string PrintSpecialty()
        {
            return $"{Name} is da Muscle with Skill Level: {SkillLevel} and Percentage Cut: {PercentageCut}";
        }
    }
}