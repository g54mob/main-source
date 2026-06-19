using System.IO;

namespace Sentry
{
	public class FileAttachmentContent : IAttachmentContent
	{
		private readonly string _filePath;

		private readonly bool _readFileAsynchronously;

		public FileAttachmentContent(string filePath)
			: this(filePath, readFileAsynchronously: true)
		{
		}

		public FileAttachmentContent(string filePath, bool readFileAsynchronously)
		{
			_filePath = filePath;
			_readFileAsynchronously = readFileAsynchronously;
		}

		public Stream GetStream()
		{
			return new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, _readFileAsynchronously);
		}
	}
}
