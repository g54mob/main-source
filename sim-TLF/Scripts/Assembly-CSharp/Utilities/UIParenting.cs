using UnityEngine;

namespace Utilities
{
	public static class UIParenting
	{
		public static void SetParentKeepSizeOnly(RectTransform child, RectTransform newParent)
		{
			Vector3[] array = new Vector3[4];
			child.GetWorldCorners(array);
			child.SetParent(newParent, worldPositionStays: true);
			Vector2 vector = newParent.InverseTransformPoint(array[0]);
			Vector2 vector2 = newParent.InverseTransformPoint(array[2]);
			child.sizeDelta = vector2 - vector;
		}
	}
}
