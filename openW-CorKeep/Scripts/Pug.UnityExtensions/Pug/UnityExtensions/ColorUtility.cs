using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class ColorUtility
	{
		private static float GammaToLinear(float value)
		{
			if (value <= 0.04045f)
			{
				return value / 12.92f;
			}
			return Mathf.Pow((value + 0.055f) / 1.055f, 2.4f);
		}

		private static float LinearToGamma(float value)
		{
			if (value <= 0.0031308f)
			{
				return 12.92f * value;
			}
			return 1.055f * Mathf.Pow(value, 5f / 12f) - 0.055f;
		}

		private static float CalculateLuminance(Color color)
		{
			return color.r * 0.299f + color.g * 0.587f + color.b * 0.114f;
		}

		public static Color32 IncreaseBrightness(Color32 color, float targetLuminance)
		{
			Color color2 = new Color(GammaToLinear((float)(int)color.r / 255f), GammaToLinear((float)(int)color.g / 255f), GammaToLinear((float)(int)color.b / 255f));
			float num = CalculateLuminance(color2);
			if (num == 0f)
			{
				float num2 = LinearToGamma(targetLuminance);
				return new Color32((byte)(num2 * 255f), (byte)(num2 * 255f), (byte)(num2 * 255f), color.a);
			}
			float num3 = targetLuminance / num;
			color2.r = Mathf.Clamp(color2.r * num3, 0f, 1f);
			color2.g = Mathf.Clamp(color2.g * num3, 0f, 1f);
			color2.b = Mathf.Clamp(color2.b * num3, 0f, 1f);
			return new Color(LinearToGamma(color2.r), LinearToGamma(color2.g), LinearToGamma(color2.b));
		}
	}
}
