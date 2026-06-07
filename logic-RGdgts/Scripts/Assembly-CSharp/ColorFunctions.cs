using UnityEngine;

public static class ColorFunctions
{
	public struct HSBColor
	{
		public float h;

		public float s;

		public float b;

		public HSBColor(float h, float s, float b)
		{
			this.h = 0f;
			this.s = 0f;
			this.b = 0f;
		}
	}

	public static Color Lerp(Color from, Color to, float t)
	{
		return default(Color);
	}

	public static Color LerpHSV(ColorHSV a, ColorHSV b, float t)
	{
		return default(Color);
	}

	public static string ColorToHex(Color32 color)
	{
		return null;
	}

	public static Color HexToColor(string hex)
	{
		return default(Color);
	}

	public static Color HSBToColor(HSBColor hsb, float alpha = 1f)
	{
		return default(Color);
	}

	public static Color HSBToColor(float hue, float saturation, float brightness, float alpha = 1f)
	{
		return default(Color);
	}

	public static HSBColor ColorToHSB(Color color)
	{
		return default(HSBColor);
	}

	public static float ColorDistance(Color a, Color b)
	{
		return 0f;
	}

	public static Color RandomSkinColor()
	{
		return default(Color);
	}
}
