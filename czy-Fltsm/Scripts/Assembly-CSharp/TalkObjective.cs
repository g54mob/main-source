using System;
using UnityEngine;

[Serializable]
public class TalkObjective : QuestObjectiveBase
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Talk";

	[SerializeField]
	private AgentProfile _actorToTalkTo;

	private Agent _registeredAgent;

	public TalkObjective()
	{
	}

	public TalkObjective(TalkObjective other)
		: base(other)
	{
		_actorToTalkTo = other._actorToTalkTo;
		_registeredAgent = other._registeredAgent;
	}

	public override void Initialize()
	{
		if (_actorToTalkTo != null)
		{
			MarkAgentAsHavingActiveTalkObjective();
		}
		else
		{
			GameEventDispatcher.AddListener(GameEventType.AgentMessageUpdated, OnAgentMessageUpdated);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentMessageUpdated, OnAgentMessageUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentSpawn, OnAgentSpawn);
		GameEventDispatcher.RemoveListener(GameEventType.AgentSelected, OnAgentSelected);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnAgentDeath);
	}

	private void MarkAgentAsHavingActiveTalkObjective()
	{
		AgentDescriptor descriptor = _actorToTalkTo.GetDescriptor();
		foreach (Community community in Community.Communities)
		{
			foreach (Agent agent in community.Agents)
			{
				if (agent.Descriptor == descriptor)
				{
					RegisterAgent(agent);
					return;
				}
			}
		}
		GameEventDispatcher.AddListener(GameEventType.AgentSpawn, OnAgentSpawn);
	}

	private void RegisterAgent(Agent agent)
	{
		_registeredAgent = agent;
		agent.SetHasActiveTalkObjective(hasActiveObjective: true);
		GameEventDispatcher.AddListener(GameEventType.AgentSelected, OnAgentSelected);
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, OnAgentDeath);
	}

	private void OnAgentMessageUpdated(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent && agentEvent.Agent != null && !agentEvent.Agent.ReturnHasMessageQueued())
		{
			SetCompleted(completed: true);
		}
	}

	private void OnAgentSpawn(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent && agentEvent.AgentDescriptor == _actorToTalkTo.GetDescriptor())
		{
			RegisterAgent(agentEvent.Agent);
		}
	}

	private void OnAgentSelected(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _registeredAgent && agentEvent.Agent.InPlayerCommunity())
		{
			SetCompleted(completed: true);
		}
	}

	private void OnAgentDeath(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _registeredAgent)
		{
			_registeredAgent = null;
			GameEventDispatcher.RemoveListener(GameEventType.AgentSelected, OnAgentSelected);
			GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnAgentDeath);
			GameEventDispatcher.AddListener(GameEventType.AgentSpawn, OnAgentSpawn);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Talk to " + ((_actorToTalkTo != null) ? _actorToTalkTo.Name : "any drifter with a message");
	}

	public override object Clone()
	{
		return new TalkObjective(this);
	}
}
