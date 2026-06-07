using Bolt;
using DV.UI;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Sets or waits for a canvas element to turn on or off")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(CharacterController))]
[UnitTitle("Panel ON/OFF")]
public class InventoryOnOffUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public bool TargetState;

		public bool ShouldSet;

		public CanvasController.ElementType Element;
	}

	[DoNotSerialize]
	public ValueInput targetElementValue;

	[DoNotSerialize]
	public ValueInput value;

	[DoNotSerialize]
	public ValueInput setInsteadOfWait;

	protected override string DoneFieldName => "Output";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		targetElementValue = ValueInput("Element", CanvasController.ElementType.Inventory);
		value = ValueInput("State", @default: false);
		setInsteadOfWait = ValueInput("Set instead of Wait", @default: false);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			TargetState = flow.GetValue<bool>(value),
			ShouldSet = flow.GetValue<bool>(setInsteadOfWait),
			Element = flow.GetValue<CanvasController.ElementType>(targetElementValue)
		};
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.ShouldSet)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(context2.Element, context2.TargetState);
			return true;
		}
		return base.EarlyOutCheck(flow, context, silent);
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		return SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(context2.Element) == context2.TargetState;
	}
}
