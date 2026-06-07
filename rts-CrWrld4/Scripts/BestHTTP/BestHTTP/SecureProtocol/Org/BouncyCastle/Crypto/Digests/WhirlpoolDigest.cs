using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public sealed class WhirlpoolDigest : IDigest, IMemoable
	{
		private const int BYTE_LENGTH = 64;

		private const int DIGEST_LENGTH_BYTES = 64;

		private const int ROUNDS = 10;

		private const int REDUCTION_POLYNOMIAL = 285;

		private static readonly int[] SBOX;

		private static readonly long[] C0;

		private static readonly long[] C1;

		private static readonly long[] C2;

		private static readonly long[] C3;

		private static readonly long[] C4;

		private static readonly long[] C5;

		private static readonly long[] C6;

		private static readonly long[] C7;

		private readonly long[] _rc;

		private static readonly short[] EIGHT;

		private const int BITCOUNT_ARRAY_SIZE = 32;

		private byte[] _buffer;

		private int _bufferPos;

		private short[] _bitCount;

		private long[] _hash;

		private long[] _K;

		private long[] _L;

		private long[] _block;

		private long[] _state;

		public string AlgorithmName => null;

		static WhirlpoolDigest()
		{
		}

		public WhirlpoolDigest()
		{
		}

		private static long packIntoLong(int b7, int b6, int b5, int b4, int b3, int b2, int b1, int b0)
		{
			return 0L;
		}

		private static int maskWithReductionPolynomial(int input)
		{
			return 0;
		}

		public WhirlpoolDigest(WhirlpoolDigest originalDigest)
		{
		}

		public int GetDigestSize()
		{
			return 0;
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		private void processFilledBuffer()
		{
		}

		private static long bytesToLongFromBuffer(byte[] buffer, int startPos)
		{
			return 0L;
		}

		private static void convertLongToByteArray(long inputLong, byte[] outputArray, int offSet)
		{
		}

		private void processBlock()
		{
		}

		public void Update(byte input)
		{
		}

		private void increment()
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		private void finish()
		{
		}

		private byte[] copyBitLength()
		{
			return null;
		}

		public int GetByteLength()
		{
			return 0;
		}

		public IMemoable Copy()
		{
			return null;
		}

		public void Reset(IMemoable other)
		{
		}
	}
}
