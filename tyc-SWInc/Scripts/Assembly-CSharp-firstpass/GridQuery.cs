using System;
using System.Collections.Generic;
using UnityEngine;

public class GridQuery<T> where T : IHasVector
{
	private Vector2 _offset;

	private List<T>[,] _grid;

	private Dictionary<T, Vector2Int> _lookup = new Dictionary<T, Vector2Int>();

	private List<List<T>> _pool = new List<List<T>>();

	private List<T> _nonThreadSafeResult = new List<T>();

	public GridQuery(Rect r)
	{
		int num = Mathf.FloorToInt(r.xMin);
		int num2 = Mathf.FloorToInt(r.yMin);
		int num3 = Mathf.CeilToInt(r.xMax);
		int num4 = Mathf.CeilToInt(r.yMax);
		_offset = new Vector2(num, num2);
		_grid = new List<T>[num3 - num, num4 - num2];
	}

	public void ForEach(Action<QuadTreeNode<T>> a)
	{
		for (int i = 0; i < _grid.GetLength(0); i++)
		{
			for (int j = 0; j < _grid.GetLength(1); j++)
			{
				List<T> list = _grid[i, j];
				QuadTreeNode<T> quadTreeNode = new QuadTreeNode<T>(new Rect(_offset.x + (float)i, _offset.y + (float)j, 1f, 1f), null, null, 0);
				if (list != null)
				{
					quadTreeNode.Contents.AddRange(list);
				}
				a(quadTreeNode);
			}
		}
	}

	public bool Contains(Vector2 p)
	{
		if (p.x >= _offset.x && p.x <= _offset.x + (float)_grid.GetLength(0) - 1f && p.y >= _offset.y)
		{
			return p.y <= _offset.y + (float)_grid.GetLength(1) - 1f;
		}
		return false;
	}

	public void Add(T obj)
	{
		Vector2 vector = obj.GetPos() - _offset;
		int num = Mathf.Clamp(Mathf.FloorToInt(vector.x), 0, _grid.GetLength(0) - 1);
		int num2 = Mathf.Clamp(Mathf.FloorToInt(vector.y), 0, _grid.GetLength(1) - 1);
		Vector2Int value;
		if (_lookup.TryGetValue(obj, out value) && value.x == num && value.y == num2)
		{
			return;
		}
		Remove(obj);
		if (_grid[num, num2] == null)
		{
			lock (_pool)
			{
				if (_pool.Count > 0)
				{
					_grid[num, num2] = _pool[_pool.Count - 1];
					_pool.RemoveAt(_pool.Count - 1);
				}
				else
				{
					_grid[num, num2] = new List<T>();
				}
			}
		}
		_lookup[obj] = new Vector2Int(num, num2);
		_grid[num, num2].Add(obj);
	}

	public List<T> Query(Vector2 p)
	{
		Vector2 vector = p - _offset;
		int x = Mathf.Clamp(Mathf.FloorToInt(vector.x), 0, _grid.GetLength(0) - 1);
		int y = Mathf.Clamp(Mathf.FloorToInt(vector.y), 0, _grid.GetLength(1) - 1);
		return Query(x, y);
	}

	public List<T> Query(Vector2 p, float radius, List<T> result = null)
	{
		Vector2 vector = Vector2.one * radius;
		result = result ?? _nonThreadSafeResult;
		result.Clear();
		Vector2 vector2 = p - vector - _offset;
		int xMin = Mathf.Clamp(Mathf.FloorToInt(vector2.x), 0, _grid.GetLength(0) - 1);
		int yMin = Mathf.Clamp(Mathf.FloorToInt(vector2.y), 0, _grid.GetLength(1) - 1);
		Vector2 vector3 = p + vector - _offset;
		int xMax = Mathf.Clamp(Mathf.CeilToInt(vector3.x), 0, _grid.GetLength(0));
		int yMax = Mathf.Clamp(Mathf.CeilToInt(vector3.y), 0, _grid.GetLength(1));
		Query(xMin, yMin, xMax, yMax, result);
		return result;
	}

	public List<T> Query(Rect r, List<T> result = null)
	{
		result = result ?? _nonThreadSafeResult;
		result.Clear();
		Vector2 vector = r.min - _offset;
		int xMin = Mathf.Clamp(Mathf.FloorToInt(vector.x), 0, _grid.GetLength(0) - 1);
		int yMin = Mathf.Clamp(Mathf.FloorToInt(vector.y), 0, _grid.GetLength(1) - 1);
		Vector2 vector2 = r.max - _offset;
		int xMax = Mathf.Clamp(Mathf.CeilToInt(vector2.x), 0, _grid.GetLength(0));
		int yMax = Mathf.Clamp(Mathf.CeilToInt(vector2.y), 0, _grid.GetLength(1));
		Query(xMin, yMin, xMax, yMax, result);
		return result;
	}

	private void Query(int xMin, int yMin, int xMax, int yMax, List<T> result)
	{
		if (xMax - xMin <= 1 && yMax - yMin <= 1)
		{
			List<T> list = Query(xMin, yMin);
			if (list != null)
			{
				result.AddRange(list);
			}
			return;
		}
		for (int i = xMin; i < xMax; i++)
		{
			for (int j = yMin; j < yMax; j++)
			{
				List<T> list2 = Query(i, j);
				if (list2 != null)
				{
					result.AddRange(list2);
				}
			}
		}
	}

	public List<T> Query(int x, int y)
	{
		return _grid[x, y];
	}

	public void Remove(T obj)
	{
		Vector2Int value;
		if (!_lookup.TryGetValue(obj, out value))
		{
			return;
		}
		if (_grid[value.x, value.y] != null)
		{
			_grid[value.x, value.y].Remove(obj);
			if (_grid[value.x, value.y].Count == 0)
			{
				lock (_pool)
				{
					_pool.Add(_grid[value.x, value.y]);
				}
				_grid[value.x, value.y] = null;
			}
		}
		_lookup.Remove(obj);
	}
}
