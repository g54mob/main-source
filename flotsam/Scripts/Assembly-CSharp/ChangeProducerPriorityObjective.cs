using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class ChangeProducerPriorityObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Change production priority";

	[SerializeField]
	private int _priority;

	[SerializeField]
	private ComparisonType _comparisonType;

	public ChangeProducerPriorityObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnBuildableSelected);
	}

	public ChangeProducerPriorityObjective(ChangeProducerPriorityObjective other)
		: base(other)
	{
		_priority = other._priority;
		_comparisonType = other._comparisonType;
	}

	public override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.ProducerPriorityChange, OnPriorityChanged);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ProducerPriorityChange, OnPriorityChanged);
	}

	private void OnPriorityChanged(GameEvent gameEvent)
	{
		if (gameEvent is ProductionRecipeEvent productionRecipeEvent && productionRecipeEvent.RecipePriority.Compare(_comparisonType, _priority))
		{
			SetCompleted(completed: true);
			Uninitialize();
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return $"Change production priority: {_comparisonType} {_priority}";
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		Producer buildableExtendable;
		if (dialogueTriggerType == DialogueTriggerType.OnBuildableSelected)
		{
			return (target is Buildable buildable && buildable.TryReturnBuildableExtendable<Producer>(out buildableExtendable)) || (target is BuildableProperties buildableProperties && buildableProperties.Prefab.TryReturnBuildableExtendable<Producer>(out buildableExtendable));
		}
		return false;
	}

	public override object Clone()
	{
		return new ChangeProducerPriorityObjective(this);
	}
}
