namespace Amazon.Runtime.Telemetry.Metrics.NoOp
{
	internal class NoOpUpDownCounter<T> : UpDownCounter<T> where T : struct
	{
		public override void Add(T value, Attributes attributes = null)
		{
		}
	}
}
