using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvent_SetTextBasedOnQuestFailedReason : TutorialEvent
{
	[Serializable]
	private class QuestFailedReasonText
	{
		public QuestFailedReason failedReason;

		public string displayedText;
	}

	private TutorialEvent_DisplayText displayTextEvent;

	[SerializeField]
	private TutorialWatcher_OnQuestFulfilled questFailedReasonSource;

	[SerializeField]
	private List<QuestFailedReasonText> failedReasonExplanations;

	private Dictionary<QuestFailedReason, string> textByFailedReason;

	public override void Begin()
	{
		textByFailedReason = new Dictionary<QuestFailedReason, string>();
		foreach (QuestFailedReasonText failedReasonExplanation in failedReasonExplanations)
		{
			textByFailedReason.Add(failedReasonExplanation.failedReason, failedReasonExplanation.displayedText);
		}
		displayTextEvent = GetComponent<TutorialEvent_DisplayText>();
		displayTextEvent.SetLocalizationKey(textByFailedReason[questFailedReasonSource.questFailedReason]);
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
	}
}
