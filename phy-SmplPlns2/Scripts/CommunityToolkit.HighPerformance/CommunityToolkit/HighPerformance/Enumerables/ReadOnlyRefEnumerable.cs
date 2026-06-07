using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Helpers.Internals;
using CommunityToolkit.HighPerformance.Memory.Internals;

namespace CommunityToolkit.HighPerformance.Enumerables
{
	public readonly ref struct ReadOnlyRefEnumerable<T>
	{
		public ref struct Enumerator
		{
			private readonly ReadOnlySpan<T> span;

			private readonly int step;

			private int position;

			public readonly ref readonly T Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					ref T source = ref span.DangerousGetReference();
					nint elementOffset = (nint)(uint)position * (nint)(uint)step;
					return ref Unsafe.Add(ref source, elementOffset);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal Enumerator(ReadOnlySpan<T> span, int step)
			{
				this.span = span;
				this.step = step;
				position = -1;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return ++position < span.Length;
			}
		}

		private readonly ReadOnlySpan<T> span;

		private readonly int step;

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return span.Length;
			}
		}

		public ref readonly T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if ((uint)index >= (uint)Length)
				{
					ThrowHelper.ThrowIndexOutOfRangeException();
				}
				ref T reference = ref MemoryMarshal.GetReference(span);
				nint elementOffset = (nint)(uint)index * (nint)(uint)step;
				return ref Unsafe.Add(ref reference, elementOffset);
			}
		}

		public ref readonly T this[Index index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref this[index.GetOffset(Length)];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ReadOnlyRefEnumerable(ReadOnlySpan<T> span, int step)
		{
			this.span = span;
			this.step = step;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ReadOnlyRefEnumerable(in T reference, int length, int step)
		{
			span = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.AsRef(in reference), length);
			this.step = step;
		}

		public static ReadOnlyRefEnumerable<T> DangerousCreate(in T value, int length, int step)
		{
			if (length < 0)
			{
				ThrowArgumentOutOfRangeExceptionForLength();
			}
			if (step < 0)
			{
				ThrowArgumentOutOfRangeExceptionForStep();
			}
			OverflowHelper.EnsureIsInNativeIntRange(length, 1, step);
			return new ReadOnlyRefEnumerable<T>(in value, length, step);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Enumerator GetEnumerator()
		{
			return new Enumerator(span, step);
		}

		public void CopyTo(RefEnumerable<T> destination)
		{
			if (step == 1)
			{
				destination.CopyFrom(span);
				return;
			}
			if (destination.Step == 1)
			{
				CopyTo(destination.Span);
				return;
			}
			ref T sourceRef = ref span.DangerousGetReference();
			ref T destinationRef = ref destination.Span.DangerousGetReference();
			int length = span.Length;
			if ((uint)destination.Span.Length < (uint)length)
			{
				ThrowArgumentExceptionForDestinationTooShort();
			}
			RefEnumerableHelper.CopyTo(ref sourceRef, ref destinationRef, (nint)(uint)length, (nint)(uint)step, (nint)(uint)destination.Step);
		}

		public bool TryCopyTo(RefEnumerable<T> destination)
		{
			int length = span.Length;
			if (destination.Span.Length >= length)
			{
				CopyTo(destination);
				return true;
			}
			return false;
		}

		public void CopyTo(Span<T> destination)
		{
			if (step == 1)
			{
				span.CopyTo(destination);
				return;
			}
			ref T sourceRef = ref span.DangerousGetReference();
			int length = span.Length;
			if ((uint)destination.Length < (uint)length)
			{
				ThrowArgumentExceptionForDestinationTooShort();
			}
			RefEnumerableHelper.CopyTo(ref sourceRef, ref destination.DangerousGetReference(), (nint)(uint)length, (nint)(uint)step);
		}

		public bool TryCopyTo(Span<T> destination)
		{
			int length = span.Length;
			if (destination.Length >= length)
			{
				CopyTo(destination);
				return true;
			}
			return false;
		}

		public T[] ToArray()
		{
			int length = span.Length;
			if (length == 0)
			{
				return Array.Empty<T>();
			}
			T[] array = new T[length];
			CopyTo(array);
			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator ReadOnlyRefEnumerable<T>(RefEnumerable<T> enumerable)
		{
			return new ReadOnlyRefEnumerable<T>(enumerable.Span, enumerable.Step);
		}

		private static void ThrowArgumentOutOfRangeExceptionForLength()
		{
			throw new ArgumentOutOfRangeException("length");
		}

		private static void ThrowArgumentOutOfRangeExceptionForStep()
		{
			throw new ArgumentOutOfRangeException("step");
		}

		private static void ThrowArgumentExceptionForDestinationTooShort()
		{
			throw new ArgumentException("The target span is too short to copy all the current items to.");
		}
	}
}
