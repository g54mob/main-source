using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class ShakeDigest : KeccakDigest, IXof, IDigest
	{
		public override string AlgorithmName => null;

		private static int CheckBitLength(int bitLength)
		{
			return 0;
		}

		public ShakeDigest()
		{
		}

		public ShakeDigest(int bitLength)
		{
		}

		public ShakeDigest(ShakeDigest source)
		{
		}

		public override int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int DoFinal(byte[] output, int outOff, int outLen)
		{
			return 0;
		}

		public virtual int DoOutput(byte[] output, int outOff, int outLen)
		{
			return 0;
		}

		protected override int DoFinal(byte[] output, int outOff, byte partialByte, int partialBits)
		{
			return 0;
		}

		protected virtual int DoFinal(byte[] output, int outOff, int outLen, byte partialByte, int partialBits)
		{
			return 0;
		}

		public override IMemoable Copy()
		{
			return null;
		}
	}
}
