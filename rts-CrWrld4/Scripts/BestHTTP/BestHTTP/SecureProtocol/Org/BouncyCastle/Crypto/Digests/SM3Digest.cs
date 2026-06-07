using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class SM3Digest : GeneralDigest
	{
		private const int DIGEST_LENGTH = 32;

		private const int BLOCK_SIZE = 16;

		private uint[] V;

		private uint[] inwords;

		private int xOff;

		private uint[] W;

		private static readonly uint[] T;

		public override string AlgorithmName => null;

		static SM3Digest()
		{
		}

		public SM3Digest()
		{
		}

		public SM3Digest(SM3Digest t)
		{
		}

		private void CopyIn(SM3Digest t)
		{
		}

		public override int GetDigestSize()
		{
			return 0;
		}

		public override IMemoable Copy()
		{
			return null;
		}

		public override void Reset(IMemoable other)
		{
		}

		public override void Reset()
		{
		}

		public override int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		internal override void ProcessWord(byte[] input, int inOff)
		{
		}

		internal override void ProcessLength(long bitLength)
		{
		}

		private uint P0(uint x)
		{
			return 0u;
		}

		private uint P1(uint x)
		{
			return 0u;
		}

		private uint FF0(uint x, uint y, uint z)
		{
			return 0u;
		}

		private uint FF1(uint x, uint y, uint z)
		{
			return 0u;
		}

		private uint GG0(uint x, uint y, uint z)
		{
			return 0u;
		}

		private uint GG1(uint x, uint y, uint z)
		{
			return 0u;
		}

		internal override void ProcessBlock()
		{
		}
	}
}
