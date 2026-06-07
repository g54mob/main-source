using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class QuaternionExtensions
	{
		public static Quaternion Mirror(this Quaternion rotation, Vector3 planeNormal)
		{
			planeNormal = planeNormal.normalized;
			float num = 1E-06f;
			if (Mathf.Abs(planeNormal.x - 1f) < num || Mathf.Abs(planeNormal.x + 1f) < num)
			{
				Quaternion quaternion = new Quaternion(1f, 0f, 0f, 0f);
				return quaternion * rotation * quaternion;
			}
			if (Mathf.Abs(planeNormal.y - 1f) < num || Mathf.Abs(planeNormal.y + 1f) < num)
			{
				Quaternion quaternion2 = new Quaternion(0f, 1f, 0f, 0f);
				return quaternion2 * rotation * quaternion2;
			}
			if (Mathf.Abs(planeNormal.z - 1f) < num || Mathf.Abs(planeNormal.z + 1f) < num)
			{
				Quaternion quaternion3 = new Quaternion(0f, 0f, 1f, 0f);
				return quaternion3 * rotation * quaternion3;
			}
			Vector3 vector = Reflect(rotation * Vector3.forward);
			Vector3 lhs = Reflect(rotation * Vector3.up);
			Vector3 rhs = Vector3.Cross(lhs, vector);
			if (rhs.sqrMagnitude < 1E-20f)
			{
				rhs = Vector3.Cross((Mathf.Abs(vector.y) < 0.99f) ? Vector3.up : Vector3.right, vector);
			}
			rhs.Normalize();
			lhs = Vector3.Cross(vector, rhs);
			lhs.Normalize();
			vector.Normalize();
			Matrix4x4 m = default(Matrix4x4);
			m.SetColumn(0, new Vector4(rhs.x, rhs.y, rhs.z, 0f));
			m.SetColumn(1, new Vector4(lhs.x, lhs.y, lhs.z, 0f));
			m.SetColumn(2, new Vector4(vector.x, vector.y, vector.z, 0f));
			m.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
			return m.ToQuaternion();
			Vector3 Reflect(Vector3 v)
			{
				return v - 2f * Vector3.Dot(v, planeNormal) * planeNormal;
			}
		}

		public static Quaternion ToRotation(this Quaternion value, Quaternion to)
		{
			return to * Quaternion.Inverse(value);
		}
	}
}
