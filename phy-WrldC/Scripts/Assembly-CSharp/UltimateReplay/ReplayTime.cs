namespace UltimateReplay
{
	public static class ReplayTime
	{
		private static float time = 0f;

		private static float delta = 0f;

		private static float timeScale = 1f;

		public static float Time
		{
			get
			{
				return time;
			}
			internal set
			{
				time = value;
			}
		}

		public static float Delta
		{
			get
			{
				return delta;
			}
			internal set
			{
				delta = value;
			}
		}

		public static float TimeScale
		{
			get
			{
				return timeScale;
			}
			set
			{
				timeScale = value;
			}
		}

		public static PlaybackDirection TimeScaleDirection
		{
			get
			{
				if (timeScale < 0f)
				{
					return PlaybackDirection.Backward;
				}
				return PlaybackDirection.Forward;
			}
		}

		public static void ResetTimeScale()
		{
			timeScale = 1f;
		}

		public static string GetCorrectedTimeValueString(float timeValue)
		{
			int num = (int)(timeValue / 60f);
			return string.Format("{0}:{1}", num, ((int)(timeValue % 60f)).ToString("00"));
		}
	}
}
