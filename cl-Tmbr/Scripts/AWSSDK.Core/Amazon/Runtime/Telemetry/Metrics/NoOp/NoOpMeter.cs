namespace Amazon.Runtime.Telemetry.Metrics.NoOp
{
	internal class NoOpMeter : Meter
	{
		public override UpDownCounter<T> CreateUpDownCounter<T>(string name, string units = null, string description = null)
		{
			return new NoOpUpDownCounter<T>();
		}

		public override MonotonicCounter<T> CreateMonotonicCounter<T>(string name, string units = null, string description = null)
		{
			return new NoOpMonotonicCounter<T>();
		}

		public override Histogram<T> CreateHistogram<T>(string name, string units = null, string description = null)
		{
			return new NoOpHistogram<T>();
		}
	}
}
