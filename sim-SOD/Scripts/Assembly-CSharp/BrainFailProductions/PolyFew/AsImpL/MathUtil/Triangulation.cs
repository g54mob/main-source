using System.Collections.Generic;
using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL.MathUtil
{
	public static class Triangulation
	{
		public static List<Triangle> TriangulateConvexPolygon(List<Vertex> vertices, bool preserveOriginalVertices = true)
		{
			return null;
		}

		public static List<Triangle> TriangulateByEarClipping(List<Vertex> origVertices, Vector3 planeNormal, string meshName, bool preserveOriginalVertices = true)
		{
			return null;
		}

		public static Triangle ClipTriangle(Vertex vertex, List<Vertex> vertices)
		{
			return null;
		}

		private static Triangle ClipEar(Vertex earVertex, List<Vertex> earVertices, List<Vertex> vertices, Vector3 planeNormal)
		{
			return null;
		}

		private static Vertex FindMaxAreaEarVertex(List<Vertex> earVertices)
		{
			return null;
		}

		private static List<Vertex> FindEarVertices(List<Vertex> vertices, Vector3 planeNormal)
		{
			return null;
		}

		private static bool IsVertexReflex(Vertex v, Vector3 vNormal)
		{
			return false;
		}

		private static bool IsVertexEar(Vertex v, List<Vertex> vertices, Vector3 planeNormal)
		{
			return false;
		}
	}
}
