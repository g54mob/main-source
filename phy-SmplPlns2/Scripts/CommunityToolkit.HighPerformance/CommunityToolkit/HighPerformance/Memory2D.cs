using System;
using System.Buffers;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Buffers.Internals;
using CommunityToolkit.HighPerformance.Helpers;
using CommunityToolkit.HighPerformance.Helpers.Internals;
using CommunityToolkit.HighPerformance.Memory.Internals;
using CommunityToolkit.HighPerformance.Memory.Views;

namespace CommunityToolkit.HighPerformance
{
	[DebuggerTypeProxy(typeof(MemoryDebugView2D<>))]
	[DebuggerDisplay("{ToString(),raw}")]
	public readonly struct Memory2D<T> : IEquatable<Memory2D<T>>
	{
		private readonly object? instance;

		private readonly nint offset;

		private readonly int height;

		private readonly int width;

		private readonly int pitch;

		public static Memory2D<T> Empty => default(Memory2D<T>);

		public bool IsEmpty
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (height != 0)
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
				return (nint)(uint)height * (nint)(uint)width;
			}
		}

		public int Height
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return height;
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

		public Span2D<T> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (instance != null)
				{
					if (instance is MemoryManager<T> memoryManager)
					{
						return new Span2D<T>(ref Unsafe.AddByteOffset(ref memoryManager.GetSpan().DangerousGetReference(), offset), height, width, pitch);
					}
					return new Span2D<T>(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(instance, offset), height, width, pitch);
				}
				return default(Span2D<T>);
			}
		}

		public Memory2D<T> this[Range rows, Range columns]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				var (row, num) = rows.GetOffsetAndLength(height);
				var (column, num2) = columns.GetOffsetAndLength(width);
				return Slice(row, column, num, num2);
			}
		}

		public Memory2D(T[] array, int height, int width)
			: this(array, 0, height, width, 0)
		{
		}

		public Memory2D(T[] array, int offset, int height, int width, int pitch)
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
			instance = array;
			this.offset = ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array.DangerousGetReferenceAt(offset));
			this.height = height;
			this.width = width;
			this.pitch = pitch;
		}

		public Memory2D(T[,]? array)
		{
			if (array == null)
			{
				this = default(Memory2D<T>);
				return;
			}
			if (array.IsCovariant())
			{
				ThrowHelper.ThrowArrayTypeMismatchException();
			}
			instance = array;
			offset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArray2DDataByteOffset<T>();
			height = array.GetLength(0);
			width = array.GetLength(1);
			pitch = 0;
		}

		public Memory2D(T[,]? array, int row, int column, int height, int width)
		{
			if (array == null)
			{
				if (row != 0 || column != 0 || height != 0 || width != 0)
				{
					ThrowHelper.ThrowArgumentException();
				}
				this = default(Memory2D<T>);
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
			instance = array;
			offset = ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array.DangerousGetReferenceAt(row, column));
			this.height = height;
			this.width = width;
			pitch = length2 - width;
		}

		public Memory2D(T[,,] array, int depth)
		{
			if (array.IsCovariant())
			{
				ThrowHelper.ThrowArrayTypeMismatchException();
			}
			if ((uint)depth >= (uint)array.GetLength(0))
			{
				ThrowHelper.ThrowArgumentOutOfRangeExceptionForDepth();
			}
			instance = array;
			offset = ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array.DangerousGetReferenceAt(depth, 0, 0));
			height = array.GetLength(1);
			width = array.GetLength(2);
			pitch = 0;
		}

		public Memory2D(T[,,] array, int depth, int row, int column, int height, int width)
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
			instance = array;
			offset = ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array.DangerousGetReferenceAt(depth, row, column));
			this.height = height;
			this.width = width;
			pitch = length2 - width;
		}

		public Memory2D(MemoryManager<T> memoryManager, int height, int width)
			: this(memoryManager, 0, height, width, 0)
		{
		}

		public Memory2D(MemoryManager<T> memoryManager, int offset, int height, int width, int pitch)
		{
			int length = memoryManager.GetSpan().Length;
			if ((uint)offset > (uint)length)
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
				this = default(Memory2D<T>);
				return;
			}
			int num = OverflowHelper.ComputeInt32Area(height, width, pitch);
			int num2 = length - offset;
			if (num > num2)
			{
				ThrowHelper.ThrowArgumentException();
			}
			instance = memoryManager;
			this.offset = (nint)(uint)offset;
			this.height = height;
			this.width = width;
			this.pitch = pitch;
		}

		internal Memory2D(Memory<T> memory, int height, int width)
			: this(memory, 0, height, width, 0)
		{
		}

		internal Memory2D(Memory<T> memory, int offset, int height, int width, int pitch)
		{
			if ((uint)offset > (uint)memory.Length)
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
				this = default(Memory2D<T>);
				return;
			}
			int num = OverflowHelper.ComputeInt32Area(height, width, pitch);
			int num2 = memory.Length - offset;
			if (num > num2)
			{
				ThrowHelper.ThrowArgumentException();
			}
			ArraySegment<T> segment;
			MemoryManager<T> manager;
			int start2;
			if (typeof(T) == typeof(char) && MemoryMarshal.TryGetString(Unsafe.As<Memory<T>, Memory<char>>(ref memory), out var text, out var start, out var length))
			{
				ref char data = ref text.DangerousGetReferenceAt(start + offset);
				instance = text;
				this.offset = ObjectMarshal.DangerousGetObjectDataByteOffset(text, ref data);
			}
			else if (MemoryMarshal.TryGetArray((ReadOnlyMemory<T>)memory, out segment))
			{
				T[] array = (T[])(instance = segment.Array);
				this.offset = ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array.DangerousGetReferenceAt(segment.Offset + offset));
			}
			else if (MemoryMarshal.TryGetMemoryManager<T, MemoryManager<T>>(memory, out manager, out start2, out length))
			{
				instance = manager;
				this.offset = (nint)(uint)(start2 + offset);
			}
			else
			{
				ThrowHelper.ThrowArgumentExceptionForUnsupportedType();
				instance = null;
				this.offset = 0;
			}
			this.height = height;
			this.width = width;
			this.pitch = pitch;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Memory2D(object instance, IntPtr offset, int height, int width, int pitch)
		{
			this.instance = instance;
			this.offset = offset;
			this.height = height;
			this.width = width;
			this.pitch = pitch;
		}

		public static Memory2D<T> DangerousCreate(object instance, ref T value, int height, int width, int pitch)
		{
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
			OverflowHelper.EnsureIsInNativeIntRange(height, width, pitch);
			IntPtr intPtr = ObjectMarshal.DangerousGetObjectDataByteOffset(instance, ref value);
			return new Memory2D<T>(instance, intPtr, height, width, pitch);
		}

		public Memory2D<T> Slice(int row, int column, int height, int width)
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
			int num = (this.width + pitch) * row + column;
			int num2 = pitch + (this.width - width);
			nint num3 = offset + num * Unsafe.SizeOf<T>();
			return new Memory2D<T>(instance, num3, height, width, num2);
		}

		public void CopyTo(Memory<T> destination)
		{
			Span.CopyTo(destination.Span);
		}

		public bool TryCopyTo(Memory<T> destination)
		{
			return Span.TryCopyTo(destination.Span);
		}

		public void CopyTo(Memory2D<T> destination)
		{
			Span.CopyTo(destination.Span);
		}

		public bool TryCopyTo(Memory2D<T> destination)
		{
			return Span.TryCopyTo(destination.Span);
		}

		public unsafe MemoryHandle Pin()
		{
			if (instance != null)
			{
				if (instance is MemoryManager<T> memoryManager)
				{
					return memoryManager.Pin();
				}
				GCHandle handle = GCHandle.Alloc(instance, GCHandleType.Pinned);
				return new MemoryHandle(Unsafe.AsPointer(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(instance, offset)), handle);
			}
			return default(MemoryHandle);
		}

		public bool TryGetMemory(out Memory<T> memory)
		{
			if (pitch == 0 && Length <= int.MaxValue)
			{
				if (instance == null)
				{
					memory = default(Memory<T>);
				}
				else if (typeof(T) == typeof(char) && instance.GetType() == typeof(string))
				{
					string text = Unsafe.As<string>(instance);
					int start = text.AsSpan().IndexOf(in ObjectMarshal.DangerousGetObjectDataReferenceAt<char>(text, offset));
					ReadOnlyMemory<char> source = text.AsMemory(start, (int)Length);
					memory = MemoryMarshal.AsMemory<T>(Unsafe.As<ReadOnlyMemory<char>, Memory<T>>(ref source));
				}
				else if (instance is MemoryManager<T> memoryManager)
				{
					memory = memoryManager.Memory.Slice((int)offset, height * width);
				}
				else if (instance.GetType() == typeof(T[]))
				{
					T[] array = Unsafe.As<T[]>(instance);
					int start2 = array.AsSpan().IndexOf(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(array, offset));
					memory = array.AsMemory(start2, height * width);
				}
				else
				{
					if (!(instance.GetType() == typeof(T[,])) && !(instance.GetType() == typeof(T[,,])))
					{
						goto IL_01bd;
					}
					memory = new RawObjectMemoryManager<T>(instance, offset, height * width).Memory;
				}
				return true;
			}
			goto IL_01bd;
			IL_01bd:
			memory = default(Memory<T>);
			return false;
		}

		public T[,] ToArray()
		{
			return Span.ToArray();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object? obj)
		{
			if (obj is Memory2D<T> other)
			{
				return Equals(other);
			}
			if (obj is ReadOnlyMemory2D<T> readOnlyMemory2D)
			{
				return readOnlyMemory2D.Equals(this);
			}
			return false;
		}

		public bool Equals(Memory2D<T> other)
		{
			if (instance == other.instance && offset == other.offset && height == other.height && width == other.width)
			{
				return pitch == other.pitch;
			}
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			if (instance != null)
			{
				return HashCode.Combine(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(instance), offset, height, width, pitch);
			}
			return 0;
		}

		public override string ToString()
		{
			return $"CommunityToolkit.HighPerformance.Memory2D<{typeof(T)}>[{height}, {width}]";
		}

		public static implicit operator Memory2D<T>(T[,]? array)
		{
			return new Memory2D<T>(array);
		}
	}
}
