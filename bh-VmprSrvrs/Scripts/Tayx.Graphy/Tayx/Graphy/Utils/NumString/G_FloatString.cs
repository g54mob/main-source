namespace Tayx.Graphy.Utils.NumString
{
	public static class G_FloatString
	{
		private const string m_floatFormat = "0.0";

		private static float m_decimalMultiplier;

		private static string[] m_negativeBuffer;

		private static string[] m_positiveBuffer;

		public static float MinValue => 0f;

		public static float MaxValue => 0f;

		public static void Init(float minNegativeValue, float maxPositiveValue)
		{
		}

		public static void Dispose()
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

		public static int ToInt(this float f)
		{
			return 0;
		}

		public static float ToFloat(this int i)
		{
			return 0f;
		}

		private static int ToIndex(this float f)
		{
			return 0;
		}

		private static float FromIndex(this int i)
		{
			return 0f;
		}
	}
}
