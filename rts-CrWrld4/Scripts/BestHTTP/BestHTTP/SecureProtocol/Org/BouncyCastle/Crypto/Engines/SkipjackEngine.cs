namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class SkipjackEngine : IBlockCipher
	{
		private const int BLOCK_SIZE = 8;

		private static readonly short[] ftable;

		private int[] key0;

		private int[] key1;

		private int[] key2;

		private int[] key3;

		private bool encrypting;

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

		private int G(int k, int w)
		{
			return 0;
		}

		public virtual int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		private int H(int k, int w)
		{
			return 0;
		}

		public virtual int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}
	}
}
