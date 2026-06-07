using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class QuestObjectives : ICloneable
{
	[Serializable]
	public class ObjectivesGroup
	{
		public List<int> Group = new List<int>();
	}

	private struct TimedObjective
	{
		public IQuestObjective Objective;

		public int DaysLeft;

		public TimedObjective(IQuestObjective objective, int daysLeft)
		{
			Objective = objective;
			DaysLeft = daysLeft;
		}
	}

	[SerializeField]
	[Tooltip("Groups of objective indexes that will show together on the UI. We show the next group when all the objectives of the previous one are completed")]
	[FormerlySerializedAs("_objectiveUIGroups")]
	private List<ObjectivesGroup> _objectiveGroups = new List<ObjectivesGroup>();

	[SerializeReference]
	[InstantiateSerializeReference]
	private List<IQuestObjective> _objectives = new List<IQuestObjective>();

	public Action OnCompleted;

	public Action<IQuestObjective> OnObjectiveTimedOut;

	private WeakReference<Quest> _owningQuest;

	private int _currentObjectivesGroupIndex = -1;

	private readonly List<IQuestObjective> _currentObjectivesGroup = new List<IQuestObjective>();

	private bool _isCompleted;

	public IReadOnlyList<IQuestObjective> Objectives => _objectives;

	public IReadOnlyList<ObjectivesGroup> ObjectiveGroups => _objectiveGroups;

	public IReadOnlyList<IQuestObjective> CurrentObjectivesGroup => _currentObjectivesGroup;

	public bool IsStarted => _currentObjectivesGroupIndex != -1;

	public void SetOwningQuest(Quest owningQuest)
	{
		_owningQuest = new WeakReference<Quest>(owningQuest);
		foreach (IQuestObjective objective in _objectives)
		{
			objective.SetOwningQuest(owningQuest);
		}
	}

	public void InitializeDialogueTriggers()
	{
		foreach (IQuestObjective objective in _objectives)
		{
			objective.InitializeDialogueTriggers();
		}
	}

	public void Start()
	{
		foreach (IQuestObjective objective in _objectives)
		{
			objective.Initialize();
		}
		if (IsCompleted())
		{
			SetCompleted();
			return;
		}
		SetCurrentObjectivesGroupID(0);
		GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, OnQuestObjectiveUpdated);
		FinalUpdate.RegisterEndOfFrameOneShot(CheckObjectivesCompletion);
	}

	~QuestObjectives()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, OnQuestObjectiveUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
		foreach (IQuestObjective objective in _objectives)
		{
			objective.Uninitialize();
			objective.UninitializeDialogueTriggers();
		}
	}

	public void SetCompleted()
	{
		if (!_isCompleted)
		{
			_isCompleted = true;
			Uninitialize();
			OnCompleted.SafeInvoke();
			OnCompleted = null;
		}
	}

	public void ShowNextObjectivesGroup(Quest owningQuest)
	{
		SetCurrentObjectivesGroupID(_currentObjectivesGroupIndex + 1);
		foreach (IQuestObjective item in CurrentObjectivesGroup)
		{
			item.TriggerShownToPlayer();
		}
		if (owningQuest != null)
		{
			QuestEvent.DispatchQuestUpdated(owningQuest);
		}
	}

	private void ShowNextObjectivesGroup()
	{
		if (_owningQuest.TryGetTarget(out var target) && target.Properties.QuestType != QuestType.Tutorial)
		{
			ShowNextObjectivesGroup(target);
		}
	}

	public int GetRemainingDaysCount(IQuestObjective objective)
	{
		Debug.LogException(new NotImplementedException());
		return 0;
	}

	private void SetCurrentObjectivesGroupID(int id)
	{
		if (id == _currentObjectivesGroupIndex)
		{
			return;
		}
		bool flag = _objectiveGroups.IsValidIndex(id);
		if (flag && IsObjectivesGroupCompleted(id))
		{
			SetCurrentObjectivesGroupID(++id);
			return;
		}
		using ListPool<IQuestObjective>.List list = ListPool<IQuestObjective>.Get(_currentObjectivesGroup);
		_currentObjectivesGroupIndex = id;
		_currentObjectivesGroup.Clear();
		if (flag)
		{
			foreach (int item in _objectiveGroups[_currentObjectivesGroupIndex].Group)
			{
				if (item >= _objectives.Count)
				{
					Debug.LogError($"Objectives group number {_currentObjectivesGroupIndex} has an index out of range of the objectives! ({item})!");
					continue;
				}
				IQuestObjective questObjective = _objectives[item];
				if (list.Contains(questObjective))
				{
					questObjective.TriggerObjectivesGroupCompleted();
					list.Remove(questObjective);
				}
				else
				{
					questObjective.SetActive(active: true);
				}
				_currentObjectivesGroup.Add(questObjective);
			}
		}
		foreach (IQuestObjective item2 in list)
		{
			item2.SetActive(active: false);
			item2.TriggerObjectivesGroupCompleted();
		}
		CheckObjectivesCompletion();
	}

	private void OnQuestObjectiveUpdated(GameEvent gameEvent)
	{
		CheckObjectivesCompletion();
	}

	private void CheckObjectivesCompletion()
	{
		List<int> list = _objectiveGroups[_currentObjectivesGroupIndex].Group;
		bool flag = true;
		bool flag2 = true;
		for (int i = 0; i < _objectives.Count; i++)
		{
			IQuestObjective questObjective = _objectives[i];
			if (!questObjective.IsOptional && !questObjective.IsCompleted())
			{
				flag = false;
				if (list.Contains(i))
				{
					flag2 = false;
					break;
				}
			}
		}
		if (flag)
		{
			SetCompleted();
		}
		else if (flag2)
		{
			FinalUpdate.RegisterEndOfFrameOneShot(ShowNextObjectivesGroup);
		}
	}

	private void OnPanelClosed(GameEvent gameEvent = null)
	{
		if (gameEvent == null || gameEvent is PanelEvent { ID: PanelID.DialoguePanel })
		{
			GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
			ShowNextObjectivesGroup();
		}
	}

	public void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, OnQuestObjectiveUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
		foreach (IQuestObjective objective in _objectives)
		{
			objective.Uninitialize();
			objective.UninitializeDialogueTriggers();
		}
	}

	public object Clone()
	{
		return new QuestObjectives
		{
			_isCompleted = _isCompleted,
			_objectiveGroups = _objectiveGroups,
			_objectives = _objectives.Clone()
		};
	}

	public bool IsCompleted()
	{
		return AreObjectivesCompleted(_objectives);
	}

	private bool AreObjectivesCompleted(List<IQuestObjective> objectives)
	{
		foreach (IQuestObjective objective in objectives)
		{
			if (!objective.IsOptional && !objective.IsCompleted())
			{
				return false;
			}
		}
		return true;
	}

	private bool IsObjectivesGroupCompleted(int objectivesGroupIndex)
	{
		foreach (int item in _objectiveGroups[objectivesGroupIndex].Group)
		{
			IQuestObjective questObjective = _objectives[item];
			if (!questObjective.IsOptional && !questObjective.IsCompleted())
			{
				return false;
			}
		}
		return true;
	}

	public bool HasVisibleObjectives()
	{
		if (CurrentObjectivesGroup.IsNullOrEmpty())
		{
			return false;
		}
		foreach (IQuestObjective item in CurrentObjectivesGroup)
		{
			if (!item.IsHidden)
			{
				return true;
			}
		}
		return false;
	}

	public void PopulateVisibleObjective(List<IQuestObjective> visibleObjectives)
	{
		if (CurrentObjectivesGroup.IsNullOrEmpty())
		{
			return;
		}
		foreach (IQuestObjective item in CurrentObjectivesGroup)
		{
			if (!item.IsHidden)
			{
				visibleObjectives.Add(item);
			}
		}
	}

	public void Restore(List<IQuestObjective.IPersistentData> objectivesDataToRestore)
	{
		if (_objectives.IsNullOrEmpty())
		{
			return;
		}
		foreach (IQuestObjective objective in _objectives)
		{
			int count = objectivesDataToRestore.Count;
			while (0 < count--)
			{
				if ((!PersistenceManager.DoesSaveInfoVersionComeBefore(0, 8, 6) || objectivesDataToRestore[count].ObjectiveHashCode == objective.GetHashCode()) && objectivesDataToRestore[count].ObjectiveHashCode == objective.UniqueID)
				{
					if (!objectivesDataToRestore[count].TryRestore(objective))
					{
						Debug.LogException(new PersistenceException($"Could not restore objective {objective}!"));
					}
					objectivesDataToRestore.RemoveAt(count);
					break;
				}
			}
			objective.Initialize();
		}
		for (int i = 0; i < _objectiveGroups.Count; i++)
		{
			foreach (int item in _objectiveGroups[i].Group)
			{
				if (!_objectives[item].IsCompleted() && !_objectives[item].IsOptional)
				{
					SetCurrentObjectivesGroupID(i);
					GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, OnQuestObjectiveUpdated);
					FinalUpdate.RegisterEndOfFrameOneShot(delegate
					{
						CheckObjectivesCompletion();
					});
					return;
				}
			}
		}
		if (objectivesDataToRestore.Count > 0)
		{
			Debug.LogException(new PersistenceException("Could not restore all current objectives data!"));
		}
		else
		{
			SetCompleted();
		}
	}
}
