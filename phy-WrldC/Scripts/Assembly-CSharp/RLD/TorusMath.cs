using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class TorusMath
	{
		public static float CalcSphereRadius(float torusCoreRadius, float torusTubeRadius)
		{
			return torusCoreRadius + torusTubeRadius;
		}

		public static AABB CalcCylModelAABB(float torusCoreRadius, float torusHrzRadius, float torusVertRadius)
		{
			float num = (torusCoreRadius + torusHrzRadius) * 2f;
			return new AABB(size: new Vector3(num, torusVertRadius * 2f, num), center: Vector3.zero);
		}

		public static AABB CalcCylAABB(Vector3 torusCenter, float torusCoreRadius, float torusHrzRadius, float torusVertRadius, Quaternion torusRotation)
		{
			AABB result = CalcCylModelAABB(torusCoreRadius, torusHrzRadius, torusVertRadius);
			result.Transform(Matrix4x4.TRS(torusCenter, torusRotation, Vector3.one));
			return result;
		}

		public static List<Vector3> Calc3DHrzExtentPoints(Vector3 torusCenter, float torusCoreRadius, float torusTubeRadius, Quaternion torusRotation)
		{
			Vector3 vector = torusRotation * Vector3.right;
			Vector3 vector2 = torusRotation * Vector3.forward;
			float num = torusCoreRadius + torusTubeRadius;
			return new List<Vector3>
			{
				torusCenter - vector * num,
				torusCenter + vector2 * num,
				torusCenter + vector * num,
				torusCenter - vector2 * num
			};
		}

		public static bool Raycast(Ray ray, out float t, Vector3 torusCenter, float torusCoreRadius, float torusTubeRadius, Quaternion torusRotation, TorusEpsilon epsilon = default(TorusEpsilon))
		{
			t = 0f;
			torusTubeRadius += epsilon.TubeRadiusEps;
			float cylinderRadius = torusCoreRadius + torusTubeRadius;
			Vector3 vector = torusRotation * Vector3.up;
			Vector3 cylinderAxisPt = torusCenter - vector * torusTubeRadius;
			Vector3 cylinderAxisPt2 = torusCenter + vector * torusTubeRadius;
			if (CylinderMath.Raycast(ray, out t, cylinderAxisPt, cylinderAxisPt2, cylinderRadius))
			{
				float num = torusCoreRadius - torusTubeRadius;
				Vector3 point = ray.GetPoint(t);
				if ((new Plane(vector, torusCenter).ProjectPoint(point) - torusCenter).magnitude >= num)
				{
					return true;
				}
				cylinderRadius = num;
				Ray ray2 = ray.Mirror(point);
				if (CylinderMath.RaycastNoCaps(ray2, out t, cylinderAxisPt, cylinderAxisPt2, cylinderRadius))
				{
					t = (ray.origin - ray2.GetPoint(t)).magnitude;
					return true;
				}
			}
			return false;
		}

		public static bool RaycastCylindrical(Ray ray, out float t, Vector3 torusCenter, float torusCoreRadius, float torusHrzRadius, float torusVertRadius, Quaternion torusRotation, TorusEpsilon epsilon = default(TorusEpsilon))
		{
			t = 0f;
			torusHrzRadius += epsilon.CylHrzRadius;
			torusVertRadius += epsilon.CylVertRadius;
			float cylinderRadius = torusCoreRadius + torusHrzRadius;
			Vector3 vector = torusRotation * Vector3.up;
			Vector3 cylinderAxisPt = torusCenter - vector * torusVertRadius;
			Vector3 cylinderAxisPt2 = torusCenter + vector * torusVertRadius;
			if (CylinderMath.Raycast(ray, out t, cylinderAxisPt, cylinderAxisPt2, cylinderRadius))
			{
				float num = torusCoreRadius - torusHrzRadius;
				Vector3 point = ray.GetPoint(t);
				if ((new Plane(vector, torusCenter).ProjectPoint(point) - torusCenter).magnitude >= num)
				{
					return true;
				}
				cylinderRadius = num;
				Ray ray2 = ray.Mirror(point);
				if (CylinderMath.RaycastNoCaps(ray2, out t, cylinderAxisPt, cylinderAxisPt2, cylinderRadius))
				{
					t = (ray.origin - ray2.GetPoint(t)).magnitude;
					return true;
				}
			}
			return false;
		}
	}
}
