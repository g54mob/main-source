using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;
using VRTK;

[TypeIcon(typeof(CharacterController))]
[UnitCategory("Input")]
[UnitSubtitle("Wait for player to use axis in VR")]
[UnitTitle("VR Axis Pressed")]
public class VRAxisPressed : GenericWaitForCondition
{
	private class Context
	{
		public bool Hand;

		public VRTK_ControllerEvents.Vector2AxisAlias Axis;

		public Vector2 Multiplier;
	}

	[DoNotSerialize]
	public ValueInput rightHand;

	[DoNotSerialize]
	public ValueInput requiredAxis;

	[DoNotSerialize]
	public ValueInput multiplier;

	protected override string DoneFieldName => "Pressed";

	protected override void InternalDefinition()
	{
		requiredAxis = ValueInput("Axis", VRTK_ControllerEvents.Vector2AxisAlias.Undefined);
		multiplier = ValueInput("Multiplier", default(Vector2));
		rightHand = ValueInput("Right Hand", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			Hand = flow.GetValue<bool>(rightHand),
			Axis = flow.GetValue<VRTK_ControllerEvents.Vector2AxisAlias>(requiredAxis),
			Multiplier = flow.GetValue<Vector2>(multiplier)
		};
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		VRTK_ControllerEvents vRTK_ControllerEvents = SingletonBehaviour<TutorialHelper>.Instance.ControllerEvents[context2.Hand ? 1 : 0];
		if ((bool)vRTK_ControllerEvents)
		{
			Vector2 vector = vRTK_ControllerEvents.GetAxis(context2.Axis) * context2.Multiplier;
			if (Mathf.Max(Mathf.Abs(vector.x), Mathf.Abs(vector.y)) > 0.5f)
			{
				return true;
			}
		}
		return false;
	}
}
