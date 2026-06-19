using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	[StructLayout(LayoutKind.Explicit, Size = 1024)]
	[GenerateTestsForBurstCompatibility]
	public struct FixedArray1024
	{
		[FieldOffset(0)]
		public FixedArray512 offset0000;

		[FieldOffset(512)]
		public FixedArray512 offset0512;

		public int Size => 1024;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)UnsafeUtility.AddressOf(ref offset0000);
		}

		public T[] ToArray<T>() where T : unmanaged
		{
			return ToArray<T>(Size / UnsafeUtility.SizeOf<T>());
		}

		public unsafe T[] ToArray<T>(int length) where T : unmanaged
		{
			int num = UnsafeUtility.SizeOf<T>();
			if (Size % num != 0)
			{
				throw new InvalidOperationException($"{typeof(T)} size is not a multiple of {Size}");
			}
			if (length * num > Size)
			{
				throw new InvalidOperationException("length is larger than total data size");
			}
			T* source = (T*)UnsafeUtility.AddressOf(ref offset0000);
			T[] array = new T[length];
			fixed (T* destination = array)
			{
				UnsafeUtility.MemCpy(destination, source, length * num);
			}
			return array;
		}

		public unsafe void Set<T>(T[] srcArray) where T : unmanaged
		{
			int num = UnsafeUtility.SizeOf<T>();
			if (Size % num != 0)
			{
				throw new InvalidOperationException($"{typeof(T)} size is not a multiple of {Size}");
			}
			if (srcArray.Length * num > Size)
			{
				throw new InvalidOperationException("srcArray is larger than total data size");
			}
			T* destination = (T*)UnsafeUtility.AddressOf(ref offset0000);
			fixed (T* source = srcArray)
			{
				UnsafeUtility.MemCpy(destination, source, srcArray.Length * num);
			}
		}

		public unsafe void CopyFrom(byte[] bytes, int startIndex)
		{
			byte* destination = (byte*)UnsafeUtility.AddressOf(ref offset0000);
			fixed (byte* ptr = bytes)
			{
				UnsafeUtility.MemCpy(destination, ptr + startIndex, math.min(Size, bytes.Length - startIndex));
			}
		}

		public unsafe void CopyTo(byte[] bytes, int startIndex)
		{
			byte* source = (byte*)UnsafeUtility.AddressOf(ref offset0000);
			fixed (byte* ptr = bytes)
			{
				UnsafeUtility.MemCpy(ptr + startIndex, source, math.min(Size, bytes.Length - startIndex));
			}
		}
	}
}
