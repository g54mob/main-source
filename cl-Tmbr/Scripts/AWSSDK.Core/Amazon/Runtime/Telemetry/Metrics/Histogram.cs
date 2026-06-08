namespace Amazon.Runtime.Telemetry.Metrics
{
	public abstract class Histogram<T> where T : struct
	{
		public abstract void Record(T value, Attributes attributes = null);
	}
}
