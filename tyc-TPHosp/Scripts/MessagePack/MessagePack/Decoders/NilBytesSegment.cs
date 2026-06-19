using System;

namespace MessagePack.Decoders
{
	internal sealed class NilBytesSegment : IBytesSegmentDecoder
	{
		internal static readonly IBytesSegmentDecoder Instance = new NilBytesSegment();

		private NilBytesSegment()
		{
		}

		public ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 1;
			return default(ArraySegment<byte>);
		}
	}
}
