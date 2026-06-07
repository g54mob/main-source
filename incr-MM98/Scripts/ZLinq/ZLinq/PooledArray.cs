using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ZLinq.Linq;

namespace ZLinq
{
	public struct PooledArray<TSource> : IDisposable
	{
		private TSource[] array;

		private int size;

		public int Size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return size;
			}
		}

		public Span<TSource> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array.AsSpan(0, size);
			}
		}

		public Memory<TSource> Memory
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array.AsMemory(0, size);
			}
		}

		public ArraySegment<TSource> ArraySegment
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new ArraySegment<TSource>(array, 0, size);
			}
		}

		public TSource[] Array => array;

		internal PooledArray(TSource[] array, int size)
		{
			this.array = array;
			this.size = size;
		}

		public IEnumerable<TSource> AsEnumerable()
		{
			return ArraySegment.AsEnumerable();
		}

		public ValueEnumerable<FromMemory<TSource>, TSource> AsValueEnumerable()
		{
			return Memory.AsValueEnumerable();
		}

		public void Deconstruct(out TSource[] array, out int size)
		{
			array = this.array;
			size = this.size;
			this.array = null;
		}

		public void Dispose()
		{
			if (array != null)
			{
				ArrayPool<TSource>.Shared.Return(array, RuntimeHelpers.IsReferenceOrContainsReferences<TSource>());
				array = null;
			}
		}
	}
}
