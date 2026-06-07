namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class RC2Engine : IBlockCipher
	{
		private static readonly byte[] piTable;

		private const int BLOCK_SIZE = 8;

		private int[] workingKey;

		private bool encrypting;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		private int[] GenerateWorkingKey(byte[] key, int bits)
		{
			return null;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual void Reset()
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

		private int RotateWordLeft(int x, int y)
		{
			return 0;
		}

		private void EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
		}

		private void DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
		}
	}
}
