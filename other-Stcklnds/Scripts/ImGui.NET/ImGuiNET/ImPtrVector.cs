using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImPtrVector<T>
	{
		public readonly int Size;

		public readonly int Capacity;

		public readonly IntPtr Data;

		private readonly int _stride;

		public unsafe T this[int index]
		{
			get
			{
				byte* ptr = (byte*)(void*)Data + index * _stride;
				return Unsafe.Read<T>(&ptr);
			}
		}

		public ImPtrVector(ImVector vector, int stride)
			: this(vector.Size, vector.Capacity, vector.Data, stride)
		{
		}

		public ImPtrVector(int size, int capacity, IntPtr data, int stride)
		{
			Size = size;
			Capacity = capacity;
			Data = data;
			_stride = stride;
		}
	}
}
