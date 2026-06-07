using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class SkeinMac : IMac
	{
		public const int SKEIN_256 = 256;

		public const int SKEIN_512 = 512;

		public const int SKEIN_1024 = 1024;

		private readonly SkeinEngine engine;

		public string AlgorithmName => null;

		public SkeinMac(int stateSizeBits, int digestSizeBits)
		{
		}

		public SkeinMac(SkeinMac mac)
		{
		}

		public void Init(ICipherParameters parameters)
		{
		}

		public int GetMacSize()
		{
			return 0;
		}

		public void Reset()
		{
		}

		public void Update(byte inByte)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}
	}
}
