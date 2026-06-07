using System;

namespace BCnEncoder.Shared
{
	internal struct Bc5Block
	{
		public Bc4ComponentBlock redBlock;

		public Bc4ComponentBlock greenBlock;

		public byte Red0
		{
			readonly get
			{
				return redBlock.Endpoint0;
			}
			set
			{
				redBlock.Endpoint0 = value;
			}
		}

		public byte Red1
		{
			readonly get
			{
				return redBlock.Endpoint1;
			}
			set
			{
				redBlock.Endpoint1 = value;
			}
		}

		public byte Green0
		{
			readonly get
			{
				return greenBlock.Endpoint0;
			}
			set
			{
				greenBlock.Endpoint0 = value;
			}
		}

		public byte Green1
		{
			readonly get
			{
				return greenBlock.Endpoint1;
			}
			set
			{
				greenBlock.Endpoint1 = value;
			}
		}

		public readonly byte GetRedIndex(int pixelIndex)
		{
			return redBlock.GetComponentIndex(pixelIndex);
		}

		public void SetRedIndex(int pixelIndex, byte redIndex)
		{
			redBlock.SetComponentIndex(pixelIndex, redIndex);
		}

		public readonly byte GetGreenIndex(int pixelIndex)
		{
			return greenBlock.GetComponentIndex(pixelIndex);
		}

		public void SetGreenIndex(int pixelIndex, byte greenIndex)
		{
			greenBlock.SetComponentIndex(pixelIndex, greenIndex);
		}

		public readonly RawBlock4X4Rgba32 Decode(ColorComponent component1 = ColorComponent.R, ColorComponent component2 = ColorComponent.G)
		{
			RawBlock4X4Rgba32 result = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = result.AsSpan;
			byte[] array = redBlock.Decode();
			byte[] array2 = greenBlock.Decode();
			for (int i = 0; i < asSpan.Length; i++)
			{
				asSpan[i] = ComponentHelper.ComponentToColor(component1, array[i]);
				asSpan[i] = ComponentHelper.ComponentToColor(asSpan[i], component2, array2[i]);
			}
			return result;
		}
	}
}
