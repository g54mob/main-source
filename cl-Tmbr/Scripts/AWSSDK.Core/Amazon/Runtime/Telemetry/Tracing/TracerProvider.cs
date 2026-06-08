namespace Amazon.Runtime.Telemetry.Tracing
{
	public abstract class TracerProvider
	{
		public abstract Tracer GetTracer(string scope);
	}
}
