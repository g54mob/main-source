using System.Security.Cryptography;

namespace Amazon.Runtime.Internal.Util
{
	public interface IDecryptionWrapper
	{
		ICryptoTransform Transformer { get; }

		void SetDecryptionData(byte[] key, byte[] IV);

		void CreateDecryptor();
	}
}
