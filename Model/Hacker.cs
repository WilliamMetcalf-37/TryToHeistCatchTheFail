using System;

namespace heistpart2
{
  public class Hacker : IRobber
  {
    public string Name { get; set; }

    public string Title
    {
      get
      {
        return "Hacker";
      }
    }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }

    public void PerformSkill(Bank bank)
    {
      if (bank.AlarmScore - SkillLevel <= 0)
      {
        Console.WriteLine($"{Name} Turned the Alarm Off!");
        bank.AlarmScore -= SkillLevel;
      }
      else
      {
        Console.WriteLine($"{Name} is hacking Bank Alarm. The Bank Alarm score is now {bank.AlarmScore -= SkillLevel}");

      }

    }
  }
}