namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class SeedEngine : IBlockCipher
	{
		private const int BlockSize = 16;

		private static readonly uint[] SS0;

		private static readonly uint[] SS1;

		private static readonly uint[] SS2;

		private static readonly uint[] SS3;

		private static readonly uint[] KC;

		private int[] wKey;

		private bool forEncryption;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual int ProcessBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		private int[] createWorkingKey(byte[] inKey)
		{
			return null;
		}

		private int extractW1(long lVal)
		{
			return 0;
		}

		private int extractW0(long lVal)
		{
			return 0;
		}

		private long rotateLeft8(long x)
		{
			return 0L;
		}

		private long rotateRight8(long x)
		{
			return 0L;
		}

		private long bytesToLong(byte[] src, int srcOff)
		{
			return 0L;
		}

		private void longToBytes(byte[] dest, int destOff, long value)
		{
		}

		private int G(int x)
		{
			return 0;
		}

		private long F(int ki0, int ki1, long r)
		{
			return 0L;
		}

		private int phaseCalc1(int r0, int ki0, int r1, int ki1)
		{
			return 0;
		}

		private int phaseCalc2(int r0, int ki0, int r1, int ki1)
		{
			return 0;
		}
	}
}
