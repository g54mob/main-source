using Bolt;
using DV.Interaction.Inputs;
using Ludiq;
using UnityEngine;

[UnitCategory("Interaction")]
[TypeIcon(typeof(Camera))]
[UnitSubtitle("Have the player zoom for a while")]
[UnitTitle("Zoom")]
public class ZoomHoldUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public float Time;
	}

	[DoNotSerialize]
	public ValueInput timeValue;

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		timeValue = ValueInput("Time", 3f);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			Time = flow.GetValue<float>(timeValue)
		};
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (InputManager.NewPlayer.GetButton(InputManager.Actions.Zoom))
		{
			context2.Time -= Time.deltaTime;
		}
		return context2.Time <= 0f;
	}
}
