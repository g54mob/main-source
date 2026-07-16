using UnityEngine;

public static class ColorHelper
{
	public static Color GetColorFromHexString(string hex)
	{
		if (hex.StartsWith("#"))
		{
			hex = hex.Substring(1);
		}
		if (ColorUtility.TryParseHtmlString("#" + hex, out var color))
		{
			return color;
		}
		return Color.white;
	}

	public static string GetHexStringFromColor(Color color)
	{
		return ColorUtility.ToHtmlStringRGB(color);
	}
}
