using UnityEngine;

public static class ColorExtensions
{
	public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
	{
		return new Color(r.GetValueOrDefault(color.r), g.GetValueOrDefault(color.g), b.GetValueOrDefault(color.b), a.GetValueOrDefault(color.a));
	}
}
