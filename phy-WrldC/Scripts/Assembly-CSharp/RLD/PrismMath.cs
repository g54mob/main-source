using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class PrismMath
	{
		public static List<Vector3> CalcTriangPrismCornerPoints(Vector3 baseCenter, float baseWidth, float baseDepth, float topWidth, float topDepth, float height, Quaternion prismRotation)
		{
			float num = baseWidth * 0.5f;
			float num2 = baseDepth * 0.5f;
			float num3 = topWidth * 0.5f;
			float num4 = topDepth * 0.5f;
			Vector3 vector = -Vector3.forward * num2 - Vector3.right * num;
			Vector3 point = vector + Vector3.right * baseWidth;
			Vector3 point2 = Vector3.forward * num2;
			Vector3 vector2 = Vector3.up * height;
			Vector3 vector3 = vector2 - Vector3.forward * num4 - Vector3.right * num3;
			Vector3 point3 = vector2 + Vector3.forward * num4;
			Vector3 point4 = vector3 + Vector3.right * topWidth;
			List<Vector3> list = new List<Vector3>(6);
			Matrix4x4 matrix4x = Matrix4x4.TRS(baseCenter, prismRotation, Vector3.one);
			list.Add(matrix4x.MultiplyPoint(vector));
			list.Add(matrix4x.MultiplyPoint(point));
			list.Add(matrix4x.MultiplyPoint(point2));
			list.Add(matrix4x.MultiplyPoint(vector3));
			list.Add(matrix4x.MultiplyPoint(point3));
			list.Add(matrix4x.MultiplyPoint(point4));
			return list;
		}

		public static bool RaycastTriangular(Ray ray, out float t, Vector3 baseCenter, float baseWidth, float baseDepth, float topWidth, float topDepth, float height, Quaternion prismRotation)
		{
			t = 0f;
			if (baseWidth == 0f || baseDepth == 0f || topWidth == 0f || topDepth == 0f || height == 0f)
			{
				return false;
			}
			baseWidth = Mathf.Abs(baseWidth);
			baseDepth = Mathf.Abs(baseDepth);
			topWidth = Mathf.Abs(topWidth);
			topDepth = Mathf.Abs(topDepth);
			ray = ray.InverseTransform(Matrix4x4.TRS(baseCenter, prismRotation, Vector3.one));
			Vector3 boxSize = Vector3.Max(new Vector3(baseWidth, height, baseDepth), new Vector3(topWidth, height, topDepth));
			if (!BoxMath.Raycast(ray, Vector3.up * height * 0.5f, boxSize, Quaternion.identity))
			{
				return false;
			}
			List<Vector3> list = CalcTriangPrismCornerPoints(Vector3.zero, baseWidth, baseDepth, topWidth, topDepth, height, Quaternion.identity);
			Vector3 vector = list[0];
			Vector3 vector2 = list[1];
			Vector3 vector3 = list[2];
			Vector3 vector4 = list[3];
			Vector3 vector5 = list[5];
			Vector3 vector6 = list[4];
			List<float> list2 = new List<float>(5);
			if (TriangleMath.Raycast(ray, out var t2, vector, vector2, vector3))
			{
				list2.Add(t2);
			}
			if (TriangleMath.Raycast(ray, out t2, vector4, vector6, vector5))
			{
				list2.Add(t2);
			}
			List<Vector3> list3 = new List<Vector3>(4) { vector, vector4, vector5, vector2 };
			Vector3 normalized = Vector3.Cross(list3[1] - list3[0], list3[3] - list3[0]).normalized;
			if (PolygonMath.Raycast(ray, out t2, list3, isClosed: false, normalized))
			{
				list2.Add(t2);
			}
			list3[1] = vector3;
			list3[2] = vector6;
			list3[3] = vector4;
			normalized = Vector3.Cross(list3[1] - list3[0], list3[3] - list3[0]).normalized;
			if (PolygonMath.Raycast(ray, out t2, list3, isClosed: false, normalized))
			{
				list2.Add(t2);
			}
			list3[0] = vector2;
			list3[1] = vector5;
			list3[3] = vector3;
			normalized = Vector3.Cross(list3[1] - list3[0], list3[3] - list3[0]).normalized;
			if (PolygonMath.Raycast(ray, out t2, list3, isClosed: false, normalized))
			{
				list2.Add(t2);
			}
			if (list2.Count == 0)
			{
				return false;
			}
			list2.Sort((float num, float value) => num.CompareTo(value));
			t = list2[0];
			return true;
		}

		public static bool ContainsPoint(Vector3 point, Vector3 baseCenter, float baseWidth, float baseDepth, float topWidth, float topDepth, float height, Quaternion prismRotation, PrismEpsilon epsilon = default(PrismEpsilon))
		{
			point = Matrix4x4.TRS(baseCenter, prismRotation, Vector3.one).inverse.MultiplyPoint(point);
			List<Vector3> list = CalcTriangPrismCornerPoints(Vector3.zero, baseWidth, baseDepth, topWidth, topDepth, height, Quaternion.identity);
			Vector3 vector = list[0];
			Vector3 a = list[1];
			Vector3 vector2 = list[2];
			Vector3 c = list[3];
			Vector3 b = list[5];
			Vector3 vector3 = list[4];
			if (new Plane(Vector3.up, vector3).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			if (new Plane(-Vector3.up, vector2).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			if (new Plane(vector, vector2, vector3).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			if (new Plane(a, b, vector3).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			if (new Plane(a, vector, c).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			return true;
		}
	}
}
