namespace Pathfinding.Clipper2Lib
{
	public struct PointD
	{
		public double x;

		public double y;

		public PointD(PointD pt)
		{
			x = 0.0;
			y = 0.0;
		}

		public PointD(Point64 pt)
		{
			x = 0.0;
			y = 0.0;
		}

		public PointD(PointD pt, double scale)
		{
			x = 0.0;
			y = 0.0;
		}

		public PointD(Point64 pt, double scale)
		{
			x = 0.0;
			y = 0.0;
		}

		public PointD(long x, long y)
		{
			this.x = 0.0;
			this.y = 0.0;
		}

		public PointD(double x, double y)
		{
			this.x = 0.0;
			this.y = 0.0;
		}

		public readonly string ToString(int precision = 2)
		{
			return null;
		}

		public static bool operator ==(PointD lhs, PointD rhs)
		{
			return false;
		}

		public static bool operator !=(PointD lhs, PointD rhs)
		{
			return false;
		}

		public override readonly bool Equals(object? obj)
		{
			return false;
		}

		public void Negate()
		{
		}

		public override readonly int GetHashCode()
		{
			return 0;
		}
	}
}
