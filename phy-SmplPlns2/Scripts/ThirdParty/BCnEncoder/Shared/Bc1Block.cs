using System;

namespace BCnEncoder.Shared
{
	internal struct Bc1Block
	{
		public ColorRgb565 color0;

		public ColorRgb565 color1;

		public uint colorIndices;

		public int this[int index]
		{
			readonly get
			{
				return (int)((colorIndices >> index * 2) & 3);
			}
			set
			{
				colorIndices = (uint)(colorIndices & ~(3 << index * 2));
				int num = value & 3;
				colorIndices |= (uint)(num << index * 2);
			}
		}

		public readonly bool HasAlphaOrBlack => color0.data <= color1.data;

		public readonly RawBlock4X4Rgba32 Decode(bool useAlpha)
		{
			RawBlock4X4Rgba32 result = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = result.AsSpan;
			ColorRgb24 colorRgb = color0.ToColorRgb24();
			ColorRgb24 colorRgb2 = color1.ToColorRgb24();
			useAlpha = useAlpha && HasAlphaOrBlack;
			Span<ColorRgb24> span = ((!HasAlphaOrBlack) ? stackalloc ColorRgb24[4]
			{
				colorRgb,
				colorRgb2,
				colorRgb.InterpolateThird(colorRgb2, 1),
				colorRgb.InterpolateThird(colorRgb2, 2)
			} : stackalloc ColorRgb24[4]
			{
				colorRgb,
				colorRgb2,
				colorRgb.InterpolateHalf(colorRgb2),
				new ColorRgb24(0, 0, 0)
			});
			Span<ColorRgb24> span2 = span;
			for (int i = 0; i < asSpan.Length; i++)
			{
				int num = (int)((colorIndices >> i * 2) & 3);
				ColorRgb24 colorRgb3 = span2[num];
				if (useAlpha && num == 3)
				{
					asSpan[i] = new ColorRgba32(0, 0, 0, 0);
				}
				else
				{
					asSpan[i] = new ColorRgba32(colorRgb3.r, colorRgb3.g, colorRgb3.b, byte.MaxValue);
				}
			}
			return result;
		}
	}
}
