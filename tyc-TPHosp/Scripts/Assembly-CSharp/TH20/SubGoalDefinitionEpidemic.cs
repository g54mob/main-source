namespace TH20
{
	public class SubGoalDefinitionEpidemic : SubGoalDefinition
	{
		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalEpidemic(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return null;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
