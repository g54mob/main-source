using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectivesHandler : SceneBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private ChildBehaviourCache<QuestObjectiveDisplay> _objectivesDisplays;

	[SerializeField]
	private GameObject _reopenQuestDialogueButton;

	private Quest _currentQuest;

	private readonly Dictionary<IQuestObjective, int> _objectivesIndices = new Dictionary<IQuestObjective, int>();

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.QuestUpdated, OnQuestDisplayRefresh);
		GameEventDispatcher.AddListener(GameEventType.QuestTracked, OnQuestDisplayRefresh);
		GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, OnObjectiveUpdated);
		GameEventDispatcher.AddListener(GameEventType.QuestAbandoned, OnQuestFailed);
		GameEventDispatcher.AddListener(GameEventType.QuestFailed, OnQuestFailed);
		SetActive(active: false);
	}

	private void Start()
	{
		SetActive(active: true);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestUpdated, OnQuestDisplayRefresh);
		GameEventDispatcher.RemoveListener(GameEventType.QuestTracked, OnQuestDisplayRefresh);
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, OnObjectiveUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.QuestAbandoned, OnQuestFailed);
		GameEventDispatcher.RemoveListener(GameEventType.QuestFailed, OnQuestFailed);
	}

	public void ReopenQuestDialogue()
	{
		if (_currentQuest != null && !GameManager.UIManager.IsPanelOpen(PanelID.DialoguePanel))
		{
			_currentQuest.RepeatLastDialogue();
		}
	}

	private void SetActive(bool active)
	{
		base.gameObject.SetActive(active);
		_reopenQuestDialogueButton.SetActive(active && _currentQuest != null && _currentQuest.DialogueProperties != null);
	}

	private void OnQuestDisplayRefresh(GameEvent gameEvent)
	{
		_objectivesDisplays.Reset();
		_objectivesIndices.Clear();
		if (StoryManager.TryGetActiveQuest(out var quest) && quest.HasActiveVisibleObjectives())
		{
			_currentQuest = quest;
			SetActive(PopulateObjectives());
		}
		else
		{
			_currentQuest = null;
			_reopenQuestDialogueButton.SetActive(value: false);
			SetActive(active: false);
		}
		_objectivesDisplays.Trim();
	}

	private bool PopulateObjectives()
	{
		using ListPool<IQuestObjective>.List list = ListPool<IQuestObjective>.Get();
		_currentQuest.PopulateVisibleObjectives(list);
		if (list.Count == 0)
		{
			return false;
		}
		_title.text = _currentQuest.Properties.QuestTitle;
		foreach (IQuestObjective item in list)
		{
			if (!_objectivesIndices.TryGetValue(item, out var value))
			{
				_objectivesDisplays.Get(active: true, out value);
				_objectivesIndices.Add(item, value);
			}
			_objectivesDisplays[value].InitializeDisplay(item, _currentQuest.Objectives);
		}
		return true;
	}

	private void OnObjectiveUpdated(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent { Objective: not null } questEvent && _objectivesIndices.TryGetValue(questEvent.Objective, out var value))
		{
			_objectivesDisplays[value].UpdateDisplay(questEvent.Objective);
		}
	}

	private void OnQuestFailed(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent && questEvent.Quest == _currentQuest)
		{
			SetActive(active: false);
		}
	}
}
