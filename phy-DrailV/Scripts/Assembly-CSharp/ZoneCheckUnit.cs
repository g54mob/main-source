using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Movement")]
[UnitSubtitle("Continue based on player's presence inside a zone")]
[UnitTitle("Is Player Inside Zone")]
public class ZoneCheckUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput insideTrigger;

	[DoNotSerialize]
	public ControlOutput outsideTrigger;

	[DoNotSerialize]
	public ValueInput markerObject;

	protected override void Definition()
	{
		insideTrigger = ControlOutput("Inside");
		outsideTrigger = ControlOutput("Outside");
		markerObject = ValueInput<GameObject>("Marker", null);
		inputTrigger = ControlInput("Input", (Flow flow) => EnterZoneUnit.PlayerEnterDetector.CheckForPlayer(flow.GetValue<GameObject>(markerObject).GetComponentsInChildren<Collider>(), feetMode: false) ? insideTrigger : outsideTrigger);
		Requirement(markerObject, inputTrigger);
	}
}
