using System;

namespace Pug.UnityExtensions
{
	public class WallClockTimer
	{
		private TimeSpan _lifespan;

		private DateTime _startTime;

		public bool HasElapsed => TimeElapsed >= _lifespan;

		public TimeSpan TimeElapsed => DateTime.Now - _startTime;

		public WallClockTimer(TimeSpan lifespan)
		{
			Restart(lifespan);
		}

		public void Restart(TimeSpan newLifespan)
		{
			_lifespan = newLifespan;
			Restart();
		}

		public void Restart()
		{
			_startTime = DateTime.Now;
		}
	}
}
