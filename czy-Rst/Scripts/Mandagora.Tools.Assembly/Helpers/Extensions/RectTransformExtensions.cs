using UnityEngine;

namespace Helpers.Extensions
{
	public static class RectTransformExtensions
	{
		public static bool ContainsRectTransform(this RectTransform rectTransform, RectTransform other, int safeSpace = 0)
		{
			return rectTransform.GetWorldRect().ContainsRectTransform(other, safeSpace);
		}

		public static bool ContainsRectTransform(this Rect rect, RectTransform other, int safeSpace = 0)
		{
			Rect worldRect = other.GetWorldRect();
			if (rect.xMin <= worldRect.xMin + (float)safeSpace && rect.yMin <= worldRect.yMin + (float)safeSpace && rect.xMax >= worldRect.xMax - (float)safeSpace)
			{
				return rect.yMax >= worldRect.yMax - (float)safeSpace;
			}
			return false;
		}

		public static Rect GetWorldRect(this RectTransform rectTransform)
		{
			Rect rect = rectTransform.rect;
			float x = rect.x;
			float y = rect.y;
			float xMax = rect.xMax;
			float yMax = rect.yMax;
			Vector2 vector = new Vector3(x, y, 0f);
			Vector2 vector2 = new Vector3(xMax, yMax, 0f);
			Matrix4x4 localToWorldMatrix = rectTransform.transform.localToWorldMatrix;
			vector = localToWorldMatrix.MultiplyPoint(vector);
			vector2 = localToWorldMatrix.MultiplyPoint(vector2);
			Vector2 size = vector2 - vector;
			return new Rect(vector, size);
		}

		public static void SetPivotSamePosition(this RectTransform rectTransform, Vector2 pivot)
		{
			Vector3 vector = rectTransform.pivot - pivot;
			vector.Scale(rectTransform.rect.size);
			vector.Scale(rectTransform.localScale);
			vector = rectTransform.rotation * vector;
			rectTransform.pivot = pivot;
			rectTransform.localPosition -= vector;
		}
	}
}
