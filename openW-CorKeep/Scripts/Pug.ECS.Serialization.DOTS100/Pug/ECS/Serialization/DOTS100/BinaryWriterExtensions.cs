using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	public static class BinaryWriterExtensions
	{
		public unsafe static void Write(this BinaryWriter writer, byte value)
		{
			writer.WriteBytes(&value, 1);
		}

		public unsafe static void Write(this BinaryWriter writer, int value)
		{
			writer.WriteBytes(&value, 4);
		}

		public unsafe static void Write(this BinaryWriter writer, ulong value)
		{
			writer.WriteBytes(&value, 8);
		}

		public unsafe static void Write(this BinaryWriter writer, byte[] bytes)
		{
			fixed (byte* data = bytes)
			{
				writer.WriteBytes(data, bytes.Length);
			}
		}

		public unsafe static void WriteArray<T>(this BinaryWriter writer, NativeArray<T> data) where T : struct
		{
			writer.WriteBytes(data.GetUnsafeReadOnlyPtr(), data.Length * UnsafeUtility.SizeOf<T>());
		}

		public unsafe static void WriteList<T>(this BinaryWriter writer, NativeList<T> data) where T : unmanaged
		{
			writer.WriteBytes(data.GetUnsafePtr(), data.Length * UnsafeUtility.SizeOf<T>());
		}

		public unsafe static void WriteList<T>(this BinaryWriter writer, NativeList<T> data, int index, int count) where T : unmanaged
		{
			if (index + count > data.Length)
			{
				throw new ArgumentException("index + count must not go beyond the end of the list");
			}
			int num = UnsafeUtility.SizeOf<T>();
			writer.WriteBytes((byte*)data.GetUnsafePtr() + num * index, count * num);
		}
	}
}
