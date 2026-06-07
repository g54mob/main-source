using UnityEngine;

namespace LeTai.Common
{
	public static class RectTransformUtilityPatch
	{
		public static Ray ScreenPointToRay(Camera cam, Vector2 screenPos)
		{
			return default(Ray);
		}

		public static bool ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector3 worldPoint)
		{
			worldPoint = default(Vector3);
			return false;
		}

		public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint)
		{
			localPoint = default(Vector2);
			return false;
		}
	}
}
