using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Gost3411_2012_256Digest : Gost3411_2012Digest
	{
		private static readonly byte[] IV;

		public override string AlgorithmName => null;

		public Gost3411_2012_256Digest()
			: base(null)
		{
		}

		public Gost3411_2012_256Digest(Gost3411_2012_256Digest other)
			: base(null)
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

		public override IMemoable Copy()
		{
			return null;
		}
	}
}
