using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public class BufferedAeadBlockCipher : BufferedCipherBase
	{
		private readonly IAeadBlockCipher cipher;

		public override string AlgorithmName => null;

		public BufferedAeadBlockCipher(IAeadBlockCipher cipher)
		{
		}

		public override void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public override int GetBlockSize()
		{
			return 0;
		}

		public override int GetUpdateOutputSize(int length)
		{
			return 0;
		}

		public override int GetOutputSize(int length)
		{
			return 0;
		}

		public override int ProcessByte(byte input, byte[] output, int outOff)
		{
			return 0;
		}

		public override byte[] ProcessByte(byte input)
		{
			return null;
		}

		public override byte[] ProcessBytes(byte[] input, int inOff, int length)
		{
			return null;
		}

		public override int ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
			return 0;
		}

		public override byte[] DoFinal()
		{
			return null;
		}

		public override byte[] DoFinal(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		public override int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public override void Reset()
		{
		}
	}
}
