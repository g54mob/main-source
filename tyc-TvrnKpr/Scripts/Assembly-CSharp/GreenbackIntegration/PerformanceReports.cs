using System.Collections.Generic;
using System.Diagnostics;

namespace GreenbackIntegration
{
	public static class PerformanceReports
	{
		public static class Timers
		{
			public const string GameBoot = "GameBoot";
		}

		private static Dictionary<string, long> _startTimes;

		private static Stopwatch _stopwatch;

		public static void StartTimer(string key)
		{
		}

		public static void StopAndLogTimer(string key)
		{
		}

		public static void LogTimer(string key, float durationInMilliseconds)
		{
		}
	}
}
