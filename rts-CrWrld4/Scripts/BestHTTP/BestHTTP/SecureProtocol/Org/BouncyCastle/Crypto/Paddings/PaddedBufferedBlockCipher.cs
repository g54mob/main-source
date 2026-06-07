namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Paddings
{
	public class PaddedBufferedBlockCipher : BufferedBlockCipher
	{
		private readonly IBlockCipherPadding padding;

		public PaddedBufferedBlockCipher(IBlockCipher cipher, IBlockCipherPadding padding)
		{
		}

		public PaddedBufferedBlockCipher(IBlockCipher cipher)
		{
		}

		public override void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public override int GetOutputSize(int length)
		{
			return 0;
		}

		public override int GetUpdateOutputSize(int length)
		{
			return 0;
		}

		public override int ProcessByte(byte input, byte[] output, int outOff)
		{
			return 0;
		}

		public override int ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
			return 0;
		}

		public override int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}
	}
}
