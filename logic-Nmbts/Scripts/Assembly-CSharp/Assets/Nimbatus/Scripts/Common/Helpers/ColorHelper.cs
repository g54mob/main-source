using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class ColorHelper
	{
		public static Color BlackAlpha0 = new Color(0f, 0f, 0f, 0f);

		public static Color ColorFromHSV(float h, float s, float v, float a = 1f)
		{
			if (s == 0f)
			{
				return new Color(v, v, v, a);
			}
			float num = h / 60f;
			int num2 = (int)num;
			float num3 = num - (float)num2;
			float num4 = v * (1f - s);
			float num5 = v * (1f - s * num3);
			float num6 = v * (1f - s * (1f - num3));
			Color result = new Color(0f, 0f, 0f, a);
			switch (num2)
			{
			case 0:
				result.r = v;
				result.g = num6;
				result.b = num4;
				break;
			case 1:
				result.r = num5;
				result.g = v;
				result.b = num4;
				break;
			case 2:
				result.r = num4;
				result.g = v;
				result.b = num6;
				break;
			case 3:
				result.r = num4;
				result.g = num5;
				result.b = v;
				break;
			case 4:
				result.r = num6;
				result.g = num4;
				result.b = v;
				break;
			default:
				result.r = v;
				result.g = num4;
				result.b = num5;
				break;
			}
			return result;
		}

		public static void ColorToHSV(Color color, out float h, out float s, out float v)
		{
			float num = Mathf.Min(Mathf.Min(color.r, color.g), color.b);
			float num2 = Mathf.Max(Mathf.Max(color.r, color.g), color.b);
			float num3 = num2 - num;
			v = num2;
			if (!Mathf.Approximately(num2, 0f))
			{
				s = num3 / num2;
				if (Mathf.Approximately(num, num2))
				{
					v = num2;
					s = 0f;
					h = -1f;
					return;
				}
				if (color.r == num2)
				{
					h = (color.g - color.b) / num3;
				}
				else if (color.g == num2)
				{
					h = 2f + (color.b - color.r) / num3;
				}
				else
				{
					h = 4f + (color.r - color.g) / num3;
				}
				h *= 60f;
				if (h < 0f)
				{
					h += 360f;
				}
			}
			else
			{
				s = 0f;
				h = -1f;
			}
		}

		public static float ConvertToGamma(float x)
		{
			float num = 0.055f;
			if (!(x <= 0.0031308f))
			{
				return (1f + num) * Mathf.Pow(x, 5f / 12f) - num;
			}
			return x * 12.92f;
		}

		public static float ConvertToLinear(float x)
		{
			float num = 0.055f;
			if (!(x <= 0.04045f))
			{
				return Mathf.Pow((x + num) * (1f / (1f + num)), 2.4f);
			}
			return x * 0.07739938f;
		}
	}
}
