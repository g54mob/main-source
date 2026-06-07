using System.Collections.Generic;
using UnityEngine;

public class ShapeObject : MonoBehaviour
{
	public int gridWidth;

	public int gridHeight;

	public List<Vector2D> pointsIn;

	private Polygon2D polygon;

	private Polygon2D polygon_world;

	public ShapeMovement movement;

	private static List<ShapeObject> shapeList;

	public static List<ShapeObject> GetList()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Awake()
	{
	}

	public Polygon2D GetWorldPolygon()
	{
		return null;
	}

	public Polygon2D GetPolygon()
	{
		return null;
	}

	public static bool PointInShapes(Vector2D point)
	{
		return false;
	}
}
