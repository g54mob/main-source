using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Math
{
	public static class Triangulator2D
	{
		public interface Vertex
		{
			Vector2 Position { get; }
		}

		public struct Triangle
		{
			public Vector2 VertexA;

			public Vector2 VertexB;

			public Vector2 VertexC;

			public int IndexVertexA;

			public int IndexVertexB;

			public int IndexVertexC;

			public Vector2 VectorAB;

			public Vector2 VectorAC;

			public float AngleAB_AC;

			public override string ToString()
			{
				return $"VertexA: {VertexA}, VertexB: {VertexB}, VertexC: {VertexC}, IndexVertexA: {IndexVertexA}, IndexVertexB: {IndexVertexB}, IndexVertexC: {IndexVertexC}, VectorAB: {VectorAB}, VectorAC: {VectorAC}, AngleAB_AC: {AngleAB_AC}";
			}
		}

		private static List<Vector2> _vertices;

		private static Triangle _triangle;

		private static Vector2[] _triangleVertices = new Vector2[3];

		private static List<Vector2> _verticesToDecompose;

		private static List<Vector2> _convexVertices = new List<Vector2>();

		private static Polygon _polygon = new Polygon();

		public static IEnumerator<Triangle> GetTriangulateEnumerator(IEnumerable<Vertex> vertices)
		{
			PopulateVertices(vertices);
			return GetTriangulationEnumerator(_vertices);
		}

		public static Vector2 TriangulateCentroid(IEnumerable<Vector2> vertices)
		{
			IEnumerator<Triangle> triangulationEnumerator = GetTriangulationEnumerator(vertices);
			Vector2 zero = Vector2.zero;
			int num = 0;
			while (triangulationEnumerator.MoveNext())
			{
				zero += (_triangle.VertexA + _triangle.VertexB + _triangle.VertexC) / 3f;
				num++;
			}
			if (0 >= num)
			{
				return Vector2.negativeInfinity;
			}
			return zero / num;
		}

		public static Vector2 TriangulateCentroid(IEnumerable<Vertex> vertices)
		{
			PopulateVertices(vertices);
			return TriangulateCentroid(_vertices);
		}

		private static IEnumerator<Triangle> GetTriangulationEnumerator(IEnumerable<Vector2> vertices)
		{
			using PooledList<Vector2> vertexList = PooledList<Vector2>.Get(vertices);
			float vertexDirection = ComputeDirection(vertexList);
			int lastEarIndex = 0;
			while (TryFindEar(vertexList, lastEarIndex, vertexDirection))
			{
				lastEarIndex = _triangle.IndexVertexA;
				vertexList.RemoveAt(lastEarIndex);
				yield return _triangle;
			}
		}

		private static bool TryFindEar(List<Vector2> vertices, int startIndex, float vertexDirection)
		{
			IEnumerator<Triangle> triangleEnumerator = GetTriangleEnumerator(vertices, startIndex);
			while (triangleEnumerator.MoveNext())
			{
				if (Mathf.Sign(_triangle.AngleAB_AC) != vertexDirection)
				{
					continue;
				}
				_triangleVertices[0] = _triangle.VertexA;
				_triangleVertices[1] = _triangle.VertexB;
				_triangleVertices[2] = _triangle.VertexC;
				if (_polygon == null)
				{
					_polygon = new Polygon();
				}
				_polygon.Update(_triangleVertices);
				bool flag = false;
				foreach (Vector2 vertex in vertices)
				{
					if (!(vertex == _triangle.VertexA) && !(vertex == _triangle.VertexB) && !(vertex == _triangle.VertexC) && _polygon.ReturnPointIsOverlapping(vertex))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			return false;
		}

		public static IEnumerator<Vector2[]> GetDecomposeEnumerator(IEnumerable<Vertex> vertices)
		{
			PopulateVertices(vertices);
			using PooledList<Vector2> verticesToDecompose = PooledList<Vector2>.Get(_vertices);
			using PooledList<Vector2> convexVertices = PooledList<Vector2>.Get();
			while (2 < _verticesToDecompose.Count)
			{
				convexVertices.Clear();
				for (int i = 0; i < verticesToDecompose.Count; i++)
				{
					TryAddConvexVertex(verticesToDecompose[i], convexVertices, _vertices);
				}
				yield return convexVertices.ToArray();
			}
		}

		private static bool TryAddConvexVertex(Vector2 vertex, List<Vector2> convexVertices, List<Vector2> allVertices)
		{
			convexVertices.Add(vertex);
			if (convexVertices.Count < 3)
			{
				return true;
			}
			if (IsConvex(convexVertices) && !IsAnyPointOVerlapping(convexVertices, allVertices))
			{
				return true;
			}
			if (convexVertices.Count == 3)
			{
				convexVertices.RemoveAt(0);
				return true;
			}
			convexVertices.Remove(vertex);
			return false;
		}

		public static bool IsConvex(List<Vector2> vertices)
		{
			IEnumerator<Triangle> triangleEnumerator = GetTriangleEnumerator(vertices);
			float num = 0f;
			while (triangleEnumerator.MoveNext())
			{
				Triangle current = triangleEnumerator.Current;
				if (num == 0f)
				{
					num = current.AngleAB_AC;
					continue;
				}
				if (num < 0f && 0f < current.AngleAB_AC)
				{
					return false;
				}
				if (!(0f < num) || !(current.AngleAB_AC < 0f))
				{
					continue;
				}
				return false;
			}
			return true;
		}

		private static void PopulateVertices(IEnumerable<Vertex> vertices)
		{
			if (_vertices == null)
			{
				_vertices = new List<Vector2>();
			}
			else
			{
				_vertices.Clear();
			}
			foreach (Vertex vertex in vertices)
			{
				_vertices.Add(vertex.Position);
			}
		}

		private static float ComputeDirection(List<Vector2> vertices)
		{
			IEnumerator<Triangle> triangleEnumerator = GetTriangleEnumerator(vertices);
			float num = 0f;
			while (triangleEnumerator.MoveNext())
			{
				num += _triangle.AngleAB_AC;
			}
			return Mathf.Sign(num);
		}

		private static bool IsAnyPointOVerlapping(List<Vector2> polygon, List<Vector2> points)
		{
			if (_polygon == null)
			{
				_polygon = new Polygon();
			}
			_polygon.Update(polygon);
			foreach (Vector2 point in points)
			{
				if (!polygon.Contains(point) && _polygon.ReturnPointIsOverlapping(point))
				{
					return true;
				}
			}
			return false;
		}

		private static IEnumerator<Triangle> GetTriangleEnumerator(List<Vector2> vertices, int startIndex = 0)
		{
			int vertexCount = vertices.Count;
			int index = Math.WrapIndex(startIndex, vertexCount);
			if (vertexCount >= 3)
			{
				_triangle.IndexVertexA = index;
				_triangle.VertexA = vertices[_triangle.IndexVertexA];
				_triangle.IndexVertexB = Math.WrapIndex(index - 1, vertexCount);
				_triangle.VertexB = vertices[_triangle.IndexVertexB];
				_triangle.VectorAB = _triangle.VertexB - _triangle.VertexA;
				for (int i = 0; i < vertexCount; i++)
				{
					int num = index + 1;
					index = num;
					_triangle.IndexVertexC = Math.WrapIndex(num, vertexCount);
					_triangle.VertexC = vertices[_triangle.IndexVertexC];
					_triangle.VectorAC = _triangle.VertexC - _triangle.VertexA;
					_triangle.AngleAB_AC = Vector2.SignedAngle(_triangle.VectorAB, _triangle.VectorAC);
					yield return _triangle;
					_triangle.IndexVertexB = _triangle.IndexVertexA;
					_triangle.VertexB = _triangle.VertexA;
					_triangle.IndexVertexA = _triangle.IndexVertexC;
					_triangle.VertexA = _triangle.VertexC;
					_triangle.VectorAB = _triangle.VertexB - _triangle.VertexA;
				}
			}
		}
	}
}
