using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace DV.Utils
{
	public static class NativeListExtensions
	{
		public unsafe static void Insert<T>(this NativeList<T> list, T item, int index) where T : struct
		{
			if (list.Length == list.Capacity - 1)
			{
				list.Capacity *= 2;
			}
			if (index == list.Length)
			{
				list.Add(item);
				return;
			}
			if (index < 0 || index > list.Length)
			{
				throw new IndexOutOfRangeException();
			}
			list.Add(default(T));
			int num = UnsafeUtility.SizeOf<T>();
			byte* unsafePtr = (byte*)list.GetUnsafePtr();
			byte* source = index * num + unsafePtr;
			byte* destination = num * (index + 1) + unsafePtr;
			int num2 = num * (list.Length - index - 1);
			UnsafeUtility.MemMove(destination, source, num2);
			list[index] = item;
		}
	}
}
