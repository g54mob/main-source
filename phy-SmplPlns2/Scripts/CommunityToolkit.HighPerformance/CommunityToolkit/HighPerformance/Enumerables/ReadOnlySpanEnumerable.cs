using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CommunityToolkit.HighPerformance.Enumerables
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ref struct ReadOnlySpanEnumerable<T>
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public readonly ref struct Item
		{
			private readonly ReadOnlySpan<T> span;

			public ref readonly T Value
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return ref MemoryMarshal.GetReference(span);
				}
			}

			public int Index
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return span.Length;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Item(ref T value, int index)
			{
				span = MemoryMarshal.CreateReadOnlySpan(ref value, index);
			}
		}

		private readonly ReadOnlySpan<T> span;

		private int index;

		public readonly Item Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Item(ref Unsafe.Add(ref MemoryMarshal.GetReference(span), (nint)(uint)index), index);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ReadOnlySpanEnumerable(ReadOnlySpan<T> span)
		{
			this.span = span;
			index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly ReadOnlySpanEnumerable<T> GetEnumerator()
		{
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			return ++index < span.Length;
		}
	}
}
