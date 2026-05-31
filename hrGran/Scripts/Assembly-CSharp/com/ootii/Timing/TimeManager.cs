namespace com.ootii.Timing
{
	public class TimeManager
	{
		public static float Relative60FPSDeltaTime;

		private static int mSampleCount;

		public static float _AverageDeltaTime;

		public static TimeManagerCore Core;

		private static float[] mSamples;

		private static int mSampleIndex;

		public static int SampleCount => 0;

		public static float AverageDeltaTime => 0f;

		public static float SmoothedDeltaTime => 0f;

		static TimeManager()
		{
		}

		public static void Initialize()
		{
		}

		public static void Update()
		{
		}
	}
}
