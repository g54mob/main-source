using UnityEngine;

public static class ColorExtension
{
	public static Color SetV(this Color parent, float newV)
	{
		return default(Color);
	}

	public static Color SetH(this Color parent, float newH)
	{
		return default(Color);
	}

	public static float GetV(this Color parent)
	{
		return 0f;
	}

	public static float GetH(this Color parent)
	{
		return 0f;
	}

	public static Color SetS(this Color parent, float newS)
	{
		return default(Color);
	}

	public static float GetS(this Color parent)
	{
		return 0f;
	}

	public static Color SetA(this Color parent, float newA)
	{
		return default(Color);
	}

	public static Color SetR(this Color parent, float newR)
	{
		return default(Color);
	}

	public static Color Addition(this Color parent, Color colorToApply)
	{
		return default(Color);
	}

	public static Color Subtract(this Color parent, Color colorToApply)
	{
		return default(Color);
	}

	public static Color Multiply(this Color parent, Color colorToApply)
	{
		return default(Color);
	}

	public static Color Divide(this Color parent, Color colorToApply)
	{
		return default(Color);
	}

	private static float ApplyDivide(float a, float b)
	{
		return 0f;
	}

	public static Color Screen(this Color parent, Color colorToApply)
	{
		return default(Color);
	}

	private static float ApplyScreen(float a, float b)
	{
		return 0f;
	}

	public static Color Overlay(this Color parent, Color colorToApply)
	{
		return default(Color);
	}

	private static float ApplyOverlay(float a, float b)
	{
		return 0f;
	}

	public static Color ColorFromHSV(float h, float s, float v, float a = 1f)
	{
		return default(Color);
	}

	public static void ColorToHSV(Color color, out float h, out float s, out float v)
	{
		h = default(float);
		s = default(float);
		v = default(float);
	}

	public static string colorToHex(Color32 color)
	{
		return null;
	}

	public static Color hexToColor(string hex)
	{
		return default(Color);
	}
}
