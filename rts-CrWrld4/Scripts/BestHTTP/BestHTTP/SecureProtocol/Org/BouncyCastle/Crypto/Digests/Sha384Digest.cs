using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	[Il2CppEagerStaticClassConstruction]
	public class Sha384Digest : LongDigest
	{
		private const int DigestLength = 48;

		public override string AlgorithmName => null;

		public Sha384Digest()
		{
		}

		public Sha384Digest(Sha384Digest t)
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
