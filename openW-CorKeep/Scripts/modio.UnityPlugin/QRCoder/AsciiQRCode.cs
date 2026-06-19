using System;
using System.Collections.Generic;
using System.Text;

namespace QRCoder
{
	public class AsciiQRCode : AbstractQRCode, IDisposable
	{
		public AsciiQRCode()
		{
		}

		public AsciiQRCode(QRCodeData data)
			: base(data)
		{
		}

		public string GetGraphic(int repeatPerModule, string darkColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true, string endOfLine = "\n")
		{
			return string.Join(endOfLine, GetLineByLineGraphic(repeatPerModule, darkColorString, whiteSpaceString, drawQuietZones));
		}

		public string[] GetLineByLineGraphic(int repeatPerModule, string darkColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true)
		{
			List<string> list = new List<string>();
			int num = ((!drawQuietZones) ? 8 : 0);
			int num2 = (int)((double)num * 0.5);
			int num3 = ((darkColorString.Length / 2 != 1) ? (darkColorString.Length / 2) : 0);
			int num4 = repeatPerModule + num3;
			int num5 = (base.QrCodeData.ModuleMatrix.Count - num) * num4;
			for (int i = 0; i < num5; i++)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < base.QrCodeData.ModuleMatrix.Count - num; j++)
				{
					bool flag = base.QrCodeData.ModuleMatrix[j + num2][(i + num4) / num4 - 1 + num2];
					for (int k = 0; k < repeatPerModule; k++)
					{
						stringBuilder.Append(flag ? darkColorString : whiteSpaceString);
					}
				}
				list.Add(stringBuilder.ToString());
			}
			return list.ToArray();
		}
	}
}
