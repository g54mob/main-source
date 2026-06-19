using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sentry
{
	public class SentryHint
	{
		private readonly SentryOptions? _options;

		private readonly List<SentryAttachment> _attachments = new List<SentryAttachment>();

		private Dictionary<string, object?>? _items;

		public ICollection<SentryAttachment> Attachments => _attachments;

		public IDictionary<string, object?> Items => _items ?? (_items = new Dictionary<string, object>());

		public SentryHint()
			: this(SentrySdk.CurrentHub.GetSentryOptions())
		{
		}

		internal SentryHint(SentryOptions? options)
		{
			_options = options;
		}

		public SentryHint(string key, object? value)
			: this()
		{
			Items[key] = value;
		}

		internal void AddAttachmentsFromScope(Scope scope)
		{
			_attachments.AddRange(scope.Attachments);
		}

		public void AddAttachment(string filePath, AttachmentType type = AttachmentType.Default, string? contentType = null)
		{
			if (_options != null)
			{
				_attachments.Add(new SentryAttachment(type, new FileAttachmentContent(filePath, _options.UseAsyncFileIO), Path.GetFileName(filePath), contentType));
			}
		}

		public void AddAttachment(byte[] data, string fileName, AttachmentType type = AttachmentType.Default, string? contentType = null)
		{
			_attachments.Add(new SentryAttachment(type, new ByteAttachmentContent(data), fileName, contentType));
		}

		public static SentryHint WithAttachments(params SentryAttachment[] attachments)
		{
			return WithAttachments(attachments.AsEnumerable());
		}

		public static SentryHint WithAttachments(IEnumerable<SentryAttachment> attachments)
		{
			SentryHint sentryHint = new SentryHint();
			sentryHint._attachments.AddRange(attachments);
			return sentryHint;
		}
	}
}
