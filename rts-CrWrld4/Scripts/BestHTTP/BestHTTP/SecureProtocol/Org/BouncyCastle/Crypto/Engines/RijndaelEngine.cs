namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class RijndaelEngine : IBlockCipher
	{
		private static readonly int MAXROUNDS;

		private static readonly int MAXKC;

		private static readonly byte[] Logtable;

		private static readonly byte[] Alogtable;

		private static readonly byte[] S;

		private static readonly byte[] Si;

		private static readonly byte[] rcon;

		private static readonly byte[][] shifts0;

		private static readonly byte[][] shifts1;

		private int BC;

		private long BC_MASK;

		private int ROUNDS;

		private int blockBits;

		private long[][] workingKey;

		private long A0;

		private long A1;

		private long A2;

		private long A3;

		private bool forEncryption;

		private byte[] shifts0SC;

		private byte[] shifts1SC;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		private byte Mul0x2(int b)
		{
			return 0;
		}

		private byte Mul0x3(int b)
		{
			return 0;
		}

		private byte Mul0x9(int b)
		{
			return 0;
		}

		private byte Mul0xb(int b)
		{
			return 0;
		}

		private byte Mul0xd(int b)
		{
			return 0;
		}

		private byte Mul0xe(int b)
		{
			return 0;
		}

		private void KeyAddition(long[] rk)
		{
		}

		private long Shift(long r, int shift)
		{
			return 0L;
		}

		private void ShiftRow(byte[] shiftsSC)
		{
		}

		private long ApplyS(long r, byte[] box)
		{
			return 0L;
		}

		private void Substitution(byte[] box)
		{
		}

		private void MixColumn()
		{
		}

		private void InvMixColumn()
		{
		}

		private long[][] GenerateWorkingKey(byte[] key)
		{
			return null;
		}

		public RijndaelEngine()
		{
		}

		public RijndaelEngine(int blockBits)
		{
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

		private void UnPackBlock(byte[] bytes, int off)
		{
		}

		private void PackBlock(byte[] bytes, int off)
		{
		}

		private void EncryptBlock(long[][] rk)
		{
		}

		private void DecryptBlock(long[][] rk)
		{
		}
	}
}
