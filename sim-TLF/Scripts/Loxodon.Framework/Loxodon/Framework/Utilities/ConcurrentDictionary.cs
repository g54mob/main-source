using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;

namespace Loxodon.Framework.Utilities
{
	[Serializable]
	[ComVisible(false)]
	[DebuggerDisplay("Count = {Count}")]
	public class ConcurrentDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		private class Tables
		{
			internal readonly Node[] m_buckets;

			internal readonly object[] m_locks;

			internal volatile int[] m_countPerLock;

			internal readonly IEqualityComparer<TKey> m_comparer;

			internal Tables(Node[] buckets, object[] locks, int[] countPerLock, IEqualityComparer<TKey> comparer)
			{
				m_buckets = buckets;
				m_locks = locks;
				m_countPerLock = countPerLock;
				m_comparer = comparer;
			}
		}

		internal class Node
		{
			internal TKey m_key;

			internal TValue m_value;

			internal volatile Node m_next;

			internal int m_hashcode;

			internal Node(TKey key, TValue value, int hashcode, Node next)
			{
				m_key = key;
				m_value = value;
				m_next = next;
				m_hashcode = hashcode;
			}
		}

		private class DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
		{
			private IEnumerator<KeyValuePair<TKey, TValue>> m_enumerator;

			public DictionaryEntry Entry => new DictionaryEntry(m_enumerator.Current.Key, m_enumerator.Current.Value);

			public object Key => m_enumerator.Current.Key;

			public object Value => m_enumerator.Current.Value;

			public object Current => Entry;

			internal DictionaryEnumerator(ConcurrentDictionary<TKey, TValue> dictionary)
			{
				m_enumerator = dictionary.GetEnumerator();
			}

			public bool MoveNext()
			{
				return m_enumerator.MoveNext();
			}

			public void Reset()
			{
				m_enumerator.Reset();
			}
		}

		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private Node[] buckets;

			private int bucketIndex;

			private Node currentNode;

			private KeyValuePair<TKey, TValue> current;

			public KeyValuePair<TKey, TValue> Current => current;

			object IEnumerator.Current => Current;

			internal Enumerator(Node[] buckets)
			{
				this.buckets = buckets;
				bucketIndex = -1;
				currentNode = null;
				current = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (currentNode != null)
				{
					currentNode = currentNode.m_next;
					if (currentNode != null)
					{
						current = new KeyValuePair<TKey, TValue>(currentNode.m_key, currentNode.m_value);
						return true;
					}
				}
				while (++bucketIndex < buckets.Length)
				{
					currentNode = Volatile.Read(ref buckets[bucketIndex]);
					if (currentNode != null)
					{
						current = new KeyValuePair<TKey, TValue>(currentNode.m_key, currentNode.m_value);
						return true;
					}
				}
				return false;
			}

			public void Reset()
			{
				bucketIndex = -1;
				currentNode = null;
				current = default(KeyValuePair<TKey, TValue>);
			}

			public void Dispose()
			{
			}
		}

		private const int MaxArrayLength = 2146435071;

		[NonSerialized]
		private volatile Tables m_tables;

		internal IEqualityComparer<TKey> m_comparer;

		[NonSerialized]
		private readonly bool m_growLockArray;

		[OptionalField]
		private int m_keyRehashCount;

		[NonSerialized]
		private int m_budget;

		private KeyValuePair<TKey, TValue>[] m_serializationArray;

		private int m_serializationConcurrencyLevel;

		private int m_serializationCapacity;

		private const int DEFAULT_CONCURRENCY_MULTIPLIER = 4;

		private const int DEFAULT_CAPACITY = 31;

		private const int MAX_LOCK_NUMBER = 1024;

		private static readonly bool s_isValueWriteAtomic = IsValueWriteAtomic();

		public TValue this[TKey key]
		{
			get
			{
				if (!TryGetValue(key, out var value))
				{
					throw new KeyNotFoundException();
				}
				return value;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				TryAddInternal(key, value, updateIfExists: true, acquireLock: true, out var _);
			}
		}

		public int Count
		{
			get
			{
				int num = 0;
				int locksAcquired = 0;
				try
				{
					AcquireAllLocks(ref locksAcquired);
					for (int i = 0; i < m_tables.m_countPerLock.Length; i++)
					{
						num += m_tables.m_countPerLock[i];
					}
					return num;
				}
				finally
				{
					ReleaseLocks(0, locksAcquired);
				}
			}
		}

		public bool IsEmpty
		{
			get
			{
				int locksAcquired = 0;
				try
				{
					AcquireAllLocks(ref locksAcquired);
					for (int i = 0; i < m_tables.m_countPerLock.Length; i++)
					{
						if (m_tables.m_countPerLock[i] != 0)
						{
							return false;
						}
					}
				}
				finally
				{
					ReleaseLocks(0, locksAcquired);
				}
				return true;
			}
		}

		public ICollection<TKey> Keys => GetKeys();

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => GetKeys();

		public ICollection<TValue> Values => GetValues();

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => GetValues();

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => GetKeys();

		ICollection IDictionary.Values => GetValues();

		object IDictionary.this[object key]
		{
			get
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				if (key is TKey && TryGetValue((TKey)key, out var value))
				{
					return value;
				}
				return null;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				if (!(key is TKey))
				{
					throw new ArgumentException(GetResource("ConcurrentDictionary_TypeOfKeyIncorrect"));
				}
				if (!(value is TValue))
				{
					throw new ArgumentException(GetResource("ConcurrentDictionary_TypeOfValueIncorrect"));
				}
				this[(TKey)key] = (TValue)value;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot
		{
			get
			{
				throw new NotSupportedException("SyncRoot Not Supported");
			}
		}

		private static int DefaultConcurrencyLevel => 4 * Environment.ProcessorCount;

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		int ICollection<KeyValuePair<TKey, TValue>>.Count
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		TValue IDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		private static bool IsValueWriteAtomic()
		{
			Type typeFromHandle = typeof(TValue);
			bool flag = typeFromHandle.IsClass || typeFromHandle == typeof(bool) || typeFromHandle == typeof(char) || typeFromHandle == typeof(byte) || typeFromHandle == typeof(sbyte) || typeFromHandle == typeof(short) || typeFromHandle == typeof(ushort) || typeFromHandle == typeof(int) || typeFromHandle == typeof(uint) || typeFromHandle == typeof(float);
			if (!flag && IntPtr.Size == 8)
			{
				flag |= typeFromHandle == typeof(double) || typeFromHandle == typeof(long);
			}
			return flag;
		}

		public ConcurrentDictionary()
			: this(DefaultConcurrencyLevel, 31, true, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
		{
		}

		public ConcurrentDictionary(int concurrencyLevel, int capacity)
			: this(concurrencyLevel, capacity, false, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
		{
		}

		public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
			: this(collection, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
		{
		}

		public ConcurrentDictionary(IEqualityComparer<TKey> comparer)
			: this(DefaultConcurrencyLevel, 31, true, comparer)
		{
		}

		public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
			: this(comparer)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			InitializeFromCollection(collection);
		}

		public ConcurrentDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
			: this(concurrencyLevel, 31, false, comparer)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			InitializeFromCollection(collection);
		}

		private void InitializeFromCollection(IEnumerable<KeyValuePair<TKey, TValue>> collection)
		{
			foreach (KeyValuePair<TKey, TValue> item in collection)
			{
				if (item.Key == null)
				{
					throw new ArgumentNullException("key");
				}
				if (!TryAddInternal(item.Key, item.Value, updateIfExists: false, acquireLock: false, out var _))
				{
					throw new ArgumentException(GetResource("ConcurrentDictionary_SourceContainsDuplicateKeys"));
				}
			}
			if (m_budget == 0)
			{
				m_budget = m_tables.m_buckets.Length / m_tables.m_locks.Length;
			}
		}

		public ConcurrentDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer)
			: this(concurrencyLevel, capacity, false, comparer)
		{
		}

		internal ConcurrentDictionary(int concurrencyLevel, int capacity, bool growLockArray, IEqualityComparer<TKey> comparer)
		{
			if (concurrencyLevel < 1)
			{
				throw new ArgumentOutOfRangeException("concurrencyLevel", GetResource("ConcurrentDictionary_ConcurrencyLevelMustBePositive"));
			}
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity", GetResource("ConcurrentDictionary_CapacityMustNotBeNegative"));
			}
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (capacity < concurrencyLevel)
			{
				capacity = concurrencyLevel;
			}
			object[] array = new object[concurrencyLevel];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new object();
			}
			int[] countPerLock = new int[array.Length];
			Node[] array2 = new Node[capacity];
			m_tables = new Tables(array2, array, countPerLock, comparer);
			m_growLockArray = growLockArray;
			m_budget = array2.Length / array.Length;
		}

		public bool TryAdd(TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TValue resultingValue;
			return TryAddInternal(key, value, updateIfExists: false, acquireLock: true, out resultingValue);
		}

		public bool ContainsKey(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TValue value;
			return TryGetValue(key, out value);
		}

		public bool TryRemove(TKey key, out TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return TryRemoveInternal(key, out value, matchValue: false, default(TValue));
		}

		private bool TryRemoveInternal(TKey key, out TValue value, bool matchValue, TValue oldValue)
		{
			while (true)
			{
				Tables tables = m_tables;
				IEqualityComparer<TKey> comparer = tables.m_comparer;
				GetBucketAndLockNo(comparer.GetHashCode(key), out var bucketNo, out var lockNo, tables.m_buckets.Length, tables.m_locks.Length);
				lock (tables.m_locks[lockNo])
				{
					if (tables != m_tables)
					{
						continue;
					}
					Node node = null;
					for (Node node2 = tables.m_buckets[bucketNo]; node2 != null; node2 = node2.m_next)
					{
						if (comparer.Equals(node2.m_key, key))
						{
							if (matchValue && !EqualityComparer<TValue>.Default.Equals(oldValue, node2.m_value))
							{
								value = default(TValue);
								return false;
							}
							if (node == null)
							{
								Volatile.Write(ref tables.m_buckets[bucketNo], node2.m_next);
							}
							else
							{
								node.m_next = node2.m_next;
							}
							value = node2.m_value;
							tables.m_countPerLock[lockNo]--;
							return true;
						}
						node = node2;
					}
					break;
				}
			}
			value = default(TValue);
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			Tables tables = m_tables;
			IEqualityComparer<TKey> comparer = tables.m_comparer;
			GetBucketAndLockNo(comparer.GetHashCode(key), out var bucketNo, out var _, tables.m_buckets.Length, tables.m_locks.Length);
			for (Node node = Volatile.Read(ref tables.m_buckets[bucketNo]); node != null; node = node.m_next)
			{
				if (comparer.Equals(node.m_key, key))
				{
					value = node.m_value;
					return true;
				}
			}
			value = default(TValue);
			return false;
		}

		public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IEqualityComparer<TValue> equalityComparer = EqualityComparer<TValue>.Default;
			while (true)
			{
				Tables tables = m_tables;
				IEqualityComparer<TKey> comparer = tables.m_comparer;
				int hashCode = comparer.GetHashCode(key);
				GetBucketAndLockNo(hashCode, out var bucketNo, out var lockNo, tables.m_buckets.Length, tables.m_locks.Length);
				lock (tables.m_locks[lockNo])
				{
					if (tables != m_tables)
					{
						continue;
					}
					Node node = null;
					for (Node node2 = tables.m_buckets[bucketNo]; node2 != null; node2 = node2.m_next)
					{
						if (comparer.Equals(node2.m_key, key))
						{
							if (equalityComparer.Equals(node2.m_value, comparisonValue))
							{
								if (s_isValueWriteAtomic)
								{
									node2.m_value = newValue;
								}
								else
								{
									Node node3 = new Node(node2.m_key, newValue, hashCode, node2.m_next);
									if (node == null)
									{
										tables.m_buckets[bucketNo] = node3;
									}
									else
									{
										node.m_next = node3;
									}
								}
								return true;
							}
							return false;
						}
						node = node2;
					}
					return false;
				}
			}
		}

		public void Clear()
		{
			int locksAcquired = 0;
			try
			{
				AcquireAllLocks(ref locksAcquired);
				Tables tables = (m_tables = new Tables(new Node[31], m_tables.m_locks, new int[m_tables.m_countPerLock.Length], m_tables.m_comparer));
				m_budget = Math.Max(1, tables.m_buckets.Length / tables.m_locks.Length);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", GetResource("ConcurrentDictionary_IndexIsNegative"));
			}
			int locksAcquired = 0;
			try
			{
				AcquireAllLocks(ref locksAcquired);
				int num = 0;
				for (int i = 0; i < m_tables.m_locks.Length; i++)
				{
					if (num < 0)
					{
						break;
					}
					num += m_tables.m_countPerLock[i];
				}
				if (array.Length - num < index || num < 0)
				{
					throw new ArgumentException(GetResource("ConcurrentDictionary_ArrayNotLargeEnough"));
				}
				CopyToPairs(array, index);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		public KeyValuePair<TKey, TValue>[] ToArray()
		{
			int locksAcquired = 0;
			checked
			{
				try
				{
					AcquireAllLocks(ref locksAcquired);
					int num = 0;
					for (int i = 0; i < m_tables.m_locks.Length; i++)
					{
						num += m_tables.m_countPerLock[i];
					}
					KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[num];
					CopyToPairs(array, 0);
					return array;
				}
				finally
				{
					ReleaseLocks(0, locksAcquired);
				}
			}
		}

		private void CopyToPairs(KeyValuePair<TKey, TValue>[] array, int index)
		{
			Node[] buckets = m_tables.m_buckets;
			for (int i = 0; i < buckets.Length; i++)
			{
				for (Node node = buckets[i]; node != null; node = node.m_next)
				{
					array[index] = new KeyValuePair<TKey, TValue>(node.m_key, node.m_value);
					index++;
				}
			}
		}

		private void CopyToEntries(DictionaryEntry[] array, int index)
		{
			Node[] buckets = m_tables.m_buckets;
			for (int i = 0; i < buckets.Length; i++)
			{
				for (Node node = buckets[i]; node != null; node = node.m_next)
				{
					array[index] = new DictionaryEntry(node.m_key, node.m_value);
					index++;
				}
			}
		}

		private void CopyToObjects(object[] array, int index)
		{
			Node[] buckets = m_tables.m_buckets;
			for (int i = 0; i < buckets.Length; i++)
			{
				for (Node node = buckets[i]; node != null; node = node.m_next)
				{
					array[index] = new KeyValuePair<TKey, TValue>(node.m_key, node.m_value);
					index++;
				}
			}
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(m_tables.m_buckets);
		}

		private bool TryAddInternal(TKey key, TValue value, bool updateIfExists, bool acquireLock, out TValue resultingValue)
		{
			checked
			{
				Tables tables;
				bool flag;
				while (true)
				{
					tables = m_tables;
					IEqualityComparer<TKey> comparer = tables.m_comparer;
					int hashCode = comparer.GetHashCode(key);
					GetBucketAndLockNo(hashCode, out var bucketNo, out var lockNo, tables.m_buckets.Length, tables.m_locks.Length);
					flag = false;
					bool lockTaken = false;
					try
					{
						if (acquireLock)
						{
							Monitor.Enter(tables.m_locks[lockNo], ref lockTaken);
						}
						if (tables != m_tables)
						{
							continue;
						}
						Node node = null;
						for (Node node2 = tables.m_buckets[bucketNo]; node2 != null; node2 = node2.m_next)
						{
							if (comparer.Equals(node2.m_key, key))
							{
								if (updateIfExists)
								{
									if (s_isValueWriteAtomic)
									{
										node2.m_value = value;
									}
									else
									{
										Node node3 = new Node(node2.m_key, value, hashCode, node2.m_next);
										if (node == null)
										{
											tables.m_buckets[bucketNo] = node3;
										}
										else
										{
											node.m_next = node3;
										}
									}
									resultingValue = value;
								}
								else
								{
									resultingValue = node2.m_value;
								}
								return false;
							}
							node = node2;
						}
						Volatile.Write(ref tables.m_buckets[bucketNo], new Node(key, value, hashCode, tables.m_buckets[bucketNo]));
						tables.m_countPerLock[lockNo]++;
						if (tables.m_countPerLock[lockNo] > m_budget)
						{
							flag = true;
						}
						break;
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(tables.m_locks[lockNo]);
						}
					}
				}
				if (flag)
				{
					GrowTable(tables, tables.m_comparer, regenerateHashKeys: false, m_keyRehashCount);
				}
				resultingValue = value;
				return true;
			}
		}

		public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (valueFactory == null)
			{
				throw new ArgumentNullException("valueFactory");
			}
			if (TryGetValue(key, out var value))
			{
				return value;
			}
			TryAddInternal(key, valueFactory(key), updateIfExists: false, acquireLock: true, out value);
			return value;
		}

		public TValue GetOrAdd(TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TryAddInternal(key, value, updateIfExists: false, acquireLock: true, out var resultingValue);
			return resultingValue;
		}

		public TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (addValueFactory == null)
			{
				throw new ArgumentNullException("addValueFactory");
			}
			if (updateValueFactory == null)
			{
				throw new ArgumentNullException("updateValueFactory");
			}
			TValue resultingValue;
			while (true)
			{
				if (TryGetValue(key, out var value))
				{
					TValue val = updateValueFactory(key, value);
					if (TryUpdate(key, val, value))
					{
						return val;
					}
				}
				else
				{
					TValue val = addValueFactory(key);
					if (TryAddInternal(key, val, updateIfExists: false, acquireLock: true, out resultingValue))
					{
						break;
					}
				}
			}
			return resultingValue;
		}

		public TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (updateValueFactory == null)
			{
				throw new ArgumentNullException("updateValueFactory");
			}
			TValue resultingValue;
			while (true)
			{
				if (TryGetValue(key, out var value))
				{
					TValue val = updateValueFactory(key, value);
					if (TryUpdate(key, val, value))
					{
						return val;
					}
				}
				else if (TryAddInternal(key, addValue, updateIfExists: false, acquireLock: true, out resultingValue))
				{
					break;
				}
			}
			return resultingValue;
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			if (!TryAdd(key, value))
			{
				throw new ArgumentException(GetResource("ConcurrentDictionary_KeyAlreadyExisted"));
			}
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			TValue value;
			return TryRemove(key, out value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
			((IDictionary<TKey, TValue>)this).Add(keyValuePair.Key, keyValuePair.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			if (!TryGetValue(keyValuePair.Key, out var value))
			{
				return false;
			}
			return EqualityComparer<TValue>.Default.Equals(value, keyValuePair.Value);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			if (keyValuePair.Key == null)
			{
				throw new ArgumentNullException(GetResource("ConcurrentDictionary_ItemKeyIsNull"));
			}
			TValue value;
			return TryRemoveInternal(keyValuePair.Key, out value, matchValue: true, keyValuePair.Value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void IDictionary.Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (!(key is TKey))
			{
				throw new ArgumentException(GetResource("ConcurrentDictionary_TypeOfKeyIncorrect"));
			}
			TValue value2;
			try
			{
				value2 = (TValue)value;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(GetResource("ConcurrentDictionary_TypeOfValueIncorrect"));
			}
			((IDictionary<TKey, TValue>)this).Add((TKey)key, value2);
		}

		bool IDictionary.Contains(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (key is TKey)
			{
				return ContainsKey((TKey)key);
			}
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new DictionaryEnumerator(this);
		}

		void IDictionary.Remove(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (key is TKey)
			{
				TryRemove((TKey)key, out var _);
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", GetResource("ConcurrentDictionary_IndexIsNegative"));
			}
			int locksAcquired = 0;
			try
			{
				AcquireAllLocks(ref locksAcquired);
				Tables tables = m_tables;
				int num = 0;
				for (int i = 0; i < tables.m_locks.Length; i++)
				{
					if (num < 0)
					{
						break;
					}
					num += tables.m_countPerLock[i];
				}
				if (array.Length - num < index || num < 0)
				{
					throw new ArgumentException(GetResource("ConcurrentDictionary_ArrayNotLargeEnough"));
				}
				if (array is KeyValuePair<TKey, TValue>[] array2)
				{
					CopyToPairs(array2, index);
					return;
				}
				if (array is DictionaryEntry[] array3)
				{
					CopyToEntries(array3, index);
					return;
				}
				if (array is object[] array4)
				{
					CopyToObjects(array4, index);
					return;
				}
				throw new ArgumentException(GetResource("ConcurrentDictionary_ArrayIncorrectType"), "array");
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		private void GrowTable(Tables tables, IEqualityComparer<TKey> newComparer, bool regenerateHashKeys, int rehashCount)
		{
			int locksAcquired = 0;
			try
			{
				AcquireLocks(0, 1, ref locksAcquired);
				if (regenerateHashKeys && rehashCount == m_keyRehashCount)
				{
					tables = m_tables;
				}
				else
				{
					if (tables != m_tables)
					{
						return;
					}
					long num = 0L;
					for (int i = 0; i < tables.m_countPerLock.Length; i++)
					{
						num += tables.m_countPerLock[i];
					}
					if (num < tables.m_buckets.Length / 4)
					{
						m_budget = 2 * m_budget;
						if (m_budget < 0)
						{
							m_budget = int.MaxValue;
						}
						return;
					}
				}
				int j = 0;
				bool flag = false;
				try
				{
					for (j = checked(tables.m_buckets.Length * 2 + 1); j % 3 == 0 || j % 5 == 0 || j % 7 == 0; j = checked(j + 2))
					{
					}
					if (j > 2146435071)
					{
						flag = true;
					}
				}
				catch (OverflowException)
				{
					flag = true;
				}
				if (flag)
				{
					j = 2146435071;
					m_budget = int.MaxValue;
				}
				AcquireLocks(1, tables.m_locks.Length, ref locksAcquired);
				object[] array = tables.m_locks;
				if (m_growLockArray && tables.m_locks.Length < 1024)
				{
					array = new object[tables.m_locks.Length * 2];
					Array.Copy(tables.m_locks, array, tables.m_locks.Length);
					for (int k = tables.m_locks.Length; k < array.Length; k++)
					{
						array[k] = new object();
					}
				}
				Node[] array2 = new Node[j];
				int[] array3 = new int[array.Length];
				for (int l = 0; l < tables.m_buckets.Length; l++)
				{
					Node node = tables.m_buckets[l];
					checked
					{
						while (node != null)
						{
							Node next = node.m_next;
							int hashcode = node.m_hashcode;
							if (regenerateHashKeys)
							{
								hashcode = newComparer.GetHashCode(node.m_key);
							}
							GetBucketAndLockNo(hashcode, out var bucketNo, out var lockNo, array2.Length, array.Length);
							array2[bucketNo] = new Node(node.m_key, node.m_value, hashcode, array2[bucketNo]);
							array3[lockNo]++;
							node = next;
						}
					}
				}
				if (regenerateHashKeys)
				{
					m_keyRehashCount++;
				}
				m_budget = Math.Max(1, array2.Length / array.Length);
				m_tables = new Tables(array2, array, array3, newComparer);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		private void GetBucketAndLockNo(int hashcode, out int bucketNo, out int lockNo, int bucketCount, int lockCount)
		{
			bucketNo = (hashcode & 0x7FFFFFFF) % bucketCount;
			lockNo = bucketNo % lockCount;
		}

		private void AcquireAllLocks(ref int locksAcquired)
		{
			AcquireLocks(0, 1, ref locksAcquired);
			AcquireLocks(1, m_tables.m_locks.Length, ref locksAcquired);
		}

		private void AcquireLocks(int fromInclusive, int toExclusive, ref int locksAcquired)
		{
			object[] locks = m_tables.m_locks;
			for (int i = fromInclusive; i < toExclusive; i++)
			{
				bool lockTaken = false;
				try
				{
					Monitor.Enter(locks[i], ref lockTaken);
				}
				finally
				{
					if (lockTaken)
					{
						locksAcquired++;
					}
				}
			}
		}

		private void ReleaseLocks(int fromInclusive, int toExclusive)
		{
			for (int i = fromInclusive; i < toExclusive; i++)
			{
				Monitor.Exit(m_tables.m_locks[i]);
			}
		}

		private ReadOnlyCollection<TKey> GetKeys()
		{
			int locksAcquired = 0;
			try
			{
				AcquireAllLocks(ref locksAcquired);
				List<TKey> list = new List<TKey>();
				for (int i = 0; i < m_tables.m_buckets.Length; i++)
				{
					for (Node node = m_tables.m_buckets[i]; node != null; node = node.m_next)
					{
						list.Add(node.m_key);
					}
				}
				return new ReadOnlyCollection<TKey>(list);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		private ReadOnlyCollection<TValue> GetValues()
		{
			int locksAcquired = 0;
			try
			{
				AcquireAllLocks(ref locksAcquired);
				List<TValue> list = new List<TValue>();
				for (int i = 0; i < m_tables.m_buckets.Length; i++)
				{
					for (Node node = m_tables.m_buckets[i]; node != null; node = node.m_next)
					{
						list.Add(node.m_value);
					}
				}
				return new ReadOnlyCollection<TValue>(list);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		[Conditional("DEBUG")]
		private void Assert(bool condition)
		{
		}

		private string GetResource(string key)
		{
			return key;
		}
	}
}
