using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pathfinding.Collections
{
	public static class SpanExtensions
	{
		private static readonly int AllocatorOffset;

		public static void FillZeros<T>(this UnsafeSpan<T> span) where T : struct
		{
		}

		public static void Fill<T>(this UnsafeSpan<T> span, T value) where T : struct
		{
		}

		public static void CopyFrom<T>(this UnsafeSpan<T> span, NativeArray<T> array) where T : struct
		{
		}

		public static void CopyFrom<T>(this UnsafeSpan<T> span, UnsafeSpan<T> other) where T : struct
		{
		}

		public static void CopyFrom<T>(this UnsafeSpan<T> span, T[] array) where T : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UnsafeSpan<T> AsUnsafeSpan<T>(this UnsafeAppendBuffer buffer) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UnsafeSpan<T> AsUnsafeSpan<T>(this NativeList<T> list) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UnsafeSpan<T> AsUnsafeSpan<T>(this NativeArray<T> arr) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		public static UnsafeSpan<T> MoveToUnsafeSpan<T>(this NativeArray<T> arr) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UnsafeSpan<T> AsUnsafeSpanNoChecks<T>(this NativeArray<T> arr) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UnsafeSpan<T> AsUnsafeReadOnlySpan<T>(this NativeArray<T> arr) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		public static Allocator GetAllocator<T>(this NativeArray<T> arr) where T : struct
		{
			return default(Allocator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UnsafeSpan<T> AsUnsafeSpan<T>(this UnsafeList<T> arr) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UnsafeSpan<T> AsUnsafeSpan<T>(this NativeSlice<T> slice) where T : struct
		{
			return default(UnsafeSpan<T>);
		}

		public static bool Contains<T>(this UnsafeSpan<T> span, T value) where T : struct, IEquatable<T>
		{
			return false;
		}

		public static int IndexOf<T>(this UnsafeSpan<T> span, T value) where T : struct, IEquatable<T>
		{
			return 0;
		}

		public static void Sort<T>(this UnsafeSpan<T> span) where T : struct, IComparable<T>
		{
		}

		public static void Sort<T, U>(this UnsafeSpan<T> span, U comp) where T : struct where U : IComparer<T>
		{
		}

		public static void InsertRange<T>(this NativeList<T> list, int index, int count) where T : struct
		{
		}
	}
}
