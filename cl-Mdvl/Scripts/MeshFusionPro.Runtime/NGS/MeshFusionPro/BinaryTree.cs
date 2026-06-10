using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public abstract class BinaryTree<TNode, TData> where TNode : BinaryTreeNode<TData>
	{
		private Dictionary<TData, List<TNode>> _dataToNodes;

		public IBinaryTreeNode Root => RootInternal;

		public int Height { get; private set; }

		protected TNode RootInternal { get; private set; }

		public BinaryTree()
		{
			Height = 0;
			_dataToNodes = new Dictionary<TData, List<TNode>>();
		}

		public void Add(TData data)
		{
			if (Root == null)
			{
				RootInternal = CreateRoot(data);
				Height = 1;
			}
			if (!Includes(RootInternal, data))
			{
				GrowTreeUp(data);
			}
			AddData(RootInternal, data, 1);
		}

		public bool Remove(TData data)
		{
			if (!_dataToNodes.TryGetValue(data, out var value))
			{
				return false;
			}
			foreach (TNode item in value)
			{
				item.Remove(data);
			}
			return _dataToNodes.Remove(data);
		}

		protected void GrowTreeUp(TData target)
		{
			if (!Includes(RootInternal, target))
			{
				RootInternal = ExpandRoot(RootInternal, target);
				Height++;
				GrowTreeUp(target);
			}
		}

		protected void GrowTreeDown(TNode node, TData target, int depth)
		{
			if (node.HasChilds)
			{
				throw new Exception("GrowTreeDown::" + depth + " node already has childs");
			}
			Bounds bounds = node.Bounds;
			Vector3 vector;
			Vector3 size;
			if (bounds.size.x > bounds.size.y && bounds.size.x > bounds.size.z)
			{
				vector = new Vector3(bounds.size.x / 4f, 0f, 0f);
				size = new Vector3(bounds.size.x / 2f, bounds.size.y, bounds.size.z);
			}
			else if (bounds.size.y > bounds.size.x || bounds.size.y > bounds.size.z)
			{
				vector = new Vector3(0f, bounds.size.y / 4f, 0f);
				size = new Vector3(bounds.size.x, bounds.size.y / 2f, bounds.size.z);
			}
			else
			{
				vector = new Vector3(0f, 0f, bounds.size.z / 4f);
				size = new Vector3(bounds.size.x, bounds.size.y, bounds.size.z / 2f);
			}
			bool flag = depth == Height;
			TNode val = CreateNode(bounds.center - vector, size, flag);
			TNode val2 = CreateNode(bounds.center + vector, size, flag);
			node.SetChilds(val, val2);
			if (!flag)
			{
				if (Intersects(val, target))
				{
					GrowTreeDown(val, target, depth + 1);
				}
				if (Intersects(val2, target))
				{
					GrowTreeDown(val2, target, depth + 1);
				}
			}
		}

		protected void AddData(TNode node, TData data, int depth)
		{
			if (node.IsLeaf)
			{
				node.Add(data);
				if (!_dataToNodes.TryGetValue(data, out var value))
				{
					value = new List<TNode>();
					_dataToNodes.Add(data, value);
				}
				if (!value.Contains(node))
				{
					value.Add(node);
				}
				return;
			}
			if (!node.HasChilds)
			{
				GrowTreeDown(node, data, depth + 1);
			}
			TNode node2 = (TNode)node.Left;
			TNode node3 = (TNode)node.Right;
			if (Intersects(node2, data))
			{
				AddData(node2, data, depth + 1);
			}
			if (Intersects(node3, data))
			{
				AddData(node3, data, depth + 1);
			}
		}

		protected void TreeTraversal(Func<TNode, int, bool> func)
		{
			TreeTraversal(RootInternal, 1, func);
		}

		protected void TreeTraversal(TNode current, int depth, Func<TNode, int, bool> func)
		{
			if (func(current, depth) && current.HasChilds)
			{
				TreeTraversal((TNode)current.Left, depth + 1, func);
				TreeTraversal((TNode)current.Right, depth + 1, func);
			}
		}

		protected abstract TNode CreateRoot(TData data);

		protected abstract TNode ExpandRoot(TNode root, TData target);

		protected abstract TNode CreateNode(Vector3 center, Vector3 size, bool isLeaf);

		protected abstract bool Intersects(TNode node, TData data);

		protected abstract bool Includes(TNode node, TData data);
	}
}
