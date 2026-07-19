using System;
using System.IO;
using System.Text;

namespace UniGLTF
{
	public struct GlbChunk
	{
		public GlbChunkType ChunkType;

		public ArraySegment<byte> Bytes;

		public GlbChunk(string json)
			: this(GlbChunkType.JSON, new ArraySegment<byte>(Encoding.UTF8.GetBytes(json)))
		{
		}

		public GlbChunk(ArraySegment<byte> bytes)
			: this(GlbChunkType.BIN, bytes)
		{
		}

		public GlbChunk(GlbChunkType type, ArraySegment<byte> bytes)
		{
			ChunkType = type;
			Bytes = bytes;
		}

		private byte GetPaddingByte()
		{
			return ChunkType switch
			{
				GlbChunkType.JSON => 32, 
				GlbChunkType.BIN => 0, 
				_ => throw new Exception("unknown chunk type: " + ChunkType), 
			};
		}

		public int WriteTo(Stream s)
		{
			int num = Bytes.Count % 4;
			int num2 = ((num > 0) ? (4 - num) : 0);
			byte[] bytes = BitConverter.GetBytes(Bytes.Count + num2);
			s.Write(bytes, 0, bytes.Length);
			switch (ChunkType)
			{
			case GlbChunkType.JSON:
				s.WriteByte(74);
				s.WriteByte(83);
				s.WriteByte(79);
				s.WriteByte(78);
				break;
			case GlbChunkType.BIN:
				s.WriteByte(66);
				s.WriteByte(73);
				s.WriteByte(78);
				s.WriteByte(0);
				break;
			default:
				throw new Exception("unknown chunk type: " + ChunkType);
			}
			s.Write(Bytes.Array, Bytes.Offset, Bytes.Count);
			byte paddingByte = GetPaddingByte();
			for (int i = 0; i < num2; i++)
			{
				s.WriteByte(paddingByte);
			}
			return 8 + Bytes.Count + num2;
		}
	}
}
