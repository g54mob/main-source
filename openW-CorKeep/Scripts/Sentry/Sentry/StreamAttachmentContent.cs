using System.IO;

namespace Sentry
{
	public class StreamAttachmentContent : IAttachmentContent
	{
		private readonly Stream _stream;

		public StreamAttachmentContent(Stream stream)
		{
			_stream = stream;
		}

		public Stream GetStream()
		{
			return _stream;
		}
	}
}
