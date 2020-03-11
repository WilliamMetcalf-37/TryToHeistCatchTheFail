using System;

namespace heistpart2
{
  public class LockPickSpecialist : IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }
    public string Title
    {
      get
      {
        return "LockPick";
      }
    }

    public void PerformSkill(Bank bank)
    {
      if (bank.VaultScore - SkillLevel <= 0)
      {
        Console.WriteLine($"{Name} Picked the Vault Lock!");
        bank.VaultScore -= SkillLevel;
      }
      else
      {
        Console.WriteLine($"{Name} is Picking the Vault Lock.  Bank Vault Score is now {bank.VaultScore -= SkillLevel}");

      }
    }
  }
}