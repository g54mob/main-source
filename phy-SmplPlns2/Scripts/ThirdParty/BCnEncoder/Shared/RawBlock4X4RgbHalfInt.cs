using System;
using System.Runtime.InteropServices;
using BCnEncoder.Encoder.Bptc;

namespace BCnEncoder.Shared
{
	internal struct RawBlock4X4RgbHalfInt
	{
		public (int, int, int) p00;

		public (int, int, int) p10;

		public (int, int, int) p20;

		public (int, int, int) p30;

		public (int, int, int) p01;

		public (int, int, int) p11;

		public (int, int, int) p21;

		public (int, int, int) p31;

		public (int, int, int) p02;

		public (int, int, int) p12;

		public (int, int, int) p22;

		public (int, int, int) p32;

		public (int, int, int) p03;

		public (int, int, int) p13;

		public (int, int, int) p23;

		public (int, int, int) p33;

		public Span<(int, int, int)> AsSpan => MemoryMarshal.CreateSpan(ref p00, 16);

		public (int, int, int) this[int x, int y]
		{
			get
			{
				return AsSpan[x + y * 4];
			}
			set
			{
				AsSpan[x + y * 4] = value;
			}
		}

		public (int, int, int) this[int index]
		{
			get
			{
				return AsSpan[index];
			}
			set
			{
				AsSpan[index] = value;
			}
		}

		public static RawBlock4X4RgbHalfInt FromRawFloats(RawBlock4X4RgbFloat other, bool signed)
		{
			RawBlock4X4RgbHalfInt result = default(RawBlock4X4RgbHalfInt);
			Span<(int, int, int)> asSpan = result.AsSpan;
			Span<ColorRgbFloat> asSpan2 = other.AsSpan;
			for (int i = 0; i < 16; i++)
			{
				asSpan[i] = Bc6EncodingHelpers.PreQuantizeRawEndpoint(asSpan2[i], signed);
			}
			return result;
		}
	}
}
