using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Show the final dialog and reload session")]
[UnitCategory("Tutorial")]
[TypeIcon(typeof(Animation))]
[UnitTitle("Pick Difficulty & Reload")]
public class PickDifficultyAndReloadUnit : Unit
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
			SingletonBehaviour<TutorialHelper>.Instance.SelectDifficultyAndReload();
			return doneTrigger;
		});
	}
}
