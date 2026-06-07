namespace Noesis
{
	internal struct NullableRect
	{
		private bool _hasValue;

		private Rect _value;

		public bool HasValue => false;

		public Rect Value => default(Rect);

		public NullableRect(Rect v)
		{
			_hasValue = false;
			_value = default(Rect);
		}

		public static explicit operator Rect(NullableRect n)
		{
			return default(Rect);
		}

		public static implicit operator NullableRect(Rect v)
		{
			return default(NullableRect);
		}

		public static implicit operator Rect?(NullableRect n)
		{
			return null;
		}

		public static implicit operator NullableRect(Rect? n)
		{
			return default(NullableRect);
		}

		public static bool operator ==(NullableRect n, Rect v)
		{
			return false;
		}

		public static bool operator !=(NullableRect n, Rect v)
		{
			return false;
		}

		public static bool operator ==(Rect v, NullableRect n)
		{
			return false;
		}

		public static bool operator !=(Rect v, NullableRect n)
		{
			return false;
		}

		public static bool operator ==(NullableRect n0, NullableRect n1)
		{
			return false;
		}

		public static bool operator !=(NullableRect n0, NullableRect n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableRect n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
