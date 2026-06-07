using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class OrderedBag<T> : CollectionBase<T>, ICloneable
	{
		[Serializable]
		private class ListView : ReadOnlyListBase<T>
		{
			private readonly OrderedBag<T> myBag;

			private readonly RedBlackTree<T>.RangeTester rangeTester;

			private readonly bool entireTree;

			private readonly bool reversed;

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

			public ListView(OrderedBag<T> myBag, RedBlackTree<T>.RangeTester rangeTester, bool entireTree, bool reversed)
			{
			}

			public sealed override int IndexOf(T item)
			{
				return 0;
			}
		}

		[Serializable]
		public class View : CollectionBase<T>
		{
			private readonly OrderedBag<T> myBag;

			private readonly RedBlackTree<T>.RangeTester rangeTester;

			private readonly bool entireTree;

			private readonly bool reversed;

			public sealed override int Count => 0;

			public T Item => default(T);

			internal View(OrderedBag<T> myBag, RedBlackTree<T>.RangeTester rangeTester, bool entireTree, bool reversed)
			{
			}

			private bool ItemInView(T item)
			{
				return false;
			}

			public sealed override IEnumerator<T> GetEnumerator()
			{
				return null;
			}

			public sealed override void Clear()
			{
			}

			public sealed override void Add(T item)
			{
			}

			public sealed override bool Remove(T item)
			{
				return false;
			}

			public sealed override bool Contains(T item)
			{
				return false;
			}

			public int IndexOf(T item)
			{
				return 0;
			}

			public int LastIndexOf(T item)
			{
				return 0;
			}

			public IList<T> AsList()
			{
				return null;
			}

			public View Reversed()
			{
				return null;
			}

			public T GetFirst()
			{
				return default(T);
			}

			public T GetLast()
			{
				return default(T);
			}
		}

		private readonly IComparer<T> comparer;

		private RedBlackTree<T> tree;

		public IComparer<T> Comparer => null;

		public sealed override int Count => 0;

		public T Item => default(T);

		public OrderedBag()
		{
		}

		public OrderedBag(Comparison<T> comparison)
		{
		}

		public OrderedBag(IComparer<T> comparer)
		{
		}

		public OrderedBag(IEnumerable<T> collection)
		{
		}

		public OrderedBag(IEnumerable<T> collection, Comparison<T> comparison)
		{
		}

		public OrderedBag(IEnumerable<T> collection, IComparer<T> comparer)
		{
		}

		private OrderedBag(IComparer<T> comparer, RedBlackTree<T> tree)
		{
		}

		object ICloneable.Clone()
		{
			return null;
		}

		public OrderedBag<T> Clone()
		{
			return null;
		}

		public OrderedBag<T> CloneContents()
		{
			return null;
		}

		public int NumberOfCopies(T item)
		{
			return 0;
		}

		public sealed override IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		public sealed override bool Contains(T item)
		{
			return false;
		}

		public IEnumerable<T> GetEqualItems(T item)
		{
			return null;
		}

		public IEnumerable<T> DistinctItems()
		{
			return null;
		}

		public int LastIndexOf(T item)
		{
			return 0;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public sealed override void Add(T item)
		{
		}

		public void AddMany(IEnumerable<T> collection)
		{
		}

		public sealed override bool Remove(T item)
		{
			return false;
		}

		public int RemoveAllCopies(T item)
		{
			return 0;
		}

		public int RemoveMany(IEnumerable<T> collection)
		{
			return 0;
		}

		public sealed override void Clear()
		{
		}

		private void CheckEmpty()
		{
		}

		public T GetFirst()
		{
			return default(T);
		}

		public T GetLast()
		{
			return default(T);
		}

		public T RemoveFirst()
		{
			return default(T);
		}

		public T RemoveLast()
		{
			return default(T);
		}

		private void CheckConsistentComparison(OrderedBag<T> otherBag)
		{
		}

		public bool IsSupersetOf(OrderedBag<T> otherBag)
		{
			return false;
		}

		public bool IsProperSupersetOf(OrderedBag<T> otherBag)
		{
			return false;
		}

		public bool IsSubsetOf(OrderedBag<T> otherBag)
		{
			return false;
		}

		public bool IsProperSubsetOf(OrderedBag<T> otherBag)
		{
			return false;
		}

		public bool IsDisjointFrom(OrderedBag<T> otherBag)
		{
			return false;
		}

		public bool IsEqualTo(OrderedBag<T> otherBag)
		{
			return false;
		}

		public void UnionWith(OrderedBag<T> otherBag)
		{
		}

		public OrderedBag<T> Union(OrderedBag<T> otherBag)
		{
			return null;
		}

		public void SumWith(OrderedBag<T> otherBag)
		{
		}

		public OrderedBag<T> Sum(OrderedBag<T> otherBag)
		{
			return null;
		}

		public void IntersectionWith(OrderedBag<T> otherBag)
		{
		}

		public OrderedBag<T> Intersection(OrderedBag<T> otherBag)
		{
			return null;
		}

		public void DifferenceWith(OrderedBag<T> otherBag)
		{
		}

		public OrderedBag<T> Difference(OrderedBag<T> otherBag)
		{
			return null;
		}

		public void SymmetricDifferenceWith(OrderedBag<T> otherBag)
		{
		}

		public OrderedBag<T> SymmetricDifference(OrderedBag<T> otherBag)
		{
			return null;
		}

		public IList<T> AsList()
		{
			return null;
		}

		public View Reversed()
		{
			return null;
		}

		public View Range(T from, bool fromInclusive, T to, bool toInclusive)
		{
			return null;
		}

		public View RangeFrom(T from, bool fromInclusive)
		{
			return null;
		}

		public View RangeTo(T to, bool toInclusive)
		{
			return null;
		}
	}
}
