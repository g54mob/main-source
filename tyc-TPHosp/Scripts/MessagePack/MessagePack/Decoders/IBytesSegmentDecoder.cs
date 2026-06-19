using System;

namespace MessagePack.Decoders
{
	internal interface IBytesSegmentDecoder
	{
		ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize);
	}
}
