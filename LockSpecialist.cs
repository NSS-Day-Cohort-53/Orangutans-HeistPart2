using System;

namespace Heist
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }


        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;
            Console.WriteLine($"{Name} is cracking the vault. Decreased vault lock by {SkillLevel} points");
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has entered the vault!");
            }
        }
    }
}