using System;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class LinkEnergyConnectorObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[QuestVariable(QuestVariableType.Buildable)]
	private int _buildableVariable;

	private EnergyGridBuildableComponent _connector;

	public LinkEnergyConnectorObjective()
	{
	}

	private LinkEnergyConnectorObjective(LinkEnergyConnectorObjective other)
		: base(other)
	{
		_buildableVariable = other._buildableVariable;
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (active)
		{
			bool flag = true;
			if (!base.IsCompleted())
			{
				if (!base.Quest.TryGetVariableValue<Buildable>(this, _buildableVariable, out var value))
				{
					Debug.LogException(new Exception("LinkEnergyConnectorObjective buildable variable has not been populated!"));
				}
				else if (!value.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out _connector))
				{
					Debug.LogException(new Exception("'" + value.Name + "' does not have a EnergyGridBuildableComponent!"));
				}
				else
				{
					flag = IsCompleted();
				}
			}
			SetCompleted(flag, sendEvent: false);
			if (!flag)
			{
				GameEventDispatcher.AddListener(GameEventType.EnergyGridConnectionAdded, OnEnergyGridConnectionAdded);
			}
		}
		else
		{
			Uninitialize();
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionAdded, OnEnergyGridConnectionAdded);
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			if ((bool)_connector)
			{
				return _connector.EnergyGrid.IsTownheartGrid;
			}
			return false;
		}
		return true;
	}

	private void OnEnergyGridConnectionAdded(GameEvent gameEvent)
	{
		if (IsCompleted())
		{
			SetCompleted(completed: true);
		}
	}

	public override object Clone()
	{
		return new LinkEnergyConnectorObjective(this);
	}
}
