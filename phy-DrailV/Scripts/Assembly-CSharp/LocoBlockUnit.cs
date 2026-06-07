using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(Rigidbody))]
[UnitSubtitle("Create or remove a blocker on the loco")]
[UnitTitle("Loco Block")]
[UnitCategory("Trains")]
public class LocoBlockUnit : Unit
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
		onValue = ValueInput("Block", @default: true);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(locoObject);
			bool value2 = flow.GetValue<bool>(onValue);
			if ((bool)value)
			{
				if (value2)
				{
					SingletonBehaviour<TutorialHelper>.Instance.BlockLoco(value);
				}
				else
				{
					SingletonBehaviour<TutorialHelper>.Instance.UnblockLoco(value);
				}
			}
			return doneTrigger;
		});
	}
}
