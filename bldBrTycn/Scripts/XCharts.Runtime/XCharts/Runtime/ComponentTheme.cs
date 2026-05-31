using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class ComponentTheme : ChildComponent
	{
		[SerializeField]
		protected Font m_Font;

		[SerializeField]
		protected Color m_TextColor;

		[SerializeField]
		protected Color m_TextBackgroundColor;

		[SerializeField]
		protected int m_FontSize = 18;

		public Font font
		{
			get
			{
				return m_Font;
			}
			set
			{
				m_Font = value;
				SetComponentDirty();
			}
		}

		public Color textColor
		{
			get
			{
				return m_TextColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_TextColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Color textBackgroundColor
		{
			get
			{
				return m_TextBackgroundColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_TextBackgroundColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public int fontSize
		{
			get
			{
				return m_FontSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_FontSize, value))
				{
					SetComponentDirty();
				}
			}
		}

		public ComponentTheme(ThemeType theme)
		{
			m_FontSize = XCSettings.fontSizeLv3;
			switch (theme)
			{
			case ThemeType.Default:
				m_TextColor = ColorUtil.GetColor("#514D4D");
				break;
			case ThemeType.Light:
				m_TextColor = ColorUtil.GetColor("#514D4D");
				break;
			case ThemeType.Dark:
				m_TextColor = ColorUtil.GetColor("#B9B8CE");
				break;
			}
		}

		public virtual void Copy(ComponentTheme theme)
		{
			m_Font = theme.font;
			m_FontSize = theme.fontSize;
			m_TextColor = theme.textColor;
			m_TextBackgroundColor = theme.textBackgroundColor;
		}

		public virtual void Reset(ComponentTheme defaultTheme)
		{
			Copy(defaultTheme);
		}
	}
}
