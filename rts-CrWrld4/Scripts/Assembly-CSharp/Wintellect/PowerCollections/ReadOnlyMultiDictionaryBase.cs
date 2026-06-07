using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public abstract class ReadOnlyMultiDictionaryBase<TKey, TValue> : ReadOnlyCollectionBase<KeyValuePair<TKey, ICollection<TValue>>>, IDictionary<TKey, ICollection<TValue>>, ICollection<KeyValuePair<TKey, ICollection<TValue>>>, IEnumerable<KeyValuePair<TKey, ICollection<TValue>>>, IEnumerable
	{
		[Serializable]
		private sealed class ValuesForKeyCollection : ReadOnlyCollectionBase<TValue>
		{
			private readonly ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary;

			private readonly TKey key;

			public override int Count => 0;

			public ValuesForKeyCollection(ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary, TKey key)
			{
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
			private readonly ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public KeysCollection(ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary)
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
			private readonly ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public ValuesCollection(ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary)
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
			private readonly ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public EnumerableValuesCollection(ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary)
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
			private readonly ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public KeyValuePairsCollection(ReadOnlyMultiDictionaryBase<TKey, TValue> myDictionary)
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

		public virtual ICollection<TValue> Item => null;

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

		private void MethodModifiesCollection()
		{
		}

		protected abstract IEnumerator<TKey> EnumerateKeys();

		protected abstract bool TryEnumerateValuesForKey(TKey key, out IEnumerator<TValue> values);

		void IDictionary<TKey, ICollection<TValue>>.Add(TKey key, ICollection<TValue> values)
		{
		}

		bool IDictionary<TKey, ICollection<TValue>>.Remove(TKey key)
		{
			return false;
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
