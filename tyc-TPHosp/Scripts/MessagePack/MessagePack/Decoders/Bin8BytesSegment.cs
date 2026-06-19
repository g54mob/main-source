using System;

namespace MessagePack.Decoders
{
	internal sealed class Bin8BytesSegment : IBytesSegmentDecoder
	{
		internal static readonly IBytesSegmentDecoder Instance = new Bin8BytesSegment();

		private Bin8BytesSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			byte b = bytes[offset + 1];
			readSize = b + 2;
			return new ArraySegment<byte>(bytes, offset + 2, b);
		}
	}
}
