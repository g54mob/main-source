using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public abstract class MultiDictionaryBase<TKey, TValue> : CollectionBase<KeyValuePair<TKey, ICollection<TValue>>>, IDictionary<TKey, ICollection<TValue>>, ICollection<KeyValuePair<TKey, ICollection<TValue>>>, IEnumerable<KeyValuePair<TKey, ICollection<TValue>>>, IEnumerable
	{
		[Serializable]
		private sealed class ValuesForKeyCollection : CollectionBase<TValue>
		{
			private readonly MultiDictionaryBase<TKey, TValue> myDictionary;

			private readonly TKey key;

			public override int Count => 0;

			public ValuesForKeyCollection(MultiDictionaryBase<TKey, TValue> myDictionary, TKey key)
			{
			}

			public override void Clear()
			{
			}

			public override void Add(TValue item)
			{
			}

			public override bool Remove(TValue item)
			{
				return false;
			}

			private static IEnumerator<TValue> NoValues()
			{
				return null;
			}

			public override IEnumerator<TValue> GetEnumerator()
			{
				return null;
			}

			public override bool Contains(TValue item)
			{
				return false;
			}
		}

		[Serializable]
		private sealed class KeysCollection : ReadOnlyCollectionBase<TKey>
		{
			private readonly MultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public KeysCollection(MultiDictionaryBase<TKey, TValue> myDictionary)
			{
			}

			public override IEnumerator<TKey> GetEnumerator()
			{
				return null;
			}

			public override bool Contains(TKey key)
			{
				return false;
			}
		}

		[Serializable]
		private sealed class ValuesCollection : ReadOnlyCollectionBase<TValue>
		{
			private readonly MultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public ValuesCollection(MultiDictionaryBase<TKey, TValue> myDictionary)
			{
			}

			public override IEnumerator<TValue> GetEnumerator()
			{
				return null;
			}

			public override bool Contains(TValue value)
			{
				return false;
			}
		}

		[Serializable]
		private sealed class EnumerableValuesCollection : ReadOnlyCollectionBase<ICollection<TValue>>
		{
			private readonly MultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public EnumerableValuesCollection(MultiDictionaryBase<TKey, TValue> myDictionary)
			{
			}

			public override IEnumerator<ICollection<TValue>> GetEnumerator()
			{
				return null;
			}

			public override bool Contains(ICollection<TValue> values)
			{
				return false;
			}
		}

		[Serializable]
		private sealed class KeyValuePairsCollection : ReadOnlyCollectionBase<KeyValuePair<TKey, TValue>>
		{
			private readonly MultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public KeyValuePairsCollection(MultiDictionaryBase<TKey, TValue> myDictionary)
			{
			}

			public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				return null;
			}

			public override bool Contains(KeyValuePair<TKey, TValue> pair)
			{
				return false;
			}
		}

		private IEqualityComparer<TValue> valueEqualityComparer;

		public abstract override int Count { get; }

		public virtual ICollection<TKey> Keys => null;

		public virtual ICollection<TValue> Values => null;

		ICollection<ICollection<TValue>> IDictionary<TKey, ICollection<TValue>>.Values => null;

		public virtual ICollection<KeyValuePair<TKey, TValue>> KeyValuePairs => null;

		public virtual ICollection<TValue> Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		ICollection<TValue> IDictionary<TKey, ICollection<TValue>>.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract override void Clear();

		protected abstract IEnumerator<TKey> EnumerateKeys();

		protected abstract bool TryEnumerateValuesForKey(TKey key, out IEnumerator<TValue> values);

		public override void Add(KeyValuePair<TKey, ICollection<TValue>> item)
		{
		}

		void IDictionary<TKey, ICollection<TValue>>.Add(TKey key, ICollection<TValue> values)
		{
		}

		public virtual void AddMany(TKey key, IEnumerable<TValue> values)
		{
		}

		public abstract void Add(TKey key, TValue value);

		public abstract bool Remove(TKey key);

		public abstract bool Remove(TKey key, TValue value);

		public override bool Remove(KeyValuePair<TKey, ICollection<TValue>> pair)
		{
			return false;
		}

		public virtual int RemoveMany(TKey key, IEnumerable<TValue> values)
		{
			return 0;
		}

		public int RemoveMany(IEnumerable<TKey> keyCollection)
		{
			return 0;
		}

		bool IDictionary<TKey, ICollection<TValue>>.TryGetValue(TKey key, out ICollection<TValue> values)
		{
			values = null;
			return false;
		}

		public virtual bool ContainsKey(TKey key)
		{
			return false;
		}

		public abstract bool Contains(TKey key, TValue value);

		public override bool Contains(KeyValuePair<TKey, ICollection<TValue>> pair)
		{
			return false;
		}

		protected virtual bool EqualValues(TValue value1, TValue value2)
		{
			return false;
		}

		protected virtual int CountValues(TKey key)
		{
			return 0;
		}

		protected virtual int CountAllValues()
		{
			return 0;
		}

		public virtual bool Replace(TKey key, TValue value)
		{
			return false;
		}

		public bool ReplaceMany(TKey key, IEnumerable<TValue> values)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		internal new string DebuggerDisplayString()
		{
			return null;
		}

		public override IEnumerator<KeyValuePair<TKey, ICollection<TValue>>> GetEnumerator()
		{
			return null;
		}
	}
}
