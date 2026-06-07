using System;
using System.Collections.Generic;
using UnityEngine;

public class QuadTree<T> where T : IHasVector
{
	public readonly float MinArea;

	public readonly int MaxNodes;

	public readonly int MaxDepth;

	public Rect Rectangle;

	public Dictionary<T, QuadTreeNode<T>> ItemLocation = new Dictionary<T, QuadTreeNode<T>>();

	private QuadTreeNode<T> _root;

	public static List<T> NonThreadSafeResult = new List<T>();

	public int Count
	{
		get
		{
			return _root.Count;
		}
	}

	public QuadTree(Rect rectangle, float minArea, int maxNodes, int maxDepth)
	{
		Rectangle = rectangle;
		_root = new QuadTreeNode<T>(Rectangle, this, null, 0);
		MinArea = minArea;
		MaxNodes = maxNodes;
		MaxDepth = maxDepth;
	}

	public bool Insert(T item)
	{
		if (ItemLocation.ContainsKey(item))
		{
			return UpdatePosition(item);
		}
		return _root.Insert(item);
	}

	public IEnumerable<T> Query(Rect area)
	{
		foreach (T item in _root.Query(area))
		{
			yield return item;
		}
	}

	public void Query(Rect area, List<T> result)
	{
		result.Clear();
		_root.Query(area, result);
	}

	public void removeItem(T item)
	{
		QuadTreeNode<T> value;
		if (ItemLocation.TryGetValue(item, out value))
		{
			value.Remove(item);
			ItemLocation.Remove(item);
		}
		else
		{
			Debug.LogError("Tried to remove non existant node in quad tree of type: " + typeof(T).ToString());
		}
	}

	public void TryRemoveItem(T item)
	{
		QuadTreeNode<T> value;
		if (ItemLocation.TryGetValue(item, out value))
		{
			value.Remove(item);
			ItemLocation.Remove(item);
		}
	}

	public bool UpdatePosition(T item)
	{
		QuadTreeNode<T> value;
		if (ItemLocation.TryGetValue(item, out value))
		{
			if (!QuadTreeNode<T>.Contains(value.Bounds, item.GetPos()))
			{
				value.Remove(item);
				ItemLocation.Remove(item);
				return Insert(item);
			}
			return true;
		}
		Debug.LogError("Tried to update position of non existant node in quad tree of type: " + typeof(T).ToString());
		return false;
	}

	public void ForEach(Action<QuadTreeNode<T>> action)
	{
		_root.ForEach(action);
	}
}
