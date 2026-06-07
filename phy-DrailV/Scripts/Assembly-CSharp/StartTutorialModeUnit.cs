using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Start Tutorial Mode")]
[UnitCategory("Tutorial")]
[TypeIcon(typeof(Animation))]
[UnitSubtitle("Engage the restricted tutorial mode")]
public class StartTutorialModeUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput startedTrigger;

	protected override void Definition()
	{
		startedTrigger = ControlOutput("Started");
		inputTrigger = ControlInput("Input", delegate
		{
			SingletonBehaviour<TutorialHelper>.Instance.StartRestrictedTutorialMode();
			return startedTrigger;
		});
	}
}
