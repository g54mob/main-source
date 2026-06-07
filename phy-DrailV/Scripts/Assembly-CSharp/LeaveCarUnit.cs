using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitSubtitle("Player is on foot, outside any train car")]
[UnitCategory("Trains")]
[UnitTitle("Leave Train Car")]
public class LeaveCarUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public float Timeout;

		public float Elapsed;
	}

	[DoNotSerialize]
	public ValueInput leaveTime;

	protected override string DoneFieldName => "Left";

	protected override string OffsetFieldName => string.Empty;

	protected override string AnchorFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		leaveTime = ValueInput("Time", 1f);
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context
		{
			Timeout = flow.GetValue<float>(leaveTime),
			Elapsed = 0f
		};
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		return PlayerManager.Car == null;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (PlayerManager.Car == null)
		{
			context2.Elapsed += Time.deltaTime;
			return context2.Elapsed >= context2.Timeout;
		}
		context2.Elapsed = 0f;
		return false;
	}
}
