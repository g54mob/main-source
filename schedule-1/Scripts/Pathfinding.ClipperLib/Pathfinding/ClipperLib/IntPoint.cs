namespace Pathfinding.ClipperLib
{
	public struct IntPoint
	{
		public long X;

		public long Y;

		public IntPoint(long X, long Y)
		{
			this.X = 0L;
			this.Y = 0L;
		}

		public IntPoint(double x, double y)
		{
			X = 0L;
			Y = 0L;
		}

		public IntPoint(IntPoint pt)
		{
			X = 0L;
			Y = 0L;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(IntPoint a, IntPoint b)
		{
			return false;
		}

		public static bool operator !=(IntPoint a, IntPoint b)
		{
			return false;
		}
	}
}
