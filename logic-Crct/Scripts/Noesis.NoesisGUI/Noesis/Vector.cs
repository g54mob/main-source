namespace Noesis
{
	public struct Vector
	{
		private float _x;

		private float _y;

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

		public float Length => 0f;

		public float LengthSquared => 0f;

		public Vector(float x, float y)
		{
			_x = 0f;
			_y = 0f;
		}

		public void Normalize()
		{
		}

		public static float CrossProduct(Vector v0, Vector v1)
		{
			return 0f;
		}

		public static float AngleBetween(Vector v0, Vector v1)
		{
			return 0f;
		}

		public static Vector operator -(Vector vector)
		{
			return default(Vector);
		}

		public void Negate()
		{
		}

		public static Vector operator +(Vector v0, Vector v1)
		{
			return default(Vector);
		}

		public static Vector Add(Vector v0, Vector v1)
		{
			return default(Vector);
		}

		public static Vector operator -(Vector v0, Vector v1)
		{
			return default(Vector);
		}

		public static Vector Subtract(Vector v0, Vector v1)
		{
			return default(Vector);
		}

		public static Point operator +(Vector vector, Point point)
		{
			return default(Point);
		}

		public static Point Add(Vector vector, Point point)
		{
			return default(Point);
		}

		public static Vector operator *(Vector vector, float scalar)
		{
			return default(Vector);
		}

		public static Vector Multiply(Vector vector, float scalar)
		{
			return default(Vector);
		}

		public static Vector operator *(float scalar, Vector vector)
		{
			return default(Vector);
		}

		public static Vector Multiply(float scalar, Vector vector)
		{
			return default(Vector);
		}

		public static Vector operator /(Vector vector, float scalar)
		{
			return default(Vector);
		}

		public static Vector Divide(Vector vector, float scalar)
		{
			return default(Vector);
		}

		public static float operator *(Vector v0, Vector v1)
		{
			return 0f;
		}

		public static float Multiply(Vector v0, Vector v1)
		{
			return 0f;
		}

		public static float Determinant(Vector v0, Vector v1)
		{
			return 0f;
		}

		public static explicit operator Size(Vector vector)
		{
			return default(Size);
		}

		public static explicit operator Point(Vector vector)
		{
			return default(Point);
		}

		public static bool operator ==(Vector v0, Vector v1)
		{
			return false;
		}

		public static bool operator !=(Vector v0, Vector v1)
		{
			return false;
		}

		public static bool Equals(Vector v0, Vector v1)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public bool Equals(Vector value)
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

		public static Vector Parse(string str)
		{
			return default(Vector);
		}
	}
}
