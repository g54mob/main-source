using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class Set<T> : CollectionBase<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ICloneable
	{
		private readonly IEqualityComparer<T> equalityComparer;

		private Hash<T> hash;

		public IEqualityComparer<T> Comparer => null;

		public sealed override int Count => 0;

		public Set()
		{
		}

		public Set(IEqualityComparer<T> equalityComparer)
		{
		}

		public Set(IEnumerable<T> collection)
		{
		}

		public Set(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer)
		{
		}

		private Set(IEqualityComparer<T> equalityComparer, Hash<T> hash)
		{
		}

		object ICloneable.Clone()
		{
			return null;
		}

		public Set<T> Clone()
		{
			return null;
		}

		public Set<T> CloneContents()
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

		private void CheckConsistentComparison(Set<T> otherSet)
		{
		}

		public bool IsSupersetOf(Set<T> otherSet)
		{
			return false;
		}

		public bool IsProperSupersetOf(Set<T> otherSet)
		{
			return false;
		}

		public bool IsSubsetOf(Set<T> otherSet)
		{
			return false;
		}

		public bool IsProperSubsetOf(Set<T> otherSet)
		{
			return false;
		}

		public bool IsEqualTo(Set<T> otherSet)
		{
			return false;
		}

		public bool IsDisjointFrom(Set<T> otherSet)
		{
			return false;
		}

		public void UnionWith(Set<T> otherSet)
		{
		}

		public Set<T> Union(Set<T> otherSet)
		{
			return null;
		}

		public void IntersectionWith(Set<T> otherSet)
		{
		}

		public Set<T> Intersection(Set<T> otherSet)
		{
			return null;
		}

		public void DifferenceWith(Set<T> otherSet)
		{
		}

		public Set<T> Difference(Set<T> otherSet)
		{
			return null;
		}

		public void SymmetricDifferenceWith(Set<T> otherSet)
		{
		}

		public Set<T> SymmetricDifference(Set<T> otherSet)
		{
			return null;
		}
	}
}
