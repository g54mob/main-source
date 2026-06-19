using System.Security.Cryptography;

namespace Loxodon.Framework.Security.Cryptography
{
	public class AesCTRSymmetricAlgorithm : SymmetricAlgorithm
	{
		private RijndaelManaged rijndael;

		public AesCTRSymmetricAlgorithm(byte[] key, byte[] iv)
		{
			int blockSize = (BlockSizeValue = 128);
			ModeValue = CipherMode.ECB;
			PaddingValue = PaddingMode.None;
			KeyValue = key;
			IVValue = iv;
			rijndael = new RijndaelManaged
			{
				Mode = CipherMode.ECB,
				Padding = PaddingMode.None,
				KeySize = 128,
				BlockSize = blockSize
			};
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return new AesCTRCryptoTransform(rijndael, rgbKey, rgbIV);
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return new AesCTRCryptoTransform(rijndael, rgbKey, rgbIV);
		}

		public override void GenerateIV()
		{
			rijndael.GenerateIV();
		}

		public override void GenerateKey()
		{
			rijndael.GenerateKey();
		}
	}
}
