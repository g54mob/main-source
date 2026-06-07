using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Chapter Filter")]
[UnitCategory("Tutorial")]
[TypeIcon(typeof(Animation))]
[UnitSubtitle("Use for event flow starts, to check if applicable")]
public class ChapterFilter : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput thisTrigger;

	[DoNotSerialize]
	public ControlOutput notThisTrigger;

	protected override void Definition()
	{
		thisTrigger = ControlOutput("This chapter");
		notThisTrigger = ControlOutput("Not this chapter");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			string text = "";
			if (flow.stack.parentElement is FlowState)
			{
				text = ((FlowState)flow.stack.parentElement).nest.embed.title;
			}
			string text2 = (string)Variables.ActiveScene.Get("TutorialChapter");
			if (text2 == null)
			{
				text2 = "";
			}
			return (text2 == text) ? thisTrigger : notThisTrigger;
		});
	}
}
