namespace Amazon.Runtime.Telemetry.Metrics.NoOp
{
	internal class NoOpMonotonicCounter<T> : MonotonicCounter<T> where T : struct
	{
		public override void Add(T value, Attributes attributes = null)
		{
		}
	}
}
