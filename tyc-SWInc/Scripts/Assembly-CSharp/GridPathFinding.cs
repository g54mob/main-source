using System.Collections.Generic;
using UnityEngine;

public static class GridPathFinding
{
	private class SortedList
	{
		private class ListNode
		{
			public float Key;

			public SplineInterp.Point2D Value;

			public ListNode Next;

			public ListNode Previous;

			public ListNode(SplineInterp.Point2D value, float key)
			{
				Value = value;
				Key = key;
			}
		}

		private ListNode Root;

		private Dictionary<SplineInterp.Point2D, ListNode> Map = new Dictionary<SplineInterp.Point2D, ListNode>();

		public void AddNode(SplineInterp.Point2D p, float val)
		{
			if (Root == null)
			{
				ListNode value = (Root = new ListNode(p, val));
				Map.Add(p, value);
				return;
			}
			ListNode value2 = null;
			if (Map.TryGetValue(p, out value2))
			{
				value2.Key = val;
				if (value2.Previous != null)
				{
					value2.Previous.Next = value2.Next;
				}
				if (value2.Next != null)
				{
					value2.Next.Previous = value2.Previous;
				}
				value2.Previous = null;
				value2.Next = null;
				if (val < Root.Key)
				{
					value2.Next = Root;
					Root.Previous = value2;
					Root = value2;
					return;
				}
			}
			else
			{
				value2 = new ListNode(p, val);
				Map.Add(p, value2);
			}
			if (val < Root.Key)
			{
				value2.Next = Root;
				Root.Previous = value2;
				Root = value2;
				return;
			}
			ListNode listNode = Root;
			ListNode next;
			for (next = Root.Next; next != null; next = next.Next)
			{
				if (val < next.Key)
				{
					value2.Previous = next.Previous;
					if (next.Previous != null)
					{
						next.Previous.Next = value2;
					}
					value2.Next = next;
					next.Previous = value2;
					break;
				}
				listNode = next;
			}
			if (next == null)
			{
				listNode.Next = value2;
				value2.Previous = listNode;
			}
		}

		public void Clear()
		{
			Root = null;
			Map.Clear();
		}

		public void RemoveNode(SplineInterp.Point2D p)
		{
			ListNode value = null;
			if (!Map.TryGetValue(p, out value))
			{
				return;
			}
			if (Root == value)
			{
				Root = value.Next;
				if (value.Next != null)
				{
					value.Next.Previous = null;
				}
			}
			else
			{
				if (value.Previous != null)
				{
					value.Previous.Next = value.Next;
				}
				if (value.Next != null)
				{
					value.Next.Previous = value.Previous;
				}
			}
			Map.Remove(p);
		}

		public SplineInterp.Point2D GetMin()
		{
			return Root.Value;
		}
	}

	private static Dictionary<SplineInterp.Point2D, SplineInterp.Point2D> cameFrom = new Dictionary<SplineInterp.Point2D, SplineInterp.Point2D>(100);

	private static Dictionary<int, float> cost = new Dictionary<int, float>(100);

	private static Dictionary<int, float> ecost = new Dictionary<int, float>(100);

	private static SortedList sorted = new SortedList();

	private static bool[,] ClosedGrid = new bool[512, 512];

	private static bool[,] OpenGrid = new bool[512, 512];

	private static int OpenCount = 0;

	public static List<SplineInterp.Point2D> FindPath(SplineInterp.Point2D start, SplineInterp.Point2D end, ref bool[,] grid, bool allowDiag)
	{
		for (int i = 0; i < grid.GetLength(1); i++)
		{
			for (int j = 0; j < grid.GetLength(0); j++)
			{
				ClosedGrid[j, i] = false;
				OpenGrid[j, i] = false;
			}
		}
		bool flag = grid[end.X, end.Y];
		grid[end.X, end.Y] = true;
		OpenCount = 0;
		cameFrom.Clear();
		cost.Clear();
		ecost.Clear();
		sorted.Clear();
		SetOpen(start.X, start.Y, true);
		cost[start.GetHashCode()] = 0f;
		float num = cost[start.GetHashCode()] + Dist3(start.X, start.Y, end.X, end.Y);
		ecost[start.GetHashCode()] = num;
		sorted.AddNode(start, num);
		while (OpenCount > 0)
		{
			SplineInterp.Point2D min = sorted.GetMin();
			if (min == end)
			{
				grid[end.X, end.Y] = flag;
				return ReconstructPath(cameFrom, end);
			}
			SetOpen(min.X, min.Y, false);
			ClosedGrid[min.X, min.Y] = true;
			sorted.RemoveNode(min);
			InnerLoop(min, end, ref grid, allowDiag);
		}
		grid[end.X, end.Y] = flag;
		return null;
	}

	private static void SetOpen(int x, int y, bool open)
	{
		if (open && !OpenGrid[x, y])
		{
			OpenCount++;
		}
		else if (!open && OpenGrid[x, y])
		{
			OpenCount--;
		}
		OpenGrid[x, y] = open;
	}

	private static void InnerLoop(SplineInterp.Point2D current, SplineInterp.Point2D end, ref bool[,] grid, bool allowDiag)
	{
		if (current.Y > 0 && grid[current.X, current.Y - 1])
		{
			InnerCheck(current, end, ref grid, current.X, current.Y - 1);
		}
		if (current.X > 0 && grid[current.X - 1, current.Y])
		{
			InnerCheck(current, end, ref grid, current.X - 1, current.Y);
		}
		if (current.Y < grid.GetLength(1) - 1 && grid[current.X, current.Y + 1])
		{
			InnerCheck(current, end, ref grid, current.X, current.Y + 1);
		}
		if (current.X < grid.GetLength(0) - 1 && grid[current.X + 1, current.Y])
		{
			InnerCheck(current, end, ref grid, current.X + 1, current.Y);
		}
		if (current.Y > 0 && current.X > 0 && (allowDiag || (grid[current.X - 1, current.Y] && grid[current.X, current.Y - 1])) && grid[current.X - 1, current.Y - 1])
		{
			InnerCheck(current, end, ref grid, current.X - 1, current.Y - 1);
		}
		if (current.Y < grid.GetLength(1) - 1 && current.X > 0 && (allowDiag || (grid[current.X - 1, current.Y] && grid[current.X, current.Y + 1])) && grid[current.X - 1, current.Y + 1])
		{
			InnerCheck(current, end, ref grid, current.X - 1, current.Y + 1);
		}
		if (current.Y > 0 && current.X < grid.GetLength(0) - 1 && (allowDiag || (grid[current.X + 1, current.Y] && grid[current.X, current.Y - 1])) && grid[current.X + 1, current.Y - 1])
		{
			InnerCheck(current, end, ref grid, current.X + 1, current.Y - 1);
		}
		if (current.Y < grid.GetLength(1) - 1 && current.X < grid.GetLength(0) - 1 && (allowDiag || (grid[current.X + 1, current.Y] && grid[current.X, current.Y + 1])) && grid[current.X + 1, current.Y + 1])
		{
			InnerCheck(current, end, ref grid, current.X + 1, current.Y + 1);
		}
	}

	private static void InnerCheck(SplineInterp.Point2D current, SplineInterp.Point2D end, ref bool[,] grid, int x, int y)
	{
		if (ClosedGrid[x, y])
		{
			return;
		}
		float num = cost[current.GetHashCode()] + Dist2(current.X, current.Y, x, y);
		SplineInterp.Point2D point2D = new SplineInterp.Point2D(x, y);
		bool flag = !OpenGrid[x, y];
		if (flag || num < cost[point2D.GetHashCode()])
		{
			cameFrom[point2D] = current;
			cost[point2D.GetHashCode()] = num;
			float num2 = cost[point2D.GetHashCode()] + Dist3(x, y, end.X, end.Y);
			ecost[point2D.GetHashCode()] = num2;
			if (flag)
			{
				SetOpen(point2D.X, point2D.Y, true);
				sorted.AddNode(point2D, num2);
			}
		}
	}

	private static List<SplineInterp.Point2D> ReconstructPath(Dictionary<SplineInterp.Point2D, SplineInterp.Point2D> cameFrom, SplineInterp.Point2D currentNode)
	{
		List<SplineInterp.Point2D> list = ((!cameFrom.ContainsKey(currentNode)) ? new List<SplineInterp.Point2D>() : ReconstructPath(cameFrom, cameFrom[currentNode]));
		list.Add(currentNode);
		return list;
	}

	private static SplineInterp.Point2D GetMin(Dictionary<int, SplineInterp.Point2D> nodes)
	{
		float num = float.PositiveInfinity;
		SplineInterp.Point2D result = default(SplineInterp.Point2D);
		foreach (KeyValuePair<int, SplineInterp.Point2D> node in nodes)
		{
			float num2 = ecost[node.Value.GetHashCode()];
			if (num2 < num)
			{
				num = num2;
				result = node.Value;
			}
		}
		return result;
	}

	public static float Dist(int x1, int y1, int x2, int y2)
	{
		int num = x1 - x2;
		int num2 = y1 - y2;
		return Mathf.Sqrt(num * num + num2 * num2);
	}

	public static float Dist2(int x1, int y1, int x2, int y2)
	{
		int num = x1 - x2;
		int num2 = y1 - y2;
		return num * num + num2 * num2;
	}

	public static float Dist3(int x1, int y1, int x2, int y2)
	{
		int a = Mathf.Abs(x1 - x2);
		int b = Mathf.Abs(y1 - y2);
		return Mathf.Max(a, b);
	}

	public static float Dist4(int x1, int y1, int x2, int y2)
	{
		int num = x1 - x2;
		int num2 = y1 - y2;
		return num + num2;
	}
}
