namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Blake2sDigest : IDigest
	{
		private static readonly uint[] blake2s_IV;

		private static readonly byte[,] blake2s_sigma;

		private const int ROUNDS = 10;

		private const int BLOCK_LENGTH_BYTES = 64;

		private int digestLength;

		private int keyLength;

		private byte[] salt;

		private byte[] personalization;

		private byte[] key;

		private byte[] buffer;

		private int bufferPos;

		private uint[] internalState;

		private uint[] chainValue;

		private uint t0;

		private uint t1;

		private uint f0;

		public virtual string AlgorithmName => null;

		public Blake2sDigest()
		{
		}

		public Blake2sDigest(Blake2sDigest digest)
		{
		}

		public Blake2sDigest(int digestBits)
		{
		}

		public Blake2sDigest(byte[] key)
		{
		}

		public Blake2sDigest(byte[] key, int digestBytes, byte[] salt, byte[] personalization)
		{
		}

		private void Init()
		{
		}

		private void InitializeInternalState()
		{
		}

		public virtual void Update(byte b)
		{
		}

		public virtual void BlockUpdate(byte[] message, int offset, int len)
		{
		}

		public virtual int DoFinal(byte[] output, int outOffset)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		private void Compress(byte[] message, int messagePos)
		{
		}

		private void G(uint m1, uint m2, int posA, int posB, int posC, int posD)
		{
		}

		private uint rotr32(uint x, int rot)
		{
			return 0u;
		}

		public virtual int GetDigestSize()
		{
			return 0;
		}

		public virtual int GetByteLength()
		{
			return 0;
		}

		public virtual void ClearKey()
		{
		}

		public virtual void ClearSalt()
		{
		}
	}
}
