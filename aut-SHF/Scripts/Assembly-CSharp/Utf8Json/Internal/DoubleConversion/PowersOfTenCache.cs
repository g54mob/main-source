namespace Utf8Json.Internal.DoubleConversion
{
	internal static class PowersOfTenCache
	{
		private static readonly CachedPower[] kCachedPowers;

		public const int kCachedPowersOffset = 348;

		public const double kD_1_LOG2_10 = 0.30102999566398114;

		public const int kDecimalExponentDistance = 8;

		public const int kMinDecimalExponent = -348;

		public const int kMaxDecimalExponent = 340;

		public static void GetCachedPowerForBinaryExponentRange(int min_exponent, int max_exponent, out DiyFp power, out int decimal_exponent)
		{
			power = default(DiyFp);
			decimal_exponent = default(int);
		}

		public static void GetCachedPowerForDecimalExponent(int requested_exponent, out DiyFp power, out int found_exponent)
		{
			power = default(DiyFp);
			found_exponent = default(int);
		}
	}
}
