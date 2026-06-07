using System;

namespace Poly2Tri.Utility
{
	public struct Rect2D
	{
		private readonly double _minX;

		private readonly double _maxX;

		private readonly double _minY;

		private readonly double _maxY;

		public double MinX
		{
			get
			{
				return _minX;
			}
		}

		public double MaxX
		{
			get
			{
				return _maxX;
			}
		}

		public double MinY
		{
			get
			{
				return _minY;
			}
		}

		public double MaxY
		{
			get
			{
				return _maxY;
			}
		}

		public double Left
		{
			get
			{
				return _minX;
			}
		}

		public double Right
		{
			get
			{
				return _maxX;
			}
		}

		public double Top
		{
			get
			{
				return _maxY;
			}
		}

		public double Bottom
		{
			get
			{
				return _minY;
			}
		}

		public double Width
		{
			get
			{
				return Right - Left;
			}
		}

		public double Height
		{
			get
			{
				return Top - Bottom;
			}
		}

		public bool IsEmpty
		{
			get
			{
				if (!(Math.Abs(Width) < 1.401298464324817E-45))
				{
					return Math.Abs(Height) < 1.401298464324817E-45;
				}
				return true;
			}
		}

		private Rect2D(double minX, double maxX, double minY, double maxY)
		{
			_minX = minX;
			_maxX = maxX;
			_minY = minY;
			_maxY = maxY;
		}

		public override int GetHashCode()
		{
			return 54734431 * _minX.GetHashCode() + 1122547711 * _minY.GetHashCode() + 1097393683 * _maxX.GetHashCode() + 1198754321 * _maxY.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Rect2D)
			{
				return Equals((Rect2D)obj);
			}
			return false;
		}

		private bool Equals(Rect2D r, double epsilon = 1E-12)
		{
			if (MathUtil.AreValuesEqual(MinX, r.MinX, epsilon) && MathUtil.AreValuesEqual(MaxX, r.MaxX, epsilon) && MathUtil.AreValuesEqual(MinY, r.MinY, epsilon))
			{
				return MathUtil.AreValuesEqual(MaxY, r.MaxY, epsilon);
			}
			return false;
		}

		public bool Intersects(Rect2D r)
		{
			if (Right > r.Left && Left < r.Right && Bottom < r.Top)
			{
				return Top > r.Bottom;
			}
			return false;
		}

		public Rect2D AddPoint(Point2D p)
		{
			return new Rect2D(Math.Min(MinX, p.X), Math.Max(MaxX, p.X), Math.Min(MinY, p.Y), Math.Max(MaxY, p.Y));
		}
	}
}
