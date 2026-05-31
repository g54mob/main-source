using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class Theme : ScriptableObject
	{
		[SerializeField]
		private ThemeType m_ThemeType;

		[SerializeField]
		private string m_ThemeName = ThemeType.Default.ToString();

		[SerializeField]
		private Font m_Font;

		[SerializeField]
		private Color32 m_ContrastColor;

		[SerializeField]
		private Color32 m_BackgroundColor;

		[SerializeField]
		private List<Color32> m_ColorPalette = new List<Color32>(13);

		[SerializeField]
		private ComponentTheme m_Common;

		[SerializeField]
		private TitleTheme m_Title;

		[SerializeField]
		private SubTitleTheme m_SubTitle;

		[SerializeField]
		private LegendTheme m_Legend;

		[SerializeField]
		private AxisTheme m_Axis;

		[SerializeField]
		private TooltipTheme m_Tooltip;

		[SerializeField]
		private DataZoomTheme m_DataZoom;

		[SerializeField]
		private VisualMapTheme m_VisualMap;

		[SerializeField]
		private SerieTheme m_Serie;

		private Dictionary<int, string> _colorDic = new Dictionary<int, string>();

		public ThemeType themeType
		{
			get
			{
				return m_ThemeType;
			}
			set
			{
				PropertyUtil.SetStruct(ref m_ThemeType, value);
			}
		}

		public string themeName
		{
			get
			{
				return m_ThemeName;
			}
			set
			{
				PropertyUtil.SetClass(ref m_ThemeName, value);
			}
		}

		public Color32 contrastColor
		{
			get
			{
				return m_ContrastColor;
			}
			set
			{
				PropertyUtil.SetColor(ref m_ContrastColor, value);
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
				PropertyUtil.SetColor(ref m_BackgroundColor, value);
			}
		}

		public List<Color32> colorPalette
		{
			get
			{
				return m_ColorPalette;
			}
			set
			{
				m_ColorPalette = value;
			}
		}

		public ComponentTheme common
		{
			get
			{
				return m_Common;
			}
			set
			{
				m_Common = value;
			}
		}

		public TitleTheme title
		{
			get
			{
				return m_Title;
			}
			set
			{
				m_Title = value;
			}
		}

		public SubTitleTheme subTitle
		{
			get
			{
				return m_SubTitle;
			}
			set
			{
				m_SubTitle = value;
			}
		}

		public LegendTheme legend
		{
			get
			{
				return m_Legend;
			}
			set
			{
				m_Legend = value;
			}
		}

		public AxisTheme axis
		{
			get
			{
				return m_Axis;
			}
			set
			{
				m_Axis = value;
			}
		}

		public TooltipTheme tooltip
		{
			get
			{
				return m_Tooltip;
			}
			set
			{
				m_Tooltip = value;
			}
		}

		public DataZoomTheme dataZoom
		{
			get
			{
				return m_DataZoom;
			}
			set
			{
				m_DataZoom = value;
			}
		}

		public VisualMapTheme visualMap
		{
			get
			{
				return m_VisualMap;
			}
			set
			{
				m_VisualMap = value;
			}
		}

		public SerieTheme serie
		{
			get
			{
				return m_Serie;
			}
			set
			{
				m_Serie = value;
			}
		}

		public Font font
		{
			get
			{
				return m_Font;
			}
			set
			{
				m_Font = value;
				SyncFontToSubComponent();
			}
		}

		public static Theme EmptyTheme
		{
			get
			{
				Theme theme = ScriptableObject.CreateInstance<Theme>();
				theme.themeType = ThemeType.Custom;
				theme.themeName = ThemeType.Custom.ToString();
				theme.backgroundColor = Color.clear;
				theme.colorPalette = new List<Color32>();
				InitChartComponentTheme(theme);
				return theme;
			}
		}

		public void SetDefaultFont()
		{
			font = XCSettings.font;
			SyncFontToSubComponent();
		}

		public Color32 GetColor(int index)
		{
			if (index < 0)
			{
				index = 0;
			}
			int num = ((index < m_ColorPalette.Count) ? index : (index % m_ColorPalette.Count));
			if (num < m_ColorPalette.Count)
			{
				return m_ColorPalette[num];
			}
			return Color.clear;
		}

		public void CheckWarning(StringBuilder sb)
		{
			if (m_Font == null)
			{
				sb.AppendFormat("warning:theme->font is null\n");
			}
			if (m_ColorPalette.Count == 0)
			{
				sb.AppendFormat("warning:theme->colorPalette is empty\n");
			}
			for (int i = 0; i < m_ColorPalette.Count; i++)
			{
				if (!ChartHelper.IsClearColor(m_ColorPalette[i]) && m_ColorPalette[i].a == 0)
				{
					sb.AppendFormat("warning:theme->colorPalette[{0}] alpha = 0\n", i);
				}
			}
		}

		public string GetColorStr(int index)
		{
			if (index < 0)
			{
				index = 0;
			}
			index %= m_ColorPalette.Count;
			if (_colorDic.ContainsKey(index))
			{
				return _colorDic[index];
			}
			_colorDic[index] = ColorUtility.ToHtmlStringRGBA(GetColor(index));
			return _colorDic[index];
		}

		public bool CopyTheme(ThemeType theme)
		{
			switch (theme)
			{
			case ThemeType.Dark:
				ResetToDarkTheme(this);
				return true;
			case ThemeType.Default:
				ResetToDefaultTheme(this);
				return true;
			default:
				return false;
			}
		}

		public void CopyTheme(Theme theme)
		{
			m_ThemeType = theme.themeType;
			m_ThemeName = theme.themeName;
			font = theme.font;
			m_BackgroundColor = theme.backgroundColor;
			m_Common.Copy(theme.common);
			m_Legend.Copy(theme.legend);
			m_Title.Copy(theme.title);
			m_SubTitle.Copy(theme.subTitle);
			m_Axis.Copy(theme.axis);
			m_Tooltip.Copy(theme.tooltip);
			m_DataZoom.Copy(theme.dataZoom);
			m_VisualMap.Copy(theme.visualMap);
			m_Serie.Copy(theme.serie);
			ChartHelper.CopyList(m_ColorPalette, theme.colorPalette);
		}

		public bool ResetTheme()
		{
			switch (m_ThemeType)
			{
			case ThemeType.Default:
				ResetToDefaultTheme(this);
				return true;
			case ThemeType.Dark:
				ResetToDarkTheme(this);
				return true;
			case ThemeType.Custom:
				return false;
			default:
				return false;
			}
		}

		public Theme CloneTheme()
		{
			Theme theme = ScriptableObject.CreateInstance<Theme>();
			InitChartComponentTheme(theme);
			theme.CopyTheme(this);
			return theme;
		}

		public static void ResetToDefaultTheme(Theme theme)
		{
			theme.themeType = ThemeType.Default;
			theme.themeName = ThemeType.Default.ToString();
			theme.backgroundColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			theme.colorPalette = new List<Color32>
			{
				ColorUtil.GetColor("#5470c6"),
				ColorUtil.GetColor("#91cc75"),
				ColorUtil.GetColor("#fac858"),
				ColorUtil.GetColor("#ee6666"),
				ColorUtil.GetColor("#73c0de"),
				ColorUtil.GetColor("#3ba272"),
				ColorUtil.GetColor("#fc8452"),
				ColorUtil.GetColor("#9a60b4"),
				ColorUtil.GetColor("#ea7ccc")
			};
			InitChartComponentTheme(theme);
		}

		public static void ResetToDarkTheme(Theme theme)
		{
			theme.themeType = ThemeType.Dark;
			theme.themeName = ThemeType.Dark.ToString();
			theme.backgroundColor = ColorUtil.GetColor("#100C2A");
			theme.colorPalette = new List<Color32>
			{
				ColorUtil.GetColor("#4992ff"),
				ColorUtil.GetColor("#7cffb2"),
				ColorUtil.GetColor("#fddd60"),
				ColorUtil.GetColor("#ff6e76"),
				ColorUtil.GetColor("#58d9f9"),
				ColorUtil.GetColor("#05c091"),
				ColorUtil.GetColor("#ff8a45"),
				ColorUtil.GetColor("#8d48e3"),
				ColorUtil.GetColor("#dd79ff")
			};
			InitChartComponentTheme(theme);
		}

		public void SyncFontToSubComponent()
		{
			common.font = font;
			title.font = font;
			subTitle.font = font;
			legend.font = font;
			axis.font = font;
			tooltip.font = font;
			dataZoom.font = font;
			visualMap.font = font;
		}

		private static void InitChartComponentTheme(Theme theme)
		{
			theme.common = new ComponentTheme(theme.themeType);
			theme.title = new TitleTheme(theme.themeType);
			theme.subTitle = new SubTitleTheme(theme.themeType);
			theme.legend = new LegendTheme(theme.themeType);
			theme.axis = new AxisTheme(theme.themeType);
			theme.tooltip = new TooltipTheme(theme.themeType);
			theme.dataZoom = new DataZoomTheme(theme.themeType);
			theme.visualMap = new VisualMapTheme(theme.themeType);
			theme.serie = new SerieTheme(theme.themeType);
			theme.SetDefaultFont();
		}

		public static Color32 GetColor(string hexColorStr)
		{
			ColorUtility.TryParseHtmlString(hexColorStr, out var color);
			return color;
		}

		public void SetColorPalette(List<string> hexColorStringList)
		{
			m_ColorPalette.Clear();
			foreach (string hexColorString in hexColorStringList)
			{
				m_ColorPalette.Add(ColorUtil.GetColor(hexColorString));
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
