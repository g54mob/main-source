using System;
using UnityEngine;

[Serializable]
public class DialogueEventStartQuest : IDialogueEvent
{
	[SerializeField]
	private QuestProperties _questProperties;

	public void TriggerEvent(Dialogue dialogue)
	{
		StoryManager.StartQuest(_questProperties);
	}
}
