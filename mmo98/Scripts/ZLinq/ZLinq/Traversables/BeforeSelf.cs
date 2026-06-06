using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Traversables
{
	[StructLayout(LayoutKind.Auto)]
	public struct BeforeSelf<TTraverser, T> : IValueEnumerator<T>, IDisposable where TTraverser : struct, ITraverser<TTraverser, T>
	{
		private bool iterateCompleted;

		public BeforeSelf(TTraverser traverser, bool withSelf)
		{
			_003Ctraverser_003EP = traverser;
			_003CwithSelf_003EP = withSelf;
			iterateCompleted = false;
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
			if (iterateCompleted)
			{
				Unsafe.SkipInit<T>(out current);
				return false;
			}
			if (_003Ctraverser_003EP.TryGetPreviousSibling(out current))
			{
				return true;
			}
			iterateCompleted = true;
			if (_003CwithSelf_003EP)
			{
				current = _003Ctraverser_003EP.Origin;
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
