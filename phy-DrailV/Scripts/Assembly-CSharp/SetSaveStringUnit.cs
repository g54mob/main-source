using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Set Save String")]
[UnitCategory("Save")]
[TypeIcon(typeof(ScriptableObject))]
[UnitSubtitle("Set a string to current save data under a given key")]
public class SetSaveStringUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput keyValue;

	[DoNotSerialize]
	public ValueInput valueValue;

	[DoNotSerialize]
	public ControlOutput setTrigger;

	protected override void Definition()
	{
		setTrigger = ControlOutput("Set");
		keyValue = ValueInput("Key", string.Empty);
		valueValue = ValueInput("Value", string.Empty);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			string value = flow.GetValue<string>(keyValue);
			string value2 = flow.GetValue<string>(valueValue);
			SingletonBehaviour<SaveGameManager>.Instance.data.SetString(value, value2);
			return setTrigger;
		});
	}
}
