using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	public class RawRDecoder : IRawDecoder
	{
		private readonly bool redAsLuminance;

		public RawRDecoder(bool redAsLuminance)
		{
			this.redAsLuminance = redAsLuminance;
		}

		public ColorRgba32[] Decode(ReadOnlyMemory<byte> data, OperationContext context)
		{
			ColorRgba32[] array = new ColorRgba32[data.Length];
			ReadOnlySpan<byte> span = data.Span;
			for (int i = 0; i < array.Length; i++)
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				if (redAsLuminance)
				{
					array[i].r = span[i];
					array[i].g = span[i];
					array[i].b = span[i];
				}
				else
				{
					array[i].r = span[i];
					array[i].g = 0;
					array[i].b = 0;
				}
				array[i].a = byte.MaxValue;
			}
			return array;
		}
	}
}
