using System;
using UnityEngine;

[Serializable]
public class ChangeDrifterAssignmentPriorityObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Change drifter assignment priority";

	public ChangeDrifterAssignmentPriorityObjective()
	{
	}

	public ChangeDrifterAssignmentPriorityObjective(ChangeDrifterAssignmentPriorityObjective other)
		: base(other)
	{
	}

	public override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentAssignmentUpdated, OnPriorityChanged);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAssignmentUpdated, OnPriorityChanged);
	}

	private void OnPriorityChanged(GameEvent gameEvent)
	{
		SetCompleted(completed: true);
		Uninitialize();
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Change drifter assignment priority";
	}

	public override object Clone()
	{
		return new ChangeDrifterAssignmentPriorityObjective(this);
	}
}
