using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Mark Phase Completed")]
[UnitCategory("Tutorial")]
[TypeIcon(typeof(Animation))]
[UnitSubtitle("Write to save data that a phase is now completed")]
public class MarkTutorialPhaseCompletedUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput phaseNumber;

	[DoNotSerialize]
	public ValueInput phaseValue;

	[DoNotSerialize]
	public ControlOutput markedTrigger;

	protected override void Definition()
	{
		markedTrigger = ControlOutput("Marked");
		phaseNumber = ValueInput("ID", 1);
		phaseValue = ValueInput("Value", @default: true);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			int value = flow.GetValue<int>(phaseNumber);
			bool value2 = flow.GetValue<bool>(phaseValue);
			switch (value)
			{
			case 1:
				SingletonBehaviour<SaveGameManager>.Instance.data.SetBool("Tutorial_01_completed", value2);
				break;
			case 2:
				SingletonBehaviour<SaveGameManager>.Instance.data.SetBool("Tutorial_02_completed", value2);
				break;
			default:
				Debug.LogError("There's currently no tutorial phase number " + value);
				break;
			}
			return markedTrigger;
		});
	}
}
