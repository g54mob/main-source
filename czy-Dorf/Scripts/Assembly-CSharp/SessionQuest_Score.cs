public class SessionQuest_Score : SessionQuest
{
	public override string GetDescription(int level = -1)
	{
		string description = base.GetDescription(level);
		return LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(description, TargetCount(level));
	}

	protected override void InitializeProgress()
	{
		if (!storeProgress)
		{
			currentProgress = rewardSystem.Score;
		}
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.StartWatching(sessionQuestWatcher);
		if (!base.Completed)
		{
			rewardSystem.OnScoreChanged += UpdateProgress;
		}
	}

	private void UpdateProgress(int addedScore)
	{
		if (!storeProgress)
		{
			currentProgress = rewardSystem.Score;
		}
		else
		{
			currentProgress += addedScore;
		}
		ProgressChanged(save: true);
		ExecuteFulfillment();
	}

	public override void StopWatching()
	{
		base.StopWatching();
		rewardSystem.OnScoreChanged -= UpdateProgress;
	}
}
