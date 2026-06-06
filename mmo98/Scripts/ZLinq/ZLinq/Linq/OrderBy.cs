using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct OrderBy<TEnumerator, TSource, TKey> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		internal TEnumerator source;

		internal OrderByComparable<TSource, TKey> comparable;

		private RentedArrayBox<TSource>? buffer;

		private int index;

		public OrderBy(TEnumerator source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer, IOrderByComparable<TSource>? parent, bool descending)
		{
			_003CkeySelector_003EP = keySelector;
			_003Ccomparer_003EP = comparer;
			_003Cparent_003EP = parent;
			_003Cdescending_003EP = descending;
			buffer = null;
			index = 0;
			this.source = source;
			comparable = new OrderByComparable<TSource, TKey>(_003CkeySelector_003EP, _003Ccomparer_003EP, _003Cparent_003EP, _003Cdescending_003EP);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			return source.TryGetNonEnumeratedCount(out count);
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			InitBuffer();
			span = buffer.Span;
			return true;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			if (source.TryGetNonEnumeratedCount(out var count) && offset.GetOffset(count) == 0 && destination.Length >= count && source.TryCopyTo(destination, 0))
			{
				Sort(destination.Slice(0, count));
				return true;
			}
			if (destination.Length == 1)
			{
				new ValueEnumerable<TEnumerator, TSource>(source).ToArrayPool().Deconstruct(out TSource[] array, out int size);
				TSource[] array2 = array;
				int num = size;
				int offset2 = offset.GetOffset(num);
				if (num == 0)
				{
					buffer = RentedArrayBox<TSource>.Empty;
					return false;
				}
				if ((uint)offset2 >= num)
				{
					buffer = new RentedArrayBox<TSource>(array2, num);
					Sort(buffer.Span);
					return false;
				}
				try
				{
					Span<TSource> span = array2.AsSpan(0, num);
					ValueEnumerable.Range(0, span.Length).ToArrayPool().Deconstruct(out int[] array3, out size);
					int[] array4 = array3;
					int num2 = size;
					using IOrderByComparer orderByComparer = comparable.GetComparer(span, null);
					int num3 = ((offset2 == 0) ? _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__OrderByHelper.Min(array4, orderByComparer, num2) : ((offset2 != num2 - 1) ? _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__OrderByHelper.QuickSelect(array4, orderByComparer, num2 - 1, offset2) : _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__OrderByHelper.Max(array4, orderByComparer, num2)));
					destination[0] = span[num3];
					ArrayPool<int>.Shared.Return(array4);
				}
				finally
				{
					ArrayPool<TSource>.Shared.Return(array2, RuntimeHelpers.IsReferenceOrContainsReferences<TSource>());
				}
				return true;
			}
			InitBuffer();
			if (EnumeratorHelper.TryGetSlice((ReadOnlySpan<TSource>)buffer.Span, offset, destination.Length, out ReadOnlySpan<TSource> slice))
			{
				slice.CopyTo(destination);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			InitBuffer();
			if ((uint)index < (uint)buffer.Length)
			{
				current = buffer.UnsafeGetAt(index);
				index++;
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			buffer?.Dispose();
			if (buffer == null)
			{
				source.Dispose();
			}
		}

		[MemberNotNull("buffer")]
		private void InitBuffer()
		{
			if (buffer == null)
			{
				new ValueEnumerable<TEnumerator, TSource>(source).ToArrayPool().Deconstruct(out TSource[] array, out int size);
				TSource[] array2 = array;
				int length = size;
				buffer = new RentedArrayBox<TSource>(array2, length);
				Sort(buffer.Span);
			}
		}

		private void Sort([ScopedRef] Span<TSource> span)
		{
			if (IsAllowDirectSort())
			{
				if (_003Cdescending_003EP)
				{
					span.Sort(_003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__DescendingDefaultComparer<TSource>.Default);
				}
				else
				{
					span.Sort();
				}
				return;
			}
			var (array2, length) = (PooledArray<int>)(ref ValueEnumerable.Range(0, span.Length).ToArrayPool());
			using IOrderByComparer orderByComparer = comparable.GetComparer(span, null);
			array2.AsSpan(0, length).Sort(span, orderByComparer);
			ArrayPool<int>.Shared.Return(array2);
		}

		public OrderBy<TEnumerator, TSource, TSecondKey> ThenBy<TSecondKey>(Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer = null)
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return new OrderBy<TEnumerator, TSource, TSecondKey>(source, keySelector, comparer, comparable, descending: false);
		}

		public OrderBy<TEnumerator, TSource, TSecondKey> ThenByDescending<TSecondKey>(Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer = null)
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return new OrderBy<TEnumerator, TSource, TSecondKey>(source, keySelector, comparer, comparable, descending: true);
		}

		private bool IsAllowDirectSort()
		{
			if (_003Cparent_003EP == null && _003CkeySelector_003EP == _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__UnsafeFunctions<TSource, TKey>.Identity && _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__OrderByHelper.TypeIsImplicitlyStable<TSource>() && (_003Ccomparer_003EP == null || _003Ccomparer_003EP == Comparer<TSource>.Default))
			{
				return true;
			}
			return false;
		}
	}
}
