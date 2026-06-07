using System;

namespace BCnEncoder.Shared
{
	internal struct AtcInterpolatedAlphaBlock
	{
		public Bc4ComponentBlock alphas;

		public AtcBlock colors;

		public readonly RawBlock4X4Rgba32 Decode()
		{
			RawBlock4X4Rgba32 result = colors.Decode();
			Span<ColorRgba32> asSpan = result.AsSpan;
			byte[] array = alphas.Decode();
			for (int i = 0; i < asSpan.Length; i++)
			{
				asSpan[i].a = array[i];
			}
			return result;
		}
	}
}
