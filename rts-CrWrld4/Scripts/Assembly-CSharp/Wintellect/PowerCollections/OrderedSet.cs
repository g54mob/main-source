using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class OrderedSet<T> : CollectionBase<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ICloneable
	{
		[Serializable]
		private class ListView : ReadOnlyListBase<T>
		{
			private readonly OrderedSet<T> mySet;

			private readonly RedBlackTree<T>.RangeTester rangeTester;

			private readonly bool entireTree;

			private readonly bool reversed;

			public override int Count => 0;

			public override T Item => default(T);

			public ListView(OrderedSet<T> mySet, RedBlackTree<T>.RangeTester rangeTester, bool entireTree, bool reversed)
			{
			}

			public override int IndexOf(T item)
			{
				return 0;
			}
		}

		[Serializable]
		public class View : CollectionBase<T>, ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private readonly OrderedSet<T> mySet;

			private readonly RedBlackTree<T>.RangeTester rangeTester;

			private readonly bool entireTree;

			private readonly bool reversed;

			public sealed override int Count => 0;

			public T Item => default(T);

			internal View(OrderedSet<T> mySet, RedBlackTree<T>.RangeTester rangeTester, bool entireTree, bool reversed)
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

			public new bool Add(T item)
			{
				return false;
			}

			void ICollection<T>.Add(T item)
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

		public OrderedSet()
		{
		}

		public OrderedSet(Comparison<T> comparison)
		{
		}

		public OrderedSet(IComparer<T> comparer)
		{
		}

		public OrderedSet(IEnumerable<T> collection)
		{
		}

		public OrderedSet(IEnumerable<T> collection, Comparison<T> comparison)
		{
		}

		public OrderedSet(IEnumerable<T> collection, IComparer<T> comparer)
		{
		}

		private OrderedSet(IComparer<T> comparer, RedBlackTree<T> tree)
		{
		}

		object ICloneable.Clone()
		{
			return null;
		}

		public OrderedSet<T> Clone()
		{
			return null;
		}

		public OrderedSet<T> CloneContents()
		{
			return null;
		}

		public sealed override IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		public sealed override bool Contains(T item)
		{
			return false;
		}

		public bool TryGetItem(T item, out T foundItem)
		{
			foundItem = default(T);
			return false;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public new bool Add(T item)
		{
			return false;
		}

		void ICollection<T>.Add(T item)
		{
		}

		public void AddMany(IEnumerable<T> collection)
		{
		}

		public sealed override bool Remove(T item)
		{
			return false;
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

		private void CheckConsistentComparison(OrderedSet<T> otherSet)
		{
		}

		public bool IsSupersetOf(OrderedSet<T> otherSet)
		{
			return false;
		}

		public bool IsProperSupersetOf(OrderedSet<T> otherSet)
		{
			return false;
		}

		public bool IsSubsetOf(OrderedSet<T> otherSet)
		{
			return false;
		}

		public bool IsProperSubsetOf(OrderedSet<T> otherSet)
		{
			return false;
		}

		public bool IsEqualTo(OrderedSet<T> otherSet)
		{
			return false;
		}

		public void UnionWith(OrderedSet<T> otherSet)
		{
		}

		public bool IsDisjointFrom(OrderedSet<T> otherSet)
		{
			return false;
		}

		public OrderedSet<T> Union(OrderedSet<T> otherSet)
		{
			return null;
		}

		public void IntersectionWith(OrderedSet<T> otherSet)
		{
		}

		public OrderedSet<T> Intersection(OrderedSet<T> otherSet)
		{
			return null;
		}

		public void DifferenceWith(OrderedSet<T> otherSet)
		{
		}

		public OrderedSet<T> Difference(OrderedSet<T> otherSet)
		{
			return null;
		}

		public void SymmetricDifferenceWith(OrderedSet<T> otherSet)
		{
		}

		public OrderedSet<T> SymmetricDifference(OrderedSet<T> otherSet)
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
