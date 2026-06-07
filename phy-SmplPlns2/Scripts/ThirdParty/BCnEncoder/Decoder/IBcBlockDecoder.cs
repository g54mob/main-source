using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal interface IBcBlockDecoder<T> where T : unmanaged
	{
		T[] Decode(ReadOnlyMemory<byte> data, OperationContext context);

		T DecodeBlock(ReadOnlySpan<byte> data);
	}
}
