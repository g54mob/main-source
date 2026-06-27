using UnityEngine;

namespace Helpers.Extensions
{
	public static class TransformExtensions
	{
		public static bool Contains(this Transform transform, Transform other)
		{
			if (transform == other)
			{
				return true;
			}
			foreach (Transform item in transform)
			{
				if (item == other || item.Contains(other))
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsInParent(this Transform transform, Transform other)
		{
			Transform transform2 = transform;
			while (transform2 != null)
			{
				if (transform2 == other)
				{
					return true;
				}
				transform2 = transform2.parent;
			}
			return false;
		}

		public static int GetNestingDepth(this Transform self)
		{
			int num = -1;
			Transform transform = self;
			while ((bool)transform)
			{
				num++;
				transform = transform.parent;
			}
			return num;
		}

		public static Vector3Int GetRotatedBoundsSize(this Transform forTransform, Vector3Int boundSize)
		{
			Vector3Int vector3Int = Vector3Int.RoundToInt(forTransform.rotation * boundSize);
			return new Vector3Int
			{
				x = Mathf.Max(Mathf.Abs(vector3Int.x), 1),
				y = Mathf.Max(Mathf.Abs(vector3Int.y), 1),
				z = Mathf.Max(Mathf.Abs(vector3Int.z), 1)
			};
		}

		public static void SetEulerAngleToMultipleAxisY(this Transform forTransform, float multiplyAngle = 90f)
		{
			float eulerAngleMultipleAxisY = forTransform.GetEulerAngleMultipleAxisY(multiplyAngle);
			Vector3 eulerAngles = forTransform.eulerAngles;
			forTransform.eulerAngles = new Vector3(eulerAngles.x, eulerAngleMultipleAxisY, eulerAngles.z);
		}

		public static float GetEulerAngleMultipleAxisY(this Transform forTransform, float multiplyAngle = 90f)
		{
			return Mathf.Round(forTransform.eulerAngles.y / multiplyAngle) * multiplyAngle;
		}
	}
}
