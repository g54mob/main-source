using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class TigerDigest : IDigest, IMemoable
	{
		private const int MyByteLength = 64;

		private static readonly long[] t1;

		private static readonly long[] t2;

		private static readonly long[] t3;

		private static readonly long[] t4;

		private const int DigestLength = 24;

		private long a;

		private long b;

		private long c;

		private long byteCount;

		private byte[] Buffer;

		private int bOff;

		private long[] x;

		private int xOff;

		public string AlgorithmName => null;

		public TigerDigest()
		{
		}

		public TigerDigest(TigerDigest t)
		{
		}

		public int GetDigestSize()
		{
			return 0;
		}

		public int GetByteLength()
		{
			return 0;
		}

		private void ProcessWord(byte[] b, int off)
		{
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		private void RoundABC(long x, long mul)
		{
		}

		private void RoundBCA(long x, long mul)
		{
		}

		private void RoundCAB(long x, long mul)
		{
		}

		private void KeySchedule()
		{
		}

		private void ProcessBlock()
		{
		}

		private void UnpackWord(long r, byte[] output, int outOff)
		{
		}

		private void ProcessLength(long bitLength)
		{
		}

		private void Finish()
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
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
