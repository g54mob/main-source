namespace Noesis
{
	internal struct NullablePoint
	{
		private bool _hasValue;

		private Point _value;

		public bool HasValue => false;

		public Point Value => default(Point);

		public NullablePoint(Point v)
		{
			_hasValue = false;
			_value = default(Point);
		}

		public static explicit operator Point(NullablePoint n)
		{
			return default(Point);
		}

		public static implicit operator NullablePoint(Point v)
		{
			return default(NullablePoint);
		}

		public static implicit operator Point?(NullablePoint n)
		{
			return null;
		}

		public static implicit operator NullablePoint(Point? n)
		{
			return default(NullablePoint);
		}

		public static bool operator ==(NullablePoint n, Point v)
		{
			return false;
		}

		public static bool operator !=(NullablePoint n, Point v)
		{
			return false;
		}

		public static bool operator ==(Point v, NullablePoint n)
		{
			return false;
		}

		public static bool operator !=(Point v, NullablePoint n)
		{
			return false;
		}

		public static bool operator ==(NullablePoint n0, NullablePoint n1)
		{
			return false;
		}

		public static bool operator !=(NullablePoint n0, NullablePoint n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullablePoint n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
