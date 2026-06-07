namespace Noesis
{
	internal struct NullableColor
	{
		private bool _hasValue;

		private Color _value;

		public bool HasValue => false;

		public Color Value => default(Color);

		public NullableColor(Color v)
		{
			_hasValue = false;
			_value = default(Color);
		}

		public static explicit operator Color(NullableColor n)
		{
			return default(Color);
		}

		public static implicit operator NullableColor(Color v)
		{
			return default(NullableColor);
		}

		public static implicit operator Color?(NullableColor n)
		{
			return null;
		}

		public static implicit operator NullableColor(Color? n)
		{
			return default(NullableColor);
		}

		public static bool operator ==(NullableColor n, Color v)
		{
			return false;
		}

		public static bool operator !=(NullableColor n, Color v)
		{
			return false;
		}

		public static bool operator ==(Color v, NullableColor n)
		{
			return false;
		}

		public static bool operator !=(Color v, NullableColor n)
		{
			return false;
		}

		public static bool operator ==(NullableColor n0, NullableColor n1)
		{
			return false;
		}

		public static bool operator !=(NullableColor n0, NullableColor n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableColor n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
