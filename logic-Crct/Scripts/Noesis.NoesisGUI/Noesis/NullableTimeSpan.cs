using System;

namespace Noesis
{
	internal struct NullableTimeSpan
	{
		private bool _hasValue;

		private TimeSpanStruct _value;

		public bool HasValue => false;

		public TimeSpan Value => default(TimeSpan);

		public NullableTimeSpan(TimeSpan v)
		{
			_hasValue = false;
			_value = default(TimeSpanStruct);
		}

		public static explicit operator TimeSpan(NullableTimeSpan n)
		{
			return default(TimeSpan);
		}

		public static implicit operator NullableTimeSpan(TimeSpan v)
		{
			return default(NullableTimeSpan);
		}

		public static implicit operator TimeSpan?(NullableTimeSpan n)
		{
			return null;
		}

		public static implicit operator NullableTimeSpan(TimeSpan? n)
		{
			return default(NullableTimeSpan);
		}

		public static bool operator ==(NullableTimeSpan n, TimeSpan v)
		{
			return false;
		}

		public static bool operator !=(NullableTimeSpan n, TimeSpan v)
		{
			return false;
		}

		public static bool operator ==(TimeSpan v, NullableTimeSpan n)
		{
			return false;
		}

		public static bool operator !=(TimeSpan v, NullableTimeSpan n)
		{
			return false;
		}

		public static bool operator ==(NullableTimeSpan n0, NullableTimeSpan n1)
		{
			return false;
		}

		public static bool operator !=(NullableTimeSpan n0, NullableTimeSpan n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableTimeSpan n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
