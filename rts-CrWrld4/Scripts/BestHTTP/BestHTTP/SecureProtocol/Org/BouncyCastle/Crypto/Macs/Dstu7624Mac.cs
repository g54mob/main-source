using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class Dstu7624Mac : IMac
	{
		private int macSize;

		private Dstu7624Engine engine;

		private int blockSize;

		private byte[] c;

		private byte[] cTemp;

		private byte[] kDelta;

		private byte[] buf;

		private int bufOff;

		public string AlgorithmName => null;

		public Dstu7624Mac(int blockSizeBits, int q)
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

		private void processBlock(byte[] input, int inOff)
		{
		}

		private void Xor(byte[] c, int cOff, byte[] input, int inOff, byte[] xorResult)
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
