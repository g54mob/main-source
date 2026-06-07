using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	public static class RectUtils
	{
		internal static bool ApproximateEqual01(Rect a, Rect b)
		{
			return false;
		}

		private static bool QuickApproximate01(float a, float b)
		{
			return false;
		}

		public static Rect Intersect(Rect a, Rect b)
		{
			return default(Rect);
		}

		public static Rect Crop(Rect src, Rect cropRegion)
		{
			return default(Rect);
		}

		public static Vector4 ToMinMaxVector(Rect rect)
		{
			return default(Vector4);
		}

		public static Vector4 ToVector4(Rect rect)
		{
			return default(Vector4);
		}

		public static Rect Expand(Rect rect, Vector2 padding)
		{
			return default(Rect);
		}
	}
}
