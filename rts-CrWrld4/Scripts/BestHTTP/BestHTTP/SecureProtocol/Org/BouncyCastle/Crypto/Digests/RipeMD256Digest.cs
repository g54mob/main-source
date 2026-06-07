using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class RipeMD256Digest : GeneralDigest
	{
		private const int DigestLength = 32;

		private int H0;

		private int H1;

		private int H2;

		private int H3;

		private int H4;

		private int H5;

		private int H6;

		private int H7;

		private int[] X;

		private int xOff;

		public override string AlgorithmName => null;

		public override int GetDigestSize()
		{
			return 0;
		}

		public RipeMD256Digest()
		{
		}

		public RipeMD256Digest(RipeMD256Digest t)
		{
		}

		private void CopyIn(RipeMD256Digest t)
		{
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

		private int RL(int x, int n)
		{
			return 0;
		}

		private int F1(int x, int y, int z)
		{
			return 0;
		}

		private int F2(int x, int y, int z)
		{
			return 0;
		}

		private int F3(int x, int y, int z)
		{
			return 0;
		}

		private int F4(int x, int y, int z)
		{
			return 0;
		}

		private int F1(int a, int b, int c, int d, int x, int s)
		{
			return 0;
		}

		private int F2(int a, int b, int c, int d, int x, int s)
		{
			return 0;
		}

		private int F3(int a, int b, int c, int d, int x, int s)
		{
			return 0;
		}

		private int F4(int a, int b, int c, int d, int x, int s)
		{
			return 0;
		}

		private int FF1(int a, int b, int c, int d, int x, int s)
		{
			return 0;
		}

		private int FF2(int a, int b, int c, int d, int x, int s)
		{
			return 0;
		}

		private int FF3(int a, int b, int c, int d, int x, int s)
		{
			return 0;
		}

		private int FF4(int a, int b, int c, int d, int x, int s)
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
