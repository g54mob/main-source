using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(Camera))]
[UnitCategory("VR")]
[UnitSubtitle("Is VR currently enabled?")]
[UnitTitle("VR Enabled")]
public class VREnabledUnit : Unit
{
	[DoNotSerialize]
	public ValueOutput outputValue;

	protected override void Definition()
	{
		outputValue = ValueOutput("VR Enabled", (Flow flow) => VRManager.IsVREnabled());
	}
}
