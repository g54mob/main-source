using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class Bc1AlphaBlockEncoder : BaseBcBlockEncoder<Bc1Block, RawBlock4X4Rgba32>
	{
		private static class Bc1AlphaBlockEncoderFast
		{
			internal static Bc1Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				bool flag = rawBlock.HasTransparentPixels();
				RgbBoundingBox.Create565AlphaCutoff(asSpan, out var min, out var max);
				ColorRgb565 colorRgb = max;
				ColorRgb565 colorRgb2 = min;
				if (flag && colorRgb.data > colorRgb2.data)
				{
					ColorRgb565 colorRgb3 = colorRgb;
					colorRgb = colorRgb2;
					colorRgb2 = colorRgb3;
				}
				float error;
				return TryColors(rawBlock, colorRgb, colorRgb2, out error);
			}
		}

		private static class Bc1AlphaBlockEncoderBalanced
		{
			private const int MaxTries = 48;

			private const float ErrorThreshold = 0.05f;

			internal static Bc1Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				bool flag = rawBlock.HasTransparentPixels();
				PcaVectors.Create(asSpan, out var mean, out var principalAxis);
				PcaVectors.GetMinMaxColor565(asSpan, mean, principalAxis, out var min, out var max);
				ColorRgb565 colorRgb = max;
				ColorRgb565 colorRgb2 = min;
				if (!flag && colorRgb.data < colorRgb2.data)
				{
					ColorRgb565 colorRgb3 = colorRgb;
					colorRgb = colorRgb2;
					colorRgb2 = colorRgb3;
				}
				else if (flag && colorRgb2.data < colorRgb.data)
				{
					ColorRgb565 colorRgb4 = colorRgb;
					colorRgb = colorRgb2;
					colorRgb2 = colorRgb4;
				}
				float error;
				Bc1Block result = TryColors(rawBlock, colorRgb, colorRgb2, out error);
				for (int i = 0; i < 48; i++)
				{
					var (colorRgb5, colorRgb6) = ColorVariationGenerator.Variate565(colorRgb, colorRgb2, i);
					if (!flag && colorRgb5.data < colorRgb6.data)
					{
						ColorRgb565 colorRgb7 = colorRgb5;
						colorRgb5 = colorRgb6;
						colorRgb6 = colorRgb7;
					}
					else if (flag && colorRgb6.data < colorRgb5.data)
					{
						ColorRgb565 colorRgb8 = colorRgb5;
						colorRgb5 = colorRgb6;
						colorRgb6 = colorRgb8;
					}
					float error2;
					Bc1Block bc1Block = TryColors(rawBlock, colorRgb5, colorRgb6, out error2);
					if (error2 < error)
					{
						result = bc1Block;
						error = error2;
						colorRgb = colorRgb5;
						colorRgb2 = colorRgb6;
					}
					if (error < 0.05f)
					{
						break;
					}
				}
				return result;
			}
		}

		private static class Bc1AlphaBlockEncoderSlow
		{
			private const int MaxTries = 9999;

			private const float ErrorThreshold = 0.05f;

			internal static Bc1Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				bool flag = rawBlock.HasTransparentPixels();
				PcaVectors.Create(asSpan, out var mean, out var principalAxis);
				PcaVectors.GetMinMaxColor565(asSpan, mean, principalAxis, out var min, out var max);
				ColorRgb565 colorRgb = max;
				ColorRgb565 colorRgb2 = min;
				if (!flag && colorRgb.data < colorRgb2.data)
				{
					ColorRgb565 colorRgb3 = colorRgb;
					colorRgb = colorRgb2;
					colorRgb2 = colorRgb3;
				}
				else if (flag && colorRgb2.data < colorRgb.data)
				{
					ColorRgb565 colorRgb4 = colorRgb;
					colorRgb = colorRgb2;
					colorRgb2 = colorRgb4;
				}
				float error;
				Bc1Block result = TryColors(rawBlock, colorRgb, colorRgb2, out error);
				int num = 0;
				for (int i = 0; i < 9999; i++)
				{
					var (colorRgb5, colorRgb6) = ColorVariationGenerator.Variate565(colorRgb, colorRgb2, i);
					if (!flag && colorRgb5.data < colorRgb6.data)
					{
						ColorRgb565 colorRgb7 = colorRgb5;
						colorRgb5 = colorRgb6;
						colorRgb6 = colorRgb7;
					}
					else if (flag && colorRgb6.data < colorRgb5.data)
					{
						ColorRgb565 colorRgb8 = colorRgb5;
						colorRgb5 = colorRgb6;
						colorRgb6 = colorRgb8;
					}
					float error2;
					Bc1Block bc1Block = TryColors(rawBlock, colorRgb5, colorRgb6, out error2);
					num++;
					if (error2 < error)
					{
						result = bc1Block;
						error = error2;
						colorRgb = colorRgb5;
						colorRgb2 = colorRgb6;
						num = 0;
					}
					if (error < 0.05f || num > ColorVariationGenerator.VarPatternCount)
					{
						break;
					}
				}
				return result;
			}
		}

		public override Bc1Block EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			return quality switch
			{
				CompressionQuality.Fast => Bc1AlphaBlockEncoderFast.EncodeBlock(block), 
				CompressionQuality.Balanced => Bc1AlphaBlockEncoderBalanced.EncodeBlock(block), 
				CompressionQuality.BestQuality => Bc1AlphaBlockEncoderSlow.EncodeBlock(block), 
				_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
			};
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRgbaS3TcDxt1Ext;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgba;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatBc1Unorm;
		}

		private static Bc1Block TryColors(RawBlock4X4Rgba32 rawBlock, ColorRgb565 color0, ColorRgb565 color1, out float error, float rWeight = 0.3f, float gWeight = 0.6f, float bWeight = 0.1f)
		{
			Bc1Block result = default(Bc1Block);
			Span<ColorRgba32> asSpan = rawBlock.AsSpan;
			result.color0 = color0;
			result.color1 = color1;
			ColorRgb24 colorRgb = color0.ToColorRgb24();
			ColorRgb24 colorRgb2 = color1.ToColorRgb24();
			bool hasAlphaOrBlack = result.HasAlphaOrBlack;
			Span<ColorRgb24> span = ((!hasAlphaOrBlack) ? stackalloc ColorRgb24[4]
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
			ReadOnlySpan<ColorRgb24> colors = span;
			error = 0f;
			for (int i = 0; i < 16; i++)
			{
				ColorRgba32 color2 = asSpan[i];
				result[i] = ColorChooser.ChooseClosestColor4AlphaCutoff(colors, color2, rWeight, gWeight, bWeight, 128, hasAlphaOrBlack, out var error2);
				error += error2;
			}
			return result;
		}
	}
}
