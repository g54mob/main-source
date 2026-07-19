using System;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	public static class Matrix4x4Extensions
	{
		public static void CalcYawPitch(this Matrix4x4 m, Vector3 target, out float yaw, out float pitch)
		{
			Vector3 vector = Vector3.Project(target, m.GetColumn(2));
			Vector3 lhs = Vector3.Project(target, m.GetColumn(1));
			Vector3 vector2 = Vector3.Project(target, m.GetColumn(0));
			float num = ((Vector3.Dot(vector2, m.GetColumn(0)) > 0f) ? 1f : (-1f));
			yaw = (float)Math.Atan2(vector2.magnitude, vector.magnitude) * num * 57.29578f;
			float num2 = ((Vector3.Dot(lhs, m.GetColumn(1)) > 0f) ? 1f : (-1f));
			pitch = (float)Math.Atan2(lhs.magnitude, (vector2 + vector).magnitude) * num2 * 57.29578f;
		}

		public static Quaternion YawPitchRotation(this Matrix4x4 m, float yaw, float pitch)
		{
			return Quaternion.AngleAxis(yaw, m.GetColumn(1)) * Quaternion.AngleAxis(0f - pitch, m.GetColumn(0));
		}

		public static Matrix4x4 RotationToWorldAxis(this Matrix4x4 m)
		{
			return UnityExtensions.Matrix4x4FromColumns(m.MultiplyVector(Vector3.right), m.MultiplyVector(Vector3.up), m.MultiplyVector(Vector3.forward), new Vector4(0f, 0f, 0f, 1f));
		}
	}
}
