using System;
using System.Threading;

namespace Coherence.Common
{
	public class ConcurrentStopwatch : IStopwatch
	{
		private readonly IStopwatch stopwatch;

		private readonly ReaderWriterLockSlim rwLock;

		public long ElapsedMilliseconds => 0L;

		public TimeSpan Elapsed => default(TimeSpan);

		public ConcurrentStopwatch(IStopwatch stopwatch)
		{
		}

		public void Start()
		{
		}

		public void Reset()
		{
		}

		public void Restart()
		{
		}

		public void Stop()
		{
		}
	}
}
