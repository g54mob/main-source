using System;

namespace Amazon.Runtime.Telemetry.Tracing.NoOp
{
	internal class NoOpTraceSpan : TraceSpan
	{
		public override void EmitEvent(string name, Attributes attributes = null)
		{
		}

		public override void SetAttribute(string key, object value)
		{
		}

		public override void SetStatus(SpanStatus status)
		{
		}

		public override void RecordException(Exception exception, Attributes attributes = null)
		{
		}

		public override void End()
		{
		}
	}
}
