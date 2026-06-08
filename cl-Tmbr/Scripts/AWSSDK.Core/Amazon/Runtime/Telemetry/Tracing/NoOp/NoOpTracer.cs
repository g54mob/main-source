namespace Amazon.Runtime.Telemetry.Tracing.NoOp
{
	internal class NoOpTracer : Tracer
	{
		public override TraceSpan CreateSpan(string name, Attributes initialAttributes = null, SpanKind spanKind = SpanKind.INTERNAL, SpanContext parentContext = null)
		{
			return new NoOpTraceSpan();
		}
	}
}
