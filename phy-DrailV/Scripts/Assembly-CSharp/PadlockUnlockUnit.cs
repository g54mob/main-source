using Bolt;
using Ludiq;
using UnityEngine;

[UnitCategory("Interaction")]
[UnitSubtitle("Wait for padlock to be unlocked")]
[TypeIcon(typeof(BoxCollider))]
[UnitTitle("Padlock Unlock")]
public class PadlockUnlockUnit : GenericWaitForConditionWithMessage
{
	[DoNotSerialize]
	public ValueInput padlock;

	protected override string DoneFieldName => "Unlocked";

	protected override string OffsetFieldName => "Target";

	protected override string AnchorFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		padlock = ValueInput<GameObject>("Padlock", null);
	}

	public override object PrepareContext(Flow flow)
	{
		return flow.GetValue<GameObject>(padlock).GetComponent<Padlock>();
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return !((Padlock)context).IsLocked;
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		return ((Padlock)context).gameObject;
	}
}
