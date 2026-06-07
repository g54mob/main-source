namespace Noesis
{
	internal struct NullableBool
	{
		private bool _hasValue;

		private bool _value;

		public bool HasValue => false;

		public bool Value => false;

		public NullableBool(bool v)
		{
			_hasValue = false;
			_value = false;
		}

		public static explicit operator bool(NullableBool n)
		{
			return false;
		}

		public static implicit operator NullableBool(bool v)
		{
			return default(NullableBool);
		}

		public static implicit operator bool?(NullableBool n)
		{
			return null;
		}

		public static implicit operator NullableBool(bool? n)
		{
			return default(NullableBool);
		}

		public static bool operator ==(NullableBool n, bool v)
		{
			return false;
		}

		public static bool operator !=(NullableBool n, bool v)
		{
			return false;
		}

		public static bool operator ==(bool v, NullableBool n)
		{
			return false;
		}

		public static bool operator !=(bool v, NullableBool n)
		{
			return false;
		}

		public static bool operator ==(NullableBool n0, NullableBool n1)
		{
			return false;
		}

		public static bool operator !=(NullableBool n0, NullableBool n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableBool n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
