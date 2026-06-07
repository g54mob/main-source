namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class SM4Engine : IBlockCipher
	{
		private const int BlockSize = 16;

		private static readonly byte[] Sbox;

		private static readonly uint[] CK;

		private static readonly uint[] FK;

		private uint[] rk;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		private static uint tau(uint A)
		{
			return 0u;
		}

		private static uint L_ap(uint B)
		{
			return 0u;
		}

		private uint T_ap(uint Z)
		{
			return 0u;
		}

		private void ExpandKey(bool forEncryption, byte[] key)
		{
		}

		private static uint L(uint B)
		{
			return 0u;
		}

		private static uint T(uint Z)
		{
			return 0u;
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
	}
}
