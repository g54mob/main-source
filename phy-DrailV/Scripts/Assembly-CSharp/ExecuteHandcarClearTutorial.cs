using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[UnitTitle("Handcar Clearing Tutorial")]
[UnitCategory("Player")]
[TypeIcon(typeof(TrainCar))]
[UnitSubtitle("Teach player to clear the summoned handcar")]
public class ExecuteHandcarClearTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput handcarValue;

	protected override void Definition()
	{
		base.Definition();
		handcarValue = ValueInput<GameObject>("Handcar", null);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		return QuickTutorialFactory.HandcarClearTutorial(TrainCar.Resolve(flow.GetValue<GameObject>(handcarValue)));
	}
}
