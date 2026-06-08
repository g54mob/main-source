namespace Amazon.Runtime.Telemetry.Tracing.NoOp
{
	internal class NoOpTracerProvider : TracerProvider
	{
		public override Tracer GetTracer(string scope)
		{
			return new NoOpTracer();
		}
	}
}
