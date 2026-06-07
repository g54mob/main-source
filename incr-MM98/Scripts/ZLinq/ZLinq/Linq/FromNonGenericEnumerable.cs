using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromNonGenericEnumerable<T> : IValueEnumerator<T>, IDisposable
	{
		private IEnumerator? enumerator;

		public FromNonGenericEnumerable(IEnumerable source)
		{
			_003Csource_003EP = source;
			enumerator = null;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (_003Csource_003EP is ICollection collection)
			{
				count = collection.Count;
				return true;
			}
			count = 0;
			return false;
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
			if (enumerator == null)
			{
				enumerator = _003Csource_003EP.GetEnumerator();
			}
			if (enumerator.MoveNext())
			{
				object current2 = enumerator.Current;
				current = (T)current2;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}

		public void Dispose()
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}
}
