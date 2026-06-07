using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Mirror
{
	public class SyncIDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, SyncObject, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		public delegate void SyncDictionaryChanged(Operation op, TKey key, TValue item);

		public enum Operation : byte
		{
			OP_ADD = 0,
			OP_CLEAR = 1,
			OP_REMOVE = 2,
			OP_SET = 3
		}

		private struct Change
		{
			internal Operation operation;

			internal TKey key;

			internal TValue item;
		}

		protected readonly IDictionary<TKey, TValue> objects;

		private readonly List<Change> changes;

		private int changesAhead;

		public int Count => 0;

		public bool IsReadOnly { get; private set; }

		public bool IsDirty => false;

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => null;

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => null;

		public TValue Item
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public event SyncDictionaryChanged Callback
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Reset()
		{
		}

		public void Flush()
		{
		}

		public SyncIDictionary(IDictionary<TKey, TValue> objects)
		{
		}

		private void AddOperation(Operation op, TKey key, TValue item)
		{
		}

		public void OnSerializeAll(NetworkWriter writer)
		{
		}

		public void OnSerializeDelta(NetworkWriter writer)
		{
		}

		public void OnDeserializeAll(NetworkReader reader)
		{
		}

		public void OnDeserializeDelta(NetworkReader reader)
		{
		}

		public void Clear()
		{
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public void CopyTo([NotNull] KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
