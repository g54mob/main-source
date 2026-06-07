using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class MD2Digest : IDigest, IMemoable
	{
		private const int DigestLength = 16;

		private const int BYTE_LENGTH = 16;

		private byte[] X;

		private int xOff;

		private byte[] M;

		private int mOff;

		private byte[] C;

		private int COff;

		private static readonly byte[] S;

		public string AlgorithmName => null;

		public MD2Digest()
		{
		}

		public MD2Digest(MD2Digest t)
		{
		}

		private void CopyIn(MD2Digest t)
		{
		}

		public int GetDigestSize()
		{
			return 0;
		}

		public int GetByteLength()
		{
			return 0;
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		internal void ProcessChecksum(byte[] m)
		{
		}

		internal void ProcessBlock(byte[] m)
		{
		}

		public IMemoable Copy()
		{
			return null;
		}

		public void Reset(IMemoable other)
		{
		}
	}
}
