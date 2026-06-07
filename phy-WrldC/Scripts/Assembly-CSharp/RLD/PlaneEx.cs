using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class PlaneEx
	{
		public static Plane InvertNormal(this Plane plane)
		{
			return new Plane(-plane.normal, 0f - plane.distance);
		}

		public static float GetAbsDistanceToPoint(this Plane plane, Vector3 point)
		{
			return Mathf.Abs(plane.GetDistanceToPoint(point));
		}

		public static Vector3 ProjectPoint(this Plane plane, Vector3 pt)
		{
			float distanceToPoint = plane.GetDistanceToPoint(pt);
			return pt - distanceToPoint * plane.normal;
		}

		public static List<Vector3> ProjectAllPoints(this Plane plane, List<Vector3> points)
		{
			if (points.Count == 0)
			{
				return new List<Vector3>();
			}
			List<Vector3> list = new List<Vector3>(points.Count);
			foreach (Vector3 point in points)
			{
				list.Add(plane.ProjectPoint(point));
			}
			return list;
		}

		public static int GetFurthestPtInFront(this Plane plane, List<Vector3> points)
		{
			int result = -1;
			float num = float.MinValue;
			for (int i = 0; i < points.Count; i++)
			{
				Vector3 point = points[i];
				float distanceToPoint = plane.GetDistanceToPoint(point);
				if (distanceToPoint > 0f && distanceToPoint > num)
				{
					num = distanceToPoint;
					result = i;
				}
			}
			return result;
		}

		public static int GetClosestPtInFront(this Plane plane, List<Vector3> points)
		{
			int result = -1;
			float num = float.MaxValue;
			for (int i = 0; i < points.Count; i++)
			{
				Vector3 point = points[i];
				float distanceToPoint = plane.GetDistanceToPoint(point);
				if (distanceToPoint > 0f && distanceToPoint < num)
				{
					num = distanceToPoint;
					result = i;
				}
			}
			return result;
		}

		public static int GetClosestPtInFrontOrOnPlane(this Plane plane, List<Vector3> points)
		{
			int result = -1;
			float num = float.MaxValue;
			for (int i = 0; i < points.Count; i++)
			{
				Vector3 point = points[i];
				float distanceToPoint = plane.GetDistanceToPoint(point);
				if ((distanceToPoint >= 0f && distanceToPoint < num) || Mathf.Abs(distanceToPoint) < 0.0001f)
				{
					num = distanceToPoint;
					result = i;
				}
			}
			return result;
		}

		public static int GetFurthestPtBehind(this Plane plane, List<Vector3> points)
		{
			int result = -1;
			float num = float.MaxValue;
			for (int i = 0; i < points.Count; i++)
			{
				Vector3 point = points[i];
				float distanceToPoint = plane.GetDistanceToPoint(point);
				if (distanceToPoint < 0f && distanceToPoint < num)
				{
					num = distanceToPoint;
					result = i;
				}
			}
			return result;
		}

		public static Plane GetCameraFacingAxisSlicePlane(Vector3 axisOrigin, Vector3 axis, Camera camera)
		{
			Vector3 forward = camera.transform.forward;
			if (forward.IsAligned(axis, checkSameDirection: false))
			{
				return default(Plane);
			}
			Vector3 lhs = Vector3.Normalize(Vector3.Cross(forward, axis));
			if (lhs.magnitude < 0.0001f)
			{
				return default(Plane);
			}
			return new Plane(Vector3.Normalize(Vector3.Cross(lhs, axis)), axisOrigin);
		}
	}
}
