using System.Globalization;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class ColorUtils
	{
		private static readonly CultureInfo CULTURE = CultureInfo.InvariantCulture;

		private const NumberStyles HEX = NumberStyles.HexNumber;

		public static Color Parse(string input)
		{
			if (input.Length > 9)
			{
				return default(Color);
			}
			if (input[0] == '#')
			{
				string text = input;
				input = text.Substring(1, text.Length - 1);
			}
			int length = input.Length;
			if (length != 6 && length != 8)
			{
				return default(Color);
			}
			int num = int.Parse($"{input[0]}{input[1]}", NumberStyles.HexNumber, CULTURE);
			int num2 = int.Parse($"{input[2]}{input[3]}", NumberStyles.HexNumber, CULTURE);
			int num3 = int.Parse($"{input[4]}{input[5]}", NumberStyles.HexNumber, CULTURE);
			return new Color(a: (float)((length == 8) ? int.Parse($"{input[6]}{input[7]}", NumberStyles.HexNumber, CULTURE) : 255) / 255f, r: (float)num / 255f, g: (float)num2 / 255f, b: (float)num3 / 255f);
		}

		public static Color SetRed(Color color, float red)
		{
			return new Color(red, color.g, color.b, color.a);
		}

		public static Color SetGreen(Color color, float green)
		{
			return new Color(color.r, green, color.b, color.a);
		}

		public static Color SetBlue(Color color, float blue)
		{
			return new Color(color.r, color.g, blue, color.a);
		}

		public static Color SetAlpha(Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}
	}
}
