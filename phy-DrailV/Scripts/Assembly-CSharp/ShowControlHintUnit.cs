using Bolt;
using DV.Game.Tutorial;
using DV.Utils;
using Ludiq;
using UnityEngine.UI;

[UnitTitle("Show Control Hint")]
[UnitSubtitle("Show a keybind reminder for an action")]
[TypeIcon(typeof(Text))]
[UnitCategory("UI")]
public class ShowControlHintUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput actionValue;

	[DoNotSerialize]
	public ControlOutput continueTrigger;

	protected override void Definition()
	{
		continueTrigger = ControlOutput("Continue");
		actionValue = ValueInput("Action", ControlHint.None);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowControlHint(flow.GetValue<ControlHint>(actionValue));
			return continueTrigger;
		});
	}
}
