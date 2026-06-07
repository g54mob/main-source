using System;

namespace Poly2Tri.Utility
{
	public class Point2D : IComparable<Point2D>
	{
		private double _x;

		private double _y;

		public virtual double X
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}
		}

		public virtual double Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		public float Xf
		{
			get
			{
				return (float)X;
			}
		}

		public float Yf
		{
			get
			{
				return (float)Y;
			}
		}

		public Point2D()
		{
			_x = 0.0;
			_y = 0.0;
		}

		public Point2D(double x, double y)
		{
			_x = x;
			_y = y;
		}

		public override string ToString()
		{
			return string.Format("[{0},{1}]", X, Y);
		}

		public override int GetHashCode()
		{
			return 378163771 * _x.GetHashCode() + 113137337 * _y.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			Point2D point2D = obj as Point2D;
			if (point2D != null)
			{
				return Equals(point2D);
			}
			return false;
		}

		public bool Equals(Point2D p, double epsilon = 0.0)
		{
			if (p == null || !MathUtil.AreValuesEqual(X, p.X, epsilon) || !MathUtil.AreValuesEqual(Y, p.Y, epsilon))
			{
				return false;
			}
			return true;
		}

		public int CompareTo(Point2D other)
		{
			if (Y < other.Y)
			{
				return -1;
			}
			if (Y > other.Y)
			{
				return 1;
			}
			if (X < other.X)
			{
				return -1;
			}
			if (X > other.X)
			{
				return 1;
			}
			return 0;
		}

		public virtual void Set(double x, double y)
		{
			X = x;
			Y = y;
		}

		public void Subtract(Point2D p)
		{
			X -= p.X;
			Y -= p.Y;
		}

		private void Multiply(double scalar)
		{
			X *= scalar;
			Y *= scalar;
		}

		public double Magnitude()
		{
			return Math.Sqrt(MagnitudeSquared());
		}

		public double MagnitudeSquared()
		{
			return X * X + Y * Y;
		}

		private double MagnitudeReciprocal()
		{
			return 1.0 / Magnitude();
		}

		public void Normalize()
		{
			Multiply(MagnitudeReciprocal());
		}

		public double Dot(Point2D p)
		{
			return X * p.X + Y * p.Y;
		}

		public double Cross(Point2D p)
		{
			return X * p.Y - Y * p.X;
		}

		public static double Dot(Point2D lhs, Point2D rhs)
		{
			return lhs.X * rhs.X + lhs.Y * rhs.Y;
		}

		public static double Cross(Point2D lhs, Point2D rhs)
		{
			return lhs.X * rhs.Y - lhs.Y * rhs.X;
		}

		public static Point2D Perpendicular(Point2D lhs, double scalar)
		{
			return new Point2D(lhs.Y * scalar, lhs.X * (0.0 - scalar));
		}

		public static Point2D Perpendicular(double scalar, Point2D rhs)
		{
			return new Point2D((0.0 - scalar) * rhs.Y, scalar * rhs.X);
		}

		public static Point2D operator +(Point2D lhs, Point2D rhs)
		{
			return new Point2D(lhs.X + rhs.X, lhs.Y + rhs.Y);
		}

		public static Point2D operator +(Point2D lhs, double scalar)
		{
			return new Point2D(lhs.X + scalar, lhs.Y + scalar);
		}

		public static Point2D operator -(Point2D lhs, Point2D rhs)
		{
			return new Point2D(lhs.X - rhs.X, lhs.Y - rhs.Y);
		}

		public static Point2D operator -(Point2D lhs, double scalar)
		{
			return new Point2D(lhs.X - scalar, lhs.Y - scalar);
		}

		public static Point2D operator *(Point2D lhs, Point2D rhs)
		{
			return new Point2D(lhs.X * rhs.X, lhs.Y * rhs.Y);
		}

		public static Point2D operator *(Point2D lhs, double scalar)
		{
			return new Point2D(lhs.X * scalar, lhs.Y * scalar);
		}

		public static Point2D operator *(double scalar, Point2D rhs)
		{
			return rhs * scalar;
		}

		public static Point2D operator /(Point2D lhs, Point2D rhs)
		{
			return new Point2D(lhs.X / rhs.X, lhs.Y / rhs.Y);
		}

		public static Point2D operator /(Point2D lhs, double scalar)
		{
			return new Point2D(lhs.X / scalar, lhs.Y / scalar);
		}

		public static Point2D operator -(Point2D p)
		{
			return new Point2D(0.0 - p.X, 0.0 - p.Y);
		}

		public static bool operator <(Point2D lhs, Point2D rhs)
		{
			return lhs.CompareTo(rhs) == -1;
		}

		public static bool operator >(Point2D lhs, Point2D rhs)
		{
			return lhs.CompareTo(rhs) == 1;
		}

		public static bool operator <=(Point2D lhs, Point2D rhs)
		{
			return lhs.CompareTo(rhs) <= 0;
		}

		public static bool operator >=(Point2D lhs, Point2D rhs)
		{
			return lhs.CompareTo(rhs) >= 0;
		}
	}
}
