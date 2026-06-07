using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	public class RawRgDecoder : IRawDecoder
	{
		public ColorRgba32[] Decode(ReadOnlyMemory<byte> data, OperationContext context)
		{
			ColorRgba32[] array = new ColorRgba32[data.Length / 2];
			ReadOnlySpan<byte> span = data.Span;
			for (int i = 0; i < array.Length; i++)
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				array[i].r = span[i * 2];
				array[i].g = span[i * 2 + 1];
				array[i].b = 0;
				array[i].a = byte.MaxValue;
			}
			return array;
		}
	}
}
