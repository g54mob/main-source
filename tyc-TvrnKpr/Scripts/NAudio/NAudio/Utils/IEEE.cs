namespace NAudio.Utils
{
	public static class IEEE
	{
		private static double UnsignedToFloat(ulong u)
		{
			return 0.0;
		}

		private static double ldexp(double x, int exp)
		{
			return 0.0;
		}

		private static double frexp(double x, out int exp)
		{
			exp = default(int);
			return 0.0;
		}

		private static ulong FloatToUnsigned(double f)
		{
			return 0uL;
		}

		public static byte[] ConvertToIeeeExtended(double num)
		{
			return null;
		}

		public static double ConvertFromIeeeExtended(byte[] bytes)
		{
			return 0.0;
		}
	}
}
