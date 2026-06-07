using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Sha512tDigest : LongDigest
	{
		private const ulong A5 = 11936128518282651045uL;

		private readonly int digestLength;

		private ulong H1t;

		private ulong H2t;

		private ulong H3t;

		private ulong H4t;

		private ulong H5t;

		private ulong H6t;

		private ulong H7t;

		private ulong H8t;

		public override string AlgorithmName => null;

		public Sha512tDigest(int bitLength)
		{
		}

		public Sha512tDigest(Sha512tDigest t)
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

		private void tIvGenerate(int bitLength)
		{
		}

		private static void UInt64_To_BE(ulong n, byte[] bs, int off, int max)
		{
		}

		private static void UInt32_To_BE(uint n, byte[] bs, int off, int max)
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
