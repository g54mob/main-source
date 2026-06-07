using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Vive Wand Message Selector")]
[UnitSubtitle("Is any of the VR controllers a Wand?")]
[UnitCategory("VR")]
[TypeIcon(typeof(Camera))]
public class ViveSlectorUnit : Unit
{
	[DoNotSerialize]
	public ValueInput nonViveValue;

	[DoNotSerialize]
	public ValueInput viveValue;

	[DoNotSerialize]
	public ValueOutput outputValue;

	protected override void Definition()
	{
		nonViveValue = ValueInput("Other VR", "");
		viveValue = ValueInput("Vive Wand", "");
		outputValue = ValueOutput("Output", (Flow flow) => flow.GetValue<string>(VRManager.AnyWandController() ? viveValue : nonViveValue));
	}
}
