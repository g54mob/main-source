namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class DesEngine : IBlockCipher
	{
		internal const int BLOCK_SIZE = 8;

		private int[] workingKey;

		private static readonly short[] bytebit;

		private static readonly int[] bigbyte;

		private static readonly byte[] pc1;

		private static readonly byte[] totrot;

		private static readonly byte[] pc2;

		private static readonly uint[] SP1;

		private static readonly uint[] SP2;

		private static readonly uint[] SP3;

		private static readonly uint[] SP4;

		private static readonly uint[] SP5;

		private static readonly uint[] SP6;

		private static readonly uint[] SP7;

		private static readonly uint[] SP8;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		public virtual int[] GetWorkingKey()
		{
			return null;
		}

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

		protected static int[] GenerateWorkingKey(bool encrypting, byte[] key)
		{
			return null;
		}

		internal static void DesFunc(int[] wKey, byte[] input, int inOff, byte[] outBytes, int outOff)
		{
		}
	}
}
