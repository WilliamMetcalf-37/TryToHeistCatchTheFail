using System;
using System.Collections.Generic;

namespace heistpart2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rolodex = new List<IRobber>();

            var Holden = new LockPickSpecialist();
            var Namita = new Hacker();
            var Garrett = new Muscle();

            Holden.Name = "Holden";
            Holden.SkillLevel = 50;
            Holden.PercentageCut = 25;
            Namita.Name = "Namita";
            Namita.SkillLevel = 50;
            Namita.PercentageCut = 25;
            Garrett.Name = "Garrett";
            Garrett.SkillLevel = 50;
            Garrett.PercentageCut = 25;

            rolodex.Add(Holden);
            rolodex.Add(Namita);
            rolodex.Add(Garrett);

            string name;
            int skill;
            double cut;
            string typePhrase;
            string typeNameQ;
            string typeSkillQ;
            string typeCutQ;

            Random randAlarm = new Random();
            int BankAlarm = randAlarm.Next(1, 100);
            Random randVault = new Random();
            int BankVault = randAlarm.Next(1, 100);
            Random randSecurity = new Random();
            int BankSecurity = randAlarm.Next(1, 100);
            Random randCash = new Random();
            int BankCash = randCash.Next(50000, 1000001);

            var TheBank = new Bank();
            TheBank.AlarmScore = BankAlarm;
            TheBank.CashOnHand = BankCash;
            TheBank.SecurityGuardScore = BankSecurity;
            TheBank.VaultScore = BankVault;

            var numbers = new List<int>();
            numbers.Add(TheBank.AlarmScore);
            numbers.Add(TheBank.CashOnHand);
            numbers.Add(TheBank.VaultScore);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Alarm Score = {TheBank.AlarmScore}");
                Console.WriteLine($"Vault Score = {TheBank.VaultScore}");
                Console.WriteLine($"Security Guard Score = {TheBank.SecurityGuardScore}");
                Console.WriteLine($"Cash On Hand = {TheBank.CashOnHand}");
                PrintRolodex();
                Console.WriteLine($"There are {rolodex.Count} Potential Team Members currently.");
                Console.WriteLine("What Kind of Team Member?");
                Console.WriteLine("Please enter Hacker, LockPick, or Muscle.  If done Adding members Enter Blank Name");
                string memberResponse = Console.ReadLine();
                if (memberResponse == "Hacker")
                {
                    typePhrase = $"Add new {memberResponse}?";
                    typeNameQ = $"Name of {memberResponse}?";
                    typeSkillQ = $"Skill of {memberResponse}?";
                    typeCutQ = $"{memberResponse}'s cut?";
                    runThings(typePhrase, typeNameQ, typeSkillQ, typeCutQ);

                    var newHacker = new Hacker();
                    newHacker.Name = name;
                    newHacker.SkillLevel = skill;
                    newHacker.PercentageCut = cut;
                    rolodex.Add(newHacker);
                    PrintRolodex();

                }
                else if (memberResponse == "LockPick")
                {
                    typePhrase = $"Add new {memberResponse}?";
                    typeNameQ = $"Name of {memberResponse}?";
                    typeSkillQ = $"Skill of {memberResponse}?";
                    typeCutQ = $"{memberResponse}'s cut?";
                    runThings(typePhrase, typeNameQ, typeSkillQ, typeCutQ);

                    var newLockPick = new LockPickSpecialist();
                    newLockPick.Name = name;
                    newLockPick.SkillLevel = skill;
                    newLockPick.PercentageCut = cut;
                    rolodex.Add(newLockPick);
                    PrintRolodex();

                }
                else if (memberResponse == "Muscle")
                {
                    typePhrase = $"Add new {memberResponse}?";
                    typeNameQ = $" Name of {memberResponse}?";
                    typeSkillQ = $"Skill of {memberResponse}?";
                    typeCutQ = $"{memberResponse}'s cut?";
                    runThings(typePhrase, typeNameQ, typeSkillQ, typeCutQ);
                    var newMuscle = new Muscle();
                    newMuscle.Name = name;
                    newMuscle.SkillLevel = skill;
                    newMuscle.PercentageCut = cut;
                    rolodex.Add(newMuscle);
                    PrintRolodex();
                }
                else if (memberResponse == "")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter Hacker, LockPick or Muscle or Nothing");
                }
                void runThings(string tp, string tnq, string tsq, string tcq)
                {
                    Console.WriteLine(tp);
                    Console.WriteLine(tnq);
                    name = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine(tsq);
                        try
                        {
                            skill = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine($"Please senter a number");
                        }

                    }
                    while (true)
                    {
                        Console.WriteLine(tcq);
                        try
                        {
                            cut = double.Parse(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine($"Please senter a number");
                        }
                    }
                }

            }
            void PrintRolodex()
            {
                Console.WriteLine("Members for team");
                foreach (var person in rolodex)
                {
                    Console.WriteLine($"{rolodex.IndexOf(person)} Name: {person.Name} Job: {person.Title} Skill: {person.SkillLevel}  Cut: %{person.PercentageCut}");
                }
            }
            var crew = new List<IRobber>();
            while (true)
            {
                Console.Clear();
                double totalTake = 0;
                foreach (var member in crew)
                {
                    totalTake += member.PercentageCut;
                }
                Console.WriteLine("-----Potentials------");
                foreach (var member in rolodex)
                {
                    if (totalTake + member.PercentageCut >= 100)
                    {
                        rolodex.Remove(member);
                        if (rolodex.Count == 0)
                        {
                            break;
                        }
                    }
                }
                if (rolodex.Count == 0)
                {
                    Console.WriteLine("No More Availible Members");
                }
                else
                {
                    PrintRolodex();
                }
                Console.WriteLine($"-----The Crew-----");
                Console.WriteLine($"{totalTake}");
                foreach (var dude in crew)
                {
                    Console.WriteLine($"{dude.Name} {dude.Title}");
                }
                Console.WriteLine("Add Member to crew.  Type Number Next to person.");
                string Member = Console.ReadLine();
                if (Member == "")
                {
                    break;
                }

                foreach (var person in rolodex)
                {
                    if (int.Parse(Member) == rolodex.IndexOf(person))
                    {
                        crew.Add(person);
                        rolodex.Remove(person);

                        break;
                    }
                }

            }
            Console.Clear();
            foreach (var member in crew)
            {
                member.PerformSkill(TheBank);
            }
            if (TheBank.IsSecure == true)
            {
                Console.WriteLine("YEYEYEYEYAEAUHA You Rich Bitch");
                double SoiCanCalculateMyMonies = 0;
                foreach (var member in crew)
                {
                    double Cash = TheBank.CashOnHand * (member.PercentageCut / 100);
                    SoiCanCalculateMyMonies += Cash;
                    Console.WriteLine($"{member.Name} Earns {Cash.ToString("C")}");
                }
                double MyCash = TheBank.CashOnHand - SoiCanCalculateMyMonies;
                Console.WriteLine($"I Made {MyCash.ToString("C")}");
            }
            else
            {
                Console.WriteLine("Bank too stronk You Lose");
            }

        }
    }
}