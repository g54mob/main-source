using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Traversables
{
	[StructLayout(LayoutKind.Auto)]
	public struct Ancestors<TTraverser, T> : IValueEnumerator<T>, IDisposable where TTraverser : struct, ITraverser<TTraverser, T>
	{
		public Ancestors(TTraverser traverser, bool withSelf)
		{
			_003Ctraverser_003EP = traverser;
			_003CwithSelf_003EP = withSelf;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
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
			if (_003Ctraverser_003EP.TryGetParent(out T parent))
			{
				current = parent;
				TTraverser val = _003Ctraverser_003EP.ConvertToTraverser(parent);
				_003Ctraverser_003EP.Dispose();
				_003Ctraverser_003EP = val;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}

		public void Dispose()
		{
			_003Ctraverser_003EP.Dispose();
		}
	}
}
