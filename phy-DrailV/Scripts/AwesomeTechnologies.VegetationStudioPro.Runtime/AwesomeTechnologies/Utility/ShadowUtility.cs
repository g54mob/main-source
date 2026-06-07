using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class ShadowUtility
	{
		public static bool IsShadowVisible(Bounds objectBounds, Vector3 lightDirection, Vector3 planeOrigin, Plane[] frustumPlanes)
		{
			bool hitPlane;
			Bounds shadowBounds = GetShadowBounds(objectBounds, lightDirection, planeOrigin, out hitPlane);
			if (hitPlane)
			{
				return BoundsIntersectsFrustum(frustumPlanes, shadowBounds);
			}
			return false;
		}

		public static bool BoundsIntersectsFrustum(Plane[] planes, Bounds bounds)
		{
			Vector3 center = bounds.center;
			Vector3 extents = bounds.extents;
			for (int i = 0; i <= planes.Length - 1; i++)
			{
				Vector3 normal = planes[i].normal;
				float distance = planes[i].distance;
				Vector3 vector = new Vector3(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z));
				float num = extents.x * vector.x + extents.y * vector.y + extents.z * vector.z;
				if (normal.x * center.x + normal.y * center.y + normal.z * center.z + num < 0f - distance)
				{
					return false;
				}
			}
			return true;
		}

		public static Bounds GetShadowBounds(Bounds objectBounds, Vector3 lightDirection, Vector3 planeOrigin, out bool hitPlane)
		{
			Ray ray = new Ray(new Vector3(objectBounds.min.x, objectBounds.max.y, objectBounds.min.z), lightDirection);
			Ray ray2 = new Ray(new Vector3(objectBounds.min.x, objectBounds.max.y, objectBounds.max.z), lightDirection);
			Ray ray3 = new Ray(new Vector3(objectBounds.max.x, objectBounds.max.y, objectBounds.min.z), lightDirection);
			Ray ray4 = new Ray(objectBounds.max, lightDirection);
			hitPlane = false;
			if (IntersectPlane(ray, planeOrigin, out var hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			if (IntersectPlane(ray2, planeOrigin, out hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			if (IntersectPlane(ray3, planeOrigin, out hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			if (IntersectPlane(ray4, planeOrigin, out hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			return objectBounds;
		}

		public static bool IntersectPlane(Ray ray, Vector3 planeOrigin, out Vector3 hitPoint)
		{
			Vector3 rhs = -Vector3.up;
			float num = Vector3.Dot(ray.direction, rhs);
			if (num > 1E-05f)
			{
				float num2 = Vector3.Dot(planeOrigin - ray.origin, rhs) / num;
				hitPoint = ray.origin + ray.direction * num2;
				return true;
			}
			hitPoint = Vector3.zero;
			return false;
		}
	}
}
