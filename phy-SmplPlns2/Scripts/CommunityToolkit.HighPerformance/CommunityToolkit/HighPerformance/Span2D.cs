using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Enumerables;
using CommunityToolkit.HighPerformance.Memory.Internals;
using CommunityToolkit.HighPerformance.Memory.Views;

namespace CommunityToolkit.HighPerformance
{
	[DebuggerTypeProxy(typeof(MemoryDebugView2D<>))]
	[DebuggerDisplay("{ToString(),raw}")]
	public readonly ref struct Span2D<T>
	{
		public ref struct Enumerator
		{
			private readonly Span<T> span;

			private readonly int width;

			private readonly int stride;

			private int x;

			private int y;

			public readonly ref T Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					ref T reference = ref MemoryMarshal.GetReference(span);
					nint elementOffset = (nint)(uint)y * (nint)(uint)stride + (nint)(uint)x;
					return ref Unsafe.Add(ref reference, elementOffset);
				}
			}

			internal Enumerator(Span2D<T> span)
			{
				this.span = span.span;
				width = span.width;
				stride = span.Stride;
				x = -1;
				y = 0;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				int num = x + 1;
				if (num < width)
				{
					x = num;
					return true;
				}
				x = 0;
				return ++y < span.Length;
			}
		}

		private readonly Span<T> span;

		private readonly int width;

		internal readonly int Stride;

		public static Span2D<T> Empty => default(Span2D<T>);

		public bool IsEmpty
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Height != 0)
				{
					return width == 0;
				}
				return true;
			}
		}

		public nint Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (nint)(uint)Height * (nint)(uint)width;
			}
		}

		public int Height
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return span.Length;
			}
		}

		public int Width
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return width;
			}
		}

		public ref T this[int row, int column]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if ((uint)row >= (uint)Height || (uint)column >= (uint)width)
				{
					ThrowHelper.ThrowIndexOutOfRangeException();
				}
				return ref DangerousGetReferenceAt(row, column);
			}
		}

		public ref T this[Index row, Index column]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref this[row.GetOffset(Height), column.GetOffset(width)];
			}
		}

		public Span2D<T> this[Range rows, Range columns]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				var (row, height) = rows.GetOffsetAndLength(Height);
				var (column, num) = columns.GetOffsetAndLength(width);
				return Slice(row, column, height, num);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal Span2D(ref T value, int height, int width, int pitch)
		{
			span = MemoryMarshal.CreateSpan(ref value, height);
			this.width = width;
			Stride = width + pitch;
		}

		public unsafe Span2D(void* pointer, int height, int width, int pitch)
		{
			if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
			{
				ThrowHelper.ThrowArgumentExceptionForManagedType();
			}
			if (width < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForWidth();
			}
			if (height < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForHeight();
			}
			if (pitch < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForPitch();
			}
			OverflowHelper.EnsureIsInNativeIntRange(height, width, pitch);
			span = new Span<T>(pointer, height);
			this.width = width;
			Stride = width + pitch;
		}

		public Span2D(T[] array, int height, int width)
			: this(array, 0, height, width, 0)
		{
		}

		public Span2D(T[] array, int offset, int height, int width, int pitch)
		{
			if (array.IsCovariant())
			{
				ThrowHelper.ThrowArrayTypeMismatchException();
			}
			if ((uint)offset > (uint)array.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForOffset();
			}
			if (height < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForHeight();
			}
			if (width < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForWidth();
			}
			if (pitch < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForPitch();
			}
			int num = OverflowHelper.ComputeInt32Area(height, width, pitch);
			int num2 = array.Length - offset;
			if (num > num2)
			{
				ThrowHelper.ThrowArgumentException();
			}
			span = MemoryMarshal.CreateSpan(ref array.DangerousGetReferenceAt(offset), height);
			this.width = width;
			Stride = width + pitch;
		}

		public Span2D(T[,]? array)
		{
			if (array == null)
			{
				this = default(Span2D<T>);
				return;
			}
			if (array.IsCovariant())
			{
				ThrowHelper.ThrowArrayTypeMismatchException();
			}
			span = MemoryMarshal.CreateSpan(ref array.DangerousGetReference(), array.GetLength(0));
			width = (Stride = array.GetLength(1));
		}

		public Span2D(T[,]? array, int row, int column, int height, int width)
		{
			if (array == null)
			{
				if (row != 0 || column != 0 || height != 0 || width != 0)
				{
					ThrowHelper.ThrowArgumentException();
				}
				this = default(Span2D<T>);
				return;
			}
			if (array.IsCovariant())
			{
				ThrowHelper.ThrowArrayTypeMismatchException();
			}
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			if ((uint)row >= (uint)length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForRow();
			}
			if ((uint)column >= (uint)length2)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForColumn();
			}
			if ((uint)height > (uint)(length - row))
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForHeight();
			}
			if ((uint)width > (uint)(length2 - column))
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForWidth();
			}
			span = MemoryMarshal.CreateSpan(ref array.DangerousGetReferenceAt(row, column), height);
			this.width = width;
			Stride = length2;
		}

		public Span2D(T[,,] array, int depth)
		{
			if (array.IsCovariant())
			{
				ThrowHelper.ThrowArrayTypeMismatchException();
			}
			if ((uint)depth >= (uint)array.GetLength(0))
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForDepth();
			}
			span = MemoryMarshal.CreateSpan(ref array.DangerousGetReferenceAt(depth, 0, 0), array.GetLength(1));
			width = (Stride = array.GetLength(2));
		}

		public Span2D(T[,,] array, int depth, int row, int column, int height, int width)
		{
			if (array.IsCovariant())
			{
				ThrowHelper.ThrowArrayTypeMismatchException();
			}
			if ((uint)depth >= (uint)array.GetLength(0))
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForDepth();
			}
			int length = array.GetLength(1);
			int length2 = array.GetLength(2);
			if ((uint)row >= (uint)length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForRow();
			}
			if ((uint)column >= (uint)length2)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForColumn();
			}
			if ((uint)height > (uint)(length - row))
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForHeight();
			}
			if ((uint)width > (uint)(length2 - column))
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForWidth();
			}
			span = MemoryMarshal.CreateSpan(ref array.DangerousGetReferenceAt(depth, row, column), height);
			this.width = width;
			Stride = length2;
		}

		internal Span2D(Span<T> span, int height, int width)
			: this(span, 0, height, width, 0)
		{
		}

		internal Span2D(Span<T> span, int offset, int height, int width, int pitch)
		{
			if ((uint)offset > (uint)span.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForOffset();
			}
			if (height < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForHeight();
			}
			if (width < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForWidth();
			}
			if (pitch < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForPitch();
			}
			if (width == 0 || height == 0)
			{
				this = default(Span2D<T>);
				return;
			}
			int num = OverflowHelper.ComputeInt32Area(height, width, pitch);
			int num2 = span.Length - offset;
			if (num > num2)
			{
				ThrowHelper.ThrowArgumentException();
			}
			this.span = MemoryMarshal.CreateSpan(ref span.DangerousGetReferenceAt(offset), height);
			this.width = width;
			Stride = width + pitch;
		}

		public static Span2D<T> DangerousCreate(ref T value, int height, int width, int pitch)
		{
			if (width < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForWidth();
			}
			if (height < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForHeight();
			}
			if (pitch < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForPitch();
			}
			OverflowHelper.EnsureIsInNativeIntRange(height, width, pitch);
			return new Span2D<T>(ref value, height, width, pitch);
		}

		public void Clear()
		{
			if (IsEmpty)
			{
				return;
			}
			if (TryGetSpan(out var span))
			{
				span.Clear();
				return;
			}
			for (int i = 0; i < Height; i++)
			{
				GetRowSpan(i).Clear();
			}
		}

		public void CopyTo(Span<T> destination)
		{
			if (IsEmpty)
			{
				return;
			}
			if (TryGetSpan(out var span))
			{
				span.CopyTo(destination);
				return;
			}
			if (Length > destination.Length)
			{
				ThrowHelper.ThrowArgumentExceptionForDestinationTooShort();
			}
			int num = 0;
			int num2 = 0;
			while (num < Height)
			{
				GetRowSpan(num).CopyTo(destination.Slice(num2));
				num++;
				num2 += width;
			}
		}

		public void CopyTo(Span2D<T> destination)
		{
			if (destination.Height != Height || destination.width != width)
			{
				ThrowHelper.ThrowArgumentExceptionForDestinationWithNotSameShape();
			}
			if (IsEmpty)
			{
				return;
			}
			if (destination.TryGetSpan(out Span<T> destination2))
			{
				CopyTo(destination2);
				return;
			}
			for (int i = 0; i < Height; i++)
			{
				GetRowSpan(i).CopyTo(destination.GetRowSpan(i));
			}
		}

		public bool TryCopyTo(Span<T> destination)
		{
			if (destination.Length >= Length)
			{
				CopyTo(destination);
				return true;
			}
			return false;
		}

		public bool TryCopyTo(Span2D<T> destination)
		{
			if (destination.Height == Height && destination.Width == width)
			{
				CopyTo(destination);
				return true;
			}
			return false;
		}

		public void Fill(T value)
		{
			if (IsEmpty)
			{
				return;
			}
			if (TryGetSpan(out var span))
			{
				span.Fill(value);
				return;
			}
			for (int i = 0; i < Height; i++)
			{
				GetRowSpan(i).Fill(value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public unsafe ref T GetPinnableReference()
		{
			ref T result = ref Unsafe.AsRef<T>(null);
			if (Length != 0)
			{
				result = ref MemoryMarshal.GetReference(span);
			}
			return ref result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref T DangerousGetReference()
		{
			return ref MemoryMarshal.GetReference(span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref T DangerousGetReferenceAt(int i, int j)
		{
			ref T reference = ref MemoryMarshal.GetReference(span);
			nint elementOffset = (nint)(uint)i * (nint)(uint)Stride + (nint)(uint)j;
			return ref Unsafe.Add(ref reference, elementOffset);
		}

		public Span2D<T> Slice(int row, int column, int height, int width)
		{
			if ((uint)row >= Height)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForRow();
			}
			if ((uint)column >= this.width)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForColumn();
			}
			if ((uint)height > Height - row)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForHeight();
			}
			if ((uint)width > this.width - column)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForWidth();
			}
			nint i = (nint)(uint)Stride * (nint)(uint)row + (nint)(uint)column;
			int pitch = Stride - width;
			return new Span2D<T>(ref span.DangerousGetReferenceAt(i), height, width, pitch);
		}

		public Span<T> GetRowSpan(int row)
		{
			if ((uint)row >= (uint)Height)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForRow();
			}
			return MemoryMarshal.CreateSpan(ref DangerousGetReferenceAt(row, 0), width);
		}

		public bool TryGetSpan(out Span<T> span)
		{
			if (Stride == width && Length <= int.MaxValue)
			{
				span = MemoryMarshal.CreateSpan(ref MemoryMarshal.GetReference(this.span), (int)Length);
				return true;
			}
			span = default(Span<T>);
			return false;
		}

		public T[,] ToArray()
		{
			T[,] array = new T[Height, width];
			CopyTo(array.AsSpan());
			return array;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Equals() on Span will always throw an exception. Use == instead.")]
		public override bool Equals(object? obj)
		{
			throw new NotSupportedException("CommunityToolkit.HighPerformance.Span2D<T>.Equals(object) is not supported.");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("GetHashCode() on Span will always throw an exception.")]
		public override int GetHashCode()
		{
			throw new NotSupportedException("CommunityToolkit.HighPerformance.Span2D<T>.GetHashCode() is not supported.");
		}

		public override string ToString()
		{
			return $"CommunityToolkit.HighPerformance.Span2D<{typeof(T)}>[{Height}, {width}]";
		}

		public static bool operator ==(Span2D<T> left, Span2D<T> right)
		{
			if (left.span == right.span && left.width == right.width)
			{
				return left.Stride == right.Stride;
			}
			return false;
		}

		public static bool operator !=(Span2D<T> left, Span2D<T> right)
		{
			return !(left == right);
		}

		public static implicit operator Span2D<T>(T[,]? array)
		{
			return new Span2D<T>(array);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public RefEnumerable<T> GetRow(int row)
		{
			if ((uint)row >= Height)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForRow();
			}
			nint elementOffset = (nint)(uint)Stride * (nint)(uint)row;
			return new RefEnumerable<T>(ref Unsafe.Add(ref DangerousGetReference(), elementOffset), Width, 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public RefEnumerable<T> GetColumn(int column)
		{
			if ((uint)column >= Width)
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForColumn();
			}
			return new RefEnumerable<T>(ref Unsafe.Add(ref DangerousGetReference(), (nint)(uint)column), Height, Stride);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}
	}
}
