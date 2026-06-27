using System;
using System.Diagnostics;

namespace FluentAssertions.Common
{
	internal sealed class StopwatchTimer : ITimer, IDisposable
	{
		private readonly Stopwatch stopwatch = Stopwatch.StartNew();

		public TimeSpan Elapsed => stopwatch.Elapsed;

		public void Dispose()
		{
			if (stopwatch.IsRunning)
			{
				stopwatch.Stop();
			}
		}
	}
}
