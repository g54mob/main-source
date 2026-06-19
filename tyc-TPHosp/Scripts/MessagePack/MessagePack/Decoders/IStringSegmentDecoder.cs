using System;

namespace MessagePack.Decoders
{
	internal interface IStringSegmentDecoder
	{
		ArraySegment<byte> Read(byte[] bytes, int offset, out int readSize);
	}
}
