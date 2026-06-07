using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Sha512Digest : LongDigest
	{
		private const int DigestLength = 64;

		public override string AlgorithmName => null;

		public Sha512Digest()
		{
		}

		public Sha512Digest(Sha512Digest t)
		{
		}

		public override int GetDigestSize()
		{
			return 0;
		}

		public override int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public override void Reset()
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
