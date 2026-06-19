using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionSilverEarned : SubGoalDefinition
	{
		public int TargetAmount;

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.EarnSilver_Goal_CS.Replace("{[SILVER]}", StringUtils.FormatSilverCurrency(TargetAmount));
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalSilverEarned(owner, this);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
