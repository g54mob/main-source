namespace Pathfinding.Jobs
{
	public struct TimeSlice
	{
		public long endTick;

		public static readonly TimeSlice Infinite;

		public bool isInfinite => false;

		public bool expired => false;

		public static TimeSlice MillisFromNow(float millis)
		{
			return default(TimeSlice);
		}
	}
}
