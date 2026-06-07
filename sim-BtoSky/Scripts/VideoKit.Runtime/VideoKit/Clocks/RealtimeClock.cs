using System.Runtime.CompilerServices;
using VideoKit.Internal;

namespace VideoKit.Clocks
{
	public sealed class RealtimeClock : IClock
	{
		private long startTime;

		private bool isPaused;

		private long pauseTime;

		public long timestamp
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return (isPaused ? pauseTime : CurrentTimestamp) - startTime;
			}
		}

		public bool paused
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return isPaused;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (value != isPaused)
				{
					if (value)
					{
						pauseTime = CurrentTimestamp;
					}
					else
					{
						startTime += CurrentTimestamp - pauseTime;
					}
					isPaused = value;
				}
			}
		}

		private static long CurrentTimestamp
		{
			get
			{
				if (VideoKit.Internal.VideoKit.GetCurrentTimestamp(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0L;
				}
				return result;
			}
		}

		public RealtimeClock()
		{
			startTime = CurrentTimestamp;
			isPaused = false;
			pauseTime = 0L;
		}
	}
}
