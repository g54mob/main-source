using System;

namespace Rewired.Libraries.SharpDX
{
	internal struct Point : IEquatable<Point>
	{
		public static readonly Point Zero = new Point(0, 0);

		public int X;

		public int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public bool Equals(Point other)
		{
			if (other.X == X)
			{
				return other.Y == Y;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (obj.GetType() != typeof(Point))
			{
				return false;
			}
			return Equals((Point)obj);
		}

		public override int GetHashCode()
		{
			return (X * 397) ^ Y;
		}

		public static bool operator ==(Point left, Point right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Point left, Point right)
		{
			return !left.Equals(right);
		}

		public override string ToString()
		{
			return string.Format("({0},{1})", X, Y);
		}
	}
}
