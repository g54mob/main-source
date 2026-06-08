namespace Amazon.Runtime.Telemetry.Metrics.NoOp
{
	internal class NoOpMeterProvider : MeterProvider
	{
		public override Meter GetMeter(string scope, Attributes attributes = null)
		{
			return new NoOpMeter();
		}
	}
}
