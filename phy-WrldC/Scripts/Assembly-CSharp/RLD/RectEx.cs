using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class RectEx
	{
		public static List<Vector2> GetCornerPoints(this Rect rect)
		{
			return new List<Vector2>
			{
				new Vector2(rect.xMin, rect.yMax),
				new Vector2(rect.xMax, rect.yMax),
				new Vector2(rect.xMax, rect.yMin),
				new Vector2(rect.xMin, rect.yMin)
			};
		}

		public static Rect PlaceBelowCenterHrz(this Rect rect, Rect other)
		{
			float x = other.center.x;
			float y = other.center.y - other.size.y * 0.5f - rect.size.y * 0.5f;
			return FromCenterAndSize(new Vector2(x, y), rect.size);
		}

		public static Rect InvertScreenY(this Rect rect)
		{
			Vector2 center = rect.center;
			center.y = (float)(Screen.height - 1) - center.y;
			return FromCenterAndSize(center, rect.size);
		}

		public static Rect FromCenterAndSize(Vector2 center, Vector2 size)
		{
			return new Rect(center.x - size.x * 0.5f, center.y - size.y * 0.5f, size.x, size.y);
		}

		public static Rect FromPoints(IEnumerable<Vector2> points)
		{
			Rect result = default(Rect);
			Vector2 rhs = Vector2Ex.FromValue(float.MaxValue);
			Vector2 rhs2 = Vector2Ex.FromValue(float.MinValue);
			foreach (Vector2 point in points)
			{
				rhs = Vector2.Min(point, rhs);
				rhs2 = Vector2.Max(point, rhs2);
			}
			result.xMin = rhs.x;
			result.yMin = rhs.y;
			result.xMax = rhs2.x;
			result.yMax = rhs2.y;
			return result;
		}

		public static Rect FromTexture2D(Texture2D texture2D)
		{
			return new Rect(0f, 0f, texture2D.width, texture2D.height);
		}

		public static Rect Inflate(this Rect rect, float inflateAmount)
		{
			float x = ((rect.size.x >= 0f) ? (rect.size.x + inflateAmount) : (rect.size.x - inflateAmount));
			float y = ((rect.size.y >= 0f) ? (rect.size.y + inflateAmount) : (rect.size.y - inflateAmount));
			return FromCenterAndSize(rect.center, new Vector2(x, y));
		}

		public static bool ContainsAllPoints(this Rect rect, IEnumerable<Vector2> points)
		{
			foreach (Vector2 point in points)
			{
				if (!rect.Contains(point, allowInverse: true))
				{
					return false;
				}
			}
			return true;
		}
	}
}
