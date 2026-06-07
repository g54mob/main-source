namespace Noesis
{
	internal struct NullableFloat
	{
		private bool _hasValue;

		private float _value;

		public bool HasValue => false;

		public float Value => 0f;

		public NullableFloat(float v)
		{
			_hasValue = false;
			_value = 0f;
		}

		public static explicit operator float(NullableFloat n)
		{
			return 0f;
		}

		public static implicit operator NullableFloat(float v)
		{
			return default(NullableFloat);
		}

		public static implicit operator float?(NullableFloat n)
		{
			return null;
		}

		public static implicit operator NullableFloat(float? n)
		{
			return default(NullableFloat);
		}

		public static bool operator ==(NullableFloat n, float v)
		{
			return false;
		}

		public static bool operator !=(NullableFloat n, float v)
		{
			return false;
		}

		public static bool operator ==(float v, NullableFloat n)
		{
			return false;
		}

		public static bool operator !=(float v, NullableFloat n)
		{
			return false;
		}

		public static bool operator ==(NullableFloat n0, NullableFloat n1)
		{
			return false;
		}

		public static bool operator !=(NullableFloat n0, NullableFloat n1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NullableFloat n)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
