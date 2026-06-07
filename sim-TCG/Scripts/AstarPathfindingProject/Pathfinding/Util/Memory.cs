using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pathfinding.Util
{
	public static class Memory
	{
		public static T[] ShrinkArray<T>(T[] arr, int newLength)
		{
			newLength = Math.Min(newLength, arr.Length);
			T[] array = new T[newLength];
			Array.Copy(arr, array, newLength);
			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Swap<T>(ref T a, ref T b)
		{
			T val = a;
			a = b;
			b = val;
		}

		public static void Realloc<T>(ref NativeArray<T> arr, int newSize, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : struct
		{
			if (!arr.IsCreated || arr.Length < newSize)
			{
				NativeArray<T> nativeArray = new NativeArray<T>(newSize, allocator, options);
				if (arr.IsCreated)
				{
					NativeArray<T>.Copy(arr, nativeArray, arr.Length);
					arr.Dispose();
				}
				arr = nativeArray;
			}
		}

		public static void Realloc<T>(ref T[] arr, int newSize)
		{
			if (arr == null)
			{
				arr = new T[newSize];
			}
			else if (newSize > arr.Length)
			{
				T[] array = new T[newSize];
				arr.CopyTo(array, 0);
				arr = array;
			}
		}

		public unsafe static T[] UnsafeAppendBufferToArray<T>(UnsafeAppendBuffer src) where T : unmanaged
		{
			int num = src.Length / UnsafeUtility.SizeOf<T>();
			T[] array = new T[num];
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			UnsafeUtility.MemCpy((void*)gCHandle.AddrOfPinnedObject(), src.Ptr, (long)num * (long)UnsafeUtility.SizeOf<T>());
			gCHandle.Free();
			return array;
		}

		public static void Rotate3DArray<T>(T[] arr, int3 size, int dx, int dz)
		{
			int x = size.x;
			int y = size.y;
			int z = size.z;
			dx %= x;
			dz %= z;
			if (dx != 0)
			{
				if (dx < 0)
				{
					dx = x + dx;
				}
				T[] array = ArrayPool<T>.Claim(dx);
				for (int i = 0; i < y; i++)
				{
					int num = i * x * z;
					for (int j = 0; j < z; j++)
					{
						Array.Copy(arr, num + j * x + x - dx, array, 0, dx);
						Array.Copy(arr, num + j * x, arr, num + j * x + dx, x - dx);
						Array.Copy(array, 0, arr, num + j * x, dx);
					}
				}
				ArrayPool<T>.Release(ref array);
			}
			if (dz != 0)
			{
				if (dz < 0)
				{
					dz = z + dz;
				}
				T[] array2 = ArrayPool<T>.Claim(dz * x);
				for (int k = 0; k < y; k++)
				{
					int num2 = k * x * z;
					Array.Copy(arr, num2 + (z - dz) * x, array2, 0, dz * x);
					Array.Copy(arr, num2, arr, num2 + dz * x, (z - dz) * x);
					Array.Copy(array2, 0, arr, num2, dz * x);
				}
				ArrayPool<T>.Release(ref array2);
			}
		}
	}
}
