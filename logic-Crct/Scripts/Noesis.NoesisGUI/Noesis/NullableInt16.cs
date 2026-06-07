namespace Noesis
{
	internal struct NullableInt16
	{
		private bool _hasValue;

		private short _value;

		public bool HasValue => false;

		public short Value => 0;

		public NullableInt16(short v)
		{
			_hasValue = false;
			_value = 0;
		}

		public static explicit operator short(NullableInt16 n)
		{
			return 0;
		}

		public static implicit operator NullableInt16(short v)
		{
			return default(NullableInt16);
		}

		public static implicit operator short?(NullableInt16 n)
		{
			return null;
		}

		public static implicit operator NullableInt16(short? n)
		{
			return default(NullableInt16);
		}

		public static bool operator ==(NullableInt16 n, short v)
		{
			return false;
		}

		public static bool operator !=(NullableInt16 n, short v)
		{
			return false;
		}

		public static bool operator ==(short v, NullableInt16 n)
		{
			return false;
		}

		public static bool operator !=(short v, NullableInt16 n)
		{
			return false;
		}

		public static bool operator ==(NullableInt16 n0, NullableInt16 n1)
		{
			return false;
		}

		public static bool operator !=(NullableInt16 n0, NullableInt16 n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableInt16 n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
