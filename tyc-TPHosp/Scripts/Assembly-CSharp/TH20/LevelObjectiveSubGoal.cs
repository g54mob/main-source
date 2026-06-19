namespace TH20
{
	public abstract class LevelObjectiveSubGoal : ObjectiveSubGoal
	{
		protected Level Level;

		protected LevelObjectiveSubGoal(Objective owner, SubGoalDefinition definition)
			: base(owner, definition)
		{
			LevelObjective levelObjective = (LevelObjective)owner;
			Level = levelObjective.Level;
		}
	}
}
