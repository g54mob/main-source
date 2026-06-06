using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromHashSet<T> : IValueEnumerator<T>, IDisposable
	{
		private bool isInit;

		private HashSet<T>.Enumerator enumerator;

		public FromHashSet(HashSet<T> source)
		{
			_003Csource_003EP = source;
			isInit = false;
			enumerator = default(HashSet<T>.Enumerator);
		}

		internal HashSet<T> GetSource()
		{
			return _003Csource_003EP;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = _003Csource_003EP.Count;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out T current)
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
			Unsafe.SkipInit<T>(out current);
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
