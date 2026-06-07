using UnityEngine;

namespace Doozy.Engine.Extensions
{
	public static class ColorExtensions
	{
		private const float LIGHT_OFFSET = 0.0625f;

		private const float DARKER_FACTOR = 0.9f;

		public static Color FromHex(this Color color, string hexValue, float alpha = 1f)
		{
			return default(Color);
		}

		public static Color ColorFrom256(this Color color, float r, float g, float b, float a = 255f)
		{
			return default(Color);
		}

		public static Color ColorFrom256(float r, float g, float b, float a = 255f)
		{
			return default(Color);
		}

		public static Color Lighter(this Color color)
		{
			return default(Color);
		}

		public static Color Darker(this Color color)
		{
			return default(Color);
		}

		public static float Brightness(this Color color)
		{
			return 0f;
		}

		public static Color WithBrightness(this Color color, float brightness)
		{
			return default(Color);
		}

		public static bool IsApproximatelyBlack(this Color color)
		{
			return false;
		}

		public static bool IsApproximatelyWhite(this Color color)
		{
			return false;
		}

		public static Color Opaque(this Color color)
		{
			return default(Color);
		}

		public static Color Invert(this Color color)
		{
			return default(Color);
		}

		public static Color WithAlpha(this Color color, float alpha)
		{
			return default(Color);
		}
	}
}
