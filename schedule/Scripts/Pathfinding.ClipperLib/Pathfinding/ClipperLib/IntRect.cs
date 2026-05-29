namespace Pathfinding.ClipperLib
{
	public struct IntRect
	{
		public long left;

		public long top;

		public long right;

		public long bottom;

		public IntRect(long l, long t, long r, long b)
		{
			left = 0L;
			top = 0L;
			right = 0L;
			bottom = 0L;
		}

		public IntRect(IntRect ir)
		{
			left = 0L;
			top = 0L;
			right = 0L;
			bottom = 0L;
		}
	}
}
