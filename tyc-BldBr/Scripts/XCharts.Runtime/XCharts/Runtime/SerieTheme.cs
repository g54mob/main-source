using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class SerieTheme : ChildComponent
	{
		[SerializeField]
		protected float m_LineWidth;

		[SerializeField]
		protected float m_LineSymbolSize;

		[SerializeField]
		protected float m_ScatterSymbolSize;

		[SerializeField]
		protected Color32 m_CandlestickColor = new Color32(235, 84, 84, byte.MaxValue);

		[SerializeField]
		protected Color32 m_CandlestickColor0 = new Color32(71, 178, 98, byte.MaxValue);

		[SerializeField]
		protected float m_CandlestickBorderWidth = 1f;

		[SerializeField]
		protected Color32 m_CandlestickBorderColor = new Color32(235, 84, 84, byte.MaxValue);

		[SerializeField]
		protected Color32 m_CandlestickBorderColor0 = new Color32(71, 178, 98, byte.MaxValue);

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

		public float lineSymbolSize
		{
			get
			{
				return m_LineSymbolSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineSymbolSize, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float scatterSymbolSize
		{
			get
			{
				return m_ScatterSymbolSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ScatterSymbolSize, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 candlestickColor
		{
			get
			{
				return m_CandlestickColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_CandlestickColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 candlestickColor0
		{
			get
			{
				return m_CandlestickColor0;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_CandlestickColor0, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 candlestickBorderColor
		{
			get
			{
				return m_CandlestickBorderColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_CandlestickBorderColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 candlestickBorderColor0
		{
			get
			{
				return m_CandlestickBorderColor0;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_CandlestickBorderColor0, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float candlestickBorderWidth
		{
			get
			{
				return m_CandlestickBorderWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_CandlestickBorderWidth, (value < 0f) ? 0f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public void Copy(SerieTheme theme)
		{
			m_LineWidth = theme.lineWidth;
			m_LineSymbolSize = theme.lineSymbolSize;
			m_ScatterSymbolSize = theme.scatterSymbolSize;
			m_CandlestickColor = theme.candlestickColor;
			m_CandlestickColor0 = theme.candlestickColor0;
			m_CandlestickBorderColor = theme.candlestickBorderColor;
			m_CandlestickBorderColor0 = theme.candlestickBorderColor0;
			m_CandlestickBorderWidth = theme.candlestickBorderWidth;
		}

		public SerieTheme(ThemeType theme)
		{
			m_LineWidth = XCSettings.serieLineWidth;
			m_LineSymbolSize = XCSettings.serieLineSymbolSize;
			m_ScatterSymbolSize = XCSettings.serieScatterSymbolSize;
			m_CandlestickBorderWidth = XCSettings.serieCandlestickBorderWidth;
			switch (theme)
			{
			case ThemeType.Default:
				m_CandlestickColor = ColorUtil.GetColor("#eb5454");
				m_CandlestickColor0 = ColorUtil.GetColor("#47b262");
				m_CandlestickBorderColor = ColorUtil.GetColor("#eb5454");
				m_CandlestickBorderColor0 = ColorUtil.GetColor("#47b262");
				break;
			case ThemeType.Light:
				m_CandlestickColor = ColorUtil.GetColor("#eb5454");
				m_CandlestickColor0 = ColorUtil.GetColor("#47b262");
				m_CandlestickBorderColor = ColorUtil.GetColor("#eb5454");
				m_CandlestickBorderColor0 = ColorUtil.GetColor("#47b262");
				break;
			case ThemeType.Dark:
				m_CandlestickColor = ColorUtil.GetColor("#f64e56");
				m_CandlestickColor0 = ColorUtil.GetColor("#54ea92");
				m_CandlestickBorderColor = ColorUtil.GetColor("#f64e56");
				m_CandlestickBorderColor0 = ColorUtil.GetColor("#54ea92");
				break;
			}
		}
	}
}
