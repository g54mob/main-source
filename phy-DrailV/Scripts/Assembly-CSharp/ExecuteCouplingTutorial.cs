using System.Collections.Generic;
using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[UnitTitle("Coupling Tutorial")]
[TypeIcon(typeof(TrainCar))]
[UnitCategory("Player")]
[UnitSubtitle("Execute and wait for completion of coupling tutorial")]
public class ExecuteCouplingTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput locoObjectValue;

	[DoNotSerialize]
	public ValueInput cargoObjectValue;

	protected override void Definition()
	{
		base.Definition();
		locoObjectValue = ValueInput<GameObject>("Loco");
		cargoObjectValue = ValueInput<GameObject>("Cargo");
		Requirement(locoObjectValue, inputTrigger);
		Requirement(cargoObjectValue, inputTrigger);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		List<TrainCar> list = null;
		GameObject value = flow.GetValue<GameObject>(locoObjectValue);
		GameObject value2 = flow.GetValue<GameObject>(cargoObjectValue);
		TrainCar trainCar = (value ? TrainCar.Resolve(value) : null);
		TrainCar trainCar2 = (value2 ? TrainCar.Resolve(value2) : null);
		if (trainCar != null && trainCar2 != null)
		{
			list = new List<TrainCar> { trainCar, trainCar2 };
			return QuickTutorialFactory.CouplingTutorial(PlayerManager.PlayerTransform, announceCompletion: false, doRangeChecks: false, list);
		}
		Debug.LogError("Loco or cargo can't be resolved to a TrainCar, or are just null, can't proceed.");
		return null;
	}
}
