using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class MD4Digest : GeneralDigest
	{
		private const int DigestLength = 16;

		private int H1;

		private int H2;

		private int H3;

		private int H4;

		private int[] X;

		private int xOff;

		private const int S11 = 3;

		private const int S12 = 7;

		private const int S13 = 11;

		private const int S14 = 19;

		private const int S21 = 3;

		private const int S22 = 5;

		private const int S23 = 9;

		private const int S24 = 13;

		private const int S31 = 3;

		private const int S32 = 9;

		private const int S33 = 11;

		private const int S34 = 15;

		public override string AlgorithmName => null;

		public MD4Digest()
		{
		}

		public MD4Digest(MD4Digest t)
		{
		}

		private void CopyIn(MD4Digest t)
		{
		}

		public override int GetDigestSize()
		{
			return 0;
		}

		internal override void ProcessWord(byte[] input, int inOff)
		{
		}

		internal override void ProcessLength(long bitLength)
		{
		}

		private void UnpackWord(int word, byte[] outBytes, int outOff)
		{
		}

		public override int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public override void Reset()
		{
		}

		private int RotateLeft(int x, int n)
		{
			return 0;
		}

		private int F(int u, int v, int w)
		{
			return 0;
		}

		private int G(int u, int v, int w)
		{
			return 0;
		}

		private int H(int u, int v, int w)
		{
			return 0;
		}

		internal override void ProcessBlock()
		{
		}

		public override IMemoable Copy()
		{
			return null;
		}

		public override void Reset(IMemoable other)
		{
		}
	}
}
