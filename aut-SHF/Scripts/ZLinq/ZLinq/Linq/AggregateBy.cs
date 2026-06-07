using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct AggregateBy<TEnumerator, TSource, TKey, TAccumulate> : IValueEnumerator<KeyValuePair<TKey, TAccumulate>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TAccumulate : notnull
	{
		private TEnumerator source;

		private DictionarySlim<TKey, TAccumulate>? dictionary;

		private DictionarySlim<TKey, TAccumulate>.Enumerator enumerator;

		public AggregateBy(TEnumerator source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer)
		{
			_003CkeySelector_003EP = null;
			_003Cseed_003EP = default(TAccumulate);
			_003Cfunc_003EP = null;
			_003CkeyComparer_003EP = null;
			this.source = default(TEnumerator);
			dictionary = null;
			enumerator = default(DictionarySlim<TKey, TAccumulate>.Enumerator);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<KeyValuePair<TKey, TAccumulate>> span)
		{
			span = default(ReadOnlySpan<KeyValuePair<TKey, TAccumulate>>);
			return false;
		}

		public bool TryCopyTo(Span<KeyValuePair<TKey, TAccumulate>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out KeyValuePair<TKey, TAccumulate> current)
		{
			current = default(KeyValuePair<TKey, TAccumulate>);
			return false;
		}

		private void Initialize()
		{
		}

		public void Dispose()
		{
		}
	}
}
