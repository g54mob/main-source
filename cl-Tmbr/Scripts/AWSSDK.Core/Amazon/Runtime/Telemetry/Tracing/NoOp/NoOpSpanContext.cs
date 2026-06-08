namespace Amazon.Runtime.Telemetry.Tracing.NoOp
{
	internal class NoOpSpanContext : SpanContext
	{
		public override string TraceId => string.Empty;

		public override string SpanId => string.Empty;

		public override bool IsRemote => false;

		public override bool IsValid => false;
	}
}
