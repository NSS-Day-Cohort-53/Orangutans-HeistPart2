using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
