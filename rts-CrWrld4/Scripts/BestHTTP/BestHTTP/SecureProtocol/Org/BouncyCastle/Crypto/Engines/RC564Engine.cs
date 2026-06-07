namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class RC564Engine : IBlockCipher
	{
		private static readonly int wordSize;

		private static readonly int bytesPerWord;

		private int _noRounds;

		private long[] _S;

		private static readonly long P64;

		private static readonly long Q64;

		private bool forEncryption;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		private void SetKey(byte[] key)
		{
		}

		private int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		private long RotateLeft(long x, long y)
		{
			return 0L;
		}

		private long RotateRight(long x, long y)
		{
			return 0L;
		}

		private long BytesToWord(byte[] src, int srcOff)
		{
			return 0L;
		}

		private void WordToBytes(long word, byte[] dst, int dstOff)
		{
		}
	}
}
