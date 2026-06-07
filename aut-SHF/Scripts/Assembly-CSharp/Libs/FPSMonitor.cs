namespace Libs
{
	public static class FPSMonitor
	{
		private static float[] _deltaTimes;

		private static int _frameIndex;

		private static float _averageFPS;

		public static float CurrentFPS => 0f;

		static FPSMonitor()
		{
		}

		public static void Update()
		{
		}
	}
}
