using UnityEngine;
using UnityEngine.UI;

namespace MyBox
{
	public static class MyColor
	{
		private const float LightOffset = 0.0625f;

		public static Color RandomBright => default(Color);

		public static Color RandomDim => default(Color);

		public static Color RandomColor => default(Color);

		public static Color WithAlphaSetTo(this Color color, float a)
		{
			return default(Color);
		}

		public static void SetAlpha(this Graphic graphic, float a)
		{
		}

		public static void SetAlpha(this SpriteRenderer renderer, float a)
		{
		}

		public static string ToHex(this Color color)
		{
			return null;
		}

		public static Color Lighter(this Color color)
		{
			return default(Color);
		}

		public static Color Darker(this Color color)
		{
			return default(Color);
		}

		public static Color BrightnessOffset(this Color color, float offset)
		{
			return default(Color);
		}

		public static Color ToUnityColor(this string source)
		{
			return default(Color);
		}
	}
}
