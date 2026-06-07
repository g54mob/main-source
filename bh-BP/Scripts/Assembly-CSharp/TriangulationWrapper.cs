using System.Collections.Generic;
using Polygon2DTriangulation;
using UnityEngine;

public static class TriangulationWrapper
{
	public class Polygon
	{
		public List<Vector2> outside;

		public List<List<Vector2>> holes;

		public List<Vector2> outsideUVs;

		public List<List<Vector2>> holesUVs;

		public Vector2 ClosestUV(Vector2 pos)
		{
			return default(Vector2);
		}
	}

	private static List<PolygonPoint> ConvertPoints(List<Vector2> points, Dictionary<uint, Vector2> codeToPosition)
	{
		return null;
	}

	public static Mesh CreateMesh(Polygon polygon)
	{
		return null;
	}

	public static Mesh CreateTriangle(Polygon polygon)
	{
		return null;
	}

	public static Mesh CreateMesh(Vector2[] vertices, int[] indices, Vector2[] uv)
	{
		return null;
	}
}
