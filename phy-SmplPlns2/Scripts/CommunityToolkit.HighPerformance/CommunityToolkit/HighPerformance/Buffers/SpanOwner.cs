using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Buffers.Views;

namespace CommunityToolkit.HighPerformance.Buffers
{
	[DebuggerTypeProxy(typeof(MemoryDebugView<>))]
	[DebuggerDisplay("{ToString(),raw}")]
	public readonly ref struct SpanOwner<T>
	{
		private readonly int length;

		private readonly ArrayPool<T> pool;

		private readonly T[] array;

		public static SpanOwner<T> Empty
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new SpanOwner<T>(0, ArrayPool<T>.Shared, AllocationMode.Default);
			}
		}

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return length;
			}
		}

		public Span<T> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Span<T>(array, 0, length);
			}
		}

		private SpanOwner(int length, ArrayPool<T> pool, AllocationMode mode)
		{
			this.length = length;
			this.pool = pool;
			array = pool.Rent(length);
			if (mode == AllocationMode.Clear)
			{
				array.AsSpan(0, length).Clear();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanOwner<T> Allocate(int size)
		{
			return new SpanOwner<T>(size, ArrayPool<T>.Shared, AllocationMode.Default);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanOwner<T> Allocate(int size, ArrayPool<T> pool)
		{
			return new SpanOwner<T>(size, pool, AllocationMode.Default);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanOwner<T> Allocate(int size, AllocationMode mode)
		{
			return new SpanOwner<T>(size, ArrayPool<T>.Shared, mode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanOwner<T> Allocate(int size, ArrayPool<T> pool, AllocationMode mode)
		{
			return new SpanOwner<T>(size, pool, mode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref T DangerousGetReference()
		{
			return ref array.DangerousGetReference();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ArraySegment<T> DangerousGetArray()
		{
			return new ArraySegment<T>(array, 0, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
			pool.Return(array);
		}

		public override string ToString()
		{
			if (typeof(T) == typeof(char) && array is char[] value)
			{
				return new string(value, 0, length);
			}
			return $"CommunityToolkit.HighPerformance.Buffers.SpanOwner<{typeof(T)}>[{length}]";
		}
	}
}
