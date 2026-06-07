namespace Noesis
{
	internal struct NullableDuration
	{
		private bool _hasValue;

		private Duration _value;

		public bool HasValue => false;

		public Duration Value => default(Duration);

		public NullableDuration(Duration v)
		{
			_hasValue = false;
			_value = default(Duration);
		}

		public static explicit operator Duration(NullableDuration n)
		{
			return default(Duration);
		}

		public static implicit operator NullableDuration(Duration v)
		{
			return default(NullableDuration);
		}

		public static implicit operator Duration?(NullableDuration n)
		{
			return null;
		}

		public static implicit operator NullableDuration(Duration? n)
		{
			return default(NullableDuration);
		}

		public static bool operator ==(NullableDuration n, Duration v)
		{
			return false;
		}

		public static bool operator !=(NullableDuration n, Duration v)
		{
			return false;
		}

		public static bool operator ==(Duration v, NullableDuration n)
		{
			return false;
		}

		public static bool operator !=(Duration v, NullableDuration n)
		{
			return false;
		}

		public static bool operator ==(NullableDuration n0, NullableDuration n1)
		{
			return false;
		}

		public static bool operator !=(NullableDuration n0, NullableDuration n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableDuration n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
