using UnityEngine;

public static class RectTransformExtensions
{
	public static void SetLeft(this RectTransform rt, float left)
	{
	}

	public static void SetRight(this RectTransform rt, float right)
	{
	}

	public static void SetTop(this RectTransform rt, float top)
	{
	}

	public static void SetBottom(this RectTransform rt, float bottom)
	{
	}

	public static Rect GetWorldRect(this RectTransform rectTransform)
	{
		return default(Rect);
	}

	private static int CountCornersVisibleFrom(this RectTransform rectTransform, Camera camera)
	{
		return 0;
	}

	public static bool IsFullyVisibleFrom(this RectTransform rectTransform, Camera camera)
	{
		return false;
	}

	public static bool IsVisibleFrom(this RectTransform rectTransform, Camera camera)
	{
		return false;
	}

	public static Rect RectTransformToScreenSpace(this RectTransform transform)
	{
		return default(Rect);
	}
}
