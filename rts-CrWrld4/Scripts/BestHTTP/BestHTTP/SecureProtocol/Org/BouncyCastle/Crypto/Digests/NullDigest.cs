using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class NullDigest : IDigest
	{
		private readonly MemoryStream bOut;

		public string AlgorithmName => null;

		public int GetByteLength()
		{
			return 0;
		}

		public int GetDigestSize()
		{
			return 0;
		}

		public void Update(byte b)
		{
		}

		public void BlockUpdate(byte[] inBytes, int inOff, int len)
		{
		}

		public int DoFinal(byte[] outBytes, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}
	}
}
