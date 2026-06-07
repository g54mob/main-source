using System;
using System.Runtime.CompilerServices;

namespace ZLinq
{
	public interface IValueEnumerator<T> : IDisposable
	{
		bool TryGetNext(out T current);

		bool TryGetNonEnumeratedCount(out int count);

		bool TryGetSpan(out ReadOnlySpan<T> span);

		bool TryCopyTo([ScopedRef] Span<T> destination, Index offset);
	}
}
