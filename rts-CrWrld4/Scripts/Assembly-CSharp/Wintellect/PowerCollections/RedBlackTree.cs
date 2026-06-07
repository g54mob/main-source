using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	internal class RedBlackTree<T> : IEnumerable<T>, IEnumerable
	{
		[Serializable]
		private class Node
		{
			public Node left;

			public Node right;

			public T item;

			private const uint REDMASK = 2147483648u;

			private uint count;

			public bool IsRed
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int Count
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public void IncrementCount()
			{
			}

			public void DecrementCount()
			{
			}

			public Node Clone()
			{
				return null;
			}
		}

		public delegate int RangeTester(T item);

		private readonly IComparer<T> comparer;

		private Node root;

		private int count;

		private int changeStamp;

		private Node[] stack;

		public int ElementCount => 0;

		private Node[] GetNodeStack()
		{
			return null;
		}

		internal void StopEnumerations()
		{
		}

		private void CheckEnumerationStamp(int startStamp)
		{
		}

		public RedBlackTree(IComparer<T> comparer)
		{
		}

		public RedBlackTree<T> Clone()
		{
			return null;
		}

		public bool Find(T key, bool findFirst, bool replace, out T item)
		{
			item = default(T);
			return false;
		}

		public int FindIndex(T key, bool findFirst)
		{
			return 0;
		}

		public T GetItemByIndex(int index)
		{
			return default(T);
		}

		public bool Insert(T item, DuplicatePolicy dupPolicy, out T previous)
		{
			previous = default(T);
			return false;
		}

		private Node InsertSplit(Node ggparent, Node gparent, Node parent, Node node, out bool rotated)
		{
			rotated = default(bool);
			return null;
		}

		private void Rotate(Node node, Node child, Node gchild)
		{
		}

		public bool Delete(T key, bool deleteFirst, out T item)
		{
			item = default(T);
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public RangeTester BoundedRangeTester(bool useFirst, T first, bool useLast, T last)
		{
			return null;
		}

		public RangeTester DoubleBoundedRangeTester(T first, bool firstInclusive, T last, bool lastInclusive)
		{
			return null;
		}

		public RangeTester LowerBoundedRangeTester(T first, bool inclusive)
		{
			return null;
		}

		public RangeTester UpperBoundedRangeTester(T last, bool inclusive)
		{
			return null;
		}

		public RangeTester EqualRangeTester(T equalTo)
		{
			return null;
		}

		public int EntireRangeTester(T item)
		{
			return 0;
		}

		public IEnumerable<T> EnumerateRange(RangeTester rangeTester)
		{
			return null;
		}

		private IEnumerable<T> EnumerateRangeInOrder(RangeTester rangeTester, Node node)
		{
			return null;
		}

		public IEnumerable<T> EnumerateRangeReversed(RangeTester rangeTester)
		{
			return null;
		}

		private IEnumerable<T> EnumerateRangeInReversedOrder(RangeTester rangeTester, Node node)
		{
			return null;
		}

		public bool DeleteItemFromRange(RangeTester rangeTester, bool deleteFirst, out T item)
		{
			item = default(T);
			return false;
		}

		public int DeleteRange(RangeTester rangeTester)
		{
			return 0;
		}

		public int CountRange(RangeTester rangeTester)
		{
			return 0;
		}

		private int CountRangeUnderNode(RangeTester rangeTester, Node node, bool belowRangeTop, bool aboveRangeBottom)
		{
			return 0;
		}

		public int FirstItemInRange(RangeTester rangeTester, out T item)
		{
			item = default(T);
			return 0;
		}

		public int LastItemInRange(RangeTester rangeTester, out T item)
		{
			item = default(T);
			return 0;
		}
	}
}
