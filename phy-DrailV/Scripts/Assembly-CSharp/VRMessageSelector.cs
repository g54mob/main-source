using Bolt;
using Ludiq;
using TMPro;

[UnitCategory("UI")]
[UnitSubtitle("Pick non-VR or VR message")]
[TypeIcon(typeof(TextMeshProUGUI))]
[UnitTitle("VR Message Selector")]
public class VRMessageSelector : Unit
{
	[DoNotSerialize]
	public ValueInput nonVRValue;

	[DoNotSerialize]
	public ValueInput vrValue;

	[DoNotSerialize]
	public ValueOutput outputValue;

	protected override void Definition()
	{
		nonVRValue = ValueInput("Non-VR", "");
		vrValue = ValueInput("VR", "");
		outputValue = ValueOutput("Output", (Flow flow) => flow.GetValue<string>(VRManager.IsVREnabled() ? vrValue : nonVRValue));
	}
}
