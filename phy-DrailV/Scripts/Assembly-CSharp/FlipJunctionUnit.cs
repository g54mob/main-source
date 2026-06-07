using Bolt;
using DV.Common;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitTitle("Flip Junction")]
[UnitSubtitle("Wait for junction to become switched in desired direction")]
[UnitCategory("Trains")]
public class FlipJunctionUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public JunctionSwitchRemoteControllable junctionSwitch;

		public Junction junction;

		public int branch;

		public bool wasSwitchingAllowed;
	}

	[DoNotSerialize]
	public ValueInput desiredBranch;

	[DoNotSerialize]
	public ValueInput junctionObject;

	protected override string DoneFieldName => "Switched";

	protected override string AnchorFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		desiredBranch = ValueInput("Branch", 0);
		junctionObject = ValueInput<GameObject>("Junction", null);
	}

	public override object PrepareContext(Flow flow)
	{
		Context obj = new Context
		{
			junctionSwitch = flow.GetValue<GameObject>(junctionObject).GetComponentInChildren<JunctionSwitchRemoteControllable>()
		};
		obj.junction = obj.junctionSwitch.transform.parent.GetComponentInChildren<Junction>();
		obj.branch = flow.GetValue<int>(desiredBranch);
		return obj;
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		Context context2 = (Context)context;
		SingletonBehaviour<JunctionSwitcherManager>.Instance.ResetSwitchWhitelist();
		SingletonBehaviour<JunctionSwitcherManager>.Instance.AllowSwitchingForJunction(context2.junction);
		context2.wasSwitchingAllowed = GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.JunctionSwitching);
		if (!context2.wasSwitchingAllowed)
		{
			GameFeatureFlags.Allow(GameFeatureFlags.Flag.JunctionSwitching);
		}
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		base.Deinitialize(flow, context, silent);
		Context obj = (Context)context;
		SingletonBehaviour<JunctionSwitcherManager>.Instance.ResetSwitchWhitelist();
		if (!obj.wasSwitchingAllowed)
		{
			GameFeatureFlags.Deny(GameFeatureFlags.Flag.JunctionSwitching);
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		return context2.junction.selectedBranch == context2.branch;
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		return ((Context)context).junctionSwitch.gameObject;
	}
}
