namespace Tayx.Graphy.Utils
{
	public static class FloatString
	{
		private static float decimalMultiplayer;

		public static string[] positiveBuffer;

		public static string[] negativeBuffer;

		public static bool Inited => false;

		public static float maxValue => 0f;

		public static float minValue => 0f;

		public static void Init(float minNegativeValue, float maxPositiveValue, int deciminals = 1)
		{
		}

		public static string ToStringNonAlloc(this float value)
		{
			return null;
		}

		public static string ToStringNonAlloc(this float value, string format)
		{
			return null;
		}

		private static int Pow(int f, int p)
		{
			return 0;
		}

		private static int ToIndex(this float f)
		{
			return 0;
		}

		private static float FromIndex(this int i)
		{
			return 0f;
		}

		public static int ToInt(this float f)
		{
			return 0;
		}

		public static float ToFloat(this int i)
		{
			return 0f;
		}
	}
}
