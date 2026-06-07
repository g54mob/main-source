using Bolt;
using Ludiq;
using UnityEngine;

[UnitCategory("Interaction")]
[UnitTitle("Set Turntable Orientation")]
[UnitSubtitle("Sets turntable to face a desired angle")]
[TypeIcon(typeof(SphereCollider))]
public class SetTurntableOrientation : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput snappedTrigger;

	[DoNotSerialize]
	public ValueInput turntableFinderObject;

	[DoNotSerialize]
	public ValueInput angleValue;

	[DoNotSerialize]
	public ValueInput autoFlipValue;

	protected override void Definition()
	{
		snappedTrigger = ControlOutput("Snapped");
		turntableFinderObject = ValueInput<GameObject>("Turntable", null);
		angleValue = ValueInput("Angle", 0f);
		autoFlipValue = ValueInput("Auto Flip", @default: false);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(turntableFinderObject);
			if (!value)
			{
				Debug.LogError("[SetTurntableOrientation] Turntable object is null, nothing to rotate");
				return snappedTrigger;
			}
			TutorialTurnTableFinder component = value.GetComponent<TutorialTurnTableFinder>();
			if ((bool)component)
			{
				component.Initialize();
				if (component.controller == null)
				{
					Debug.LogError("[SetTurntableOrientation] Turntable finder didn't find a turntable");
					return snappedTrigger;
				}
				if (flow.GetValue<bool>(autoFlipValue))
				{
					float targetYRotation = component.controller.turntable.targetYRotation;
					float value2 = flow.GetValue<float>(angleValue);
					float num = Mathf.Repeat(value2 + 180f, 360f);
					float num2 = Mathf.Abs(Mathf.DeltaAngle(targetYRotation, value2));
					float num3 = Mathf.Abs(Mathf.DeltaAngle(targetYRotation, num));
					component.controller.SetAngle((num2 < num3) ? value2 : num, forceNoSnapping: true);
				}
				else
				{
					component.controller.SetAngle(flow.GetValue<float>(angleValue), forceNoSnapping: true);
				}
			}
			else
			{
				Debug.LogError("[SetTurntableOrientation] Turntable object does not have a TutorialTurnTableFinder component");
			}
			return snappedTrigger;
		});
	}
}
