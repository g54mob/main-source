using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class Dstu7564Mac : IMac
	{
		private Dstu7564Digest engine;

		private int macSize;

		private ulong inputLength;

		private byte[] paddedKey;

		private byte[] invertedKey;

		public string AlgorithmName => null;

		public Dstu7564Mac(int macSizeBits)
		{
		}

		public void Init(ICipherParameters parameters)
		{
		}

		public int GetMacSize()
		{
			return 0;
		}

		public void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public void Update(byte input)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		private void Pad()
		{
		}

		private byte[] PadKey(byte[] input)
		{
			return null;
		}
	}
}
