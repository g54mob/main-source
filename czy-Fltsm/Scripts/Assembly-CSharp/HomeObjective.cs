using System;
using UnityEngine;

[Serializable]
public class HomeObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Build homes";

	[SerializeField]
	private int _amount;

	private int _homesCount;

	public HomeObjective()
	{
	}

	public HomeObjective(HomeObjective other)
		: base(other)
	{
		_amount = other._amount;
		_homesCount = other._homesCount;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		return ((_homesCount > 0) ? _homesCount : GetHomesCount()) >= _amount;
	}

	public override void Initialize()
	{
		_homesCount = GetHomesCount();
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.AgentHouseUpdated, OnAgentHouseUpdated);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentHouseUpdated, OnAgentHouseUpdated);
	}

	private int GetHomesCount()
	{
		int num = 0;
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if ((bool)agent.ReservedHouse)
			{
				num++;
			}
		}
		return num;
	}

	private void OnAgentHouseUpdated(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent && agentEvent.Agent.ReservedHouse != null)
		{
			if (++_homesCount >= _amount)
			{
				SetCompleted(completed: true, sendEvent: false);
			}
		}
		else
		{
			_homesCount--;
		}
		QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Build Homes";
	}

	protected override bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = _homesCount;
		goalValue = _amount;
		return true;
	}

	public override object Clone()
	{
		return new HomeObjective(this);
	}
}
