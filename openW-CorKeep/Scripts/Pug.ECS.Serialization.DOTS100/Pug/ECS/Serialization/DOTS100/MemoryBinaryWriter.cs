using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	public class MemoryBinaryWriter : BinaryWriter, IDisposable
	{
		private NativeList<byte> content = new NativeList<byte>(Allocator.Temp);

		public unsafe byte* Data => content.GetUnsafePtr();

		public int Length => content.Length;

		public long Position { get; set; }

		public void Dispose()
		{
			content.Dispose();
		}

		internal NativeArray<byte> GetContentAsNativeArray()
		{
			return content.AsArray();
		}

		public unsafe void WriteBytes(void* data, int bytes)
		{
			content.ResizeUninitialized((int)Position + bytes);
			UnsafeUtility.MemCpy(content.GetUnsafePtr() + (int)Position, data, bytes);
			Position += bytes;
		}
	}
}
