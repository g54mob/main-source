using Bolt;
using DV.Interaction.Inputs;
using Ludiq;
using UnityEngine;

[UnitTitle("Mouse Look")]
[UnitSubtitle("Wait for player to engage mouse look for at least a frame")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(MouseButton))]
public class MouseLookUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public bool Looked;

		public float Timeout;

		public float Elapsed;
	}

	[DoNotSerialize]
	public ValueInput delayValue;

	protected override string DoneFieldName => "Looked";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		delayValue = ValueInput("Delay", 2f);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			Looked = false,
			Timeout = flow.GetValue<float>(delayValue),
			Elapsed = 0f
		};
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		if (VRManager.IsVREnabled())
		{
			return true;
		}
		return base.EarlyOutCheck(flow, context, silent);
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (!context2.Looked)
		{
			context2.Looked = InputManager.NewPlayer.GetButton(InputManager.Actions.MouseLook);
		}
		else
		{
			context2.Elapsed += Time.deltaTime;
		}
		if (context2.Looked)
		{
			return context2.Elapsed >= context2.Timeout;
		}
		return false;
	}
}
