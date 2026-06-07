namespace Utf8Json.Internal.DoubleConversion
{
	internal struct Single
	{
		private const int kExponentBias = 150;

		private const int kDenormalExponent = -149;

		private const int kMaxExponent = 105;

		private const uint kInfinity = 2139095040u;

		private const uint kNaN = 2143289344u;

		public const uint kSignMask = 2147483648u;

		public const uint kExponentMask = 2139095040u;

		public const uint kSignificandMask = 8388607u;

		public const uint kHiddenBit = 8388608u;

		public const int kPhysicalSignificandSize = 23;

		public const int kSignificandSize = 24;

		private uint d32_;

		public Single(float f)
		{
			d32_ = 0u;
		}

		public DiyFp AsDiyFp()
		{
			return default(DiyFp);
		}

		public uint AsUint32()
		{
			return 0u;
		}

		public int Exponent()
		{
			return 0;
		}

		public uint Significand()
		{
			return 0u;
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

		public void NormalizedBoundaries(out DiyFp out_m_minus, out DiyFp out_m_plus)
		{
			out_m_minus = default(DiyFp);
			out_m_plus = default(DiyFp);
		}

		public DiyFp UpperBoundary()
		{
			return default(DiyFp);
		}

		public bool LowerBoundaryIsCloser()
		{
			return false;
		}

		public float value()
		{
			return 0f;
		}

		public static float Infinity()
		{
			return 0f;
		}

		public static float NaN()
		{
			return 0f;
		}
	}
}
