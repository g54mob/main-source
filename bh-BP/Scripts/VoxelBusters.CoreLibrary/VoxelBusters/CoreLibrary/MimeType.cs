namespace VoxelBusters.CoreLibrary
{
	public static class MimeType
	{
		public const string kAny = "*/*";

		public const string kPlainText = "text/plain";

		public const string kHtmlText = "text/html";

		public const string kJavaScriptText = "text/javascript";

		public const string kAllImages = "image/*";

		public const string kJPGImage = "image/jpeg";

		public const string kPNGImage = "image/png";

		public const string kGIFImage = "image/gif";

		public const string kPDF = "application/pdf";

		public const string kAllVideos = "video/*";

		public const string kMP4Video = "video/mp4";

		public const string kAllAudio = "audio/*";

		public static string GetTypeForExtension(string extension)
		{
			return null;
		}

		public static string GetExtensionForType(string mimeType)
		{
			return null;
		}
	}
}
