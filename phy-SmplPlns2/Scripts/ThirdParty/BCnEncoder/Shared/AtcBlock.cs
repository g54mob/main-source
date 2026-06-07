using System;

namespace BCnEncoder.Shared
{
	internal struct AtcBlock
	{
		public ColorRgb555 color0;

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

		public readonly RawBlock4X4Rgba32 Decode()
		{
			RawBlock4X4Rgba32 result = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = result.AsSpan;
			ColorRgb24 colorRgb = color0.ToColorRgb24();
			ColorRgb24 colorRgb2 = color1.ToColorRgb24();
			Span<ColorRgb24> span = stackalloc ColorRgb24[4]
			{
				new ColorRgb24(0, 0, 0),
				colorRgb.InterpolateFourthAtc(colorRgb2, 1),
				colorRgb,
				colorRgb2
			};
			for (int i = 0; i < asSpan.Length; i++)
			{
				int num = this[i];
				ColorRgb24 colorRgb3 = ((color0.Mode == 0) ? colorRgb.InterpolateThird(colorRgb2, num) : span[num]);
				asSpan[i] = new ColorRgba32(colorRgb3.r, colorRgb3.g, colorRgb3.b, byte.MaxValue);
			}
			return result;
		}
	}
}
