using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;
using VRTK;

[TypeIcon(typeof(CharacterController))]
[UnitSubtitle("Wait for player to press button in VR")]
[UnitCategory("Input")]
[UnitTitle("VR Button Pressed")]
public class VRButtonPressed : GenericWaitForCondition
{
	private class Context
	{
		public bool Hand;

		public VRTK_ControllerEvents.ButtonAlias Button;
	}

	[DoNotSerialize]
	public ValueInput requiredButton;

	[DoNotSerialize]
	public ValueInput rightHand;

	protected override string DoneFieldName => "Pressed";

	protected override void InternalDefinition()
	{
		requiredButton = ValueInput("Button", VRTK_ControllerEvents.ButtonAlias.Undefined);
		rightHand = ValueInput("Right Hand", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			Hand = flow.GetValue<bool>(rightHand),
			Button = flow.GetValue<VRTK_ControllerEvents.ButtonAlias>(requiredButton)
		};
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		VRTK_ControllerEvents vRTK_ControllerEvents = SingletonBehaviour<TutorialHelper>.Instance.ControllerEvents[context2.Hand ? 1 : 0];
		if ((bool)vRTK_ControllerEvents)
		{
			return vRTK_ControllerEvents.IsButtonPressed(context2.Button);
		}
		return false;
	}
}
