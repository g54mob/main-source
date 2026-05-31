using System;

namespace XCharts.Runtime
{
	[Serializable]
	public class RadarAxisTheme : BaseAxisTheme
	{
		public RadarAxisTheme(ThemeType theme)
			: base(theme)
		{
			m_SplitAreaColors.Clear();
			switch (theme)
			{
			case ThemeType.Dark:
				m_SplitAreaColors.Add(ThemeStyle.GetColor("#6f6f6f"));
				m_SplitAreaColors.Add(ThemeStyle.GetColor("#606060"));
				break;
			case ThemeType.Default:
				m_SplitAreaColors.Add(ThemeStyle.GetColor("#f6f6f6"));
				m_SplitAreaColors.Add(ThemeStyle.GetColor("#e7e7e7"));
				break;
			case ThemeType.Light:
				m_SplitAreaColors.Add(ThemeStyle.GetColor("#f6f6f6"));
				m_SplitAreaColors.Add(ThemeStyle.GetColor("#e7e7e7"));
				break;
			}
		}
	}
}
