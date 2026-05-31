using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class BaseAxisTheme : ComponentTheme
	{
		[SerializeField]
		protected LineStyle.Type m_LineType;

		[SerializeField]
		protected float m_LineWidth = 1f;

		[SerializeField]
		protected float m_LineLength;

		[SerializeField]
		protected Color32 m_LineColor;

		[SerializeField]
		protected LineStyle.Type m_SplitLineType = LineStyle.Type.Dashed;

		[SerializeField]
		protected float m_SplitLineWidth = 1f;

		[SerializeField]
		protected float m_SplitLineLength;

		[SerializeField]
		protected Color32 m_SplitLineColor;

		[SerializeField]
		protected Color32 m_MinorSplitLineColor;

		[SerializeField]
		protected float m_TickWidth = 1f;

		[SerializeField]
		protected float m_TickLength = 5f;

		[SerializeField]
		protected Color32 m_TickColor;

		[SerializeField]
		protected List<Color32> m_SplitAreaColors = new List<Color32>();

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

		public float lineLength
		{
			get
			{
				return m_LineLength;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineLength, value))
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

		public LineStyle.Type splitLineType
		{
			get
			{
				return m_SplitLineType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SplitLineType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float splitLineWidth
		{
			get
			{
				return m_SplitLineWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SplitLineWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float splitLineLength
		{
			get
			{
				return m_SplitLineLength;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SplitLineLength, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 splitLineColor
		{
			get
			{
				return m_SplitLineColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_SplitLineColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 minorSplitLineColor
		{
			get
			{
				if (!ChartHelper.IsClearColor(m_MinorSplitLineColor))
				{
					return m_MinorSplitLineColor;
				}
				return ColorUtil.GetColor("#F4F7FD");
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_MinorSplitLineColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float tickLength
		{
			get
			{
				return m_TickLength;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_TickLength, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float tickWidth
		{
			get
			{
				return m_TickWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_TickWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 tickColor
		{
			get
			{
				return m_TickColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_TickColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public List<Color32> splitAreaColors
		{
			get
			{
				return m_SplitAreaColors;
			}
			set
			{
				if (value != null)
				{
					m_SplitAreaColors = value;
					SetVerticesDirty();
				}
			}
		}

		public BaseAxisTheme(ThemeType theme)
			: base(theme)
		{
			m_FontSize = XCSettings.fontSizeLv4;
			m_LineType = XCSettings.axisLineType;
			m_LineWidth = XCSettings.axisLineWidth;
			m_LineLength = 0f;
			m_SplitLineType = XCSettings.axisSplitLineType;
			m_SplitLineWidth = XCSettings.axisSplitLineWidth;
			m_SplitLineLength = 0f;
			m_TickWidth = XCSettings.axisTickWidth;
			m_TickLength = XCSettings.axisTickLength;
			switch (theme)
			{
			case ThemeType.Default:
				m_LineColor = ColorUtil.GetColor("#6E7079");
				m_TickColor = ColorUtil.GetColor("#6E7079");
				m_SplitLineColor = ColorUtil.GetColor("#E0E6F1");
				m_MinorSplitLineColor = ColorUtil.GetColor("#F4F7FD");
				m_SplitAreaColors = new List<Color32>
				{
					new Color32(250, 250, 250, 51),
					new Color32(210, 219, 238, 51)
				};
				break;
			case ThemeType.Light:
				m_LineColor = ColorUtil.GetColor("#6E7079");
				m_TickColor = ColorUtil.GetColor("#6E7079");
				m_SplitLineColor = ColorUtil.GetColor("#E0E6F1");
				m_MinorSplitLineColor = ColorUtil.GetColor("#F4F7FD");
				m_SplitAreaColors = new List<Color32>
				{
					new Color32(250, 250, 250, 51),
					new Color32(210, 219, 238, 51)
				};
				break;
			case ThemeType.Dark:
				m_LineColor = ColorUtil.GetColor("#6E7079");
				m_TickColor = ColorUtil.GetColor("#6E7079");
				m_SplitLineColor = ColorUtil.GetColor("#E0E6F1");
				m_MinorSplitLineColor = ColorUtil.GetColor("#F4F7FD");
				m_SplitAreaColors = new List<Color32>
				{
					new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 5),
					new Color32(210, 219, 238, 5)
				};
				break;
			}
		}

		public void Copy(BaseAxisTheme theme)
		{
			base.Copy(theme);
			m_LineType = theme.lineType;
			m_LineWidth = theme.lineWidth;
			m_LineLength = theme.lineLength;
			m_LineColor = theme.lineColor;
			m_SplitLineType = theme.splitLineType;
			m_SplitLineWidth = theme.splitLineWidth;
			m_SplitLineLength = theme.splitLineLength;
			m_SplitLineColor = theme.splitLineColor;
			m_TickWidth = theme.tickWidth;
			m_TickLength = theme.tickLength;
			m_TickColor = theme.tickColor;
			ChartHelper.CopyList(m_SplitAreaColors, theme.splitAreaColors);
		}
	}
}
