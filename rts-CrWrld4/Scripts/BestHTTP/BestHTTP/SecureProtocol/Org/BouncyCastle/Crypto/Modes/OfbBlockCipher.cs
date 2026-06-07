namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	public class OfbBlockCipher : IBlockCipher
	{
		private byte[] IV;

		private byte[] ofbV;

		private byte[] ofbOutV;

		private readonly int blockSize;

		private readonly IBlockCipher cipher;

		public string AlgorithmName => null;

		public bool IsPartialBlockOkay => false;

		public OfbBlockCipher(IBlockCipher cipher, int blockSize)
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

		public void Reset()
		{
		}
	}
}
