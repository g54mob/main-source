using System.Collections.Generic;

public class MortalDangerDriftersWarningBubble : DrifterWarningBubble
{
	protected override void Start()
	{
		base.Start();
		UpdateMortalDanger(Community.PlayerCommunity.Agents);
	}

	private void OnEnable()
	{
		StartAnimation(PulseTweenCoroutine(_background, 1f, 1.3f));
	}

	protected override void Subscribe()
	{
		base.Subscribe();
		GameEventDispatcher.AddListener(GameEventType.VitalsUpdated, OnVitalsEvent);
	}

	protected override void Unsubscribe()
	{
		base.Unsubscribe();
		GameEventDispatcher.RemoveListener(GameEventType.VitalsUpdated, OnVitalsEvent);
	}

	private void OnVitalsEvent(GameEvent gameEvent)
	{
		UpdateMortalDanger(Community.PlayerCommunity.Agents);
	}

	private void UpdateMortalDanger(List<Agent> agents)
	{
		foreach (Agent agent in agents)
		{
			if (agent.Vitals.IsInMortalDanger())
			{
				AddWarning(agent);
			}
			else
			{
				RemoveWarning(agent);
			}
		}
	}

	protected override bool AddWarning(Agent agent)
	{
		if (base.AddWarning(agent))
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
}
