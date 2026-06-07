using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class QuaternionEx
	{
		public static void RotatePoints(this Quaternion quat, List<Vector3> points, Vector3 pivot)
		{
			for (int i = 0; i < points.Count; i++)
			{
				Vector3 vector = points[i] - pivot;
				vector = quat * vector;
				points[i] = pivot + vector;
			}
		}

		public static Quaternion GetRelativeRotation(Quaternion from, Quaternion to)
		{
			return Quaternion.Inverse(from) * to;
		}

		public static float Length(this Quaternion quat)
		{
			return Mathf.Sqrt(quat.x * quat.x + quat.y * quat.y + quat.z * quat.z + quat.w * quat.w);
		}

		public static Quaternion Normalize(Quaternion quat)
		{
			float num = quat.Length();
			if (num < 1E-05f)
			{
				return quat;
			}
			num = 1f / num;
			return new Quaternion(quat.x * num, quat.y * num, quat.z * num, quat.w * num);
		}

		public static Quaternion FromToRotation3D(Vector3 from, Vector3 to, Vector3 perp180)
		{
			from = from.normalized;
			to = to.normalized;
			float num = Vector3.Dot(from, to);
			if (1f - num < 1E-05f)
			{
				return Quaternion.identity;
			}
			if (1f + num < 1E-05f)
			{
				return Quaternion.AngleAxis(180f, perp180);
			}
			float angle = MathEx.SafeAcos(num) * 57.29578f;
			Vector3 normalized = Vector3.Cross(from, to).normalized;
			return Quaternion.AngleAxis(angle, normalized);
		}

		public static Quaternion FromToRotation2D(Vector2 from, Vector2 to)
		{
			from = from.normalized;
			to = to.normalized;
			float num = Vector2.Dot(from, to);
			if (1f - num < 1E-05f)
			{
				return Quaternion.identity;
			}
			if (1f + num < 1E-05f)
			{
				return Quaternion.AngleAxis(180f, Vector3.forward);
			}
			float angle = MathEx.SafeAcos(num) * 57.29578f;
			Vector3 normalized = Vector3.Cross(from, to).normalized;
			return Quaternion.AngleAxis(angle, normalized);
		}

		public static float ConvertTo2DRotation(this Quaternion quat)
		{
			quat.ToAngleAxis(out var angle, out var axis);
			if (Vector3.Dot(Vector3.forward, axis) < 0f)
			{
				return 0f - angle;
			}
			return angle;
		}
	}
}
