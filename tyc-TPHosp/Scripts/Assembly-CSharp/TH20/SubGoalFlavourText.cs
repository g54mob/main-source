namespace TH20
{
	public class SubGoalFlavourText : LevelObjectiveSubGoal
	{
		public SubGoalFlavourText(Objective owner, SubGoalDefinition definition)
			: base(owner, definition)
		{
		}

		protected override bool HasCompleted()
		{
			return true;
		}

		public override float PercentComplete()
		{
			return 1f;
		}

		public override int Score()
		{
			return 0;
		}

		public override string ProgressText()
		{
			return string.Empty;
		}
	}
}
