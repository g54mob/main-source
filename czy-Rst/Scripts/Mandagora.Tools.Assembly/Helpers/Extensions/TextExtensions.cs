using UnityEngine;
using UnityEngine.UI;

namespace Helpers.Extensions
{
	public static class TextExtensions
	{
		public static void SetAlpha(this Text text, Color color)
		{
			Color color2 = text.color;
			color2.a = color.a;
			text.color = color2;
		}
	}
}
