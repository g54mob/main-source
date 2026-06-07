using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine.UI;

[TypeIcon(typeof(Text))]
[UnitTitle("Hide Floatie")]
[UnitCategory("UI")]
[UnitSubtitle("Hides the last floatie")]
public class HideFloatieUnit : Unit
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
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			return continueTrigger;
		});
	}
}
