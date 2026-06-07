using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Math
{
	public static class Geometry2D
	{
		private const float INTERSECT_VECTOR_MULTIPLIER = 1000f;

		public static void ComputeConvexHullIndices(List<Vector2> vertices, List<int> indices)
		{
			int num = GetMinVertexIndex(vertices);
			int count = vertices.Count;
			int num2 = 0;
			Vector2 directionToNextVertex = Vector2.up;
			while (!indices.Contains(num) && num2 < count)
			{
				indices.Add(num);
				num = GetNextVertexIndex(vertices, num, directionToNextVertex, out directionToNextVertex);
				num2++;
			}
		}

		private static int GetMinVertexIndex(List<Vector2> vertices)
		{
			Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
			int count = vertices.Count;
			int result = -1;
			for (int i = 0; i < count; i++)
			{
				Vector2 vector2 = vertices[i];
				if (vector2.x < vector.x)
				{
					vector = vector2;
				}
				else
				{
					if (vector2.x != vector.x || !(vector2.y < vector.y))
					{
						continue;
					}
					vector.y = vector2.y;
				}
				result = i;
			}
			return result;
		}

		private static int GetNextVertexIndex(List<Vector2> vertices, int currentVertexIndex, Vector2 directionToCurrentVertex, out Vector2 directionToNextVertex)
		{
			Vector2 vector = vertices[currentVertexIndex];
			int result = -1;
			float num = float.MaxValue;
			directionToNextVertex = default(Vector2);
			for (int i = 0; i < vertices.Count; i++)
			{
				if (i == currentVertexIndex)
				{
					continue;
				}
				Vector2 vector2 = vertices[i] - vector;
				float num2 = Vector2.SignedAngle(vector2, directionToCurrentVertex);
				if (0f <= num2 && num2 < 180f)
				{
					if (num2 < num)
					{
						num = num2;
						directionToNextVertex = vector2;
						result = i;
					}
					else if (num2 == num && directionToNextVertex.sqrMagnitude < vector2.sqrMagnitude)
					{
						directionToNextVertex = vector2;
						result = i;
					}
				}
			}
			return result;
		}

		public static ListPool<Vector2>.List ScalePolygon(Vector2[] vertices, float scale)
		{
			int num = vertices.Length;
			if (num < 3)
			{
				throw new NotSupportedException();
			}
			Vector2 zero = Vector2.zero;
			for (int i = 0; i < num; i++)
			{
				zero += vertices[i];
			}
			zero /= (float)num;
			ListPool<Vector2>.List list = ListPool<Vector2>.Get(num);
			for (int j = 0; j < num; j++)
			{
				list.Add(zero + (vertices[j] - zero) * scale);
			}
			return list;
		}

		public static void AddPaddingToPolygon(List<Vector2> vertices, List<Vector2> paddedVertices, float padding)
		{
			int count = vertices.Count;
			if (count < 3)
			{
				throw new NotSupportedException();
			}
			paddedVertices.Clear();
			if (paddedVertices.Capacity < count)
			{
				paddedVertices.Capacity = count;
			}
			Vector2 vertexLeft = vertices[count - 2];
			Vector2 vector = vertices[count - 1];
			for (int i = 0; i < count; i++)
			{
				Vector2 vector2 = vertices[i];
				if (TryReturnPaddedPolygonVertex(vertexLeft, vector, vector2, padding, out var paddedVertex))
				{
					paddedVertices.Add(paddedVertex);
				}
				vertexLeft = vector;
				vector = vector2;
			}
		}

		public static ListPool<Vector2>.List AddPaddingToPolygon(Vector2[] vertices, float padding)
		{
			int num = vertices.Length;
			if (num < 3)
			{
				throw new NotSupportedException();
			}
			ListPool<Vector2>.List list = ListPool<Vector2>.Get(num);
			Vector2 vertexLeft = vertices[num - 2];
			Vector2 vector = vertices[num - 1];
			for (int i = 0; i < num; i++)
			{
				Vector2 vector2 = vertices[i];
				if (TryReturnPaddedPolygonVertex(vertexLeft, vector, vector2, padding, out var paddedVertex))
				{
					list.Add(paddedVertex);
				}
				vertexLeft = vector;
				vector = vector2;
			}
			return list;
		}

		private static bool TryReturnPaddedPolygonVertex(Vector2 vertexLeft, Vector2 vertex, Vector2 vertexRight, float padding, out Vector2 paddedVertex)
		{
			Vector2 normalized = (vertex - vertexLeft).normalized;
			Vector2 vector = new Vector2(0f - normalized.y, normalized.x);
			Vector2 linePoint = vertex + vector * padding;
			Vector2 normalized2 = (vertex - vertexRight).normalized;
			Vector2 vector2 = new Vector2(normalized2.y, 0f - normalized2.x);
			return TryIntersect(linePoint2: vertex + vector2 * padding, linePoint1: linePoint, lineVector1: normalized * 1000f, lineVector2: normalized2 * 1000f, intersectionPoint: out paddedVertex);
		}

		public static bool TryIntersect(Vector2 linePoint1, Vector2 lineVector1, Vector2 linePoint2, Vector2 lineVector2, out Vector2 intersectionPoint)
		{
			lineVector2 = -lineVector2;
			Vector2 vector = linePoint1 - linePoint2;
			float num = lineVector2.y * vector.x - lineVector2.x * vector.y;
			float num2 = lineVector1.x * vector.y - lineVector1.y * vector.x;
			float num3 = lineVector1.y * lineVector2.x - lineVector1.x * lineVector2.y;
			intersectionPoint = default(Vector2);
			if (num3 == 0f)
			{
				return false;
			}
			if (num3 > 0f)
			{
				if (num < 0f || num > num3 || num2 < 0f || num2 > num3)
				{
					return false;
				}
			}
			else if (num > 0f || num < num3 || num2 > 0f || num2 < num3)
			{
				return false;
			}
			intersectionPoint = linePoint1 + lineVector1 * num / num3;
			return true;
		}
	}
}
