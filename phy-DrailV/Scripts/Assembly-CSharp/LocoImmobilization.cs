using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Loco Immobilization")]
[UnitCategory("Trains")]
[TypeIcon(typeof(Rigidbody))]
[UnitSubtitle("Immobilize a train car, or reverse it")]
public class LocoImmobilization : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput locoObject;

	[DoNotSerialize]
	public ValueInput onValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		locoObject = ValueInput<GameObject>("Train", null);
		onValue = ValueInput("Immobilize", @default: true);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(locoObject);
			bool value2 = flow.GetValue<bool>(onValue);
			if ((bool)value)
			{
				if (value2)
				{
					SingletonBehaviour<TutorialHelper>.Instance.ImmobilizeLoco(value);
				}
				else
				{
					SingletonBehaviour<TutorialHelper>.Instance.RemoveImmobilizationFromLoco(value);
				}
			}
			return doneTrigger;
		});
	}
}
