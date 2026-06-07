using UnityEngine;

internal static class RectExtensions
{
	public static Rect Transform(this Rect r, Transform transform)
	{
		return new Rect
		{
			min = transform.TransformPoint(r.min),
			max = transform.TransformPoint(r.max)
		};
	}

	public static Rect InverseTransform(this Rect r, Transform transform)
	{
		return new Rect
		{
			min = transform.InverseTransformPoint(r.min),
			max = transform.InverseTransformPoint(r.max)
		};
	}
}
