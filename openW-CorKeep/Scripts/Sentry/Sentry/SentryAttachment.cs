using System.Diagnostics;

namespace Sentry
{
	[DebuggerDisplay("{FileName}")]
	public class SentryAttachment
	{
		public AttachmentType Type { get; }

		public IAttachmentContent Content { get; }

		public string FileName { get; }

		public string? ContentType { get; }

		public SentryAttachment(AttachmentType type, IAttachmentContent content, string fileName, string? contentType)
		{
			Type = type;
			Content = content;
			FileName = fileName;
			ContentType = contentType;
		}
	}
}
