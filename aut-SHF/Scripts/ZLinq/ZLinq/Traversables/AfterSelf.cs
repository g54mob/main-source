using System;
using System.Runtime.InteropServices;

namespace ZLinq.Traversables
{
	[StructLayout((LayoutKind)3)]
	public struct AfterSelf<TTraverser, T> : IValueEnumerator<T>, IDisposable where TTraverser : struct, ITraverser<TTraverser, T>
	{
		public AfterSelf(TTraverser traverser, bool withSelf)
		{
			_003Ctraverser_003EP = default(TTraverser);
			_003CwithSelf_003EP = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
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
			current = default(T);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
