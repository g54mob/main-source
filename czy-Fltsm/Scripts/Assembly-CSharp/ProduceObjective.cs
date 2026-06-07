using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class ProduceObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	public enum Mode
	{
		ItemProperties = 0,
		ItemType = 1
	}

	[Serializable]
	public new class PersistentData : QuestObjectiveBase.PersistentData
	{
		private readonly int _producedAmount;

		public PersistentData(ProduceObjective objective)
			: base(objective)
		{
			_producedAmount = objective._producedAmount;
		}

		public override bool TryRestore(IQuestObjective objective)
		{
			if (base.TryRestore(objective) && objective is ProduceObjective produceObjective)
			{
				produceObjective._producedAmount = _producedAmount;
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Produce";

	[SerializeField]
	private Mode _mode;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true)]
	private ItemProperties _itemProperties;

	[SerializeField]
	[ConditionalEnumHide("_mode", 1, true)]
	private ItemType _itemType;

	[SerializeField]
	private int _amount;

	[SerializeField]
	[Tooltip("How should the produced amount be initialized")]
	private ObjectiveAmountInitialization _initialProducedAmount = ObjectiveAmountInitialization.StatsManager;

	private int _producedAmount;

	public ProduceObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnBuildableSelected);
	}

	public ProduceObjective(ProduceObjective other)
		: base(other)
	{
		_mode = other._mode;
		_itemProperties = other._itemProperties;
		_itemType = other._itemType;
		_amount = other._amount;
		_initialProducedAmount = other._initialProducedAmount;
		_producedAmount = other._producedAmount;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return ((_producedAmount == 0) ? GetInitialProducedAmount() : _producedAmount) >= _amount;
	}

	public override void Initialize()
	{
		_producedAmount = GetInitialProducedAmount();
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.ProducerItemProduced, OnItemProduced);
			GameEventDispatcher.AddListener(GameEventType.ItemFarmed, OnItemProduced);
		}
	}

	public override void Uninitialize()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdatedEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ProducerItemProduced, OnItemProduced);
		GameEventDispatcher.RemoveListener(GameEventType.ItemFarmed, OnItemProduced);
	}

	private void OnItemProduced(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent itemEvent && itemEvent.ItemProperties != null)
		{
			IncrementProducedAmount(itemEvent.ItemProperties);
		}
	}

	private void OnInventoryUpdatedEvent()
	{
		_producedAmount = GetInitialProducedAmount();
	}

	private void IncrementProducedAmount(ItemProperties itemProperties)
	{
		switch (_mode)
		{
		case Mode.ItemProperties:
			if (!(itemProperties == _itemProperties))
			{
				return;
			}
			break;
		case Mode.ItemType:
			if (!(itemProperties.ItemType == _itemType))
			{
				return;
			}
			break;
		default:
			Debug.LogException(new NotImplementedException());
			return;
		}
		if (++_producedAmount >= _amount)
		{
			SetCompleted(completed: true, sendEvent: false);
		}
		QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Produce: " + ((_itemProperties != null) ? _itemProperties.LocalizedName : "Any");
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _producedAmount;
		goalValue = _amount;
		return true;
	}

	public override string GetParameterValue(string param)
	{
		if (!(param == "ITEMTYPE"))
		{
			if (param == "ITEM")
			{
				return (_itemProperties != null) ? _itemProperties.LocalizedName : "Any";
			}
			return base.GetParameterValue(param);
		}
		return (_itemType != null) ? ((string)_itemType.Name) : "NULL";
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		Producer buildableExtendable;
		if (dialogueTriggerType == DialogueTriggerType.OnBuildableSelected)
		{
			return (target is Buildable buildable && buildable.TryReturnBuildableExtendable<Producer>(out buildableExtendable) && IsProducerInContext(buildableExtendable)) || (target is BuildableProperties buildableProperties && buildableProperties.Prefab.TryReturnBuildableExtendable<Producer>(out buildableExtendable) && IsProducerInContext(buildableExtendable));
		}
		return false;
	}

	private bool IsProducerInContext(Producer producer)
	{
		if (_mode == Mode.ItemProperties)
		{
			return producer.ProducedItems.Contains(_itemProperties);
		}
		return _itemType != null && producer.ProducedItems.Find((ItemProperties item) => item.ItemType == _itemType) != null;
	}

	public override object Clone()
	{
		return new ProduceObjective(this);
	}

	private int GetInitialProducedAmount()
	{
		switch (_initialProducedAmount)
		{
		case ObjectiveAmountInitialization.Community:
		{
			CommunityInventory inventory = Community.PlayerCommunity.Inventory;
			if (_mode != Mode.ItemProperties)
			{
				return inventory.ReturnCount(_itemType);
			}
			return inventory.ReturnCount(_itemProperties);
		}
		case ObjectiveAmountInitialization.StatsManager:
		{
			GameStatsManager gameStatsManager = GameManager.GameStatsManager;
			if (_mode != Mode.ItemProperties)
			{
				return gameStatsManager.GetProducedItemsCount(_itemType);
			}
			return gameStatsManager.GetProducedItemsCount(_itemProperties);
		}
		default:
			return 0;
		}
	}

	public override IQuestObjective.IPersistentData GetPersistentData()
	{
		return new PersistentData(this);
	}
}
