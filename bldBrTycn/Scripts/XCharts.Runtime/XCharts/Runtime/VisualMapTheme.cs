using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class VisualMapTheme : ComponentTheme
	{
		[SerializeField]
		protected float m_BorderWidth;

		[SerializeField]
		protected Color32 m_BorderColor;

		[SerializeField]
		protected Color32 m_BackgroundColor;

		[SerializeField]
		[Range(10f, 50f)]
		protected float m_TriangeLen = 20f;

		public float borderWidth
		{
			get
			{
				return m_BorderWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BorderWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 borderColor
		{
			get
			{
				return m_BorderColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BorderColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Color32 backgroundColor
		{
			get
			{
				return m_BackgroundColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_BackgroundColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float triangeLen
		{
			get
			{
				return m_TriangeLen;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_TriangeLen, (value < 0f) ? 1f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public VisualMapTheme(ThemeType theme)
			: base(theme)
		{
			m_BorderWidth = XCSettings.visualMapBorderWidth;
			m_TriangeLen = XCSettings.visualMapTriangeLen;
			m_FontSize = XCSettings.fontSizeLv4;
			switch (theme)
			{
			case ThemeType.Default:
				m_TextColor = ColorUtil.GetColor("#333");
				m_BorderColor = ColorUtil.GetColor("#ccc");
				m_BackgroundColor = ColorUtil.clearColor32;
				break;
			case ThemeType.Light:
				m_TextColor = ColorUtil.GetColor("#333");
				m_BorderColor = ColorUtil.GetColor("#ccc");
				m_BackgroundColor = ColorUtil.clearColor32;
				break;
			case ThemeType.Dark:
				m_TextColor = ColorUtil.GetColor("#B9B8CE");
				m_BorderColor = ColorUtil.GetColor("#ccc");
				m_BackgroundColor = ColorUtil.clearColor32;
				break;
			}
		}

		public void Copy(VisualMapTheme theme)
		{
			base.Copy(theme);
			m_TriangeLen = theme.triangeLen;
			m_BorderWidth = theme.borderWidth;
			m_BorderColor = theme.borderColor;
			m_BackgroundColor = theme.backgroundColor;
		}
	}
}
