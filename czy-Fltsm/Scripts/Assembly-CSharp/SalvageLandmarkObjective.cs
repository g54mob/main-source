using System;
using Assets.Code.Story.Objectives;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class SalvageLandmarkObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[Serializable]
	public new class PersistentData : QuestObjectiveBase.PersistentData
	{
		private readonly int _salvagedAmount;

		public PersistentData(SalvageLandmarkObjective objective)
			: base(objective)
		{
			_salvagedAmount = objective._salvagedAmount;
		}

		public override bool TryRestore(IQuestObjective objective)
		{
			if (base.TryRestore(objective) && objective is SalvageLandmarkObjective salvageLandmarkObjective)
			{
				salvageLandmarkObjective._salvagedAmount = _salvagedAmount;
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Salvage landmark";

	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	private int _amount;

	[SerializeField]
	private ObjectiveAmountInitialization _salvagedAmountInitialization;

	[SerializeField]
	private bool _targetLandmarkVariable;

	[SerializeField]
	[ConditionalHide("_targetLandmarkVariable", true)]
	[QuestVariable(QuestVariableType.Landmark)]
	private int _landmarkVariable;

	[SerializeField]
	[ConditionalHide("_targetLandmarkVariable", true)]
	private SpawnerObjectiveBearing _bearing;

	private int _salvagedAmount;

	public SalvageLandmarkObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkSelected);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkRegionEntered);
	}

	public SalvageLandmarkObjective(SalvageLandmarkObjective other)
		: base(other)
	{
		_itemProperties = other._itemProperties;
		_amount = other._amount;
		_salvagedAmountInitialization = other._salvagedAmountInitialization;
		_salvagedAmount = other._salvagedAmount;
		_targetLandmarkVariable = other._targetLandmarkVariable;
		_landmarkVariable = other._landmarkVariable;
		_bearing = other._bearing;
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
		switch (_salvagedAmountInitialization)
		{
		case ObjectiveAmountInitialization.Zero:
			_salvagedAmount = 0;
			break;
		case ObjectiveAmountInitialization.Community:
			_salvagedAmount = Community.PlayerCommunity.Inventory.ReturnCount(_itemProperties);
			break;
		default:
			_salvagedAmount = GameManager.GameStatsManager.GetSalvagedLandmarkItemsCount(_itemProperties);
			break;
		}
		if (TryGetTargetLandmark(out var targetLandmark))
		{
			_bearing.Initialize(this, targetLandmark);
		}
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedLandmarkItem, OnItemSalvaged);
		}
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		_bearing.SetActive(active);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedLandmarkItem, OnItemSalvaged);
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

	protected override string GetNonLocalizedDescription()
	{
		return "Salvage Landmark: " + ((_itemProperties != null) ? _itemProperties.LocalizedName : "Any");
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

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		LandmarkActionSalvage action;
		if (dialogueTriggerType == DialogueTriggerType.OnLandmarkSelected || dialogueTriggerType == DialogueTriggerType.OnLandmarkRegionEntered)
		{
			return target is ActionsBehaviour actionsBehaviour && actionsBehaviour.TryReturnAction<LandmarkActionSalvage>(out action, false) && action.ReturnIsSalvageableItem(_itemProperties);
		}
		return false;
	}

	public override object Clone()
	{
		return new SalvageLandmarkObjective(this);
	}

	private bool TryGetTargetLandmark(out LandmarkSpawner targetLandmark)
	{
		targetLandmark = (_targetLandmarkVariable ? base.Quest.GetVariableValue<LandmarkSpawner>(this, _landmarkVariable) : null);
		return targetLandmark != null;
	}

	public override IQuestObjective.IPersistentData GetPersistentData()
	{
		return new PersistentData(this);
	}
}
