using System.Collections.Generic;
using UnityEngine;

public class SessionQuest_TotalGamesPlayed : SessionQuest
{
	[SerializeField]
	private List<int> neededScorePerLevel;

	public override string GetDescription(int level = -1)
	{
		int value = ((level == -1) ? CurrentLevel.index : level);
		string localizedValue = LocalizationManager.Instance.GetLocalizedValue(descriptionKey);
		localizedValue = localizedValue.Replace("[y]", neededScorePerLevel[Mathf.Clamp(value, 0, neededScorePerLevel.Count - 1)].ToString());
		localizedValue = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(localizedValue, TargetCount(level));
		return localizedValue.Replace("[x]", TargetCount(level).ToString());
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.StartWatching(sessionQuestWatcher);
		if (!base.Completed)
		{
			rewardSystem.OnGameOver += AddProgress;
		}
	}

	private void AddProgress(bool animate, bool setHighscore)
	{
		if (setHighscore && (neededScorePerLevel.Count <= CurrentLevelIndex || rewardSystem.Score >= neededScorePerLevel[CurrentLevelIndex]))
		{
			currentProgress++;
			ProgressChanged(save: true);
			ExecuteFulfillment();
		}
	}

	public override void StopWatching()
	{
		base.StopWatching();
		rewardSystem.OnGameOver -= AddProgress;
	}
}
