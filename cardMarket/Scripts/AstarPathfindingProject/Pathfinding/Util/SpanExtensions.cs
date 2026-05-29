using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pathfinding.Util
{
	public static class SpanExtensions
	{
		public unsafe static void FillZeros<T>(this UnsafeSpan<T> span) where T : unmanaged
		{
			if (span.length != 0)
			{
				UnsafeUtility.MemSet(span.ptr, 0, sizeof(T) * span.length);
			}
		}

		public unsafe static void Fill<T>(this UnsafeSpan<T> span, T value) where T : unmanaged
		{
			if (span.length != 0)
			{
				if (sizeof(T) * span.length > int.MaxValue)
				{
					throw new ArgumentException("Span is too large to fill");
				}
				UnsafeUtility.MemCpyReplicate(span.ptr, &value, sizeof(T), (int)span.length);
			}
		}

		public static void CopyFrom<T>(this UnsafeSpan<T> span, NativeArray<T> array) where T : unmanaged
		{
			span.CopyFrom(array.AsUnsafeReadOnlySpan());
		}

		public unsafe static void CopyFrom<T>(this UnsafeSpan<T> span, UnsafeSpan<T> other) where T : unmanaged
		{
			if (other.Length > span.Length)
			{
				throw new InvalidOperationException();
			}
			if (other.Length != 0)
			{
				UnsafeUtility.MemCpy(span.ptr, other.ptr, (long)sizeof(T) * (long)other.Length);
			}
		}

		public unsafe static void CopyFrom<T>(this UnsafeSpan<T> span, T[] array) where T : unmanaged
		{
			if (array.Length > span.Length)
			{
				throw new InvalidOperationException();
			}
			if (array.Length != 0)
			{
				ulong gcHandle;
				void* source = UnsafeUtility.PinGCArrayAndGetDataAddress(array, out gcHandle);
				UnsafeUtility.MemCpy(span.ptr, source, (long)sizeof(T) * (long)array.Length);
				UnsafeUtility.ReleaseGCObject(gcHandle);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static UnsafeSpan<T> AsUnsafeSpan<T>(this UnsafeAppendBuffer buffer) where T : unmanaged
		{
			int num = buffer.Length / UnsafeUtility.SizeOf<T>();
			if (num * UnsafeUtility.SizeOf<T>() != buffer.Length)
			{
				throw new ArgumentException("Buffer length is not a multiple of the element size");
			}
			return new UnsafeSpan<T>(buffer.Ptr, num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static UnsafeSpan<T> AsUnsafeSpan<T>(this NativeList<T> list) where T : unmanaged
		{
			return new UnsafeSpan<T>(list.GetUnsafePtr(), list.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static UnsafeSpan<T> AsUnsafeSpan<T>(this NativeArray<T> arr) where T : unmanaged
		{
			return new UnsafeSpan<T>(arr.GetUnsafePtr(), arr.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static UnsafeSpan<T> AsUnsafeSpanNoChecks<T>(this NativeArray<T> arr) where T : unmanaged
		{
			return new UnsafeSpan<T>(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(arr), arr.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static UnsafeSpan<T> AsUnsafeReadOnlySpan<T>(this NativeArray<T> arr) where T : unmanaged
		{
			return new UnsafeSpan<T>(arr.GetUnsafeReadOnlyPtr(), arr.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static UnsafeSpan<T> AsUnsafeSpan<T>(this UnsafeList<T> arr) where T : unmanaged
		{
			return new UnsafeSpan<T>(arr.Ptr, arr.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static UnsafeSpan<T> AsUnsafeSpan<T>(this NativeSlice<T> slice) where T : unmanaged
		{
			return new UnsafeSpan<T>(slice.GetUnsafePtr(), slice.Length);
		}

		public static bool Contains<T>(this UnsafeSpan<T> span, T value) where T : unmanaged, IEquatable<T>
		{
			return span.IndexOf(value) != -1;
		}

		public unsafe static int IndexOf<T>(this UnsafeSpan<T> span, T value) where T : unmanaged, IEquatable<T>
		{
			return new ReadOnlySpan<T>(span.ptr, (int)span.length).IndexOf(value);
		}

		public unsafe static void Sort<T>(this UnsafeSpan<T> span) where T : unmanaged, IComparable<T>
		{
			NativeSortExtension.Sort(span.ptr, span.Length);
		}

		public unsafe static void Sort<T, U>(this UnsafeSpan<T> span, U comp) where T : unmanaged where U : IComparer<T>
		{
			NativeSortExtension.Sort(span.ptr, span.Length, comp);
		}

		public static void InsertRange<T>(this NativeList<T> list, int index, int count) where T : unmanaged
		{
			list.ResizeUninitialized(list.Length + count);
			list.AsUnsafeSpan().Move(index, index + count, list.Length - (index + count));
		}

		public static void AddReplicate<T>(this NativeList<T> list, T value, int count) where T : unmanaged
		{
			int length = list.Length;
			list.ResizeUninitialized(length + count);
			list.AsUnsafeSpan().Slice(length).Fill(value);
		}
	}
}
