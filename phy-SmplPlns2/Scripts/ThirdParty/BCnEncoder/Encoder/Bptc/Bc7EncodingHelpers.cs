using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc7EncodingHelpers
	{
		private static readonly int[] varPatternRAlpha = new int[10] { 1, -1, 1, 0, 0, -1, 0, 0, 0, 0 };

		private static readonly int[] varPatternRNoAlpha = new int[8] { 1, -1, 1, 0, 0, -1, 0, 0 };

		private static readonly int[] varPatternGAlpha = new int[10] { 1, -1, 0, 1, 0, 0, -1, 0, 0, 0 };

		private static readonly int[] varPatternGNoAlpha = new int[8] { 1, -1, 0, 1, 0, 0, -1, 0 };

		private static readonly int[] varPatternBAlpha = new int[10] { 1, -1, 0, 0, 1, 0, 0, -1, 0, 0 };

		private static readonly int[] varPatternBNoAlpha = new int[8] { 1, -1, 0, 0, 1, 0, 0, -1 };

		private static readonly int[] varPatternAAlpha = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 1, -1 };

		private static readonly int[] varPatternANoAlpha = new int[8];

		public static bool TypeHasPBits(Bc7BlockType type)
		{
			return type switch
			{
				Bc7BlockType.Type0 => true, 
				Bc7BlockType.Type1 => true, 
				Bc7BlockType.Type3 => true, 
				Bc7BlockType.Type6 => true, 
				Bc7BlockType.Type7 => true, 
				_ => false, 
			};
		}

		public static bool TypeHasSharedPBits(Bc7BlockType type)
		{
			if (type == Bc7BlockType.Type1)
			{
				return true;
			}
			return false;
		}

		public static int GetColorComponentPrecisionWithPBit(Bc7BlockType type)
		{
			return type switch
			{
				Bc7BlockType.Type0 => 5, 
				Bc7BlockType.Type1 => 7, 
				Bc7BlockType.Type2 => 5, 
				Bc7BlockType.Type3 => 8, 
				Bc7BlockType.Type4 => 5, 
				Bc7BlockType.Type5 => 7, 
				Bc7BlockType.Type6 => 8, 
				Bc7BlockType.Type7 => 6, 
				_ => 0, 
			};
		}

		public static int GetAlphaComponentPrecisionWithPBit(Bc7BlockType type)
		{
			return type switch
			{
				Bc7BlockType.Type4 => 6, 
				Bc7BlockType.Type5 => 8, 
				Bc7BlockType.Type6 => 8, 
				Bc7BlockType.Type7 => 6, 
				_ => 0, 
			};
		}

		public static int GetColorComponentPrecision(Bc7BlockType type)
		{
			return type switch
			{
				Bc7BlockType.Type0 => 4, 
				Bc7BlockType.Type1 => 6, 
				Bc7BlockType.Type2 => 5, 
				Bc7BlockType.Type3 => 7, 
				Bc7BlockType.Type4 => 5, 
				Bc7BlockType.Type5 => 7, 
				Bc7BlockType.Type6 => 7, 
				Bc7BlockType.Type7 => 5, 
				_ => 0, 
			};
		}

		public static int GetAlphaComponentPrecision(Bc7BlockType type)
		{
			return type switch
			{
				Bc7BlockType.Type4 => 6, 
				Bc7BlockType.Type5 => 8, 
				Bc7BlockType.Type6 => 7, 
				Bc7BlockType.Type7 => 5, 
				_ => 0, 
			};
		}

		public static int GetColorIndexBitCount(Bc7BlockType type, int type4IdxMode = 0)
		{
			switch (type)
			{
			case Bc7BlockType.Type0:
				return 3;
			case Bc7BlockType.Type1:
				return 3;
			case Bc7BlockType.Type2:
				return 2;
			case Bc7BlockType.Type3:
				return 2;
			case Bc7BlockType.Type4:
				switch (type4IdxMode)
				{
				case 0:
					return 2;
				case 1:
					return 3;
				}
				break;
			case Bc7BlockType.Type5:
				return 2;
			case Bc7BlockType.Type6:
				return 4;
			case Bc7BlockType.Type7:
				return 2;
			}
			return 0;
		}

		public static int GetAlphaIndexBitCount(Bc7BlockType type, int type4IdxMode = 0)
		{
			switch (type)
			{
			case Bc7BlockType.Type4:
				switch (type4IdxMode)
				{
				case 0:
					return 3;
				case 1:
					return 2;
				}
				break;
			case Bc7BlockType.Type5:
				return 2;
			case Bc7BlockType.Type6:
				return 4;
			case Bc7BlockType.Type7:
				return 2;
			}
			return 0;
		}

		public static void ExpandEndpoints(Bc7BlockType type, ColorRgba32[] endpoints, byte[] pBits)
		{
			if (type == Bc7BlockType.Type0 || type == Bc7BlockType.Type1 || type == Bc7BlockType.Type3 || type == Bc7BlockType.Type6 || type == Bc7BlockType.Type7)
			{
				for (int i = 0; i < endpoints.Length; i++)
				{
					endpoints[i] <<= 1;
				}
				if (type == Bc7BlockType.Type1)
				{
					endpoints[0] |= (int)pBits[0];
					endpoints[1] |= (int)pBits[0];
					endpoints[2] |= (int)pBits[1];
					endpoints[3] |= (int)pBits[1];
				}
				else
				{
					for (int j = 0; j < endpoints.Length; j++)
					{
						endpoints[j] |= (int)pBits[j];
					}
				}
			}
			int colorComponentPrecisionWithPBit = GetColorComponentPrecisionWithPBit(type);
			int alphaComponentPrecisionWithPBit = GetAlphaComponentPrecisionWithPBit(type);
			for (int k = 0; k < endpoints.Length; k++)
			{
				endpoints[k].r = (byte)(endpoints[k].r << 8 - colorComponentPrecisionWithPBit);
				endpoints[k].g = (byte)(endpoints[k].g << 8 - colorComponentPrecisionWithPBit);
				endpoints[k].b = (byte)(endpoints[k].b << 8 - colorComponentPrecisionWithPBit);
				endpoints[k].a = (byte)(endpoints[k].a << 8 - alphaComponentPrecisionWithPBit);
				endpoints[k].r = (byte)(endpoints[k].r | (endpoints[k].r >> colorComponentPrecisionWithPBit));
				endpoints[k].g = (byte)(endpoints[k].g | (endpoints[k].g >> colorComponentPrecisionWithPBit));
				endpoints[k].b = (byte)(endpoints[k].b | (endpoints[k].b >> colorComponentPrecisionWithPBit));
				endpoints[k].a = (byte)(endpoints[k].a | (endpoints[k].a >> alphaComponentPrecisionWithPBit));
			}
			if (type == Bc7BlockType.Type0 || type == Bc7BlockType.Type1 || type == Bc7BlockType.Type2 || type == Bc7BlockType.Type3)
			{
				for (int l = 0; l < endpoints.Length; l++)
				{
					endpoints[l].a = byte.MaxValue;
				}
			}
		}

		public static ColorRgba32 ExpandEndpoint(Bc7BlockType type, ColorRgba32 endpoint, byte pBit)
		{
			if (type == Bc7BlockType.Type0 || type == Bc7BlockType.Type1 || type == Bc7BlockType.Type3 || type == Bc7BlockType.Type6 || type == Bc7BlockType.Type7)
			{
				endpoint <<= 1;
				endpoint |= (int)pBit;
			}
			int colorComponentPrecisionWithPBit = GetColorComponentPrecisionWithPBit(type);
			int alphaComponentPrecisionWithPBit = GetAlphaComponentPrecisionWithPBit(type);
			endpoint.r = (byte)(endpoint.r << 8 - colorComponentPrecisionWithPBit);
			endpoint.g = (byte)(endpoint.g << 8 - colorComponentPrecisionWithPBit);
			endpoint.b = (byte)(endpoint.b << 8 - colorComponentPrecisionWithPBit);
			endpoint.a = (byte)(endpoint.a << 8 - alphaComponentPrecisionWithPBit);
			endpoint.r = (byte)(endpoint.r | (endpoint.r >> colorComponentPrecisionWithPBit));
			endpoint.g = (byte)(endpoint.g | (endpoint.g >> colorComponentPrecisionWithPBit));
			endpoint.b = (byte)(endpoint.b | (endpoint.b >> colorComponentPrecisionWithPBit));
			endpoint.a = (byte)(endpoint.a | (endpoint.a >> alphaComponentPrecisionWithPBit));
			if (type == Bc7BlockType.Type0 || type == Bc7BlockType.Type1 || type == Bc7BlockType.Type2 || type == Bc7BlockType.Type3)
			{
				endpoint.a = byte.MaxValue;
			}
			return endpoint;
		}

		public static void GetInitialUnscaledEndpoints(RawBlock4X4Rgba32 block, out ColorRgba32 ep0, out ColorRgba32 ep1)
		{
			PcaVectors.CreateWithAlpha(block.AsSpan, out var mean, out var principalAxis);
			PcaVectors.GetExtremePointsWithAlpha(block.AsSpan, mean, principalAxis, out var min, out var max);
			ep0 = new ColorRgba32((byte)(min.X * 255f), (byte)(min.Y * 255f), (byte)(min.Z * 255f), (byte)(min.W * 255f));
			ep1 = new ColorRgba32((byte)(max.X * 255f), (byte)(max.Y * 255f), (byte)(max.Z * 255f), (byte)(max.W * 255f));
		}

		public static void GetInitialUnscaledEndpointsForSubset(RawBlock4X4Rgba32 block, out ColorRgba32 ep0, out ColorRgba32 ep1, ReadOnlySpan<int> partitionTable, int subsetIndex)
		{
			Span<ColorRgba32> asSpan = block.AsSpan;
			int num = 0;
			for (int i = 0; i < 16; i++)
			{
				if (partitionTable[i] == subsetIndex)
				{
					num++;
				}
			}
			Span<ColorRgba32> colors = stackalloc ColorRgba32[num];
			int num2 = 0;
			for (int j = 0; j < 16; j++)
			{
				if (partitionTable[j] == subsetIndex)
				{
					colors[num2++] = asSpan[j];
				}
			}
			PcaVectors.CreateWithAlpha(colors, out var mean, out var principalAxis);
			PcaVectors.GetExtremePointsWithAlpha(block.AsSpan, mean, principalAxis, out var min, out var max);
			ep0 = new ColorRgba32((byte)(min.X * 255f), (byte)(min.Y * 255f), (byte)(min.Z * 255f), (byte)(min.W * 255f));
			ep1 = new ColorRgba32((byte)(max.X * 255f), (byte)(max.Y * 255f), (byte)(max.Z * 255f), (byte)(max.W * 255f));
		}

		public static ColorRgba32 ScaleDownEndpoint(ColorRgba32 endpoint, Bc7BlockType type, bool ignoreAlpha, out byte pBit)
		{
			int colorComponentPrecisionWithPBit = GetColorComponentPrecisionWithPBit(type);
			int alphaComponentPrecisionWithPBit = GetAlphaComponentPrecisionWithPBit(type);
			byte b = (byte)(endpoint.r >> 8 - colorComponentPrecisionWithPBit);
			byte b2 = (byte)(endpoint.g >> 8 - colorComponentPrecisionWithPBit);
			byte b3 = (byte)(endpoint.b >> 8 - colorComponentPrecisionWithPBit);
			byte b4 = (byte)(endpoint.a >> 8 - alphaComponentPrecisionWithPBit);
			if (TypeHasPBits(type))
			{
				int num = (1 << 8 - colorComponentPrecisionWithPBit + 1) - 1;
				if ((0f + (float)(endpoint.r & num) + (float)(endpoint.g & num) + (float)(endpoint.b & num)) / 3f >= (float)num / 2f)
				{
					pBit = 1;
				}
				else
				{
					pBit = 0;
				}
				b >>= 1;
				b2 >>= 1;
				b3 >>= 1;
				b4 >>= 1;
			}
			else
			{
				pBit = 0;
			}
			if (ignoreAlpha)
			{
				return new ColorRgba32(b, b2, b3, 0);
			}
			return new ColorRgba32(b, b2, b3, b4);
		}

		public static ColorRgba32 InterpolateColor(ColorRgba32 endPointStart, ColorRgba32 endPointEnd, int colorIndex, int alphaIndex, int colorBitCount, int alphaBitCount)
		{
			return new ColorRgba32(BptcEncodingHelpers.InterpolateByte(endPointStart.r, endPointEnd.r, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateByte(endPointStart.g, endPointEnd.g, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateByte(endPointStart.b, endPointEnd.b, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateByte(endPointStart.a, endPointEnd.a, alphaIndex, alphaBitCount));
		}

		public static void ClampEndpoint(ref ColorRgba32 endpoint, byte colorMax, byte alphaMax)
		{
			if (endpoint.r > colorMax)
			{
				endpoint.r = colorMax;
			}
			if (endpoint.g > colorMax)
			{
				endpoint.g = colorMax;
			}
			if (endpoint.b > colorMax)
			{
				endpoint.b = colorMax;
			}
			if (endpoint.a > alphaMax)
			{
				endpoint.a = alphaMax;
			}
		}

		private static int FindClosestColorIndex(ColorYCbCrAlpha color, ReadOnlySpan<ColorYCbCrAlpha> colors, out float bestError)
		{
			bestError = color.CalcDistWeighted(colors[0], 4f, 2f);
			int result = 0;
			for (int i = 1; i < colors.Length; i++)
			{
				float num = color.CalcDistWeighted(colors[i], 4f, 2f);
				if (num < bestError)
				{
					result = i;
					bestError = num;
				}
			}
			return result;
		}

		private static int FindClosestColorIndex(ColorYCbCr color, ReadOnlySpan<ColorYCbCr> colors, out float bestError)
		{
			bestError = color.CalcDistWeighted(colors[0]);
			int result = 0;
			for (int i = 1; i < colors.Length; i++)
			{
				float num = color.CalcDistWeighted(colors[i]);
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

		private static int FindClosestAlphaIndex(byte alpha, ReadOnlySpan<byte> alphas, out float bestError)
		{
			bestError = (alpha - alphas[0]) * (alpha - alphas[0]);
			int result = 0;
			for (int i = 1; i < alphas.Length; i++)
			{
				float num = (alpha - alphas[i]) * (alpha - alphas[i]);
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

		private static float TrySubsetEndpoints(Bc7BlockType type, RawBlock4X4Rgba32 raw, ColorRgba32 ep0, ColorRgba32 ep1, ReadOnlySpan<int> partitionTable, int subsetIndex, int type4IdxMode)
		{
			int colorIndexBitCount = GetColorIndexBitCount(type, type4IdxMode);
			int alphaIndexBitCount = GetAlphaIndexBitCount(type, type4IdxMode);
			if (type == Bc7BlockType.Type4 || type == Bc7BlockType.Type5)
			{
				Span<ColorYCbCr> span = stackalloc ColorYCbCr[1 << colorIndexBitCount];
				Span<byte> span2 = stackalloc byte[1 << alphaIndexBitCount];
				for (int i = 0; i < span.Length; i++)
				{
					span[i] = new ColorYCbCr(InterpolateColor(ep0, ep1, i, 0, colorIndexBitCount, 0));
				}
				for (int j = 0; j < span2.Length; j++)
				{
					span2[j] = InterpolateColor(ep0, ep1, 0, j, 0, alphaIndexBitCount).a;
				}
				Span<ColorRgba32> asSpan = raw.AsSpan;
				float num = 0f;
				for (int k = 0; k < 16; k++)
				{
					FindClosestColorIndex(new ColorYCbCr(asSpan[k]), span, out var bestError);
					FindClosestAlphaIndex(asSpan[k].a, span2, out var bestError2);
					num += bestError + bestError2;
				}
				return num / 16f;
			}
			Span<ColorYCbCrAlpha> span3 = stackalloc ColorYCbCrAlpha[1 << colorIndexBitCount];
			for (int l = 0; l < span3.Length; l++)
			{
				span3[l] = new ColorYCbCrAlpha(InterpolateColor(ep0, ep1, l, l, colorIndexBitCount, alphaIndexBitCount));
			}
			Span<ColorRgba32> asSpan2 = raw.AsSpan;
			float num2 = 0f;
			float num3 = 0f;
			for (int m = 0; m < 16; m++)
			{
				if (partitionTable[m] == subsetIndex)
				{
					FindClosestColorIndex(new ColorYCbCrAlpha(asSpan2[m]), span3, out var bestError3);
					num2 += bestError3 * bestError3;
					num3 += 1f;
				}
			}
			return num2 / num3;
		}

		public static void FillSubsetIndices(Bc7BlockType type, RawBlock4X4Rgba32 raw, ColorRgba32 ep0, ColorRgba32 ep1, ReadOnlySpan<int> partitionTable, int subsetIndex, Span<byte> indicesToFill)
		{
			int colorIndexBitCount = GetColorIndexBitCount(type);
			int alphaIndexBitCount = GetAlphaIndexBitCount(type);
			if (type == Bc7BlockType.Type4 || type == Bc7BlockType.Type5)
			{
				throw new ArgumentException();
			}
			Span<ColorYCbCrAlpha> span = stackalloc ColorYCbCrAlpha[1 << colorIndexBitCount];
			for (int i = 0; i < span.Length; i++)
			{
				span[i] = new ColorYCbCrAlpha(InterpolateColor(ep0, ep1, i, i, colorIndexBitCount, alphaIndexBitCount));
			}
			Span<ColorRgba32> asSpan = raw.AsSpan;
			for (int j = 0; j < 16; j++)
			{
				if (partitionTable[j] == subsetIndex)
				{
					float bestError;
					int num = FindClosestColorIndex(new ColorYCbCrAlpha(asSpan[j]), span, out bestError);
					indicesToFill[j] = (byte)num;
				}
			}
		}

		public static void FillAlphaColorIndices(Bc7BlockType type, RawBlock4X4Rgba32 raw, ColorRgba32 ep0, ColorRgba32 ep1, Span<byte> colorIndicesToFill, Span<byte> alphaIndicesToFill, int idxMode = 0)
		{
			int colorIndexBitCount = GetColorIndexBitCount(type, idxMode);
			int alphaIndexBitCount = GetAlphaIndexBitCount(type, idxMode);
			if (type == Bc7BlockType.Type4 || type == Bc7BlockType.Type5)
			{
				Span<ColorYCbCr> span = stackalloc ColorYCbCr[1 << colorIndexBitCount];
				Span<byte> span2 = stackalloc byte[1 << alphaIndexBitCount];
				for (int i = 0; i < span.Length; i++)
				{
					span[i] = new ColorYCbCr(InterpolateColor(ep0, ep1, i, 0, colorIndexBitCount, 0));
				}
				for (int j = 0; j < span2.Length; j++)
				{
					span2[j] = InterpolateColor(ep0, ep1, 0, j, 0, alphaIndexBitCount).a;
				}
				Span<ColorRgba32> asSpan = raw.AsSpan;
				for (int k = 0; k < 16; k++)
				{
					int num = FindClosestColorIndex(new ColorYCbCr(asSpan[k]), span, out var bestError);
					colorIndicesToFill[k] = (byte)num;
					num = FindClosestAlphaIndex(asSpan[k].a, span2, out bestError);
					alphaIndicesToFill[k] = (byte)num;
				}
				return;
			}
			throw new ArgumentException();
		}

		public static void OptimizeSubsetEndpointsWithPBit(Bc7BlockType type, RawBlock4X4Rgba32 raw, ref ColorRgba32 ep0, ref ColorRgba32 ep1, ref byte pBit0, ref byte pBit1, int variation, ReadOnlySpan<int> partitionTable, int subsetIndex, bool variatePBits, bool variateAlpha, int type4IdxMode = 0)
		{
			byte colorMax = (byte)((1 << GetColorComponentPrecision(type)) - 1);
			byte alphaMax = (byte)((1 << GetAlphaComponentPrecision(type)) - 1);
			float num = TrySubsetEndpoints(type, raw, ExpandEndpoint(type, ep0, pBit0), ExpandEndpoint(type, ep1, pBit1), partitionTable, subsetIndex, type4IdxMode);
			ReadOnlySpan<int> readOnlySpan = (variateAlpha ? varPatternRAlpha : varPatternRNoAlpha);
			ReadOnlySpan<int> readOnlySpan2 = (variateAlpha ? varPatternGAlpha : varPatternGNoAlpha);
			ReadOnlySpan<int> readOnlySpan3 = (variateAlpha ? varPatternBAlpha : varPatternBNoAlpha);
			ReadOnlySpan<int> readOnlySpan4 = (variateAlpha ? varPatternAAlpha : varPatternANoAlpha);
			while (variation > 0)
			{
				bool flag = false;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					ColorRgba32 endpoint = new ColorRgba32((byte)(ep0.r - variation * readOnlySpan[i]), (byte)(ep0.g - variation * readOnlySpan2[i]), (byte)(ep0.b - variation * readOnlySpan3[i]), (byte)(ep0.a - variation * readOnlySpan4[i]));
					ColorRgba32 endpoint2 = new ColorRgba32((byte)(ep1.r + variation * readOnlySpan[i]), (byte)(ep1.g + variation * readOnlySpan2[i]), (byte)(ep1.b + variation * readOnlySpan3[i]), (byte)(ep1.a + variation * readOnlySpan4[i]));
					ClampEndpoint(ref endpoint, colorMax, alphaMax);
					ClampEndpoint(ref endpoint2, colorMax, alphaMax);
					float num2 = TrySubsetEndpoints(type, raw, ExpandEndpoint(type, endpoint, pBit0), ExpandEndpoint(type, endpoint2, pBit1), partitionTable, subsetIndex, type4IdxMode);
					if (num2 < num)
					{
						num = num2;
						ep0 = endpoint;
						ep1 = endpoint2;
						flag = true;
					}
				}
				for (int j = 0; j < readOnlySpan.Length; j++)
				{
					ColorRgba32 endpoint3 = new ColorRgba32((byte)(ep0.r + variation * readOnlySpan[j]), (byte)(ep0.g + variation * readOnlySpan2[j]), (byte)(ep0.b + variation * readOnlySpan3[j]), (byte)(ep0.a + variation * readOnlySpan4[j]));
					ClampEndpoint(ref endpoint3, colorMax, alphaMax);
					float num3 = TrySubsetEndpoints(type, raw, ExpandEndpoint(type, endpoint3, pBit0), ExpandEndpoint(type, ep1, pBit1), partitionTable, subsetIndex, type4IdxMode);
					if (num3 < num)
					{
						num = num3;
						ep0 = endpoint3;
						flag = true;
					}
				}
				for (int k = 0; k < readOnlySpan.Length; k++)
				{
					ColorRgba32 endpoint4 = new ColorRgba32((byte)(ep1.r + variation * readOnlySpan[k]), (byte)(ep1.g + variation * readOnlySpan2[k]), (byte)(ep1.b + variation * readOnlySpan3[k]), (byte)(ep1.a + variation * readOnlySpan4[k]));
					ClampEndpoint(ref endpoint4, colorMax, alphaMax);
					float num4 = TrySubsetEndpoints(type, raw, ExpandEndpoint(type, ep0, pBit0), ExpandEndpoint(type, endpoint4, pBit1), partitionTable, subsetIndex, type4IdxMode);
					if (num4 < num)
					{
						num = num4;
						ep1 = endpoint4;
						flag = true;
					}
				}
				if (variatePBits)
				{
					byte b = ((pBit0 == 0) ? ((byte)1) : ((byte)0));
					float num5 = TrySubsetEndpoints(type, raw, ExpandEndpoint(type, ep0, b), ExpandEndpoint(type, ep1, pBit1), partitionTable, subsetIndex, type4IdxMode);
					if (num5 < num)
					{
						num = num5;
						pBit0 = b;
						flag = true;
					}
					byte b2 = ((pBit1 == 0) ? ((byte)1) : ((byte)0));
					float num6 = TrySubsetEndpoints(type, raw, ExpandEndpoint(type, ep0, pBit0), ExpandEndpoint(type, ep1, b2), partitionTable, subsetIndex, type4IdxMode);
					if (num6 < num)
					{
						num = num6;
						pBit1 = b2;
						flag = true;
					}
				}
				if (!flag)
				{
					variation--;
				}
			}
		}

		public static RawBlock4X4Rgba32 RotateBlockColors(RawBlock4X4Rgba32 block, int rotation)
		{
			if (rotation == 0)
			{
				return block;
			}
			RawBlock4X4Rgba32 result = default(RawBlock4X4Rgba32);
			Span<ColorRgba32> asSpan = block.AsSpan;
			Span<ColorRgba32> asSpan2 = result.AsSpan;
			for (int i = 0; i < 16; i++)
			{
				ColorRgba32 colorRgba = asSpan[i];
				switch (rotation)
				{
				case 1:
					asSpan2[i] = new ColorRgba32(colorRgba.a, colorRgba.g, colorRgba.b, colorRgba.r);
					break;
				case 2:
					asSpan2[i] = new ColorRgba32(colorRgba.r, colorRgba.a, colorRgba.b, colorRgba.g);
					break;
				case 3:
					asSpan2[i] = new ColorRgba32(colorRgba.r, colorRgba.g, colorRgba.a, colorRgba.b);
					break;
				}
			}
			return result;
		}
	}
}
