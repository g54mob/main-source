using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class ThemeStyle : ChildComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private Theme m_SharedTheme;

		[SerializeField]
		private bool m_TransparentBackground;

		[SerializeField]
		private bool m_EnableCustomTheme;

		[SerializeField]
		private Font m_CustomFont;

		[SerializeField]
		private Color32 m_CustomBackgroundColor;

		[SerializeField]
		private List<Color32> m_CustomColorPalette = new List<Color32>(13);

		private Dictionary<int, string> _colorDic = new Dictionary<int, string>();

		public bool show => m_Show;

		public ThemeType themeType => sharedTheme.themeType;

		public string themeName => sharedTheme.themeName;

		public Theme sharedTheme
		{
			get
			{
				return m_SharedTheme;
			}
			set
			{
				m_SharedTheme = value;
				SetAllDirty();
			}
		}

		public Color32 contrastColor => sharedTheme.contrastColor;

		public Color32 backgroundColor
		{
			get
			{
				if (m_TransparentBackground)
				{
					return ColorUtil.clearColor32;
				}
				if (!m_EnableCustomTheme)
				{
					return sharedTheme.backgroundColor;
				}
				return m_CustomBackgroundColor;
			}
		}

		public bool transparentBackground
		{
			get
			{
				return m_TransparentBackground;
			}
			set
			{
				m_TransparentBackground = value;
				SetAllDirty();
			}
		}

		public bool enableCustomTheme
		{
			get
			{
				return m_EnableCustomTheme;
			}
			set
			{
				m_EnableCustomTheme = value;
				_colorDic.Clear();
				SetAllDirty();
			}
		}

		public Color32 customBackgroundColor
		{
			get
			{
				return m_CustomBackgroundColor;
			}
			set
			{
				m_CustomBackgroundColor = value;
				SetAllDirty();
			}
		}

		public List<Color32> colorPalette
		{
			get
			{
				if (!m_EnableCustomTheme)
				{
					return sharedTheme.colorPalette;
				}
				return m_CustomColorPalette;
			}
		}

		public List<Color32> customColorPalette
		{
			get
			{
				return m_CustomColorPalette;
			}
			set
			{
				m_CustomColorPalette = value;
				SetVerticesDirty();
			}
		}

		public ComponentTheme common => sharedTheme.common;

		public TitleTheme title => sharedTheme.title;

		public SubTitleTheme subTitle => sharedTheme.subTitle;

		public LegendTheme legend => sharedTheme.legend;

		public AxisTheme axis => sharedTheme.axis;

		public TooltipTheme tooltip => sharedTheme.tooltip;

		public DataZoomTheme dataZoom => sharedTheme.dataZoom;

		public VisualMapTheme visualMap => sharedTheme.visualMap;

		public SerieTheme serie => sharedTheme.serie;

		public Color32 GetColor(int index)
		{
			if (colorPalette.Count <= 0)
			{
				return Color.clear;
			}
			if (index < 0)
			{
				index = 0;
			}
			int num = ((index < colorPalette.Count) ? index : (index % colorPalette.Count));
			if (num < colorPalette.Count)
			{
				return colorPalette[num];
			}
			return Color.clear;
		}

		public Color32 GetBackgroundColor(Background background)
		{
			if (background != null && background.show && !background.autoColor)
			{
				return background.imageColor;
			}
			return backgroundColor;
		}

		public void SyncSharedThemeColorToCustom()
		{
			m_CustomBackgroundColor = sharedTheme.backgroundColor;
			m_CustomColorPalette.Clear();
			foreach (Color32 item in sharedTheme.colorPalette)
			{
				m_CustomColorPalette.Add(item);
			}
			SetAllDirty();
		}

		public void CheckWarning(StringBuilder sb)
		{
			if (sharedTheme.font == null)
			{
				sb.AppendFormat("warning:theme->font is null\n");
			}
			if (sharedTheme.colorPalette.Count == 0)
			{
				sb.AppendFormat("warning:theme->colorPalette is empty\n");
			}
			for (int i = 0; i < sharedTheme.colorPalette.Count; i++)
			{
				if (!ChartHelper.IsClearColor(sharedTheme.colorPalette[i]) && sharedTheme.colorPalette[i].a == 0)
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
			index %= colorPalette.Count;
			if (_colorDic.ContainsKey(index))
			{
				return _colorDic[index];
			}
			_colorDic[index] = ColorUtility.ToHtmlStringRGBA(GetColor(index));
			return _colorDic[index];
		}

		public static Color32 GetColor(string hexColorStr)
		{
			ColorUtility.TryParseHtmlString(hexColorStr, out var color);
			return color;
		}
	}
}
