using System;
using UnityEngine;

namespace DigitalRuby.Tween
{
	public class ColorTween : Tween<Color>
	{
		private static readonly Func<ITween<Color>, Color, Color, float, Color> LerpFunc = LerpColor;

		private static Color LerpColor(ITween<Color> t, Color start, Color end, float progress)
		{
			return Color.Lerp(start, end, progress);
		}

		public ColorTween()
			: base(LerpFunc)
		{
		}
	}
}
