using System.IO;

namespace Gh.Tk
{
	public class FeedbackSavePackage
	{
		public string FromEmail { get; set; }

		public string Subject { get; set; }

		public string Feeling { get; set; }

		public string Body { get; set; }

		public string ExtendedInfo { get; set; }

		public byte[] JpgData { get; set; }

		public (string name, Stream stream)[] SaveFileStreams { get; set; }

		public (string name, string codes)[] SaveFileCodes { get; set; }
	}
}
