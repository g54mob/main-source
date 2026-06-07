using System.Diagnostics;

namespace Placemaker
{
	public static class UniversalStopwatch
	{
		public static Stopwatch stopwatch;

		private static int lastCountFrame;

		public static bool StartCounting()
		{
			return false;
		}

		public static bool KeepGoing()
		{
			return false;
		}
	}
}
