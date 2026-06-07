using System;
using System.Collections.Generic;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	public class SplayTree<TKey, TValue> : BinarySearchTreeBase<TKey, TValue>
	{
		private static readonly KeyValuePair<TKey, TValue> nullPair;

		public override KeyValuePair<TKey, TValue> Maximum
		{
			get
			{
				KeyValuePair<TKey, TValue> maximum = base.Maximum;
				Splay(maximum);
				return maximum;
			}
		}

		public override KeyValuePair<TKey, TValue> Minimum
		{
			get
			{
				KeyValuePair<TKey, TValue> minimum = base.Minimum;
				Splay(minimum);
				return minimum;
			}
		}

		public SplayTree()
		{
		}

		public SplayTree(IComparer<TKey> comparer)
			: base(comparer)
		{
		}

		public SplayTree(Comparison<TKey> comparison)
			: base(comparison)
		{
		}

		protected override BinaryTree<KeyValuePair<TKey, TValue>> FindNode(TKey key)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = base.FindNode(key);
			if (binaryTree != null)
			{
				Splay(binaryTree.Data);
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
			Splay(item);
			int num = base.Comparer.Compare(item, base.Tree.Data);
			if (num == 0)
			{
				throw new ArgumentException("Already in the tree.", "item");
			}
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
			if (num < 0)
			{
				binaryTree.Left = base.Tree.Left;
				binaryTree.Right = base.Tree;
				base.Tree.Left = null;
			}
			else
			{
				binaryTree.Right = base.Tree.Right;
				binaryTree.Left = base.Tree;
				base.Tree.Right = null;
			}
			base.Tree = binaryTree;
		}

		private void Splay(KeyValuePair<TKey, TValue> item)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = new BinaryTree<KeyValuePair<TKey, TValue>>(nullPair, null, null, false);
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree2 = binaryTree;
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree3 = binaryTree;
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree4 = base.Tree;
			while (true)
			{
				if (base.Comparer.Compare(item, binaryTree4.Data) < 0)
				{
					if (binaryTree4.Left == null)
					{
						break;
					}
					if (base.Comparer.Compare(item, binaryTree4.Left.Data) < 0)
					{
						BinaryTree<KeyValuePair<TKey, TValue>> left = binaryTree4.Left;
						binaryTree4.Left = left.Right;
						left.Right = binaryTree4;
						binaryTree4 = left;
						if (binaryTree4.Left == null)
						{
							break;
						}
					}
					binaryTree3.Left = binaryTree4;
					binaryTree3 = binaryTree4;
					binaryTree4 = binaryTree4.Left;
					continue;
				}
				if (base.Comparer.Compare(item, binaryTree4.Data) <= 0 || binaryTree4.Right == null)
				{
					break;
				}
				if (base.Comparer.Compare(item, binaryTree4.Right.Data) > 0)
				{
					BinaryTree<KeyValuePair<TKey, TValue>> left = binaryTree4.Right;
					binaryTree4.Right = left.Left;
					left.Left = binaryTree4;
					binaryTree4 = left;
					if (binaryTree4.Right == null)
					{
						break;
					}
				}
				binaryTree2.Right = binaryTree4;
				binaryTree2 = binaryTree4;
				binaryTree4 = binaryTree4.Right;
			}
			binaryTree2.Right = binaryTree4.Left;
			binaryTree3.Left = binaryTree4.Right;
			binaryTree4.Left = binaryTree.Right;
			binaryTree4.Right = binaryTree.Left;
			base.Tree = binaryTree4;
		}

		protected override bool RemoveItem(KeyValuePair<TKey, TValue> item)
		{
			if (base.Tree == null)
			{
				return false;
			}
			Splay(item);
			if (base.Comparer.Compare(item, base.Tree.Data) == 0)
			{
				if (base.Tree.Left == null)
				{
					base.Tree = base.Tree.Right;
				}
				else
				{
					BinaryTree<KeyValuePair<TKey, TValue>> right = base.Tree.Right;
					base.Tree = base.Tree.Left;
					Splay(item);
					base.Tree.Right = right;
				}
				return true;
			}
			return false;
		}
	}
}
