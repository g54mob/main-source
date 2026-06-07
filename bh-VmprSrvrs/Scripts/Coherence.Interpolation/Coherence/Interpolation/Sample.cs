namespace Coherence.Interpolation
{
	public struct Sample<T>
	{
		public T Value;

		public bool Stopped;

		public readonly double Time;

		public readonly double? Latency;

		public long Frame => 0L;

		public Sample(T value, bool stopped, double time, double? latency)
		{
			Value = default(T);
			Stopped = false;
			Time = 0.0;
			Latency = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
