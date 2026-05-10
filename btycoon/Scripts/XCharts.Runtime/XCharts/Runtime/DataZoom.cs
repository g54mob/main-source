using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(DataZoomHandler), true)]
	public class DataZoom : MainComponent, IUpdateRuntimeData
	{
		public enum FilterMode
		{
			Filter = 0,
			WeakFilter = 1,
			Empty = 2,
			None = 3
		}

		public enum RangeMode
		{
			Percent = 0
		}

		private class AxisIndexValueInfo
		{
			public double rawMin;

			public double rawMax;

			public double min;

			public double max;
		}

		[SerializeField]
		private bool m_Enable = true;

		[SerializeField]
		private FilterMode m_FilterMode;

		[SerializeField]
		private List<int> m_XAxisIndexs = new List<int> { 0 };

		[SerializeField]
		private List<int> m_YAxisIndexs = new List<int>();

		[SerializeField]
		private bool m_SupportInside;

		[SerializeField]
		private bool m_SupportInsideScroll = true;

		[SerializeField]
		private bool m_SupportInsideDrag = true;

		[SerializeField]
		private bool m_SupportSlider;

		[SerializeField]
		private bool m_SupportMarquee;

		[SerializeField]
		private bool m_ShowDataShadow;

		[SerializeField]
		private bool m_ShowDetail;

		[SerializeField]
		private bool m_ZoomLock;

		[SerializeField]
		protected Color32 m_FillerColor;

		[SerializeField]
		protected Color32 m_BorderColor;

		[SerializeField]
		protected float m_BorderWidth;

		[SerializeField]
		protected Color32 m_BackgroundColor;

		[SerializeField]
		private float m_Left;

		[SerializeField]
		private float m_Right;

		[SerializeField]
		private float m_Top;

		[SerializeField]
		private float m_Bottom;

		[SerializeField]
		private RangeMode m_RangeMode;

		[SerializeField]
		private float m_Start;

		[SerializeField]
		private float m_End;

		[SerializeField]
		private int m_MinShowNum = 2;

		[Range(1f, 20f)]
		[SerializeField]
		private float m_ScrollSensitivity = 1.1f;

		[SerializeField]
		private Orient m_Orient;

		[SerializeField]
		private LabelStyle m_LabelStyle = new LabelStyle();

		[SerializeField]
		private LineStyle m_LineStyle = new LineStyle(LineStyle.Type.Solid);

		[SerializeField]
		private AreaStyle m_AreaStyle = new AreaStyle();

		[SerializeField]
		[Since("v3.5.0")]
		private MarqueeStyle m_MarqueeStyle = new MarqueeStyle();

		[SerializeField]
		[Since("v3.6.0")]
		private bool m_StartLock;

		[SerializeField]
		[Since("v3.6.0")]
		private bool m_EndLock;

		public DataZoomContext context = new DataZoomContext();

		private CustomDataZoomStartEndFunction m_StartEndFunction;

		private Dictionary<int, AxisIndexValueInfo> m_XAxisIndexInfos = new Dictionary<int, AxisIndexValueInfo>();

		private Dictionary<int, AxisIndexValueInfo> m_YAxisIndexInfos = new Dictionary<int, AxisIndexValueInfo>();

		public bool enable
		{
			get
			{
				return m_Enable;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Enable, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public FilterMode filterMode
		{
			get
			{
				return m_FilterMode;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_FilterMode, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public List<int> xAxisIndexs
		{
			get
			{
				return m_XAxisIndexs;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_XAxisIndexs, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public List<int> yAxisIndexs
		{
			get
			{
				return m_YAxisIndexs;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_YAxisIndexs, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool supportInside
		{
			get
			{
				return m_SupportInside;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SupportInside, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool supportInsideScroll
		{
			get
			{
				return m_SupportInsideScroll;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SupportInsideScroll, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool supportInsideDrag
		{
			get
			{
				return m_SupportInsideDrag;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SupportInsideDrag, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool supportSlider
		{
			get
			{
				return m_SupportSlider;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SupportSlider, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool supportMarquee
		{
			get
			{
				return m_SupportMarquee;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SupportMarquee, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showDataShadow
		{
			get
			{
				return m_ShowDataShadow;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowDataShadow, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showDetail
		{
			get
			{
				return m_ShowDetail;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowDetail, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool zoomLock
		{
			get
			{
				return m_ZoomLock;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ZoomLock, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool realtime => true;

		public Color backgroundColor
		{
			get
			{
				return m_BackgroundColor;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BackgroundColor, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Color32 fillerColor
		{
			get
			{
				return m_FillerColor;
			}
			set
			{
				if (PropertyUtil.SetColor(ref m_FillerColor, value))
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
					SetComponentDirty();
				}
			}
		}

		public float bottom
		{
			get
			{
				return m_Bottom;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Bottom, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float top
		{
			get
			{
				return m_Top;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Top, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float left
		{
			get
			{
				return m_Left;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Left, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float right
		{
			get
			{
				return m_Right;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Right, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public RangeMode rangeMode
		{
			get
			{
				return m_RangeMode;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_RangeMode, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float start
		{
			get
			{
				return m_Start;
			}
			set
			{
				m_Start = value;
				if (m_Start < 0f)
				{
					m_Start = 0f;
				}
				if (m_Start > 100f)
				{
					m_Start = 100f;
				}
				SetVerticesDirty();
			}
		}

		public bool startLock
		{
			get
			{
				return m_StartLock;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_StartLock, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool endLock
		{
			get
			{
				return m_EndLock;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_EndLock, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float end
		{
			get
			{
				return m_End;
			}
			set
			{
				m_End = value;
				if (m_End < 0f)
				{
					m_End = 0f;
				}
				if (m_End > 100f)
				{
					m_End = 100f;
				}
				SetVerticesDirty();
			}
		}

		public int minShowNum
		{
			get
			{
				return m_MinShowNum;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MinShowNum, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float scrollSensitivity
		{
			get
			{
				return m_ScrollSensitivity;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ScrollSensitivity, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Orient orient
		{
			get
			{
				return m_Orient;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Orient, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public LabelStyle labelStyle
		{
			get
			{
				return m_LabelStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_LabelStyle, value))
				{
					SetComponentDirty();
				}
			}
		}

		public LineStyle lineStyle
		{
			get
			{
				return m_LineStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_LineStyle, value))
				{
					SetComponentDirty();
				}
			}
		}

		public AreaStyle areaStyle
		{
			get
			{
				return m_AreaStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_AreaStyle, value))
				{
					SetComponentDirty();
				}
			}
		}

		public MarqueeStyle marqueeStyle
		{
			get
			{
				return m_MarqueeStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_MarqueeStyle, value))
				{
					SetAllDirty();
				}
			}
		}

		public CustomDataZoomStartEndFunction startEndFunction
		{
			get
			{
				return m_StartEndFunction;
			}
			set
			{
				m_StartEndFunction = value;
			}
		}

		private ChartLabel m_StartLabel { get; set; }

		private ChartLabel m_EndLabel { get; set; }

		public override void SetDefaultValue()
		{
			supportInside = true;
			supportSlider = true;
			filterMode = FilterMode.None;
			xAxisIndexs = new List<int> { 0 };
			yAxisIndexs = new List<int>();
			showDataShadow = true;
			showDetail = false;
			zoomLock = false;
			m_Bottom = 10f;
			m_Left = 10f;
			m_Right = 10f;
			m_Top = 0.9f;
			rangeMode = RangeMode.Percent;
			start = 30f;
			end = 70f;
			m_Orient = Orient.Horizonal;
			m_ScrollSensitivity = 10f;
			m_LabelStyle = new LabelStyle();
			m_LineStyle = new LineStyle(LineStyle.Type.Solid)
			{
				opacity = 0.3f
			};
			m_AreaStyle = new AreaStyle
			{
				show = true,
				opacity = 0.3f
			};
			m_MarqueeStyle = new MarqueeStyle();
		}

		public bool IsInZoom(Vector2 pos)
		{
			if (pos.x < context.x - 1f || pos.x > context.x + context.width + 1f || pos.y < context.y - 1f || pos.y > context.y + context.height + 1f)
			{
				return false;
			}
			return true;
		}

		public bool IsInSelectedZoom(Vector2 pos)
		{
			switch (m_Orient)
			{
			case Orient.Horizonal:
			{
				float yMin = context.x + context.width * m_Start / 100f;
				float yMax = context.x + context.width * m_End / 100f;
				return ChartHelper.IsInRect(pos, yMin, yMax, context.y, context.y + context.height);
			}
			case Orient.Vertical:
			{
				float yMin = context.y + context.height * m_Start / 100f;
				float yMax = context.y + context.height * m_End / 100f;
				return ChartHelper.IsInRect(pos, context.x, context.x + context.width, yMin, yMax);
			}
			default:
				return false;
			}
		}

		public bool IsInSelectedZoom(int totalIndex, int index, bool invert)
		{
			if (totalIndex <= 0)
			{
				return false;
			}
			float num = (invert ? (100f - end) : start);
			float num2 = (invert ? (100f - start) : end);
			int num3 = Mathf.RoundToInt((float)totalIndex * (num2 - num) / 100f);
			int num4 = Mathf.FloorToInt((float)totalIndex * num / 100f);
			int num5 = Mathf.CeilToInt((float)totalIndex * num2 / 100f);
			if (num4 == 0)
			{
				num5 = num4 + num3;
			}
			if (num5 == totalIndex)
			{
				num4 = num5 - num3;
			}
			if (index >= num4)
			{
				return index < num4 + num3;
			}
			return false;
		}

		public bool IsInStartZoom(Vector2 pos)
		{
			switch (m_Orient)
			{
			case Orient.Horizonal:
			{
				float num = context.x + context.width * m_Start / 100f;
				return ChartHelper.IsInRect(pos, num - 10f, num + 10f, context.y, context.y + context.height);
			}
			case Orient.Vertical:
			{
				float num = context.y + context.height * m_Start / 100f;
				return ChartHelper.IsInRect(pos, context.x, context.x + context.width, num - 10f, num + 10f);
			}
			default:
				return false;
			}
		}

		public bool IsInEndZoom(Vector2 pos)
		{
			switch (m_Orient)
			{
			case Orient.Horizonal:
			{
				float num = context.x + context.width * m_End / 100f;
				return ChartHelper.IsInRect(pos, num - 10f, num + 10f, context.y, context.y + context.height);
			}
			case Orient.Vertical:
			{
				float num = context.y + context.height * m_End / 100f;
				return ChartHelper.IsInRect(pos, context.x, context.x + context.width, num - 10f, num + 10f);
			}
			default:
				return false;
			}
		}

		public bool IsInMarqueeArea(SerieData serieData)
		{
			return IsInMarqueeArea(serieData.context.position);
		}

		public bool IsInMarqueeArea(Vector2 pos)
		{
			if (!supportMarquee)
			{
				return false;
			}
			if (context.marqueeRect.width >= 0f)
			{
				return context.marqueeRect.Contains(pos);
			}
			Rect marqueeRect = context.marqueeRect;
			return new Rect(marqueeRect.x + marqueeRect.width, marqueeRect.y, 0f - marqueeRect.width, marqueeRect.height).Contains(pos);
		}

		public bool IsContainsAxis(Axis axis)
		{
			if (axis == null)
			{
				return false;
			}
			if (axis is XAxis)
			{
				return xAxisIndexs.Contains(axis.index);
			}
			if (axis is YAxis)
			{
				return yAxisIndexs.Contains(axis.index);
			}
			return false;
		}

		public bool IsContainsXAxis(int index)
		{
			if (xAxisIndexs != null)
			{
				return xAxisIndexs.Contains(index);
			}
			return false;
		}

		public bool IsContainsYAxis(int index)
		{
			if (yAxisIndexs != null)
			{
				return yAxisIndexs.Contains(index);
			}
			return false;
		}

		public Color32 GetFillerColor(Color32 themeColor)
		{
			if (ChartHelper.IsClearColor(fillerColor))
			{
				return themeColor;
			}
			return fillerColor;
		}

		public Color32 GetBackgroundColor(Color32 themeColor)
		{
			if (ChartHelper.IsClearColor(backgroundColor))
			{
				return themeColor;
			}
			return backgroundColor;
		}

		public Color32 GetBorderColor(Color32 themeColor)
		{
			if (ChartHelper.IsClearColor(borderColor))
			{
				return themeColor;
			}
			return borderColor;
		}

		internal void SetLabelActive(bool flag)
		{
			m_StartLabel.SetActive(flag);
			m_EndLabel.SetActive(flag);
		}

		internal void SetStartLabelText(string text)
		{
			if (m_StartLabel != null)
			{
				m_StartLabel.SetText(text);
			}
		}

		internal void SetEndLabelText(string text)
		{
			if (m_EndLabel != null)
			{
				m_EndLabel.SetText(text);
			}
		}

		internal void SetStartLabel(ChartLabel startLabel)
		{
			m_StartLabel = startLabel;
		}

		internal void SetEndLabel(ChartLabel endLabel)
		{
			m_EndLabel = endLabel;
		}

		internal void UpdateStartLabelPosition(Vector3 pos)
		{
			if (m_StartLabel != null)
			{
				m_StartLabel.SetPosition(pos);
			}
		}

		internal void UpdateEndLabelPosition(Vector3 pos)
		{
			if (m_EndLabel != null)
			{
				m_EndLabel.SetPosition(pos);
			}
		}

		public void UpdateRuntimeData(BaseChart chart)
		{
			float chartX = chart.chartX;
			float chartY = chart.chartY;
			float chartWidth = chart.chartWidth;
			float chartHeight = chart.chartHeight;
			float num = ((left <= 1f) ? (left * chartWidth) : left);
			float num2 = ((bottom <= 1f) ? (bottom * chartHeight) : bottom);
			float num3 = ((top <= 1f) ? (top * chartHeight) : top);
			float num4 = ((right <= 1f) ? (right * chartWidth) : right);
			context.x = chartX + num;
			context.y = chartY + num2;
			context.width = chartWidth - num - num4;
			context.height = chartHeight - num3 - num2;
		}

		internal void SetXAxisIndexValueInfo(int xAxisIndex, ref double min, ref double max)
		{
			if (!m_XAxisIndexInfos.TryGetValue(xAxisIndex, out var value))
			{
				value = new AxisIndexValueInfo();
				m_XAxisIndexInfos[xAxisIndex] = value;
			}
			value.rawMin = min;
			value.rawMax = max;
			value.min = min + (max - min) * (double)start / 100.0;
			value.max = min + (max - min) * (double)end / 100.0;
			min = value.min;
			max = value.max;
		}

		internal void SetYAxisIndexValueInfo(int yAxisIndex, ref double min, ref double max)
		{
			if (!m_YAxisIndexInfos.TryGetValue(yAxisIndex, out var value))
			{
				value = new AxisIndexValueInfo();
				m_YAxisIndexInfos[yAxisIndex] = value;
			}
			value.rawMin = min;
			value.rawMax = max;
			value.min = min + (max - min) * (double)start / 100.0;
			value.max = min + (max - min) * (double)end / 100.0;
			min = value.min;
			max = value.max;
		}

		internal bool IsXAxisIndexValue(int axisIndex)
		{
			return m_XAxisIndexInfos.ContainsKey(axisIndex);
		}

		internal bool IsYAxisIndexValue(int axisIndex)
		{
			return m_YAxisIndexInfos.ContainsKey(axisIndex);
		}

		internal void GetXAxisIndexValue(int axisIndex, out double min, out double max)
		{
			if (m_XAxisIndexInfos.TryGetValue(axisIndex, out var value))
			{
				double num = value.rawMax - value.rawMin;
				min = value.rawMin + num * (double)m_Start / 100.0;
				max = value.rawMin + num * (double)m_End / 100.0;
			}
			else
			{
				min = 0.0;
				max = 0.0;
			}
		}

		internal void GetYAxisIndexValue(int axisIndex, out double min, out double max)
		{
			if (m_YAxisIndexInfos.TryGetValue(axisIndex, out var value))
			{
				double num = value.rawMax - value.rawMin;
				min = value.rawMin + num * (double)m_Start / 100.0;
				max = value.rawMin + num * (double)m_End / 100.0;
			}
			else
			{
				min = 0.0;
				max = 0.0;
			}
		}
	}
}
