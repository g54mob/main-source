namespace Noesis
{
	internal struct NullableDouble
	{
		private bool _hasValue;

		private double _value;

		public bool HasValue => false;

		public double Value => 0.0;

		public NullableDouble(double v)
		{
			_hasValue = false;
			_value = 0.0;
		}

		public static explicit operator double(NullableDouble n)
		{
			return 0.0;
		}

		public static implicit operator NullableDouble(double v)
		{
			return default(NullableDouble);
		}

		public static implicit operator double?(NullableDouble n)
		{
			return null;
		}

		public static implicit operator NullableDouble(double? n)
		{
			return default(NullableDouble);
		}

		public static bool operator ==(NullableDouble n, double v)
		{
			return false;
		}

		public static bool operator !=(NullableDouble n, double v)
		{
			return false;
		}

		public static bool operator ==(double v, NullableDouble n)
		{
			return false;
		}

		public static bool operator !=(double v, NullableDouble n)
		{
			return false;
		}

		public static bool operator ==(NullableDouble n0, NullableDouble n1)
		{
			return false;
		}

		public static bool operator !=(NullableDouble n0, NullableDouble n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableDouble n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
