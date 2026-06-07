using UnityEngine;

public class PolygonTriangulator2D : MonoBehaviour
{
	public enum Triangulation
	{
		Advanced = 0,
		Legacy = 1
	}

	public static Mesh Triangulate3D(Polygon2D polygon, float z, Vector2 UVScale, Vector2 UVOffset, float UVRotation, Triangulation triangulation)
	{
		return null;
	}

	public static Mesh Triangulate2D(Polygon2D polygon, Vector2 UVScale, Vector2 UVOffset, Triangulation triangulation)
	{
		return null;
	}

	public static Mesh PerformTriangulation(Polygon2D polygon, Vector2 UVScale, Vector2 UVOffset)
	{
		return null;
	}

	public static Mesh PerformTriangulationAdvanced(Polygon2D polygon, Vector2 UVScale, Vector2 UVOffset, float UVRotation)
	{
		return null;
	}
}
