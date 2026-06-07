using System.Collections;
using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(Timer))]
[UnitCategory("Timing")]
[UnitSubtitle("Wait for initializations to complete")]
[UnitTitle("Tutorial ready")]
public class TutorialReadyUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput readyTrigger;

	protected override void Definition()
	{
		readyTrigger = ControlOutput("Ready");
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		bool startedNotReady = !SingletonBehaviour<TutorialHelper>.Instance.IsReady;
		while (!SingletonBehaviour<TutorialHelper>.Instance.IsReady)
		{
			if (startedNotReady)
			{
				ScreenFade.Fade(Color.black, 0f);
			}
			yield return null;
		}
		yield return readyTrigger;
	}
}
