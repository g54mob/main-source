using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class Matrix4x4Extensions
	{
		public static Quaternion ToQuaternion(this Matrix4x4 m)
		{
			float num = m.m00 + m.m11 + m.m22;
			Quaternion q = default(Quaternion);
			if (num > 0f)
			{
				float num2 = Mathf.Sqrt(num + 1f) * 2f;
				q.w = 0.25f * num2;
				q.x = (m.m21 - m.m12) / num2;
				q.y = (m.m02 - m.m20) / num2;
				q.z = (m.m10 - m.m01) / num2;
			}
			else if (m.m00 > m.m11 && m.m00 > m.m22)
			{
				float num3 = Mathf.Sqrt(1f + m.m00 - m.m11 - m.m22) * 2f;
				q.w = (m.m21 - m.m12) / num3;
				q.x = 0.25f * num3;
				q.y = (m.m01 + m.m10) / num3;
				q.z = (m.m02 + m.m20) / num3;
			}
			else if (m.m11 > m.m22)
			{
				float num4 = Mathf.Sqrt(1f + m.m11 - m.m00 - m.m22) * 2f;
				q.w = (m.m02 - m.m20) / num4;
				q.x = (m.m01 + m.m10) / num4;
				q.y = 0.25f * num4;
				q.z = (m.m12 + m.m21) / num4;
			}
			else
			{
				float num5 = Mathf.Sqrt(1f + m.m22 - m.m00 - m.m11) * 2f;
				q.w = (m.m10 - m.m01) / num5;
				q.x = (m.m02 + m.m20) / num5;
				q.y = (m.m12 + m.m21) / num5;
				q.z = 0.25f * num5;
			}
			return Quaternion.Normalize(q);
		}
	}
}
