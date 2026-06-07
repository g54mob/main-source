using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NGenerics.Comparers;
using NGenerics.Patterns.Visitor;
using NGenerics.Util;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	public abstract class BinarySearchTreeBase<T> : ISearchTree<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		protected delegate int CustomComparison<TSearch>(TSearch value, T item);

		internal const string alreadyContainedInTheTree = "The item is already contained in the tree.";

		private BinaryTree<T> tree;

		private readonly IComparer<T> comparer;

		public IComparer<T> Comparer
		{
			get
			{
				return comparer;
			}
		}

		protected BinaryTree<T> Tree
		{
			get
			{
				return tree;
			}
			set
			{
				tree = value;
			}
		}

		public virtual T Minimum
		{
			get
			{
				ValidateEmpty();
				return FindMinimumNode().Data;
			}
		}

		public virtual T Maximum
		{
			get
			{
				ValidateEmpty();
				return FindMaximumNode().Data;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public int Count { get; private set; }

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		protected BinarySearchTreeBase()
		{
			comparer = Comparer<T>.Default;
		}

		protected BinarySearchTreeBase(IComparer<T> comparer)
		{
			Guard.ArgumentNotNull(comparer, "comparer");
			this.comparer = comparer;
		}

		protected BinarySearchTreeBase(Comparison<T> comparison)
		{
			Guard.ArgumentNotNull(comparison, "comparison");
			comparer = new ComparisonComparer<T>(comparison);
		}

		protected virtual BinaryTree<T> FindNode(T item)
		{
			if (tree == null)
			{
				return null;
			}
			BinaryTree<T> binaryTree = tree;
			while (binaryTree != null)
			{
				int num = comparer.Compare(item, binaryTree.Data);
				if (num == 0)
				{
					return binaryTree;
				}
				binaryTree = ((num < 0) ? binaryTree.Left : binaryTree.Right);
			}
			return null;
		}

		protected virtual BinaryTree<T> FindNode<TSearch>(TSearch value, CustomComparison<TSearch> customComparison)
		{
			if (tree == null)
			{
				return null;
			}
			BinaryTree<T> binaryTree = tree;
			while (binaryTree != null)
			{
				int num = customComparison(value, binaryTree.Data);
				if (num == 0)
				{
					return binaryTree;
				}
				binaryTree = ((num < 0) ? binaryTree.Left : binaryTree.Right);
			}
			return null;
		}

		protected abstract bool RemoveItem(T item);

		protected abstract void AddItem(T item);

		protected BinaryTree<T> FindMaximumNode()
		{
			return FindMaximumNode(tree);
		}

		protected BinaryTree<T> FindMinimumNode()
		{
			return FindMinimumNode(tree);
		}

		protected static BinaryTree<T> FindMaximumNode(BinaryTree<T> startNode)
		{
			BinaryTree<T> binaryTree = startNode;
			while (binaryTree.Right != null)
			{
				binaryTree = binaryTree.Right;
			}
			return binaryTree;
		}

		protected static BinaryTree<T> FindMinimumNode(BinaryTree<T> startNode)
		{
			BinaryTree<T> binaryTree = startNode;
			while (binaryTree.Left != null)
			{
				binaryTree = binaryTree.Left;
			}
			return binaryTree;
		}

		private static void VisitNode(BinaryTree<T> node, OrderedVisitor<T> visitor)
		{
			if (node != null)
			{
				T data = node.Data;
				visitor.VisitPreOrder(data);
				VisitNode(node.Left, visitor);
				visitor.VisitInOrder(data);
				VisitNode(node.Right, visitor);
				visitor.VisitPostOrder(data);
			}
		}

		private void ValidateEmpty()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("The search tree is empty.");
			}
		}

		public void DepthFirstTraversal(OrderedVisitor<T> visitor)
		{
			Guard.ArgumentNotNull(visitor, "visitor");
			VisitNode(tree, visitor);
		}

		public IEnumerator<T> GetOrderedEnumerator()
		{
			if (tree != null)
			{
				TrackingVisitor<T> trackingVisitor = new TrackingVisitor<T>();
				InOrderVisitor<T> orderedVisitor = new InOrderVisitor<T>(trackingVisitor);
				tree.DepthFirstTraversal(orderedVisitor);
				IList<T> trackingList = trackingVisitor.TrackingList;
				for (int i = 0; i < trackingList.Count; i++)
				{
					yield return trackingList[i];
				}
			}
		}

		public bool Remove(T item)
		{
			bool num = RemoveItem(item);
			if (num)
			{
				Count--;
			}
			return num;
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			tree = null;
			Count = 0;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (tree == null)
			{
				yield break;
			}
			Stack<BinaryTree<T>> stack = new Stack<BinaryTree<T>>();
			stack.Push(tree);
			while (stack.Count > 0)
			{
				BinaryTree<T> binaryTree = stack.Pop();
				yield return binaryTree.Data;
				if (binaryTree.Left != null)
				{
					stack.Push(binaryTree.Left);
				}
				if (binaryTree.Right != null)
				{
					stack.Push(binaryTree.Right);
				}
			}
		}

		public void Add(T item)
		{
			AddItem(item);
			Count++;
		}

		public virtual bool Contains(T item)
		{
			return FindNode(item) != null;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			foreach (T item in tree)
			{
				array[arrayIndex++] = item;
			}
		}
	}
	[Serializable]
	public abstract class BinarySearchTreeBase<TKey, TValue> : BinarySearchTreeBase<KeyValuePair<TKey, TValue>>, ISearchTreeDictionary<TKey, TValue>, ISearchTree<KeyValuePair<TKey, TValue>>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>
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
				BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = FindNode(key);
				if (binaryTree == null)
				{
					throw new KeyNotFoundException("key");
				}
				return binaryTree.Data.Value;
			}
			set
			{
				BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = FindNode(key);
				if (binaryTree == null)
				{
					throw new KeyNotFoundException("key");
				}
				binaryTree.Data = new KeyValuePair<TKey, TValue>(key, value);
			}
		}

		protected BinarySearchTreeBase()
			: base((IComparer<KeyValuePair<TKey, TValue>>)new KeyValuePairComparer<TKey, TValue>())
		{
		}

		protected BinarySearchTreeBase(IComparer<TKey> comparer)
			: base((IComparer<KeyValuePair<TKey, TValue>>)new KeyValuePairComparer<TKey, TValue>(comparer))
		{
		}

		protected BinarySearchTreeBase(Comparison<TKey> comparison)
			: base((IComparer<KeyValuePair<TKey, TValue>>)new KeyValuePairComparer<TKey, TValue>(comparison))
		{
		}

		protected virtual BinaryTree<KeyValuePair<TKey, TValue>> FindNode(TKey key)
		{
			return FindNode(new KeyValuePair<TKey, TValue>(key, default(TValue)));
		}

		internal void ManipulateKeys(Func<TKey, TKey> manipulator)
		{
			if (base.Tree == null)
			{
				return;
			}
			Stack<BinaryTree<KeyValuePair<TKey, TValue>>> stack = new Stack<BinaryTree<KeyValuePair<TKey, TValue>>>();
			stack.Push(base.Tree);
			while (stack.Count > 0)
			{
				BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = stack.Pop();
				binaryTree.Data = new KeyValuePair<TKey, TValue>(manipulator(binaryTree.Data.Key), binaryTree.Data.Value);
				if (binaryTree.Left != null)
				{
					stack.Push(binaryTree.Left);
				}
				if (binaryTree.Right != null)
				{
					stack.Push(binaryTree.Right);
				}
			}
		}

		public bool Remove(TKey key)
		{
			return Remove(new KeyValuePair<TKey, TValue>(key, default(TValue)));
		}

		public void Add(TKey key, TValue value)
		{
			Add(new KeyValuePair<TKey, TValue>(key, value));
		}

		public bool ContainsKey(TKey key)
		{
			return FindNode(key) != null;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = FindNode(key);
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
			BinaryTree<KeyValuePair<TKey, TValue>> binaryTree = FindNode(item);
			if (binaryTree != null)
			{
				return item.Value.Equals(binaryTree.Data.Value);
			}
			return false;
		}
	}
}
