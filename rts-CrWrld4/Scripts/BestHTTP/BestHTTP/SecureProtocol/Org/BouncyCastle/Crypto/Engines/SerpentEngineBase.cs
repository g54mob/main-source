namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public abstract class SerpentEngineBase : IBlockCipher
	{
		protected static readonly int BlockSize;

		internal const int ROUNDS = 32;

		internal const int PHI = -1640531527;

		protected bool encrypting;

		protected int[] wKey;

		protected int X0;

		protected int X1;

		protected int X2;

		protected int X3;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		public virtual void Init(bool encrypting, ICipherParameters parameters)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		protected static int RotateLeft(int x, int bits)
		{
			return 0;
		}

		private static int RotateRight(int x, int bits)
		{
			return 0;
		}

		protected void Sb0(int a, int b, int c, int d)
		{
		}

		protected void Ib0(int a, int b, int c, int d)
		{
		}

		protected void Sb1(int a, int b, int c, int d)
		{
		}

		protected void Ib1(int a, int b, int c, int d)
		{
		}

		protected void Sb2(int a, int b, int c, int d)
		{
		}

		protected void Ib2(int a, int b, int c, int d)
		{
		}

		protected void Sb3(int a, int b, int c, int d)
		{
		}

		protected void Ib3(int a, int b, int c, int d)
		{
		}

		protected void Sb4(int a, int b, int c, int d)
		{
		}

		protected void Ib4(int a, int b, int c, int d)
		{
		}

		protected void Sb5(int a, int b, int c, int d)
		{
		}

		protected void Ib5(int a, int b, int c, int d)
		{
		}

		protected void Sb6(int a, int b, int c, int d)
		{
		}

		protected void Ib6(int a, int b, int c, int d)
		{
		}

		protected void Sb7(int a, int b, int c, int d)
		{
		}

		protected void Ib7(int a, int b, int c, int d)
		{
		}

		protected void LT()
		{
		}

		protected void InverseLT()
		{
		}

		protected abstract int[] MakeWorkingKey(byte[] key);

		protected abstract void EncryptBlock(byte[] input, int inOff, byte[] output, int outOff);

		protected abstract void DecryptBlock(byte[] input, int inOff, byte[] output, int outOff);
	}
}
