namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Blake2bDigest : IDigest
	{
		private static readonly ulong[] blake2b_IV;

		private static readonly byte[,] blake2b_sigma;

		private const int ROUNDS = 12;

		private const int BLOCK_LENGTH_BYTES = 128;

		private int digestLength;

		private int keyLength;

		private byte[] salt;

		private byte[] personalization;

		private byte[] key;

		private byte[] buffer;

		private int bufferPos;

		private ulong[] internalState;

		private ulong[] chainValue;

		private ulong t0;

		private ulong t1;

		private ulong f0;

		public virtual string AlgorithmName => null;

		public Blake2bDigest()
		{
		}

		public Blake2bDigest(Blake2bDigest digest)
		{
		}

		public Blake2bDigest(int digestSize)
		{
		}

		public Blake2bDigest(byte[] key)
		{
		}

		public Blake2bDigest(byte[] key, int digestLength, byte[] salt, byte[] personalization)
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

		private void G(ulong m1, ulong m2, int posA, int posB, int posC, int posD)
		{
		}

		private static ulong Rotr64(ulong x, int rot)
		{
			return 0uL;
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
