using System;

namespace QRCoder
{
	public class BitmapByteQRCode : AbstractQRCode, IDisposable
	{
		public BitmapByteQRCode()
		{
		}

		public BitmapByteQRCode(QRCodeData data)
		{
		}

		public byte[] GetGraphic(int pixelsPerModule)
		{
			return null;
		}

		public byte[] GetGraphic(int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex)
		{
			return null;
		}

		public byte[] GetGraphic(int pixelsPerModule, byte[] darkColorRgb, byte[] lightColorRgb)
		{
			return null;
		}

		private byte[] HexColorToByteArray(string colorString)
		{
			return null;
		}

		private byte[] IntTo4Byte(int inp)
		{
			return null;
		}
	}
}
