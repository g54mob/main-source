namespace MyBox
{
	public static class MinMaxExtensions
	{
		public static bool IsInRange(this MinMaxInt minMax, int value)
		{
			return false;
		}

		public static bool IsInRange(this MinMaxFloat minMax, float value)
		{
			return false;
		}

		public static int Clamp(this MinMaxInt minMax, int value)
		{
			return 0;
		}

		public static float Clamp(this MinMaxFloat minMax, float value)
		{
			return 0f;
		}

		public static int Length(this MinMaxInt minMax)
		{
			return 0;
		}

		public static float Length(this MinMaxFloat minMax)
		{
			return 0f;
		}

		public static int MidPoint(this MinMaxInt minMax)
		{
			return 0;
		}

		public static float MidPoint(this MinMaxFloat minMax)
		{
			return 0f;
		}

		public static float Lerp(this MinMaxInt minMax, float value)
		{
			return 0f;
		}

		public static float Lerp(this MinMaxFloat minMax, float value)
		{
			return 0f;
		}

		public static float LerpUnclamped(this MinMaxInt minMax, float value)
		{
			return 0f;
		}

		public static float LerpUnclamped(this MinMaxFloat minMax, float value)
		{
			return 0f;
		}

		public static int RandomInRange(this MinMaxInt minMax)
		{
			return 0;
		}

		public static float RandomInRange(this MinMaxFloat minMax)
		{
			return 0f;
		}

		public static int RandomInRangeInclusive(this MinMaxInt minMax)
		{
			return 0;
		}
	}
}
