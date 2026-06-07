namespace Noesis
{
	internal struct NullableKeyTime
	{
		private bool _hasValue;

		private KeyTime _value;

		public bool HasValue => false;

		public KeyTime Value => default(KeyTime);

		public NullableKeyTime(KeyTime v)
		{
			_hasValue = false;
			_value = default(KeyTime);
		}

		public static explicit operator KeyTime(NullableKeyTime n)
		{
			return default(KeyTime);
		}

		public static implicit operator NullableKeyTime(KeyTime v)
		{
			return default(NullableKeyTime);
		}

		public static implicit operator KeyTime?(NullableKeyTime n)
		{
			return null;
		}

		public static implicit operator NullableKeyTime(KeyTime? n)
		{
			return default(NullableKeyTime);
		}

		public static bool operator ==(NullableKeyTime n, KeyTime v)
		{
			return false;
		}

		public static bool operator !=(NullableKeyTime n, KeyTime v)
		{
			return false;
		}

		public static bool operator ==(KeyTime v, NullableKeyTime n)
		{
			return false;
		}

		public static bool operator !=(KeyTime v, NullableKeyTime n)
		{
			return false;
		}

		public static bool operator ==(NullableKeyTime n0, NullableKeyTime n1)
		{
			return false;
		}

		public static bool operator !=(NullableKeyTime n0, NullableKeyTime n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableKeyTime n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
