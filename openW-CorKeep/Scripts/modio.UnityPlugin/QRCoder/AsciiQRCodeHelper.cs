namespace QRCoder
{
	public static class AsciiQRCodeHelper
	{
		public static string GetQRCode(string plainText, int pixelsPerModule, string darkColorString, string whiteSpaceString, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1, string endOfLine = "\n", bool drawQuietZones = true)
		{
			using QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
			using QRCodeData data = qRCodeGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion);
			using AsciiQRCode asciiQRCode = new AsciiQRCode(data);
			return asciiQRCode.GetGraphic(pixelsPerModule, darkColorString, whiteSpaceString, drawQuietZones, endOfLine);
		}
	}
}
