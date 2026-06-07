using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(Animation))]
[UnitCategory("Tutorial")]
[UnitSubtitle("Disengage the restricted tutorial mode")]
[UnitTitle("End Tutorial Mode")]
public class EndTutorialModeUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput endedTrigger;

	protected override void Definition()
	{
		endedTrigger = ControlOutput("Ended");
		inputTrigger = ControlInput("Input", delegate
		{
			SingletonBehaviour<TutorialHelper>.Instance.EndTutorial();
			return endedTrigger;
		});
	}
}
