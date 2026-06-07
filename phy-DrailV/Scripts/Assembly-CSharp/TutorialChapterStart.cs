using System.Collections;
using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitCategory("Tutorial")]
[UnitSubtitle("Mark the start of a new tutorial chapter")]
[TypeIcon(typeof(Animation))]
[UnitTitle("Chapter Start")]
public class TutorialChapterStart : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput outputTrigger;

	[DoNotSerialize]
	public ControlOutput previousSkippedTrigger;

	protected override void Definition()
	{
		outputTrigger = ControlOutput("Started");
		previousSkippedTrigger = ControlOutput("Previous skipped");
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		while (SingletonBehaviour<TutorialHelper>.Instance.CheckIfStreaming())
		{
			yield return null;
		}
		if (previousSkippedTrigger.hasValidConnection)
		{
			if (Variables.ActiveScene.IsDefined("SKIP") && Variables.ActiveScene.Get<bool>("SKIP"))
			{
				Variables.ActiveScene.Set("SKIP", false);
				yield return previousSkippedTrigger;
			}
		}
		else if (Variables.ActiveScene.IsDefined("SKIP") && Variables.ActiveScene.Get<bool>("SKIP"))
		{
			Variables.ActiveScene.Set("SKIP", false);
		}
		if (flow.stack.parentElement is FlowState)
		{
			string currentTutorialPhaseName = TutorialHelper.GetCurrentTutorialPhaseName(flow);
			Debug.Log("CHAPTER TITLE: " + currentTutorialPhaseName);
			Variables.ActiveScene.Set("TutorialChapter", currentTutorialPhaseName);
			TutorialHelper.SetCurrentlyRunningTutorial(flow.stack.gameObject);
		}
		yield return outputTrigger;
	}
}
