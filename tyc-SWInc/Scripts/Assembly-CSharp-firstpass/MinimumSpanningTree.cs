using System;
using System.Collections.Generic;
using System.Linq;

public static class MinimumSpanningTree<T, Y> where T : class
{
	public class TreeNode
	{
		public T S;

		public Y Pos;

		public T PointTo;

		public float D;

		public TreeNode Set(T s, Y pos)
		{
			S = s;
			Pos = pos;
			D = float.MaxValue;
			PointTo = null;
			return this;
		}

		public void Clear()
		{
			S = null;
			Pos = default(Y);
			PointTo = null;
		}
	}

	private static List<TreeNode> _left;

	private static List<TreeNode> _left2;

	private static ObjectPool<TreeNode> _nodePool = new ObjectPool<TreeNode>(() => new TreeNode(), null, delegate(TreeNode x)
	{
		x.Clear();
	});

	private static void InitializeCachedLists()
	{
		if (_left == null)
		{
			_left = new List<TreeNode>();
			_left2 = new List<TreeNode>();
		}
		else
		{
			_left.Clear();
			_left2.Clear();
		}
	}

	public static void Finish(List<TreeNode> result)
	{
		lock (_nodePool)
		{
			for (int i = 0; i < result.Count; i++)
			{
				_nodePool.Release(result[i]);
			}
		}
	}

	public static List<TreeNode> Run(IEnumerable<T> items, Func<T, Y> getPoint, Func<Y, float> priority, Func<Y, Y, float> dist, List<TreeNode> result = null, bool parallel = false)
	{
		float num = float.MaxValue;
		int index = -1;
		List<TreeNode> list = null;
		List<TreeNode> list2 = null;
		int num2 = 0;
		bool flag = false;
		foreach (T item in items)
		{
			if (!flag)
			{
				if (parallel)
				{
					if (result != null)
					{
						list = result;
						list.Clear();
					}
					else
					{
						list = new List<TreeNode>();
					}
					list2 = new List<TreeNode>();
				}
				else
				{
					InitializeCachedLists();
					list = _left;
					list2 = _left2;
				}
				flag = true;
			}
			TreeNode treeNode;
			lock (_nodePool)
			{
				treeNode = _nodePool.Get().Set(item, getPoint(item));
			}
			list.Add(treeNode);
			list2.Add(treeNode);
			float num3 = priority(treeNode.Pos);
			if (num3 < num)
			{
				num = num3;
				index = num2;
			}
			num2++;
		}
		if (!flag)
		{
			if (result != null)
			{
				result.Clear();
			}
			return null;
		}
		TreeNode treeNode2 = list[index];
		list2.RemoveAt(index);
		while (list2.Count > 0)
		{
			float num4 = float.MaxValue;
			int index2 = -1;
			for (int i = 0; i < list2.Count; i++)
			{
				TreeNode treeNode3 = list2[i];
				float num5 = dist(treeNode3.Pos, treeNode2.Pos);
				if (num5 < treeNode3.D)
				{
					treeNode3.D = num5;
					treeNode3.PointTo = treeNode2.S;
				}
				if (treeNode3.D < num4)
				{
					num4 = treeNode3.D;
					index2 = i;
				}
			}
			treeNode2 = list2[index2];
			list2.RemoveAt(index2);
		}
		if (parallel)
		{
			return list;
		}
		if (result != null)
		{
			result.Clear();
			result.AddRange(list);
			return result;
		}
		return list.ToList();
	}
}
