using System.Collections.Generic;

public class DiseasedDriftersWarningBubble : DrifterWarningBubble
{
	protected override void Start()
	{
		base.Start();
		UpdateDiseases(Community.PlayerCommunity.Agents);
	}

	private void OnEnable()
	{
		StartAnimation(PulseTweenCoroutine(_background, 1f, 1.3f));
	}

	protected override void Subscribe()
	{
		base.Subscribe();
		GameEventDispatcher.AddListener(GameEventType.DiseasesUpdated, OnDiseasesEvent);
	}

	protected override void Unsubscribe()
	{
		base.Unsubscribe();
		GameEventDispatcher.RemoveListener(GameEventType.DiseasesUpdated, OnDiseasesEvent);
	}

	private void OnDiseasesEvent(GameEvent gameEvent)
	{
		UpdateDiseases(Community.PlayerCommunity.Agents);
	}

	private void UpdateDiseases(List<Agent> agents)
	{
		foreach (Agent agent in agents)
		{
			if (agent.Vitals.Pollution.CurrentDisease == null)
			{
				RemoveWarning(agent);
			}
			else
			{
				AddWarning(agent);
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
