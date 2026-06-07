using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class XCSettings : ScriptableObject
	{
		public static readonly string THEME_ASSET_NAME_PREFIX = "XCTheme-";

		public static readonly string THEME_ASSET_FOLDER = "Assets/XCharts/Resources";

		[SerializeField]
		private Lang m_Lang;

		[SerializeField]
		private Font m_Font;

		[SerializeField]
		[Range(1f, 200f)]
		private int m_FontSizeLv1 = 28;

		[SerializeField]
		[Range(1f, 200f)]
		private int m_FontSizeLv2 = 24;

		[SerializeField]
		[Range(1f, 200f)]
		private int m_FontSizeLv3 = 20;

		[SerializeField]
		[Range(1f, 200f)]
		private int m_FontSizeLv4 = 18;

		[SerializeField]
		private LineStyle.Type m_AxisLineType;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_AxisLineWidth = 0.8f;

		[SerializeField]
		private LineStyle.Type m_AxisSplitLineType;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_AxisSplitLineWidth = 0.8f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_AxisTickWidth = 0.8f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_AxisTickLength = 5f;

		[SerializeField]
		[Range(0f, 200f)]
		private float m_GaugeAxisLineWidth = 15f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_GaugeAxisSplitLineWidth = 0.8f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_GaugeAxisSplitLineLength = 15f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_GaugeAxisTickWidth = 0.8f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_GaugeAxisTickLength = 5f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_TootipLineWidth = 0.8f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_DataZoomBorderWidth = 0.5f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_DataZoomDataLineWidth = 0.5f;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_VisualMapBorderWidth;

		[SerializeField]
		[Range(0f, 20f)]
		private float m_SerieLineWidth = 1.8f;

		[SerializeField]
		[Range(0f, 200f)]
		private float m_SerieLineSymbolSize = 5f;

		[SerializeField]
		[Range(0f, 200f)]
		private float m_SerieScatterSymbolSize = 20f;

		[SerializeField]
		[Range(0f, 200f)]
		private float m_SerieSelectedRate = 1.3f;

		[SerializeField]
		[Range(0f, 10f)]
		private float m_SerieCandlestickBorderWidth = 1f;

		[SerializeField]
		private bool m_EditorShowAllListData;

		[SerializeField]
		[Range(1f, 20f)]
		protected int m_MaxPainter = 10;

		[SerializeField]
		[Range(1f, 10f)]
		protected float m_LineSmoothStyle = 3f;

		[SerializeField]
		[Range(1f, 20f)]
		protected float m_LineSmoothness = 2f;

		[SerializeField]
		[Range(1f, 20f)]
		protected float m_LineSegmentDistance = 3f;

		[SerializeField]
		[Range(1f, 10f)]
		protected float m_CicleSmoothness = 2f;

		[SerializeField]
		[Range(10f, 50f)]
		protected float m_VisualMapTriangeLen = 20f;

		[SerializeField]
		protected List<Theme> m_CustomThemes = new List<Theme>();

		private static XCSettings s_Instance;

		public static Lang lang => Instance.m_Lang;

		public static Font font => Instance.m_Font;

		public static int fontSizeLv1 => Instance.m_FontSizeLv1;

		public static int fontSizeLv2 => Instance.m_FontSizeLv2;

		public static int fontSizeLv3 => Instance.m_FontSizeLv3;

		public static int fontSizeLv4 => Instance.m_FontSizeLv4;

		public static LineStyle.Type axisLineType => Instance.m_AxisLineType;

		public static float axisLineWidth => Instance.m_AxisLineWidth;

		public static LineStyle.Type axisSplitLineType => Instance.m_AxisSplitLineType;

		public static float axisSplitLineWidth => Instance.m_AxisSplitLineWidth;

		public static float axisTickWidth => Instance.m_AxisTickWidth;

		public static float axisTickLength => Instance.m_AxisTickLength;

		public static float gaugeAxisLineWidth => Instance.m_GaugeAxisLineWidth;

		public static float gaugeAxisSplitLineWidth => Instance.m_GaugeAxisSplitLineWidth;

		public static float gaugeAxisSplitLineLength => Instance.m_GaugeAxisSplitLineLength;

		public static float gaugeAxisTickWidth => Instance.m_GaugeAxisTickWidth;

		public static float gaugeAxisTickLength => Instance.m_GaugeAxisTickLength;

		public static float tootipLineWidth => Instance.m_TootipLineWidth;

		public static float dataZoomBorderWidth => Instance.m_DataZoomBorderWidth;

		public static float dataZoomDataLineWidth => Instance.m_DataZoomDataLineWidth;

		public static float visualMapBorderWidth => Instance.m_VisualMapBorderWidth;

		public static float serieLineWidth => Instance.m_SerieLineWidth;

		public static float serieLineSymbolSize => Instance.m_SerieLineSymbolSize;

		public static float serieScatterSymbolSize => Instance.m_SerieScatterSymbolSize;

		public static float serieSelectedRate => Instance.m_SerieSelectedRate;

		public static float serieCandlestickBorderWidth => Instance.m_SerieCandlestickBorderWidth;

		public static bool editorShowAllListData => Instance.m_EditorShowAllListData;

		public static int maxPainter => Instance.m_MaxPainter;

		public static float lineSmoothStyle => Instance.m_LineSmoothStyle;

		public static float lineSmoothness => Instance.m_LineSmoothness;

		public static float lineSegmentDistance => Instance.m_LineSegmentDistance;

		public static float cicleSmoothness => Instance.m_CicleSmoothness;

		public static float visualMapTriangeLen => Instance.m_VisualMapTriangeLen;

		public static List<Theme> customThemes => Instance.m_CustomThemes;

		public static XCSettings Instance
		{
			get
			{
				if (s_Instance == null)
				{
					s_Instance = Resources.Load<XCSettings>("XCSettings");
				}
				return s_Instance;
			}
		}

		public static bool AddCustomTheme(Theme theme)
		{
			if (theme == null)
			{
				return false;
			}
			if (Instance == null || Instance.m_CustomThemes == null)
			{
				return false;
			}
			if (!Instance.m_CustomThemes.Contains(theme))
			{
				Instance.m_CustomThemes.Add(theme);
				return true;
			}
			return false;
		}
	}
}
