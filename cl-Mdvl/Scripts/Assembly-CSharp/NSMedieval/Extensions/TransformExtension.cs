using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Extensions
{
	public static class TransformExtension
	{
		public static int GetEulerAngleY(this Transform transform)
		{
			int i;
			for (i = (int)(transform.eulerAngles.y + 0.5f); i > 360; i -= 360)
			{
			}
			for (; i < 0; i += 360)
			{
			}
			return i;
		}

		public static Transform GetClosest(this IEnumerable<Transform> transforms, Vector3 targetPos)
		{
			Transform result = null;
			float num = float.PositiveInfinity;
			foreach (Transform transform in transforms)
			{
				float num2 = Vector3.Distance(transform.position, targetPos);
				if (num2 < num)
				{
					num = num2;
					result = transform;
				}
			}
			return result;
		}
	}
}
