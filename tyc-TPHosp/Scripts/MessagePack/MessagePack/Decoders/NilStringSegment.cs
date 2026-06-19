using System;

namespace MessagePack.Decoders
{
	internal sealed class NilStringSegment : IStringSegmentDecoder
	{
		internal static readonly IStringSegmentDecoder Instance = new NilStringSegment();

		private NilStringSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 1;
			return new ArraySegment<byte>(bytes, offset, 1);
		}
	}
}
