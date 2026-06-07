namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	public class CfbBlockCipher : IBlockCipher
	{
		private byte[] IV;

		private byte[] cfbV;

		private byte[] cfbOutV;

		private bool encrypting;

		private readonly int blockSize;

		private readonly IBlockCipher cipher;

		public string AlgorithmName => null;

		public bool IsPartialBlockOkay => false;

		public CfbBlockCipher(IBlockCipher cipher, int bitBlockSize)
		{
		}

		public IBlockCipher GetUnderlyingCipher()
		{
			return null;
		}

		public void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public int GetBlockSize()
		{
			return 0;
		}

		public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		public int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}
	}
}
