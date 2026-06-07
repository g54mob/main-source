namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class IdeaEngine : IBlockCipher
	{
		private const int BLOCK_SIZE = 8;

		private int[] workingKey;

		private static readonly int MASK;

		private static readonly int BASE;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		private int BytesToWord(byte[] input, int inOff)
		{
			return 0;
		}

		private void WordToBytes(int word, byte[] outBytes, int outOff)
		{
		}

		private int Mul(int x, int y)
		{
			return 0;
		}

		private void IdeaFunc(int[] workingKey, byte[] input, int inOff, byte[] outBytes, int outOff)
		{
		}

		private int[] ExpandKey(byte[] uKey)
		{
			return null;
		}

		private int MulInv(int x)
		{
			return 0;
		}

		private int AddInv(int x)
		{
			return 0;
		}

		private int[] InvertKey(int[] inKey)
		{
			return null;
		}

		private int[] GenerateWorkingKey(bool forEncryption, byte[] userKey)
		{
			return null;
		}
	}
}
