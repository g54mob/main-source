namespace Noesis
{
	internal struct NullableCornerRadius
	{
		private bool _hasValue;

		private CornerRadius _value;

		public bool HasValue => false;

		public CornerRadius Value => default(CornerRadius);

		public NullableCornerRadius(CornerRadius v)
		{
			_hasValue = false;
			_value = default(CornerRadius);
		}

		public static explicit operator CornerRadius(NullableCornerRadius n)
		{
			return default(CornerRadius);
		}

		public static implicit operator NullableCornerRadius(CornerRadius v)
		{
			return default(NullableCornerRadius);
		}

		public static implicit operator CornerRadius?(NullableCornerRadius n)
		{
			return null;
		}

		public static implicit operator NullableCornerRadius(CornerRadius? n)
		{
			return default(NullableCornerRadius);
		}

		public static bool operator ==(NullableCornerRadius n, CornerRadius v)
		{
			return false;
		}

		public static bool operator !=(NullableCornerRadius n, CornerRadius v)
		{
			return false;
		}

		public static bool operator ==(CornerRadius v, NullableCornerRadius n)
		{
			return false;
		}

		public static bool operator !=(CornerRadius v, NullableCornerRadius n)
		{
			return false;
		}

		public static bool operator ==(NullableCornerRadius n0, NullableCornerRadius n1)
		{
			return false;
		}

		public static bool operator !=(NullableCornerRadius n0, NullableCornerRadius n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableCornerRadius n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
