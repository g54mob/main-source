namespace Amazon.Runtime.Telemetry.Metrics
{
	public abstract class UpDownCounter<T> where T : struct
	{
		public abstract void Add(T value, Attributes attributes = null);
	}
}
