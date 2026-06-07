using System.Collections.Generic;
using UnityEngine;

public class Polygon2DList : Polygon2D
{
	public static Polygon2D GetBiggest(List<Polygon2D> list)
	{
		return null;
	}

	public static Polygon2D GetSmallest(List<Polygon2D> list)
	{
		return null;
	}

	public static void RemoveClosePoints(List<Vector2D> list, float closePrecisionSqr = 2.5E-05f)
	{
	}

	public static List<Polygon2D> CreateFromPolygonColliderToWorldSpace(PolygonCollider2D collider)
	{
		return null;
	}

	public static List<Polygon2D> CreateFromPolygonColliderToLocalSpace(PolygonCollider2D collider)
	{
		return null;
	}

	public static List<Polygon2D> CreateFromGameObject(GameObject gameObject)
	{
		return null;
	}

	public static List<Polygon2D> CreateFromGameObject(GameObject gameObject, ColliderType colliderType)
	{
		return null;
	}
}
