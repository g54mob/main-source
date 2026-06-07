using Bolt;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[UnitCategory("Tutorial")]
[TypeIcon(typeof(Coroutine))]
[UnitTitle("Abort current QT")]
[UnitSubtitle("Abort any QT, if running")]
public class AbortQTUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		inputTrigger = ControlInput("Input", delegate
		{
			if (QuickTutorialHost.IsTutorialRunning)
			{
				QuickTutorialHost.AbortTutorial();
			}
			return doneTrigger;
		});
	}
}
