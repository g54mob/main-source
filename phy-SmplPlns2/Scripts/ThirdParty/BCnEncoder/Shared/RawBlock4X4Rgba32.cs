using System;
using System.Runtime.InteropServices;

namespace BCnEncoder.Shared
{
	public struct RawBlock4X4Rgba32
	{
		public ColorRgba32 p00;

		public ColorRgba32 p10;

		public ColorRgba32 p20;

		public ColorRgba32 p30;

		public ColorRgba32 p01;

		public ColorRgba32 p11;

		public ColorRgba32 p21;

		public ColorRgba32 p31;

		public ColorRgba32 p02;

		public ColorRgba32 p12;

		public ColorRgba32 p22;

		public ColorRgba32 p32;

		public ColorRgba32 p03;

		public ColorRgba32 p13;

		public ColorRgba32 p23;

		public ColorRgba32 p33;

		public Span<ColorRgba32> AsSpan => MemoryMarshal.CreateSpan(ref p00, 16);

		public ColorRgba32 this[int x, int y]
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

		public ColorRgba32 this[int index]
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

		public RawBlock4X4Rgba32(ColorRgba32 fillColor)
		{
			p00 = (p01 = (p02 = (p03 = (p10 = (p11 = (p12 = (p13 = (p20 = (p21 = (p22 = (p23 = (p30 = (p31 = (p32 = (p33 = fillColor)))))))))))))));
		}

		internal int CalculateError(RawBlock4X4Rgba32 other, bool useAlpha = false)
		{
			float num = 0f;
			Span<ColorRgba32> asSpan = AsSpan;
			Span<ColorRgba32> asSpan2 = other.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				ColorRgba32 colorRgba = asSpan[i];
				ColorRgba32 colorRgba2 = asSpan2[i];
				int num2 = colorRgba.r - colorRgba2.r;
				int num3 = colorRgba.g - colorRgba2.g;
				int num4 = colorRgba.b - colorRgba2.b;
				num += (float)(num2 * num2);
				num += (float)(num3 * num3);
				num += (float)(num4 * num4);
				if (useAlpha)
				{
					int num5 = colorRgba.a - colorRgba2.a;
					num += (float)(num5 * num5 * 4);
				}
			}
			num /= (float)asSpan.Length;
			num = MathF.Sqrt(num);
			return (int)num;
		}

		internal float CalculateYCbCrError(RawBlock4X4Rgba32 other)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			Span<ColorRgba32> asSpan = AsSpan;
			Span<ColorRgba32> asSpan2 = other.AsSpan;
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

		internal float CalculateYCbCrAlphaError(RawBlock4X4Rgba32 other, float yMultiplier = 2f, float alphaMultiplier = 1f)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			Span<ColorRgba32> asSpan = AsSpan;
			Span<ColorRgba32> asSpan2 = other.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				ColorYCbCrAlpha colorYCbCrAlpha = new ColorYCbCrAlpha(asSpan[i]);
				ColorYCbCrAlpha colorYCbCrAlpha2 = new ColorYCbCrAlpha(asSpan2[i]);
				float num5 = (colorYCbCrAlpha.y - colorYCbCrAlpha2.y) * yMultiplier;
				float num6 = colorYCbCrAlpha.cb - colorYCbCrAlpha2.cb;
				float num7 = colorYCbCrAlpha.cr - colorYCbCrAlpha2.cr;
				float num8 = (colorYCbCrAlpha.alpha - colorYCbCrAlpha2.alpha) * alphaMultiplier;
				num += num5 * num5;
				num2 += num6 * num6;
				num3 += num7 * num7;
				num4 += num8 * num8;
			}
			return num + num2 + num3 + num4;
		}

		internal RawBlock4X4Ycbcr ToRawBlockYcbcr()
		{
			RawBlock4X4Ycbcr result = default(RawBlock4X4Ycbcr);
			Span<ColorRgba32> asSpan = AsSpan;
			Span<ColorYCbCr> asSpan2 = result.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				asSpan2[i] = new ColorYCbCr(asSpan[i]);
			}
			return result;
		}

		public bool HasTransparentPixels()
		{
			Span<ColorRgba32> asSpan = AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				if (asSpan[i].a < byte.MaxValue)
				{
					return true;
				}
			}
			return false;
		}
	}
}
