using System.Threading;

namespace DV.Telemetry
{
	public static class TelemetrySavingTracker
	{
		private static volatile int count;

		public static bool AnyPendingSaves => count > 0;

		public static void StartSaving()
		{
			Interlocked.Increment(ref count);
		}

		public static void FinishSaving()
		{
			Interlocked.Decrement(ref count);
		}
	}
}
