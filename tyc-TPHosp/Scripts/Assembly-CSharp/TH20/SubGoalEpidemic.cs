namespace TH20
{
	public class SubGoalEpidemic : LevelObjectiveSubGoal
	{
		private ChallengeEpidemic _challenge;

		public SubGoalEpidemic(Objective owner, SubGoalDefinition definition)
			: base(owner, definition)
		{
			_challenge = (ChallengeEpidemic)owner;
		}

		protected override bool HasCompleted()
		{
			return false;
		}

		public override float PercentComplete()
		{
			return 0f;
		}

		public override int Score()
		{
			return 0;
		}

		public override string ProgressText()
		{
			return _challenge.GetProgressText();
		}

		public new void UpdateProgress()
		{
			base.UpdateProgress();
		}
	}
}
