namespace Utf8Json.Internal.DoubleConversion
{
	internal struct CachedPower
	{
		public readonly ulong significand;

		public readonly short binary_exponent;

		public readonly short decimal_exponent;

		public CachedPower(ulong significand, short binary_exponent, short decimal_exponent)
		{
			this.significand = 0uL;
			this.binary_exponent = 0;
			this.decimal_exponent = 0;
		}
	}
}
