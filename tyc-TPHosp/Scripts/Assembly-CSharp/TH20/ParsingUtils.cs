using System;
using UnityEngine;

namespace TH20
{
	public static class ParsingUtils
	{
		public static Color ColorFromInts(int r, int g, int b, int a = 255)
		{
			return new Color((float)r / 255f, (float)g / 255f, (float)b / 255f, (float)a / 255f);
		}

		public static string ColorToRichTextHex(Color color)
		{
			return "<color=" + ColorToHex(color) + ">";
		}

		public static string ColorToHex(Color32 color)
		{
			string text = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
			return "#" + text;
		}

		public static Color HexStringToColour(string hexString)
		{
			if (hexString.Length != 7)
			{
				throw new ArgumentException();
			}
			string value = hexString.Substring(1, 2);
			string value2 = hexString.Substring(3, 2);
			string value3 = hexString.Substring(5, 2);
			int r = Convert.ToInt32(value, 16);
			int g = Convert.ToInt32(value2, 16);
			int b = Convert.ToInt32(value3, 16);
			return ColorFromInts(r, g, b);
		}

		public static Color RGBCSVIntStringToColour(string rgbstring)
		{
			string[] array = rgbstring.Split(',');
			if (array.Length != 3)
			{
				throw new ArgumentException();
			}
			return new Color((float)int.Parse(array[0]) / 255f, (float)int.Parse(array[1]) / 255f, (float)int.Parse(array[2]) / 255f);
		}

		public static string ColourToRGBComponentString(Color colour)
		{
			return (int)(colour.r * 255f) + "," + (int)(colour.g * 255f) + "," + (int)(colour.b * 255f);
		}

		public static byte[] HexStringToByteArray(string hex)
		{
			int length = hex.Length;
			int num = (length + 1) / 2;
			bool flag = length % 2 == 1;
			byte[] array = new byte[num];
			int num2;
			for (int i = 0; i < length; i += num2)
			{
				num2 = ((flag && i == 0) ? 1 : 2);
				array[(i + 1) / 2] = Convert.ToByte(hex.Substring(i, num2), 16);
			}
			return array;
		}
	}
}
