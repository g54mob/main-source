using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pathfinding.Util
{
	public static class Memory
	{
		public static T[] ShrinkArray<T>(T[] arr, int newLength)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Swap<T>(ref T a, ref T b)
		{
		}

		public static void Realloc<T>(ref NativeArray<T> arr, int newSize, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : struct
		{
		}

		public static void Realloc<T>(ref T[] arr, int newSize)
		{
		}

		public static T[] UnsafeAppendBufferToArray<T>(UnsafeAppendBuffer src) where T : struct
		{
			return null;
		}

		public static bool SequenceEqual<T>(T[] a, T[] b) where T : IEquatable<T>
		{
			return false;
		}

		public static void Rotate3DArray<T>(T[] arr, int3 size, int dx, int dz)
		{
		}
	}
}
