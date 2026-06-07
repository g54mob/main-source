using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Player")]
[UnitTitle("Rerailing Tutorial")]
[UnitSubtitle("Execute and wait for completion of rerailing tutorial")]
public class ExecuteRerailingTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput railAnchorValue;

	public ValueInput onlyClosestRail;

	protected override void Definition()
	{
		base.Definition();
		railAnchorValue = ValueInput<GameObject>("Rail anchor", null);
		onlyClosestRail = ValueInput("Only closest rail", @default: false);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(railAnchorValue);
		Collider specificCollider = (value ? value.GetComponentInChildren<Collider>() : null);
		bool value2 = flow.GetValue<bool>(onlyClosestRail);
		RailTrack specificTrack = null;
		if ((bool)value)
		{
			specificTrack = CarSpawner.GetTrackClosestTo(value.transform.position, 1f, out var _);
		}
		return QuickTutorialFactory.RerailingTutorial(PlayerManager.PlayerTransform, doRangeChecks: false, value2, specificTrack, specificCollider);
	}
}
