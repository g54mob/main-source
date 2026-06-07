using UnityEngine;

namespace Lexone.UnityTwitchChat
{
	public static class ChatColors
	{
		public static string[] defaultNameColors = new string[15]
		{
			"#FF0000", "#00FF00", "#0000FF", "#B22222", "#FF7F50", "#9ACD32", "#FF4500", "#2E8B57", "#DAA520", "#D2691E",
			"#5F9EA0", "#1E90FF", "#FF69B4", "#8A2BE2", "#00FF7F"
		};

		public static float grayscaleLow = 0.3f;

		public static float grayscaleHigh = 1f;

		public static string GetRandomNameColor(int sessionRandom, string login)
		{
			int num = sessionRandom + login[0] + login[login.Length - 1];
			return defaultNameColors[num % defaultNameColors.Length];
		}

		public static Color NormalizeColor(Color color)
		{
			if (color.grayscale < grayscaleLow)
			{
				float num = grayscaleLow - color.grayscale;
				return new Color(color.r + num, color.g + num, color.b + num);
			}
			if (color.grayscale > grayscaleHigh)
			{
				float num2 = grayscaleHigh - color.grayscale;
				return new Color(color.r + num2, color.g + num2, color.b + num2);
			}
			return color;
		}
	}
}
