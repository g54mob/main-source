using System.Collections.Generic;
using UnityEngine;

public struct Vector2List
{
	public List<Vector2> points;

	public int Count()
	{
		return 0;
	}

	public void Insert(int id, Vector2 vec)
	{
	}

	public Vector2List Copy()
	{
		return default(Vector2List);
	}

	public void RemoveAt(int id)
	{
	}

	public int IndexOf(Vector2 v)
	{
		return 0;
	}

	public void Clear()
	{
	}

	public Vector2List(bool use)
	{
		points = null;
	}

	public Vector2List(List<Vector2D> list)
	{
		points = null;
	}

	public void Add(Vector2 v)
	{
	}

	public List<Vector2D> ToVector2DList()
	{
		return null;
	}

	public Vector2 First()
	{
		return default(Vector2);
	}

	public Vector2 Last()
	{
		return default(Vector2);
	}
}
