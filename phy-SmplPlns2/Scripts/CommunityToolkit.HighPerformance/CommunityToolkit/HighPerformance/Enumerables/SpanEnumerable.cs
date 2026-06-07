using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CommunityToolkit.HighPerformance.Enumerables
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ref struct SpanEnumerable<T>
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public readonly ref struct Item
		{
			private readonly Span<T> span;

			public ref T Value
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
				span = MemoryMarshal.CreateSpan(ref value, index);
			}
		}

		private readonly Span<T> span;

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
		public SpanEnumerable(Span<T> span)
		{
			this.span = span;
			index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly SpanEnumerable<T> GetEnumerator()
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
