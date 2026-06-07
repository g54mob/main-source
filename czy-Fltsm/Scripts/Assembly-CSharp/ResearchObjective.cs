using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class ResearchObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Research";

	[SerializeField]
	private ResearchUnlockable _buildingToUnlock;

	public ResearchObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnBuildableSelected);
	}

	public ResearchObjective(ResearchObjective other)
		: base(other)
	{
		_buildingToUnlock = other._buildingToUnlock;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			if (_buildingToUnlock != null)
			{
				return Community.PlayerCommunity.Research.IsResearched(_buildingToUnlock);
			}
			return false;
		}
		return true;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.ResearchFinished, OnResearchFinished);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, OnResearchFinished);
	}

	private void OnResearchFinished(GameEvent gameEvent)
	{
		if (_buildingToUnlock == null || Community.PlayerCommunity.Research.IsResearched(_buildingToUnlock))
		{
			SetCompleted(completed: true);
			Uninitialize();
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Research: " + ((_buildingToUnlock != null) ? _buildingToUnlock.GetName() : "Any");
	}

	public override string GetParameterValue(string param)
	{
		if (param == "RESEARCHABLE")
		{
			return (_buildingToUnlock != null) ? _buildingToUnlock.GetName() : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		ResearchStation buildableExtendable;
		if (dialogueTriggerType == DialogueTriggerType.OnBuildableSelected)
		{
			return (target is Buildable buildable && buildable.TryReturnBuildableExtendable<ResearchStation>(out buildableExtendable)) || (target is BuildableProperties buildableProperties && buildableProperties.Prefab.TryReturnBuildableExtendable<ResearchStation>(out buildableExtendable));
		}
		return false;
	}

	public override object Clone()
	{
		return new ResearchObjective(this);
	}
}
