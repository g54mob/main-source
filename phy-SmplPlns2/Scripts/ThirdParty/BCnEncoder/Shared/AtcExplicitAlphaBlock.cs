using System;

namespace BCnEncoder.Shared
{
	internal struct AtcExplicitAlphaBlock
	{
		public Bc2AlphaBlock alphas;

		public AtcBlock colors;

		public readonly RawBlock4X4Rgba32 Decode()
		{
			RawBlock4X4Rgba32 result = colors.Decode();
			Span<ColorRgba32> asSpan = result.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				asSpan[i].a = alphas.GetAlpha(i);
			}
			return result;
		}
	}
}
