using Bolt;
using DV.Interaction.Inputs;
using DV.Localization;
using DV.Utils;
using Ludiq;
using UnityEngine;
using UnityEngine.UI;

[UnitSubtitle("Can point to things if Attention is attached")]
[TypeIcon(typeof(Text))]
[UnitCategory("UI")]
[UnitTitle("Show Floatie")]
public class ShowFloatieUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public bool NeedsDismissal;

		public bool Depressed;

		public bool Dismissed;

		public int StartFrame;

		public int Countdown = 3;
	}

	[DoNotSerialize]
	public ValueInput needsDismissal;

	protected override string DoneFieldName => "Continue";

	protected override string AnchorFieldName => "Attention";

	protected override bool LocalizeMessage => false;

	protected override void InternalDefinition()
	{
		needsDismissal = ValueInput("Manual dismiss", @default: false);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			NeedsDismissal = flow.GetValue<bool>(needsDismissal)
		};
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		return false;
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		if (((Context)context).NeedsDismissal && !VRManager.IsVREnabled())
		{
			InputManager.SetInteractConflictersEnabled(on: false);
		}
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.NeedsDismissal && !VRManager.IsVREnabled())
		{
			InputManager.SetInteractConflictersEnabled(on: true);
		}
		base.Deinitialize(flow, context, !context2.NeedsDismissal || silent);
	}

	protected override string GetMessageText(Flow flow, object context)
	{
		if (((Context)context).NeedsDismissal)
		{
			if (VRManager.IsVREnabled())
			{
				string firstParamValue = (VRManager.AnyWandController() ? LocalizationAPI.L("vr/meta/right_touchpad_up") : LocalizationAPI.L("vr/meta/right_joystick_up"));
				string text = LocalizationAPI.L("tutorial/to_continue_vr", firstParamValue);
				return LocalizationAPI.L(base.GetMessageText(flow, context)) + "\n<color=#00ffff>" + text + "</color>";
			}
			return LocalizationAPI.L(base.GetMessageText(flow, context)) + "\n<color=#00ffff>" + LocalizationAPI.L("tutorial/to_continue_nonvr", InputManager.Actions.Interact.LocalizeInput()) + "</color>";
		}
		return LocalizationAPI.L(base.GetMessageText(flow, context));
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.NeedsDismissal)
		{
			if (!context2.Depressed)
			{
				if (!(VRManager.IsVREnabled() ? (!SingletonBehaviour<TutorialHelper>.Instance.IsAnyVRContinueButtonPressed) : (!InputManager.NewPlayer.GetButton(InputManager.Actions.Interact))))
				{
					return false;
				}
				context2.Depressed = true;
			}
			else if (!context2.Dismissed)
			{
				if (!(VRManager.IsVREnabled() ? SingletonBehaviour<TutorialHelper>.Instance.IsAnyVRContinueButtonPressed : InputManager.NewPlayer.GetButton(InputManager.Actions.Interact)))
				{
					return false;
				}
				SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
				context2.Dismissed = true;
				context2.StartFrame = Time.frameCount;
			}
			if (context2.Dismissed)
			{
				return Time.frameCount - context2.StartFrame >= context2.Countdown;
			}
			return false;
		}
		return true;
	}
}
