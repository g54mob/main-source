using System.Security.Cryptography;

namespace Amazon.Runtime.Internal.Util
{
	public abstract class EncryptionWrapper : IEncryptionWrapper
	{
		private SymmetricAlgorithm algorithm;

		private ICryptoTransform encryptor;

		private const int encryptionKeySize = 256;

		protected EncryptionWrapper()
		{
			algorithm = CreateAlgorithm();
		}

		protected abstract SymmetricAlgorithm CreateAlgorithm();

		public int AppendBlock(byte[] buffer, int offset, int count, byte[] target, int targetOffset)
		{
			return encryptor.TransformBlock(buffer, offset, count, target, targetOffset);
		}

		public byte[] AppendLastBlock(byte[] buffer, int offset, int count)
		{
			return encryptor.TransformFinalBlock(buffer, offset, count);
		}

		public void CreateEncryptor()
		{
			encryptor = algorithm.CreateEncryptor();
		}

		public void SetEncryptionData(byte[] key, byte[] IV)
		{
			algorithm.KeySize = 256;
			algorithm.Padding = PaddingMode.PKCS7;
			algorithm.Mode = CipherMode.CBC;
			algorithm.Key = key;
			algorithm.IV = IV;
		}

		public void Reset()
		{
			CreateEncryptor();
		}
	}
}
