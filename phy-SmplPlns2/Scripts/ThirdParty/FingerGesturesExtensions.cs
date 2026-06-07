using UnityEngine;

public static class FingerGesturesExtensions
{
	public static string Abreviation(this DistanceUnit unit)
	{
		return unit switch
		{
			DistanceUnit.Centimeters => "cm", 
			DistanceUnit.Inches => "in", 
			DistanceUnit.Pixels => "px", 
			_ => unit.ToString(), 
		};
	}

	public static float Convert(this float value, DistanceUnit fromUnit, DistanceUnit toUnit)
	{
		return FingerGestures.Convert(value, fromUnit, toUnit);
	}

	public static float In(this float valueInPixels, DistanceUnit toUnit)
	{
		return valueInPixels.Convert(DistanceUnit.Pixels, toUnit);
	}

	public static float Centimeters(this float valueInPixels)
	{
		return valueInPixels.In(DistanceUnit.Centimeters);
	}

	public static float Inches(this float valueInPixels)
	{
		return valueInPixels.In(DistanceUnit.Inches);
	}

	public static Vector2 Convert(this Vector2 v, DistanceUnit fromUnit, DistanceUnit toUnit)
	{
		return FingerGestures.Convert(v, fromUnit, toUnit);
	}

	public static Vector2 In(this Vector2 vecInPixels, DistanceUnit toUnit)
	{
		return vecInPixels.Convert(DistanceUnit.Pixels, toUnit);
	}

	public static Vector2 Centimeters(this Vector2 vecInPixels)
	{
		return vecInPixels.In(DistanceUnit.Centimeters);
	}

	public static Vector2 Inches(this Vector2 vecInPixels)
	{
		return vecInPixels.In(DistanceUnit.Inches);
	}
}
