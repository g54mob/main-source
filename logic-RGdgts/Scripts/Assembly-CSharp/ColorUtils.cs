using UnityEngine;

public class ColorUtils
{
	public static Color Script_Color(byte r, byte g, byte b)
	{
		return default(Color);
	}

	public static Color Script_ColorRGBA(byte r, byte g, byte b, byte a)
	{
		return default(Color);
	}

	public static Color Script_HsvToInt(float h, float s, float v)
	{
		return default(Color);
	}

	public static uint ColorToInt(byte r, byte g, byte b)
	{
		return 0u;
	}

	public static uint ColorToInt(byte r, byte g, byte b, byte a)
	{
		return 0u;
	}

	public static uint ColorToInt(Color color)
	{
		return 0u;
	}

	public static uint ColorToInt(Color32 color)
	{
		return 0u;
	}

	public static string ColorToHexString(Color32 color, bool alpha = false)
	{
		return null;
	}

	public static bool ColorFromHexString(string str, bool alpha, out Color32 colorValue)
	{
		colorValue = default(Color32);
		return false;
	}

	public static Color32 IntToColor(uint color)
	{
		return default(Color32);
	}
}
