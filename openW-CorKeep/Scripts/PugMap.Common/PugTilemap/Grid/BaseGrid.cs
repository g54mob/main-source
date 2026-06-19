using System;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugTilemap.Grid
{
	public abstract class BaseGrid<CellType>
	{
		public RectInt bounds;

		[HideInInspector]
		[SerializeField]
		public CellType[] cells;

		private CellType defaultCell;

		public BaseGrid()
			: this(default(RectInt))
		{
		}

		public BaseGrid(RectInt bounds)
		{
			this.bounds = bounds;
			cells = new CellType[bounds.size.y * bounds.size.x];
			defaultCell = default(CellType);
		}

		public void Resize(RectInt newBounds)
		{
			if (!newBounds.Equals(bounds))
			{
				RectInt rect = bounds;
				CellType[] array = cells;
				bounds = newBounds;
				cells = new CellType[newBounds.size.y * newBounds.size.x];
				RectInt rectInt = rect.Intersection(newBounds);
				for (int i = rectInt.yMin; i < rectInt.yMax; i++)
				{
					Array.Copy(array, destinationArray: cells, sourceIndex: rect.RowMajorCell(rectInt.xMin, i), destinationIndex: newBounds.RowMajorCell(rectInt.xMin, i), length: rectInt.xMax - rectInt.xMin);
				}
			}
		}

		public void Recycle(RectInt newBounds, bool warning = true)
		{
			if (bounds.size == newBounds.size)
			{
				Array.Clear(cells, 0, cells.Length);
			}
			else
			{
				cells = new CellType[newBounds.size.y * newBounds.size.x];
				if (warning)
				{
					Debug.Log("Recycling CellMap to incompatible bounds will generate garbage. " + $"old bounds: {bounds}, new bounds: {newBounds}");
				}
			}
			bounds = newBounds;
		}

		public void Clear()
		{
			bounds = default(RectInt);
			cells = new CellType[0];
		}

		public void ClearRect(RectInt r)
		{
			if (!r.FullyOutside(bounds))
			{
				RectInt rectInt = bounds.Intersection(r);
				for (int i = rectInt.yMin; i < rectInt.yMax; i++)
				{
					Array.Clear(cells, bounds.RowMajorCell(rectInt.xMin, i), rectInt.xMax - rectInt.xMin);
				}
			}
		}

		public void Set(Vector2Int pos, CellType c)
		{
			if (!bounds.Contains(pos))
			{
				if (IsTypeEmpty(c))
				{
					return;
				}
				RectInt newBounds = bounds.Fit(pos);
				Resize(newBounds);
			}
			cells[bounds.RowMajorCell(pos.x, pos.y)] = c;
		}

		public void UnsafeSet(Vector2Int pos, CellType c)
		{
			cells[bounds.RowMajorCell(pos.x, pos.y)] = c;
		}

		public RectInt GetMinimumBounds()
		{
			RectInt rectInt = default(RectInt);
			CellEnumerator<CellType> enumerator = Enumerate().GetEnumerator();
			while (enumerator.MoveNext())
			{
				CellEnumerator<CellType> current = enumerator.Current;
				if (!IsTypeEmpty(current.item))
				{
					rectInt = rectInt.Fit(current.pos);
				}
			}
			return rectInt;
		}

		public void Trim()
		{
			Resize(GetMinimumBounds());
		}

		public CellType Get(Vector2Int pos)
		{
			if (!bounds.Contains(pos))
			{
				return defaultCell;
			}
			return cells[bounds.RowMajorCell(pos.x, pos.y)];
		}

		public CellType UnsafeGet(Vector2Int pos)
		{
			return cells[bounds.RowMajorCell(pos.x, pos.y)];
		}

		public abstract bool IsTypeEmpty(CellType c);

		public bool IsEmpty()
		{
			return bounds.size == Vector2Int.zero;
		}

		public CellEnumerator<CellType> Enumerate(RectInt rect)
		{
			return new CellEnumerator<CellType>(this, rect);
		}

		public CellEnumerator<CellType> Enumerate()
		{
			return new CellEnumerator<CellType>(this, bounds);
		}

		public void CopyFrom(BaseGrid<CellType> g)
		{
			Recycle(g.bounds);
			Array.Copy(g.cells, cells, g.cells.Length);
		}
	}
}
