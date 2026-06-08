namespace Dorfromantik
{
	public class Challenge_ScorePerPlacement : SessionQuest
	{
		private int currentPlacementScore;

		public override string GetDescription(int level = -1)
		{
			string description = base.GetDescription(level);
			return LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(description, TargetCount(level));
		}

		protected override void InitializeProgress()
		{
			currentProgress = 0;
		}

		public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
		{
			base.StartWatching(sessionQuestWatcher);
			rewardSystem.OnScoreChanged += AddScore;
		}

		public override void ExecuteFulfillment(Tile placedTile = null, bool isPlacedByPlayer = true)
		{
			currentPlacementScore = 0;
			while (CurrentState != RewardState.Completed && IsFulfilled())
			{
				base.ExecuteFulfillment(placedTile, isPlacedByPlayer);
			}
			if (currentProgress >= TargetCount())
			{
				currentProgress = currentPlacementScore;
				ProgressChanged(save: true);
			}
		}

		private void AddScore(int addedScore)
		{
			currentPlacementScore += addedScore;
			currentProgress = currentPlacementScore;
			ProgressChanged(save: true);
		}

		public override void StopWatching()
		{
			base.StopWatching();
			rewardSystem.OnScoreChanged -= AddScore;
		}
	}
}
