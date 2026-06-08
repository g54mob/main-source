using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	public class FixedSizeDictionary<TKey, TValue, TComparer> : IIndexed<TKey, TValue>, IReadOnlyIndexed<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyDictionary<TKey, TValue> where TKey : notnull where TValue : notnull where TComparer : notnull, IEqualityComparer<TKey>
	{
		private struct Entry
		{
			public readonly int Index;

			public readonly int Hash;

			public readonly TKey Key;

			public readonly bool IsNotDefault;

			public readonly byte Version;

			public int Next;

			public TValue Value;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal Entry(in int hash, in int index, in TKey key, in TValue value, in byte version)
			{
				Index = index;
				Hash = hash;
				Key = key;
				Value = value;
				Version = version;
				IsNotDefault = true;
				Next = -1;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal Entry(Entry entry, byte version)
			{
				Index = entry.Index;
				Hash = entry.Hash;
				Key = entry.Key;
				Value = entry.Value;
				Version = version;
				Next = entry.Next;
				IsNotDefault = true;
			}

			public override string ToString()
			{
				return $"{Key}: {Value}";
			}
		}

		private static class Throw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void CapacityShouldBeEqual(string paramName)
			{
				throw new ArgumentException(" capacity should be equal to source dictionary", paramName);
			}
		}

		private const int MaximumSize = 1024;

		private readonly int _bucketMask;

		private readonly int _bucketSize;

		private readonly Entry[] _entries;

		private readonly EntryIndex<TKey>[] _indexes;

		private readonly TComparer _comparer;

		private byte _version;

		private int _count;

		public int Count => _count;

		public int Capacity => _entries.Length;

		public TValue this[in TKey key]
		{
			get
			{
				if (!TryGetValue(in key, out var value))
				{
					return default(TValue);
				}
				return value;
			}
			set
			{
				AddOrReplace(in key, in value, out var _);
			}
		}

		public TValue this[in EntryIndex<TKey> entryIndex]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (entryIndex.Version != _version)
				{
					return default(TValue);
				}
				return _entries[entryIndex.Index].Value;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (entryIndex.Version == _version)
				{
					_entries[entryIndex.Index].Value = value;
				}
			}
		}

		TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				if (!TryGetIndex(key, out var index))
				{
					throw new KeyNotFoundException();
				}
				return this[in index];
			}
		}

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
		{
			get
			{
				for (int index = 0; index < _indexes.Length; index++)
				{
					EntryIndex<TKey> entryIndex = _indexes[index];
					if (entryIndex.Version == _version && entryIndex.IsNotEmpty)
					{
						yield return _entries[entryIndex.Index].Key;
						continue;
					}
					break;
				}
			}
		}

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
		{
			get
			{
				for (int index = 0; index < _indexes.Length; index++)
				{
					EntryIndex<TKey> entryIndex = _indexes[index];
					if (entryIndex.Version == _version && entryIndex.IsNotEmpty)
					{
						yield return _entries[entryIndex.Index].Value;
						continue;
					}
					break;
				}
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

		public FixedSizeDictionary(int bucketsCount, int bucketSize, TComparer comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (bucketsCount > 1024)
			{
				throw new ArgumentException($" cannot be greater then {1024}", "bucketsCount");
			}
			if (bucketSize > HashHelper.Primes[HashHelper.Primes.Length - 1])
			{
				throw new ArgumentException($" cannot be greater then {HashHelper.Primes[HashHelper.Primes.Length - 1]}", "bucketSize");
			}
			bucketsCount = HashHelper.AlignBy2(bucketsCount);
			_comparer = comparer;
			_bucketMask = bucketsCount - 1;
			_bucketSize = HashHelper.FindClosestPrime(bucketSize);
			_version = 1;
			_entries = new Entry[bucketsCount * bucketSize];
			_indexes = new EntryIndex<TKey>[bucketsCount * bucketSize];
		}

		public bool TryGetIndex(TKey key, out EntryIndex<TKey> index)
		{
			if (_count == 0)
			{
				index = default(EntryIndex<TKey>);
				return false;
			}
			int hashCode = _comparer.GetHashCode(key);
			int num = hashCode & _bucketMask;
			int value = hashCode % _bucketSize;
			int index2 = num * _bucketSize + Math.Abs(value);
			Entry entry = _entries[index2];
			if (entry.Version != _version || (hashCode == entry.Hash && _comparer.Equals(key, entry.Key)))
			{
				index = new EntryIndex<TKey>(in index2, in _version);
				return true;
			}
			while (entry.Next != -1)
			{
				entry = _entries[entry.Next];
				if (!entry.IsNotDefault)
				{
					break;
				}
				if (entry.Version != _version || (hashCode == entry.Hash && _comparer.Equals(key, entry.Key)))
				{
					index = new EntryIndex<TKey>(in entry.Index, in _version);
					return true;
				}
			}
			index = default(EntryIndex<TKey>);
			return false;
		}

		public bool ContainsKey(in EntryIndex<TKey> keyIndex)
		{
			return keyIndex.Version == _version;
		}

		public bool ContainsKey(in TKey key)
		{
			if (_count == 0)
			{
				return false;
			}
			int hashCode = _comparer.GetHashCode(key);
			int num = hashCode & _bucketMask;
			int value = hashCode % _bucketSize;
			int num2 = num * _bucketSize + Math.Abs(value);
			Entry entry = _entries[num2];
			if (!entry.IsNotDefault || entry.Version != _version)
			{
				return false;
			}
			if (hashCode == entry.Hash && _comparer.Equals(key, entry.Key))
			{
				return true;
			}
			while (entry.Next != -1)
			{
				entry = _entries[entry.Next];
				if (!entry.IsNotDefault || entry.Version != _version)
				{
					return false;
				}
				if (hashCode == entry.Hash && _comparer.Equals(key, entry.Key))
				{
					return true;
				}
			}
			return false;
		}

		bool IReadOnlyDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			return ContainsKey(in key);
		}

		public bool TryGetValue(in EntryIndex<TKey> keyIndex, out TValue value)
		{
			if (_count == 0 || keyIndex.Version != _version)
			{
				value = default(TValue);
				return false;
			}
			Entry entry = _entries[keyIndex.Index];
			if (entry.IsNotDefault && entry.Version == _version)
			{
				value = entry.Value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		public bool TryGetValue(in TKey key, out TValue value)
		{
			if (_count == 0)
			{
				value = default(TValue);
				return false;
			}
			int hashCode = _comparer.GetHashCode(key);
			int num = hashCode & _bucketMask;
			int value2 = hashCode % _bucketSize;
			int num2 = num * _bucketSize + Math.Abs(value2);
			Entry entry = _entries[num2];
			if (!entry.IsNotDefault || entry.Version != _version)
			{
				value = default(TValue);
				return false;
			}
			if (hashCode == entry.Hash && _comparer.Equals(key, entry.Key))
			{
				value = entry.Value;
				return true;
			}
			while (entry.Next != -1)
			{
				entry = _entries[entry.Next];
				if (!entry.IsNotDefault || entry.Version != _version)
				{
					value = default(TValue);
					return false;
				}
				if (hashCode == entry.Hash && _comparer.Equals(key, entry.Key))
				{
					value = entry.Value;
					return true;
				}
			}
			value = default(TValue);
			return false;
		}

		void IIndexed<TKey, TValue>.AddOrReplace(in TKey key, in TValue value)
		{
			AddOrReplace(in key, in value, out var _);
		}

		public void AddOrReplace(in TKey key, in TValue value, out EntryIndex<TKey> index)
		{
			int hash = _comparer.GetHashCode(key);
			int num = hash & _bucketMask;
			int value2 = hash % _bucketSize;
			int index2 = num * _bucketSize + Math.Abs(value2);
			Entry entry = _entries[index2];
			if (!entry.IsNotDefault || entry.Version != _version)
			{
				_entries[index2] = new Entry(in hash, in index2, in key, in value, in _version);
				index = new EntryIndex<TKey>(in index2, in _version);
				_indexes[_count++] = index;
				return;
			}
			if (hash == entry.Hash && _comparer.Equals(key, entry.Key))
			{
				index = new EntryIndex<TKey>(in index2, in _version);
				_entries[index2].Value = value;
				return;
			}
			while (entry.Next != -1)
			{
				entry = _entries[entry.Next];
				if (entry.Version != _version)
				{
					_entries[entry.Index] = new Entry(in hash, in entry.Index, in key, in value, in _version);
					index = new EntryIndex<TKey>(in entry.Index, in _version);
					_indexes[_count++] = index;
					return;
				}
				if (hash == entry.Hash && _comparer.Equals(key, entry.Key))
				{
					index = new EntryIndex<TKey>(in entry.Index, in _version);
					_entries[entry.Index].Value = value;
					return;
				}
			}
			ref Entry reference = ref _entries[entry.Index];
			index2 = reference.Index + 1;
			int num2 = index2 - 1;
			for (; index2 < _entries.Length; index2++)
			{
				entry = _entries[index2];
				if (!entry.IsNotDefault || entry.Version != _version)
				{
					reference.Next = index2;
					_entries[index2] = new Entry(in hash, in index2, in key, in value, in _version);
					index = new EntryIndex<TKey>(in index2, in _version);
					_indexes[_count++] = index;
					return;
				}
			}
			index2 = num2 - 1;
			if (index2 >= _entries.Length)
			{
				index2 = _entries.Length - 1;
			}
			while (index2 >= 0)
			{
				entry = _entries[index2];
				if (!entry.IsNotDefault || entry.Version != _version)
				{
					reference.Next = index2;
					_entries[index2] = new Entry(in hash, in index2, in key, in value, in _version);
					index = new EntryIndex<TKey>(in index2, in _version);
					_indexes[_count++] = index;
					return;
				}
				index2--;
			}
			throw new InvalidOperationException("Item cannot be added due to capacity constraint.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CopyTo(FixedSizeDictionary<TKey, TValue, TComparer> destination)
		{
			if (Capacity != destination.Capacity)
			{
				Throw.CapacityShouldBeEqual("destination");
			}
			if (_count == 0)
			{
				return;
			}
			for (int i = 0; i < _indexes.Length; i++)
			{
				EntryIndex<TKey> entryIndex = _indexes[i];
				if (entryIndex.Version != _version || !entryIndex.IsNotEmpty)
				{
					destination._indexes[i] = new EntryIndex<TKey>(in entryIndex.Index, in destination._version);
					break;
				}
				Entry entry = _entries[entryIndex.Index];
				if (entry.IsNotDefault && entry.Version == _version)
				{
					destination._indexes[i] = new EntryIndex<TKey>(in entryIndex.Index, in destination._version);
					destination._entries[entryIndex.Index] = new Entry(entry, destination._version);
				}
			}
			destination._count = _count;
		}

		public void AdjustIndexes(EntryIndex<TKey>[] source, FixedSizeDictionary<TKey, TValue, TComparer> destination, EntryIndex<TKey>[] target)
		{
			if (source.Length != target.Length)
			{
				Throw.CapacityShouldBeEqual("target");
			}
			for (int i = 0; i < source.Length; i++)
			{
				target[i] = new EntryIndex<TKey>(in source[i].Index, in destination._version);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			_count = 0;
			_version++;
			if (_version == 0)
			{
				_version = 1;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
			for (int i = 0; i < _indexes.Length; i++)
			{
				EntryIndex<TKey> entryIndex = _indexes[i];
				if (entryIndex.Version != _version || !entryIndex.IsNotEmpty)
				{
					break;
				}
				_entries[entryIndex.Index] = default(Entry);
				_indexes[i] = default(EntryIndex<TKey>);
			}
			_count = 0;
			_version++;
			if (_version == 0)
			{
				_version = 1;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void OptionalClear()
		{
			if (_version % 10 == 0)
			{
				Clear();
			}
			else
			{
				Reset();
			}
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			for (int index = 0; index < _indexes.Length; index++)
			{
				EntryIndex<TKey> entryIndex = _indexes[index];
				if (entryIndex.Version == _version && entryIndex.IsNotEmpty)
				{
					Entry entry = _entries[entryIndex.Index];
					yield return new KeyValuePair<TKey, TValue>(entry.Key, entry.Value);
					continue;
				}
				break;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		bool IReadOnlyDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			return TryGetValue(in key, out value);
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
