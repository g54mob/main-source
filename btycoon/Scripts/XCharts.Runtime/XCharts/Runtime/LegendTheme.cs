using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class LegendTheme : ComponentTheme
	{
		[SerializeField]
		protected Color m_UnableColor;

		public Color unableColor
		{
			get
			{
				return m_UnableColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_UnableColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public void Copy(LegendTheme theme)
		{
			base.Copy(theme);
			m_UnableColor = theme.unableColor;
		}

		public LegendTheme(ThemeType theme)
			: base(theme)
		{
			m_UnableColor = ColorUtil.GetColor("#cccccc");
		}
	}
}
