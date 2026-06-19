using UnityEngine;

namespace TH20.UI
{
	public static class RectTransformUtils
	{
		private static float Precision = 20f;

		public static void SetSizeWithCurrentAnchorsSafe(this RectTransform rect, RectTransform.Axis axis, float size)
		{
			Vector2 sizeDelta = rect.sizeDelta;
			Vector2 sizeDelta2 = sizeDelta;
			sizeDelta2[(int)axis] = size - rect.GetParentSize()[(int)axis] * (rect.anchorMax[(int)axis] - rect.anchorMin[(int)axis]);
			if (Mathf.RoundToInt(sizeDelta[(int)axis] * Precision) != Mathf.RoundToInt(sizeDelta2[(int)axis] * Precision))
			{
				rect.sizeDelta = sizeDelta2;
			}
		}

		public static void SetInsetAndSizeFromParentEdgeSafe(this RectTransform rect, RectTransform.Edge edge, float inset, float size)
		{
			int index = ((edge == RectTransform.Edge.Top || edge == RectTransform.Edge.Bottom) ? 1 : 0);
			int num;
			float num2;
			if (edge != RectTransform.Edge.Top)
			{
				num = ((edge == RectTransform.Edge.Right) ? 1 : 0);
				if (num == 0)
				{
					num2 = 0f;
					goto IL_0027;
				}
			}
			else
			{
				num = 1;
			}
			num2 = 1f;
			goto IL_0027;
			IL_0027:
			float num3 = num2;
			if ((int)(rect.anchorMin[index] * Precision) != (int)(num3 * Precision))
			{
				Vector2 anchorMin = rect.anchorMin;
				anchorMin[index] = num3;
				rect.anchorMin = anchorMin;
			}
			if ((int)(rect.anchorMax[index] * Precision) != (int)(num3 * Precision))
			{
				Vector2 anchorMax = rect.anchorMax;
				anchorMax[index] = num3;
				rect.anchorMax = anchorMax;
			}
			if ((int)(rect.sizeDelta[index] * Precision) != (int)(size * Precision))
			{
				Vector2 sizeDelta = rect.sizeDelta;
				sizeDelta[index] = size;
				rect.sizeDelta = sizeDelta;
			}
			float num4 = ((num == 0) ? (inset + size * rect.pivot[index]) : ((float)((double)(0f - inset) - (double)size * (1.0 - (double)rect.pivot[index]))));
			if ((int)(rect.anchoredPosition[index] * Precision) != (int)(num4 * Precision))
			{
				Vector2 anchoredPosition = rect.anchoredPosition;
				anchoredPosition[index] = num4;
				rect.anchoredPosition = anchoredPosition;
			}
		}

		public static void SetInsetAndSizeFromCenter(this RectTransform rect, RectTransform.Axis axis, float inset, float size)
		{
			if ((int)(rect.anchorMin[(int)axis] * Precision) != (int)(0.5f * Precision))
			{
				Vector2 anchorMin = rect.anchorMin;
				anchorMin[(int)axis] = 0.5f;
				rect.anchorMin = anchorMin;
			}
			if ((int)(rect.anchorMax[(int)axis] * Precision) != (int)(0.5f * Precision))
			{
				Vector2 anchorMax = rect.anchorMax;
				anchorMax[(int)axis] = 0.5f;
				rect.anchorMax = anchorMax;
			}
			if ((int)(rect.sizeDelta[(int)axis] * Precision) != (int)(size * Precision))
			{
				Vector2 sizeDelta = rect.sizeDelta;
				sizeDelta[(int)axis] = size;
				rect.sizeDelta = sizeDelta;
			}
			if ((int)(rect.anchoredPosition[(int)axis] * Precision) != (int)(inset * Precision))
			{
				Vector2 anchoredPosition = rect.anchoredPosition;
				anchoredPosition[(int)axis] = inset;
				rect.anchoredPosition = anchoredPosition;
			}
		}

		private static Vector2 GetParentSize(this RectTransform rect)
		{
			RectTransform rectTransform = rect.parent as RectTransform;
			if (!rectTransform)
			{
				return Vector2.zero;
			}
			return rectTransform.rect.size;
		}

		public static Rect GetScreenSpaceRect(this RectTransform transform)
		{
			Vector2 vector = Vector2.Scale(transform.rect.size, transform.lossyScale);
			Rect result = new Rect(transform.position.x, (float)Screen.height - transform.position.y, vector.x, vector.y);
			result.x -= transform.pivot.x * vector.x;
			result.y -= (1f - transform.pivot.y) * vector.y;
			return result;
		}
	}
}
