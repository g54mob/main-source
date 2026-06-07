namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public class BufferedAsymmetricBlockCipher : BufferedCipherBase
	{
		private readonly IAsymmetricBlockCipher cipher;

		private byte[] buffer;

		private int bufOff;

		public override string AlgorithmName => null;

		public BufferedAsymmetricBlockCipher(IAsymmetricBlockCipher cipher)
		{
		}

		internal int GetBufferPosition()
		{
			return 0;
		}

		public override int GetBlockSize()
		{
			return 0;
		}

		public override int GetOutputSize(int length)
		{
			return 0;
		}

		public override int GetUpdateOutputSize(int length)
		{
			return 0;
		}

		public override void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public override byte[] ProcessByte(byte input)
		{
			return null;
		}

		public override byte[] ProcessBytes(byte[] input, int inOff, int length)
		{
			return null;
		}

		public override byte[] DoFinal()
		{
			return null;
		}

		public override byte[] DoFinal(byte[] input, int inOff, int length)
		{
			return null;
		}

		public override void Reset()
		{
		}
	}
}
