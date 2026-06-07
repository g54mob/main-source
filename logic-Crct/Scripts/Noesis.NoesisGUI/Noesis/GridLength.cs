namespace Noesis
{
	public struct GridLength
	{
		private GridUnitType _type;

		private float _value;

		public GridUnitType GridUnitType => default(GridUnitType);

		public bool IsAbsolute => false;

		public bool IsAuto => false;

		public bool IsStar => false;

		public float Value => 0f;

		public static GridLength Auto => default(GridLength);

		public GridLength(float pixels)
		{
			_type = default(GridUnitType);
			_value = 0f;
		}

		public GridLength(float value, GridUnitType type)
		{
			_type = default(GridUnitType);
			_value = 0f;
		}

		public static bool operator ==(GridLength l0, GridLength l1)
		{
			return false;
		}

		public static bool operator !=(GridLength l0, GridLength l1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(GridLength t)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static GridLength Parse(string str)
		{
			return default(GridLength);
		}

		public static bool TryParse(string str, out GridLength result)
		{
			result = default(GridLength);
			return false;
		}
	}
}
