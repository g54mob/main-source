using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Sit Down")]
[UnitSubtitle("Wait for player sit down or get up")]
[TypeIcon(typeof(CharacterController))]
[UnitCategory("Player")]
public class SitDownUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public bool WantedValue;

		public CustomFirstPersonController FPC;
	}

	[DoNotSerialize]
	public ValueInput sitValue;

	protected override string DoneFieldName => "Dropped";

	protected override string AnchorFieldName => "Attention";

	protected override void InternalDefinition()
	{
		sitValue = ValueInput("Sit down", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			WantedValue = flow.GetValue<bool>(sitValue),
			FPC = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>()
		};
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (!VRManager.IsVREnabled() && !(context2.FPC == null))
		{
			return context2.FPC.provider.IsSitting == context2.WantedValue;
		}
		return true;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		return context2.FPC.provider.IsSitting == context2.WantedValue;
	}
}
