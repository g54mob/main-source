namespace Amazon.Runtime.Telemetry.Tracing
{
	public abstract class SpanContext
	{
		public abstract string TraceId { get; }

		public abstract string SpanId { get; }

		public abstract bool IsRemote { get; }

		public abstract bool IsValid { get; }
	}
}
