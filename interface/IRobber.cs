namespace heistpart2
{
  public interface IRobber
  {
    string Name { get; set; }
    int SkillLevel { get; set; }
    double PercentageCut { get; set; }
    string Title { get; }

    void PerformSkill(Bank bank);

  }
}