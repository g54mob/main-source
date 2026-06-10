using System;

namespace QRCoder
{
	public class AsciiQRCode : AbstractQRCode, IDisposable
	{
		public AsciiQRCode()
		{
		}

		public AsciiQRCode(QRCodeData data)
		{
		}

		public string GetGraphic(int repeatPerModule, string darkColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true, string endOfLine = "\n")
		{
			return null;
		}

		public string[] GetLineByLineGraphic(int repeatPerModule, string darkColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true)
		{
			return null;
		}
	}
}
