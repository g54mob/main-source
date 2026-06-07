using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Helpers.Internals;
using CommunityToolkit.HighPerformance.Memory.Internals;

namespace CommunityToolkit.HighPerformance.Enumerables
{
	public readonly ref struct RefEnumerable<T>
	{
		public ref struct Enumerator
		{
			private readonly Span<T> span;

			private readonly int step;

			private int position;

			public readonly ref T Current
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
			internal Enumerator(Span<T> span, int step)
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

		internal readonly Span<T> Span;

		internal readonly int Step;

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Span.Length;
			}
		}

		public ref T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if ((uint)index >= (uint)Length)
				{
					ThrowHelper.ThrowIndexOutOfRangeException();
				}
				ref T reference = ref MemoryMarshal.GetReference(Span);
				nint elementOffset = (nint)(uint)index * (nint)(uint)Step;
				return ref Unsafe.Add(ref reference, elementOffset);
			}
		}

		public ref T this[Index index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref this[index.GetOffset(Length)];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal RefEnumerable(ref T reference, int length, int step)
		{
			Span = MemoryMarshal.CreateSpan(ref reference, length);
			Step = step;
		}

		public static RefEnumerable<T> DangerousCreate(ref T value, int length, int step)
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
			return new RefEnumerable<T>(ref value, length, step);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Enumerator GetEnumerator()
		{
			return new Enumerator(Span, Step);
		}

		public void Clear()
		{
			if (Step == 1)
			{
				Span.Clear();
				return;
			}
			ref T r = ref Span.DangerousGetReference();
			int length = Span.Length;
			RefEnumerableHelper.Clear(ref r, (nint)(uint)length, (nint)(uint)Step);
		}

		public void CopyTo(RefEnumerable<T> destination)
		{
			if (Step == 1)
			{
				destination.CopyFrom(Span);
				return;
			}
			if (destination.Step == 1)
			{
				CopyTo(destination.Span);
				return;
			}
			ref T sourceRef = ref Span.DangerousGetReference();
			ref T destinationRef = ref destination.Span.DangerousGetReference();
			int length = Span.Length;
			if ((uint)destination.Span.Length < (uint)length)
			{
				ThrowArgumentExceptionForDestinationTooShort();
			}
			RefEnumerableHelper.CopyTo(ref sourceRef, ref destinationRef, (nint)(uint)length, (nint)(uint)Step, (nint)(uint)destination.Step);
		}

		public bool TryCopyTo(RefEnumerable<T> destination)
		{
			int length = Span.Length;
			if (destination.Span.Length >= length)
			{
				CopyTo(destination);
				return true;
			}
			return false;
		}

		public void CopyTo(Span<T> destination)
		{
			if (Step == 1)
			{
				Span.CopyTo(destination);
				return;
			}
			ref T sourceRef = ref Span.DangerousGetReference();
			int length = Span.Length;
			if ((uint)destination.Length < (uint)length)
			{
				ThrowArgumentExceptionForDestinationTooShort();
			}
			RefEnumerableHelper.CopyTo(ref sourceRef, ref destination.DangerousGetReference(), (nint)(uint)length, (nint)(uint)Step);
		}

		public bool TryCopyTo(Span<T> destination)
		{
			int length = Span.Length;
			if (destination.Length >= length)
			{
				CopyTo(destination);
				return true;
			}
			return false;
		}

		internal void CopyFrom(ReadOnlySpan<T> source)
		{
			if (Step == 1)
			{
				source.CopyTo(Span);
				return;
			}
			ref T destinationRef = ref Span.DangerousGetReference();
			int length = Span.Length;
			ref T sourceRef = ref source.DangerousGetReference();
			int length2 = source.Length;
			if ((uint)length < (uint)length2)
			{
				ThrowArgumentExceptionForDestinationTooShort();
			}
			RefEnumerableHelper.CopyFrom(ref sourceRef, ref destinationRef, (nint)(uint)length2, (nint)(uint)Step);
		}

		public bool TryCopyFrom(ReadOnlySpan<T> source)
		{
			if (Span.Length >= source.Length)
			{
				CopyFrom(source);
				return true;
			}
			return false;
		}

		public void Fill(T value)
		{
			if (Step == 1)
			{
				Span.Fill(value);
				return;
			}
			ref T r = ref Span.DangerousGetReference();
			int length = Span.Length;
			RefEnumerableHelper.Fill(ref r, (nint)(uint)length, (nint)(uint)Step, value);
		}

		public T[] ToArray()
		{
			int length = Span.Length;
			if (length == 0)
			{
				return Array.Empty<T>();
			}
			T[] array = new T[length];
			CopyTo(array);
			return array;
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
