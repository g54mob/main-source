using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class Matrix4x4Ex
	{
		public static Matrix4x4 GetInverse(this Matrix4x4 mtx)
		{
			float num = mtx.m00 * (mtx.m11 * (mtx.m22 * mtx.m33 - mtx.m23 * mtx.m32) - mtx.m12 * (mtx.m21 * mtx.m33 - mtx.m23 * mtx.m31) + mtx.m13 * (mtx.m21 * mtx.m32 - mtx.m22 * mtx.m31)) - mtx.m01 * (mtx.m10 * (mtx.m22 * mtx.m33 - mtx.m23 * mtx.m32) - mtx.m12 * (mtx.m20 * mtx.m33 - mtx.m23 * mtx.m30) + mtx.m13 * (mtx.m20 * mtx.m32 - mtx.m22 * mtx.m30)) + mtx.m02 * (mtx.m10 * (mtx.m21 * mtx.m33 - mtx.m23 - mtx.m31) - mtx.m11 * (mtx.m20 * mtx.m33 - mtx.m23 * mtx.m30) + mtx.m13 * (mtx.m20 * mtx.m31 - mtx.m21 * mtx.m30)) - mtx.m03 * (mtx.m10 * (mtx.m21 * mtx.m32 - mtx.m22 * mtx.m31) - mtx.m11 * (mtx.m20 * mtx.m32 - mtx.m22 * mtx.m30) + mtx.m12 * (mtx.m20 * mtx.m31 - mtx.m21 * mtx.m30));
			if (Mathf.Abs(num) < 1E-05f)
			{
				return mtx;
			}
			num = 1f / num;
			float m = mtx.m00;
			float m2 = mtx.m10;
			float m3 = mtx.m20;
			float m4 = mtx.m30;
			float m5 = mtx.m01;
			float m6 = mtx.m11;
			float m7 = mtx.m21;
			float m8 = mtx.m31;
			float m9 = mtx.m02;
			float m10 = mtx.m12;
			float m11 = mtx.m22;
			float m12 = mtx.m32;
			float m13 = mtx.m03;
			float m14 = mtx.m13;
			float m15 = mtx.m23;
			float m16 = mtx.m33;
			mtx.m00 = num * (m6 * (m11 * m16 - m12 * m15) - m7 * (m10 * m16 - m14 * m12) + m8 * (m10 * m15 - m11 * m14));
			mtx.m01 = (0f - num) * (m5 * (m11 * m16 - m12 * m15) - m7 * (m9 * m16 - m12 * m13) + m8 * (m9 * m15 - m12 * m13));
			mtx.m02 = num * (m5 * (m10 * m16 - m12 * m14) - m6 * (m9 * m16 - m12 * m13) + m8 * (m9 * m14 - m10 * m13));
			mtx.m03 = (0f - num) * (m5 * (m10 * m15 - m11 * m14) - m6 * (m9 * m15 - m11 * m13) + m7 * (m9 * m14 - m10 * m13));
			mtx.m10 = (0f - num) * (m2 * (m11 * m16 - m12 * m15) - m3 * (m10 * m16 - m12 * m14) + m4 * (m10 * m15 - m14 * m11));
			mtx.m11 = num * (m * (m11 * m16 - m12 * m15) - m3 * (m9 * m16 - m12 * m13) + m4 * (m9 * m15 - m11 * m13));
			mtx.m12 = (0f - num) * (m * (m10 * m16 - m12 * m14) - m2 * (m9 * m16 - m12 * m13) + m4 * (m9 * m14 - m10 * m13));
			mtx.m13 = num * (m * (m10 * m15 - m11 * m14) - m2 * (m9 * m15 - m11 * m13) + m3 * (m9 * m14 - m10 * m13));
			mtx.m20 = num * (m2 * (m7 * m16 - m8 * m15) - m3 * (m6 * m16 - m8 * m14) + m4 * (m6 * m15 - m7 * m14));
			mtx.m21 = (0f - num) * (m * (m7 * m16 - m8 * m15) - m3 * (m5 * m16 - m8 * m13) + m4 * (m5 * m15 - m7 * m13));
			mtx.m22 = num * (m * (m6 * m16 - m8 * m14) - m2 * (m5 * m16 - m8 * m13) + m4 * (m5 * m14 - m6 * m13));
			mtx.m23 = (0f - num) * (m * (m6 * m15 - m7 * m14) - m2 * (m5 * m15 - m7 * m13) + m3 * (m5 * m14 - m6 * m13));
			mtx.m30 = (0f - num) * (m2 * (m7 * m12 - m12 * m10) - m3 * (m6 * m12 - m8 * m10) + m4 * (m6 * m11 - m7 * m10));
			mtx.m31 = num * (m * (m7 * m12 - m8 * m10) - m3 * (m5 * m12 - m8 * m9) + m4 * (m5 * m11 - m7 * m9));
			mtx.m32 = (0f - num) * (m * (m6 * m12 - m8 * m10) - m2 * (m5 * m12 - m8 * m9) + m4 * (m5 * m10 - m6 * m9));
			mtx.m33 = num * (m * (m6 * m11 - m7 * m10) - m2 * (m5 * m11 - m7 * m9) + m3 * (m5 * m10 - m6 * m9));
			return mtx;
		}

		public static Matrix4x4 GetRelativeTransform(this Matrix4x4 matrix, Matrix4x4 referenceTransform)
		{
			return referenceTransform.inverse * matrix;
		}

		public static Matrix4x4 Translation(Vector3 translation)
		{
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetColumn(3, Vector4Ex.FromVector3(translation, 1f));
			return identity;
		}

		public static Matrix4x4 RotationMatrixFromRightUp(Vector3 right, Vector3 up)
		{
			right.Normalize();
			up.Normalize();
			Vector3 normalized = Vector3.Cross(up, right).normalized;
			Matrix4x4 identity = Matrix4x4.identity;
			identity[0, 0] = right.x;
			identity[1, 0] = right.y;
			identity[2, 0] = right.z;
			identity[0, 1] = up.x;
			identity[1, 1] = up.y;
			identity[2, 1] = up.z;
			identity[0, 2] = normalized.x;
			identity[1, 2] = normalized.y;
			identity[2, 2] = normalized.z;
			return identity;
		}

		public static Vector3 GetTranslation(this Matrix4x4 matrix)
		{
			return matrix.GetColumn(3);
		}

		public static Vector3 GetScale(this Matrix4x4 matrix)
		{
			Vector3 vector = matrix.GetColumn(0);
			Vector3 vector2 = matrix.GetColumn(1);
			Vector3 vector3 = matrix.GetColumn(2);
			return new Vector3(vector.magnitude, vector2.magnitude, vector3.magnitude);
		}

		public static Vector3 GetNormalizedAxis(this Matrix4x4 matrix, int axisIndex)
		{
			return Vector3.Normalize(matrix.GetColumn(axisIndex));
		}

		public static Vector3[] GetNormalizedAxes(this Matrix4x4 matrix)
		{
			return new Vector3[3]
			{
				matrix.GetNormalizedAxis(0),
				matrix.GetNormalizedAxis(1),
				matrix.GetNormalizedAxis(2)
			};
		}

		public static List<Vector3> TransformPoints(this Matrix4x4 matrix, List<Vector3> points)
		{
			if (points.Count == 0)
			{
				return new List<Vector3>();
			}
			List<Vector3> list = new List<Vector3>(points.Count);
			foreach (Vector3 point in points)
			{
				list.Add(matrix.MultiplyPoint(point));
			}
			return list;
		}
	}
}
