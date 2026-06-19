using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	public struct ThreadSafeTimerSimple
	{
		private double _startTime;

		public float lifespan;

		private float _timer;

		public bool isRunning => _startTime > 0.0;

		public float GetElapsedTime(double currentTime)
		{
			if (isRunning)
			{
				_timer = (float)(currentTime - math.abs(_startTime));
			}
			return _timer;
		}

		public float GetRemainingTime(double currentTime)
		{
			return lifespan - GetElapsedTime(currentTime);
		}

		public bool IsTimerElapsed(double currentTime)
		{
			return GetElapsedTime(currentTime) >= lifespan;
		}

		public float GetElapsedRatio(double currentTime)
		{
			return GetElapsedTime(currentTime) / lifespan;
		}

		public float GetInvElapsedRatio(double currentTime)
		{
			return 1f - GetElapsedRatio(currentTime);
		}

		public void Stop()
		{
			_startTime = 0.0 - math.abs(_startTime);
		}

		public void Start(double currentTime, float newLifespan)
		{
			lifespan = newLifespan;
			_startTime = currentTime;
		}
	}
}
