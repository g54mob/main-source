using System;

namespace MessagePack.Decoders
{
	internal sealed class Bin16BytesSegment : IBytesSegmentDecoder
	{
		internal static readonly IBytesSegmentDecoder Instance = new Bin16BytesSegment();

		private Bin16BytesSegment()
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
