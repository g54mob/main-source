using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromDictionary<TKey, TValue> : IValueEnumerator<KeyValuePair<TKey, TValue>>, IDisposable where TKey : notnull
	{
		private bool isInit;

		private Dictionary<TKey, TValue>.Enumerator enumerator;

		public FromDictionary(Dictionary<TKey, TValue> source)
		{
			_003Csource_003EP = source;
			enumerator = default(Dictionary<TKey, TValue>.Enumerator);
			isInit = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = _003Csource_003EP.Count;
			return true;
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
			if (!isInit)
			{
				isInit = true;
				enumerator = _003Csource_003EP.GetEnumerator();
			}
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				return true;
			}
			Unsafe.SkipInit<KeyValuePair<TKey, TValue>>(out current);
			return false;
		}

		public void Dispose()
		{
			if (isInit)
			{
				enumerator.Dispose();
			}
		}
	}
}
