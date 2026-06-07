using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class BoxMath
	{
		private static List<BoxFace> _allBoxFaces;

		private static Vector3[] A;

		private static Vector3[] B;

		private static float[,] R;

		private static float[,] absR;

		public static List<BoxFace> AllBoxFaces => new List<BoxFace>(_allBoxFaces);

		static BoxMath()
		{
			_allBoxFaces = new List<BoxFace>();
			A = new Vector3[3];
			B = new Vector3[3];
			R = new float[3, 3];
			absR = new float[3, 3];
			_allBoxFaces.Add(BoxFace.Front);
			_allBoxFaces.Add(BoxFace.Back);
			_allBoxFaces.Add(BoxFace.Left);
			_allBoxFaces.Add(BoxFace.Right);
			_allBoxFaces.Add(BoxFace.Bottom);
			_allBoxFaces.Add(BoxFace.Top);
		}

		public static int GetFaceAxisIndex(BoxFace face)
		{
			switch (face)
			{
			case BoxFace.Bottom:
			case BoxFace.Top:
				return 1;
			case BoxFace.Left:
			case BoxFace.Right:
				return 0;
			case BoxFace.Front:
			case BoxFace.Back:
				return 2;
			default:
				return -1;
			}
		}

		public static BoxFaceDesc GetFaceClosestToPoint(Vector3 point, Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation)
		{
			float num = float.MaxValue;
			Plane plane = default(Plane);
			BoxFace boxFace = BoxFace.Front;
			foreach (BoxFace allBoxFace in AllBoxFaces)
			{
				Plane plane2 = CalcBoxFacePlane(boxCenter, boxSize, boxRotation, allBoxFace);
				float absDistanceToPoint = plane2.GetAbsDistanceToPoint(point);
				if (absDistanceToPoint < num)
				{
					boxFace = allBoxFace;
					plane = plane2;
					num = absDistanceToPoint;
				}
			}
			return new BoxFaceDesc
			{
				Face = boxFace,
				Plane = plane,
				Center = CalcBoxFaceCenter(boxCenter, boxSize, boxRotation, boxFace)
			};
		}

		public static BoxFaceDesc GetFaceClosestToPoint(Vector3 point, Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, Vector3 viewVector)
		{
			float num = float.MaxValue;
			Plane plane = default(Plane);
			BoxFace boxFace = BoxFace.Front;
			foreach (BoxFace allBoxFace in AllBoxFaces)
			{
				Plane plane2 = CalcBoxFacePlane(boxCenter, boxSize, boxRotation, allBoxFace);
				if (!(Vector3.Dot(viewVector, plane2.normal) >= 0f))
				{
					float absDistanceToPoint = plane2.GetAbsDistanceToPoint(point);
					if (absDistanceToPoint < num)
					{
						boxFace = allBoxFace;
						plane = plane2;
						num = absDistanceToPoint;
					}
				}
			}
			return new BoxFaceDesc
			{
				Face = boxFace,
				Plane = plane,
				Center = CalcBoxFaceCenter(boxCenter, boxSize, boxRotation, boxFace)
			};
		}

		public static BoxFace GetMostAlignedFace(Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, Vector3 direction)
		{
			List<BoxFace> allBoxFaces = AllBoxFaces;
			int index = 0;
			float num = Vector3.Dot(direction, CalcBoxFaceNormal(boxCenter, boxSize, boxRotation, allBoxFaces[0]));
			for (int i = 1; i < allBoxFaces.Count; i++)
			{
				float num2 = Vector3.Dot(direction, CalcBoxFaceNormal(boxCenter, boxSize, boxRotation, allBoxFaces[i]));
				if (num2 > num)
				{
					num = num2;
					index = i;
				}
			}
			return allBoxFaces[index];
		}

		public static Vector3 CalcBoxFaceSize(Vector3 boxSize, BoxFace boxFace)
		{
			Vector3 result = boxSize;
			switch (boxFace)
			{
			case BoxFace.Front:
			case BoxFace.Back:
				result.z = 0f;
				break;
			case BoxFace.Left:
			case BoxFace.Right:
				result.x = 0f;
				break;
			default:
				result.y = 0f;
				break;
			}
			return result;
		}

		public static BoxFaceAreaDesc GetBoxFaceAreaDesc(Vector3 boxSize, BoxFace boxFace)
		{
			switch (boxFace)
			{
			case BoxFace.Front:
			case BoxFace.Back:
			{
				float num3 = boxSize.x * boxSize.y;
				if (num3 < 1E-06f)
				{
					return new BoxFaceAreaDesc(BoxFaceAreaType.Line, Mathf.Max(boxSize.x, boxSize.y));
				}
				return new BoxFaceAreaDesc(BoxFaceAreaType.Quad, num3);
			}
			case BoxFace.Left:
			case BoxFace.Right:
			{
				float num2 = boxSize.y * boxSize.z;
				if (num2 < 1E-06f)
				{
					return new BoxFaceAreaDesc(BoxFaceAreaType.Line, Mathf.Max(boxSize.y, boxSize.z));
				}
				return new BoxFaceAreaDesc(BoxFaceAreaType.Quad, num2);
			}
			default:
			{
				float num = boxSize.x * boxSize.z;
				if (num < 1E-06f)
				{
					return new BoxFaceAreaDesc(BoxFaceAreaType.Line, Mathf.Max(boxSize.x, boxSize.z));
				}
				return new BoxFaceAreaDesc(BoxFaceAreaType.Quad, num);
			}
			}
		}

		public static Plane CalcBoxFacePlane(Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, BoxFace boxFace)
		{
			Vector3 vector = boxSize * 0.5f;
			Vector3 vector2 = boxRotation * Vector3.right;
			Vector3 vector3 = boxRotation * Vector3.up;
			Vector3 vector4 = boxRotation * Vector3.forward;
			switch (boxFace)
			{
			case BoxFace.Front:
				return new Plane(-vector4, boxCenter - vector4 * vector.z);
			case BoxFace.Back:
				return new Plane(vector4, boxCenter + vector4 * vector.z);
			case BoxFace.Left:
				return new Plane(-vector2, boxCenter - vector2 * vector.x);
			case BoxFace.Right:
				return new Plane(vector2, boxCenter + vector2 * vector.x);
			case BoxFace.Bottom:
				return new Plane(-vector3, boxCenter - vector3 * vector.y);
			default:
				return new Plane(vector3, boxCenter + vector3 * vector.y);
			}
		}

		public static Vector3 CalcBoxFaceNormal(Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, BoxFace boxFace)
		{
			Vector3 vector = boxRotation * Vector3.right;
			Vector3 vector2 = boxRotation * Vector3.up;
			Vector3 vector3 = boxRotation * Vector3.forward;
			switch (boxFace)
			{
			case BoxFace.Front:
				return -vector3;
			case BoxFace.Back:
				return vector3;
			case BoxFace.Left:
				return -vector;
			case BoxFace.Right:
				return vector;
			case BoxFace.Bottom:
				return -vector2;
			default:
				return vector2;
			}
		}

		public static Vector3 CalcBoxFaceCenter(Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, BoxFace boxFace)
		{
			Vector3 vector = boxSize * 0.5f;
			Vector3 vector2 = boxRotation * Vector3.right;
			Vector3 vector3 = boxRotation * Vector3.up;
			Vector3 vector4 = boxRotation * Vector3.forward;
			switch (boxFace)
			{
			case BoxFace.Front:
				return boxCenter - vector4 * vector.z;
			case BoxFace.Back:
				return boxCenter + vector4 * vector.z;
			case BoxFace.Left:
				return boxCenter - vector2 * vector.x;
			case BoxFace.Right:
				return boxCenter + vector2 * vector.x;
			case BoxFace.Bottom:
				return boxCenter - vector3 * vector.y;
			default:
				return boxCenter + vector3 * vector.y;
			}
		}

		public static List<Vector3> CalcBoxCornerPoints(Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation)
		{
			Vector3 vector = boxSize * 0.5f;
			Vector3 vector2 = boxRotation * Vector3.right;
			Vector3 vector3 = boxRotation * Vector3.up;
			Vector3 vector4 = boxRotation * Vector3.forward;
			Vector3[] array = new Vector3[8];
			Vector3 vector5 = boxCenter - vector4 * vector.z;
			array[0] = vector5 - vector2 * vector.x + vector3 * vector.y;
			array[1] = vector5 + vector2 * vector.x + vector3 * vector.y;
			array[2] = vector5 + vector2 * vector.x - vector3 * vector.y;
			array[3] = vector5 - vector2 * vector.x - vector3 * vector.y;
			vector5 = boxCenter + vector4 * vector.z;
			array[4] = vector5 + vector2 * vector.x + vector3 * vector.y;
			array[5] = vector5 - vector2 * vector.x + vector3 * vector.y;
			array[6] = vector5 - vector2 * vector.x - vector3 * vector.y;
			array[7] = vector5 + vector2 * vector.x - vector3 * vector.y;
			return new List<Vector3>(array);
		}

		public static void TransformBox(Vector3 boxCenter, Vector3 boxSize, Matrix4x4 transformMatrix, out Vector3 newBoxCenter, out Vector3 newBoxSize)
		{
			Vector3 vector = transformMatrix.GetColumn(0);
			Vector3 vector2 = transformMatrix.GetColumn(1);
			Vector3 vector3 = transformMatrix.GetColumn(2);
			Vector3 vector4 = boxSize * 0.5f;
			Vector3 vector5 = vector * vector4.x;
			Vector3 vector6 = vector2 * vector4.y;
			Vector3 vector7 = vector3 * vector4.z;
			float x = Mathf.Abs(vector5.x) + Mathf.Abs(vector6.x) + Mathf.Abs(vector7.x);
			float y = Mathf.Abs(vector5.y) + Mathf.Abs(vector6.y) + Mathf.Abs(vector7.y);
			float z = Mathf.Abs(vector5.z) + Mathf.Abs(vector6.z) + Mathf.Abs(vector7.z);
			newBoxCenter = transformMatrix.MultiplyPoint(boxCenter);
			newBoxSize = new Vector3(x, y, z) * 2f;
		}

		public static bool BoxIntersectsBox(Vector3 center0, Vector3 size0, Quaternion rotation0, Vector3 center1, Vector3 size1, Quaternion rotation1)
		{
			A[0] = rotation0 * Vector3.right;
			A[1] = rotation0 * Vector3.up;
			A[2] = rotation0 * Vector3.forward;
			B[0] = rotation1 * Vector3.right;
			B[1] = rotation1 * Vector3.up;
			B[2] = rotation1 * Vector3.forward;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					R[i, j] = Vector3.Dot(A[i], B[j]);
				}
			}
			Vector3 vector = size0 * 0.5f;
			Vector3 vector2 = new Vector3(vector.x, vector.y, vector.z);
			vector = size1 * 0.5f;
			Vector3 vector3 = new Vector3(vector.x, vector.y, vector.z);
			for (int k = 0; k < 3; k++)
			{
				for (int l = 0; l < 3; l++)
				{
					absR[k, l] = Mathf.Abs(R[k, l]) + 0.0001f;
				}
			}
			Vector3 lhs = center1 - center0;
			Vector3 vector4 = new Vector3(Vector3.Dot(lhs, A[0]), Vector3.Dot(lhs, A[1]), Vector3.Dot(lhs, A[2]));
			for (int m = 0; m < 3; m++)
			{
				float num = vector3[0] * absR[m, 0] + vector3[1] * absR[m, 1] + vector3[2] * absR[m, 2];
				if (Mathf.Abs(vector4[m]) > vector2[m] + num)
				{
					return false;
				}
			}
			for (int n = 0; n < 3; n++)
			{
				float num2 = vector2[0] * absR[0, n] + vector2[1] * absR[1, n] + vector2[2] * absR[2, n];
				if (Mathf.Abs(vector4[0] * R[0, n] + vector4[1] * R[1, n] + vector4[2] * R[2, n]) > num2 + vector3[n])
				{
					return false;
				}
			}
			float num3 = vector2[1] * absR[2, 0] + vector2[2] * absR[1, 0];
			float num4 = vector3[1] * absR[0, 2] + vector3[2] * absR[0, 1];
			if (Mathf.Abs(vector4[2] * R[1, 0] - vector4[1] * R[2, 0]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[1] * absR[2, 1] + vector2[2] * absR[1, 1];
			num4 = vector3[0] * absR[0, 2] + vector3[2] * absR[0, 0];
			if (Mathf.Abs(vector4[2] * R[1, 1] - vector4[1] * R[2, 1]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[1] * absR[2, 2] + vector2[2] * absR[1, 2];
			num4 = vector3[0] * absR[0, 1] + vector3[1] * absR[0, 0];
			if (Mathf.Abs(vector4[2] * R[1, 2] - vector4[1] * R[2, 2]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[0] * absR[2, 0] + vector2[2] * absR[0, 0];
			num4 = vector3[1] * absR[1, 2] + vector3[2] * absR[1, 1];
			if (Mathf.Abs(vector4[0] * R[2, 0] - vector4[2] * R[0, 0]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[0] * absR[2, 1] + vector2[2] * absR[0, 1];
			num4 = vector3[0] * absR[1, 2] + vector3[2] * absR[1, 0];
			if (Mathf.Abs(vector4[0] * R[2, 1] - vector4[2] * R[0, 1]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[0] * absR[2, 2] + vector2[2] * absR[0, 2];
			num4 = vector3[0] * absR[1, 1] + vector3[1] * absR[1, 0];
			if (Mathf.Abs(vector4[0] * R[2, 2] - vector4[2] * R[0, 2]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[0] * absR[1, 0] + vector2[1] * absR[0, 0];
			num4 = vector3[1] * absR[2, 2] + vector3[2] * absR[2, 1];
			if (Mathf.Abs(vector4[1] * R[0, 0] - vector4[0] * R[1, 0]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[0] * absR[1, 1] + vector2[1] * absR[0, 1];
			num4 = vector3[0] * absR[2, 2] + vector3[2] * absR[2, 0];
			if (Mathf.Abs(vector4[1] * R[0, 1] - vector4[0] * R[1, 1]) > num3 + num4)
			{
				return false;
			}
			num3 = vector2[0] * absR[1, 2] + vector2[1] * absR[0, 2];
			num4 = vector3[0] * absR[2, 1] + vector3[1] * absR[2, 0];
			if (Mathf.Abs(vector4[1] * R[0, 2] - vector4[0] * R[1, 2]) > num3 + num4)
			{
				return false;
			}
			return true;
		}

		public static Vector3 CalcBoxPtClosestToPt(Vector3 point, Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation)
		{
			Vector3 rhs = point - boxCenter;
			Vector3[] array = new Vector3[3]
			{
				boxRotation * Vector3.right,
				boxRotation * Vector3.up,
				boxRotation * Vector3.forward
			};
			Vector3 vector = boxSize * 0.5f;
			Vector3 result = boxCenter;
			for (int i = 0; i < 3; i++)
			{
				float num = Vector3.Dot(array[i], rhs);
				if (num > vector[i])
				{
					num = vector[i];
				}
				else if (num < 0f - vector[i])
				{
					num = 0f - vector[i];
				}
				result += array[i] * num;
			}
			return result;
		}

		public static bool Raycast(Ray ray, Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, BoxEpsilon epsilon = default(BoxEpsilon))
		{
			float t;
			return Raycast(ray, out t, boxCenter, boxSize, boxRotation, epsilon);
		}

		public static bool Raycast(Ray ray, out float t, Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, BoxEpsilon epsilon = default(BoxEpsilon))
		{
			t = 0f;
			boxSize += epsilon.SizeEps;
			int num = 0;
			if (boxSize.x < 1E-06f)
			{
				num++;
			}
			if (boxSize.y < 1E-06f)
			{
				num++;
			}
			if (boxSize.z < 1E-06f)
			{
				num++;
			}
			if (num > 1)
			{
				return false;
			}
			if (num == 1)
			{
				if (boxSize.x < 1E-06f)
				{
					Vector3 quadRight = boxRotation * Vector3.forward;
					Vector3 quadUp = boxRotation * Vector3.up;
					return QuadMath.Raycast(ray, out t, boxCenter, boxSize.z, boxSize.y, quadRight, quadUp);
				}
				if (boxSize.y < 1E-06f)
				{
					Vector3 quadRight2 = boxRotation * Vector3.right;
					Vector3 quadUp2 = boxRotation * Vector3.forward;
					return QuadMath.Raycast(ray, out t, boxCenter, boxSize.x, boxSize.z, quadRight2, quadUp2);
				}
				Vector3 quadRight3 = boxRotation * Vector3.right;
				Vector3 quadUp3 = boxRotation * Vector3.up;
				return QuadMath.Raycast(ray, out t, boxCenter, boxSize.x, boxSize.y, quadRight3, quadUp3);
			}
			Matrix4x4 transformMatrix = Matrix4x4.TRS(boxCenter, boxRotation, boxSize);
			Ray ray2 = ray.InverseTransform(transformMatrix);
			if (ray2.direction.sqrMagnitude == 0f)
			{
				return false;
			}
			if (new Bounds(Vector3.zero, Vector3.one).IntersectRay(ray2, out t))
			{
				Vector3 vector = transformMatrix.MultiplyPoint(ray2.GetPoint(t));
				t = (vector - ray.origin).magnitude;
				return true;
			}
			return false;
		}

		public static bool ContainsPoint(Vector3 point, Vector3 boxCenter, Vector3 boxSize, Quaternion boxRotation, BoxEpsilon epsilon = default(BoxEpsilon))
		{
			boxSize += epsilon.SizeEps;
			point = Matrix4x4.TRS(boxCenter, boxRotation, boxSize).inverse.MultiplyPoint(point);
			if (point.x >= -0.5f && point.x <= 0.5f && point.y >= -0.5f && point.y <= 0.5f && point.z >= -0.5f)
			{
				return point.z <= 0.5f;
			}
			return false;
		}
	}
}
