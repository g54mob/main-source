namespace Noesis
{
	public struct Point
	{
		private float _x;

		private float _y;

		public float this[uint i]
		{
			get
			{
				return 0f;
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

		public Point(float x, float y)
		{
			_x = 0f;
			_y = 0f;
		}

		public void Offset(float offsetX, float offsetY)
		{
		}

		public static Point operator +(Point point, Vector vector)
		{
			return default(Point);
		}

		public static Point Add(Point point, Vector vector)
		{
			return default(Point);
		}

		public static Point operator -(Point point, Vector vector)
		{
			return default(Point);
		}

		public static Point Subtract(Point point, Vector vector)
		{
			return default(Point);
		}

		public static Vector operator -(Point point1, Point point2)
		{
			return default(Vector);
		}

		public static Vector Subtract(Point point1, Point point2)
		{
			return default(Vector);
		}

		public static Point operator *(Point point, Matrix matrix)
		{
			return default(Point);
		}

		public static Point Multiply(Point point, Matrix matrix)
		{
			return default(Point);
		}

		public static explicit operator Size(Point point)
		{
			return default(Size);
		}

		public static explicit operator Vector(Point point)
		{
			return default(Vector);
		}

		public static bool operator ==(Point p0, Point p1)
		{
			return false;
		}

		public static bool operator !=(Point p0, Point p1)
		{
			return false;
		}

		public static bool Equals(Point p0, Point p1)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public bool Equals(Point value)
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

		public static Point Parse(string str)
		{
			return default(Point);
		}

		public static bool TryParse(string str, out Point result)
		{
			result = default(Point);
			return false;
		}
	}
}
