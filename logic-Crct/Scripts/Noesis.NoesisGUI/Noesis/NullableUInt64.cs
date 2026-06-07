namespace Noesis
{
	internal struct NullableUInt64
	{
		private bool _hasValue;

		private ulong _value;

		public bool HasValue => false;

		public ulong Value => 0uL;

		public NullableUInt64(ulong v)
		{
			_hasValue = false;
			_value = 0uL;
		}

		public static explicit operator ulong(NullableUInt64 n)
		{
			return 0uL;
		}

		public static implicit operator NullableUInt64(ulong v)
		{
			return default(NullableUInt64);
		}

		public static implicit operator ulong?(NullableUInt64 n)
		{
			return null;
		}

		public static implicit operator NullableUInt64(ulong? n)
		{
			return default(NullableUInt64);
		}

		public static bool operator ==(NullableUInt64 n, ulong v)
		{
			return false;
		}

		public static bool operator !=(NullableUInt64 n, ulong v)
		{
			return false;
		}

		public static bool operator ==(ulong v, NullableUInt64 n)
		{
			return false;
		}

		public static bool operator !=(ulong v, NullableUInt64 n)
		{
			return false;
		}

		public static bool operator ==(NullableUInt64 n0, NullableUInt64 n1)
		{
			return false;
		}

		public static bool operator !=(NullableUInt64 n0, NullableUInt64 n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableUInt64 n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
