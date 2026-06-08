using System.IO;

namespace Amazon.Runtime.Internal.Util
{
	public class AESDecryptionStream : DecryptStream<DecryptionWrapperAES>
	{
		public AESDecryptionStream(Stream baseStream, byte[] key, byte[] IV)
			: base(baseStream, key, IV)
		{
		}
	}
}
