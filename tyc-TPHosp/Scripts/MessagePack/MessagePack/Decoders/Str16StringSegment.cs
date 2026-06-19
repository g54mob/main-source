using System;

namespace MessagePack.Decoders
{
	internal sealed class Str16StringSegment : IStringSegmentDecoder
	{
		internal static readonly IStringSegmentDecoder Instance = new Str16StringSegment();

		private Str16StringSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			int num = (bytes[offset + 1] << 8) + bytes[offset + 2];
			readSize = num + 3;
			return new ArraySegment<byte>(bytes, offset + 3, num);
		}
	}
}
