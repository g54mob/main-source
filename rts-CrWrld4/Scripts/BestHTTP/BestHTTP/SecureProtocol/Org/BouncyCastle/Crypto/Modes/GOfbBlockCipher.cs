namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	public class GOfbBlockCipher : IBlockCipher
	{
		private byte[] IV;

		private byte[] ofbV;

		private byte[] ofbOutV;

		private readonly int blockSize;

		private readonly IBlockCipher cipher;

		private bool firstStep;

		private int N3;

		private int N4;

		private const int C1 = 16843012;

		private const int C2 = 16843009;

		public string AlgorithmName => null;

		public bool IsPartialBlockOkay => false;

		public GOfbBlockCipher(IBlockCipher cipher)
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

		private int bytesToint(byte[] inBytes, int inOff)
		{
			return 0;
		}

		private void intTobytes(int num, byte[] outBytes, int outOff)
		{
		}
	}
}
