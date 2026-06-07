using PajamaLlama.Math;
using UnityEngine;

public struct Polygon2DLine
{
	internal Vector2 Point;

	internal Vector2 Vector;

	public Polygon2DLine(Vector2 pointA, Vector2 pointB)
	{
		Point = pointA;
		Vector = new Vector2(pointB.x - pointA.x, pointB.y - pointA.y);
	}

	public Vector2 ReturnProjection(Vector2 pointToProject)
	{
		Vector2 vector = pointToProject - Point;
		float num = Vector.normalized.x * vector.x + Vector.normalized.y * vector.y;
		return Point + Vector.normalized * num;
	}

	public Vector2 ReturnClosesPointOnLineSegment(Vector2 pointToProject)
	{
		Vector2 normalized = Vector.normalized;
		Vector2 vector = pointToProject - Point;
		float num = normalized.x * vector.x + normalized.y * vector.y;
		float magnitude = Vector.magnitude;
		if (0f <= num && num <= magnitude)
		{
			return Point + Vector.normalized * num;
		}
		if (num < 0f)
		{
			return Point;
		}
		return Point + Vector;
	}

	public bool TryReturnProjectionInBounds(Vector2 pointToProject, out Vector2 projection)
	{
		Vector2 normalized = Vector.normalized;
		Vector2 vector = pointToProject - Point;
		float num = normalized.x * vector.x + normalized.y * vector.y;
		float magnitude = Vector.magnitude;
		if ((0f < num && num < magnitude) || Mathf.Approximately(num, 0f) || Mathf.Approximately(num, magnitude))
		{
			projection = Point + Vector.normalized * num;
			return true;
		}
		projection = default(Vector2);
		return false;
	}

	public bool TryReturnIntersectionOnLine(Polygon2DLine lineToIntersect, out Vector2 intersection)
	{
		float a = Vector.Cross(lineToIntersect.Vector);
		intersection = default(Vector2);
		if (Mathf.Approximately(a, 0f))
		{
			return false;
		}
		float num = (lineToIntersect.Point.Cross(lineToIntersect.Vector) - Point.Cross(lineToIntersect.Vector)) / Vector.Cross(lineToIntersect.Vector);
		if (num < 0f || num > 1f)
		{
			return false;
		}
		intersection = Point + num * Vector;
		Vector2 lhs = intersection - lineToIntersect.Point;
		if (Vector2.Dot(lhs, lineToIntersect.Vector) > 0f)
		{
			return lhs.magnitude < lineToIntersect.Vector.magnitude;
		}
		return false;
	}

	public bool TryReturnIntersection(Polygon2DLine lineToIntersect, out Vector2 intersection)
	{
		float a = Vector.Cross(lineToIntersect.Vector);
		intersection = default(Vector2);
		if (Mathf.Approximately(a, 0f))
		{
			return false;
		}
		float num = (lineToIntersect.Point.Cross(lineToIntersect.Vector) - Point.Cross(lineToIntersect.Vector)) / Vector.Cross(lineToIntersect.Vector);
		intersection = Point + num * Vector;
		return true;
	}

	public Rect ReturnMarginRect(float margin)
	{
		Vector2 vector = Vector.normalized * margin;
		Vector2 vector2 = Vector2.Perpendicular(vector);
		Vector2 lhs = Point - vector - vector2;
		Vector2 rhs = Point + Vector + vector + vector2;
		Vector2 vector3 = Vector2.Min(lhs, rhs);
		Vector2 vector4 = Vector2.Max(lhs, rhs);
		return new Rect(vector3, vector4 - vector3);
	}
}
