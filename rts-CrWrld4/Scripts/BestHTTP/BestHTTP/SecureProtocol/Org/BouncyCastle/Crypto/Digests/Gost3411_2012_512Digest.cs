using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Gost3411_2012_512Digest : Gost3411_2012Digest
	{
		private static readonly byte[] IV;

		public override string AlgorithmName => null;

		public Gost3411_2012_512Digest()
			: base(null)
		{
		}

		public Gost3411_2012_512Digest(Gost3411_2012_512Digest other)
			: base(null)
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
	}
}
