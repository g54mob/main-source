using System;
using System.Runtime.InteropServices;

namespace BCnEncoder.Shared
{
	internal struct RawBlock4X4Ycbcr
	{
		public ColorYCbCr p00;

		public ColorYCbCr p10;

		public ColorYCbCr p20;

		public ColorYCbCr p30;

		public ColorYCbCr p01;

		public ColorYCbCr p11;

		public ColorYCbCr p21;

		public ColorYCbCr p31;

		public ColorYCbCr p02;

		public ColorYCbCr p12;

		public ColorYCbCr p22;

		public ColorYCbCr p32;

		public ColorYCbCr p03;

		public ColorYCbCr p13;

		public ColorYCbCr p23;

		public ColorYCbCr p33;

		public Span<ColorYCbCr> AsSpan => MemoryMarshal.CreateSpan(ref p00, 16);

		public ColorYCbCr this[int x, int y]
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

		public float CalculateError(RawBlock4X4Rgba32 other)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			Span<ColorYCbCr> asSpan = AsSpan;
			Span<ColorRgba32> asSpan2 = other.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				ColorYCbCr colorYCbCr = asSpan[i];
				ColorYCbCr colorYCbCr2 = new ColorYCbCr(asSpan2[i]);
				float num4 = colorYCbCr.y - colorYCbCr2.y;
				float num5 = colorYCbCr.cb - colorYCbCr2.cb;
				float num6 = colorYCbCr.cr - colorYCbCr2.cr;
				num += num4 * num4;
				num2 += num5 * num5;
				num3 += num6 * num6;
			}
			return num * 2f + num2 / 2f + num3 / 2f;
		}
	}
}
