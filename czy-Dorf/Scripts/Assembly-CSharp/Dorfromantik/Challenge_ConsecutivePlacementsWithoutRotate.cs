namespace Dorfromantik
{
	public class Challenge_ConsecutivePlacementsWithoutRotate : SessionQuest
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
				rewardSystem.OnConsecutivePlacementsWithoutRotateChanged += UpdateProgress;
			}
		}

		protected override void InitializeProgress()
		{
			currentProgress = rewardSystem.ConsecutivePlacementsWithoutRotate;
		}

		private void UpdateProgress()
		{
			currentProgress = rewardSystem.ConsecutivePlacementsWithoutRotate;
			ProgressChanged(save: true);
			ExecuteFulfillment();
		}

		public override void StopWatching()
		{
			base.StopWatching();
			rewardSystem.OnConsecutivePlacementsWithoutRotateChanged -= UpdateProgress;
		}
	}
}
