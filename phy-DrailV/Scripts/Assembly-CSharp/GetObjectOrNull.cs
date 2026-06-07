using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Get Object Or Null")]
[UnitSubtitle("Gets an object from a scene variable, or returns null if nonexistent")]
[UnitCategory("Variables")]
[TypeIcon(typeof(MonoBehaviour))]
public class GetObjectOrNull : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput gotTrigger;

	[DoNotSerialize]
	public ValueInput variableName;

	[DoNotSerialize]
	public ValueOutput gottenObject;

	protected override void Definition()
	{
		gotTrigger = ControlOutput("Got");
		variableName = ValueInput("Name", "");
		gottenObject = ValueOutput<GameObject>("Object", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			string value = flow.GetValue<string>(variableName);
			if (Variables.ActiveScene.IsDefined(value))
			{
				flow.SetValue(gottenObject, Variables.ActiveScene.Get<GameObject>(value));
			}
			else
			{
				flow.SetValue(gottenObject, null);
			}
			return gotTrigger;
		});
	}
}
