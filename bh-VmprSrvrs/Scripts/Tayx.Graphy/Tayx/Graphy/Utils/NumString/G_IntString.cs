namespace Tayx.Graphy.Utils.NumString
{
	public static class G_IntString
	{
		private static string[] m_negativeBuffer;

		private static string[] m_positiveBuffer;

		public static int MinValue => 0;

		public static int MaxValue => 0;

		public static void Init(int minNegativeValue, int maxPositiveValue)
		{
		}

		public static void Dispose()
		{
		}

		public static string ToStringNonAlloc(this int value)
		{
			return null;
		}
	}
}
