using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	public static class RectUtils
	{
		internal static bool ApproximateEqual01(Rect a, Rect b)
		{
			if (QuickApproximate01(a.x, b.x) && QuickApproximate01(a.y, b.y) && QuickApproximate01(a.width, b.width))
			{
				return QuickApproximate01(a.height, b.height);
			}
			return false;
		}

		private static bool QuickApproximate01(float a, float b)
		{
			return Mathf.Abs(b - a) < 5.9604645E-08f;
		}

		public static Vector4 ToMinMaxVector(Rect rect)
		{
			return new Vector4(rect.xMin, rect.yMin, rect.xMax, rect.yMax);
		}

		public static Vector4 ToVector4(Rect rect)
		{
			return new Vector4(rect.xMin, rect.yMin, rect.width, rect.height);
		}
	}
}
