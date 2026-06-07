using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Reset Player Orientation")]
[UnitSubtitle("Force player to be in a certain position and/or face a certain way")]
[UnitCategory("Player")]
[TypeIcon(typeof(CharacterController))]
public class ResetPlayerOrientationUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput forcedTrigger;

	[DoNotSerialize]
	public ValueInput forceAngleValue;

	[DoNotSerialize]
	public ValueInput angleValue;

	[DoNotSerialize]
	public ValueInput forcePositionValue;

	[DoNotSerialize]
	public ValueInput positionValue;

	protected override void Definition()
	{
		forcedTrigger = ControlOutput("Dropped");
		forceAngleValue = ValueInput("Force angle", @default: true);
		angleValue = ValueInput("Angle", 0f);
		forcePositionValue = ValueInput("Force position", @default: false);
		positionValue = ValueInput("Position", Vector3.zero);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			if (!VRManager.IsVREnabled() && flow.GetValue<bool>(forceAngleValue))
			{
				CustomFirstPersonController component = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
				if ((bool)component)
				{
					float value = flow.GetValue<float>(angleValue);
					component.ForceLookRotation(Quaternion.Euler(0f, value, 0f));
				}
			}
			if (flow.GetValue<bool>(forcePositionValue))
			{
				PlayerManager.TeleportPlayer(flow.GetValue<Vector3>(positionValue) + WorldMover.currentMove, Quaternion.identity, null, useRotation: false);
			}
			return forcedTrigger;
		});
	}
}
