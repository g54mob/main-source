using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class Dstu7624WrapEngine : IWrapper
	{
		private KeyParameter param;

		private Dstu7624Engine engine;

		private bool forWrapping;

		private int blockSize;

		public string AlgorithmName => null;

		public Dstu7624WrapEngine(int blockSizeBits)
		{
		}

		public void Init(bool forWrapping, ICipherParameters parameters)
		{
		}

		public byte[] Wrap(byte[] input, int inOff, int length)
		{
			return null;
		}

		public byte[] Unwrap(byte[] input, int inOff, int length)
		{
			return null;
		}
	}
}
