using System;
using System.Runtime.InteropServices;

namespace ZLinq.Traversables
{
	[StructLayout(LayoutKind.Auto)]
	public struct Children<TTraverser, T> : IValueEnumerator<T>, IDisposable where TTraverser : struct, ITraverser<TTraverser, T>
	{
		public Children(TTraverser traverser, bool withSelf)
		{
			_003Ctraverser_003EP = traverser;
			_003CwithSelf_003EP = withSelf;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (_003Ctraverser_003EP.TryGetChildCount(out var count2))
			{
				count = count2 + (_003CwithSelf_003EP ? 1 : 0);
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
			if (_003CwithSelf_003EP)
			{
				current = _003Ctraverser_003EP.Origin;
				_003CwithSelf_003EP = false;
				return true;
			}
			return _003Ctraverser_003EP.TryGetNextChild(out current);
		}

		public void Dispose()
		{
			_003Ctraverser_003EP.Dispose();
		}
	}
}
