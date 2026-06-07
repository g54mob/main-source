namespace Pathfinding.Clipper2Lib
{
	public struct Point64
	{
		public long X;

		public long Y;

		public Point64(Point64 pt)
		{
			X = 0L;
			Y = 0L;
		}

		public Point64(long x, long y)
		{
			X = 0L;
			Y = 0L;
		}

		public Point64(double x, double y)
		{
			X = 0L;
			Y = 0L;
		}

		public Point64(PointD pt)
		{
			X = 0L;
			Y = 0L;
		}

		public Point64(Point64 pt, double scale)
		{
			X = 0L;
			Y = 0L;
		}

		public Point64(PointD pt, double scale)
		{
			X = 0L;
			Y = 0L;
		}

		public static bool operator ==(Point64 lhs, Point64 rhs)
		{
			return false;
		}

		public static bool operator !=(Point64 lhs, Point64 rhs)
		{
			return false;
		}

		public static Point64 operator +(Point64 lhs, Point64 rhs)
		{
			return default(Point64);
		}

		public static Point64 operator -(Point64 lhs, Point64 rhs)
		{
			return default(Point64);
		}

		public override readonly string ToString()
		{
			return null;
		}

		public override readonly bool Equals(object? obj)
		{
			return false;
		}

		public override readonly int GetHashCode()
		{
			return 0;
		}
	}
}
