using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Paddings;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class ISO9797Alg3Mac : IMac
	{
		private byte[] mac;

		private byte[] buf;

		private int bufOff;

		private IBlockCipher cipher;

		private IBlockCipherPadding padding;

		private int macSize;

		private KeyParameter lastKey2;

		private KeyParameter lastKey3;

		public string AlgorithmName => null;

		public ISO9797Alg3Mac(IBlockCipher cipher)
		{
		}

		public ISO9797Alg3Mac(IBlockCipher cipher, IBlockCipherPadding padding)
		{
		}

		public ISO9797Alg3Mac(IBlockCipher cipher, int macSizeInBits)
		{
		}

		public ISO9797Alg3Mac(IBlockCipher cipher, int macSizeInBits, IBlockCipherPadding padding)
		{
		}

		public void Init(ICipherParameters parameters)
		{
		}

		public int GetMacSize()
		{
			return 0;
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}
	}
}
