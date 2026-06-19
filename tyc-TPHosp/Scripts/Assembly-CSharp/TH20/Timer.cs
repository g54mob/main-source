namespace TH20
{
	public class Timer
	{
		public readonly string Name;

		public readonly bool UseScaledTime;

		private readonly bool _isRandomTimer;

		private readonly bool _rerandomiseEveryReset;

		private readonly float _minTimerLength;

		private readonly float _maxTimerLength;

		private float _timerLength;

		public float TimeRemaining;

		public bool ExpireOnFinish;

		public Timer(string name, bool useScaledTime, float timerLength, bool isLooping)
		{
			Name = name;
			UseScaledTime = useScaledTime;
			_isRandomTimer = false;
			TimeRemaining = timerLength;
			_timerLength = timerLength;
			ExpireOnFinish = !isLooping;
		}

		public Timer(string name, bool useScaledTime, float minTimerLength, float maxTimerLength, bool isLooping, bool rerandomiseEveryReset)
		{
			Name = name;
			UseScaledTime = useScaledTime;
			_isRandomTimer = true;
			_minTimerLength = minTimerLength;
			_maxTimerLength = maxTimerLength;
			_timerLength = RandomUtils.GlobalRandomInstance.NextFloat(_minTimerLength, _maxTimerLength);
			ExpireOnFinish = !isLooping;
			_rerandomiseEveryReset = rerandomiseEveryReset;
		}

		public void Reset()
		{
			if (!ExpireOnFinish)
			{
				if (_isRandomTimer && _rerandomiseEveryReset)
				{
					_timerLength = RandomUtils.GlobalRandomInstance.NextFloat(_minTimerLength, _maxTimerLength);
				}
				TimeRemaining = _timerLength;
			}
		}
	}
}
