using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class TooltipTheme : ComponentTheme
	{
		[SerializeField]
		protected LineStyle.Type m_LineType;

		[SerializeField]
		protected float m_LineWidth = 1f;

		[SerializeField]
		protected Color32 m_LineColor;

		[SerializeField]
		protected Color32 m_AreaColor;

		[SerializeField]
		protected Color32 m_LabelTextColor;

		[SerializeField]
		protected Color32 m_LabelBackgroundColor;

		public LineStyle.Type lineType
		{
			get
			{
				return m_LineType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float lineWidth
		{
			get
			{
				return m_LineWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 lineColor
		{
			get
			{
				return m_LineColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_LineColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 areaColor
		{
			get
			{
				return m_AreaColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_AreaColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 labelTextColor
		{
			get
			{
				return m_LabelTextColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_LabelTextColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public Color32 labelBackgroundColor
		{
			get
			{
				return m_LabelBackgroundColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_LabelBackgroundColor, value))
				{
					SetComponentDirty();
				}
			}
		}

		public TooltipTheme(ThemeType theme)
			: base(theme)
		{
			m_LineType = LineStyle.Type.Solid;
			m_LineWidth = XCSettings.tootipLineWidth;
			switch (theme)
			{
			case ThemeType.Default:
				m_TextBackgroundColor = ColorUtil.GetColor("#FFFFFFFF");
				m_TextColor = ColorUtil.GetColor("#000000FF");
				m_AreaColor = ColorUtil.GetColor("#51515120");
				m_LabelTextColor = ColorUtil.GetColor("#FFFFFFFF");
				m_LabelBackgroundColor = ColorUtil.GetColor("#292929FF");
				m_LineColor = ColorUtil.GetColor("#29292964");
				break;
			case ThemeType.Light:
				m_TextBackgroundColor = ColorUtil.GetColor("#FFFFFFFF");
				m_TextColor = ColorUtil.GetColor("#000000FF");
				m_AreaColor = ColorUtil.GetColor("#51515120");
				m_LabelTextColor = ColorUtil.GetColor("#FFFFFFFF");
				m_LabelBackgroundColor = ColorUtil.GetColor("#292929FF");
				m_LineColor = ColorUtil.GetColor("#29292964");
				break;
			case ThemeType.Dark:
				m_TextBackgroundColor = ColorUtil.GetColor("#FFFFFFFF");
				m_TextColor = ColorUtil.GetColor("#000000FF");
				m_AreaColor = ColorUtil.GetColor("#51515120");
				m_LabelTextColor = ColorUtil.GetColor("#FFFFFFFF");
				m_LabelBackgroundColor = ColorUtil.GetColor("#292929FF");
				m_LineColor = ColorUtil.GetColor("#29292964");
				break;
			}
		}

		public void Copy(TooltipTheme theme)
		{
			base.Copy(theme);
			m_LineType = theme.lineType;
			m_LineWidth = theme.lineWidth;
			m_LineColor = theme.lineColor;
			m_AreaColor = theme.areaColor;
			m_LabelTextColor = theme.labelTextColor;
			m_LabelBackgroundColor = theme.labelBackgroundColor;
		}
	}
}
