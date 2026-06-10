using UnityEngine;

namespace NSMedieval.Tools
{
	public static class ColorTools
	{
		public static Color GetGradientColor(float currentValue, float maxValue, Color[] colors, float endAlpha = 1f)
		{
			ColorUtility.TryParseHtmlString("#" + GetGradientHex(currentValue, maxValue, colors, endAlpha), out var color);
			return color;
		}

		public static string GetGradientHex(float currentValue, float maxValue, Color[] colors, float endAlpha = 1f)
		{
			currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
			GradientColorKey[] array = new GradientColorKey[colors.Length];
			GradientAlphaKey[] array2 = new GradientAlphaKey[colors.Length];
			Gradient gradient = new Gradient();
			int num = colors.Length;
			for (int i = 0; i < num; i++)
			{
				array[i].color = colors[i];
				array[i].time = (float)i / (float)(num - 1);
				if (endAlpha == 1f)
				{
					array2[i].alpha = 1f;
					array2[i].time = 0f;
				}
				else
				{
					array2[i].alpha = (float)i / (float)(num - 1);
					array2[i].time = (float)i / (float)(num - 1);
				}
			}
			gradient.SetKeys(array, array2);
			float num2 = currentValue / maxValue;
			if (num2 < 0f || float.IsNaN(num2))
			{
				return ColorUtility.ToHtmlStringRGB(Color.black);
			}
			return ColorUtility.ToHtmlStringRGB(gradient.Evaluate(num2));
		}

		public static string GetHexColor(float currentValue, float maxValue)
		{
			Color[] colors = new Color[3]
			{
				Color.red,
				Color.yellow,
				Color.white
			};
			return GetGradientHex(currentValue, maxValue, colors);
		}

		public static string GetHexWhiteFaded(float currentValue, float maxValue, float endAplha = 0f)
		{
			Color[] colors = new Color[2]
			{
				Color.white,
				Color.white
			};
			return GetGradientHex(currentValue, maxValue, colors, endAplha);
		}
	}
}
