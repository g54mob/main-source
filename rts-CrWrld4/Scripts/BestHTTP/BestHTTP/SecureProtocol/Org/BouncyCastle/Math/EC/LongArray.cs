namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	internal class LongArray
	{
		private static readonly ushort[] INTERLEAVE2_TABLE;

		private static readonly int[] INTERLEAVE3_TABLE;

		private static readonly int[] INTERLEAVE4_TABLE;

		private static readonly int[] INTERLEAVE5_TABLE;

		private static readonly long[] INTERLEAVE7_TABLE;

		private const string ZEROES = "0000000000000000000000000000000000000000000000000000000000000000";

		internal static readonly byte[] BitLengths;

		private long[] m_ints;

		public int Length => 0;

		public LongArray(int intLen)
		{
		}

		public LongArray(long[] ints)
		{
		}

		public LongArray(long[] ints, int off, int len)
		{
		}

		public LongArray(BigInteger bigInt)
		{
		}

		internal void CopyTo(long[] z, int zOff)
		{
		}

		public bool IsOne()
		{
			return false;
		}

		public bool IsZero()
		{
			return false;
		}

		public int GetUsedLength()
		{
			return 0;
		}

		public int GetUsedLengthFrom(int from)
		{
			return 0;
		}

		public int Degree()
		{
			return 0;
		}

		private int DegreeFrom(int limit)
		{
			return 0;
		}

		private static int BitLength(long w)
		{
			return 0;
		}

		private long[] ResizedInts(int newLen)
		{
			return null;
		}

		public BigInteger ToBigInteger()
		{
			return null;
		}

		private static long ShiftUp(long[] x, int xOff, int count, int shift)
		{
			return 0L;
		}

		private static long ShiftUp(long[] x, int xOff, long[] z, int zOff, int count, int shift)
		{
			return 0L;
		}

		public LongArray AddOne()
		{
			return null;
		}

		private void AddShiftedByBitsSafe(LongArray other, int otherDegree, int bits)
		{
		}

		private static long AddShiftedUp(long[] x, int xOff, long[] y, int yOff, int count, int shift)
		{
			return 0L;
		}

		private static long AddShiftedDown(long[] x, int xOff, long[] y, int yOff, int count, int shift)
		{
			return 0L;
		}

		public void AddShiftedByWords(LongArray other, int words)
		{
		}

		private static void Add(long[] x, int xOff, long[] y, int yOff, int count)
		{
		}

		private static void Add(long[] x, int xOff, long[] y, int yOff, long[] z, int zOff, int count)
		{
		}

		private static void AddBoth(long[] x, int xOff, long[] y1, int y1Off, long[] y2, int y2Off, int count)
		{
		}

		private static void Distribute(long[] x, int src, int dst1, int dst2, int count)
		{
		}

		private static void FlipWord(long[] buf, int off, int bit, long word)
		{
		}

		public bool TestBitZero()
		{
			return false;
		}

		private static bool TestBit(long[] buf, int off, int n)
		{
			return false;
		}

		private static void FlipBit(long[] buf, int off, int n)
		{
		}

		private static void MultiplyWord(long a, long[] b, int bLen, long[] c, int cOff)
		{
		}

		public LongArray ModMultiplyLD(LongArray other, int m, int[] ks)
		{
			return null;
		}

		public LongArray ModMultiply(LongArray other, int m, int[] ks)
		{
			return null;
		}

		public LongArray ModMultiplyAlt(LongArray other, int m, int[] ks)
		{
			return null;
		}

		public LongArray ModReduce(int m, int[] ks)
		{
			return null;
		}

		public LongArray Multiply(LongArray other, int m, int[] ks)
		{
			return null;
		}

		public void Reduce(int m, int[] ks)
		{
		}

		private static LongArray ReduceResult(long[] buf, int off, int len, int m, int[] ks)
		{
			return null;
		}

		private static int ReduceInPlace(long[] buf, int off, int len, int m, int[] ks)
		{
			return 0;
		}

		private static void ReduceBitWise(long[] buf, int off, int BitLength, int m, int[] ks)
		{
		}

		private static void ReduceBit(long[] buf, int off, int bit, int m, int[] ks)
		{
		}

		private static void ReduceWordWise(long[] buf, int off, int len, int toBit, int m, int[] ks)
		{
		}

		private static void ReduceWord(long[] buf, int off, int bit, long word, int m, int[] ks)
		{
		}

		private static void ReduceVectorWise(long[] buf, int off, int len, int words, int m, int[] ks)
		{
		}

		private static void FlipVector(long[] x, int xOff, long[] y, int yOff, int yLen, int bits)
		{
		}

		public LongArray ModSquare(int m, int[] ks)
		{
			return null;
		}

		public LongArray ModSquareN(int n, int m, int[] ks)
		{
			return null;
		}

		public LongArray Square(int m, int[] ks)
		{
			return null;
		}

		private static void SquareInPlace(long[] x, int xLen, int m, int[] ks)
		{
		}

		private static void Interleave(long[] x, int xOff, long[] z, int zOff, int count, int width)
		{
		}

		private static void Interleave3(long[] x, int xOff, long[] z, int zOff, int count)
		{
		}

		private static long Interleave3(long x)
		{
			return 0L;
		}

		private static long Interleave3_21to63(int x)
		{
			return 0L;
		}

		private static void Interleave5(long[] x, int xOff, long[] z, int zOff, int count)
		{
		}

		private static long Interleave5(long x)
		{
			return 0L;
		}

		private static long Interleave3_13to65(int x)
		{
			return 0L;
		}

		private static void Interleave7(long[] x, int xOff, long[] z, int zOff, int count)
		{
		}

		private static long Interleave7(long x)
		{
			return 0L;
		}

		private static void Interleave2_n(long[] x, int xOff, long[] z, int zOff, int count, int rounds)
		{
		}

		private static long Interleave2_n(long x, int rounds)
		{
			return 0L;
		}

		private static long Interleave4_16to64(int x)
		{
			return 0L;
		}

		private static long Interleave2_32to64(int x)
		{
			return 0L;
		}

		public LongArray ModInverse(int m, int[] ks)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public virtual bool Equals(LongArray other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public LongArray Copy()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
