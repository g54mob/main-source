namespace Tayx.Graphy.Utils
{
	public static class IntString
	{
		public static string[] positiveBuffer;

		public static string[] negativeBuffer;

		public static float maxValue => 0f;

		public static float minValue => 0f;

		public static bool Inited => false;

		public static void Init(int minNegativeValue, int maxPositiveValue)
		{
		}

		public static string ToStringNonAlloc(this int value)
		{
			return null;
		}
	}
}
