using System.Diagnostics;

namespace Pathfinding.Jobs
{
	public struct TimeSlice
	{
		public long endTick;

		public static readonly TimeSlice Infinite = new TimeSlice
		{
			endTick = long.MaxValue
		};

		public bool expired => Stopwatch.GetTimestamp() > endTick;

		public static TimeSlice MillisFromNow(float millis)
		{
			return new TimeSlice
			{
				endTick = Stopwatch.GetTimestamp() + (long)(millis * 10000f)
			};
		}
	}
}
