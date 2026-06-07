using System;
using Assets.Code.Story.Objectives;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class SalvageMarkerObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	public enum Mode
	{
		ItemProperties = 0,
		PointOfInterestVariable = 1
	}

	[Serializable]
	public new class PersistentData : QuestObjectiveBase.PersistentData
	{
		private readonly int _salvagedAmount;

		private readonly Vector3 _worldPosition = Vector3.zero;

		public PersistentData(SalvageMarkerObjective objective)
			: base(objective)
		{
			_salvagedAmount = objective._salvagedAmount;
		}

		public override bool TryRestore(IQuestObjective objective)
		{
			if (base.TryRestore(objective) && objective is SalvageMarkerObjective salvageMarkerObjective)
			{
				salvageMarkerObjective._salvagedAmount = _salvagedAmount;
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Salvage marker";

	[SerializeField]
	private int _amount;

	[SerializeField]
	private ObjectiveAmountInitialization _amountInitialization = ObjectiveAmountInitialization.StatsManager;

	[SerializeField]
	[Tooltip("Do we include resources salvaged before this objective started?")]
	private bool _includePreSalvaged = true;

	[SerializeField]
	private Mode _mode;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true)]
	private ItemProperties _itemProperties;

	[SerializeField]
	[ConditionalEnumHide("_mode", 1, true)]
	[QuestVariable(QuestVariableType.PointOfInterest)]
	private int _pointOfInterestVariable;

	[SerializeField]
	private SpawnerObjectiveBearing _bearing;

	private ISpawner _spawner;

	private int _salvagedAmount;

	public SalvageMarkerObjective()
	{
	}

	public SalvageMarkerObjective(SalvageMarkerObjective other)
		: base(other)
	{
		_amount = other._amount;
		_includePreSalvaged = other._includePreSalvaged;
		_mode = other._mode;
		_itemProperties = other._itemProperties;
		_pointOfInterestVariable = other._pointOfInterestVariable;
		_bearing = new SpawnerObjectiveBearing(other._bearing);
		_salvagedAmount = other._salvagedAmount;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return _salvagedAmount >= _amount;
	}

	public override void Initialize()
	{
		_salvagedAmount = (_includePreSalvaged ? GetInitialAmount() : 0);
		if (InitializeIsCompleted())
		{
			return;
		}
		GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedMarkerItem, OnItemSalvaged);
		if (_bearing.Enabled)
		{
			GameEventDispatcher.AddListener(GameEventType.MapActivated, OnMapOpened);
			if (GameManager.UIManager.UIState == UIState.Map)
			{
				OnMapOpened();
			}
		}
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (_spawner != null)
		{
			_bearing.SetActive(active);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedMarkerItem, OnItemSalvaged);
		GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapOpened);
		_bearing.Uninitialize();
	}

	private void OnItemSalvaged(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent agentActionItemPropertiesEvent && !(agentActionItemPropertiesEvent.ItemProperties != _itemProperties))
		{
			if (++_salvagedAmount >= _amount)
			{
				SetCompleted(completed: true, sendEvent: false);
			}
			QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
		}
	}

	private void OnMapOpened(GameEvent gameEvent = null)
	{
		_spawner = null;
		switch (_mode)
		{
		case Mode.ItemProperties:
		{
			WorldMapFlotsam nearestFlotsam = GetNearestFlotsam(_itemProperties);
			if ((bool)nearestFlotsam)
			{
				_spawner = nearestFlotsam.Spawner;
			}
			break;
		}
		case Mode.PointOfInterestVariable:
			if (base.Quest.TryGetVariableValue<ISpawner>(this, _pointOfInterestVariable, out _spawner))
			{
				AddBlockingSpawner(_spawner);
			}
			break;
		default:
			Debug.LogException(new NotImplementedException());
			break;
		}
		if (_spawner == null)
		{
			Debug.LogError("No valid flotsam found anywhere for SalvageMarkerObjective!");
			_bearing.SetActive(active: false);
		}
		else
		{
			_bearing.Initialize(this, _spawner);
			_bearing.SetActive(active: true);
		}
	}

	private WorldMapFlotsam GetNearestFlotsam(ItemProperties itemProperties)
	{
		using ListPool<WorldMapFlotsam>.List list = GetFlotsam(itemProperties.FlotsamProperties);
		Vector3 position = GameManager.WorldMapManager.WorldMap.Townheart.Position;
		float num = float.MaxValue;
		WorldMapFlotsam result = null;
		foreach (WorldMapFlotsam item in list)
		{
			Vector3 vector = item.transform.position - position;
			if (!(vector.x < -150f))
			{
				float sqrMagnitude = vector.sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = item;
				}
			}
		}
		return result;
	}

	private ListPool<WorldMapFlotsam>.List GetFlotsam(FlotsamProperties flotsamProperties)
	{
		ListPool<WorldMapFlotsam>.List list = ListPool<WorldMapFlotsam>.Get();
		foreach (WorldMapFlotsam item in GameManager.WorldMapManager.WorldMap.GetAllFlotsam())
		{
			foreach (FlotsamProperties allFlotsamProperty in item.GetAllFlotsamProperties())
			{
				if (allFlotsamProperty == flotsamProperties || (allFlotsamProperty is CompositedFlotsamProperties compositedFlotsamProperties && compositedFlotsamProperties.Contains(flotsamProperties)))
				{
					list.Add(item);
					break;
				}
			}
		}
		return list;
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Salvage: " + ((_itemProperties != null) ? _itemProperties.LocalizedName : "Any");
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _salvagedAmount;
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
		return new SalvageMarkerObjective(this);
	}

	private int GetInitialAmount()
	{
		return _amountInitialization switch
		{
			ObjectiveAmountInitialization.Community => Community.PlayerCommunity.Inventory.ReturnCount(_itemProperties), 
			ObjectiveAmountInitialization.StatsManager => GameManager.GameStatsManager.GetSalvagedMarkerItemsCount(_itemProperties), 
			_ => 0, 
		};
	}

	public override IQuestObjective.IPersistentData GetPersistentData()
	{
		return new PersistentData(this);
	}
}
