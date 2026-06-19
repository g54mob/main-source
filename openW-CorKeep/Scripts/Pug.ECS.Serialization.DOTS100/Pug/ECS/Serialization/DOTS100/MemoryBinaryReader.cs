using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	public class MemoryBinaryReader : BinaryReader, IDisposable
	{
		private unsafe readonly byte* content;

		private readonly long length;

		public long Position { get; set; }

		public unsafe MemoryBinaryReader(byte* content, long length)
		{
			this.content = content;
			this.length = length;
			Position = 0L;
		}

		public void Dispose()
		{
		}

		public unsafe void ReadBytes(void* data, int bytes)
		{
			UnsafeUtility.MemCpy(data, content + Position, bytes);
			Position += bytes;
		}

		public unsafe static explicit operator BurstableMemoryBinaryReader(MemoryBinaryReader src)
		{
			return new BurstableMemoryBinaryReader
			{
				content = src.content,
				length = src.length,
				Position = src.Position
			};
		}
	}
}
