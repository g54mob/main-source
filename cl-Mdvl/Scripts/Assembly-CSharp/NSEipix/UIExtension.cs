using UnityEngine;

namespace NSEipix
{
	public static class UIExtension
	{
		public static Vector2 GetScreenSize(this RectTransform transform)
		{
			Vector3[] array = new Vector3[4];
			transform.GetWorldCorners(array);
			Vector3 vector = Camera.main.WorldToScreenPoint(array[0]) - Camera.main.WorldToScreenPoint(array[2]);
			return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
		}

		public static Vector2 GetWorldSize(this RectTransform transform)
		{
			Vector3[] array = new Vector3[4];
			transform.GetWorldCorners(array);
			return new Vector2(Mathf.Abs(array[0].x - array[2].x), Mathf.Abs(array[0].y - array[2].y));
		}

		public static Vector2 GetWorldSizeNonAlloc(this RectTransform transform, ref Vector3[] corners)
		{
			transform.GetWorldCorners(corners);
			return new Vector2(Mathf.Abs(corners[0].x - corners[2].x), Mathf.Abs(corners[0].y - corners[2].y));
		}
	}
}
