using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Buffers.Internals;
using CommunityToolkit.HighPerformance.Enumerables;
using CommunityToolkit.HighPerformance.Helpers;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance
{
	public static class ArrayExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReference<T>(this T[] array)
		{
			IntPtr arrayDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayDataByteOffset<T>();
			return ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(array, arrayDataByteOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReferenceAt<T>(this T[] array, int i)
		{
			IntPtr arrayDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayDataByteOffset<T>();
			return ref Unsafe.Add(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(array, arrayDataByteOffset), (nint)(uint)i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<T>(this T[] array, T value) where T : IEquatable<T>
		{
			ref T r = ref array.DangerousGetReference();
			nint arrayNativeLength = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayNativeLength(array);
			nint num = SpanHelper.Count(ref r, arrayNativeLength, value);
			if ((nuint)num > (nuint)2147483647u)
			{
				ThrowOverflowException();
			}
			return (int)num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanEnumerable<T> Enumerate<T>(this T[] array)
		{
			return new SpanEnumerable<T>(array);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SpanTokenizer<T> Tokenize<T>(this T[] array, T separator) where T : IEquatable<T>
		{
			return new SpanTokenizer<T>(array, separator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDjb2HashCode<T>(this T[] array) where T : notnull
		{
			ref T r = ref array.DangerousGetReference();
			nint arrayNativeLength = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayNativeLength(array);
			return SpanHelper.GetDjb2HashCode(ref r, arrayNativeLength);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsCovariant<T>(this T[] array)
		{
			if (default(T) == null)
			{
				return array.GetType() != typeof(T[]);
			}
			return false;
		}

		private static void ThrowOverflowException()
		{
			throw new OverflowException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReference<T>(this T[,] array)
		{
			IntPtr array2DDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArray2DDataByteOffset<T>();
			return ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(array, array2DDataByteOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReferenceAt<T>(this T[,] array, int i, int j)
		{
			int length = array.GetLength(1);
			nint elementOffset = (nint)(uint)i * (nint)(uint)length + (nint)(uint)j;
			IntPtr array2DDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArray2DDataByteOffset<T>();
			return ref Unsafe.Add(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(array, array2DDataByteOffset), elementOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RefEnumerable<T> GetRow<T>(this T[,] array, int row)
		{
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			int length = array.GetLength(0);
			if ((uint)row >= (uint)length)
			{
				ThrowArgumentOutOfRangeExceptionForRow();
			}
			int length2 = array.GetLength(1);
			return new RefEnumerable<T>(ref array.DangerousGetReferenceAt(row, 0), length2, 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RefEnumerable<T> GetColumn<T>(this T[,] array, int column)
		{
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			int length = array.GetLength(1);
			if ((uint)column >= (uint)length)
			{
				ThrowArgumentOutOfRangeExceptionForColumn();
			}
			int length2 = array.GetLength(0);
			return new RefEnumerable<T>(ref array.DangerousGetReferenceAt(0, column), length2, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span2D<T> AsSpan2D<T>(this T[,]? array)
		{
			return new Span2D<T>(array);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span2D<T> AsSpan2D<T>(this T[,]? array, int row, int column, int height, int width)
		{
			return new Span2D<T>(array, row, column, height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory2D<T> AsMemory2D<T>(this T[,]? array)
		{
			return new Memory2D<T>(array);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory2D<T> AsMemory2D<T>(this T[,]? array, int row, int column, int height, int width)
		{
			return new Memory2D<T>(array, row, column, height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<T> GetRowSpan<T>(this T[,] array, int row)
		{
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			if ((uint)row >= (uint)array.GetLength(0))
			{
				ThrowArgumentOutOfRangeExceptionForRow();
			}
			return MemoryMarshal.CreateSpan(ref array.DangerousGetReferenceAt(row, 0), array.GetLength(1));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<T> GetRowMemory<T>(this T[,] array, int row)
		{
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			if ((uint)row >= (uint)array.GetLength(0))
			{
				ThrowArgumentOutOfRangeExceptionForRow();
			}
			IntPtr offset = ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array.DangerousGetReferenceAt(row, 0));
			return new RawObjectMemoryManager<T>(array, offset, array.GetLength(1)).Memory;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<T> AsMemory<T>(this T[,]? array)
		{
			if (array == null)
			{
				return default(Memory<T>);
			}
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			IntPtr array2DDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArray2DDataByteOffset<T>();
			int length = array.Length;
			return new RawObjectMemoryManager<T>(array, array2DDataByteOffset, length).Memory;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<T> AsSpan<T>(this T[,]? array)
		{
			if (array == null)
			{
				return default(Span<T>);
			}
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			ref T reference = ref array.DangerousGetReference();
			int length = array.Length;
			return MemoryMarshal.CreateSpan(ref reference, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<T>(this T[,] array, T value) where T : IEquatable<T>
		{
			ref T r = ref array.DangerousGetReference();
			nint arrayNativeLength = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayNativeLength(array);
			nint num = SpanHelper.Count(ref r, arrayNativeLength, value);
			if ((nuint)num > (nuint)2147483647u)
			{
				ThrowOverflowException();
			}
			return (int)num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDjb2HashCode<T>(this T[,] array) where T : notnull
		{
			ref T r = ref array.DangerousGetReference();
			nint arrayNativeLength = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayNativeLength(array);
			return SpanHelper.GetDjb2HashCode(ref r, arrayNativeLength);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsCovariant<T>(this T[,] array)
		{
			if (default(T) == null)
			{
				return array.GetType() != typeof(T[,]);
			}
			return false;
		}

		private static void ThrowArrayTypeMismatchException()
		{
			throw new ArrayTypeMismatchException("The given array doesn't match the specified type T.");
		}

		private static void ThrowArgumentOutOfRangeExceptionForRow()
		{
			throw new ArgumentOutOfRangeException("row");
		}

		private static void ThrowArgumentOutOfRangeExceptionForColumn()
		{
			throw new ArgumentOutOfRangeException("column");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReference<T>(this T[,,] array)
		{
			IntPtr array3DDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArray3DDataByteOffset<T>();
			return ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(array, array3DDataByteOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T DangerousGetReferenceAt<T>(this T[,,] array, int i, int j, int k)
		{
			int length = array.GetLength(1);
			int length2 = array.GetLength(2);
			nint elementOffset = (nint)(uint)i * (nint)(uint)length * (nint)(uint)length2 + (nint)(uint)j * (nint)(uint)length2 + (nint)(uint)k;
			IntPtr array3DDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArray3DDataByteOffset<T>();
			return ref Unsafe.Add(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(array, array3DDataByteOffset), elementOffset);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<T> AsMemory<T>(this T[,,]? array)
		{
			if (array == null)
			{
				return default(Memory<T>);
			}
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			IntPtr array3DDataByteOffset = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArray3DDataByteOffset<T>();
			int length = array.Length;
			return new RawObjectMemoryManager<T>(array, array3DDataByteOffset, length).Memory;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<T> AsSpan<T>(this T[,,]? array)
		{
			if (array == null)
			{
				return default(Span<T>);
			}
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			ref T reference = ref array.DangerousGetReference();
			int length = array.Length;
			return MemoryMarshal.CreateSpan(ref reference, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<T> AsSpan<T>(this T[,,] array, int depth)
		{
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			if ((uint)depth >= (uint)array.GetLength(0))
			{
				ThrowArgumentOutOfRangeExceptionForDepth();
			}
			ref T reference = ref array.DangerousGetReferenceAt(depth, 0, 0);
			int length = checked(array.GetLength(1) * array.GetLength(2));
			return MemoryMarshal.CreateSpan(ref reference, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<T> AsMemory<T>(this T[,,] array, int depth)
		{
			if (array.IsCovariant())
			{
				ThrowArrayTypeMismatchException();
			}
			if ((uint)depth >= (uint)array.GetLength(0))
			{
				ThrowArgumentOutOfRangeExceptionForDepth();
			}
			IntPtr offset = ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array.DangerousGetReferenceAt(depth, 0, 0));
			int length = checked(array.GetLength(1) * array.GetLength(2));
			return new RawObjectMemoryManager<T>(array, offset, length).Memory;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span2D<T> AsSpan2D<T>(this T[,,] array, int depth)
		{
			return new Span2D<T>(array, depth);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory2D<T> AsMemory2D<T>(this T[,,] array, int depth)
		{
			return new Memory2D<T>(array, depth);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<T>(this T[,,] array, T value) where T : IEquatable<T>
		{
			ref T r = ref array.DangerousGetReference();
			nint arrayNativeLength = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayNativeLength(array);
			nint num = SpanHelper.Count(ref r, arrayNativeLength, value);
			if ((nuint)num > (nuint)2147483647u)
			{
				ThrowOverflowException();
			}
			return (int)num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDjb2HashCode<T>(this T[,,] array) where T : notnull
		{
			ref T r = ref array.DangerousGetReference();
			nint arrayNativeLength = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.GetArrayNativeLength(array);
			return SpanHelper.GetDjb2HashCode(ref r, arrayNativeLength);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsCovariant<T>(this T[,,] array)
		{
			if (default(T) == null)
			{
				return array.GetType() != typeof(T[,,]);
			}
			return false;
		}

		private static void ThrowArgumentOutOfRangeExceptionForDepth()
		{
			throw new ArgumentOutOfRangeException("depth");
		}
	}
}
