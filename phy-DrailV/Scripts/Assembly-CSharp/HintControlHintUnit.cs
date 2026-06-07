using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine.UI;

[UnitTitle("Hide Control Hint")]
[UnitCategory("UI")]
[UnitSubtitle("Hide previously shown hint")]
[TypeIcon(typeof(Text))]
public class HintControlHintUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput continueTrigger;

	protected override void Definition()
	{
		continueTrigger = ControlOutput("Continue");
		inputTrigger = ControlInput("Input", delegate
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideControlHint();
			return continueTrigger;
		});
	}
}
