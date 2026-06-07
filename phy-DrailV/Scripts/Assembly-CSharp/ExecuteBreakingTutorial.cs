using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Player")]
[UnitTitle("Breaking Tutorial")]
[UnitSubtitle("Teach player to brake, with specific target")]
public class ExecuteBreakingTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput startBreakingZone;

	[DoNotSerialize]
	public ValueInput pointZone;

	protected override void Definition()
	{
		base.Definition();
		startBreakingZone = ValueInput<GameObject>("Start breaking", null);
		pointZone = ValueInput<GameObject>("Point to", null);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(startBreakingZone);
		GameObject value2 = flow.GetValue<GameObject>(pointZone);
		return QuickTutorialFactory.CareerParkingTutorial(PlayerManager.Car, value2.transform, value.GetComponent<BoxCollider>(), doRangeChecks: false);
	}
}
