using Bolt;
using DV.Customization.Gadgets.Implementations;
using Ludiq;
using UnityEngine;

[UnitTitle("Beacon State")]
[UnitCategory("Player")]
[TypeIcon(typeof(Light))]
[UnitSubtitle("Wait for beacon to turn on or off")]
public class BeaconStateUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public GadgetBeacon Beacon;

		public Transform CustomAnchor;

		public bool TargetState;
	}

	[DoNotSerialize]
	public ValueInput beacon;

	[DoNotSerialize]
	public ValueInput targetState;

	protected override void InternalDefinition()
	{
		beacon = ValueInput<GameObject>("Beacon", null);
		targetState = ValueInput("On", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		Context obj = new Context
		{
			Beacon = flow.GetValue<GameObject>(beacon).GetComponent<GadgetBeacon>(),
			TargetState = flow.GetValue<bool>(targetState)
		};
		GameObject value = flow.GetValue<GameObject>(floatieAnchor);
		obj.CustomAnchor = (value ? value.transform : null);
		return obj;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.TargetState)
		{
			return context2.Beacon.CurrentValue >= 1f;
		}
		return context2.Beacon.CurrentValue < 1f;
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		Context context2 = (Context)context;
		if (!context2.CustomAnchor)
		{
			return context2.Beacon.gameObject;
		}
		return context2.CustomAnchor.gameObject;
	}
}
