namespace Polygon2DTriangulation
{
	public class Rect2D
	{
		private double mMinX;

		private double mMaxX;

		private double mMinY;

		private double mMaxY;

		public double MinX
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double MaxX
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double MinY
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double MaxY
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Left
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Right
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Top
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Bottom
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Width => 0.0;

		public double Height => 0.0;

		public bool Empty => false;

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Rect2D r)
		{
			return false;
		}

		public bool Equals(Rect2D r, double epsilon)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void Set(double xmin, double xmax, double ymin, double ymax)
		{
		}

		public void Set(Rect2D b)
		{
		}

		public void SetSize(double w, double h)
		{
		}

		public bool Contains(double x, double y)
		{
			return false;
		}

		public bool Contains(Point2D p)
		{
			return false;
		}

		public bool Contains(Rect2D r)
		{
			return false;
		}

		public bool ContainsInclusive(double x, double y)
		{
			return false;
		}

		public bool ContainsInclusive(double x, double y, double epsilon)
		{
			return false;
		}

		public bool ContainsInclusive(Point2D p)
		{
			return false;
		}

		public bool ContainsInclusive(Point2D p, double epsilon)
		{
			return false;
		}

		public bool ContainsInclusive(Rect2D r)
		{
			return false;
		}

		public bool ContainsInclusive(Rect2D r, double epsilon)
		{
			return false;
		}

		public bool Intersects(Rect2D r)
		{
			return false;
		}

		public Point2D GetCenter()
		{
			return null;
		}

		public bool IsNormalized()
		{
			return false;
		}

		public void Normalize()
		{
		}

		public void AddPoint(Point2D p)
		{
		}

		public void Inflate(double w, double h)
		{
		}

		public void Inflate(double left, double top, double right, double bottom)
		{
		}

		public void Offset(double w, double h)
		{
		}

		public void SetPosition(double x, double y)
		{
		}

		public bool Intersection(Rect2D r1, Rect2D r2)
		{
			return false;
		}

		public void Union(Rect2D r1, Rect2D r2)
		{
		}
	}
}
