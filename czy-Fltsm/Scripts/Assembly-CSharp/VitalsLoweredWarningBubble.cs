using System.Collections.Generic;
using UnityEngine;

public class VitalsLoweredWarningBubble : DrifterWarningBubble
{
	[SerializeField]
	private VitalType _vital = VitalType.None;

	[Tooltip("Value of the vital when the warning shows.")]
	[SerializeField]
	private int _warningVitalValue = 1;

	[SerializeField]
	private int _warningPulseValue = 3;

	private Coroutine _pulseRoutine;

	protected override void Start()
	{
		base.Start();
		UpdateVitals(Community.PlayerCommunity.Agents);
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
		UpdateVitals(Community.PlayerCommunity.Agents);
	}

	private void UpdateVitals(List<Agent> agents)
	{
		foreach (Agent agent in agents)
		{
			int num = agent.Vitals.ReturnVitalAmount(_vital);
			if (_warningVitalValue <= num)
			{
				AddWarning(agent);
			}
			else
			{
				RemoveWarning(agent);
			}
			if (_warningPulseValue <= num)
			{
				_pulseRoutine = StartAnimation(PulseTweenCoroutine(_background, 1f, 1.3f));
			}
			else if (_pulseRoutine != null)
			{
				StopAnimation(_pulseRoutine);
				_pulseRoutine = null;
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
