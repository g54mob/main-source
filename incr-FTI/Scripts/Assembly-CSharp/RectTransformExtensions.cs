using UnityEngine;

public static class RectTransformExtensions
{
	public static void SetLeft(this RectTransform rt, float left)
	{
		rt.offsetMin = new Vector2(left, rt.offsetMin.y);
	}

	public static void SetRight(this RectTransform rt, float right)
	{
		rt.offsetMax = new Vector2(0f - right, rt.offsetMax.y);
	}

	public static void SetTop(this RectTransform rt, float top)
	{
		rt.offsetMax = new Vector2(rt.offsetMax.x, 0f - top);
	}

	public static void SetBottom(this RectTransform rt, float bottom)
	{
		rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
	}

	public static void SetWidth(this RectTransform rt, float width)
	{
		rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
	}

	public static void SetHeight(this RectTransform rt, float height)
	{
		rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);
	}

	public static void SetPosX(this RectTransform rt, float x)
	{
		rt.anchoredPosition = new Vector2(x, rt.anchoredPosition.y);
	}

	public static void SetPosY(this RectTransform rt, float y)
	{
		rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, y);
	}

	public static void PinToAnchorY(this RectTransform rt, float y)
	{
		rt.anchorMin = new Vector2(rt.anchorMin.x, y);
		rt.anchorMax = new Vector2(rt.anchorMax.x, y);
		rt.pivot = new Vector2(rt.pivot.x, y);
	}

	public static void StretchHeight(this RectTransform rt)
	{
		rt.anchorMin = new Vector2(rt.anchorMin.x, 0f);
		rt.anchorMax = new Vector2(rt.anchorMax.x, 1f);
		rt.pivot = new Vector2(rt.pivot.x, 0.5f);
	}
}
