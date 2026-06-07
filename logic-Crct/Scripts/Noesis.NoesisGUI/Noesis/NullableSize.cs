namespace Noesis
{
	internal struct NullableSize
	{
		private bool _hasValue;

		private Size _value;

		public bool HasValue => false;

		public Size Value => default(Size);

		public NullableSize(Size v)
		{
			_hasValue = false;
			_value = default(Size);
		}

		public static explicit operator Size(NullableSize n)
		{
			return default(Size);
		}

		public static implicit operator NullableSize(Size v)
		{
			return default(NullableSize);
		}

		public static implicit operator Size?(NullableSize n)
		{
			return null;
		}

		public static implicit operator NullableSize(Size? n)
		{
			return default(NullableSize);
		}

		public static bool operator ==(NullableSize n, Size v)
		{
			return false;
		}

		public static bool operator !=(NullableSize n, Size v)
		{
			return false;
		}

		public static bool operator ==(Size v, NullableSize n)
		{
			return false;
		}

		public static bool operator !=(Size v, NullableSize n)
		{
			return false;
		}

		public static bool operator ==(NullableSize n0, NullableSize n1)
		{
			return false;
		}

		public static bool operator !=(NullableSize n0, NullableSize n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableSize n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
