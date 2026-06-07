using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class PyramidMath
	{
		public static List<Vector3> CalcBaseCornerPoints(Vector3 baseCenter, float baseWidth, float baseDepth, Quaternion rotation)
		{
			Vector3 vector = rotation * Vector3.right;
			Vector3 vector2 = rotation * Vector3.forward;
			float num = baseWidth * 0.5f;
			float num2 = baseDepth * 0.5f;
			return new List<Vector3>
			{
				baseCenter + vector * num + vector2 * num2,
				baseCenter + vector * num - vector2 * num2,
				baseCenter - vector * num - vector2 * num2,
				baseCenter - vector * num + vector2 * num2
			};
		}

		public static bool Raycast(Ray ray, out float t, Vector3 baseCenter, float baseWidth, float baseDepth, float height, Quaternion rotation)
		{
			t = 0f;
			ray = ray.InverseTransform(Matrix4x4.TRS(baseCenter, rotation, Vector3.one));
			if (!BoxMath.Raycast(boxSize: new Vector3(baseWidth, height, baseDepth), ray: ray, boxCenter: Vector3.up * height * 0.5f, boxRotation: Quaternion.identity))
			{
				return false;
			}
			List<float> list = new List<float>(5);
			Plane plane = new Plane(Vector3.up, Vector3.zero);
			float enter = 0f;
			if (plane.Raycast(ray, out enter) && QuadMath.Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, baseCenter, baseWidth, baseDepth, Vector3.right, Vector3.forward))
			{
				list.Add(enter);
			}
			float num = 0.5f * baseWidth;
			float num2 = 0.5f * baseDepth;
			Vector3 vector2;
			Vector3 vector = (vector2 = Vector3.up * height);
			Vector3 vector3 = Vector3.right * num - Vector3.forward * num2;
			Vector3 vector4 = vector3 - Vector3.right * baseWidth;
			if (new Plane(vector2, vector3, vector4).Raycast(ray, out enter) && TriangleMath.Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, vector2, vector3, vector4))
			{
				list.Add(enter);
			}
			vector2 = vector;
			vector3 = Vector3.right * num + Vector3.forward * num2;
			vector4 = vector3 - Vector3.forward * baseDepth;
			if (new Plane(vector2, vector3, vector4).Raycast(ray, out enter) && TriangleMath.Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, vector2, vector3, vector4))
			{
				list.Add(enter);
			}
			vector2 = vector;
			vector3 = -Vector3.right * num + Vector3.forward * num2;
			vector4 = vector3 + Vector3.right * baseWidth;
			if (new Plane(vector2, vector3, vector4).Raycast(ray, out enter) && TriangleMath.Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, vector2, vector3, vector4))
			{
				list.Add(enter);
			}
			vector2 = vector;
			vector3 = -Vector3.right * num - Vector3.forward * num2;
			vector4 = vector3 + Vector3.forward * baseDepth;
			if (new Plane(vector2, vector3, vector4).Raycast(ray, out enter) && TriangleMath.Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, vector2, vector3, vector4))
			{
				list.Add(enter);
			}
			if (list.Count == 0)
			{
				return false;
			}
			list.Sort((float num3, float value) => num3.CompareTo(value));
			t = list[0];
			return true;
		}

		public static bool ContainsPoint(Vector3 point, Vector3 baseCenter, float baseWidth, float baseDepth, float height, Quaternion rotation, PyramidEpsilon epsilon = default(PyramidEpsilon))
		{
			point = Matrix4x4.TRS(baseCenter, rotation, Vector3.one).inverse.MultiplyPoint(point);
			if (new Plane(-Vector3.up, Vector3.zero).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			float num = 0.5f * baseWidth;
			float num2 = 0.5f * baseDepth;
			Vector3 vector = Vector3.up * height;
			Vector3 a = vector;
			Vector3 vector2 = Vector3.right * num - Vector3.forward * num2;
			Vector3 c = vector2 - Vector3.right * baseWidth;
			if (new Plane(a, vector2, c).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			a = vector;
			vector2 = Vector3.right * num + Vector3.forward * num2;
			c = vector2 - Vector3.forward * baseDepth;
			if (new Plane(a, vector2, c).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			a = vector;
			vector2 = -Vector3.right * num + Vector3.forward * num2;
			c = vector2 + Vector3.right * baseWidth;
			if (new Plane(a, vector2, c).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			a = vector;
			vector2 = -Vector3.right * num - Vector3.forward * num2;
			c = vector2 + Vector3.forward * baseDepth;
			if (new Plane(a, vector2, c).GetDistanceToPoint(point) > epsilon.PtContainEps)
			{
				return false;
			}
			return true;
		}
	}
}
