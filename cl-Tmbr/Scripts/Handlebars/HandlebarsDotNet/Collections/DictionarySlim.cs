using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	internal class DictionarySlim<TKey, TValue, TComparer> : IIndexed<TKey, TValue>, IReadOnlyIndexed<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TComparer : IEqualityComparer<TKey>
	{
		[DebuggerDisplay("({Key}, {Value})->{Next}")]
		private struct Entry
		{
			public TKey Key;

			public TValue Value;

			public int Next;
		}

		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private readonly DictionarySlim<TKey, TValue, TComparer> _dictionary;

			private int _index;

			private int _count;

			private KeyValuePair<TKey, TValue> _current;

			public KeyValuePair<TKey, TValue> Current => _current;

			object IEnumerator.Current => _current;

			internal Enumerator(DictionarySlim<TKey, TValue, TComparer> dictionary)
			{
				_dictionary = dictionary;
				_index = 0;
				_count = _dictionary._count;
				_current = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (_count == 0)
				{
					_current = default(KeyValuePair<TKey, TValue>);
					return false;
				}
				_count--;
				while (_dictionary._entries[_index].Next < -1)
				{
					_index++;
				}
				_current = new KeyValuePair<TKey, TValue>(_dictionary._entries[_index].Key, _dictionary._entries[_index++].Value);
				return true;
			}

			void IEnumerator.Reset()
			{
				_index = 0;
				_count = _dictionary._count;
				_current = default(KeyValuePair<TKey, TValue>);
			}

			public void Dispose()
			{
			}
		}

		private static class Throw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ConcurrentOperationsNotSupported()
			{
				throw new InvalidOperationException("ConcurrentOperationsNotSupported");
			}
		}

		private readonly TComparer _comparer;

		private static readonly Entry[] InitialEntries = new Entry[1];

		private int _count;

		private int _freeList = -1;

		private int[] _buckets;

		private Entry[] _entries;

		public int Count => _count;

		public TValue this[in TKey key]
		{
			get
			{
				if (!TryGetValue(in key, out var value))
				{
					throw new KeyNotFoundException($"{key}");
				}
				return value;
			}
			set
			{
				AddOrReplace(in key, in value);
			}
		}

		TValue IIndexed<TKey, TValue>.this[in TKey key]
		{
			get
			{
				return this[in key];
			}
			set
			{
				this[in key] = value;
			}
		}

		TValue IReadOnlyIndexed<TKey, TValue>.this[in TKey key] => this[in key];

		public DictionarySlim(TComparer comparer)
		{
			_comparer = comparer;
			_buckets = HashHelper.SizeOneIntArray;
			_entries = InitialEntries;
		}

		public DictionarySlim(int capacity, TComparer comparer)
		{
			if (capacity < 0)
			{
				throw new ArgumentException("capacity");
			}
			if (capacity < 2)
			{
				capacity = 2;
			}
			_comparer = comparer;
			capacity = HashHelper.PowerOf2(capacity);
			_buckets = new int[capacity];
			_entries = new Entry[capacity];
		}

		public DictionarySlim(IReadOnlyIndexed<TKey, TValue> other, TComparer comparer)
			: this(other.Count, comparer)
		{
			foreach (KeyValuePair<TKey, TValue> item in other)
			{
				AddOrReplace(item.Key, item.Value);
			}
		}

		public DictionarySlim(DictionarySlim<TKey, TValue, TComparer> other)
		{
			_comparer = other._comparer;
			_buckets = new int[other._buckets.Length];
			_entries = new Entry[other._entries.Length];
			Enumerator enumerator = new Enumerator(other);
			while (enumerator.MoveNext())
			{
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				AddOrReplace(current.Key, current.Value);
			}
		}

		public void Clear()
		{
			_count = 0;
			_freeList = -1;
			for (int i = 0; i < _entries.Length; i++)
			{
				_buckets[i] = 0;
				_entries[i] = default(Entry);
			}
		}

		public bool ContainsKey(in TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			Entry[] entries = _entries;
			int num = 0;
			int num2 = _buckets[_comparer.GetHashCode(key) & (_buckets.Length - 1)] - 1;
			while ((uint)num2 < (uint)entries.Length)
			{
				if (_comparer.Equals(key, entries[num2].Key))
				{
					return true;
				}
				if (num == entries.Length)
				{
					Throw.ConcurrentOperationsNotSupported();
				}
				num++;
				num2 = entries[num2].Next;
			}
			return false;
		}

		public bool TryGetValue(in TKey key, out TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			Entry[] entries = _entries;
			int num = 0;
			int num2 = _buckets[_comparer.GetHashCode(key) & (_buckets.Length - 1)] - 1;
			while ((uint)num2 < (uint)entries.Length)
			{
				if (_comparer.Equals(key, entries[num2].Key))
				{
					value = entries[num2].Value;
					return true;
				}
				if (num == entries.Length)
				{
					Throw.ConcurrentOperationsNotSupported();
				}
				num++;
				num2 = entries[num2].Next;
			}
			value = default(TValue);
			return false;
		}

		public void AddOrReplace(in TKey key, in TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			Entry[] entries = _entries;
			int num = 0;
			int num2 = _comparer.GetHashCode(key) & (_buckets.Length - 1);
			int num3 = _buckets[num2] - 1;
			while ((uint)num3 < (uint)entries.Length)
			{
				if (_comparer.Equals(key, entries[num3].Key))
				{
					entries[num3].Value = value;
				}
				if (num == entries.Length)
				{
					Throw.ConcurrentOperationsNotSupported();
				}
				num++;
				num3 = entries[num3].Next;
			}
			AddValue(key, value, num2);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddValue(TKey key, TValue value, int bucketIndex)
		{
			Entry[] array = _entries;
			int num;
			if (_freeList != -1)
			{
				num = _freeList;
				_freeList = -3 - array[_freeList].Next;
			}
			else
			{
				if (_count == array.Length || array.Length == 1)
				{
					array = Resize();
					bucketIndex = _comparer.GetHashCode(key) & (_buckets.Length - 1);
				}
				num = _count;
			}
			array[num].Key = key;
			array[num].Next = _buckets[bucketIndex] - 1;
			_buckets[bucketIndex] = num + 1;
			_count++;
			array[num].Value = value;
		}

		private Entry[] Resize()
		{
			int count = _count;
			int num = _entries.Length * 2;
			if ((uint)num > 2147483647u)
			{
				throw new InvalidOperationException("capacity overflow");
			}
			Entry[] array = new Entry[num];
			Array.Copy(_entries, 0, array, 0, count);
			int[] array2 = new int[array.Length];
			while (count-- > 0)
			{
				int num2 = _comparer.GetHashCode(array[count].Key) & (array2.Length - 1);
				array[count].Next = array2[num2] - 1;
				array2[num2] = count + 1;
			}
			_buckets = array2;
			_entries = array;
			return array;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void IIndexed<TKey, TValue>.AddOrReplace(in TKey key, in TValue value)
		{
			AddOrReplace(in key, in value);
		}

		bool IReadOnlyIndexed<TKey, TValue>.ContainsKey(in TKey key)
		{
			return ContainsKey(in key);
		}

		bool IReadOnlyIndexed<TKey, TValue>.TryGetValue(in TKey key, out TValue value)
		{
			return TryGetValue(in key, out value);
		}
	}
}
