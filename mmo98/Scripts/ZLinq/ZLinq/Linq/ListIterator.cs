using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	internal sealed class ListIterator<T> : CollectionIterator<T>
	{
		public static readonly ListIterator<T> Instance = new ListIterator<T>();

		private ListIterator()
		{
		}

		public override bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count)
		{
			count = Unsafe.As<IEnumerable<T>, List<T>>(ref source).Count;
			return true;
		}

		public override bool TryGetSpan(IEnumerable<T> source, out ReadOnlySpan<T> span)
		{
			span = Unsafe.As<IEnumerable<T>, List<T>>(ref source).AsSpan();
			return true;
		}

		public override bool TryCopyTo(IEnumerable<T> source, Span<T> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSlice((ReadOnlySpan<T>)Unsafe.As<IEnumerable<T>, List<T>>(ref source).AsSpan(), offset, destination.Length, out ReadOnlySpan<T> slice))
			{
				slice.CopyTo(destination);
				return true;
			}
			return false;
		}

		public override bool TryGetNext(ref FromEnumerableContent content, out T current)
		{
			int index = content.Index;
			List<T> list = Unsafe.As<List<T>>(content.Source);
			if ((uint)index < (uint)list.Count)
			{
				current = list[index];
				content.Index = index + 1;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}
	}
}
