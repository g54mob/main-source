using System;

namespace Sentry.Ben.BlockingDetector
{
	internal class StaticRecursionTracker : IRecursionTracker
	{
		[ThreadStatic]
		private static int RecursionCount;

		public void Recurse()
		{
			RecursionCount++;
		}

		public void Backtrack()
		{
			if (RecursionCount > 0)
			{
				RecursionCount--;
			}
		}

		public bool IsRecursive()
		{
			return RecursionCount > 0;
		}

		public bool IsFirstRecursion()
		{
			return RecursionCount == 1;
		}
	}
}
