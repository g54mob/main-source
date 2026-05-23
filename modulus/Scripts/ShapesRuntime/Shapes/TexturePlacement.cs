using System;
using UnityEngine;

namespace Shapes
{
	internal static class TexturePlacement
	{
		private static readonly Rect fitUvs = new Rect(0f, 0f, 1f, 1f);

		internal static (Rect rect, Rect uvs) Fit(Texture texture, Rect rect, TextureFillMode mode)
		{
			return mode switch
			{
				TextureFillMode.StretchToFill => StretchToFill(rect), 
				TextureFillMode.ScaleToFit => ScaleToFit(texture, rect), 
				TextureFillMode.ScaleAndCropToFill => ScaleAndCropToFill(texture, rect), 
				_ => throw new ArgumentOutOfRangeException("mode", mode, null), 
			};
		}

		internal static (Rect rect, Rect uvs) Size(Texture texture, Vector2 c, float size, TextureSizeMode mode)
		{
			float num = (float)texture.width / (float)texture.height;
			switch (mode)
			{
			case TextureSizeMode.Width:
				return FitWidth(c, size, num);
			case TextureSizeMode.Height:
				return FitHeight(c, size, num);
			case TextureSizeMode.LongestSide:
				if (!(num < 1f))
				{
					return FitWidth(c, size, num);
				}
				return FitHeight(c, size, num);
			case TextureSizeMode.ShortestSide:
				if (!(num < 1f))
				{
					return FitHeight(c, size, num);
				}
				return FitWidth(c, size, num);
			case TextureSizeMode.PixelsPerMeter:
				return TexelSized(texture, c, size);
			case TextureSizeMode.Radius:
				return FitRadius(texture, c, size);
			default:
				throw new ArgumentOutOfRangeException("mode", mode, null);
			}
		}

		private static (Rect rect, Rect uvs) FitWidth(Vector2 c, float w, float aspect)
		{
			return SimpleRect(c, w, w / aspect);
		}

		private static (Rect rect, Rect uvs) FitHeight(Vector2 c, float h, float aspect)
		{
			return SimpleRect(c, h * aspect, h);
		}

		private static (Rect rect, Rect uvs) FitRadius(Texture tex, Vector2 c, float r)
		{
			Vector2 vector = new Vector2(tex.width, tex.height).normalized * (r * 2f);
			return SimpleRect(c, vector.x, vector.y);
		}

		private static (Rect rect, Rect uvs) SimpleRect(Vector2 c, float w, float h)
		{
			return (rect: RectCnt(c.x, c.y, w, h), uvs: fitUvs);
		}

		private static Rect RectCnt(float cx, float cy, float w, float h)
		{
			return new Rect(cx - w / 2f, cy - h / 2f, w, h);
		}

		private static Rect RectCnt(Vector2 c, float w, float h)
		{
			return new Rect(c.x - w / 2f, c.y - h / 2f, w, h);
		}

		private static (Rect rect, Rect uvs) StretchToFill(Rect rect)
		{
			return (rect: rect, uvs: fitUvs);
		}

		private static (Rect rect, Rect uvs) ScaleToFit(Texture texture, Rect rect)
		{
			float a = rect.width / (float)texture.width;
			float b = rect.height / (float)texture.height;
			float num = Mathf.Min(a, b);
			return (rect: RectCnt(rect.center, (float)texture.width * num, (float)texture.height * num), uvs: fitUvs);
		}

		private static (Rect rect, Rect uvs) ScaleAndCropToFill(Texture texture, Rect rect)
		{
			float num = rect.width / (float)texture.width;
			float num2 = rect.height / (float)texture.height;
			float num3 = Mathf.Max(num, num2);
			return (rect: rect, uvs: RectCnt(0.5f, 0.5f, num / num3, num2 / num3));
		}

		private static (Rect rect, Rect uvs) TexelSized(Texture texture, Vector2 center, float pixelsPerMeter)
		{
			float w = (float)texture.width / pixelsPerMeter;
			float h = (float)texture.height / pixelsPerMeter;
			return SimpleRect(center, w, h);
		}
	}
}
