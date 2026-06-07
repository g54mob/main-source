using System;

namespace BCnEncoder.Shared
{
	internal struct ColorYCbCrAlpha
	{
		public float y;

		public float cb;

		public float cr;

		public float alpha;

		public ColorYCbCrAlpha(float y, float cb, float cr, float alpha)
		{
			this.y = y;
			this.cb = cb;
			this.cr = cr;
			this.alpha = alpha;
		}

		public ColorYCbCrAlpha(ColorRgb24 rgb)
		{
			float num = (float)(int)rgb.r / 255f;
			float num2 = (float)(int)rgb.g / 255f;
			float num3 = (float)(int)rgb.b / 255f;
			y = 0.2989f * num + 0.5866f * num2 + 0.1145f * num3;
			cb = -0.1687f * num - 0.3313f * num2 + 0.5f * num3;
			cr = 0.5f * num - 0.4184f * num2 - 0.0816f * num3;
			alpha = 1f;
		}

		public ColorYCbCrAlpha(ColorRgb565 rgb)
		{
			float num = (float)(int)rgb.R / 255f;
			float num2 = (float)(int)rgb.G / 255f;
			float num3 = (float)(int)rgb.B / 255f;
			y = 0.2989f * num + 0.5866f * num2 + 0.1145f * num3;
			cb = -0.1687f * num - 0.3313f * num2 + 0.5f * num3;
			cr = 0.5f * num - 0.4184f * num2 - 0.0816f * num3;
			alpha = 1f;
		}

		public ColorYCbCrAlpha(ColorRgba32 rgba)
		{
			float num = (float)(int)rgba.r / 255f;
			float num2 = (float)(int)rgba.g / 255f;
			float num3 = (float)(int)rgba.b / 255f;
			y = 0.2989f * num + 0.5866f * num2 + 0.1145f * num3;
			cb = -0.1687f * num - 0.3313f * num2 + 0.5f * num3;
			cr = 0.5f * num - 0.4184f * num2 - 0.0816f * num3;
			alpha = (float)(int)rgba.a / 255f;
		}

		public ColorYCbCrAlpha(ColorRgbaFloat rgba)
		{
			float r = rgba.r;
			float g = rgba.g;
			float b = rgba.b;
			y = 0.2989f * r + 0.5866f * g + 0.1145f * b;
			cb = -0.1687f * r - 0.3313f * g + 0.5f * b;
			cr = 0.5f * r - 0.4184f * g - 0.0816f * b;
			alpha = rgba.a;
		}

		public ColorRgb565 ToColorRgb565()
		{
			float num = Math.Max(0f, Math.Min(1f, (float)((double)y + 0.0 * (double)cb + 1.4022 * (double)cr)));
			float num2 = Math.Max(0f, Math.Min(1f, (float)((double)y - 0.3456 * (double)cb - 0.7145 * (double)cr)));
			float num3 = Math.Max(0f, Math.Min(1f, (float)((double)y + 1.771 * (double)cb + 0.0 * (double)cr)));
			return new ColorRgb565((byte)(num * 255f), (byte)(num2 * 255f), (byte)(num3 * 255f));
		}

		public override string ToString()
		{
			float num = Math.Max(0f, Math.Min(1f, (float)((double)y + 0.0 * (double)cb + 1.4022 * (double)cr)));
			float num2 = Math.Max(0f, Math.Min(1f, (float)((double)y - 0.3456 * (double)cb - 0.7145 * (double)cr)));
			float num3 = Math.Max(0f, Math.Min(1f, (float)((double)y + 1.771 * (double)cb + 0.0 * (double)cr)));
			return $"r : {num * 255f} g : {num2 * 255f} b : {num3 * 255f}";
		}

		public float CalcDistWeighted(ColorYCbCrAlpha other, float yWeight = 4f, float aWeight = 1f)
		{
			float num = (y - other.y) * (y - other.y) * yWeight;
			float num2 = (cb - other.cb) * (cb - other.cb);
			float num3 = (cr - other.cr) * (cr - other.cr);
			float num4 = (alpha - other.alpha) * (alpha - other.alpha) * aWeight;
			return MathF.Sqrt(num + num2 + num3 + num4);
		}

		public static ColorYCbCrAlpha operator +(ColorYCbCrAlpha left, ColorYCbCrAlpha right)
		{
			return new ColorYCbCrAlpha(left.y + right.y, left.cb + right.cb, left.cr + right.cr, left.alpha + right.alpha);
		}

		public static ColorYCbCrAlpha operator /(ColorYCbCrAlpha left, float right)
		{
			return new ColorYCbCrAlpha(left.y / right, left.cb / right, left.cr / right, left.alpha / right);
		}
	}
}
