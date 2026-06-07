using System;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class Bc3BlockEncoder : BaseBcBlockEncoder<Bc3Block, RawBlock4X4Rgba32>
	{
		private static class Bc3BlockEncoderFast
		{
			internal static Bc3Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				PcaVectors.Create(asSpan, out var mean, out var principalAxis);
				PcaVectors.GetMinMaxColor565(asSpan, mean, principalAxis, out var min, out var max);
				ColorRgb565 colorRgb = max;
				ColorRgb565 colorRgb2 = min;
				if (colorRgb.data <= colorRgb2.data)
				{
					ColorRgb565 colorRgb3 = colorRgb;
					colorRgb = colorRgb2;
					colorRgb2 = colorRgb3;
				}
				float error;
				Bc3Block result = TryColors(rawBlock, colorRgb, colorRgb2, out error);
				result.alphaBlock = bc4BlockEncoder.EncodeBlock(rawBlock, CompressionQuality.Fast);
				return result;
			}
		}

		private static class Bc3BlockEncoderBalanced
		{
			private const int MaxTries = 48;

			private const float ErrorThreshold = 0.05f;

			internal static Bc3Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				Span<ColorRgba32> asSpan = rawBlock.AsSpan;
				PcaVectors.Create(asSpan, out var mean, out var principalAxis);
				PcaVectors.GetMinMaxColor565(asSpan, mean, principalAxis, out var min, out var max);
				ColorRgb565 colorRgb = max;
				ColorRgb565 colorRgb2 = min;
				float error;
				Bc3Block result = TryColors(rawBlock, colorRgb, colorRgb2, out error);
				for (int i = 0; i < 48; i++)
				{
					(ColorRgb565, ColorRgb565) tuple = ColorVariationGenerator.Variate565(colorRgb, colorRgb2, i);
					ColorRgb565 item = tuple.Item1;
					ColorRgb565 item2 = tuple.Item2;
					float error2;
					Bc3Block bc3Block = TryColors(rawBlock, item, item2, out error2);
					if (error2 < error)
					{
						result = bc3Block;
						error = error2;
						colorRgb = item;
						colorRgb2 = item2;
					}
					if (error < 0.05f)
					{
						break;
					}
				}
				result.alphaBlock = bc4BlockEncoder.EncodeBlock(rawBlock, CompressionQuality.Balanced);
				return result;
			}
		}

		private static class Bc3BlockEncoderSlow
		{
			private const int MaxTries = 9999;

			private const float ErrorThreshold = 0.01f;

			internal static Bc3Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
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
				Bc3Block result = TryColors(rawBlock, colorRgb, colorRgb2, out error);
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
					Bc3Block bc3Block = TryColors(rawBlock, colorRgb4, colorRgb5, out error2);
					num++;
					if (error2 < error)
					{
						result = bc3Block;
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
				result.alphaBlock = bc4BlockEncoder.EncodeBlock(rawBlock, CompressionQuality.BestQuality);
				return result;
			}
		}

		private static readonly Bc4ComponentBlockEncoder bc4BlockEncoder = new Bc4ComponentBlockEncoder(ColorComponent.A);

		public override Bc3Block EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			return quality switch
			{
				CompressionQuality.Fast => Bc3BlockEncoderFast.EncodeBlock(block), 
				CompressionQuality.Balanced => Bc3BlockEncoderBalanced.EncodeBlock(block), 
				CompressionQuality.BestQuality => Bc3BlockEncoderSlow.EncodeBlock(block), 
				_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
			};
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRgbaS3TcDxt5Ext;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgba;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatBc3Unorm;
		}

		private static Bc3Block TryColors(RawBlock4X4Rgba32 rawBlock, ColorRgb565 color0, ColorRgb565 color1, out float error, float rWeight = 0.3f, float gWeight = 0.6f, float bWeight = 0.1f)
		{
			Bc3Block result = default(Bc3Block);
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
				result[i] = ColorChooser.ChooseClosestColor4(colors, color2, rWeight, gWeight, bWeight, out var error2);
				error += error2;
			}
			return result;
		}
	}
}
