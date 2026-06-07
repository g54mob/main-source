using Bolt;
using DV.Utils;
using Ludiq;

[TypeIcon(typeof(MouseButton))]
[UnitCategory("Interaction")]
[UnitSubtitle("Wait for player enable or disable the mouse mode")]
[UnitTitle("Mouse Mode")]
public class MouseModeUnit : GenericWaitForConditionWithMessage
{
	[DoNotSerialize]
	public ValueInput targetValue;

	protected override string DoneFieldName => "Switch";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		targetValue = ValueInput("On", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		return flow.GetValue<bool>(targetValue);
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return (bool)context == SingletonBehaviour<ScreenspaceMouse>.Instance.on;
	}
}
