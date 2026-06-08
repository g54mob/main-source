using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace HandlebarsDotNet.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	internal sealed class LookupSlim<TKey, TValue, TComparer> : IReadOnlyIndexed<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TComparer : IEqualityComparer<TKey>
	{
		private readonly TComparer _comparer;

		private DictionarySlim<TKey, TValue, TComparer> _inner;

		public int Count => _inner.Count;

		TValue IReadOnlyIndexed<TKey, TValue>.this[in TKey key] => _inner[in key];

		public LookupSlim(TComparer comparer)
		{
			_comparer = comparer;
			_inner = new DictionarySlim<TKey, TValue, TComparer>(comparer);
		}

		public bool ContainsKey(in TKey key)
		{
			return _inner.ContainsKey(in key);
		}

		public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
		{
			if (_inner.TryGetValue(in key, out var value))
			{
				return value;
			}
			return Write(key, valueFactory(key));
		}

		public TValue GetOrAdd<TState>(TKey key, Func<TKey, TState, TValue> valueFactory, TState state)
		{
			if (_inner.TryGetValue(in key, out var value))
			{
				return value;
			}
			return Write(key, valueFactory(key, state));
		}

		public bool TryGetValue(in TKey key, out TValue value)
		{
			return _inner.TryGetValue(in key, out value);
		}

		public void Clear()
		{
			_inner = new DictionarySlim<TKey, TValue, TComparer>(_comparer);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			foreach (KeyValuePair<TKey, TValue> item in _inner)
			{
				yield return item;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).GetEnumerator();
		}

		private TValue Write(TKey key, TValue value)
		{
			DictionarySlim<TKey, TValue, TComparer> inner = _inner;
			DictionarySlim<TKey, TValue, TComparer> dictionarySlim = new DictionarySlim<TKey, TValue, TComparer>(inner);
			dictionarySlim.AddOrReplace(in key, in value);
			Interlocked.CompareExchange(ref _inner, dictionarySlim, inner);
			return value;
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
