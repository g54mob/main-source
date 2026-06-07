namespace Noesis
{
	internal struct NullableInt64
	{
		private bool _hasValue;

		private long _value;

		public bool HasValue => false;

		public long Value => 0L;

		public NullableInt64(long v)
		{
			_hasValue = false;
			_value = 0L;
		}

		public static explicit operator long(NullableInt64 n)
		{
			return 0L;
		}

		public static implicit operator NullableInt64(long v)
		{
			return default(NullableInt64);
		}

		public static implicit operator long?(NullableInt64 n)
		{
			return null;
		}

		public static implicit operator NullableInt64(long? n)
		{
			return default(NullableInt64);
		}

		public static bool operator ==(NullableInt64 n, long v)
		{
			return false;
		}

		public static bool operator !=(NullableInt64 n, long v)
		{
			return false;
		}

		public static bool operator ==(long v, NullableInt64 n)
		{
			return false;
		}

		public static bool operator !=(long v, NullableInt64 n)
		{
			return false;
		}

		public static bool operator ==(NullableInt64 n0, NullableInt64 n1)
		{
			return false;
		}

		public static bool operator !=(NullableInt64 n0, NullableInt64 n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableInt64 n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
