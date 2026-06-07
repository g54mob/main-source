using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("In VR?")]
[UnitSubtitle("Branch based on VR state")]
[UnitCategory("Controls")]
[TypeIcon(typeof(Camera))]
public class VRSelectorUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput vrTrigger;

	[DoNotSerialize]
	public ControlOutput nonVrTrigger;

	protected override void Definition()
	{
		vrTrigger = ControlOutput("VR");
		nonVrTrigger = ControlOutput("Non-VR");
		inputTrigger = ControlInput("Input", (Flow flow) => VRManager.IsVREnabled() ? vrTrigger : nonVrTrigger);
	}
}
