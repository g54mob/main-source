using System;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class RectExtensions
	{
		public static void SplitFromLeft(this Rect rect, float separation, out Rect outLeftRect, out Rect outRightRect, float padding = 0f)
		{
			Rect rect2 = rect;
			Rect rect3 = rect;
			separation = Mathf.InverseLerp(0f, rect.width, separation);
			float num = Mathf.InverseLerp(0f, rect.width, padding);
			rect2.width *= separation;
			rect3.width *= 1f - separation - num;
			rect3.x += rect2.width + padding;
			outLeftRect = rect2;
			outRightRect = rect3;
		}

		public static void SplitFromRight(this Rect rect, float separation, out Rect outLeftRect, out Rect outRightRect, float padding = 0f)
		{
			Rect rect2 = rect;
			Rect rect3 = rect;
			separation = Mathf.InverseLerp(0f, rect.width, separation);
			float num = Mathf.InverseLerp(0f, rect.width, padding);
			rect2.width *= 1f - separation - num;
			rect3.width *= separation;
			rect3.x += rect2.width + padding;
			outLeftRect = rect2;
			outRightRect = rect3;
		}

		public static void SplitFromTop(this Rect rect, float separation, out Rect outTopRect, out Rect outBottomRect, float padding = 0f)
		{
			Rect rect2 = rect;
			Rect rect3 = rect;
			separation = Mathf.InverseLerp(0f, rect.height, separation);
			float num = Mathf.InverseLerp(0f, rect.height, padding);
			rect2.height *= separation;
			rect3.height *= 1f - separation - num;
			rect3.y += rect2.height + padding;
			outTopRect = rect2;
			outBottomRect = rect3;
		}

		public static void SplitFromBottom(this Rect rect, float separation, out Rect outTopRect, out Rect outBottomRect, float padding = 0f)
		{
			Rect rect2 = rect;
			Rect rect3 = rect;
			separation = Mathf.InverseLerp(0f, rect.height, separation);
			float num = Mathf.InverseLerp(0f, rect.height, padding);
			rect2.height *= 1f - separation - num;
			rect3.height *= separation;
			rect3.y += rect2.height + padding;
			outTopRect = rect2;
			outBottomRect = rect3;
		}

		public static Rect AdaptToImage(this Rect rect, Texture image)
		{
			float num = image.width;
			float num2 = image.height;
			float width = rect.width;
			float height = rect.height;
			rect.width = num;
			rect.height = num2;
			float num3 = num - width;
			float num4 = num2 - height;
			rect.x -= num3 * 0.5f;
			rect.y -= num4 * 0.5f;
			return rect;
		}

		public static Rect Pad(this Rect rect, float padding)
		{
			return rect.PadX(padding).PadY(padding);
		}

		public static Rect PadY(this Rect rect, float padding)
		{
			Rect rect2 = rect;
			rect.height = Math.Max(0f, rect.height - padding * 2f);
			padding = Math.Abs(Math.Min(padding, (rect.height - rect2.height) * 0.5f));
			rect.position = new Vector2(rect.position.x, rect.position.y + padding);
			return rect;
		}

		public static Rect PadX(this Rect rect, float padding)
		{
			Rect rect2 = rect;
			rect.width = Math.Max(0f, rect.width - padding * 2f);
			padding = Math.Abs(Math.Min(padding, (rect.width - rect2.width) * 0.5f));
			rect.position = new Vector2(rect.position.x + padding, rect.position.y);
			return rect;
		}

		public static Rect PanX(this Rect rect, float panning)
		{
			rect.position = new Vector2(rect.position.x + panning, rect.position.y);
			return rect;
		}

		public static Rect PanY(this Rect rect, float panning)
		{
			rect.position = new Vector2(rect.position.x, rect.position.y + panning);
			return rect;
		}
	}
}
