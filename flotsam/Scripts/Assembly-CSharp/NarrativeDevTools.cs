using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarrativeDevTools : MonoBehaviour
{
	[SerializeField]
	private QuestProperties[] _quests;

	[SerializeField]
	private TMP_Dropdown _questDropdown;

	private List<string> _questOptions = new List<string>();

	private void OnEnable()
	{
		_questOptions.Clear();
		QuestProperties[] quests = _quests;
		foreach (QuestProperties questProperties in quests)
		{
			_questOptions.Add(questProperties.name);
		}
		_questDropdown.ClearOptions();
		_questDropdown.AddOptions(_questOptions);
	}

	public void StartSelectedQuest()
	{
		StoryManager.StartQuest(_quests[_questDropdown.value]);
	}

	public void SkipCurrentQuest()
	{
		IReadOnlyList<Quest> activeQuests = GameManager.StoryManager.ActiveQuests;
		if (activeQuests.Count > 1)
		{
			Debug.LogError("This cheat was designed with only one active quest at a time in mind; there are currently multiple and we'll just pick the latest. Please contact a dev to adapt this if needed.");
		}
		else if (activeQuests.Count > 0)
		{
			activeQuests[activeQuests.Count - 1].SetCompleted();
		}
	}

	public void ReceiveDistressSignal()
	{
		throw new NotImplementedException();
	}
}
