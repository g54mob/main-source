using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImVector
	{
		public readonly int Size;

		public readonly int Capacity;

		public readonly IntPtr Data;

		public ImVector(int size, int capacity, IntPtr data)
		{
			Size = size;
			Capacity = capacity;
			Data = data;
		}

		public unsafe ref T Ref<T>(int index)
		{
			return ref Unsafe.AsRef<T>((byte*)(void*)Data + index * Unsafe.SizeOf<T>());
		}

		public unsafe IntPtr Address<T>(int index)
		{
			return (IntPtr)((byte*)(void*)Data + index * Unsafe.SizeOf<T>());
		}
	}
	public struct ImVector<T>
	{
		public readonly int Size;

		public readonly int Capacity;

		public readonly IntPtr Data;

		public unsafe ref T this[int index] => ref Unsafe.AsRef<T>((byte*)(void*)Data + index * Unsafe.SizeOf<T>());

		public ImVector(ImVector vector)
		{
			Size = vector.Size;
			Capacity = vector.Capacity;
			Data = vector.Data;
		}

		public ImVector(int size, int capacity, IntPtr data)
		{
			Size = size;
			Capacity = capacity;
			Data = data;
		}
	}
}
