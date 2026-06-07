namespace Noesis
{
	internal struct NullableInt32Rect
	{
		private bool _hasValue;

		private Int32Rect _value;

		public bool HasValue => false;

		public Int32Rect Value => default(Int32Rect);

		public NullableInt32Rect(Int32Rect v)
		{
			_hasValue = false;
			_value = default(Int32Rect);
		}

		public static explicit operator Int32Rect(NullableInt32Rect n)
		{
			return default(Int32Rect);
		}

		public static implicit operator NullableInt32Rect(Int32Rect v)
		{
			return default(NullableInt32Rect);
		}

		public static implicit operator Int32Rect?(NullableInt32Rect n)
		{
			return null;
		}

		public static implicit operator NullableInt32Rect(Int32Rect? n)
		{
			return default(NullableInt32Rect);
		}

		public static bool operator ==(NullableInt32Rect n, Int32Rect v)
		{
			return false;
		}

		public static bool operator !=(NullableInt32Rect n, Int32Rect v)
		{
			return false;
		}

		public static bool operator ==(Int32Rect v, NullableInt32Rect n)
		{
			return false;
		}

		public static bool operator !=(Int32Rect v, NullableInt32Rect n)
		{
			return false;
		}

		public static bool operator ==(NullableInt32Rect n0, NullableInt32Rect n1)
		{
			return false;
		}

		public static bool operator !=(NullableInt32Rect n0, NullableInt32Rect n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableInt32Rect n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
