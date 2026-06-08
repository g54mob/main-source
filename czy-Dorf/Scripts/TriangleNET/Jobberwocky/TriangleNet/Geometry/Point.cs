using System;

namespace Jobberwocky.TriangleNet.Geometry
{
	public class Point : IComparable<Point>, IEquatable<Point>
	{
		internal int id;

		internal int label;

		internal double x;

		internal double y;

		internal double z;

		public int ID => id;

		public double X => x;

		public double Y => y;

		public double Z
		{
			get
			{
				return z;
			}
			set
			{
				z = value;
			}
		}

		public Point()
			: this(0.0, 0.0, 0)
		{
		}

		public Point(double x, double y)
			: this(x, y, 0)
		{
		}

		public Point(double x, double y, int label)
		{
			this.x = x;
			this.y = y;
			this.label = label;
		}

		public static bool operator ==(Point a, Point b)
		{
			if ((object)a == b)
			{
				return true;
			}
			if ((object)a == null || (object)b == null)
			{
				return false;
			}
			return a.Equals(b);
		}

		public static bool operator !=(Point a, Point b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is Point point))
			{
				return false;
			}
			return x == point.x && y == point.y;
		}

		public bool Equals(Point p)
		{
			if ((object)p == null)
			{
				return false;
			}
			return x == p.x && y == p.y;
		}

		public int CompareTo(Point other)
		{
			if (x == other.x && y == other.y)
			{
				return 0;
			}
			return (!(x < other.x) && (x != other.x || !(y < other.y))) ? 1 : (-1);
		}

		public override int GetHashCode()
		{
			int num = 19;
			num = num * 31 + x.GetHashCode();
			return num * 31 + y.GetHashCode();
		}
	}
}
