using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	public struct FromDictionary<TKey, TValue> : IValueEnumerator<KeyValuePair<TKey, TValue>>, IDisposable where TKey : notnull where TValue : notnull
	{
		private bool isInit;

		private Dictionary<TKey, TValue>.Enumerator enumerator;

		public FromDictionary(Dictionary<TKey, TValue> source)
		{
			_003Csource_003EP = null;
			isInit = false;
			enumerator = default(Dictionary<TKey, TValue>.Enumerator);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<KeyValuePair<TKey, TValue>> span)
		{
			span = default(ReadOnlySpan<KeyValuePair<TKey, TValue>>);
			return false;
		}

		public bool TryCopyTo(Span<KeyValuePair<TKey, TValue>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out KeyValuePair<TKey, TValue> current)
		{
			current = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
