using System;
using UnityEngine;

[Serializable]
public class ActivateModuleObjective : QuestObjectiveBase
{
	[SerializeField]
	private ModuleProperties _module;

	public ModuleProperties Module => _module;

	public ActivateModuleObjective()
	{
	}

	public ActivateModuleObjective(ActivateModuleObjective other)
		: base(other)
	{
		_module = other._module;
	}

	public override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.ModuleActivated, OnModuleActivated);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ModuleActivated, OnModuleActivated);
	}

	public override object Clone()
	{
		return new ActivateModuleObjective(this);
	}

	private void OnModuleActivated(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && buildableEvent.ModuleProperties == _module)
		{
			SetCompleted(completed: true);
		}
	}
}
