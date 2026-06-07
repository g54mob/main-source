namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class ShortenedDigest : IDigest
	{
		private IDigest baseDigest;

		private int length;

		public string AlgorithmName => null;

		public ShortenedDigest(IDigest baseDigest, int length)
		{
		}

		public int GetDigestSize()
		{
			return 0;
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		public int GetByteLength()
		{
			return 0;
		}
	}
}
