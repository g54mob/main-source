using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class GMac : IMac
	{
		private readonly GcmBlockCipher cipher;

		private readonly int macSizeBits;

		public string AlgorithmName => null;

		public GMac(GcmBlockCipher cipher)
		{
		}

		public GMac(GcmBlockCipher cipher, int macSizeBits)
		{
		}

		public void Init(ICipherParameters parameters)
		{
		}

		public int GetMacSize()
		{
			return 0;
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}
	}
}
