using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class Bc2BlockEncoder : BaseBcBlockEncoder<Bc2Block, RawBlock4X4Rgba32>
	{
		private static class Bc2BlockEncoderFast
		{
			internal static Bc2Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				PcaVectors.Create(asSpan, out var mean, out var principalAxis);
				PcaVectors.GetMinMaxColor565(asSpan, mean, principalAxis, out var min, out var max);
				ColorRgb565 color = max;
				ColorRgb565 color2 = min;
				float error;
				return TryColors(rawBlock, color, color2, out error);
			}
		}

		private static class Bc2BlockEncoderBalanced
		{
			private const int MaxTries = 48;

			private const float ErrorThreshold = 0.05f;

			internal static Bc2Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				PcaVectors.Create(asSpan, out var mean, out var principalAxis);
				PcaVectors.GetMinMaxColor565(asSpan, mean, principalAxis, out var min, out var max);
				ColorRgb565 colorRgb = max;
				ColorRgb565 colorRgb2 = min;
				float error;
				Bc2Block result = TryColors(rawBlock, colorRgb, colorRgb2, out error);
				for (int i = 0; i < 48; i++)
				{
					(ColorRgb565, ColorRgb565) tuple = ColorVariationGenerator.Variate565(colorRgb, colorRgb2, i);
					ColorRgb565 item = tuple.Item1;
					ColorRgb565 item2 = tuple.Item2;
					float error2;
					Bc2Block bc2Block = TryColors(rawBlock, item, item2, out error2);
					if (error2 < error)
					{
						result = bc2Block;
						error = error2;
						colorRgb = item;
						colorRgb2 = item2;
					}
					if (error < 0.05f)
					{
						break;
					}
				}
				return result;
			}
		}

		private static class Bc2BlockEncoderSlow
		{
			private const int MaxTries = 9999;

			private const float ErrorThreshold = 0.01f;

			internal static Bc2Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				PcaVectors.Create(asSpan, out var mean, out var principalAxis);
				PcaVectors.GetMinMaxColor565(asSpan, mean, principalAxis, out var min, out var max);
				ColorRgb565 colorRgb = max;
				ColorRgb565 colorRgb2 = min;
				if (colorRgb.data < colorRgb2.data)
				{
					ColorRgb565 colorRgb3 = colorRgb;
					colorRgb = colorRgb2;
					colorRgb2 = colorRgb3;
				}
				float error;
				Bc2Block result = TryColors(rawBlock, colorRgb, colorRgb2, out error);
				int num = 0;
				for (int i = 0; i < 9999; i++)
				{
					var (colorRgb4, colorRgb5) = ColorVariationGenerator.Variate565(colorRgb, colorRgb2, i);
					if (colorRgb4.data < colorRgb5.data)
					{
						ColorRgb565 colorRgb6 = colorRgb4;
						colorRgb4 = colorRgb5;
						colorRgb5 = colorRgb6;
					}
					float error2;
					Bc2Block bc2Block = TryColors(rawBlock, colorRgb4, colorRgb5, out error2);
					num++;
					if (error2 < error)
					{
						result = bc2Block;
						error = error2;
						colorRgb = colorRgb4;
						colorRgb2 = colorRgb5;
						num = 0;
					}
					if (error < 0.01f || num > ColorVariationGenerator.VarPatternCount)
					{
						break;
					}
				}
				return result;
			}
		}

		public override Bc2Block EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			return quality switch
			{
				CompressionQuality.Fast => Bc2BlockEncoderFast.EncodeBlock(block), 
				CompressionQuality.Balanced => Bc2BlockEncoderBalanced.EncodeBlock(block), 
				CompressionQuality.BestQuality => Bc2BlockEncoderSlow.EncodeBlock(block), 
				_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
			};
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRgbaS3TcDxt3Ext;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgba;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatBc2Unorm;
		}

		private static Bc2Block TryColors(RawBlock4X4Rgba32 rawBlock, ColorRgb565 color0, ColorRgb565 color1, out float error, float rWeight = 0.3f, float gWeight = 0.6f, float bWeight = 0.1f)
		{
			Bc2Block result = default(Bc2Block);
			Span<ColorRgba32> asSpan = rawBlock.AsSpan;
			result.color0 = color0;
			result.color1 = color1;
			ColorRgb24 colorRgb = color0.ToColorRgb24();
			ColorRgb24 colorRgb2 = color1.ToColorRgb24();
			ReadOnlySpan<ColorRgb24> colors = stackalloc ColorRgb24[4]
			{
				colorRgb,
				colorRgb2,
				colorRgb.InterpolateThird(colorRgb2, 1),
				colorRgb.InterpolateThird(colorRgb2, 2)
			};
			error = 0f;
			for (int i = 0; i < 16; i++)
			{
				ColorRgba32 color2 = asSpan[i];
				result.SetAlpha(i, color2.a);
				result[i] = ColorChooser.ChooseClosestColor4(colors, color2, rWeight, gWeight, bWeight, out var error2);
				error += error2;
			}
			return result;
		}
	}
}
