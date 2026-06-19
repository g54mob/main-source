using System;

namespace MessagePack.Decoders
{
	internal sealed class Str32StringSegment : IStringSegmentDecoder
	{
		internal static readonly IStringSegmentDecoder Instance = new Str32StringSegment();

		private Str32StringSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			int num = (bytes[offset + 1] << 24) | (bytes[offset + 2] << 16) | (bytes[offset + 3] << 8) | bytes[offset + 4];
			readSize = num + 5;
			return new ArraySegment<byte>(bytes, offset + 5, num);
		}
	}
}
