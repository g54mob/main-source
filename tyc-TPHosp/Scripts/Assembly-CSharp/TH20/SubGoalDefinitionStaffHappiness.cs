using I2.Loc;

namespace TH20
{
	public class SubGoalDefinitionStaffHappiness : SubGoalDefinition
	{
		public float _targetHappiness;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalStaffHappiness(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return LocalisedString.Replace(ScriptLocalization.Challenges_SubGoals.StaffHappiness_Goal_CS, "{[TARGET]}", StringUtils.FormatPercentageValue(_targetHappiness / 100f));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
