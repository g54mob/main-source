using System.Collections.Generic;
using UnityEngine;

public class Slice2D
{
	public Slice2DType sliceType;

	public List<Vector2D> slice;

	public List<List<Vector2D>> slices;

	public GameObject originGameObject;

	private List<Vector2D> collisions;

	private List<GameObject> gameObjects;

	private List<Polygon2D> polygons;

	public List<Vector2D> GetCollisions()
	{
		return null;
	}

	public List<GameObject> GetGameObjects()
	{
		return null;
	}

	public List<Polygon2D> GetPolygons()
	{
		return null;
	}

	public void AddSlice(List<Vector2D> list)
	{
	}

	public void AddCollision(Vector2D point)
	{
	}

	public void AddGameObject(GameObject gameObject)
	{
	}

	public void AddGameObjects(List<GameObject> newGameObjects)
	{
	}

	public void SetGameObjects(List<GameObject> newGameObjects)
	{
	}

	public void SetPolygons(List<Polygon2D> newPolygons)
	{
	}

	public void AddPolygon(Polygon2D polygon)
	{
	}

	public void RemovePolygon(Polygon2D polygon)
	{
	}

	public void AddSlice(Pair2D slice)
	{
	}

	public static Slice2D Create(GameObject originGameObject, List<Vector2D> newSlice)
	{
		return null;
	}

	public static Slice2D Create(GameObject originGameObject, Pair2D newSlice)
	{
		return null;
	}

	public static Slice2D Create(GameObject originGameObject, LinearCut newSlice)
	{
		return null;
	}

	public static Slice2D Create(GameObject originGameObject, ComplexCut newSlice)
	{
		return null;
	}

	public static Slice2D Create(GameObject originGameObject, Vector2D point, float rotation)
	{
		return null;
	}

	public static Slice2D Create(GameObject originGameObject, Polygon2D slice)
	{
		return null;
	}

	public static Slice2D Create(GameObject originGameObject, Vector2D point)
	{
		return null;
	}

	public static Slice2D Create(GameObject originGameObject, Slice2DType sliceType)
	{
		return null;
	}
}
