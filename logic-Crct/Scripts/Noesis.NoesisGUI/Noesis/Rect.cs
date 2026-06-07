namespace Noesis
{
	public struct Rect
	{
		private float _x;

		private float _y;

		private float _width;

		private float _height;

		private static readonly Rect _empty;

		public static Rect Empty => default(Rect);

		public bool IsEmpty => false;

		public Point Location
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Size Size
		{
			get
			{
				return default(Size);
			}
			set
			{
			}
		}

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Left => 0f;

		public float Right => 0f;

		public float Top => 0f;

		public float Bottom => 0f;

		public Point TopLeft => default(Point);

		public Point TopRight => default(Point);

		public Point BottomLeft => default(Point);

		public Point BottomRight => default(Point);

		public Rect(float x, float y, float width, float height)
		{
			_x = 0f;
			_y = 0f;
			_width = 0f;
			_height = 0f;
		}

		public Rect(Point p0, Point p1)
		{
			_x = 0f;
			_y = 0f;
			_width = 0f;
			_height = 0f;
		}

		public Rect(Point p, Vector v)
		{
			_x = 0f;
			_y = 0f;
			_width = 0f;
			_height = 0f;
		}

		public Rect(Size size)
		{
			_x = 0f;
			_y = 0f;
			_width = 0f;
			_height = 0f;
		}

		public Rect(Point location, Size size)
		{
			_x = 0f;
			_y = 0f;
			_width = 0f;
			_height = 0f;
		}

		public bool Contains(float x, float y)
		{
			return false;
		}

		public bool Contains(Point point)
		{
			return false;
		}

		public bool Contains(Rect rect)
		{
			return false;
		}

		public bool IntersectsWith(Rect rect)
		{
			return false;
		}

		public void Intersect(Rect rect)
		{
		}

		public static Rect Intersect(Rect r0, Rect r1)
		{
			return default(Rect);
		}

		public void Union(Rect rect)
		{
		}

		public static Rect Union(Rect r0, Rect r1)
		{
			return default(Rect);
		}

		public void Union(Point point)
		{
		}

		public static Rect Union(Rect rect, Point point)
		{
			return default(Rect);
		}

		public void Offset(float x, float y)
		{
		}

		public void Offset(Vector offset)
		{
		}

		public static Rect Offset(Rect rect, float x, float y)
		{
			return default(Rect);
		}

		public static Rect Offset(Rect rect, Vector offset)
		{
			return default(Rect);
		}

		public void Inflate(float width, float height)
		{
		}

		public void Inflate(Size size)
		{
		}

		public static Rect Inflate(Rect rect, float width, float height)
		{
			return default(Rect);
		}

		public static Rect Inflate(Rect rect, Size size)
		{
			return default(Rect);
		}

		public static Rect Transform(Rect rect, Matrix matrix)
		{
			return default(Rect);
		}

		public void Transform(Matrix matrix)
		{
		}

		public void Transform(Matrix4 matrix)
		{
		}

		public void Scale(float scaleX, float scaleY)
		{
		}

		public static bool operator ==(Rect r0, Rect r1)
		{
			return false;
		}

		public static bool operator !=(Rect r0, Rect r1)
		{
			return false;
		}

		public bool Equals(Rect r0, Rect r1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Rect r)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static Rect Parse(string str)
		{
			return default(Rect);
		}

		private static Rect CreateEmptyRect()
		{
			return default(Rect);
		}

		public static bool TryParse(string str, out Rect result)
		{
			result = default(Rect);
			return false;
		}
	}
}
