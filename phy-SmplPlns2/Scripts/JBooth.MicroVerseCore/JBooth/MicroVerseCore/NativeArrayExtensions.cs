using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace JBooth.MicroVerseCore
{
	public static class NativeArrayExtensions
	{
		public unsafe static void CopyToFast<T>(this NativeArray<T> nativeArray, T[,] array) where T : struct
		{
			int num = nativeArray.Length * Marshal.SizeOf(default(T));
			void* destination = UnsafeUtility.AddressOf(ref array[0, 0]);
			void* unsafePtr = nativeArray.GetUnsafePtr();
			UnsafeUtility.MemCpy(destination, unsafePtr, num);
		}

		public unsafe static void CopyToFastByteToInt(this NativeArray<byte> nativeArray, int[,] array)
		{
			int count = nativeArray.Length * Marshal.SizeOf((byte)0);
			void* destination = UnsafeUtility.AddressOf(ref array[0, 0]);
			void* unsafePtr = nativeArray.GetUnsafePtr();
			UnsafeUtility.MemCpyStride(destination, 4, unsafePtr, 1, 1, count);
		}
	}
}
