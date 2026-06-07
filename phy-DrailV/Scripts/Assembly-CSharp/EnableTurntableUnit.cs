using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Enable or disable turntable interactivity")]
[UnitTitle("Enable Turntable")]
[UnitCategory("Interaction")]
public class EnableTurntableUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput turntableFinderObject;

	[DoNotSerialize]
	public ValueInput enabledValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		turntableFinderObject = ValueInput<GameObject>("Turntable", null);
		enabledValue = ValueInput("Enabled", @default: true);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(turntableFinderObject);
			if (value == null)
			{
				Debug.LogError("[EnableTurntableUnit] Turntable finder object is null");
				return doneTrigger;
			}
			TutorialTurnTableFinder component = value.GetComponent<TutorialTurnTableFinder>();
			if (component == null)
			{
				Debug.LogError("[EnableTurntableUnit] Turntable finder object does not have a TutorialTurnTableFinder component");
				return doneTrigger;
			}
			component.Initialize();
			TurntableController controller = component.controller;
			if (controller == null)
			{
				Debug.LogError("[EnableTurntableUnit] TutorialTurnTableFinder didn't find a TurntableController component");
				return doneTrigger;
			}
			controller.PlayerControlAllowed = flow.GetValue<bool>(enabledValue);
			return doneTrigger;
		});
	}
}
