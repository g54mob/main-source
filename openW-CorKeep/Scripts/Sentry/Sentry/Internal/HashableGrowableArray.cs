using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sentry.Internal
{
	internal struct HashableGrowableArray<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IEquatable<HashableGrowableArray<T>> where T : notnull
	{
		private GrowableArray<T> _items;

		private int _hashCode;

		private bool _sealed;

		public T this[int index]
		{
			get
			{
				return _items[index];
			}
			set
			{
				_items[index] = value;
			}
		}

		public int Count => _items.Count;

		public HashableGrowableArray(int capacity)
		{
			_hashCode = 0;
			_sealed = false;
			_items = new GrowableArray<T>(capacity);
		}

		public void Seal()
		{
			_sealed = true;
			foreach (T item in _items)
			{
				_hashCode = HashCode.Combine(_hashCode, item.GetHashCode());
			}
		}

		public void Trim(int maxWaste)
		{
			_items.Trim(maxWaste);
		}

		public void Add(T item)
		{
			_items.Add(item);
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public bool Equals(HashableGrowableArray<T> other)
		{
			if (_hashCode == other._hashCode)
			{
				return this.SequenceEqual<T>(other);
			}
			return false;
		}

		public override bool Equals(object? obj)
		{
			if (obj is HashableGrowableArray<T> other)
			{
				return Equals(other);
			}
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}
	}
}
