using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	public static class DynamicBufferExtensions
	{
		public static void Cache<T>(this DynamicBuffer<T> buffer, List<T> list) where T : struct, IBufferElementData
		{
			list.Clear();
			foreach (T item in buffer)
			{
				list.Add(item);
			}
		}

		public static void CopyToArray<T>(this DynamicBuffer<T> buffer, T[] array, int offset = 0) where T : struct, IBufferElementData
		{
			int length = buffer.Length;
			for (int i = 0; i < length; i++)
			{
				array[offset + i] = buffer[i];
			}
		}
	}
}
