using System;

namespace heistpart2
{
  public class Muscle : IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }
    public string Title
    {
      get
      {
        return "Muscle";
      }
    }

    public void PerformSkill(Bank bank)
    {

      if (bank.SecurityGuardScore - SkillLevel <= 0)
      {
        Console.WriteLine($"{Name} Beat up the Security!");
        bank.SecurityGuardScore -= SkillLevel;

      }
      else
      {
        Console.WriteLine($"{Name} is fighting the security guard {bank.SecurityGuardScore -= SkillLevel}");

      }

    }
  }
}