using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TutorialEvent_DisplayText))]
public class TutorialEvent_ReplaceTextWithQuestInfo : TutorialEvent
{
	private enum QuestInfo
	{
		TargetValue = 0,
		CurrentValue = 1,
		RemainingValue = 2,
		InitialRemainingValue = 3
	}

	[Serializable]
	private struct ReplacedQuestInfo
	{
		public string stringToReplace;

		public QuestInfo replacementInfo;
	}

	[SerializeField]
	private List<ReplacedQuestInfo> replacedInfo;

	[SerializeField]
	private bool useQuestOnStack;

	[SerializeField]
	private QuestManager questManager;

	private TextMeshProUGUI textLabel;

	private QuestWatcher watchedQuest;

	private TutorialEvent_DisplayText displayTextEvent;

	public override void Begin()
	{
		displayTextEvent = GetComponent<TutorialEvent_DisplayText>();
		watchedQuest = questManager.GetLatestQuest();
		int relativeCount = 0;
		foreach (ReplacedQuestInfo item in replacedInfo)
		{
			switch (item.replacementInfo)
			{
			case QuestInfo.TargetValue:
				relativeCount = questManager.GetLatestQuest(useQuestOnStack).GetConditionWatcher(0).TargetValue;
				break;
			case QuestInfo.RemainingValue:
				relativeCount = questManager.GetLatestQuest(useQuestOnStack).GetConditionWatcher(0).RemainingValue;
				break;
			case QuestInfo.CurrentValue:
				relativeCount = questManager.GetLatestQuest(useQuestOnStack).GetConditionWatcher(0).CurrentValue;
				break;
			}
			displayTextEvent.AddReplacement(item.stringToReplace, relativeCount.ToString());
		}
		displayTextEvent.SetRelativeCount(relativeCount);
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
	}
}
