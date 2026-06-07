using System;

namespace Polygon2DTriangulation
{
	public class Point2D : IComparable<Point2D>
	{
		protected double mX;

		protected double mY;

		public virtual double X
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public virtual double Y
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public float Xf => 0f;

		public float Yf => 0f;

		public Point2D()
		{
		}

		public Point2D(double x, double y)
		{
		}

		public Point2D(Point2D p)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Point2D p)
		{
			return false;
		}

		public bool Equals(Point2D p, double epsilon)
		{
			return false;
		}

		public int CompareTo(Point2D other)
		{
			return 0;
		}

		public virtual void Set(double x, double y)
		{
		}

		public virtual void Set(Point2D p)
		{
		}

		public void Add(Point2D p)
		{
		}

		public void Add(double scalar)
		{
		}

		public void Subtract(Point2D p)
		{
		}

		public void Subtract(double scalar)
		{
		}

		public void Multiply(Point2D p)
		{
		}

		public void Multiply(double scalar)
		{
		}

		public void Divide(Point2D p)
		{
		}

		public void Divide(double scalar)
		{
		}

		public void Negate()
		{
		}

		public double Magnitude()
		{
			return 0.0;
		}

		public double MagnitudeSquared()
		{
			return 0.0;
		}

		public double MagnitudeReciprocal()
		{
			return 0.0;
		}

		public void Normalize()
		{
		}

		public double Dot(Point2D p)
		{
			return 0.0;
		}

		public double Cross(Point2D p)
		{
			return 0.0;
		}

		public void Clamp(Point2D low, Point2D high)
		{
		}

		public void Abs()
		{
		}

		public void Reciprocal()
		{
		}

		public void Translate(Point2D vector)
		{
		}

		public void Translate(double x, double y)
		{
		}

		public void Scale(Point2D vector)
		{
		}

		public void Scale(double scalar)
		{
		}

		public void Scale(double x, double y)
		{
		}

		public void Rotate(double radians)
		{
		}

		public void RotateDegrees(double degrees)
		{
		}

		public static double Dot(Point2D lhs, Point2D rhs)
		{
			return 0.0;
		}

		public static double Cross(Point2D lhs, Point2D rhs)
		{
			return 0.0;
		}

		public static Point2D Clamp(Point2D a, Point2D low, Point2D high)
		{
			return null;
		}

		public static Point2D Min(Point2D a, Point2D b)
		{
			return null;
		}

		public static Point2D Max(Point2D a, Point2D b)
		{
			return null;
		}

		public static Point2D Abs(Point2D a)
		{
			return null;
		}

		public static Point2D Reciprocal(Point2D a)
		{
			return null;
		}

		public static Point2D Perpendicular(Point2D lhs, double scalar)
		{
			return null;
		}

		public static Point2D Perpendicular(double scalar, Point2D rhs)
		{
			return null;
		}

		public static Point2D operator +(Point2D lhs, Point2D rhs)
		{
			return null;
		}

		public static Point2D operator +(Point2D lhs, double scalar)
		{
			return null;
		}

		public static Point2D operator -(Point2D lhs, Point2D rhs)
		{
			return null;
		}

		public static Point2D operator -(Point2D lhs, double scalar)
		{
			return null;
		}

		public static Point2D operator *(Point2D lhs, Point2D rhs)
		{
			return null;
		}

		public static Point2D operator *(Point2D lhs, double scalar)
		{
			return null;
		}

		public static Point2D operator *(double scalar, Point2D lhs)
		{
			return null;
		}

		public static Point2D operator /(Point2D lhs, Point2D rhs)
		{
			return null;
		}

		public static Point2D operator /(Point2D lhs, double scalar)
		{
			return null;
		}

		public static Point2D operator -(Point2D p)
		{
			return null;
		}

		public static bool operator <(Point2D lhs, Point2D rhs)
		{
			return false;
		}

		public static bool operator >(Point2D lhs, Point2D rhs)
		{
			return false;
		}

		public static bool operator <=(Point2D lhs, Point2D rhs)
		{
			return false;
		}

		public static bool operator >=(Point2D lhs, Point2D rhs)
		{
			return false;
		}
	}
}
