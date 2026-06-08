namespace Dorfromantik
{
	public class Challenge_PerfectPlacementsAtOnce : SessionQuest
	{
		private int perfectPlacementsWithCurrentTile;

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
			if (!base.Completed)
			{
				rewardSystem.OnPerfectPlacement += CountPerfectPlacement;
				tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += EvaluatePerfectPlacementCount;
			}
		}

		private void EvaluatePerfectPlacementCount(Tile arg1, bool arg2)
		{
			currentProgress = perfectPlacementsWithCurrentTile;
			ProgressChanged(save: true);
			while (CurrentState != RewardState.Completed && IsFulfilled())
			{
				ExecuteFulfillment();
			}
			perfectPlacementsWithCurrentTile = 0;
			if (currentProgress >= TargetCount())
			{
				currentProgress = perfectPlacementsWithCurrentTile;
				ProgressChanged(save: true);
			}
		}

		private void CountPerfectPlacement()
		{
			perfectPlacementsWithCurrentTile++;
		}

		public override void StopWatching()
		{
			base.StopWatching();
			rewardSystem.OnPerfectPlacement -= CountPerfectPlacement;
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= EvaluatePerfectPlacementCount;
		}
	}
}
