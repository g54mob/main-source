using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct CountBy<TEnumerator, TSource, TKey> : IValueEnumerator<KeyValuePair<TKey, int>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private DictionarySlim<TKey, int>? dictionary;

		private DictionarySlim<TKey, int>.Enumerator enumerator;

		public CountBy(TEnumerator source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? keyComparer)
		{
			_003CkeySelector_003EP = null;
			_003CkeyComparer_003EP = null;
			this.source = default(TEnumerator);
			dictionary = null;
			enumerator = default(DictionarySlim<TKey, int>.Enumerator);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<KeyValuePair<TKey, int>> span)
		{
			span = default(ReadOnlySpan<KeyValuePair<TKey, int>>);
			return false;
		}

		public bool TryCopyTo(Span<KeyValuePair<TKey, int>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out KeyValuePair<TKey, int> current)
		{
			current = default(KeyValuePair<TKey, int>);
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
