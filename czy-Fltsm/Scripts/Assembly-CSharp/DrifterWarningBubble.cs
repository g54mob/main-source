public abstract class DrifterWarningBubble : WarningBubble
{
	protected override void Subscribe()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, OnAgentDeath);
	}

	protected override void Unsubscribe()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnAgentDeath);
	}

	private void OnAgentDeath(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent)
		{
			RemoveWarning(agentEvent.Agent);
		}
	}

	protected virtual bool AddWarning(Agent agent)
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
			return true;
		}
		return false;
	}

	protected virtual void RemoveWarning(Agent agent)
	{
		RemoveObjectOfInterest(agent.gameObject);
	}
}
