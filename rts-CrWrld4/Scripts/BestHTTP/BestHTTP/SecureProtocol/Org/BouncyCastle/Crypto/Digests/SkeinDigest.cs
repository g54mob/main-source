using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class SkeinDigest : IDigest, IMemoable
	{
		public const int SKEIN_256 = 256;

		public const int SKEIN_512 = 512;

		public const int SKEIN_1024 = 1024;

		private readonly SkeinEngine engine;

		public string AlgorithmName => null;

		public SkeinDigest(int stateSizeBits, int digestSizeBits)
		{
		}

		public SkeinDigest(SkeinDigest digest)
		{
		}

		public void Reset(IMemoable other)
		{
		}

		public IMemoable Copy()
		{
			return null;
		}

		public int GetDigestSize()
		{
			return 0;
		}

		public int GetByteLength()
		{
			return 0;
		}

		public void Init(SkeinParameters parameters)
		{
		}

		public void Reset()
		{
		}

		public void Update(byte inByte)
		{
		}

		public void BlockUpdate(byte[] inBytes, int inOff, int len)
		{
		}

		public int DoFinal(byte[] outBytes, int outOff)
		{
			return 0;
		}
	}
}
