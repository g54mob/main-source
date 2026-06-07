using System.Collections;
using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(Canvas))]
[UnitCategory("UI")]
[UnitSubtitle("Fade screen to a color over time")]
[UnitTitle("Screen Fade")]
public class ScreenFadeUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput colorValue;

	[DoNotSerialize]
	public ValueInput durationValue;

	[DoNotSerialize]
	public ValueInput asyncMode;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Spawned");
		colorValue = ValueInput("Color", Color.black);
		durationValue = ValueInput("Duration", 1f);
		asyncMode = ValueInput("Async", @default: false);
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		Color value = flow.GetValue<Color>(colorValue);
		float value2 = flow.GetValue<float>(durationValue);
		bool value3 = flow.GetValue<bool>(asyncMode);
		ScreenFade.Fade(value, value2);
		if (!value3)
		{
			yield return WaitFor.SecondsRealtime(value2);
		}
		yield return doneTrigger;
	}
}
