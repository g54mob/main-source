using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder
{
	internal class Bc4ComponentBlockEncoder
	{
		private readonly ColorComponent component;

		public Bc4ComponentBlockEncoder(ColorComponent component)
		{
			this.component = component;
		}

		public Bc4ComponentBlock EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			Bc4ComponentBlock colorBlock = default(Bc4ComponentBlock);
			Span<ColorRgba32> asSpan = block.AsSpan;
			byte[] array = new byte[asSpan.Length];
			for (int i = 0; i < asSpan.Length; i++)
			{
				array[i] = ComponentHelper.ColorToComponent(asSpan[i], component);
			}
			return quality switch
			{
				CompressionQuality.Fast => FindComponentValues(colorBlock, array, 3), 
				CompressionQuality.Balanced => FindComponentValues(colorBlock, array, 4), 
				CompressionQuality.BestQuality => FindComponentValues(colorBlock, array, 8), 
				_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
			};
		}

		private static Bc4ComponentBlock FindComponentValues(Bc4ComponentBlock colorBlock, byte[] pixels, int variations)
		{
			byte b = byte.MaxValue;
			byte b2 = 0;
			bool flag = false;
			for (int i = 0; i < pixels.Length; i++)
			{
				if (pixels[i] < byte.MaxValue && pixels[i] > 0)
				{
					if (pixels[i] < b)
					{
						b = pixels[i];
					}
					if (pixels[i] > b2)
					{
						b2 = pixels[i];
					}
				}
				else
				{
					flag = true;
				}
			}
			if (flag && b == byte.MaxValue && b2 == 0)
			{
				colorBlock.Endpoint0 = 0;
				colorBlock.Endpoint1 = byte.MaxValue;
				SelectIndices(ref colorBlock);
				return colorBlock;
			}
			Bc4ComponentBlock block = colorBlock;
			block.Endpoint0 = b2;
			block.Endpoint1 = b;
			int num = SelectIndices(ref block);
			if (num == 0)
			{
				return block;
			}
			for (byte b3 = (byte)variations; b3 > 0; b3--)
			{
				byte b4 = ByteHelper.ClampToByte(b2 - b3);
				byte b5 = ByteHelper.ClampToByte(b + b3);
				Bc4ComponentBlock block2 = colorBlock;
				block2.Endpoint0 = (flag ? b5 : b4);
				block2.Endpoint1 = (flag ? b4 : b5);
				int num2 = SelectIndices(ref block2);
				if (num2 < num)
				{
					block = block2;
					num = num2;
					b2 = b4;
					b = b5;
				}
				byte b6 = ByteHelper.ClampToByte(b2 + b3);
				byte b7 = ByteHelper.ClampToByte(b - b3);
				Bc4ComponentBlock block3 = colorBlock;
				block3.Endpoint0 = (flag ? b7 : b6);
				block3.Endpoint1 = (flag ? b6 : b7);
				int num3 = SelectIndices(ref block3);
				if (num3 < num)
				{
					block = block3;
					num = num3;
					b2 = b6;
					b = b7;
				}
				byte b8 = ByteHelper.ClampToByte(b2);
				byte b9 = ByteHelper.ClampToByte(b - b3);
				Bc4ComponentBlock block4 = colorBlock;
				block4.Endpoint0 = (flag ? b9 : b8);
				block4.Endpoint1 = (flag ? b8 : b9);
				int num4 = SelectIndices(ref block4);
				if (num4 < num)
				{
					block = block4;
					num = num4;
					b2 = b8;
					b = b9;
				}
				byte b10 = ByteHelper.ClampToByte(b2 + b3);
				byte b11 = ByteHelper.ClampToByte(b);
				Bc4ComponentBlock block5 = colorBlock;
				block5.Endpoint0 = (flag ? b11 : b10);
				block5.Endpoint1 = (flag ? b10 : b11);
				int num5 = SelectIndices(ref block5);
				if (num5 < num)
				{
					block = block5;
					num = num5;
					b2 = b10;
					b = b11;
				}
				byte b12 = ByteHelper.ClampToByte(b2);
				byte b13 = ByteHelper.ClampToByte(b + b3);
				Bc4ComponentBlock block6 = colorBlock;
				block6.Endpoint0 = (flag ? b13 : b12);
				block6.Endpoint1 = (flag ? b12 : b13);
				int num6 = SelectIndices(ref block6);
				if (num6 < num)
				{
					block = block6;
					num = num6;
					b2 = b12;
					b = b13;
				}
				byte b14 = ByteHelper.ClampToByte(b2 - b3);
				byte b15 = ByteHelper.ClampToByte(b);
				Bc4ComponentBlock block7 = colorBlock;
				block7.Endpoint0 = (flag ? b15 : b14);
				block7.Endpoint1 = (flag ? b14 : b15);
				int num7 = SelectIndices(ref block7);
				if (num7 < num)
				{
					block = block7;
					num = num7;
					b2 = b14;
					b = b15;
				}
				if (num < 5)
				{
					break;
				}
			}
			return block;
			int SelectIndices(ref Bc4ComponentBlock reference)
			{
				int num8 = 0;
				byte endpoint = reference.Endpoint0;
				byte endpoint2 = reference.Endpoint1;
				Span<byte> span = ((endpoint <= endpoint2) ? stackalloc byte[8]
				{
					endpoint,
					endpoint2,
					endpoint.InterpolateFifth(endpoint2, 1),
					endpoint.InterpolateFifth(endpoint2, 2),
					endpoint.InterpolateFifth(endpoint2, 3),
					endpoint.InterpolateFifth(endpoint2, 4),
					0,
					byte.MaxValue
				} : stackalloc byte[8]
				{
					endpoint,
					endpoint2,
					endpoint.InterpolateSeventh(endpoint2, 1),
					endpoint.InterpolateSeventh(endpoint2, 2),
					endpoint.InterpolateSeventh(endpoint2, 3),
					endpoint.InterpolateSeventh(endpoint2, 4),
					endpoint.InterpolateSeventh(endpoint2, 5),
					endpoint.InterpolateSeventh(endpoint2, 6)
				});
				Span<byte> span2 = span;
				for (int j = 0; j < pixels.Length; j++)
				{
					byte redIndex = 0;
					int num9 = Math.Abs(pixels[j] - span2[0]);
					for (byte b16 = 1; b16 < span2.Length; b16++)
					{
						int num10 = Math.Abs(pixels[j] - span2[b16]);
						if (num10 < num9)
						{
							redIndex = b16;
							num9 = num10;
						}
						if (num9 == 0)
						{
							break;
						}
					}
					reference.SetComponentIndex(j, redIndex);
					num8 += num9 * num9;
				}
				return num8;
			}
		}
	}
}
