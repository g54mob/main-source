using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[UnitTitle("Handcar Summoning Tutorial")]
[UnitSubtitle("Teach player to summon a handcar on a specific track")]
[TypeIcon(typeof(TrainCar))]
[UnitCategory("Player")]
public class ExecuteHandcarSummonTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput railtrackReferencePoint;

	[DoNotSerialize]
	public ValueOutput summonedCarValue;

	protected override void Definition()
	{
		base.Definition();
		railtrackReferencePoint = ValueInput<GameObject>("Reference point", null);
		summonedCarValue = ValueOutput<GameObject>("Summoned car");
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		return QuickTutorialFactory.HandcarSpawnTutorial(flow.GetValue<GameObject>(railtrackReferencePoint).transform, onlyClosestRail: true);
	}

	protected override void PostTutorialPhase(Flow flow, QuickTutorial tutorial)
	{
		if (tutorial.IsDone && !tutorial.IsFailed && !tutorial.IsAborted)
		{
			CarSummonedStep[] stepsOfType = tutorial.GetStepsOfType<CarSummonedStep>();
			if (stepsOfType.Length == 1)
			{
				flow.SetValue(summonedCarValue, stepsOfType[0].SummonedCar.gameObject);
			}
			else
			{
				Debug.LogError(string.Format("Expected exactly one {0}, got {1} did the tutorial change?", "CarSummonedStep", stepsOfType.Length));
			}
		}
	}
}
