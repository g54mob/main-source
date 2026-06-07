using Bolt;
using DV.Common;
using Ludiq;
using UnityEngine;

[UnitTitle("Check Tutorial Junction Alignment")]
[UnitSubtitle("Wait for the registered tutorial junctions to become properly aligned")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(SphereCollider))]
public class CheckTutorialJunctionAlignment : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public TutorialSteelMillSwitchChecker Checker;

		public bool WasSwitchingAllowed;
	}

	[DoNotSerialize]
	public ValueInput targetItem;

	protected override string DoneFieldName => "Flipped";

	protected override string AnchorFieldName => "Attention";

	protected override void InternalDefinition()
	{
		targetItem = ValueInput<GameObject>("Item", null);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		GameObject value = flow.GetValue<GameObject>(targetItem);
		context.Checker = (value ? value.GetComponentInChildren<TutorialSteelMillSwitchChecker>() : null);
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		if (context == null)
		{
			return true;
		}
		return base.EarlyOutCheck(flow, context, silent);
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, false);
		Context obj = (Context)context;
		obj.Checker.InitializeAndStartChecking();
		obj.WasSwitchingAllowed = GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.JunctionSwitching);
		if (!obj.WasSwitchingAllowed)
		{
			GameFeatureFlags.Allow(GameFeatureFlags.Flag.JunctionSwitching);
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((Context)context).Checker.IsAlligned();
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		base.Deinitialize(flow, context, false);
		Context context2 = (Context)context;
		if (context2.Checker != null)
		{
			context2.Checker.StopChecking();
		}
		if (!context2.WasSwitchingAllowed)
		{
			GameFeatureFlags.Deny(GameFeatureFlags.Flag.JunctionSwitching);
		}
	}
}
