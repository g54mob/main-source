using UnityEngine;

namespace RLD
{
	public static class RayEx
	{
		public static Ray InverseTransform(this Ray ray, Matrix4x4 transformMatrix)
		{
			Matrix4x4 inverse = transformMatrix.inverse;
			Vector3 origin = inverse.MultiplyPoint(ray.origin);
			Vector3 normalized = inverse.MultiplyVector(ray.direction).normalized;
			return new Ray(origin, normalized);
		}

		public static Ray Mirror(this Ray ray, Vector3 mirrorPoint)
		{
			Ray result = ray;
			result.origin = mirrorPoint + ray.direction * (ray.origin - mirrorPoint).magnitude;
			result.direction = -ray.direction;
			return result;
		}
	}
}
