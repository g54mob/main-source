using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class BuildDecorationObjective : QuestObjectiveBase, ILocalizationParamsManager
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
		private readonly int _decosAmount;

		public PersistentData(BuildDecorationObjective objective)
			: base(objective)
		{
			_decosAmount = objective._decosAmount;
		}

		public override bool TryRestore(IQuestObjective objective)
		{
			if (base.TryRestore(objective) && objective is BuildDecorationObjective buildDecorationObjective)
			{
				buildDecorationObjective._decosAmount = _decosAmount;
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Build Deco";

	[SerializeField]
	private DecorationProperties _decoration;

	[SerializeField]
	private BuildAction _requiredBuildAction;

	[SerializeField]
	[ConditionalEnumHide("_requiredBuildAction", 0, false, HideInInspector = true)]
	private int _amount = 1;

	private int _decosAmount;

	public BuildDecorationObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnBuildableSelected);
	}

	public BuildDecorationObjective(BuildDecorationObjective other)
		: base(other)
	{
		_decoration = other._decoration;
		_requiredBuildAction = other._requiredBuildAction;
		_amount = other._amount;
		_decosAmount = other._decosAmount;
	}

	public override bool IsCompleted()
	{
		bool flag = base.IsCompleted();
		if (!flag)
		{
			bool flag2 = _requiredBuildAction == BuildAction.Build && _decosAmount >= _amount;
			flag = flag2;
		}
		return flag;
	}

	public override void Initialize()
	{
		_decosAmount = 0;
		if (!InitializeIsCompleted())
		{
			switch (_requiredBuildAction)
			{
			case BuildAction.Build:
				GameEventDispatcher.AddListener(GameEventType.DecorationBuilt, OnDecorationBuilt);
				break;
			case BuildAction.Place:
				GameEventDispatcher.AddListener(GameEventType.DecorationPlaced, OnDecorationPlaced);
				break;
			case BuildAction.SelectInBuildMenu:
				GameEventDispatcher.AddListener(GameEventType.DecorationSelectedInBuildMenu, OnDecorationSelectedInBuildMenu);
				break;
			}
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DecorationBuilt, OnDecorationBuilt);
		GameEventDispatcher.RemoveListener(GameEventType.DecorationPlaced, OnDecorationPlaced);
		GameEventDispatcher.RemoveListener(GameEventType.DecorationSelectedInBuildMenu, OnDecorationSelectedInBuildMenu);
	}

	private void OnDecorationBuilt(GameEvent gameEvent)
	{
		if (gameEvent is DecorationEvent decorationEvent && !(decorationEvent.Properties != _decoration))
		{
			if (++_decosAmount >= _amount)
			{
				SetCompleted(completed: true, sendEvent: false);
			}
			QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
		}
	}

	private void OnDecorationPlaced(GameEvent gameEvent)
	{
		if (gameEvent is DecorationEvent decorationEvent && decorationEvent.Properties == _decoration)
		{
			SetCompleted(completed: true);
		}
	}

	private void OnDecorationSelectedInBuildMenu(GameEvent gameEvent)
	{
		if (gameEvent is DecorationEvent decorationEvent && decorationEvent.Properties == _decoration)
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		string text = ((_decoration != null) ? _decoration.Name : "Any");
		return _requiredBuildAction switch
		{
			BuildAction.Build => "Build " + text, 
			BuildAction.Place => "Place " + text, 
			_ => "Select " + text + " in build menu", 
		};
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _decosAmount;
		goalValue = _amount;
		return true;
	}

	public override string GetParameterValue(string param)
	{
		if (param == "DECORATION")
		{
			return (_decoration != null) ? _decoration.Name : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		DecorationSlots buildableExtendable;
		if (dialogueTriggerType == DialogueTriggerType.OnBuildableSelected)
		{
			return target is Buildable buildable && buildable.TryReturnBuildableExtendable<DecorationSlots>(out buildableExtendable);
		}
		return false;
	}

	public override object Clone()
	{
		return new BuildDecorationObjective(this);
	}

	public override IQuestObjective.IPersistentData GetPersistentData()
	{
		return new PersistentData(this);
	}
}
