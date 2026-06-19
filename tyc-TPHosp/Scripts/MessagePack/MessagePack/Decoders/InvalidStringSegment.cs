using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidStringSegment : IStringSegmentDecoder
	{
		internal static readonly IStringSegmentDecoder Instance = new InvalidStringSegment();

		private InvalidStringSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
