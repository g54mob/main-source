namespace Coherence.Brook
{
	public struct FloatMeta
	{
		public FloatCompression Compression;

		public int BitCount;

		public int Minimum;

		public int Maximum;

		public double Precision;

		public static void EnsureValidTruncatedBitCount(int bits)
		{
		}

		public static FloatMeta NoCompression()
		{
			return default(FloatMeta);
		}

		public static FloatMeta ForTruncated(int bits)
		{
			return default(FloatMeta);
		}

		public static FloatMeta ForFixedPoint(int minRange, int maxRange, double precision)
		{
			return default(FloatMeta);
		}
	}
}
