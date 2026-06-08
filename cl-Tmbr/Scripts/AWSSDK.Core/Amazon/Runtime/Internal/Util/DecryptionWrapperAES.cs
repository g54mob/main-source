using System.Security.Cryptography;

namespace Amazon.Runtime.Internal.Util
{
	public class DecryptionWrapperAES : DecryptionWrapper
	{
		protected override SymmetricAlgorithm CreateAlgorithm()
		{
			return Aes.Create();
		}
	}
}
