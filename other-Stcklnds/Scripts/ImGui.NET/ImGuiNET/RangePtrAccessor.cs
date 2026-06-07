using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct RangePtrAccessor<T> where T : struct
	{
		public unsafe readonly void* Data;

		public readonly int Count;

		public unsafe T this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					throw new IndexOutOfRangeException();
				}
				return Unsafe.Read<T>((byte*)Data + sizeof(void*) * index);
			}
		}

		public unsafe RangePtrAccessor(IntPtr data, int count)
			: this(data.ToPointer(), count)
		{
		}

		public unsafe RangePtrAccessor(void* data, int count)
		{
			Data = data;
			Count = count;
		}
	}
}
