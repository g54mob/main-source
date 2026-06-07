using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal interface IRawDecoder
	{
		ColorRgba32[] Decode(ReadOnlyMemory<byte> data, OperationContext context);
	}
}
