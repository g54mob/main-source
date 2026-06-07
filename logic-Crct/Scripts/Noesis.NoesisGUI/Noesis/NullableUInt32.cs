namespace Noesis
{
	internal struct NullableUInt32
	{
		private bool _hasValue;

		private uint _value;

		public bool HasValue => false;

		public uint Value => 0u;

		public NullableUInt32(uint v)
		{
			_hasValue = false;
			_value = 0u;
		}

		public static explicit operator uint(NullableUInt32 n)
		{
			return 0u;
		}

		public static implicit operator NullableUInt32(uint v)
		{
			return default(NullableUInt32);
		}

		public static implicit operator uint?(NullableUInt32 n)
		{
			return null;
		}

		public static implicit operator NullableUInt32(uint? n)
		{
			return default(NullableUInt32);
		}

		public static bool operator ==(NullableUInt32 n, uint v)
		{
			return false;
		}

		public static bool operator !=(NullableUInt32 n, uint v)
		{
			return false;
		}

		public static bool operator ==(uint v, NullableUInt32 n)
		{
			return false;
		}

		public static bool operator !=(uint v, NullableUInt32 n)
		{
			return false;
		}

		public static bool operator ==(NullableUInt32 n0, NullableUInt32 n1)
		{
			return false;
		}

		public static bool operator !=(NullableUInt32 n0, NullableUInt32 n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableUInt32 n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
