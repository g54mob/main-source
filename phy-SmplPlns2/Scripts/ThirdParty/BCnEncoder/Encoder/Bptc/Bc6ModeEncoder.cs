using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc6ModeEncoder
	{
		public static Bc6Block EncodeBlock1Sub(Bc6BlockType type, RawBlock4X4RgbFloat block, ColorRgbFloat initialEndpoint0, ColorRgbFloat initialEndpoint1, bool signed, out bool badTransform)
		{
			int endpointBits = type.EndpointBits();
			(int, int, int) deltaBits = type.DeltaBits();
			bool flag = type.HasTransformedEndpoints();
			(int, int, int) endpoint = Bc6EncodingHelpers.PreQuantizeRawEndpoint(initialEndpoint0, signed);
			(int, int, int) endpoint2 = Bc6EncodingHelpers.PreQuantizeRawEndpoint(initialEndpoint1, signed);
			(int, int, int) tuple = Bc6EncodingHelpers.FinishQuantizeEndpoint(endpoint, endpointBits, signed);
			(int, int, int) tuple2 = Bc6EncodingHelpers.FinishQuantizeEndpoint(endpoint2, endpointBits, signed);
			if (flag)
			{
				bool badTransform2 = false;
				Bc6EncodingHelpers.CreateTransformedEndpoint(tuple, tuple2, deltaBits, ref badTransform2);
				if (badTransform2)
				{
					badTransform = true;
					return default(Bc6Block);
				}
			}
			(int, int, int) unQuantizedEp = Bc6Block.UnQuantize(tuple, endpointBits, signed);
			(int, int, int) unQuantizedEp2 = Bc6Block.UnQuantize(tuple2, endpointBits, signed);
			Span<byte> indices = stackalloc byte[16];
			Bc6EncodingHelpers.FindOptimalIndicesInt1Sub(block, unQuantizedEp, unQuantizedEp2, indices, signed);
			Bc6EncodingHelpers.SwapIndicesIfNecessary1Sub(block, ref unQuantizedEp, ref unQuantizedEp2, indices, signed);
			(int, int, int) tuple3 = Bc6EncodingHelpers.FinishQuantizeEndpoint(unQuantizedEp, endpointBits, signed);
			(int, int, int) tuple4 = Bc6EncodingHelpers.FinishQuantizeEndpoint(unQuantizedEp2, endpointBits, signed);
			badTransform = false;
			if (flag)
			{
				tuple4 = Bc6EncodingHelpers.CreateTransformedEndpoint(tuple3, tuple4, deltaBits, ref badTransform);
			}
			return type switch
			{
				Bc6BlockType.Type3 => Bc6Block.PackType3(tuple3, tuple4, indices), 
				Bc6BlockType.Type7 => Bc6Block.PackType7(tuple3, tuple4, indices), 
				Bc6BlockType.Type11 => Bc6Block.PackType11(tuple3, tuple4, indices), 
				Bc6BlockType.Type15 => Bc6Block.PackType15(tuple3, tuple4, indices), 
				_ => throw new ArgumentOutOfRangeException("type", type, null), 
			};
		}

		public static Bc6Block EncodeBlock2Sub(Bc6BlockType type, RawBlock4X4RgbFloat block, ColorRgbFloat initialEndpoint0, ColorRgbFloat initialEndpoint1, ColorRgbFloat initialEndpoint2, ColorRgbFloat initialEndpoint3, int partitionSetId, bool signed, out bool badTransform)
		{
			int endpointBits = type.EndpointBits();
			(int, int, int) deltaBits = type.DeltaBits();
			bool flag = type.HasTransformedEndpoints();
			(int, int, int) endpoint = Bc6EncodingHelpers.PreQuantizeRawEndpoint(initialEndpoint0, signed);
			(int, int, int) endpoint2 = Bc6EncodingHelpers.PreQuantizeRawEndpoint(initialEndpoint1, signed);
			(int, int, int) endpoint3 = Bc6EncodingHelpers.PreQuantizeRawEndpoint(initialEndpoint2, signed);
			(int, int, int) endpoint4 = Bc6EncodingHelpers.PreQuantizeRawEndpoint(initialEndpoint3, signed);
			(int, int, int) tuple = Bc6EncodingHelpers.FinishQuantizeEndpoint(endpoint, endpointBits, signed);
			(int, int, int) tuple2 = Bc6EncodingHelpers.FinishQuantizeEndpoint(endpoint2, endpointBits, signed);
			(int, int, int) tuple3 = Bc6EncodingHelpers.FinishQuantizeEndpoint(endpoint3, endpointBits, signed);
			(int, int, int) tuple4 = Bc6EncodingHelpers.FinishQuantizeEndpoint(endpoint4, endpointBits, signed);
			if (flag)
			{
				bool badTransform2 = false;
				Bc6EncodingHelpers.CreateTransformedEndpoint(tuple, tuple2, deltaBits, ref badTransform2);
				Bc6EncodingHelpers.CreateTransformedEndpoint(tuple, tuple3, deltaBits, ref badTransform2);
				Bc6EncodingHelpers.CreateTransformedEndpoint(tuple, tuple4, deltaBits, ref badTransform2);
				if (badTransform2)
				{
					badTransform = true;
					return default(Bc6Block);
				}
			}
			(int, int, int) unQuantizedEp = Bc6Block.UnQuantize(tuple, endpointBits, signed);
			(int, int, int) unQuantizedEp2 = Bc6Block.UnQuantize(tuple2, endpointBits, signed);
			(int, int, int) unQuantizedEp3 = Bc6Block.UnQuantize(tuple3, endpointBits, signed);
			(int, int, int) unQuantizedEp4 = Bc6Block.UnQuantize(tuple4, endpointBits, signed);
			Span<byte> indices = stackalloc byte[16];
			Bc6EncodingHelpers.FindOptimalIndicesInt2Sub(block, unQuantizedEp, unQuantizedEp2, indices, partitionSetId, 0, signed);
			Bc6EncodingHelpers.FindOptimalIndicesInt2Sub(block, unQuantizedEp3, unQuantizedEp4, indices, partitionSetId, 1, signed);
			Bc6EncodingHelpers.SwapIndicesIfNecessary2Sub(block, ref unQuantizedEp, ref unQuantizedEp2, indices, partitionSetId, 0, signed);
			Bc6EncodingHelpers.SwapIndicesIfNecessary2Sub(block, ref unQuantizedEp3, ref unQuantizedEp4, indices, partitionSetId, 1, signed);
			(int, int, int) tuple5 = Bc6EncodingHelpers.FinishQuantizeEndpoint(unQuantizedEp, endpointBits, signed);
			(int, int, int) tuple6 = Bc6EncodingHelpers.FinishQuantizeEndpoint(unQuantizedEp2, endpointBits, signed);
			(int, int, int) tuple7 = Bc6EncodingHelpers.FinishQuantizeEndpoint(unQuantizedEp3, endpointBits, signed);
			(int, int, int) tuple8 = Bc6EncodingHelpers.FinishQuantizeEndpoint(unQuantizedEp4, endpointBits, signed);
			badTransform = false;
			if (flag)
			{
				tuple6 = Bc6EncodingHelpers.CreateTransformedEndpoint(tuple5, tuple6, deltaBits, ref badTransform);
				tuple7 = Bc6EncodingHelpers.CreateTransformedEndpoint(tuple5, tuple7, deltaBits, ref badTransform);
				tuple8 = Bc6EncodingHelpers.CreateTransformedEndpoint(tuple5, tuple8, deltaBits, ref badTransform);
			}
			return type switch
			{
				Bc6BlockType.Type0 => Bc6Block.PackType0(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type1 => Bc6Block.PackType1(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type2 => Bc6Block.PackType2(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type6 => Bc6Block.PackType6(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type10 => Bc6Block.PackType10(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type14 => Bc6Block.PackType14(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type18 => Bc6Block.PackType18(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type22 => Bc6Block.PackType22(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type26 => Bc6Block.PackType26(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				Bc6BlockType.Type30 => Bc6Block.PackType30(tuple5, tuple6, tuple7, tuple8, partitionSetId, indices), 
				_ => throw new ArgumentOutOfRangeException("type", type, null), 
			};
		}
	}
}
