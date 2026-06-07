using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class ItemObtainedObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	private enum CountMode
	{
		Count = 0,
		GameStatsManager = 1,
		Community = 2
	}

	[Serializable]
	public new class PersistentData : QuestObjectiveBase.PersistentData
	{
		private int _obtainedAmount;

		public PersistentData(ItemObtainedObjective objective)
			: base(objective)
		{
			_obtainedAmount = objective._obtainedAmount;
		}

		public override bool TryRestore(IQuestObjective objective)
		{
			if (base.TryRestore(objective) && objective is ItemObtainedObjective itemObtainedObjective)
			{
				itemObtainedObjective._obtainedAmount = _obtainedAmount;
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Obtain items";

	[SerializeField]
	private ObjectiveInitialization _initialization;

	[SerializeField]
	private CountMode _countMode = CountMode.GameStatsManager;

	[SerializeField]
	private GameEventType[] _gameEventTypes = new GameEventType[5]
	{
		GameEventType.ProducerItemProduced,
		GameEventType.ItemFarmed,
		GameEventType.AgentActionSalvagedLandmarkItem,
		GameEventType.AgentActionSalvagedMarkerItem,
		GameEventType.AgentActionSalvagedSalvagerItem
	};

	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	private int _amount;

	private int _obtainedAmount = -1;

	public ItemObtainedObjective()
	{
	}

	public ItemObtainedObjective(ItemObtainedObjective other)
		: base(other)
	{
		_initialization = other._initialization;
		_countMode = other._countMode;
		_gameEventTypes = other._gameEventTypes.Clone() as GameEventType[];
		_itemProperties = other._itemProperties;
		_amount = other._amount;
		_obtainedAmount = other._obtainedAmount;
	}

	public override void Initialize()
	{
		if (_initialization == ObjectiveInitialization.Initialize)
		{
			OnInitialize();
		}
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (active && _initialization == ObjectiveInitialization.SetActive)
		{
			OnInitialize();
		}
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return _obtainedAmount >= _amount;
	}

	public override void Uninitialize()
	{
		GameEventType[] gameEventTypes = _gameEventTypes;
		for (int i = 0; i < gameEventTypes.Length; i++)
		{
			GameEventDispatcher.RemoveListener(gameEventTypes[i], OnGameEvent);
		}
	}

	private void OnInitialize()
	{
		InitializeObtainedAmount();
		bool flag = IsCompleted();
		SetCompleted(flag, sendEvent: false);
		if (!flag)
		{
			GameEventType[] gameEventTypes = _gameEventTypes;
			for (int i = 0; i < gameEventTypes.Length; i++)
			{
				GameEventDispatcher.AddListener(gameEventTypes[i], OnGameEvent);
			}
		}
	}

	private void InitializeObtainedAmount()
	{
		switch (_countMode)
		{
		case CountMode.GameStatsManager:
		{
			GameStatsManager gameStatsManager = GameManager.GameStatsManager;
			_obtainedAmount = 0;
			if (_gameEventTypes.Contains(GameEventType.ProducerItemProduced))
			{
				_obtainedAmount += gameStatsManager.GetProducedItemsCount(_itemProperties);
			}
			if (_gameEventTypes.Contains(GameEventType.ItemFarmed))
			{
				_obtainedAmount += gameStatsManager.GetFarmedItemCount(_itemProperties);
			}
			if (_gameEventTypes.Contains(GameEventType.AgentActionSalvagedMarkerItem))
			{
				_obtainedAmount += gameStatsManager.GetSalvagedMarkerItemsCount(_itemProperties);
			}
			if (_gameEventTypes.Contains(GameEventType.AgentActionSalvagedLandmarkItem))
			{
				_obtainedAmount += gameStatsManager.GetSalvagedLandmarkItemsCount(_itemProperties);
			}
			if (_gameEventTypes.Contains(GameEventType.AgentActionSalvagedSalvagerItem))
			{
				_obtainedAmount += gameStatsManager.GetSalvagedSalvagerItemCount(_itemProperties);
			}
			break;
		}
		case CountMode.Community:
			_obtainedAmount = Community.PlayerCommunity.Inventory.ReturnCount(_itemProperties);
			break;
		default:
			if (_obtainedAmount < 0)
			{
				_obtainedAmount = 0;
			}
			break;
		}
	}

	private void OnGameEvent(GameEvent gameEvent)
	{
		ItemProperties itemProperties = null;
		if (gameEvent is AgentActionItemPropertiesEvent agentActionItemPropertiesEvent)
		{
			itemProperties = agentActionItemPropertiesEvent.ItemProperties;
		}
		else if (gameEvent is ItemEvent itemEvent)
		{
			itemProperties = itemEvent.ItemProperties;
		}
		if (itemProperties == _itemProperties)
		{
			if (++_obtainedAmount >= _amount)
			{
				SetCompleted(completed: true);
			}
			else
			{
				QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
			}
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Obtain Item(s): " + ((_itemProperties != null) ? _itemProperties.LocalizedName : "Any");
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _obtainedAmount;
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

	public override object Clone()
	{
		return new ItemObtainedObjective(this);
	}

	public override IQuestObjective.IPersistentData GetPersistentData()
	{
		if (_countMode == CountMode.Count)
		{
			return new PersistentData(this);
		}
		return base.GetPersistentData();
	}
}
