using System;

namespace BCnEncoder.Shared
{
	internal struct Bc3Block
	{
		public Bc4ComponentBlock alphaBlock;

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

		public byte Alpha0
		{
			get
			{
				return alphaBlock.Endpoint0;
			}
			set
			{
				alphaBlock.Endpoint0 = value;
			}
		}

		public byte Alpha1
		{
			get
			{
				return alphaBlock.Endpoint1;
			}
			set
			{
				alphaBlock.Endpoint1 = value;
			}
		}

		public readonly byte GetAlphaIndex(int pixelIndex)
		{
			return alphaBlock.GetComponentIndex(pixelIndex);
		}

		public void SetAlphaIndex(int pixelIndex, byte alphaIndex)
		{
			alphaBlock.SetComponentIndex(pixelIndex, alphaIndex);
		}

		public readonly RawBlock4X4Rgba32 Decode()
		{
			RawBlock4X4Rgba32 result = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = result.AsSpan;
			ColorRgb24 colorRgb = color0.ToColorRgb24();
			ColorRgb24 colorRgb2 = color1.ToColorRgb24();
			Span<ColorRgb24> span = stackalloc ColorRgb24[4]
			{
				colorRgb,
				colorRgb2,
				colorRgb.InterpolateThird(colorRgb2, 1),
				colorRgb.InterpolateThird(colorRgb2, 2)
			};
			byte[] array = alphaBlock.Decode();
			for (int i = 0; i < asSpan.Length; i++)
			{
				int index = (int)((colorIndices >> i * 2) & 3);
				ColorRgb24 colorRgb3 = span[index];
				asSpan[i] = new ColorRgba32(colorRgb3.r, colorRgb3.g, colorRgb3.b, array[i]);
			}
			return result;
		}
	}
}
