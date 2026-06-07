using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class PolygonMath
	{
		public static bool Raycast(Ray ray, out float t, List<Vector3> cwPolyPoints, bool isClosed, Vector3 polyNormal, PolygonEpsilon epsilon = default(PolygonEpsilon))
		{
			t = 0f;
			if (cwPolyPoints.Count < (isClosed ? 4 : 3))
			{
				return false;
			}
			if (new Plane(polyNormal, cwPolyPoints[0]).Raycast(ray, out var enter) && Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, cwPolyPoints, isClosed, polyNormal, epsilon))
			{
				t = enter;
				return true;
			}
			return false;
		}

		public static bool Contains3DPoint(Vector3 point, bool checkOnPlane, List<Vector3> cwPolyPoints, bool isClosed, Vector3 polyNormal, PolygonEpsilon epsilon = default(PolygonEpsilon))
		{
			if (cwPolyPoints.Count < (isClosed ? 4 : 3))
			{
				return false;
			}
			Plane plane = new Plane(polyNormal, cwPolyPoints[0]);
			if (checkOnPlane && Mathf.Abs(plane.GetDistanceToPoint(point)) > epsilon.ExtrudeEps)
			{
				return false;
			}
			if (isClosed)
			{
				for (int i = 0; i < cwPolyPoints.Count - 1; i++)
				{
					Vector3 normalized = Vector3.Cross(cwPolyPoints[i + 1] - cwPolyPoints[i], polyNormal).normalized;
					if (Vector3.Dot(point - cwPolyPoints[i], normalized) > epsilon.AreaEps)
					{
						return false;
					}
				}
			}
			else
			{
				for (int j = 0; j < cwPolyPoints.Count; j++)
				{
					Vector3 normalized2 = Vector3.Cross(cwPolyPoints[(j + 1) % cwPolyPoints.Count] - cwPolyPoints[j], polyNormal).normalized;
					if (Vector3.Dot(point - cwPolyPoints[j], normalized2) > epsilon.AreaEps)
					{
						return false;
					}
				}
			}
			return true;
		}

		public static bool Contains2DPoint(Vector2 point, List<Vector2> polyPoints, bool isClosed, PolygonEpsilon epsilon = default(PolygonEpsilon))
		{
			if (isClosed)
			{
				for (int i = 0; i < polyPoints.Count - 1; i++)
				{
					Vector2 normal = (polyPoints[i + 1] - polyPoints[i]).GetNormal();
					if (Vector2.Dot(point - polyPoints[i], normal) > epsilon.AreaEps)
					{
						return false;
					}
				}
			}
			else
			{
				for (int j = 0; j < polyPoints.Count; j++)
				{
					Vector2 normal2 = (polyPoints[(j + 1) % polyPoints.Count] - polyPoints[j]).GetNormal();
					if (Vector2.Dot(point - polyPoints[j], normal2) > epsilon.AreaEps)
					{
						return false;
					}
				}
			}
			return true;
		}

		public static bool Is3DPointOnBorder(Vector3 point, bool checkOnPlane, List<Vector3> cwPolyPoints, bool isClosed, Vector3 polyNormal, PolygonEpsilon epsilon = default(PolygonEpsilon))
		{
			if (cwPolyPoints.Count < (isClosed ? 4 : 3))
			{
				return false;
			}
			Plane plane = new Plane(polyNormal, cwPolyPoints[0]);
			if (checkOnPlane && Mathf.Abs(plane.GetDistanceToPoint(point)) > epsilon.ExtrudeEps)
			{
				return false;
			}
			if (!checkOnPlane)
			{
				point = plane.ProjectPoint(point);
			}
			if (isClosed)
			{
				for (int i = 0; i < cwPolyPoints.Count - 1; i++)
				{
					if (point.GetDistanceToSegment(cwPolyPoints[i], cwPolyPoints[i + 1]) <= epsilon.WireEps)
					{
						return true;
					}
				}
			}
			else
			{
				for (int j = 0; j < cwPolyPoints.Count; j++)
				{
					if (point.GetDistanceToSegment(cwPolyPoints[j], cwPolyPoints[(j + 1) % cwPolyPoints.Count]) <= epsilon.WireEps)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool Is2DPointOnBorder(Vector2 point, List<Vector2> polyPoints, bool isClosed, PolygonEpsilon epsilon = default(PolygonEpsilon))
		{
			if (polyPoints.Count < (isClosed ? 4 : 3))
			{
				return false;
			}
			if (isClosed)
			{
				for (int i = 0; i < polyPoints.Count - 1; i++)
				{
					if (point.GetDistanceToSegment(polyPoints[i], polyPoints[i + 1]) <= epsilon.WireEps)
					{
						return true;
					}
				}
			}
			else
			{
				for (int j = 0; j < polyPoints.Count; j++)
				{
					if (point.GetDistanceToSegment(polyPoints[j], polyPoints[(j + 1) % polyPoints.Count]) <= epsilon.WireEps)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool Is2DPointOnThickBorder(Vector2 point, List<Vector2> polyPoints, List<Vector2> thickBorderPoints, bool isClosed, PolygonEpsilon epsilon = default(PolygonEpsilon))
		{
			if (polyPoints.Count != thickBorderPoints.Count)
			{
				return false;
			}
			if (polyPoints.Count < (isClosed ? 4 : 3))
			{
				return false;
			}
			List<Vector2> list = new List<Vector2>(4);
			PolygonEpsilon epsilon2 = new PolygonEpsilon
			{
				AreaEps = epsilon.ThickWireEps
			};
			for (int i = 0; i < polyPoints.Count - 1; i++)
			{
				list.Clear();
				list.Add(polyPoints[i]);
				list.Add(thickBorderPoints[i]);
				list.Add(thickBorderPoints[i + 1]);
				list.Add(polyPoints[i + 1]);
				list.Add(polyPoints[i]);
				if (Contains2DPoint(point, list, isClosed: true, epsilon2))
				{
					return true;
				}
			}
			return false;
		}
	}
}
