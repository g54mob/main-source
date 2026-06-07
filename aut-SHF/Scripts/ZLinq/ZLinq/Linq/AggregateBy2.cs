using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct AggregateBy2<TEnumerator, TSource, TKey, TAccumulate> : IValueEnumerator<KeyValuePair<TKey, TAccumulate>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TAccumulate : notnull
	{
		private TEnumerator source;

		private DictionarySlim<TKey, TAccumulate>? dictionary;

		private DictionarySlim<TKey, TAccumulate>.Enumerator enumerator;

		public AggregateBy2(TEnumerator source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer)
		{
			_003CkeySelector_003EP = null;
			_003CseedSelector_003EP = null;
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
