using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Force Align Tutorial Junctions")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Set all the tutorial junctions to their 'completed' state")]
public class ForceAlignTutorialJunctions : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput alignedTrigger;

	[DoNotSerialize]
	public ValueInput targetItem;

	protected override void Definition()
	{
		alignedTrigger = ControlOutput("Flipped");
		targetItem = ValueInput<GameObject>("Item", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			flow.GetValue<GameObject>(targetItem).GetComponentInChildren<TutorialSteelMillSwitchChecker>().ResetSwitches();
			return alignedTrigger;
		});
	}
}
