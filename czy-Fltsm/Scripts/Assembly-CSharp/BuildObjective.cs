using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class BuildObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	public enum BuildAction
	{
		Build = 0,
		Place = 1,
		SelectInBuildMenu = 2
	}

	[Serializable]
	public new class PersistentData : QuestObjectiveBase.PersistentData
	{
		private readonly int _buildableAmount;

		public PersistentData(BuildObjective objective)
			: base(objective)
		{
			_buildableAmount = objective._buildableAmount;
		}

		public override bool TryRestore(IQuestObjective objective)
		{
			if (base.TryRestore(objective) && objective is BuildObjective buildObjective)
			{
				buildObjective._buildableAmount = _buildableAmount;
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Build";

	[SerializeField]
	private BuildableProperties _buildable;

	[SerializeField]
	private BuildAction _requiredBuildAction;

	[SerializeField]
	[ConditionalEnumHide("_requiredBuildAction", 0, false, HideInInspector = true)]
	private int _amount;

	[SerializeField]
	private ObjectiveAmountInitialization _amountInitialization = ObjectiveAmountInitialization.StatsManager;

	[SerializeField]
	private bool _setBuildableVariable;

	[SerializeField]
	[ConditionalHide("_setBuildableVariable", true)]
	[QuestVariable(QuestVariableType.Buildable)]
	private int _buildableVariable;

	private List<Buildable> _buildablesBuilt = new List<Buildable>();

	private int _buildableAmount;

	public BuildObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnBuildableSelected);
	}

	public BuildObjective(BuildObjective other)
		: base(other)
	{
		_buildable = other._buildable;
		_requiredBuildAction = other._requiredBuildAction;
		_amount = other._amount;
		_setBuildableVariable = other._setBuildableVariable;
		_buildableVariable = other._buildableVariable;
		_buildableAmount = other._buildableAmount;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		switch (_requiredBuildAction)
		{
		case BuildAction.Place:
		case BuildAction.SelectInBuildMenu:
			return _buildableAmount > 0;
		case BuildAction.Build:
			return _buildableAmount >= _amount;
		default:
			return false;
		}
	}

	public override void Initialize()
	{
		switch (_amountInitialization)
		{
		case ObjectiveAmountInitialization.Community:
			_buildableAmount = Community.PlayerCommunity.ReturnBuildableCount(_buildable, _requiredBuildAction == BuildAction.Build);
			break;
		case ObjectiveAmountInitialization.StatsManager:
			_buildableAmount = GameManager.GameStatsManager.GetBuildablesBuiltCount(_buildable);
			break;
		default:
			_buildableAmount = 0;
			break;
		}
		if (!InitializeIsCompleted())
		{
			switch (_requiredBuildAction)
			{
			case BuildAction.Build:
				GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
				break;
			case BuildAction.Place:
				GameEventDispatcher.AddListener(GameEventType.BuildablePlaced, OnBuildablePlaced);
				break;
			case BuildAction.SelectInBuildMenu:
				GameEventDispatcher.AddListener(GameEventType.BuildableSelectedInBuildMenu, OnBuildableSelectedInBuildMenu);
				break;
			}
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
		GameEventDispatcher.RemoveListener(GameEventType.BuildablePlaced, OnBuildablePlaced);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSelectedInBuildMenu, OnBuildableSelectedInBuildMenu);
	}

	private void OnBuildableBuilt(GameEvent gameEvent)
	{
		if (!(gameEvent is BuildableEvent buildableEvent) || buildableEvent.BuildableProperties != _buildable)
		{
			return;
		}
		if ((bool)buildableEvent.Buildable)
		{
			_buildablesBuilt?.Add(buildableEvent.Buildable);
			if (_setBuildableVariable)
			{
				base.Quest.SetVariableValue(_buildableVariable, buildableEvent.Buildable);
			}
		}
		if (++_buildableAmount >= _amount)
		{
			SetCompleted(completed: true, sendEvent: false);
		}
		QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
	}

	private void OnBuildablePlaced(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && !(buildableEvent.BuildableProperties != _buildable))
		{
			if (_buildablesBuilt != null && buildableEvent.Buildable != null)
			{
				_buildablesBuilt.Add(buildableEvent.Buildable);
			}
			SetCompleted(completed: true);
		}
	}

	private void OnBuildableSelectedInBuildMenu(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && buildableEvent.BuildableProperties == _buildable)
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		string text = ((_buildable != null) ? _buildable.Name : "Any");
		return _requiredBuildAction switch
		{
			BuildAction.Build => "Build " + text, 
			BuildAction.Place => "Place " + text, 
			_ => "Select " + text + " in build menu", 
		};
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _buildableAmount;
		goalValue = _amount;
		return true;
	}

	public override string GetParameterValue(string param)
	{
		if (param == "BUILDING")
		{
			return (_buildable != null) ? _buildable.Name : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		if (dialogueTriggerType == DialogueTriggerType.OnBuildableSelected)
		{
			return _buildablesBuilt != null && target is Buildable item && _buildablesBuilt.Contains(item);
		}
		return false;
	}

	public override object Clone()
	{
		return new BuildObjective(this);
	}

	public override IQuestObjective.IPersistentData GetPersistentData()
	{
		return new PersistentData(this);
	}
}
