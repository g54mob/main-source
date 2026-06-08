using System.IO;

namespace Amazon.Runtime.Internal.Util
{
	public class AESEncryptionPutObjectStream : EncryptStream<EncryptionWrapperAES>
	{
		public AESEncryptionPutObjectStream(Stream baseStream, byte[] key, byte[] IV)
			: base(baseStream, key, IV)
		{
		}
	}
}
