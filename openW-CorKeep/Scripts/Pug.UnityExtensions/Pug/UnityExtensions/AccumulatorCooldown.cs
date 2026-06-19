namespace Pug.UnityExtensions
{
	public class AccumulatorCooldown
	{
		public readonly int limit;

		private TimerSimple timer;

		public int accu { get; private set; }

		public float lifespan => timer.lifespan;

		public AccumulatorCooldown(int limit, float timeWindow)
		{
			this.limit = limit;
			timer = new TimerSimple(timeWindow);
			Reset();
		}

		public void Reset()
		{
			accu = 0;
			timer.Stop();
		}

		public int Hit()
		{
			if (!timer.isRunning || timer.isTimerElapsed)
			{
				Reset();
			}
			accu++;
			if (accu >= limit)
			{
				Reset();
				return 0;
			}
			timer.Start();
			return limit - accu;
		}
	}
}
