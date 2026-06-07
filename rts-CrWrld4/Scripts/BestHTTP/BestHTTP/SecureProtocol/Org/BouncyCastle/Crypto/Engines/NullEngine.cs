namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class NullEngine : IBlockCipher
	{
		private bool initialised;

		private const int BlockSize = 1;

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
	}
}
