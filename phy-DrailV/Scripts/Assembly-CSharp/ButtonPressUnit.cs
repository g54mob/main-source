using Bolt;
using DV.CabControls;
using DV.CabControls.Spec;
using Ludiq;
using UnityEngine;

[UnitTitle("Button Press")]
[UnitCategory("Interaction")]
[UnitSubtitle("Wait for a regular button to be pressed")]
[TypeIcon(typeof(Button))]
public class ButtonPressUnit : GenericWaitForConditionWithMessage
{
	[DoNotSerialize]
	public ValueInput targetButton;

	protected override void InternalDefinition()
	{
		targetButton = ValueInput<GameObject>("Button", null);
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		GameObject messageAnchor = base.GetMessageAnchor(flow, context);
		if (messageAnchor != null)
		{
			return messageAnchor;
		}
		return ((ButtonBase)context).gameObject;
	}

	public override object PrepareContext(Flow flow)
	{
		return flow.GetValue<GameObject>(targetButton).GetComponent<ButtonBase>();
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((ButtonBase)context).Value > 0.5f;
	}
}
