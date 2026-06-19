using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugTilemap.Grid
{
	public class FloodFill<TCellSrc, TCellDst> where TCellDst : IEquatable<TCellDst>
	{
		private TCellSrc srcSeedValue;

		private TCellDst dstFillValue;

		private Vector2Int min;

		private Vector2Int max;

		private Stack<Vector2Int> frontier;

		private Stack<Vector2Int> next;

		private int estimatedPeakCapacity;

		private int depth;

		public BaseGrid<TCellSrc> srcGrid { get; private set; }

		public BaseGrid<TCellDst> dstGrid { get; private set; }

		public FloodFill(BaseGrid<TCellDst> dstGrid, TCellDst dstFillValue)
		{
			RectInt bounds = dstGrid.bounds;
			estimatedPeakCapacity = Math.Max(bounds.size.x, bounds.size.y) * 2 - 2;
			this.dstGrid = dstGrid;
			this.dstFillValue = dstFillValue;
			frontier = new Stack<Vector2Int>(estimatedPeakCapacity);
			next = new Stack<Vector2Int>(estimatedPeakCapacity);
		}

		public void RecycleDestinationBuffer(RectInt rect)
		{
			dstGrid.Recycle(rect);
		}

		public void Init(BaseGrid<TCellSrc> srcGrid, Vector2Int seedPosition)
		{
			this.srcGrid = srcGrid;
			depth = 0;
			frontier.Clear();
			next.Clear();
			if (!srcGrid.bounds.Contains(seedPosition))
			{
				Debug.LogWarning($"FloodFill: seed out of bounds: {seedPosition} {srcGrid.bounds}");
				return;
			}
			RectInt rectInt = dstGrid.bounds.Intersection(srcGrid.bounds);
			min = rectInt.min;
			max = rectInt.max;
			srcSeedValue = srcGrid.UnsafeGet(seedPosition);
			next.Push(seedPosition);
			dstGrid.Set(seedPosition, dstFillValue);
		}

		protected virtual bool IsSrcCellFillable(Vector2Int p)
		{
			return srcGrid.UnsafeGet(p).Equals(srcSeedValue);
		}

		public void Run(int maxSteps = 0)
		{
			int num = ((maxSteps == 0) ? int.MaxValue : (depth + maxSteps));
			int val = 0;
			while (next.Count != 0 && depth < num)
			{
				depth++;
				Stack<Vector2Int> stack = next;
				next = frontier;
				frontier = stack;
				val = Math.Max(val, frontier.Count);
				while (frontier.Count != 0)
				{
					Vector2Int vector2Int = frontier.Pop();
					Vector2Int vector2Int2 = new Vector2Int(vector2Int.x - 1, vector2Int.y);
					Vector2Int vector2Int3 = new Vector2Int(vector2Int.x + 1, vector2Int.y);
					Vector2Int vector2Int4 = new Vector2Int(vector2Int.x, vector2Int.y - 1);
					Vector2Int vector2Int5 = new Vector2Int(vector2Int.x, vector2Int.y + 1);
					if (vector2Int2.x >= min.x && IsSrcCellFillable(vector2Int2) && !dstGrid.UnsafeGet(vector2Int2).Equals(dstFillValue))
					{
						next.Push(vector2Int2);
						dstGrid.UnsafeSet(vector2Int2, dstFillValue);
					}
					if (vector2Int3.x < max.x && IsSrcCellFillable(vector2Int3) && !dstGrid.UnsafeGet(vector2Int3).Equals(dstFillValue))
					{
						next.Push(vector2Int3);
						dstGrid.UnsafeSet(vector2Int3, dstFillValue);
					}
					if (vector2Int4.y >= min.y && IsSrcCellFillable(vector2Int4) && !dstGrid.UnsafeGet(vector2Int4).Equals(dstFillValue))
					{
						next.Push(vector2Int4);
						dstGrid.UnsafeSet(vector2Int4, dstFillValue);
					}
					if (vector2Int5.y < max.y && IsSrcCellFillable(vector2Int5) && !dstGrid.UnsafeGet(vector2Int5).Equals(dstFillValue))
					{
						next.Push(vector2Int5);
						dstGrid.UnsafeSet(vector2Int5, dstFillValue);
					}
				}
			}
		}
	}
}
