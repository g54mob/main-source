using UnityEngine;

namespace Timberborn.Localization
{
	public static class TextColors
	{
		private static readonly Color GreenHighlight = new Color(0.35f, 1f, 0.38f);

		private static readonly Color RedHighlight = new Color(1f, 0.3f, 0.3f);

		private static readonly Color YellowHighlight = new Color(1f, 1f, 0.1f);

		public static string ColorizeText(string text)
		{
			return text.Replace("<GreenHighlight>", "<color=#" + ColorUtility.ToHtmlStringRGB(GreenHighlight) + ">").Replace("</GreenHighlight>", "</color>").Replace("<RedHighlight>", "<color=#" + ColorUtility.ToHtmlStringRGB(RedHighlight) + ">")
				.Replace("</RedHighlight>", "</color>")
				.Replace("<YellowHighlight>", "<color=#" + ColorUtility.ToHtmlStringRGB(YellowHighlight) + ">")
				.Replace("</YellowHighlight>", "</color>");
		}
	}
}
