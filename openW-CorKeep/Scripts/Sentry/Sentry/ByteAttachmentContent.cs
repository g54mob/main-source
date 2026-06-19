using System.IO;

namespace Sentry
{
	public class ByteAttachmentContent : IAttachmentContent
	{
		private readonly byte[] _bytes;

		public ByteAttachmentContent(byte[] bytes)
		{
			_bytes = bytes;
		}

		public Stream GetStream()
		{
			return new MemoryStream(_bytes);
		}
	}
}
