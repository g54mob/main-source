using System;

namespace Sentry.Ben.BlockingDetector
{
	internal class StaticTaskBlockingListenerState : ITaskBlockingListenerState
	{
		[ThreadStatic]
		private static int SuppressionCount;

		public void Suppress()
		{
			SuppressionCount++;
		}

		public bool IsSuppressed()
		{
			return SuppressionCount > 0;
		}

		public void Restore()
		{
			SuppressionCount--;
		}
	}
}
