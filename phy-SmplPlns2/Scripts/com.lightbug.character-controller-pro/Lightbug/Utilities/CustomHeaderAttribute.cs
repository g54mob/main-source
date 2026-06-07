using System;
using UnityEngine;

namespace Lightbug.Utilities
{
	[AttributeUsage(AttributeTargets.Field)]
	public class CustomHeaderAttribute : PropertyAttribute
	{
		public enum HeaderColor
		{
			HighContrastLight = 0,
			HighContrastDark = 1,
			DarkGray = 2,
			LightGray = 3
		}

		public TextAlignment m_textAlignment;

		public string m_text;

		public bool m_colorThemeByProSkin = true;

		public bool m_filledBackground = true;

		public HeaderColor m_colorTheme;

		public CustomHeaderAttribute(string text)
		{
			m_text = text;
			m_textAlignment = TextAlignment.Left;
			m_colorThemeByProSkin = true;
			m_filledBackground = true;
		}

		public CustomHeaderAttribute(string text, TextAlignment textAlignment)
		{
			m_text = text;
			m_textAlignment = textAlignment;
			m_colorThemeByProSkin = true;
			m_filledBackground = true;
		}

		public CustomHeaderAttribute(string text, TextAlignment textAlignment, bool filledBackground)
		{
			m_text = text;
			m_textAlignment = textAlignment;
			m_colorThemeByProSkin = true;
			m_filledBackground = filledBackground;
		}

		public CustomHeaderAttribute(string text, TextAlignment textAlignment, bool filledBackground, HeaderColor colorTheme)
		{
			m_text = text;
			m_textAlignment = textAlignment;
			m_colorThemeByProSkin = false;
			m_colorTheme = colorTheme;
			m_filledBackground = filledBackground;
		}
	}
}
