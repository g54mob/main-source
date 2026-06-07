using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NGenerics.Comparers;
using NGenerics.Patterns.Visitor;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	public class RedBlackTree<T> : BinarySearchTreeBase<T>
	{
		public RedBlackTree()
		{
		}

		public RedBlackTree(IComparer<T> comparer)
			: base(comparer)
		{
		}

		public RedBlackTree(Comparison<T> comparison)
			: base(comparison)
		{
		}

		protected override void AddItem(T item)
		{
			if (object.Equals(item, null))
			{
				throw new ArgumentNullException("item");
			}
			RedBlackTreeNode<T> node = (RedBlackTreeNode<T>)base.Tree;
			RedBlackTreeNode<T> redBlackTreeNode = InsertNode(node, item);
			redBlackTreeNode.Color = NodeColor.Black;
			base.Tree = redBlackTreeNode;
		}

		protected override bool RemoveItem(T item)
		{
			if (base.Tree != null)
			{
				RedBlackTreeNode<T> redBlackTreeNode = new RedBlackTreeNode<T>(default(T));
				RedBlackTreeNode<T> redBlackTreeNode2 = redBlackTreeNode;
				redBlackTreeNode.Right = (RedBlackTreeNode<T>)base.Tree;
				RedBlackTreeNode<T> redBlackTreeNode3 = null;
				RedBlackTreeNode<T> redBlackTreeNode4 = null;
				bool flag = true;
				while (redBlackTreeNode2[flag] != null)
				{
					bool flag2 = flag;
					RedBlackTreeNode<T> redBlackTreeNode5 = redBlackTreeNode3;
					redBlackTreeNode3 = redBlackTreeNode2;
					redBlackTreeNode2 = redBlackTreeNode2[flag];
					int num = base.Comparer.Compare(redBlackTreeNode2.Data, item);
					if (num == 0)
					{
						redBlackTreeNode4 = redBlackTreeNode2;
					}
					flag = num < 0;
					if (!IsBlack(redBlackTreeNode2) || !IsBlack(redBlackTreeNode2[flag]))
					{
						continue;
					}
					if (IsRed(redBlackTreeNode2[!flag]))
					{
						RedBlackTreeNode<T> redBlackTreeNode6 = (redBlackTreeNode3[flag2] = SingleRotation(redBlackTreeNode2, flag));
						redBlackTreeNode3 = redBlackTreeNode6;
					}
					else
					{
						if (!IsBlack(redBlackTreeNode2[flag]))
						{
							continue;
						}
						RedBlackTreeNode<T> redBlackTreeNode8 = redBlackTreeNode3[!flag2];
						if (redBlackTreeNode8 == null)
						{
							continue;
						}
						if (IsBlack(redBlackTreeNode8.Left) && IsBlack(redBlackTreeNode8.Right))
						{
							redBlackTreeNode3.Color = NodeColor.Black;
							redBlackTreeNode8.Color = NodeColor.Red;
							redBlackTreeNode2.Color = NodeColor.Red;
							continue;
						}
						bool direction = redBlackTreeNode5.Right == redBlackTreeNode3;
						if (IsRed(redBlackTreeNode8[flag2]))
						{
							redBlackTreeNode5[direction] = DoubleRotation(redBlackTreeNode3, flag2);
						}
						else if (IsRed(redBlackTreeNode8[!flag2]))
						{
							redBlackTreeNode5[direction] = SingleRotation(redBlackTreeNode3, flag2);
						}
						RedBlackTreeNode<T> redBlackTreeNode9 = redBlackTreeNode2;
						NodeColor color = (redBlackTreeNode5[direction].Color = NodeColor.Red);
						redBlackTreeNode9.Color = color;
						redBlackTreeNode5[direction].Left.Color = NodeColor.Black;
						redBlackTreeNode5[direction].Right.Color = NodeColor.Black;
					}
				}
				if (redBlackTreeNode4 != null)
				{
					redBlackTreeNode4.Data = redBlackTreeNode2.Data;
					redBlackTreeNode3[redBlackTreeNode3.Right == redBlackTreeNode2] = redBlackTreeNode2[redBlackTreeNode2.Left == null];
				}
				base.Tree = redBlackTreeNode.Right;
				if (base.Tree != null)
				{
					((RedBlackTreeNode<T>)base.Tree).Color = NodeColor.Black;
				}
				if (redBlackTreeNode4 != null)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsRed(RedBlackTreeNode<T> node)
		{
			if (node != null)
			{
				return node.Color == NodeColor.Red;
			}
			return false;
		}

		private static bool IsBlack(RedBlackTreeNode<T> node)
		{
			if (node != null)
			{
				return node.Color == NodeColor.Black;
			}
			return true;
		}

		private RedBlackTreeNode<T> InsertNode(RedBlackTreeNode<T> node, T item)
		{
			if (node == null)
			{
				node = new RedBlackTreeNode<T>(item);
			}
			else
			{
				if (base.Comparer.Compare(item, node.Data) == 0)
				{
					throw new ArgumentException("The item is already contained in the tree.");
				}
				bool flag = base.Comparer.Compare(node.Data, item) < 0;
				node[flag] = InsertNode(node[flag], item);
				if (IsRed(node[flag]))
				{
					if (IsRed(node[!flag]))
					{
						node.Color = NodeColor.Red;
						node.Left.Color = NodeColor.Black;
						node.Right.Color = NodeColor.Black;
					}
					else if (IsRed(node[flag][flag]))
					{
						node = SingleRotation(node, !flag);
					}
					else if (IsRed(node[flag][!flag]))
					{
						node = DoubleRotation(node, !flag);
					}
				}
			}
			return node;
		}

		private static RedBlackTreeNode<T> SingleRotation(RedBlackTreeNode<T> node, bool direction)
		{
			RedBlackTreeNode<T> redBlackTreeNode = node[!direction];
			node[!direction] = redBlackTreeNode[direction];
			redBlackTreeNode[direction] = node;
			node.Color = NodeColor.Red;
			redBlackTreeNode.Color = NodeColor.Black;
			return redBlackTreeNode;
		}

		private static RedBlackTreeNode<T> DoubleRotation(RedBlackTreeNode<T> node, bool direction)
		{
			node[!direction] = SingleRotation(node[!direction], !direction);
			return SingleRotation(node, direction);
		}
	}
	[Serializable]
	public class RedBlackTree<TKey, TValue> : RedBlackTree<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		public ICollection<TKey> Keys
		{
			get
			{
				KeyTrackingVisitor<TKey, TValue> keyTrackingVisitor = new KeyTrackingVisitor<TKey, TValue>();
				InOrderVisitor<KeyValuePair<TKey, TValue>> visitor = new InOrderVisitor<KeyValuePair<TKey, TValue>>(keyTrackingVisitor);
				DepthFirstTraversal(visitor);
				return new ReadOnlyCollection<TKey>(keyTrackingVisitor.TrackingList);
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				ValueTrackingVisitor<TKey, TValue> valueTrackingVisitor = new ValueTrackingVisitor<TKey, TValue>();
				InOrderVisitor<KeyValuePair<TKey, TValue>> visitor = new InOrderVisitor<KeyValuePair<TKey, TValue>>(valueTrackingVisitor);
				DepthFirstTraversal(visitor);
				return new ReadOnlyCollection<TValue>(valueTrackingVisitor.TrackingList);
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode = FindNode(key);
				if (redBlackTreeNode == null)
				{
					throw new KeyNotFoundException("key");
				}
				return redBlackTreeNode.Data.Value;
			}
			set
			{
				RedBlackTreeNode<KeyValuePair<TKey, TValue>> redBlackTreeNode = FindNode(key);
				if (redBlackTreeNode == null)
				{
					throw new KeyNotFoundException("key");
				}
				redBlackTreeNode.Data = new KeyValuePair<TKey, TValue>(key, value);
			}
		}

		public RedBlackTree()
			: base((IComparer<KeyValuePair<TKey, TValue>>)new KeyValuePairComparer<TKey, TValue>())
		{
		}

		public RedBlackTree(IComparer<TKey> comparer)
			: base((IComparer<KeyValuePair<TKey, TValue>>)new KeyValuePairComparer<TKey, TValue>(comparer))
		{
		}

		public RedBlackTree(Comparison<TKey> comparison)
			: base((IComparer<KeyValuePair<TKey, TValue>>)new KeyValuePairComparer<TKey, TValue>(comparison))
		{
		}

		private RedBlackTreeNode<KeyValuePair<TKey, TValue>> FindNode(TKey key)
		{
			return base.FindNode(new KeyValuePair<TKey, TValue>(key, default(TValue))) as RedBlackTreeNode<KeyValuePair<TKey, TValue>>;
		}

		private bool Contains(KeyValuePair<TKey, TValue> item, bool checkValue)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = FindNode(item);
			if (binaryTree != null && !checkValue)
			{
				return true;
			}
			if (binaryTree != null)
			{
				return object.Equals(item.Value, binaryTree.Data.Value);
			}
			return false;
		}

		public bool Remove(TKey key)
		{
			return Remove(new KeyValuePair<TKey, TValue>(key, default(TValue)));
		}

		public void Add(TKey key, TValue value)
		{
			if (object.Equals(key, null))
			{
				throw new ArgumentNullException("key");
			}
			Add(new KeyValuePair<TKey, TValue>(key, value));
		}

		public bool ContainsKey(TKey key)
		{
			return Contains(new KeyValuePair<TKey, TValue>(key, default(TValue)), false);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = FindNode(new KeyValuePair<TKey, TValue>(key, default(TValue)));
			if (binaryTree == null)
			{
				value = default(TValue);
				return false;
			}
			value = binaryTree.Data.Value;
			return true;
		}

		public override bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return Contains(item, true);
		}
	}
}
