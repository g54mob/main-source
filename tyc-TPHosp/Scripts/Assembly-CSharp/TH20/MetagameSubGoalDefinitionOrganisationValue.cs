using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionOrganisationValue : SubGoalDefinition
	{
		public int TargetAmount;

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.OrganisationValue_Goal_CS.Replace("{[CASH]}", StringUtils.FormatCurrency(TargetAmount));
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalOrganisationValue(owner, this);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
