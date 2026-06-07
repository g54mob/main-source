namespace Coherence.Interpolation
{
	public struct InterpolationResult<T>
	{
		public Sample<T> sample0;

		public Sample<T> sample1;

		public Sample<T> sample2;

		public Sample<T> sample3;

		public float t;

		public double delay;

		public double targetDelay;

		public double networkLatency;

		public double lastSampleLatency;

		public double lastSampleInterval;

		public double measuredSampleInterval;

		public bool isStopped;

		public double virtualOvershoot;

		public T value0 => default(T);

		public T value1 => default(T);

		public T value2 => default(T);

		public T value3 => default(T);

		public override string ToString()
		{
			return null;
		}
	}
}
