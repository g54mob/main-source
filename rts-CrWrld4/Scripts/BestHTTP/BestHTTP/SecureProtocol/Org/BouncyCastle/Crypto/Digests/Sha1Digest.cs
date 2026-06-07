using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	[Il2CppEagerStaticClassConstruction]
	public class Sha1Digest : GeneralDigest
	{
		private const int DigestLength = 20;

		private uint H1;

		private uint H2;

		private uint H3;

		private uint H4;

		private uint H5;

		private uint[] X;

		private int xOff;

		private const uint Y1 = 1518500249u;

		private const uint Y2 = 1859775393u;

		private const uint Y3 = 2400959708u;

		private const uint Y4 = 3395469782u;

		public override string AlgorithmName => null;

		public Sha1Digest()
		{
		}

		public Sha1Digest(Sha1Digest t)
		{
		}

		private void CopyIn(Sha1Digest t)
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

		public override int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public override void Reset()
		{
		}

		private static uint F(uint u, uint v, uint w)
		{
			return 0u;
		}

		private static uint H(uint u, uint v, uint w)
		{
			return 0u;
		}

		private static uint G(uint u, uint v, uint w)
		{
			return 0u;
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
