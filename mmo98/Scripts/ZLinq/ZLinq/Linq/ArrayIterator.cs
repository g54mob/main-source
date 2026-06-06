using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	internal sealed class ArrayIterator<T> : CollectionIterator<T>
	{
		public static readonly ArrayIterator<T> Instance = new ArrayIterator<T>();

		private ArrayIterator()
		{
		}

		public override bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count)
		{
			count = Unsafe.As<IEnumerable<T>, T[]>(ref source).Length;
			return true;
		}

		public override bool TryGetSpan(IEnumerable<T> source, out ReadOnlySpan<T> span)
		{
			span = Unsafe.As<IEnumerable<T>, T[]>(ref source);
			return true;
		}

		public override bool TryCopyTo(IEnumerable<T> source, Span<T> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSlice((ReadOnlySpan<T>)Unsafe.As<IEnumerable<T>, T[]>(ref source), offset, destination.Length, out ReadOnlySpan<T> slice))
			{
				slice.CopyTo(destination);
				return true;
			}
			return false;
		}

		public override bool TryGetNext(ref FromEnumerableContent content, out T current)
		{
			int index = content.Index;
			T[] array = Unsafe.As<T[]>(content.Source);
			if ((uint)index < (uint)array.Length)
			{
				current = array[index];
				content.Index = index + 1;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}
	}
}
