namespace Utf8Json.Internal.DoubleConversion
{
	internal struct DiyFp
	{
		public const int kSignificandSize = 64;

		public const ulong kUint64MSB = 9223372036854775808uL;

		public ulong f;

		public int e;

		public DiyFp(ulong significand, int exponent)
		{
			f = 0uL;
			e = 0;
		}

		public void Subtract(ref DiyFp other)
		{
		}

		public static DiyFp Minus(ref DiyFp a, ref DiyFp b)
		{
			return default(DiyFp);
		}

		public static DiyFp operator -(DiyFp lhs, DiyFp rhs)
		{
			return default(DiyFp);
		}

		public void Multiply(ref DiyFp other)
		{
		}

		public static DiyFp Times(ref DiyFp a, ref DiyFp b)
		{
			return default(DiyFp);
		}

		public static DiyFp operator *(DiyFp lhs, DiyFp rhs)
		{
			return default(DiyFp);
		}

		public void Normalize()
		{
		}

		public static DiyFp Normalize(ref DiyFp a)
		{
			return default(DiyFp);
		}
	}
}
