using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionEarnMoney : SubGoalDefinition
	{
		public int TargetAmount;

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.EarnMoney_Goal_CS.Replace("{[CASH]}", StringUtils.FormatCurrency(TargetAmount));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalEarnMoney(owner, this);
		}
	}
}
