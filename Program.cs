using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> crew = new List<IRobber>();
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker()
                {
                    Name= "Kevin Hacker",
                    SkillLevel= 95,
                    PercentageCut= 25,

                },
                new Muscle()
                {
                    Name= "Hunter Pruett",
                    SkillLevel= 25,
                    PercentageCut= 10,

                },
                new LockSpecialist()
                {
                    Name= "Jury Byrd",
                    SkillLevel= 70,
                    PercentageCut= 25,

                },
                new Hacker()
                {
                    Name= "Joe Shepherd",
                    SkillLevel= 9001,
                    PercentageCut= 4,

                },
                new Muscle()
                {
                    Name= "Isaac 'the bus' Weiser",
                    SkillLevel= 75,
                    PercentageCut= 45,

                }
            };

            Console.WriteLine("Welome to Redistribution!");

            Console.WriteLine($"You currently have {rolodex.Count} operatives.");


            do
            {

                // ask for team member's name
                Console.WriteLine();
                Console.Write("Enter the name of a new crew member: ");
                var name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(name))
                {
                    break;
                }


                int specialtyInt = 0;

                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.WriteLine(@"Specialties:
1) Hacker (Disables alarms)
2) Muscle (Disarms guards)
3) Lock Specialist (cracks vault)");
                        Console.Write("Choose a specialty (1-3): ");
                        string specialtyStr = Console.ReadLine();
                        specialtyInt = int.Parse(specialtyStr);
                        if (specialtyInt <= 0 || specialtyInt > 3)
                        {
                            throw new FormatException("Please enter 1, 2, or 3!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (specialtyInt <= 0 || specialtyInt > 3);


                // ask for team member's skill level
                int skillLevelInt = 0;
                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("What is your team member's skill level? ");
                        string skillLevelStr = Console.ReadLine();
                        skillLevelInt = int.Parse(skillLevelStr);
                        if (skillLevelInt <= 0 || skillLevelInt > 100)
                        {
                            throw new FormatException("Please enter a integer between 1 and 100!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (skillLevelInt <= 0 || skillLevelInt > 100);

                int percentCutInt = 0;
                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("What is your team member's percentage cut? ");
                        string percentCutStr = Console.ReadLine();
                        percentCutInt = int.Parse(percentCutStr);
                        if (percentCutInt <= 0 || percentCutInt > 100)
                        {
                            throw new FormatException("Please enter a integer between 1 and 100!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (percentCutInt <= 0 || percentCutInt > 100);

                switch (specialtyInt)
                {

                    case 1:
                        rolodex.Add(new Hacker()
                        {
                            Name = name,
                            SkillLevel = skillLevelInt,
                            PercentageCut = percentCutInt

                        });
                        break;

                    case 2:
                        rolodex.Add(new Muscle()
                        {
                            Name = name,
                            SkillLevel = skillLevelInt,
                            PercentageCut = percentCutInt

                        });
                        break;

                    case 3:
                        rolodex.Add(new LockSpecialist()
                        {
                            Name = name,
                            SkillLevel = skillLevelInt,
                            PercentageCut = percentCutInt

                        });
                        break;

                }
            } while (true);

            Random randomizer = new Random();
            Bank daTarget = new Bank() {
                CashOnHand = randomizer.Next(50000, 100001),
                AlarmScore = randomizer.Next(101),
                VaultScore = randomizer.Next(101),
                SecurityGuardScore = randomizer.Next(101)
            };
            Dictionary<string, int> daDetails = new Dictionary<string, int>();
            daDetails.Add("Alarms", daTarget.AlarmScore);
            daDetails.Add("Vaults", daTarget.VaultScore);
            daDetails.Add("Security", daTarget.SecurityGuardScore);

            Console.WriteLine($"Least Secure: {daDetails.OrderBy(d => d.Value).First().Key}");
            Console.WriteLine($"Most Secure: {daDetails.OrderByDescending(d => d.Value).First().Key}");


            Console.WriteLine("Select operatives and create your crew");
            while (true) {
                //keep track of ther percentage cut so we can limit what we show as options only to IRobbers that we can pay
                int currentCutTotal = crew.Sum(c => c.PercentageCut);
                Console.WriteLine($"Current total of crew's cut {currentCutTotal}%");
                for (int i = 0; i < rolodex.Count; i++) {
                    if (rolodex[i].PercentageCut + currentCutTotal <= 100) {
                        Console.WriteLine($"{i + 1}) {rolodex[i].PrintSpecialty()}");
                    }
                }
                string choiceString = Console.ReadLine();
                //break out of this sequence if enter is pressed
                if (String.IsNullOrWhiteSpace(choiceString)) {
                    break;
                }
                if (int.TryParse(choiceString, out int choice)) {
                    if (choice > 0 && choice <= rolodex.Count) {
                        IRobber operative = rolodex[choice - 1];
                        crew.Add(operative);
                        rolodex.Remove(operative);
                    } else {
                        Console.WriteLine("Invalid Option Selected");
                    }

                } else {
                    Console.WriteLine("Invalid Option Selected");
                }
            }
            //Do the heist
            crew.ForEach(c => c.PerformSkill(daTarget));
            //check for success or failure
            if (daTarget.IsSecure) {
                //failure because bank is secure
                Console.WriteLine("Heist failed. You all go to jail. Except for the one guy who's grandpa is rich enough to pay bail.");
            } else {
                //success because bank is not secure
                Console.WriteLine("Heist Successful!");
                decimal userHaul = daTarget.CashOnHand;
                crew.ForEach(c => {
                    decimal memberHaul = ((c.PercentageCut * .01M) * daTarget.CashOnHand);
                    userHaul -= memberHaul;
                    Console.WriteLine($"{c.Name} took home ${memberHaul}");
                });
                Console.WriteLine($"You took home ${userHaul}");
            }
        }
    }
}
