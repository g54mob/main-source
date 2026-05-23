namespace Utf8Json.Internal.DoubleConversion
{
	internal struct Double
	{
		public const ulong kSignMask = 9223372036854775808uL;

		public const ulong kExponentMask = 9218868437227405312uL;

		public const ulong kSignificandMask = 4503599627370495uL;

		public const ulong kHiddenBit = 4503599627370496uL;

		public const int kPhysicalSignificandSize = 52;

		public const int kSignificandSize = 53;

		private const int kExponentBias = 1075;

		private const int kDenormalExponent = -1074;

		private const int kMaxExponent = 972;

		private const ulong kInfinity = 9218868437227405312uL;

		private const ulong kNaN = 9221120237041090560uL;

		private ulong d64_;

		public Double(double d)
		{
			d64_ = 0uL;
		}

		public Double(DiyFp d)
		{
			d64_ = 0uL;
		}

		public DiyFp AsDiyFp()
		{
			return default(DiyFp);
		}

		public DiyFp AsNormalizedDiyFp()
		{
			return default(DiyFp);
		}

		public ulong AsUint64()
		{
			return 0uL;
		}

		public double NextDouble()
		{
			return 0.0;
		}

		public double PreviousDouble()
		{
			return 0.0;
		}

		public int Exponent()
		{
			return 0;
		}

		public ulong Significand()
		{
			return 0uL;
		}

		public bool IsDenormal()
		{
			return false;
		}

		public bool IsSpecial()
		{
			return false;
		}

		public bool IsNan()
		{
			return false;
		}

		public bool IsInfinite()
		{
			return false;
		}

		public int Sign()
		{
			return 0;
		}

		public DiyFp UpperBoundary()
		{
			return default(DiyFp);
		}

		public void NormalizedBoundaries(out DiyFp out_m_minus, out DiyFp out_m_plus)
		{
			out_m_minus = default(DiyFp);
			out_m_plus = default(DiyFp);
		}

		public bool LowerBoundaryIsCloser()
		{
			return false;
		}

		public double value()
		{
			return 0.0;
		}

		public static int SignificandSizeForOrderOfMagnitude(int order)
		{
			return 0;
		}

		public static double Infinity()
		{
			return 0.0;
		}

		public static double NaN()
		{
			return 0.0;
		}

		public static ulong DiyFpToUint64(DiyFp diy_fp)
		{
			return 0uL;
		}
	}
}
