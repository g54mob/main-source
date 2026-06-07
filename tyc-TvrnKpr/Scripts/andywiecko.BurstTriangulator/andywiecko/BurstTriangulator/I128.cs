namespace andywiecko.BurstTriangulator
{
	internal struct I128
	{
		private ulong hi;

		private ulong lo;

		public bool IsNegative => false;

		public I128(ulong hi, ulong lo)
		{
			this.hi = 0uL;
			this.lo = 0uL;
		}

		public static I128 operator +(I128 a, I128 b)
		{
			return default(I128);
		}

		public static I128 operator -(I128 a, I128 b)
		{
			return default(I128);
		}

		public static I128 operator -(I128 a)
		{
			return default(I128);
		}

		public static I128 Multiply(long slhs, long srhs)
		{
			return default(I128);
		}
	}
}
