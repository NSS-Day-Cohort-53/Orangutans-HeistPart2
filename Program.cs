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
        }
    }
}
