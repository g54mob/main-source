using UnityEngine;
using UnityEngine.UI;

public static class UIExtensions
{
	private static Vector3[] corners;

	public static Bounds TransformBoundsTo(this RectTransform source, Transform target)
	{
		return default(Bounds);
	}

	public static float NormalizeScrollDistance(this ScrollRect scrollRect, int axis, float distance)
	{
		return 0f;
	}

	public static void ScrollToCenter(this ScrollRect scrollRect, RectTransform target)
	{
	}

	public static void ScrollToTop(this ScrollRect scrollRect, RectTransform target)
	{
	}
}
