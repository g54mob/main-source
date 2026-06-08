using UnityEngine;
using UnityEngine.UI;

public static class ScrollViewFocusFunctions
{
	public static Vector2 CalculateScrollPositionWhereTargetIsVisible(ScrollRect scrollView, RectTransform target, Vector2 padding = default(Vector2))
	{
		Vector3 vector = -scrollView.content.InverseTransformPoint(target.transform.TransformPoint(target.rect.center));
		Vector2 vector2 = (Vector2)vector - target.sizeDelta / 2f;
		Vector2 vector3 = (Vector2)vector + target.sizeDelta / 2f;
		Vector2 size = scrollView.content.rect.size;
		Vector2 size2 = ((RectTransform)scrollView.content.parent).rect.size;
		Vector2 anchoredPosition = scrollView.content.anchoredPosition;
		Vector2 normalizedPosition = scrollView.normalizedPosition;
		if (scrollView.vertical && size.y > size2.y)
		{
			bool flag = (vector3 - anchoredPosition).y + padding.y > size2.y;
			bool num = (vector2 - anchoredPosition).y - padding.y <= 0f;
			Vector2 vector4 = anchoredPosition;
			if (num)
			{
				normalizedPosition.y = 1f - Mathf.Clamp01((vector2 - new Vector2(0f, padding.y)).y / (size.y - size2.y));
			}
			else if (flag)
			{
				normalizedPosition.y = 1f - Mathf.Clamp01((vector3 - size2 + new Vector2(0f, padding.y)).y / (size.y - size2.y));
			}
		}
		return normalizedPosition;
	}

	public static void ScrollBy(ScrollRect scrollView, Vector2 scrollAmount)
	{
		Vector2 size = scrollView.content.rect.size;
		Vector2 size2 = ((RectTransform)scrollView.content.parent).rect.size;
		Vector2 scale = scrollView.content.localScale;
		size.Scale(scale);
		Vector2 normalizedPosition = scrollView.normalizedPosition;
		if (scrollView.horizontal && size.x > size2.x)
		{
			normalizedPosition.x = Mathf.Clamp01(normalizedPosition.x + scrollAmount.x / (size.x - size2.x));
		}
		if (scrollView.vertical && size.y > size2.y)
		{
			normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y + scrollAmount.y / (size.y - size2.y));
		}
		scrollView.normalizedPosition = normalizedPosition;
	}
}
