using System;
using System.Collections.Generic;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	public class BinarySearchTree<TKey, TValue> : BinarySearchTreeBase<TKey, TValue>
	{
		public BinarySearchTree()
		{
		}

		public BinarySearchTree(IComparer<TKey> comparer)
			: base(comparer)
		{
		}

		public BinarySearchTree(Comparison<TKey> comparison)
			: base(comparison)
		{
		}

		private BinaryTree<KeyValuePair<TKey, TValue>> FindNode(TKey key, out BinaryTree<KeyValuePair<TKey, TValue>> parent)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = base.Tree;
			parent = null;
			KeyValuePair<TKey, TValue> x = new KeyValuePair<TKey, TValue>(key, default(TValue));
			while (binaryTree != null)
			{
				int num = base.Comparer.Compare(x, binaryTree.Data);
				if (num == 0)
				{
					return binaryTree;
				}
				if (num < 0)
				{
					parent = binaryTree;
					binaryTree = binaryTree.Left;
				}
				else
				{
					parent = binaryTree;
					binaryTree = binaryTree.Right;
				}
			}
			return null;
		}

		private static BinaryTree<KeyValuePair<TKey, TValue>> FindMaximumNode(BinaryTree<KeyValuePair<TKey, TValue>> startNode, out BinaryTree<KeyValuePair<TKey, TValue>> parent)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = startNode;
			parent = null;
			while (binaryTree.Right != null)
			{
				parent = binaryTree;
				binaryTree = binaryTree.Right;
			}
			return binaryTree;
		}

		protected override void AddItem(KeyValuePair<TKey, TValue> item)
		{
			if (base.Tree == null)
			{
				base.Tree = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
				return;
			}
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = base.Tree;
			while (true)
			{
				int num = base.Comparer.Compare(item, binaryTree.Data);
				if (num == 0)
				{
					throw new ArgumentException("The item is already contained in the tree.", "item");
				}
				if (num < 0)
				{
					if (binaryTree.Left == null)
					{
						binaryTree.Left = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
						return;
					}
					binaryTree = binaryTree.Left;
				}
				else
				{
					if (binaryTree.Right == null)
					{
						break;
					}
					binaryTree = binaryTree.Right;
				}
			}
			binaryTree.Right = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
		}

		protected override bool RemoveItem(KeyValuePair<TKey, TValue> item)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> parent;
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = FindNode(item.Key, out parent);
			if (binaryTree == null)
			{
				return false;
			}
			if (binaryTree.Degree == 2)
			{
				BinaryTree<KeyValuePair<TKey, TValue>> parent2;
				BinaryTree<KeyValuePair<TKey, TValue>> binaryTree2 = FindMaximumNode(binaryTree.Left, out parent2);
				parent = parent2 ?? binaryTree;
				binaryTree.Data = binaryTree2.Data;
				binaryTree = binaryTree2;
			}
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree3 = binaryTree.Left ?? binaryTree.Right;
			if (binaryTree == base.Tree)
			{
				base.Tree = binaryTree3;
			}
			else if (binaryTree == parent.Left)
			{
				parent.Left = binaryTree3;
			}
			else
			{
				parent.Right = binaryTree3;
			}
			return true;
		}
	}
}
