using System;
using System.Collections;
using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Player")]
[UnitSubtitle("Execute and wait for completion of loco tutorial")]
[UnitTitle("Loco Tutorial")]
public class ExecuteLocoTutorial : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput invalidateZoneValue;

	[DoNotSerialize]
	public ControlOutput completedTrigger;

	[DoNotSerialize]
	public ControlOutput abortedTrigger;

	protected override void Definition()
	{
		completedTrigger = ControlOutput("Completed");
		invalidateZoneValue = ValueInput<GameObject>("Interrupt zone", null);
		abortedTrigger = ControlOutput("Aborted/Failed");
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	protected virtual QuickTutorial ConstructTutorial(Flow flow)
	{
		return QuickTutorialFactory.DieselEngineCareerTutorial(PlayerManager.Car);
	}

	protected virtual void PostTutorialPhase(Flow flow, QuickTutorial tutorial)
	{
	}

	private IEnumerator Routine(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(invalidateZoneValue);
		ParkingDetector detector = (value ? value.GetComponent<ParkingDetector>() : null);
		if ((bool)detector)
		{
			if (PlayerManager.Car != null && PlayerManager.Car.IsLoco)
			{
				detector.AddDesiredCar(PlayerManager.Car);
				detector.CheckNow();
			}
			else if (PlayerManager.LastLoco != null)
			{
				detector.AddDesiredCar(PlayerManager.LastLoco);
				detector.CheckNow();
			}
		}
		if ((bool)detector && detector.IsCarInside)
		{
			yield return completedTrigger;
			yield break;
		}
		QuickTutorial tutorial = null;
		try
		{
			tutorial = ConstructTutorial(flow);
		}
		catch (Exception ex)
		{
			Debug.LogError("Error constructing quick tutorial: " + ex.Message);
			Debug.LogException(ex);
		}
		if (tutorial == null)
		{
			yield return abortedTrigger;
			yield break;
		}
		if (!QuickTutorialHost.StartTutorial(tutorial))
		{
			yield return abortedTrigger;
			yield break;
		}
		while (!tutorial.IsDone && !tutorial.IsFailed)
		{
			if ((bool)detector && detector.IsCarInside)
			{
				QuickTutorialHost.AbortTutorial();
				PostTutorialPhase(flow, tutorial);
				yield return completedTrigger;
				yield break;
			}
			yield return null;
		}
		PostTutorialPhase(flow, tutorial);
		if (tutorial.IsFailed || tutorial.IsAborted)
		{
			yield return abortedTrigger;
		}
		else
		{
			yield return completedTrigger;
		}
	}
}
