using System.Security.Cryptography;

namespace Amazon.Runtime.Internal.Util
{
	public class EncryptionWrapperAES : EncryptionWrapper
	{
		protected override SymmetricAlgorithm CreateAlgorithm()
		{
			return Aes.Create();
		}
	}
}
