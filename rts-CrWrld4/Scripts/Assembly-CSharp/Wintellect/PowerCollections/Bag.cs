using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class Bag<T> : CollectionBase<T>, ICloneable
	{
		private readonly IEqualityComparer<KeyValuePair<T, int>> equalityComparer;

		private readonly IEqualityComparer<T> keyEqualityComparer;

		private Hash<KeyValuePair<T, int>> hash;

		private int count;

		public IEqualityComparer<T> Comparer => null;

		public sealed override int Count => 0;

		private static KeyValuePair<T, int> NewPair(T item, int count)
		{
			return default(KeyValuePair<T, int>);
		}

		private static KeyValuePair<T, int> NewPair(T item)
		{
			return default(KeyValuePair<T, int>);
		}

		public Bag()
		{
		}

		public Bag(IEqualityComparer<T> equalityComparer)
		{
		}

		public Bag(IEnumerable<T> collection)
		{
		}

		public Bag(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer)
		{
		}

		private Bag(IEqualityComparer<KeyValuePair<T, int>> equalityComparer, IEqualityComparer<T> keyEqualityComparer, Hash<KeyValuePair<T, int>> hash, int count)
		{
		}

		object ICloneable.Clone()
		{
			return null;
		}

		public Bag<T> Clone()
		{
			return null;
		}

		public Bag<T> CloneContents()
		{
			return null;
		}

		public int NumberOfCopies(T item)
		{
			return 0;
		}

		public int GetRepresentativeItem(T item, out T representative)
		{
			representative = default(T);
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

		public IEnumerable<T> DistinctItems()
		{
			return null;
		}

		public sealed override void Add(T item)
		{
		}

		public void AddRepresentative(T item)
		{
		}

		public void ChangeNumberOfCopies(T item, int numCopies)
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

		private void CheckConsistentComparison(Bag<T> otherBag)
		{
		}

		public bool IsEqualTo(Bag<T> otherBag)
		{
			return false;
		}

		public bool IsSupersetOf(Bag<T> otherBag)
		{
			return false;
		}

		public bool IsProperSupersetOf(Bag<T> otherBag)
		{
			return false;
		}

		public bool IsSubsetOf(Bag<T> otherBag)
		{
			return false;
		}

		public bool IsProperSubsetOf(Bag<T> otherBag)
		{
			return false;
		}

		public bool IsDisjointFrom(Bag<T> otherBag)
		{
			return false;
		}

		public void UnionWith(Bag<T> otherBag)
		{
		}

		public Bag<T> Union(Bag<T> otherBag)
		{
			return null;
		}

		public void SumWith(Bag<T> otherBag)
		{
		}

		public Bag<T> Sum(Bag<T> otherBag)
		{
			return null;
		}

		public void IntersectionWith(Bag<T> otherBag)
		{
		}

		public Bag<T> Intersection(Bag<T> otherBag)
		{
			return null;
		}

		public void DifferenceWith(Bag<T> otherBag)
		{
		}

		public Bag<T> Difference(Bag<T> otherBag)
		{
			return null;
		}

		public void SymmetricDifferenceWith(Bag<T> otherBag)
		{
		}

		public Bag<T> SymmetricDifference(Bag<T> otherBag)
		{
			return null;
		}
	}
}
