using System.Collections.Generic;
using UnityEngine;

public class Polygon2D
{
	public enum ColliderType
	{
		Polygon = 0,
		Box = 1,
		Circle = 2,
		Capsule = 3,
		Edge = 4,
		None = 5
	}

	public enum PolygonType
	{
		Rectangle = 0,
		Circle = 1,
		Pentagon = 2,
		Hexagon = 3,
		Octagon = 4
	}

	public static int defaultCircleVerticesCount;

	public List<Vector2D> pointsList;

	public List<Polygon2D> holesList;

	private static Pair2D id;

	public static Polygon2D CreateFromCamera(Camera camera)
	{
		return null;
	}

	public void AddPoint(Vector2D point)
	{
	}

	public void AddPoint(Vector2 point)
	{
	}

	public void AddPoint(float pointX, float pointY)
	{
	}

	public void AddPoints(List<Vector2D> points)
	{
	}

	public Polygon2D()
	{
	}

	public Polygon2D(List<Vector2D> polygonPointsList, List<Polygon2D> holes = null)
	{
	}

	public Polygon2D(Vector2List polygonPointsList)
	{
	}

	public Polygon2D(Polygon2D polygon)
	{
	}

	public void AddHole(Polygon2D poly)
	{
	}

	public bool PointInPoly(Vector2D point)
	{
		return false;
	}

	public bool PolyInPoly(Polygon2D poly)
	{
		return false;
	}

	public Polygon2D PointInHole(Vector2D point)
	{
		return null;
	}

	public Polygon2D ToLocalSpace(Transform transform)
	{
		return null;
	}

	public Polygon2D ToWorldSpace(Transform transform)
	{
		return null;
	}

	public Polygon2D ToScale(Vector2 scale, Vector2D center = null)
	{
		return null;
	}

	public Polygon2D ToRotation(float rotation, Vector2D center = null)
	{
		return null;
	}

	public Polygon2D ToOffset(Vector2D pos)
	{
		return null;
	}

	public Polygon2D ToOffset(Vector2 pos)
	{
		return null;
	}

	public void Normalize()
	{
	}

	public bool IsClockwise()
	{
		return false;
	}

	public double GetArea()
	{
		return 0.0;
	}

	public Rect GetBounds()
	{
		return default(Rect);
	}

	public List<Polygon2D> LineIntersectHoles(Pair2D pair)
	{
		return null;
	}

	public bool SliceIntersectPoly(List<Vector2D> slice)
	{
		return false;
	}

	public List<Polygon2D> GetListSliceIntersectHoles(List<Vector2D> slice)
	{
		return null;
	}

	public List<Vector2D> GetListLineIntersectPoly(Pair2D line)
	{
		return null;
	}

	public static ColliderType GetColliderType(GameObject gameObject)
	{
		return default(ColliderType);
	}

	public static Polygon2D CreateFromRect(Vector2 size)
	{
		return null;
	}

	public static Polygon2D CreateFromCircleCollider(CircleCollider2D circleCollider, int pointsCount = -1)
	{
		return null;
	}

	public static Polygon2D CreateFromBoxCollider(BoxCollider2D boxCollider)
	{
		return null;
	}

	public static Polygon2D CreateFromCapsuleCollider(CapsuleCollider2D capsuleCollider, int pointsCount = -1)
	{
		return null;
	}

	public static Polygon2D Create(PolygonType type, float size = 1f)
	{
		return null;
	}

	public PolygonCollider2D CreatePolygonCollider(GameObject gameObject)
	{
		return null;
	}

	public EdgeCollider2D CreateEdgeCollider(GameObject gameObject)
	{
		return null;
	}

	public static Polygon2D CreateFromEdgeCollider(EdgeCollider2D edgeCollider)
	{
		return null;
	}

	public Mesh CreateMesh(Vector2 UVScale, Vector2 UVOffset, PolygonTriangulator2D.Triangulation triangulation = PolygonTriangulator2D.Triangulation.Advanced)
	{
		return null;
	}

	public Mesh CreateMesh(GameObject gObj, Vector2 UVScale, Vector2 UVOffset, PolygonTriangulator2D.Triangulation triangulation = PolygonTriangulator2D.Triangulation.Advanced)
	{
		return null;
	}

	public Mesh CreateMesh3D(GameObject gameObject, float zSize, Vector2 UVScale, Vector2 UVOffset, float uvRotation, PolygonTriangulator2D.Triangulation triangulation)
	{
		return null;
	}

	public static void SpriteToMesh(GameObject gameObject, VirtualSpriteRenderer spriteRenderer, PolygonTriangulator2D.Triangulation triangulation = PolygonTriangulator2D.Triangulation.Advanced, Vector2D customUVOffset = null)
	{
	}

	public static void SpriteToMesh3D(GameObject gameObject, VirtualSpriteRenderer spriteRenderer, float zSize, PolygonTriangulator2D.Triangulation triangulation = PolygonTriangulator2D.Triangulation.Advanced, Vector2D customUVOffset = null)
	{
	}

	public static Polygon2D GenerateShadow(Polygon2D poly, float sunDirection, float height)
	{
		return null;
	}
}
