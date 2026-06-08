using System.IO;

namespace Amazon.Runtime.Internal.Util
{
	public class AESEncryptionUploadPartStream : EncryptUploadPartStream<EncryptionWrapperAES>
	{
		public AESEncryptionUploadPartStream(Stream baseStream, byte[] key, byte[] IV)
			: base(baseStream, key, IV)
		{
		}
	}
}
