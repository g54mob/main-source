public class SessionQuest_ConsecutivePerfectFits : SessionQuest
{
	public override string GetDescription(int level = -1)
	{
		string description = base.GetDescription(level);
		return LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(description, TargetCount(level));
	}

	protected override void InitializeProgress()
	{
		currentProgress = rewardSystem.ConsecutivePerfectFits;
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.StartWatching(sessionQuestWatcher);
		if (!base.Completed)
		{
			rewardSystem.OnConsecutivePerfectFitsChanged += UpdateProgress;
		}
	}

	private void UpdateProgress()
	{
		currentProgress = rewardSystem.ConsecutivePerfectFits;
		ProgressChanged(save: true);
		ExecuteFulfillment();
	}

	public override void StopWatching()
	{
		base.StopWatching();
		if ((bool)rewardSystem)
		{
			rewardSystem.OnConsecutivePerfectFitsChanged -= UpdateProgress;
		}
	}
}
