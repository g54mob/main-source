using System;
using System.IO;

namespace UniGLTF
{
	public static class Glb
	{
		public static byte[] ToBytes(string json, ArraySegment<byte> body)
		{
			using MemoryStream memoryStream = new MemoryStream();
			GlbHeader.WriteTo(memoryStream);
			long position = memoryStream.Position;
			memoryStream.Position += 4L;
			int value = 12 + new GlbChunk(json).WriteTo(memoryStream) + new GlbChunk(body).WriteTo(memoryStream);
			memoryStream.Position = position;
			byte[] bytes = BitConverter.GetBytes(value);
			memoryStream.Write(bytes, 0, bytes.Length);
			return memoryStream.ToArray();
		}
	}
}
