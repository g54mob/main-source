using System.Collections;
using Bolt;
using DV.Game.Tutorial;
using DV.Utils;
using Ludiq;
using UnityEngine.UI;

[UnitCategory("UI")]
[TypeIcon(typeof(Text))]
[UnitTitle("Show Prompt")]
[UnitSubtitle("Show message in tutorial prompt form")]
public class ShowPromptUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput confirmTrigger;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput dialogMessage;

	[DoNotSerialize]
	public ValueInput pauseGame;

	[DoNotSerialize]
	public ValueInput waitBeforeValue;

	[DoNotSerialize]
	public ValueInput waitAfterValue;

	protected override void Definition()
	{
		confirmTrigger = ControlOutput("Confirmed");
		dialogMessage = ValueInput("Message", string.Empty);
		pauseGame = ValueInput("Pause", @default: false);
		waitBeforeValue = ValueInput("Wait before", 2f);
		waitAfterValue = ValueInput("Wait after", 0.5f);
		inputTrigger = ControlInputCoroutine("Input", Routine);
		Requirement(dialogMessage, inputTrigger);
	}

	private IEnumerator Routine(Flow flow)
	{
		string message = flow.GetValue<string>(dialogMessage);
		bool pause = flow.GetValue<bool>(pauseGame);
		bool dismissed = false;
		float value = flow.GetValue<float>(waitBeforeValue);
		float waitAfter = flow.GetValue<float>(waitAfterValue);
		if (value > 0f)
		{
			yield return WaitFor.Seconds(value);
		}
		SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt(message, pause, delegate
		{
			dismissed = true;
		});
		while (!dismissed)
		{
			yield return null;
		}
		if (waitAfter > 0f)
		{
			yield return WaitFor.Seconds(waitAfter);
		}
		yield return confirmTrigger;
	}
}
