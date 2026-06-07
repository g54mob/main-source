namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	internal class MacCFBBlockCipher : IBlockCipher
	{
		private byte[] IV;

		private byte[] cfbV;

		private byte[] cfbOutV;

		private readonly int blockSize;

		private readonly IBlockCipher cipher;

		public string AlgorithmName => null;

		public bool IsPartialBlockOkay => false;

		public MacCFBBlockCipher(IBlockCipher cipher, int bitBlockSize)
		{
		}

		public void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public int GetBlockSize()
		{
			return 0;
		}

		public int ProcessBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		public void GetMacBlock(byte[] mac)
		{
		}
	}
}
