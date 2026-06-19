using System.IO;

namespace Sentry
{
	public interface IAttachmentContent
	{
		Stream GetStream();
	}
}
