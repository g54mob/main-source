using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class ImageTransitions
	{
		public static IEnumerator Alpha(Image image, float targetAlphaValue)
		{
			float incrementSize = 0.05f;
			Color color = image.color;
			while (color.a != targetAlphaValue)
			{
				color.a = ((color.a > targetAlphaValue) ? (color.a - incrementSize) : (color.a + incrementSize));
				if (color.a < 0f || color.a > 1f)
				{
					color.a = targetAlphaValue;
				}
				image.color = color;
				yield return new WaitForSecondsRealtime(0.025f);
			}
		}

		public static IEnumerator AlphaFast(Image image, float targetAlphaValue)
		{
			float incrementSize = 0.05f;
			Color color = image.color;
			while (color.a != targetAlphaValue)
			{
				color.a = ((color.a > targetAlphaValue) ? (color.a - incrementSize) : (color.a + incrementSize));
				if (color.a < 0f || color.a > 1f)
				{
					color.a = targetAlphaValue;
				}
				image.color = color;
				yield return new WaitForSecondsRealtime(0.01f);
			}
		}
	}
}
