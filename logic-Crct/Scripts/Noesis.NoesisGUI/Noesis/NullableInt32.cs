namespace Noesis
{
	internal struct NullableInt32
	{
		private bool _hasValue;

		private int _value;

		public bool HasValue => false;

		public int Value => 0;

		public NullableInt32(int v)
		{
			_hasValue = false;
			_value = 0;
		}

		public static explicit operator int(NullableInt32 n)
		{
			return 0;
		}

		public static implicit operator NullableInt32(int v)
		{
			return default(NullableInt32);
		}

		public static implicit operator int?(NullableInt32 n)
		{
			return null;
		}

		public static implicit operator NullableInt32(int? n)
		{
			return default(NullableInt32);
		}

		public static bool operator ==(NullableInt32 n, int v)
		{
			return false;
		}

		public static bool operator !=(NullableInt32 n, int v)
		{
			return false;
		}

		public static bool operator ==(int v, NullableInt32 n)
		{
			return false;
		}

		public static bool operator !=(int v, NullableInt32 n)
		{
			return false;
		}

		public static bool operator ==(NullableInt32 n0, NullableInt32 n1)
		{
			return false;
		}

		public static bool operator !=(NullableInt32 n0, NullableInt32 n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableInt32 n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
