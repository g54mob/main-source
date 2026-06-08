namespace Dorfromantik
{
	public class Challenge_PreplacedTilesDiscovered : SessionQuest
	{
		public override string GetDescription(int level = -1)
		{
			string description = base.GetDescription(level);
			return LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(description, TargetCount(level));
		}

		public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
		{
			base.StartWatching(sessionQuestWatcher);
			if (!base.Completed)
			{
				rewardSystem.OnPreplacedTileConnected += UpdateProgress;
			}
		}

		private void UpdateProgress(PreplacedTileHint preplacedTileHint)
		{
			currentProgress++;
			ProgressChanged(save: true);
			ExecuteFulfillment();
		}

		public override void StopWatching()
		{
			base.StopWatching();
			rewardSystem.OnPreplacedTileConnected -= UpdateProgress;
		}
	}
}
