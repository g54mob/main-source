using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class RectTransformExtensions
	{
		public static Rect GetWorldRect(this RectTransform rectTransform)
		{
			Vector3[] array = new Vector3[4];
			rectTransform.GetWorldCorners(array);
			return new Rect(array[0], array[2] - array[0]);
		}
	}
}
