using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public abstract class Polygon2DBase
{
	public abstract Rect Bounds { get; protected set; }

	public abstract int VertexCount { get; }

	protected abstract int SideCount { get; }

	protected abstract int ProjectionCount { get; }

	public Vector2 GetClosestPointOnPolygon(out Polygon2DLine closestSide, out float distance, Vector2 position, float range = float.MaxValue)
	{
		int sideCount = SideCount;
		Vector2 result = default(Vector2);
		closestSide = default(Polygon2DLine);
		distance = range;
		for (int i = 0; i < sideCount; i++)
		{
			Polygon2DLine side = GetSide(i);
			Vector2 vector = side.ReturnClosesPointOnLineSegment(position);
			float num = Vector2.Distance(position, vector);
			if (num < distance)
			{
				result = vector;
				closestSide = side;
				distance = num;
			}
		}
		return result;
	}

	public abstract Vector2 GetVertex(int index);

	protected abstract Polygon2DLine GetSide(int index);

	protected abstract Polygon2DProjection GetProjection(int index);

	public virtual void PopulateVertices(List<Vector2> vertices)
	{
		for (int i = 0; i < VertexCount; i++)
		{
			vertices.Add(GetVertex(i));
		}
	}

	public bool TryPopulateExpandedVertices(List<Vector2> expandedVertices, float amount)
	{
		for (int i = 0; i < VertexCount; i++)
		{
			Polygon2DLine side = GetSide(i);
			side.Point = MoveSideOutwards(side, amount);
			Polygon2DLine side2 = GetSide((i + 1).ToWrappedIndex(VertexCount));
			side2.Point = MoveSideOutwards(side2, amount);
			if (side.TryReturnIntersection(side2, out var intersection))
			{
				expandedVertices.Add(intersection);
				continue;
			}
			return false;
		}
		return true;
	}

	private Vector2 MoveSideOutwards(Polygon2DLine side, float amount)
	{
		Vector2 vector = new Vector2(0f - side.Vector.y, side.Vector.x);
		vector.Normalize();
		return side.Point + vector * amount;
	}

	public bool IsOverlapping(Polygon2DBase other, bool includeTolerance = false)
	{
		if (!Bounds.Overlaps(other.Bounds))
		{
			return false;
		}
		if (includeTolerance)
		{
			if (IsPolygonOverlappingWithTolerance(other))
			{
				return other.IsPolygonOverlappingWithTolerance(this);
			}
			return false;
		}
		if (IsPolygonOverlapping(other))
		{
			return other.IsPolygonOverlapping(this);
		}
		return false;
	}

	public bool IsOverlapping(Vector2 point, float marginOffError = 0f)
	{
		int projectionCount = ProjectionCount;
		for (int i = 0; i < projectionCount; i++)
		{
			Polygon2DProjection projection = GetProjection(i);
			float scalar = Vector2.Dot(projection.axis, point);
			if (!projection.ReturnOverlap(scalar, marginOffError))
			{
				return false;
			}
		}
		return true;
	}

	public bool TryGetOverlap(Polygon2DBase polygon, out float overlap)
	{
		using ListPool<Vector2>.List vertices = ListPool<Vector2>.Get();
		if (Bounds.Overlaps(polygon.Bounds) && PopulateOverlap(polygon, vertices))
		{
			SortVertices(vertices);
			overlap = ComputeSurface(vertices);
			return true;
		}
		overlap = 0f;
		return false;
	}

	public bool PopulateOverlap(Polygon2DBase polygon, List<Vector2> vertices)
	{
		PopulateOverllapingPoints(polygon, vertices);
		polygon.PopulateOverllapingPoints(this, vertices);
		PopulateIntersectionPoints(polygon, vertices);
		return 2 < vertices.Count;
	}

	private void PopulateOverllapingPoints(Polygon2DBase polygon, List<Vector2> vertices)
	{
		for (int i = 0; i < polygon.VertexCount; i++)
		{
			Vector2 vertex = polygon.GetVertex(i);
			if (IsOverlapping(vertex))
			{
				vertices.Add(vertex);
			}
		}
	}

	private void PopulateIntersectionPoints(Polygon2DBase polygon, List<Vector2> vertices)
	{
		for (int i = 0; i < SideCount; i++)
		{
			Polygon2DLine side = GetSide(i);
			for (int j = 0; j < polygon.SideCount; j++)
			{
				Polygon2DLine side2 = polygon.GetSide(j);
				if (side.TryReturnIntersectionOnLine(side2, out var intersection))
				{
					vertices.Add(intersection);
				}
			}
		}
	}

	private bool IsPolygonOverlapping(Polygon2DBase polygon)
	{
		for (int i = 0; i < ProjectionCount; i++)
		{
			if (!GetProjection(i).ReturnOverlap(polygon))
			{
				return false;
			}
		}
		return true;
	}

	private bool IsPolygonOverlappingWithTolerance(Polygon2DBase polygon)
	{
		for (int i = 0; i < ProjectionCount; i++)
		{
			if (!GetProjection(i).ReturnOverlapWithTolerance(polygon))
			{
				return false;
			}
		}
		return true;
	}

	protected bool ReturnIsIntersecting(Vector2 origin, Vector2 direction)
	{
		int sideCount = SideCount;
		for (int i = 0; i < sideCount; i++)
		{
			Polygon2DLine side = GetSide(i);
			float num = ReturnIntersectionScalar(origin, direction, side.Point, side.Vector);
			if (!(num < 0f) && !(1f < num))
			{
				Vector2 point = origin + num * direction;
				if (ReturnPointIsOverlapping(point, 0.01f))
				{
					return true;
				}
			}
		}
		return false;
	}

	protected float ReturnIntersectionScalar(Vector2 pointA, Vector2 vectorA, Vector2 pointB, Vector2 vectorB)
	{
		return (pointB.Cross(vectorB) - pointA.Cross(vectorB)) / vectorA.Cross(vectorB);
	}

	protected bool ReturnPointIsOverlapping(Vector2 point, float marginOffError = 0f)
	{
		int projectionCount = ProjectionCount;
		for (int i = 0; i < projectionCount; i++)
		{
			Polygon2DProjection projection = GetProjection(i);
			float scalar = Vector2.Dot(projection.axis, point);
			if (!projection.ReturnOverlap(scalar, marginOffError))
			{
				return false;
			}
		}
		return true;
	}

	protected Polygon2DProjection GetProjectionOnAxis(Vector2 axis)
	{
		Vector2 vertex = GetVertex(0);
		float num = axis.x * vertex.x + axis.y * vertex.y;
		float num2 = num;
		float num3 = num;
		int vertexCount = VertexCount;
		for (int i = 1; i < vertexCount; i++)
		{
			vertex = GetVertex(i);
			num = axis.x * vertex.x + axis.y * vertex.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		return new Polygon2DProjection(axis, num2, num3);
	}

	protected bool IsRegular()
	{
		int vertexCount = VertexCount;
		Vector2 vertex = GetVertex(vertexCount - 1);
		Vector2 vertex2 = GetVertex(0);
		Vector2 vector = vertex - GetVertex(vertexCount - 2);
		Vector2 vector2 = vertex2 - vertex;
		float b = vector.Angle(vector2);
		for (int i = 1; i < vertexCount; i++)
		{
			vertex = vertex2;
			vertex2 = GetVertex(i);
			vector = vector2;
			vector2 = vertex2 - vertex;
			if (!Mathf.Approximately(vector.Angle(vector2), b))
			{
				return false;
			}
		}
		return true;
	}

	public static void SortVertices(List<Vector2> vertices)
	{
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get(vertices);
		vertices.Clear();
		SortFirstVertices(list, vertices);
		Vector2 vector = vertices[vertices.Count - 1];
		Vector2 vector2 = vertices[vertices.Count - 2] - vector;
		while (list.Count > 1)
		{
			int nextSortedVertexIndex = GetNextSortedVertexIndex(vector, vector2, list);
			Vector2 vector3 = list[nextSortedVertexIndex];
			vector2 = vector - vector3;
			vector = vector3;
			vertices.Add(vector);
			list.RemoveAt(nextSortedVertexIndex);
		}
		if (list.Count == 1)
		{
			vertices.Add(list[0]);
		}
	}

	private static void SortFirstVertices(List<Vector2> unsortedVertices, List<Vector2> sortedVertices)
	{
		Vector2 vector = unsortedVertices[0];
		unsortedVertices.RemoveAt(0);
		GetFirstSortedVertexIndices(vector, unsortedVertices, out var indexA, out var indexB);
		Vector2 vector2 = unsortedVertices[indexA];
		Vector2 vector3 = unsortedVertices[indexB];
		Vector2 vector4 = vector2 - vector;
		Vector2 to = vector3 - vector;
		if (Vector2.SignedAngle(vector4, to) < 0f)
		{
			sortedVertices.Add(vector3);
			sortedVertices.Add(vector);
			sortedVertices.Add(vector2);
		}
		else
		{
			sortedVertices.Add(vector2);
			sortedVertices.Add(vector);
			sortedVertices.Add(vector3);
		}
		if (indexA < indexB)
		{
			unsortedVertices.RemoveAt(indexB);
			unsortedVertices.RemoveAt(indexA);
		}
		else
		{
			unsortedVertices.RemoveAt(indexA);
			unsortedVertices.RemoveAt(indexB);
		}
	}

	private static void GetFirstSortedVertexIndices(Vector2 vertex, List<Vector2> unsorted, out int indexA, out int indexB)
	{
		float num = 0f;
		indexA = -1;
		indexB = -1;
		for (int i = 0; i < unsorted.Count - 1; i++)
		{
			Vector2 vector = unsorted[i] - vertex;
			for (int j = i + 1; j < unsorted.Count; j++)
			{
				Vector2 to = unsorted[j] - vertex;
				float num2 = Vector2.Angle(vector, to);
				if (num < num2)
				{
					num = num2;
					indexA = i;
					indexB = j;
				}
			}
		}
	}

	private static int GetNextSortedVertexIndex(Vector2 vertex, Vector2 vector, List<Vector2> vertices)
	{
		float num = -1f;
		int result = -1;
		for (int i = 0; i < vertices.Count; i++)
		{
			float num2 = Vector2.Angle(vector, vertices[i] - vertex);
			if (num < num2)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	public static Vector2 ComputeCentroid(List<Vector2> vertices)
	{
		Vector2 zero = Vector2.zero;
		foreach (Vector2 vertex in vertices)
		{
			zero += vertex;
		}
		return zero / vertices.Count;
	}

	public static float ComputeSurface(List<Vector2> vertices)
	{
		if (vertices.Count - 2 < 1)
		{
			return 0f;
		}
		Vector2 vector = vertices[0];
		Vector2 vector2 = vertices[1];
		float num = 0f;
		for (int i = 2; i < vertices.Count; i++)
		{
			Vector2 vector3 = vertices[i];
			float magnitude = (vector2 - vector).magnitude;
			float magnitude2 = (vector3 - vector2).magnitude;
			float magnitude3 = (vector - vector3).magnitude;
			float num2 = (magnitude + magnitude2 + magnitude3) / 2f;
			num += Mathf.Sqrt(num2 * (num2 - magnitude) * (num2 - magnitude2) * (num2 - magnitude3));
			vector2 = vector3;
		}
		return num;
	}
}
