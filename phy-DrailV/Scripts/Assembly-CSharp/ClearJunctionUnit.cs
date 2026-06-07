using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Clear Junction")]
[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Trains")]
[UnitSubtitle("Waits for player to move any trains away from a junction")]
public class ClearJunctionUnit : GenericWaitForConditionWithMessage
{
	[DoNotSerialize]
	public ValueInput junctionBlocker;

	protected override string DoneFieldName => "Entered";

	protected override void InternalDefinition()
	{
		junctionBlocker = ValueInput<TutorialSwitchInhibitor>("Blocker", null);
		Requirement(junctionBlocker, inputTrigger);
	}

	public override object PrepareContext(Flow flow)
	{
		return flow.GetValue<TutorialSwitchInhibitor>(junctionBlocker);
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		if (context != null)
		{
			return base.EarlyOutCheck(flow, context);
		}
		return true;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return !((TutorialSwitchInhibitor)context).IsBlocked;
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		GameObject messageAnchor = base.GetMessageAnchor(flow, context);
		if (!messageAnchor)
		{
			return ((TutorialSwitchInhibitor)context).junctionSwitch.VisualSwitch.gameObject;
		}
		return messageAnchor;
	}
}
