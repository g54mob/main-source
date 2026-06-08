namespace Amazon.Runtime.Telemetry.Metrics.NoOp
{
	internal class NoOpHistogram<T> : Histogram<T> where T : struct
	{
		public override void Record(T value, Attributes attributes = null)
		{
		}
	}
}
