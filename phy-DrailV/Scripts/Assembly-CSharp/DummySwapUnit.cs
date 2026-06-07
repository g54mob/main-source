using Bolt;
using Ludiq;
using UnityEngine;

[UnitCategory("Items")]
[TypeIcon(typeof(BoxCollider))]
[UnitSubtitle("Disables one object and swaps for another in-place")]
[UnitTitle("Dummy Swap")]
public class DummySwapUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput outputTrigger;

	[DoNotSerialize]
	public ValueInput originalObject;

	[DoNotSerialize]
	public ValueInput replacementObject;

	protected override void Definition()
	{
		outputTrigger = ControlOutput("Done");
		originalObject = ValueInput<GameObject>("Original", null);
		replacementObject = ValueInput<GameObject>("Replacement", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(originalObject);
			GameObject value2 = flow.GetValue<GameObject>(replacementObject);
			value.SetActive(value: false);
			value2.transform.position = value.transform.position;
			value2.transform.rotation = value.transform.rotation;
			value2.SetActive(value: true);
			return outputTrigger;
		});
		Requirement(originalObject, inputTrigger);
		Requirement(replacementObject, inputTrigger);
	}
}
