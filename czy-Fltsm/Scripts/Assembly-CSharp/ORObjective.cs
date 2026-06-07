using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class ORObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "OR";

	[SerializeReference]
	[SubclassSelector]
	private List<IQuestObjective> _objectives = new List<IQuestObjective>();

	public override bool IsOptional
	{
		get
		{
			if (!base.IsOptional)
			{
				return _objectives.Find((IQuestObjective objective) => objective.IsOptional) != null;
			}
			return true;
		}
	}

	public ORObjective()
	{
	}

	public ORObjective(ORObjective other)
		: base(other)
	{
		_objectives = other._objectives.Clone();
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			return _objectives.Find((IQuestObjective objective) => objective.IsCompleted()) != null;
		}
		return true;
	}

	public override void SetOwningQuest(Quest owningQuest)
	{
		base.SetOwningQuest(owningQuest);
		foreach (IQuestObjective objective in _objectives)
		{
			objective.SetOwningQuest(owningQuest);
		}
	}

	public override void Initialize()
	{
		foreach (IQuestObjective objective in _objectives)
		{
			objective.Initialize();
		}
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, CheckObjectivesCompletion);
		}
	}

	public override void InitializeDialogueTriggers()
	{
		base.InitializeDialogueTriggers();
		foreach (IQuestObjective objective in _objectives)
		{
			objective.InitializeDialogueTriggers();
		}
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		foreach (IQuestObjective objective in _objectives)
		{
			objective.SetActive(active);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, CheckObjectivesCompletion);
		foreach (IQuestObjective objective in _objectives)
		{
			objective.Uninitialize();
		}
	}

	public override void UninitializeDialogueTriggers()
	{
		base.UninitializeDialogueTriggers();
		foreach (IQuestObjective objective in _objectives)
		{
			objective.UninitializeDialogueTriggers();
		}
	}

	private void CheckObjectivesCompletion(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent && _objectives.Contains(questEvent.Objective) && questEvent.Objective.IsCompleted())
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int i = 0;
		for (int count = _objectives.Count; i < count; i++)
		{
			IQuestObjective questObjective = _objectives[i];
			if (!questObjective.IsHidden)
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(" or ");
				}
				if (questObjective is ORObjective || questObjective is ANDObjective)
				{
					stringBuilder.Append($"({questObjective})");
				}
				else
				{
					stringBuilder.Append(questObjective);
				}
			}
		}
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		return new ORObjective(this);
	}
}
