namespace QRCoder
{
	public static class PngByteQRCodeHelper
	{
		public static byte[] GetQRCode(string plainText, int pixelsPerModule, byte[] darkColorRgba, byte[] lightColorRgba, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true)
		{
			return null;
		}

		public static byte[] GetQRCode(string txt, QRCodeGenerator.ECCLevel eccLevel, int size, bool drawQuietZones = true)
		{
			return null;
		}
	}
}
