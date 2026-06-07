using UnityEngine;

namespace RLD
{
	public static class SegmentMath
	{
		public static bool Raycast(Ray ray, out float t, Vector3 startPoint, Vector3 endPoint, SegmentEpsilon epsilon = default(SegmentEpsilon))
		{
			if (CylinderMath.Raycast(ray, out t, startPoint, endPoint, epsilon.RaycastEps))
			{
				return true;
			}
			if (SphereMath.Raycast(ray, out t, startPoint, epsilon.RaycastEps))
			{
				return true;
			}
			return SphereMath.Raycast(ray, out t, endPoint, epsilon.RaycastEps);
		}

		public static bool Is3DPointOnSegment(Vector3 point, Vector3 startPoint, Vector3 endPoint, SegmentEpsilon epsilon = default(SegmentEpsilon))
		{
			return point.GetDistanceToSegment(startPoint, endPoint) <= epsilon.PtOnSegmentEps;
		}

		public static bool Is2DPointOnSegment(Vector2 point, Vector2 startPoint, Vector2 endPoint, SegmentEpsilon epsilon = default(SegmentEpsilon))
		{
			return point.GetDistanceToSegment(startPoint, endPoint) <= epsilon.PtOnSegmentEps;
		}

		public static Vector3 ProjectPtOnSegment(Vector3 point, Vector3 startPoint, Vector3 endPoint)
		{
			Vector3 normalized = (endPoint - startPoint).normalized;
			float num = Vector3.Dot(normalized, point - startPoint);
			return startPoint + normalized * num;
		}
	}
}
