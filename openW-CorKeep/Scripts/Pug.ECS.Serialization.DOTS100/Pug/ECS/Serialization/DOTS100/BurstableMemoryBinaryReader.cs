using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	[GenerateTestsForBurstCompatibility]
	public struct BurstableMemoryBinaryReader : BinaryReader, IDisposable
	{
		internal unsafe byte* content;

		internal long length;

		public long Position { get; set; }

		public unsafe BurstableMemoryBinaryReader(byte* content, long length)
		{
			this.content = content;
			this.length = length;
			Position = 0L;
		}

		public void Dispose()
		{
		}

		public unsafe byte ReadByte()
		{
			byte result = content[Position];
			Position++;
			return result;
		}

		public unsafe int ReadInt()
		{
			int result = *(int*)(content + Position);
			Position += 4L;
			return result;
		}

		public unsafe ulong ReadULong()
		{
			long result = *(long*)(content + Position);
			Position += 8L;
			return (ulong)result;
		}

		public unsafe void ReadBytes(void* data, int bytes)
		{
			UnsafeUtility.MemCpy(data, content + Position, bytes);
			Position += bytes;
		}
	}
}
