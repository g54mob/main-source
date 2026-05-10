using System.Diagnostics;

namespace FluffyUnderware.DevTools
{
	public class TimeMeasure : Ring<long>
	{
		public Stopwatch mWatch;

		public double LastTicks => 0.0;

		public double LastMS => 0.0;

		public double AverageMS => 0.0;

		public double MinimumMS => 0.0;

		public double MaximumMS => 0.0;

		public double AverageTicks => 0.0;

		public double MinimumTicks => 0.0;

		public double MaximumTicks => 0.0;

		public TimeMeasure(int size)
			: base(0)
		{
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		public void Pause()
		{
		}
	}
}
