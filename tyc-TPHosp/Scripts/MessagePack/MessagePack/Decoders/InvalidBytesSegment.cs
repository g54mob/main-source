using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidBytesSegment : IBytesSegmentDecoder
	{
		internal static readonly IBytesSegmentDecoder Instance = new InvalidBytesSegment();

		private InvalidBytesSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
