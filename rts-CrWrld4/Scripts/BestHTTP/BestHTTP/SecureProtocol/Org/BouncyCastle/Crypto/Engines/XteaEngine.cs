namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class XteaEngine : IBlockCipher
	{
		private const int rounds = 32;

		private const int block_size = 8;

		private const int delta = -1640531527;

		private uint[] _S;

		private uint[] _sum0;

		private uint[] _sum1;

		private bool _initialised;

		private bool _forEncryption;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int ProcessBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		private void setKey(byte[] key)
		{
		}

		private int encryptBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		private int decryptBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}
	}
}
