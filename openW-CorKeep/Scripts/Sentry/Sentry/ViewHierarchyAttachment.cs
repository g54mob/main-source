namespace Sentry
{
	public class ViewHierarchyAttachment : SentryAttachment
	{
		public ViewHierarchyAttachment(IAttachmentContent content)
			: base(AttachmentType.ViewHierarchy, content, "view-hierarchy.json", "application/json")
		{
		}
	}
}
