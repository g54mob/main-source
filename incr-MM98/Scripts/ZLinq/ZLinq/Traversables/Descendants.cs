using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Traversables
{
	[StructLayout(LayoutKind.Auto)]
	public struct Descendants<TTraverser, T> : IValueEnumerator<T>, IDisposable where TTraverser : struct, ITraverser<TTraverser, T>
	{
		private RefStack<Children<TTraverser, T>>? recursiveStack;

		public Descendants(TTraverser traverser, bool withSelf)
		{
			_003Ctraverser_003EP = traverser;
			_003CwithSelf_003EP = withSelf;
			recursiveStack = null;
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
			if (recursiveStack == RefStack<Children<TTraverser, T>>.DisposeSentinel)
			{
				Unsafe.SkipInit<T>(out current);
				return false;
			}
			if (_003CwithSelf_003EP)
			{
				current = _003Ctraverser_003EP.Origin;
				_003CwithSelf_003EP = false;
				return true;
			}
			if (recursiveStack == null)
			{
				ValueEnumerable<Children<TTraverser, T>, T> valueEnumerable = _003Ctraverser_003EP.Children<TTraverser, T>();
				recursiveStack = RefStack<Children<TTraverser, T>>.Rent();
				recursiveStack.Push(valueEnumerable.Enumerator);
			}
			ref Children<TTraverser, T> reference = ref recursiveStack.PeekRefOrNullRef();
			while (!Unsafe.IsNullRef(ref reference))
			{
				if (reference.TryGetNext(out var current2))
				{
					current = current2;
					using (TTraverser val = _003Ctraverser_003EP.ConvertToTraverser(current2))
					{
						if (!val.TryGetHasChild(out var hasChild) || hasChild)
						{
							ValueEnumerable<Children<TTraverser, T>, T> valueEnumerable2 = val.Children<TTraverser, T>();
							recursiveStack.Push(valueEnumerable2.Enumerator);
						}
					}
					return true;
				}
				reference.Dispose();
				recursiveStack.Pop();
				reference = ref recursiveStack.PeekRefOrNullRef();
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}

		public void Dispose()
		{
			if (recursiveStack != null)
			{
				RefStack<Children<TTraverser, T>>.Return(recursiveStack);
				recursiveStack = RefStack<Children<TTraverser, T>>.DisposeSentinel;
			}
		}
	}
}
