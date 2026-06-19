using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QRCoder
{
	public class BitmapByteQRCode : AbstractQRCode, IDisposable
	{
		public BitmapByteQRCode()
		{
		}

		public BitmapByteQRCode(QRCodeData data)
			: base(data)
		{
		}

		public byte[] GetGraphic(int pixelsPerModule)
		{
			return GetGraphic(pixelsPerModule, new byte[3], new byte[3] { 255, 255, 255 });
		}

		public byte[] GetGraphic(int pixelsPerModule, string darkColorHtmlHex, string lightColorHtmlHex)
		{
			return GetGraphic(pixelsPerModule, HexColorToByteArray(darkColorHtmlHex), HexColorToByteArray(lightColorHtmlHex));
		}

		public byte[] GetGraphic(int pixelsPerModule, byte[] darkColorRgb, byte[] lightColorRgb)
		{
			int num = base.QrCodeData.ModuleMatrix.Count * pixelsPerModule;
			IEnumerable<byte> enumerable = darkColorRgb.Reverse();
			IEnumerable<byte> enumerable2 = lightColorRgb.Reverse();
			List<byte> list = new List<byte>();
			list.AddRange(new byte[18]
			{
				66, 77, 76, 0, 0, 0, 0, 0, 0, 0,
				26, 0, 0, 0, 12, 0, 0, 0
			});
			list.AddRange(IntTo4Byte(num));
			list.AddRange(IntTo4Byte(num));
			list.AddRange(new byte[4] { 1, 0, 24, 0 });
			for (int num2 = num - 1; num2 >= 0; num2 -= pixelsPerModule)
			{
				for (int i = 0; i < pixelsPerModule; i++)
				{
					for (int j = 0; j < num; j += pixelsPerModule)
					{
						bool flag = base.QrCodeData.ModuleMatrix[(num2 + pixelsPerModule) / pixelsPerModule - 1][(j + pixelsPerModule) / pixelsPerModule - 1];
						for (int k = 0; k < pixelsPerModule; k++)
						{
							list.AddRange(flag ? enumerable : enumerable2);
						}
					}
					if (num % 4 != 0)
					{
						for (int l = 0; l < num % 4; l++)
						{
							list.Add(0);
						}
					}
				}
			}
			list.AddRange(new byte[2]);
			return list.ToArray();
		}

		private byte[] HexColorToByteArray(string colorString)
		{
			if (colorString.StartsWith("#"))
			{
				colorString = colorString.Substring(1);
			}
			byte[] array = new byte[colorString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte.Parse(colorString.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return array;
		}

		private byte[] IntTo4Byte(int inp)
		{
			byte[] array = new byte[2];
			array[1] = (byte)(inp >> 8);
			array[0] = (byte)inp;
			return array;
		}
	}
}
