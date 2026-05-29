using System;
using System.Collections;
using System.Collections.Generic;

namespace CTS.Core.Utilities
{
	public readonly struct ReadOnlyHashSet<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IEquatable<HashSet<T>>, IEquatable<ReadOnlyHashSet<T>>, IEnumerable<T, HashSet<T>.Enumerator>
	{
		private readonly HashSet<T> _set;

		public int Count => _set.Count;

		public ReadOnlyHashSet(HashSet<T> set)
		{
			_set = set;
		}

		public static implicit operator ReadOnlyHashSet<T>(HashSet<T> set)
		{
			return new ReadOnlyHashSet<T>(set);
		}

		public HashSet<T>.Enumerator GetEnumerator()
		{
			return _set.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool Contains(T obj)
		{
			return _set.Contains(obj);
		}

		public HashSet<T> Copy()
		{
			return new HashSet<T>(_set);
		}

		public static bool operator ==(ReadOnlyHashSet<T> set, HashSet<T> otherSet)
		{
			return set.Equals(otherSet);
		}

		public static bool operator !=(ReadOnlyHashSet<T> set, HashSet<T> otherSet)
		{
			return !set.Equals(otherSet);
		}

		public static bool operator ==(ReadOnlyHashSet<T> set, ReadOnlyHashSet<T> otherSet)
		{
			return set.Equals(otherSet);
		}

		public static bool operator !=(ReadOnlyHashSet<T> set, ReadOnlyHashSet<T> otherSet)
		{
			return !set.Equals(otherSet);
		}

		public static bool operator ==(HashSet<T> set, ReadOnlyHashSet<T> otherSet)
		{
			return otherSet.Equals(set);
		}

		public static bool operator !=(HashSet<T> set, ReadOnlyHashSet<T> otherSet)
		{
			return !otherSet.Equals(set);
		}

		public bool Equals(HashSet<T> other)
		{
			if (_set == null)
			{
				return other == null;
			}
			return _set.Equals(other);
		}

		public bool Equals(ReadOnlyHashSet<T> other)
		{
			return Equals(other._set);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is HashSet<T> other))
			{
				if (obj is ReadOnlyHashSet<T> other2)
				{
					return Equals(other2);
				}
				return false;
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return _set.GetHashCode();
		}
	}
}
