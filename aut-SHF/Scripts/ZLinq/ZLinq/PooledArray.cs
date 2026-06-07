using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZLinq.Linq;

namespace ZLinq
{
	public struct PooledArray<TSource> : IDisposable where TSource : notnull
	{
		private TSource[] array;

		private int size;

		public int Size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0;
			}
		}

		public Span<TSource> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(Span<TSource>);
			}
		}

		public Memory<TSource> Memory
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(Memory<TSource>);
			}
		}

		public ArraySegment<TSource> ArraySegment
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(ArraySegment<TSource>);
			}
		}

		public TSource[] Array => null;

		internal PooledArray(TSource[] array, int size)
		{
			this.array = null;
			this.size = 0;
		}

		public IEnumerable<TSource> AsEnumerable()
		{
			return null;
		}

		public ValueEnumerable<FromMemory<TSource>, TSource> AsValueEnumerable()
		{
			return default(ValueEnumerable<FromMemory<TSource>, TSource>);
		}

		public void Deconstruct(out TSource[] array, out int size)
		{
			array = null;
			size = default(int);
		}

		public void Dispose()
		{
		}
	}
}
