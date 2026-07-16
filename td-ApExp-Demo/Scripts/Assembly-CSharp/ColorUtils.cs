using System.Globalization;
using UnityEngine;

public static class ColorUtils
{
	public static Color HexToColor(string hex)
	{
		hex = hex.Replace("0x", "").Replace("#", "");
		byte a = byte.MaxValue;
		byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
		if (hex.Length == 8)
		{
			a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
		}
		return new Color32(r, g, b, a);
	}

	public static string ColorToHex(Color color, bool includeAlpha = false)
	{
		Color32 color2 = color;
		if (!includeAlpha)
		{
			return $"{color2.r:X2}{color2.g:X2}{color2.b:X2}";
		}
		return $"{color2.r:X2}{color2.g:X2}{color2.b:X2}{color2.a:X2}";
	}
}
