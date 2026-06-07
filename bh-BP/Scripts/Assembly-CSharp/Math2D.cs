using System.Collections.Generic;
using UnityEngine;

public class Math2D
{
	public class Angle
	{
		public static float FindAngle(Vector2 p0, Vector2 p1, Vector2 p2)
		{
			return 0f;
		}

		public static Vector2 ReflectAngle(Vector2 v, float wallAngle)
		{
			return default(Vector2);
		}
	}

	public class Circle
	{
		public static bool IntersectPolygon(Polygon2D poly, Vector2D circle, float radius)
		{
			return false;
		}

		public static bool IntersectSlice(List<Vector2D> points, Vector2D circle, float radius)
		{
			return false;
		}

		public static bool IntersectLine(Pair2D line, Vector2D circle, float radius)
		{
			return false;
		}
	}

	public class Distance
	{
		public double value;

		public Distance(double val)
		{
		}

		public static Distance PolygonToPolygon(Polygon2D polyA, Polygon2D polyB)
		{
			return null;
		}

		public static double PointToLine(Vector2D p, Pair2D pair)
		{
			return 0.0;
		}
	}

	private static Pair2D a;

	private static Pair2D b;

	private static Pair2D pair2D;

	private static Pair2D line_intersect_poly;

	private static double tor;

	public static Vector3 GetPitchYawRollRad(Quaternion rotation)
	{
		return default(Vector3);
	}

	public static Vector3 GetPitchYawRollDeg(Quaternion rotation)
	{
		return default(Vector3);
	}

	public static Rect GetBounds(List<Vector2D> pointsList)
	{
		return default(Rect);
	}

	public static Rect GetBounds(Pair2D pair)
	{
		return default(Rect);
	}

	public static bool PolyInPoly(Polygon2D polyA, Polygon2D polyB)
	{
		return false;
	}

	public static bool PolyCollidePoly(Polygon2D polyA, Polygon2D polyB)
	{
		return false;
	}

	public static bool PolyIntersectPoly(Polygon2D polyA, Polygon2D polyB)
	{
		return false;
	}

	public static bool SliceIntersectPoly(List<Vector2D> slice, Polygon2D poly)
	{
		return false;
	}

	public static bool LineIntersectSlice(Pair2D pairA, List<Vector2D> slice)
	{
		return false;
	}

	public static bool LineIntersectPoly(Pair2D line, Polygon2D poly)
	{
		return false;
	}

	public static bool LineIntersectLine(Pair2D lineA, Pair2D lineB)
	{
		return false;
	}

	public static bool SliceIntersectItself(List<Vector2D> slice)
	{
		return false;
	}

	public static Vector2D GetPointLineIntersectLine(Pair2D lineA, Pair2D lineB)
	{
		return null;
	}

	public static bool GetBoolLineIntersectLine(Pair2D lineA, Pair2D lineB)
	{
		return false;
	}

	public static bool PointInPoly(Vector2D point, Polygon2D poly)
	{
		return false;
	}

	private static int GetQuad(Vector2D axis, Vector2D vert)
	{
		return 0;
	}

	public static List<Vector2D> GetListLineIntersectPoly(Pair2D line, Polygon2D poly)
	{
		return null;
	}

	public static List<Vector2D> GetListLineIntersectSlice(Pair2D pair, List<Vector2D> slice)
	{
		return null;
	}

	public static List<Vector2D> GetConvexHull(List<Vector2D> points)
	{
		return null;
	}

	public static float IsAPointLeftOfVectorOrOnTheLine(Vector2 a, Vector2 b, Vector2 p)
	{
		return 0f;
	}

	public static Vector2 ReflectAngle(Vector2 v, float wallAngle)
	{
		return default(Vector2);
	}

	public static float FindAngle(Vector2 p0, Vector2 p1, Vector2 p2)
	{
		return 0f;
	}
}
