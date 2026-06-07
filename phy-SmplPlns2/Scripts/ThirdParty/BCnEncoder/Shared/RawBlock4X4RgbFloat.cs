using System;
using System.Runtime.InteropServices;

namespace BCnEncoder.Shared
{
	public struct RawBlock4X4RgbFloat
	{
		public ColorRgbFloat p00;

		public ColorRgbFloat p10;

		public ColorRgbFloat p20;

		public ColorRgbFloat p30;

		public ColorRgbFloat p01;

		public ColorRgbFloat p11;

		public ColorRgbFloat p21;

		public ColorRgbFloat p31;

		public ColorRgbFloat p02;

		public ColorRgbFloat p12;

		public ColorRgbFloat p22;

		public ColorRgbFloat p32;

		public ColorRgbFloat p03;

		public ColorRgbFloat p13;

		public ColorRgbFloat p23;

		public ColorRgbFloat p33;

		public Span<ColorRgbFloat> AsSpan => MemoryMarshal.CreateSpan(ref p00, 16);

		public ColorRgbFloat this[int x, int y]
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

		public ColorRgbFloat this[int index]
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

		public RawBlock4X4RgbFloat(ColorRgbFloat fillColor)
		{
			p00 = (p01 = (p02 = (p03 = (p10 = (p11 = (p12 = (p13 = (p20 = (p21 = (p22 = (p23 = (p30 = (p31 = (p32 = (p33 = fillColor)))))))))))))));
		}

		internal float CalculateError(RawBlock4X4RgbFloat other)
		{
			float num = 0f;
			Span<ColorRgbFloat> asSpan = AsSpan;
			Span<ColorRgbFloat> asSpan2 = other.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				ColorRgbFloat colorRgbFloat = asSpan[i];
				ColorRgbFloat colorRgbFloat2 = asSpan2[i];
				float num2 = (float)Math.Sign(colorRgbFloat.r) * MathF.Log(1f + MathF.Abs(colorRgbFloat.r)) - (float)Math.Sign(colorRgbFloat2.r) * MathF.Log(1f + MathF.Abs(colorRgbFloat2.r));
				float num3 = (float)Math.Sign(colorRgbFloat.g) * MathF.Log(1f + MathF.Abs(colorRgbFloat.g)) - (float)Math.Sign(colorRgbFloat2.g) * MathF.Log(1f + MathF.Abs(colorRgbFloat2.g));
				float num4 = (float)Math.Sign(colorRgbFloat.b) * MathF.Log(1f + MathF.Abs(colorRgbFloat.b)) - (float)Math.Sign(colorRgbFloat2.b) * MathF.Log(1f + MathF.Abs(colorRgbFloat2.b));
				num += num2 * num2;
				num += num3 * num3;
				num += num4 * num4;
			}
			num /= (float)(asSpan.Length * 3);
			return MathF.Sqrt(num);
		}

		internal float CalculateYCbCrError(RawBlock4X4RgbFloat other)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			Span<ColorRgbFloat> asSpan = AsSpan;
			Span<ColorRgbFloat> asSpan2 = other.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				ColorYCbCr colorYCbCr = new ColorYCbCr(asSpan[i]);
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

		internal RawBlock4X4Ycbcr ToRawBlockYcbcr()
		{
			RawBlock4X4Ycbcr result = default(RawBlock4X4Ycbcr);
			Span<ColorRgbFloat> asSpan = AsSpan;
			Span<ColorYCbCr> asSpan2 = result.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				asSpan2[i] = new ColorYCbCr(asSpan[i]);
			}
			return result;
		}
	}
}
