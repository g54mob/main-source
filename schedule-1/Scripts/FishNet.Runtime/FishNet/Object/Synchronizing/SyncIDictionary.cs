using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using JetBrains.Annotations;

namespace FishNet.Object.Synchronizing
{
	public class SyncIDictionary<TKey, TValue> : SyncBase, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		private struct CachedOnChange
		{
			internal readonly SyncDictionaryOperation Operation;

			internal readonly TKey Key;

			internal readonly TValue Value;

			public CachedOnChange(SyncDictionaryOperation operation, TKey key, TValue value)
			{
				Operation = default(SyncDictionaryOperation);
				Key = default(TKey);
				Value = default(TValue);
			}
		}

		private struct ChangeData
		{
			internal readonly SyncDictionaryOperation Operation;

			internal readonly TKey Key;

			internal readonly TValue Value;

			public ChangeData(SyncDictionaryOperation operation, TKey key, TValue value)
			{
				Operation = default(SyncDictionaryOperation);
				Key = default(TKey);
				Value = default(TValue);
			}
		}

		[APIExclude]
		public delegate void SyncDictionaryChanged(SyncDictionaryOperation op, TKey key, TValue value, bool asServer);

		public readonly IDictionary<TKey, TValue> Collection;

		public readonly IDictionary<TKey, TValue> ClientHostCollection;

		private IDictionary<TKey, TValue> _initialValues;

		private readonly List<ChangeData> _changed;

		private readonly List<CachedOnChange> _serverOnChanges;

		private readonly List<CachedOnChange> _clientOnChanges;

		private bool _valuesChanged;

		private bool _sendAll;

		[APIExclude]
		public bool IsReadOnly => false;

		public int Count => 0;

		public ICollection<TKey> Keys => null;

		[APIExclude]
		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => null;

		public ICollection<TValue> Values => null;

		[APIExclude]
		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => null;

		public TValue this[TKey key]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public event SyncDictionaryChanged OnChange
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

		[APIExclude]
		public SyncIDictionary(IDictionary<TKey, TValue> objects)
		{
		}

		public Dictionary<TKey, TValue> GetCollection(bool asServer)
		{
			return null;
		}

		protected override void Registered()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		private void AddOperation(SyncDictionaryOperation operation, TKey key, TValue value)
		{
		}

		public override void OnStartCallback(bool asServer)
		{
		}

		[APIExclude]
		public override void WriteDelta(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		[APIExclude]
		public override void WriteFull(PooledWriter writer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public override void Read(PooledReader reader, bool asServer)
		{
		}

		private void InvokeOnChange(SyncDictionaryOperation operation, TKey key, TValue value, bool asServer)
		{
		}

		[APIExclude]
		public override void ResetState()
		{
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		private void Add(TKey key, TValue value, bool asServer)
		{
		}

		public void Clear()
		{
		}

		private void Clear(bool asServer)
		{
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public void CopyTo([NotNull] KeyValuePair<TKey, TValue>[] array, int offset)
		{
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public void DirtyAll()
		{
		}

		public void Dirty(TKey key)
		{
		}

		public bool Dirty(TValue value, EqualityComparer<TValue> comparer = null)
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
