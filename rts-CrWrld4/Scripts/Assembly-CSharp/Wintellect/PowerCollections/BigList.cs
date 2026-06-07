using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class BigList<T> : ListBase<T>, ICloneable
	{
		[Serializable]
		private abstract class Node
		{
			public int count;

			protected bool shared;

			public int Count => 0;

			public bool Shared => false;

			public abstract int Depth { get; }

			public void MarkShared()
			{
			}

			public abstract T GetAt(int index);

			public abstract Node Subrange(int first, int last);

			public abstract Node SetAt(int index, T item);

			public abstract Node SetAtInPlace(int index, T item);

			public abstract Node Append(Node node, bool nodeIsUnused);

			public abstract Node AppendInPlace(Node node, bool nodeIsUnused);

			public abstract Node AppendInPlace(T item);

			public abstract Node RemoveRange(int first, int last);

			public abstract Node RemoveRangeInPlace(int first, int last);

			public abstract Node Insert(int index, Node node, bool nodeIsUnused);

			public abstract Node InsertInPlace(int index, T item);

			public abstract Node InsertInPlace(int index, Node node, bool nodeIsUnused);

			public Node Prepend(Node node, bool nodeIsUnused)
			{
				return null;
			}

			public Node PrependInPlace(Node node, bool nodeIsUnused)
			{
				return null;
			}

			public abstract Node PrependInPlace(T item);

			public bool IsBalanced()
			{
				return false;
			}

			public bool IsAlmostBalanced()
			{
				return false;
			}
		}

		[Serializable]
		private sealed class LeafNode : Node
		{
			public T[] items;

			public override int Depth => 0;

			public LeafNode(T item)
			{
			}

			public LeafNode(int count, T[] newItems)
			{
			}

			public override T GetAt(int index)
			{
				return default(T);
			}

			public override Node SetAtInPlace(int index, T item)
			{
				return null;
			}

			public override Node SetAt(int index, T item)
			{
				return null;
			}

			private bool MergeLeafInPlace(Node other)
			{
				return false;
			}

			private Node MergeLeaf(Node other)
			{
				return null;
			}

			public override Node PrependInPlace(T item)
			{
				return null;
			}

			public override Node AppendInPlace(T item)
			{
				return null;
			}

			public override Node AppendInPlace(Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node Append(Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node InsertInPlace(int index, T item)
			{
				return null;
			}

			public override Node InsertInPlace(int index, Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node Insert(int index, Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node RemoveRangeInPlace(int first, int last)
			{
				return null;
			}

			public override Node RemoveRange(int first, int last)
			{
				return null;
			}

			public override Node Subrange(int first, int last)
			{
				return null;
			}
		}

		[Serializable]
		private sealed class ConcatNode : Node
		{
			public Node left;

			public Node right;

			private short depth;

			public override int Depth => 0;

			public ConcatNode(Node left, Node right)
			{
			}

			private Node NewNode(Node newLeft, Node newRight)
			{
				return null;
			}

			private Node NewNodeInPlace(Node newLeft, Node newRight)
			{
				return null;
			}

			public override T GetAt(int index)
			{
				return default(T);
			}

			public override Node SetAtInPlace(int index, T item)
			{
				return null;
			}

			public override Node SetAt(int index, T item)
			{
				return null;
			}

			public override Node PrependInPlace(T item)
			{
				return null;
			}

			public override Node AppendInPlace(T item)
			{
				return null;
			}

			public override Node AppendInPlace(Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node Append(Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node InsertInPlace(int index, T item)
			{
				return null;
			}

			public override Node InsertInPlace(int index, Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node Insert(int index, Node node, bool nodeIsUnused)
			{
				return null;
			}

			public override Node RemoveRangeInPlace(int first, int last)
			{
				return null;
			}

			public override Node RemoveRange(int first, int last)
			{
				return null;
			}

			public override Node Subrange(int first, int last)
			{
				return null;
			}
		}

		[Serializable]
		private class BigListRange : ListBase<T>
		{
			private readonly BigList<T> wrappedList;

			private readonly int start;

			private int count;

			public override int Count => 0;

			public override T Item
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			public BigListRange(BigList<T> wrappedList, int start, int count)
			{
			}

			public override void Clear()
			{
			}

			public override void Insert(int index, T item)
			{
			}

			public override void RemoveAt(int index)
			{
			}

			public override IEnumerator<T> GetEnumerator()
			{
				return null;
			}
		}

		private const uint MAXITEMS = 2147483646u;

		private const int MAXLEAF = 120;

		private const int BALANCEFACTOR = 6;

		private static readonly int[] FIBONACCI;

		private const int MAXFIB = 44;

		private Node root;

		private int changeStamp;

		public sealed override int Count => 0;

		public sealed override T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		private void StopEnumerations()
		{
		}

		private void CheckEnumerationStamp(int startStamp)
		{
		}

		public BigList()
		{
		}

		public BigList(IEnumerable<T> collection)
		{
		}

		public BigList(IEnumerable<T> collection, int copies)
		{
		}

		public BigList(BigList<T> list)
		{
		}

		public BigList(BigList<T> list, int copies)
		{
		}

		private BigList(Node node)
		{
		}

		public sealed override void Clear()
		{
		}

		public sealed override void Insert(int index, T item)
		{
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
		}

		public void InsertRange(int index, BigList<T> list)
		{
		}

		public sealed override void RemoveAt(int index)
		{
		}

		public void RemoveRange(int index, int count)
		{
		}

		public sealed override void Add(T item)
		{
		}

		public void AddToFront(T item)
		{
		}

		public void AddRange(IEnumerable<T> collection)
		{
		}

		public void AddRangeToFront(IEnumerable<T> collection)
		{
		}

		public BigList<T> Clone()
		{
			return null;
		}

		object ICloneable.Clone()
		{
			return null;
		}

		public BigList<T> CloneContents()
		{
			return null;
		}

		public void AddRange(BigList<T> list)
		{
		}

		public void AddRangeToFront(BigList<T> list)
		{
		}

		public static BigList<T> operator +(BigList<T> first, BigList<T> second)
		{
			return null;
		}

		public BigList<T> GetRange(int index, int count)
		{
			return null;
		}

		public sealed override IList<T> Range(int index, int count)
		{
			return null;
		}

		private IEnumerator<T> GetEnumerator(int start, int maxItems)
		{
			return null;
		}

		public sealed override IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		private static Node NodeFromEnumerable(IEnumerable<T> collection)
		{
			return null;
		}

		private static LeafNode LeafFromEnumerator(IEnumerator<T> enumerator)
		{
			return null;
		}

		private static Node NCopiesOfNode(int copies, Node node)
		{
			return null;
		}

		private void CheckBalance()
		{
		}

		internal void Rebalance()
		{
		}

		private void AddNodeToRebalanceArray(Node[] rebalanceArray, Node node, bool shared)
		{
		}

		private static void AddBalancedNodeToRebalanceArray(Node[] rebalanceArray, Node balancedNode)
		{
		}

		public new BigList<TDest> ConvertAll<TDest>(Converter<T, TDest> converter)
		{
			return null;
		}

		public void Reverse()
		{
		}

		public void Reverse(int start, int count)
		{
		}

		public void Sort()
		{
		}

		public void Sort(IComparer<T> comparer)
		{
		}

		public void Sort(Comparison<T> comparison)
		{
		}

		public int BinarySearch(T item)
		{
			return 0;
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return 0;
		}

		public int BinarySearch(T item, Comparison<T> comparison)
		{
			return 0;
		}
	}
}
