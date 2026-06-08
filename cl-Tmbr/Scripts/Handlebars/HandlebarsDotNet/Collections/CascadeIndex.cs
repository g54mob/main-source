using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	public class CascadeIndex<TKey, TValue, TComparer> : IIndexed<TKey, TValue>, IReadOnlyIndexed<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TComparer : IEqualityComparer<TKey>
	{
		private static class Throw
		{
			public static void KeyNotFoundException(string message, Exception exception = null)
			{
				throw new KeyNotFoundException(message, exception);
			}
		}

		private readonly TComparer _comparer;

		private DictionarySlim<TKey, TValue, TComparer> _inner;

		public IReadOnlyIndexed<TKey, TValue> Outer { get; set; }

		public int Count => (_inner?.Count ?? 0) + OuterEnumerable().Count();

		public TValue this[in TKey key]
		{
			get
			{
				if (TryGetValue(in key, out var value))
				{
					return value;
				}
				Throw.KeyNotFoundException($"{key}");
				return default(TValue);
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

		public CascadeIndex(TComparer comparer)
			: this((IReadOnlyIndexed<TKey, TValue>)null, comparer)
		{
		}

		public CascadeIndex(IReadOnlyIndexed<TKey, TValue> outer, TComparer comparer)
		{
			_comparer = comparer;
			Outer = outer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddOrReplace(in TKey key, in TValue value)
		{
			(_inner ?? (_inner = new DictionarySlim<TKey, TValue, TComparer>(_comparer))).AddOrReplace(in key, in value);
		}

		public void Clear()
		{
			Outer = null;
			_inner?.Clear();
		}

		public bool ContainsKey(in TKey key)
		{
			DictionarySlim<TKey, TValue, TComparer> inner = _inner;
			if (inner == null || !inner.ContainsKey(in key))
			{
				return Outer?.ContainsKey(in key) ?? false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryGetValue(in TKey key, out TValue value)
		{
			value = default(TValue);
			DictionarySlim<TKey, TValue, TComparer> inner = _inner;
			if (inner == null || !inner.TryGetValue(in key, out value))
			{
				return Outer?.TryGetValue(in key, out value) ?? false;
			}
			return true;
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			foreach (KeyValuePair<TKey, TValue> item in InnerEnumerable())
			{
				yield return item;
			}
			foreach (KeyValuePair<TKey, TValue> item2 in OuterEnumerable())
			{
				yield return item2;
			}
		}

		private IEnumerable<KeyValuePair<TKey, TValue>> InnerEnumerable()
		{
			if (_inner == null)
			{
				yield break;
			}
			DictionarySlim<TKey, TValue, TComparer>.Enumerator outerEnumerator = _inner.GetEnumerator();
			while (outerEnumerator.MoveNext())
			{
				if (!_inner.ContainsKey(outerEnumerator.Current.Key))
				{
					yield return outerEnumerator.Current;
				}
			}
		}

		private IEnumerable<KeyValuePair<TKey, TValue>> OuterEnumerable()
		{
			if (Outer == null)
			{
				yield break;
			}
			using IEnumerator<KeyValuePair<TKey, TValue>> outerEnumerator = Outer.GetEnumerator();
			while (outerEnumerator.MoveNext())
			{
				if (!_inner.ContainsKey(outerEnumerator.Current.Key))
				{
					yield return outerEnumerator.Current;
				}
			}
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
