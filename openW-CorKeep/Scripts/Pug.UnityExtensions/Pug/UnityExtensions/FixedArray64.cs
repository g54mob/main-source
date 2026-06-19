using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	[GenerateTestsForBurstCompatibility]
	public struct FixedArray64
	{
		[FieldOffset(0)]
		public uint offset0000;

		[FieldOffset(4)]
		public uint offset0004;

		[FieldOffset(8)]
		public uint offset0008;

		[FieldOffset(12)]
		public uint offset0012;

		[FieldOffset(16)]
		public uint offset0016;

		[FieldOffset(20)]
		public uint offset0020;

		[FieldOffset(24)]
		public uint offset0024;

		[FieldOffset(28)]
		public uint offset0028;

		[FieldOffset(32)]
		public uint offset0032;

		[FieldOffset(36)]
		public uint offset0036;

		[FieldOffset(40)]
		public uint offset0040;

		[FieldOffset(44)]
		public uint offset0044;

		[FieldOffset(48)]
		public uint offset0048;

		[FieldOffset(52)]
		public uint offset0052;

		[FieldOffset(56)]
		public uint offset0056;

		[FieldOffset(60)]
		public uint offset0060;

		public int Size => 64;

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
