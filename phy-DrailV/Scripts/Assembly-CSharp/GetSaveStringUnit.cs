using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Get Save String")]
[UnitSubtitle("Get a string from current save data under a given key")]
[UnitCategory("Save")]
[TypeIcon(typeof(ScriptableObject))]
public class GetSaveStringUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput keyValue;

	[DoNotSerialize]
	public ValueOutput valueValue;

	[DoNotSerialize]
	public ControlOutput gotTrigger;

	protected override void Definition()
	{
		gotTrigger = ControlOutput("Got");
		keyValue = ValueInput("Key", string.Empty);
		valueValue = ValueOutput<string>("Value");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			string value = flow.GetValue<string>(keyValue);
			flow.SetValue(valueValue, SingletonBehaviour<SaveGameManager>.Instance.data.GetString(value));
			return gotTrigger;
		});
	}
}
