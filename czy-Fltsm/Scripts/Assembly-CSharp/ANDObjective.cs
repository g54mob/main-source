using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class ANDObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "AND";

	[SerializeReference]
	[SubclassSelector]
	private List<IQuestObjective> _objectives = new List<IQuestObjective>();

	public override bool IsOptional
	{
		get
		{
			if (!base.IsOptional)
			{
				return _objectives.Find((IQuestObjective objective) => !objective.IsOptional) == null;
			}
			return true;
		}
	}

	public ANDObjective()
	{
	}

	public ANDObjective(ANDObjective other)
		: base(other)
	{
		_objectives = other._objectives.Clone();
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			return _objectives.Find((IQuestObjective objective) => !objective.IsCompleted()) == null;
		}
		return true;
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

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, CheckObjectivesCompletion);
		foreach (IQuestObjective objective in _objectives)
		{
			objective.Uninitialize();
		}
	}

	private void CheckObjectivesCompletion(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent && _objectives.Contains(questEvent.Objective) && IsCompleted())
		{
			SetCompleted(completed: true);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int i = 0;
		for (int count = _objectives.Count; i < count; i++)
		{
			IQuestObjective questObjective = _objectives[i];
			if (questObjective is ORObjective || questObjective is ANDObjective)
			{
				stringBuilder.Append($"({questObjective})");
			}
			else
			{
				stringBuilder.Append(questObjective);
			}
			if (i < count - 1)
			{
				stringBuilder.Append(" and ");
			}
		}
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		return new ANDObjective(this);
	}
}
