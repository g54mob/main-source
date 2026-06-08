using System.Collections.Generic;
using UnityEngine;

public class Challenge_QuestsFulfilled : SessionQuest
{
	[SerializeField]
	private List<QuestConditionType> filterQuestConditions;

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
			rewardSystem.OnQuestCompleted += UpdateProgress;
		}
	}

	private void UpdateProgress(QuestWatcher fulfilledQuest)
	{
		if (filterQuestConditions.Count == 0 || filterQuestConditions.Contains(fulfilledQuest.GetConditionWatcher(0).Condition.conditionType))
		{
			currentProgress++;
			ProgressChanged(save: true);
		}
	}

	public override void StopWatching()
	{
		base.StopWatching();
		rewardSystem.OnQuestCompleted -= UpdateProgress;
	}
}
