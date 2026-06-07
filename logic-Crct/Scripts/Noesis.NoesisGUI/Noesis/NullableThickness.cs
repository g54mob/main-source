namespace Noesis
{
	internal struct NullableThickness
	{
		private bool _hasValue;

		private Thickness _value;

		public bool HasValue => false;

		public Thickness Value => default(Thickness);

		public NullableThickness(Thickness v)
		{
			_hasValue = false;
			_value = default(Thickness);
		}

		public static explicit operator Thickness(NullableThickness n)
		{
			return default(Thickness);
		}

		public static implicit operator NullableThickness(Thickness v)
		{
			return default(NullableThickness);
		}

		public static implicit operator Thickness?(NullableThickness n)
		{
			return null;
		}

		public static implicit operator NullableThickness(Thickness? n)
		{
			return default(NullableThickness);
		}

		public static bool operator ==(NullableThickness n, Thickness v)
		{
			return false;
		}

		public static bool operator !=(NullableThickness n, Thickness v)
		{
			return false;
		}

		public static bool operator ==(Thickness v, NullableThickness n)
		{
			return false;
		}

		public static bool operator !=(Thickness v, NullableThickness n)
		{
			return false;
		}

		public static bool operator ==(NullableThickness n0, NullableThickness n1)
		{
			return false;
		}

		public static bool operator !=(NullableThickness n0, NullableThickness n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableThickness n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
