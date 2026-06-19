using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	public struct RateLimiter
	{
		private int _currentRate;

		private float _processRatioPerTick;

		public RateLimiter(int maxTicksToProcessAll)
		{
			_currentRate = 0;
			_processRatioPerTick = 1f / (float)maxTicksToProcessAll;
		}

		public void SetMaxTicksToProcessAll(int maxTicksToProcessAll)
		{
			_processRatioPerTick = 1f / (float)maxTicksToProcessAll;
		}

		public int UpdateAndGetCurrentTarget(int currentPending)
		{
			_currentRate = math.max(_currentRate, (int)math.ceil((float)currentPending * _processRatioPerTick));
			_currentRate = math.min(_currentRate, currentPending);
			return _currentRate;
		}
	}
}
