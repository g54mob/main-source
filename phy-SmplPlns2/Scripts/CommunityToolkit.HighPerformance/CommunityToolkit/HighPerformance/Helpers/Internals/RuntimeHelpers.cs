using System;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Helpers.Internals
{
	internal static class RuntimeHelpers
	{
		private static class TypeInfo<T>
		{
			public static readonly IntPtr ArrayDataByteOffset = MeasureArrayDataByteOffset();

			public static readonly IntPtr Array2DDataByteOffset = MeasureArray2DDataByteOffset();

			public static readonly IntPtr Array3DDataByteOffset = MeasureArray3DDataByteOffset();

			private static IntPtr MeasureArrayDataByteOffset()
			{
				T[] array = new T[1];
				return ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array[0]);
			}

			private static IntPtr MeasureArray2DDataByteOffset()
			{
				T[,] array = new T[1, 1];
				return ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array[0, 0]);
			}

			private static IntPtr MeasureArray3DDataByteOffset()
			{
				T[,,] array = new T[1, 1, 1];
				return ObjectMarshal.DangerousGetObjectDataByteOffset(array, ref array[0, 0, 0]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int ConvertLength<TFrom, TTo>(int length) where TFrom : unmanaged where TTo : unmanaged
		{
			if (sizeof(TFrom) == sizeof(TTo))
			{
				return length;
			}
			if (sizeof(TFrom) == 1)
			{
				return (int)((uint)length / (uint)sizeof(TTo));
			}
			checked
			{
				return (int)unchecked((ulong)((long)(uint)length * (long)(uint)sizeof(TFrom)) / (ulong)(uint)sizeof(TTo));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static nint GetArrayNativeLength<T>(T[] array)
		{
			return (nint)array.LongLength;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static nint GetArrayNativeLength(Array array)
		{
			return (nint)array.LongLength;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IntPtr GetArrayDataByteOffset<T>()
		{
			return TypeInfo<T>.ArrayDataByteOffset;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IntPtr GetArray2DDataByteOffset<T>()
		{
			return TypeInfo<T>.Array2DDataByteOffset;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IntPtr GetArray3DDataByteOffset<T>()
		{
			return TypeInfo<T>.Array3DDataByteOffset;
		}
	}
}
