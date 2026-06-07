using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	public class RawBgraDecoder : IRawDecoder
	{
		public ColorRgba32[] Decode(ReadOnlyMemory<byte> data, OperationContext context)
		{
			ColorRgba32[] array = new ColorRgba32[data.Length / 4];
			ReadOnlySpan<byte> span = data.Span;
			for (int i = 0; i < array.Length; i++)
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				array[i].b = span[i * 4];
				array[i].g = span[i * 4 + 1];
				array[i].r = span[i * 4 + 2];
				array[i].a = span[i * 4 + 3];
			}
			return array;
		}
	}
}
