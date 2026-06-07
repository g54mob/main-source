namespace PolygonIntersection
{
	public struct Vector
	{
		public float X;

		public float Y;

		public float Magnitude => 0f;

		public static Vector FromPoint(Point p)
		{
			return default(Vector);
		}

		public static Vector FromPoint(float x, float y)
		{
			return default(Vector);
		}

		public Vector(float x, float y)
		{
			X = 0f;
			Y = 0f;
		}

		public void Normalize()
		{
		}

		public Vector GetNormalized()
		{
			return default(Vector);
		}

		public float DotProduct(Vector vector)
		{
			return 0f;
		}

		public float DistanceTo(Vector vector)
		{
			return 0f;
		}

		public static implicit operator Point(Vector p)
		{
			return default(Point);
		}

		public static Vector operator +(Vector a, Vector b)
		{
			return default(Vector);
		}

		public static Vector operator -(Vector a)
		{
			return default(Vector);
		}

		public static Vector operator -(Vector a, Vector b)
		{
			return default(Vector);
		}

		public static Vector operator *(Vector a, float b)
		{
			return default(Vector);
		}

		public static Vector operator *(Vector a, int b)
		{
			return default(Vector);
		}

		public static Vector operator *(Vector a, double b)
		{
			return default(Vector);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Vector v)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(Vector a, Vector b)
		{
			return false;
		}

		public static bool operator !=(Vector a, Vector b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(bool rounded)
		{
			return null;
		}
	}
}
