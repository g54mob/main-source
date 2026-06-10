using System;

namespace ModIOBrowser
{
	[Serializable]
	public struct ColorSchemeBlock
	{
		public static ColorSchemeBlock DefaultColorSchemeBlock;

		public ColorSetterType Normal;

		public float NormalColorAlpha;

		public ColorSetterType Highlighted;

		public float HighlightedColorAlpha;

		public ColorSetterType Pressed;

		public float PressedColorAlpha;

		public ColorSetterType Disabled;

		public float DisabledColorAlpha;

		public float ColorMultiplier;

		public float FadeDuration;
	}
}
