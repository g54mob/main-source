using UnityEngine;

namespace MoreMountains.Tools
{
	public static class MMColorExtensions
	{
		public static float MMSum(this Color color)
		{
			return color.r + color.g + color.b + color.a;
		}

		public static float MMMeanRGB(this Color color)
		{
			return (color.r + color.g + color.b) / 3f;
		}

		public static float MMLuminance(this Color color)
		{
			return 0.2126f * color.r + 0.7152f * color.g + 0.0722f * color.b;
		}

		public static Color MMLighten(this Color color, float amount)
		{
			amount = Mathf.Clamp01(amount);
			color.r /= amount;
			color.g /= amount;
			color.b /= amount;
			return color;
		}

		public static Color MMDarken(this Color color, float amount)
		{
			amount = Mathf.Clamp01(amount);
			color.r *= 1f - amount;
			color.g *= 1f - amount;
			color.b *= 1f - amount;
			return color;
		}

		public static Color32 MMDarken(this Color32 color, float amount)
		{
			amount = 1f - Mathf.Clamp01(amount);
			color.r = (byte)((float)(int)color.r * amount);
			color.g = (byte)((float)(int)color.g * amount);
			color.b = (byte)((float)(int)color.b * amount);
			return color;
		}

		public static Color MMAlpha(this Color color, float newAlpha)
		{
			newAlpha = Mathf.Clamp01(newAlpha);
			color.a = newAlpha;
			return color;
		}
	}
}
