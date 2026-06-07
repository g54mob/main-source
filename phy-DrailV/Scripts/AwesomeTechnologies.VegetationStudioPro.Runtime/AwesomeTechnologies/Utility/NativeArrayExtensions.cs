using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace AwesomeTechnologies.Utility
{
	public static class NativeArrayExtensions
	{
		public unsafe static void CopyToFast<T>(this NativeArray<T> nativeArray, T[] array) where T : struct
		{
			if (array == null)
			{
				throw new NullReferenceException("array is null");
			}
			int length = nativeArray.Length;
			if (array.Length < length)
			{
				throw new IndexOutOfRangeException("array is shorter than nativeArray");
			}
			int num = nativeArray.Length * UnsafeUtility.SizeOf<T>();
			void* destination = UnsafeUtility.AddressOf(ref array[0]);
			void* unsafePtr = nativeArray.GetUnsafePtr();
			UnsafeUtility.MemCpy(destination, unsafePtr, num);
		}

		public unsafe static void CopyToFast<T>(this NativeSlice<T> nativeSlice, T[] array) where T : struct
		{
			if (array == null)
			{
				throw new NullReferenceException("array is null");
			}
			int length = nativeSlice.Length;
			if (array.Length < length)
			{
				throw new IndexOutOfRangeException("array is shorter than nativeSlice");
			}
			int num = nativeSlice.Length * UnsafeUtility.SizeOf<T>();
			void* destination = UnsafeUtility.AddressOf(ref array[0]);
			void* unsafePtr = nativeSlice.GetUnsafePtr();
			UnsafeUtility.MemCpy(destination, unsafePtr, num);
		}

		public unsafe static void CopyToFast<T>(this NativeArray<T> nativeArray, T[,,] array) where T : struct
		{
			if (array == null)
			{
				throw new NullReferenceException("array is null");
			}
			int length = nativeArray.Length;
			if (array.GetLength(0) * array.GetLength(1) * array.GetLength(2) < length)
			{
				throw new IndexOutOfRangeException("array is shorter than nativeArray");
			}
			int num = nativeArray.Length * UnsafeUtility.SizeOf<T>();
			void* destination = UnsafeUtility.AddressOf(ref array[0, 0, 0]);
			void* unsafePtr = nativeArray.GetUnsafePtr();
			UnsafeUtility.MemCpy(destination, unsafePtr, num);
		}

		public unsafe static void CopyFromFast<T>(this NativeArray<T> nativeArray, T[,] array) where T : struct
		{
			if (array == null)
			{
				throw new NullReferenceException("array is null");
			}
			int length = nativeArray.Length;
			int num = array.GetLength(0) * array.GetLength(1);
			if (num > length)
			{
				throw new IndexOutOfRangeException("nativeArray is shorter than array");
			}
			int num2 = num * UnsafeUtility.SizeOf<T>();
			void* source = UnsafeUtility.AddressOf(ref array[0, 0]);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr(), source, num2);
		}

		public unsafe static void CopyFromFast<T>(this NativeArray<T> nativeArray, T[,,] array) where T : struct
		{
			if (array == null)
			{
				throw new NullReferenceException("array is null");
			}
			int length = nativeArray.Length;
			int num = array.GetLength(0) * array.GetLength(1) * array.GetLength(2);
			if (num > length)
			{
				throw new IndexOutOfRangeException("nativeArray is shorter than array");
			}
			int num2 = num * UnsafeUtility.SizeOf<T>();
			void* source = UnsafeUtility.AddressOf(ref array[0, 0, 0]);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr(), source, num2);
		}

		public unsafe static void CopyFromFast<T>(this NativeArray<T> nativeArray, T[] array) where T : struct
		{
			if (array == null)
			{
				throw new NullReferenceException("array is null");
			}
			int length = nativeArray.Length;
			int length2 = array.GetLength(0);
			if (length2 > length)
			{
				throw new IndexOutOfRangeException("nativeArray is shorter than array");
			}
			int num = length2 * UnsafeUtility.SizeOf<T>();
			void* source = UnsafeUtility.AddressOf(ref array[0]);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr(), source, num);
		}

		public unsafe static void CopyFromFast<T>(this NativeArray<T> nativeArray, List<T> managedList) where T : struct
		{
			if (managedList == null)
			{
				throw new NullReferenceException("managedList is null");
			}
			int length = nativeArray.Length;
			int count = managedList.Count;
			T[] internalArray = managedList.GetInternalArray();
			if (count > length)
			{
				throw new IndexOutOfRangeException("nativeArray is shorter than managedInternalArray");
			}
			int num = count * UnsafeUtility.SizeOf<T>();
			void* source = UnsafeUtility.AddressOf(ref internalArray[0]);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr(), source, num);
		}
	}
}
