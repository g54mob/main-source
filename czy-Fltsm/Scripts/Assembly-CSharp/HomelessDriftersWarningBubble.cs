public class HomelessDriftersWarningBubble : WarningBubble
{
	protected override void Start()
	{
		base.Start();
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			UpdateAgentHousing(agent);
		}
	}

	protected override void Subscribe()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentRemovedFromPlayerCommunity, OnAgentEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentHouseUpdated, OnAgentEvent);
	}

	protected override void Unsubscribe()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnAgentEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentHouseUpdated, OnAgentEvent);
	}

	private void OnAgentEvent(GameEvent gameEvent)
	{
		AgentEvent agentEvent = gameEvent as AgentEvent;
		UpdateAgentHousing(agentEvent.Agent);
	}

	private void UpdateAgentHousing(Agent agent)
	{
		if (agent.InPlayerCommunity() && agent.ReservedHouse == null)
		{
			AddHomelessAgent(agent);
		}
		else
		{
			RemoveHomelessAgent(agent);
		}
	}

	private void AddHomelessAgent(Agent agent)
	{
		if (AddObjectOfInterest(new DefaultObjectOfInterest(agent.gameObject, ObjectType.Agent)))
		{
			if (_objectOfInterestContainer.ObjectsOfInterest.Count == 1)
			{
				StartAnimation(BounceOutTweenCoroutine(_background));
			}
			else if (_objectOfInterestContainer.ObjectsOfInterest.Count > 1)
			{
				StartAnimation(BounceOutTweenCoroutine(_counter));
			}
		}
	}

	private void RemoveHomelessAgent(Agent agent)
	{
		RemoveObjectOfInterest(agent.gameObject);
	}
}
