using Bolt;
using Ludiq;
using UnityEngine;

[UnitCategory("Timing")]
[UnitTitle("Wait")]
[TypeIcon(typeof(Timer))]
[UnitSubtitle("Delay further execution for X seconds")]
public class WaitUnit : GenericWaitForCondition
{
	private class Context
	{
		public bool Realtime;

		public float Seconds;

		public float LastCheckTime;

		public int StartingFrame;
	}

	[DoNotSerialize]
	public ValueInput secondsValue;

	[DoNotSerialize]
	public ValueInput realtimeCheck;

	protected override void InternalDefinition()
	{
		secondsValue = ValueInput("Seconds", 1f);
		realtimeCheck = ValueInput("Real-time", @default: false);
	}

	public override object PrepareContext(Flow flow)
	{
		Context obj = new Context
		{
			Seconds = flow.GetValue<float>(secondsValue),
			Realtime = flow.GetValue<bool>(realtimeCheck)
		};
		obj.LastCheckTime = (obj.Realtime ? Time.realtimeSinceStartup : Time.time);
		obj.StartingFrame = Time.frameCount;
		return obj;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		float num = (context2.Realtime ? Time.realtimeSinceStartup : Time.time);
		float num2 = num - context2.LastCheckTime;
		context2.LastCheckTime = num;
		context2.Seconds -= num2;
		if (context2.Seconds <= 0f)
		{
			return Time.frameCount > context2.StartingFrame;
		}
		return false;
	}
}
