using System;

namespace MessagePack.Decoders
{
	internal sealed class Bin32BytesSegment : IBytesSegmentDecoder
	{
		internal static readonly IBytesSegmentDecoder Instance = new Bin32BytesSegment();

		private Bin32BytesSegment()
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
