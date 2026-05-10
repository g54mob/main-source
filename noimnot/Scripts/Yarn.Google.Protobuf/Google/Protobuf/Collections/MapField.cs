using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Google.Protobuf.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(MapField<, >.MapFieldDebugView))]
	public sealed class MapField<TKey, TValue> : IDeepCloneable<MapField<TKey, TValue>>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IEquatable<MapField<TKey, TValue>>, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		private class DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
		{
			private readonly IEnumerator<KeyValuePair<TKey, TValue>> enumerator;

			public object Current => null;

			public DictionaryEntry Entry => default(DictionaryEntry);

			public object Key => null;

			public object Value => null;

			internal DictionaryEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator)
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}
		}

		public sealed class Codec
		{
			private readonly FieldCodec<TKey> keyCodec;

			private readonly FieldCodec<TValue> valueCodec;

			private readonly uint mapTag;

			internal FieldCodec<TKey> KeyCodec => null;

			internal FieldCodec<TValue> ValueCodec => null;

			internal uint MapTag => 0u;

			public Codec(FieldCodec<TKey> keyCodec, FieldCodec<TValue> valueCodec, uint mapTag)
			{
			}
		}

		private class MapView<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ICollection
		{
			private readonly MapField<TKey, TValue> parent;

			private readonly Func<KeyValuePair<TKey, TValue>, T> projection;

			private readonly Func<T, bool> containsCheck;

			public int Count => 0;

			public bool IsReadOnly => false;

			public bool IsSynchronized => false;

			public object SyncRoot => null;

			internal MapView(MapField<TKey, TValue> parent, Func<KeyValuePair<TKey, TValue>, T> projection, Func<T, bool> containsCheck)
			{
			}

			public void Add(T item)
			{
			}

			public void Clear()
			{
			}

			public bool Contains(T item)
			{
				return false;
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
			}

			public IEnumerator<T> GetEnumerator()
			{
				return null;
			}

			public bool Remove(T item)
			{
				return false;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			public void CopyTo(Array array, int index)
			{
			}
		}

		private sealed class MapFieldDebugView
		{
			private readonly MapField<TKey, TValue> map;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public KeyValuePair<TKey, TValue>[] Items => null;

			public MapFieldDebugView(MapField<TKey, TValue> map)
			{
			}
		}

		private static readonly EqualityComparer<TValue> ValueEqualityComparer;

		private static readonly EqualityComparer<TKey> KeyEqualityComparer;

		private readonly Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> map;

		private readonly LinkedList<KeyValuePair<TKey, TValue>> list;

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

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		public int Count => 0;

		public bool IsReadOnly => false;

		bool IDictionary.IsFixedSize => false;

		ICollection IDictionary.Keys => null;

		ICollection IDictionary.Values => null;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		object IDictionary.this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => null;

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => null;

		public MapField<TKey, TValue> Clone()
		{
			return null;
		}

		public void Add(TKey key, TValue value)
		{
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		private bool ContainsValue(TValue value)
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

		public void Add(IDictionary<TKey, TValue> entries)
		{
		}

		public void MergeFrom(IDictionary<TKey, TValue> entries)
		{
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
		}

		public void Clear()
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(MapField<TKey, TValue> other)
		{
			return false;
		}

		public void AddEntriesFrom(CodedInputStream input, Codec codec)
		{
		}

		public void AddEntriesFrom(ref ParseContext ctx, Codec codec)
		{
		}

		public void WriteTo(CodedOutputStream output, Codec codec)
		{
		}

		internal IEnumerable<KeyValuePair<TKey, TValue>> GetSortedListCopy(IEnumerable<KeyValuePair<TKey, TValue>> listToSort)
		{
			return null;
		}

		public void WriteTo(ref WriteContext ctx, Codec codec)
		{
		}

		private void WriteTo(ref WriteContext ctx, Codec codec, IEnumerable<KeyValuePair<TKey, TValue>> listKvp)
		{
		}

		public int CalculateSize(Codec codec)
		{
			return 0;
		}

		private static int CalculateEntrySize(Codec codec, KeyValuePair<TKey, TValue> entry)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		void IDictionary.Add(object key, object value)
		{
		}

		bool IDictionary.Contains(object key)
		{
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		void IDictionary.Remove(object key)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}
	}
}
