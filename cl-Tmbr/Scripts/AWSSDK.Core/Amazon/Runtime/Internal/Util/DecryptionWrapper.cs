using System.Security.Cryptography;

namespace Amazon.Runtime.Internal.Util
{
	public abstract class DecryptionWrapper : IDecryptionWrapper
	{
		private SymmetricAlgorithm algorithm;

		private ICryptoTransform decryptor;

		private const int encryptionKeySize = 256;

		public ICryptoTransform Transformer => decryptor;

		protected DecryptionWrapper()
		{
			algorithm = CreateAlgorithm();
		}

		protected abstract SymmetricAlgorithm CreateAlgorithm();

		public void SetDecryptionData(byte[] key, byte[] IV)
		{
			algorithm.KeySize = 256;
			algorithm.Padding = PaddingMode.PKCS7;
			algorithm.Mode = CipherMode.CBC;
			algorithm.Key = key;
			algorithm.IV = IV;
		}

		public void CreateDecryptor()
		{
			decryptor = algorithm.CreateDecryptor();
		}
	}
}
