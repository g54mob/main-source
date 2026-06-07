using UnityEngine;

public static class ColorExtension
{
	private const float EPSILON = 1E-10f;

	public static ColorHSV ToHSV(this Color rgb)
	{
		return default(ColorHSV);
	}

	private static Vector3 RGBtoHCV(Color rgb)
	{
		return default(Vector3);
	}
}
