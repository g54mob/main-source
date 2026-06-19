using System;

namespace MessagePack.Decoders
{
	internal sealed class FixStringSegment : IStringSegmentDecoder
	{
		internal static readonly IStringSegmentDecoder Instance = new FixStringSegment();

		private FixStringSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			int num = bytes[offset] & 0x1F;
			readSize = num + 1;
			return new ArraySegment<byte>(bytes, offset + 1, num);
		}
	}
}
