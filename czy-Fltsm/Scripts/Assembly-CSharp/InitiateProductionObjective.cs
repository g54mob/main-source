using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class InitiateProductionObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Initiate production";

	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	private int _amount;

	private int _producedAmount;

	public InitiateProductionObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnBuildableSelected);
	}

	public InitiateProductionObjective(InitiateProductionObjective other)
		: base(other)
	{
		_itemProperties = other._itemProperties;
		_amount = other._amount;
		_producedAmount = other._producedAmount;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			return GameManager.GameStatsManager.GetItemProductionsQueuedCount(_itemProperties) > 0;
		}
		return true;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.ProducerItemQueued, OnProducerItemQueued);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ProducerItemQueued, OnProducerItemQueued);
	}

	private void OnProducerItemQueued(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent itemEvent && !(itemEvent.ItemProperties != _itemProperties) && ++_producedAmount >= _amount)
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Initiate Item Production: " + ((_itemProperties != null) ? _itemProperties.LocalizedName : "Any");
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _producedAmount;
		goalValue = _amount;
		return true;
	}

	public override string GetParameterValue(string param)
	{
		if (param == "ITEM")
		{
			return (_itemProperties != null) ? _itemProperties.LocalizedName : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		Producer buildableExtendable;
		if (dialogueTriggerType == DialogueTriggerType.OnBuildableSelected)
		{
			return (target is Buildable buildable && buildable.TryReturnBuildableExtendable<Producer>(out buildableExtendable) && buildableExtendable.ProducedItems.Contains(_itemProperties)) || (target is BuildableProperties buildableProperties && buildableProperties.Prefab.TryReturnBuildableExtendable<Producer>(out buildableExtendable) && buildableExtendable.ProducedItems.Contains(_itemProperties));
		}
		return false;
	}

	public override object Clone()
	{
		return new InitiateProductionObjective(this);
	}
}
