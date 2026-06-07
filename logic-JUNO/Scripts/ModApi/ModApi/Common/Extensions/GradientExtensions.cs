using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class GradientExtensions
	{
		public static Gradient Clone(this Gradient gradient)
		{
			Gradient gradient2 = new Gradient();
			gradient2.mode = gradient.mode;
			gradient2.SetKeys(gradient.colorKeys, gradient.alphaKeys);
			return gradient2;
		}

		public static Gradient ToLinear(this Gradient gradient)
		{
			Gradient gradient2 = new Gradient();
			GradientColorKey[] colorKeys = gradient.colorKeys;
			for (int i = 0; i < colorKeys.Length; i++)
			{
				colorKeys[i].color = colorKeys[i].color.linear;
			}
			gradient2.SetKeys(colorKeys, gradient.alphaKeys);
			return gradient2;
		}
	}
}
