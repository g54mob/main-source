namespace Amazon.Runtime.Telemetry.Metrics
{
	public abstract class MeterProvider
	{
		public abstract Meter GetMeter(string scope, Attributes attributes = null);
	}
}
