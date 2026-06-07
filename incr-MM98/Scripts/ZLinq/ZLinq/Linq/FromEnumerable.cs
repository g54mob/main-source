using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromEnumerable<T> : IValueEnumerator<T>, IDisposable
	{
		private readonly CollectionIterator<T> iterator;

		private FromEnumerableContent content;

		public FromEnumerable(IEnumerable<T> source)
		{
			if (source.GetType() == typeof(T[]))
			{
				iterator = ArrayIterator<T>.Instance;
			}
			else if (source.GetType() == typeof(List<T>))
			{
				iterator = ListIterator<T>.Instance;
			}
			else if (source is IReadOnlyList<T>)
			{
				iterator = IReadOnlyListIterator<T>.Instance;
			}
			else if (source is IList<T>)
			{
				iterator = IListIterator<T>.Instance;
			}
			else
			{
				iterator = EnumerableIterator<T>.Instance;
			}
			content = new FromEnumerableContent(source);
		}

		internal IEnumerable<T> GetSource()
		{
			content.ThrowIfNoEnumerable();
			return Unsafe.As<IEnumerable<T>>(content.Source);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			content.ThrowIfNoEnumerable();
			return iterator.TryGetNonEnumeratedCount(Unsafe.As<IEnumerable<T>>(content.Source), out count);
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			content.ThrowIfNoEnumerable();
			return iterator.TryGetSpan(Unsafe.As<IEnumerable<T>>(content.Source), out span);
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			content.ThrowIfNoEnumerable();
			return iterator.TryCopyTo(Unsafe.As<IEnumerable<T>>(content.Source), destination, offset);
		}

		public bool TryGetNext(out T current)
		{
			return iterator.TryGetNext(ref content, out current);
		}

		public void Dispose()
		{
			if (content.Index < 0)
			{
				Unsafe.As<IEnumerator<T>>(content.Source).Dispose();
			}
		}
	}
}
