using System;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Traversables
{
	[StructLayout((LayoutKind)3)]
	public struct Descendants<TTraverser, T> : IValueEnumerator<T>, IDisposable where TTraverser : struct, ITraverser<TTraverser, T>
	{
		private RefStack<Children<TTraverser, T>>? recursiveStack;

		public Descendants(TTraverser traverser, bool withSelf)
		{
			_003Ctraverser_003EP = default(TTraverser);
			_003CwithSelf_003EP = false;
			recursiveStack = null;
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
