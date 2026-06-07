using System;

namespace BCnEncoder.Shared
{
	internal struct Bc4Block
	{
		public Bc4ComponentBlock componentBlock;

		public byte Endpoint0
		{
			readonly get
			{
				return componentBlock.Endpoint0;
			}
			set
			{
				componentBlock.Endpoint0 = value;
			}
		}

		public byte Endpoint1
		{
			readonly get
			{
				return componentBlock.Endpoint1;
			}
			set
			{
				componentBlock.Endpoint1 = value;
			}
		}

		public readonly byte GetComponentIndex(int pixelIndex)
		{
			return componentBlock.GetComponentIndex(pixelIndex);
		}

		public void SetComponentIndex(int pixelIndex, byte redIndex)
		{
			componentBlock.SetComponentIndex(pixelIndex, redIndex);
		}

		public readonly RawBlock4X4Rgba32 Decode(ColorComponent component = ColorComponent.R)
		{
			RawBlock4X4Rgba32 result = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = result.AsSpan;
			byte[] array = componentBlock.Decode();
			for (int i = 0; i < asSpan.Length; i++)
			{
				asSpan[i] = ComponentHelper.ComponentToColor(component, array[i]);
			}
			return result;
		}
	}
}
