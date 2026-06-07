using System;
using System.Diagnostics;

namespace Coherence.Common
{
	public class SystemStopwatch : IStopwatch
	{
		private readonly Stopwatch stopwatch;

		public long ElapsedMilliseconds => 0L;

		public TimeSpan Elapsed => default(TimeSpan);

		public static IStopwatch StartNew()
		{
			return null;
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		public void Reset()
		{
		}

		public void Restart()
		{
		}
	}
}
