using System;

namespace MessagePack.Decoders
{
	internal sealed class Str8StringSegment : IStringSegmentDecoder
	{
		internal static readonly IStringSegmentDecoder Instance = new Str8StringSegment();

		private Str8StringSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			int num = bytes[offset + 1];
			readSize = num + 2;
			return new ArraySegment<byte>(bytes, offset + 2, num);
		}
	}
}
