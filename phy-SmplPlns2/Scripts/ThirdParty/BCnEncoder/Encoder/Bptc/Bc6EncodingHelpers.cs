using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc6EncodingHelpers
	{
		internal static int PreQuantize(float value, bool signed)
		{
			Half half = new Half(value);
			int bits = Half.GetBits(half);
			if (!signed)
			{
				return (bits << 6) / 31;
			}
			if (half < new Half(0))
			{
				return -((-(-(bits & -32769)) << 5) / 31);
			}
			return (bits << 5) / 31;
		}

		internal static int Quantize(int component, int endpointBits, bool signed)
		{
			if (!signed)
			{
				if (endpointBits >= 15)
				{
					return component;
				}
				return component switch
				{
					0 => 0, 
					65535 => (1 << endpointBits) - 1, 
					_ => (component << endpointBits) - 32768 >> 16, 
				};
			}
			if (endpointBits >= 16)
			{
				return component;
			}
			if (component == 0)
			{
				return 0;
			}
			if (component > 0)
			{
				if (component == 32767)
				{
					return (1 << endpointBits - 1) - 1;
				}
				return (component << endpointBits - 1) - 16384 >> 15;
			}
			if (-component == 32767)
			{
				return -((1 << endpointBits - 1) - 1);
			}
			return -((-component << endpointBits - 1) + 16384 >> 15);
		}

		public static (int, int, int) PreQuantizeRawEndpoint(ColorRgbFloat endpoint, bool signed)
		{
			int item = PreQuantize(endpoint.r, signed);
			int item2 = PreQuantize(endpoint.g, signed);
			int item3 = PreQuantize(endpoint.b, signed);
			return (item, item2, item3);
		}

		public static (int, int, int) FinishQuantizeEndpoint((int, int, int) endpoint, int endpointBits, bool signed)
		{
			return (Quantize(endpoint.Item1, endpointBits, signed), Quantize(endpoint.Item2, endpointBits, signed), Quantize(endpoint.Item3, endpointBits, signed));
		}

		public static int CreateTranformedEndpoint(int quantizedEp0, int quantizedEpT, int deltaBits, ref bool badTransform)
		{
			int num = quantizedEpT - quantizedEp0;
			int num2 = 1 << deltaBits - 1;
			if ((num >= 0) ? (num >= num2) : (-num > num2))
			{
				badTransform = true;
			}
			if (num < 0)
			{
				num = ((-num <= num2) ? (num & ((1 << deltaBits) - 1)) : num2);
			}
			else if (num >= num2)
			{
				num = num2 - 1;
			}
			return num;
		}

		public static (int, int, int) CreateTransformedEndpoint((int, int, int) quantizedEp0, (int, int, int) quantizedEpT, (int, int, int) deltaBits, ref bool badTransform)
		{
			return (CreateTranformedEndpoint(quantizedEp0.Item1, quantizedEpT.Item1, deltaBits.Item1, ref badTransform), CreateTranformedEndpoint(quantizedEp0.Item2, quantizedEpT.Item2, deltaBits.Item2, ref badTransform), CreateTranformedEndpoint(quantizedEp0.Item3, quantizedEpT.Item3, deltaBits.Item3, ref badTransform));
		}

		public static void GeneratePalette(Span<ColorRgbFloat> palette, (int, int, int) unQuantizedEp0, (int, int, int) unQuantizedEp1, int indexPrecision, bool signed)
		{
			int num = 1 << indexPrecision;
			for (int i = 0; i < num; i++)
			{
				var (half, half2, half3) = Bc6Block.FinishUnQuantize(Bc6Block.InterpolateColor(unQuantizedEp0, unQuantizedEp1, i, indexPrecision), signed);
				palette[i] = new ColorRgbFloat(half, half2, half3);
			}
		}

		public static void GeneratePaletteInt(Span<(int, int, int)> palette, (int, int, int) unQuantizedEp0, (int, int, int) unQuantizedEp1, int indexPrecision, bool signed)
		{
			int num = 1 << indexPrecision;
			for (int i = 0; i < num; i++)
			{
				(int, int, int) tuple = Bc6Block.InterpolateColor(unQuantizedEp0, unQuantizedEp1, i, indexPrecision);
				palette[i] = tuple;
			}
		}

		private static int FindClosestColorIndexInt((int, int, int) color, ReadOnlySpan<(int, int, int)> colors, out float bestError)
		{
			bestError = CalculateError(color, colors[0]);
			int result = 0;
			for (int i = 1; i < colors.Length; i++)
			{
				float num = CalculateError(color, colors[i]);
				if (num < bestError)
				{
					result = i;
					bestError = num;
				}
				if (bestError == 0f)
				{
					break;
				}
			}
			return result;
			static float CalculateError((int, int, int) c0, (int, int, int) c1)
			{
				return Math.Abs(c0.Item1 - c1.Item1) + Math.Abs(c0.Item2 - c1.Item2) + Math.Abs(c0.Item3 - c1.Item3);
			}
		}

		private static int FindClosestColorIndex(ColorRgbFloat color, ReadOnlySpan<ColorRgbFloat> colors, out float bestError)
		{
			bestError = color.CalcLogDist(colors[0]);
			int result = 0;
			for (int i = 1; i < colors.Length; i++)
			{
				float num = color.CalcLogDist(colors[i]);
				if (num < bestError)
				{
					result = i;
					bestError = num;
				}
				if (bestError == 0f)
				{
					break;
				}
			}
			return result;
		}

		public static float FindOptimalIndicesInt1Sub(RawBlock4X4RgbFloat block, (int, int, int) unQuantizedEp0, (int, int, int) unQuantizedEp1, Span<byte> indices, bool signed)
		{
			Span<(int, int, int)> span = stackalloc(int, int, int)[16];
			GeneratePaletteInt(span, unQuantizedEp0, unQuantizedEp1, 4, signed);
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			float num = 0f;
			for (int i = 0; i < asSpan.Length; i++)
			{
				(int, int, int) color = PreQuantizeRawEndpoint(asSpan[i], signed);
				indices[i] = (byte)FindClosestColorIndexInt(color, span, out var bestError);
				num += bestError;
			}
			return MathF.Sqrt(num / 48f);
		}

		public static float FindOptimalIndices1Sub(RawBlock4X4RgbFloat block, (int, int, int) unQuantizedEp0, (int, int, int) unQuantizedEp1, Span<byte> indices, bool signed)
		{
			Span<ColorRgbFloat> span = stackalloc ColorRgbFloat[16];
			GeneratePalette(span, unQuantizedEp0, unQuantizedEp1, 4, signed);
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			float num = 0f;
			for (int i = 0; i < asSpan.Length; i++)
			{
				indices[i] = (byte)FindClosestColorIndex(asSpan[i], span, out var bestError);
				num += bestError;
			}
			return num;
		}

		public static float FindOptimalIndicesInt2Sub(RawBlock4X4RgbFloat block, (int, int, int) unQuantizedEp0, (int, int, int) unQuantizedEp1, Span<byte> indices, int partitionSetId, int subsetIndex, bool signed)
		{
			Span<(int, int, int)> span = stackalloc(int, int, int)[8];
			GeneratePaletteInt(span, unQuantizedEp0, unQuantizedEp1, 3, signed);
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			float num = 0f;
			for (int i = 0; i < asSpan.Length; i++)
			{
				if (Bc6Block.Subsets2PartitionTable[partitionSetId][i] == subsetIndex)
				{
					(int, int, int) color = PreQuantizeRawEndpoint(asSpan[i], signed);
					indices[i] = (byte)FindClosestColorIndexInt(color, span, out var bestError);
					num += bestError;
				}
			}
			return num;
		}

		public static float FindOptimalIndices2Sub(RawBlock4X4RgbFloat block, (int, int, int) unQuantizedEp0, (int, int, int) unQuantizedEp1, Span<byte> indices, int partitionSetId, int subsetIndex, bool signed)
		{
			Span<ColorRgbFloat> span = stackalloc ColorRgbFloat[8];
			GeneratePalette(span, unQuantizedEp0, unQuantizedEp1, 3, signed);
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			float num = 0f;
			for (int i = 0; i < asSpan.Length; i++)
			{
				if (Bc6Block.Subsets2PartitionTable[partitionSetId][i] == subsetIndex)
				{
					indices[i] = (byte)FindClosestColorIndex(asSpan[i], span, out var bestError);
					num += bestError;
				}
			}
			return num;
		}

		public static void SwapIndicesIfNecessary1Sub(RawBlock4X4RgbFloat block, ref (int, int, int) unQuantizedEp0, ref (int, int, int) unQuantizedEp1, Span<byte> indices, bool signed)
		{
			if ((indices[0] & 8) != 0)
			{
				InternalUtils.Swap(ref unQuantizedEp0, ref unQuantizedEp1);
				FindOptimalIndicesInt1Sub(block, unQuantizedEp0, unQuantizedEp1, indices, signed);
			}
		}

		public static void SwapIndicesIfNecessary2Sub(RawBlock4X4RgbFloat block, ref (int, int, int) unQuantizedEp0, ref (int, int, int) unQuantizedEp1, Span<byte> indices, int partitionSetId, int subsetIndex, bool signed)
		{
			int index = ((subsetIndex != 0) ? Bc6Block.Subsets2AnchorIndices[partitionSetId] : 0);
			if ((indices[index] & 4) != 0)
			{
				InternalUtils.Swap(ref unQuantizedEp0, ref unQuantizedEp1);
				FindOptimalIndicesInt2Sub(block, unQuantizedEp0, unQuantizedEp1, indices, partitionSetId, subsetIndex, signed);
			}
		}

		public static void GetInitialUnscaledEndpointsForSubset(RawBlock4X4RgbFloat block, out ColorRgbFloat ep0, out ColorRgbFloat ep1, int partitionSetId, int subsetIndex)
		{
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			int num = 0;
			for (int i = 0; i < 16; i++)
			{
				if (Bc6Block.Subsets2PartitionTable[partitionSetId][i] == subsetIndex)
				{
					num++;
				}
			}
			Span<ColorRgbFloat> colors = stackalloc ColorRgbFloat[num];
			int num2 = 0;
			for (int j = 0; j < 16; j++)
			{
				if (Bc6Block.Subsets2PartitionTable[partitionSetId][j] == subsetIndex)
				{
					colors[num2++] = asSpan[j];
				}
			}
			PcaVectors.Create(colors, out var mean, out var principalAxis);
			PcaVectors.GetExtremePoints(colors, mean, principalAxis, out var min, out var max);
			ep0 = new ColorRgbFloat(min);
			ep1 = new ColorRgbFloat(max);
		}

		public static void GetInitialUnscaledEndpoints(RawBlock4X4RgbFloat block, out ColorRgbFloat ep0, out ColorRgbFloat ep1)
		{
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			PcaVectors.Create(asSpan, out var mean, out var principalAxis);
			PcaVectors.GetExtremePoints(asSpan, mean, principalAxis, out var min, out var max);
			ep0 = new ColorRgbFloat(min);
			ep1 = new ColorRgbFloat(max);
		}
	}
}
