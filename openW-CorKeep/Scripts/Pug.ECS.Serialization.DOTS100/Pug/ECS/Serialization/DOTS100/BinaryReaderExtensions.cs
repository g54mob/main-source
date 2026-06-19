using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	public static class BinaryReaderExtensions
	{
		public unsafe static byte ReadByte(this BinaryReader reader)
		{
			byte result = default(byte);
			reader.ReadBytes(&result, 1);
			return result;
		}

		public unsafe static int ReadInt(this BinaryReader reader)
		{
			int result = default(int);
			reader.ReadBytes(&result, 4);
			return result;
		}

		public unsafe static ulong ReadULong(this BinaryReader reader)
		{
			ulong result = default(ulong);
			reader.ReadBytes(&result, 8);
			return result;
		}

		public unsafe static void ReadBytes(this BinaryReader reader, NativeArray<byte> elements, int count, int offset = 0)
		{
			byte* data = (byte*)elements.GetUnsafePtr() + offset;
			reader.ReadBytes(data, count);
		}

		public unsafe static void ReadArray<T>(this BinaryReader reader, NativeArray<T> elements, int count) where T : struct
		{
			reader.ReadBytes(elements.GetUnsafeReadOnlyPtr(), count * UnsafeUtility.SizeOf<T>());
		}
	}
}
