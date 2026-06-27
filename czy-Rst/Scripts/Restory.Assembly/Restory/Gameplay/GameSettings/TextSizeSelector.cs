using UnityEngine;

namespace Restory.Gameplay.GameSettings
{
	public static class TextSizeSelector
	{
		private static Vector2 minimalResolution = new Vector2(1280f, 800f);

		private static float minimalScreenSize = 10f;

		public static TextSize DetectRecommendedSize()
		{
			if (Screen.dpi == 0f)
			{
				return ResolutionBased();
			}
			return DpiBased(Screen.dpi);
		}

		private static TextSize DpiBased(float dpi)
		{
			float width = Screen.width;
			float height = Screen.height;
			float num = CalculateScreenSizeInches(width, height, dpi);
			TextSize result = TextSize.Default;
			if (num <= minimalScreenSize)
			{
				result = TextSize.Large;
			}
			return result;
		}

		private static float CalculateScreenSizeInches(float width, float height, float dpi)
		{
			return Mathf.Sqrt(Mathf.Pow(width, 2f) + Mathf.Pow(height, 2f)) / dpi;
		}

		private static TextSize ResolutionBased()
		{
			float num = Screen.width;
			float num2 = Screen.height;
			TextSize result = TextSize.Default;
			if (num <= minimalResolution.x && num2 <= minimalResolution.y)
			{
				result = TextSize.Large;
			}
			return result;
		}
	}
}
