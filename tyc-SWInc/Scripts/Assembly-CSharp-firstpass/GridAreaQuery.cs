using System.Collections.Generic;
using UnityEngine;

public class GridAreaQuery<T>
{
	public List<T>[,] Grid;

	public Vector2 Offset;

	public Vector2 GridSize;

	private static List<List<T>> _pool = new List<List<T>>();

	private static HashSet<T> _queryStruct = new HashSet<T>();

	public GridAreaQuery(Rect r, Vector2 gridSize)
	{
		GridSize = gridSize;
		int xmin;
		int ymin;
		int xmax;
		int ymax;
		Convert(r, out xmin, out ymin, out xmax, out ymax);
		Offset = new Vector2(xmin, ymin);
		Grid = new List<T>[xmax - xmin, ymax - ymin];
	}

	public void Convert(Rect r, out int xmin, out int ymin, out int xmax, out int ymax)
	{
		xmin = Mathf.FloorToInt(r.xMin / GridSize.x - Offset.x);
		ymin = Mathf.FloorToInt(r.yMin / GridSize.y - Offset.y);
		xmax = Mathf.CeilToInt(r.xMax / GridSize.x - Offset.x);
		ymax = Mathf.CeilToInt(r.yMax / GridSize.y - Offset.y);
	}

	public HashSet<T> QueryAround(Vector2 p, float radius)
	{
		_queryStruct.Clear();
		Vector2 vector = Vector2.one * radius;
		Vector2 vector2 = (p - vector) / GridSize - Offset;
		int num = Mathf.Clamp(Mathf.FloorToInt(vector2.x), 0, Grid.GetLength(0) - 1);
		int num2 = Mathf.Clamp(Mathf.FloorToInt(vector2.y), 0, Grid.GetLength(1) - 1);
		Vector2 vector3 = (p + vector) / GridSize - Offset;
		int num3 = Mathf.Clamp(Mathf.CeilToInt(vector3.x), 0, Grid.GetLength(0));
		int num4 = Mathf.Clamp(Mathf.CeilToInt(vector3.y), 0, Grid.GetLength(1));
		if (num3 - num <= 1 && num4 - num2 <= 1)
		{
			List<T> list = Query(num, num2);
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					_queryStruct.Add(list[i]);
				}
			}
			return _queryStruct;
		}
		for (int j = num; j < num3; j++)
		{
			for (int k = num2; k < num4; k++)
			{
				List<T> list2 = Query(j, k);
				if (list2 != null)
				{
					for (int l = 0; l < list2.Count; l++)
					{
						T item = list2[l];
						_queryStruct.Add(item);
					}
				}
			}
		}
		return _queryStruct;
	}

	public List<T> Query(Vector2 p)
	{
		int num = Mathf.FloorToInt(p.x / GridSize.x - Offset.x);
		int num2 = Mathf.FloorToInt(p.y / GridSize.y - Offset.y);
		if (num >= 0 && num < Grid.GetLength(0) && num2 >= 0 && num2 < Grid.GetLength(1))
		{
			return Query(num, num2);
		}
		return null;
	}

	public List<T> Query(int x, int y)
	{
		return Grid[x, y];
	}

	public void Add(T obj, Rect r)
	{
		int xmin;
		int ymin;
		int xmax;
		int ymax;
		Convert(r, out xmin, out ymin, out xmax, out ymax);
		for (int i = xmin; i < xmax; i++)
		{
			if (i < 0 || i >= Grid.GetLength(0))
			{
				continue;
			}
			for (int j = ymin; j < ymax; j++)
			{
				if (j < 0 || j >= Grid.GetLength(1))
				{
					continue;
				}
				if (Grid[i, j] == null)
				{
					lock (_pool)
					{
						if (_pool.Count > 0)
						{
							Grid[i, j] = _pool[0];
							_pool.RemoveAt(0);
						}
						else
						{
							Grid[i, j] = new List<T>();
						}
					}
				}
				Grid[i, j].Add(obj);
			}
		}
	}

	public void Remove(T obj, Rect r)
	{
		int xmin;
		int ymin;
		int xmax;
		int ymax;
		Convert(r, out xmin, out ymin, out xmax, out ymax);
		for (int i = xmin; i < xmax; i++)
		{
			if (i < 0 || i >= Grid.GetLength(0))
			{
				continue;
			}
			for (int j = ymin; j < ymax; j++)
			{
				if (j < 0 || j >= Grid.GetLength(1) || Grid[i, j] == null)
				{
					continue;
				}
				Grid[i, j].Remove(obj);
				if (Grid[i, j].Count == 0)
				{
					lock (_pool)
					{
						_pool.Add(Grid[i, j]);
					}
					Grid[i, j] = null;
				}
			}
		}
	}
}
