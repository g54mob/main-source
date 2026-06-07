using Bolt;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Check which phase of tutorial to start")]
[UnitCategory("Tutorial")]
[TypeIcon(typeof(Animation))]
[UnitTitle("Phase Filter")]
public class PhaseFilter : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput phaseNumber;

	[DoNotSerialize]
	public ControlOutput thisTrigger;

	[DoNotSerialize]
	public ControlOutput notThisTrigger;

	protected override void Definition()
	{
		thisTrigger = ControlOutput("This phase");
		notThisTrigger = ControlOutput("Not this phase");
		phaseNumber = ValueInput("ID", 1);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			int value = flow.GetValue<int>(phaseNumber);
			return (!TutorialHelper.IsTutorialPhaseCompleted(value) && (value <= 1 || TutorialHelper.IsTutorialPhaseCompleted(value - 1))) ? thisTrigger : notThisTrigger;
		});
	}
}
