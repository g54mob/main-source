namespace Noesis
{
	internal struct NullableUInt16
	{
		private bool _hasValue;

		private ushort _value;

		public bool HasValue => false;

		public ushort Value => 0;

		public NullableUInt16(ushort v)
		{
			_hasValue = false;
			_value = 0;
		}

		public static explicit operator ushort(NullableUInt16 n)
		{
			return 0;
		}

		public static implicit operator NullableUInt16(ushort v)
		{
			return default(NullableUInt16);
		}

		public static implicit operator ushort?(NullableUInt16 n)
		{
			return null;
		}

		public static implicit operator NullableUInt16(ushort? n)
		{
			return default(NullableUInt16);
		}

		public static bool operator ==(NullableUInt16 n, ushort v)
		{
			return false;
		}

		public static bool operator !=(NullableUInt16 n, ushort v)
		{
			return false;
		}

		public static bool operator ==(ushort v, NullableUInt16 n)
		{
			return false;
		}

		public static bool operator !=(ushort v, NullableUInt16 n)
		{
			return false;
		}

		public static bool operator ==(NullableUInt16 n0, NullableUInt16 n1)
		{
			return false;
		}

		public static bool operator !=(NullableUInt16 n0, NullableUInt16 n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableUInt16 n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
