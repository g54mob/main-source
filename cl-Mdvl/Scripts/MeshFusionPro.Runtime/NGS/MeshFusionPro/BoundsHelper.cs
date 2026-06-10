using UnityEngine;

namespace NGS.MeshFusionPro
{
	public static class BoundsHelper
	{
		public static Bounds Transform(this Bounds bounds, Matrix4x4 transform)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			Vector4 column = transform.GetColumn(3);
			Vector3 vector = column;
			Vector3 vector2 = column;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					float num = transform[i, j];
					float num2 = num * min[j];
					float num3 = num * max[j];
					vector[i] += ((num2 < num3) ? num2 : num3);
					vector2[i] += ((num2 < num3) ? num3 : num2);
				}
			}
			return new Bounds
			{
				center = transform.MultiplyPoint3x4(bounds.center),
				size = vector2 - vector
			};
		}

		public static bool Contains(this Bounds bounds, Bounds target)
		{
			if (bounds.Contains(target.min))
			{
				return bounds.Contains(target.max);
			}
			return false;
		}
	}
}
