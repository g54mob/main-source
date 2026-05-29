using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(RadarCoordHandler), true)]
	[CoordOptions(typeof(RadarCoord))]
	public class RadarCoord : CoordSystem, ISerieContainer
	{
		public enum Shape
		{
			Polygon = 0,
			Circle = 1
		}

		public enum PositionType
		{
			Vertice = 0,
			Between = 1
		}

		[Serializable]
		public class Indicator
		{
			[SerializeField]
			private string m_Name;

			[SerializeField]
			private double m_Max;

			[SerializeField]
			private double m_Min;

			[SerializeField]
			private double[] m_Range = new double[2];

			public string name
			{
				get
				{
					return m_Name;
				}
				set
				{
					m_Name = value;
				}
			}

			public double max
			{
				get
				{
					return m_Max;
				}
				set
				{
					m_Max = value;
				}
			}

			public double min
			{
				get
				{
					return m_Min;
				}
				set
				{
					m_Min = value;
				}
			}

			public Text text { get; set; }

			public double[] range
			{
				get
				{
					return m_Range;
				}
				set
				{
					if (value != null && value.Length == 2)
					{
						m_Range = value;
					}
				}
			}

			public bool IsInRange(double value)
			{
				if (m_Range == null || m_Range.Length < 2)
				{
					return true;
				}
				if (m_Range[0] != 0.0 || m_Range[1] != 0.0)
				{
					if (value >= m_Range[0])
					{
						return value <= m_Range[1];
					}
					return false;
				}
				return true;
			}
		}

		[SerializeField]
		private bool m_Show;

		[SerializeField]
		private Shape m_Shape;

		[SerializeField]
		private float m_Radius = 100f;

		[SerializeField]
		private int m_SplitNumber = 5;

		[SerializeField]
		private float[] m_Center = new float[2] { 0.5f, 0.5f };

		[SerializeField]
		private AxisLine m_AxisLine = AxisLine.defaultAxisLine;

		[SerializeField]
		private AxisName m_AxisName = AxisName.defaultAxisName;

		[SerializeField]
		private AxisSplitLine m_SplitLine = AxisSplitLine.defaultSplitLine;

		[SerializeField]
		private AxisSplitArea m_SplitArea = AxisSplitArea.defaultSplitArea;

		[SerializeField]
		private bool m_Indicator = true;

		[SerializeField]
		private PositionType m_PositionType;

		[SerializeField]
		private float m_IndicatorGap = 10f;

		[SerializeField]
		private double m_CeilRate;

		[SerializeField]
		private bool m_IsAxisTooltip;

		[SerializeField]
		private Color32 m_OutRangeColor = Color.red;

		[SerializeField]
		private bool m_ConnectCenter;

		[SerializeField]
		private bool m_LineGradient = true;

		[SerializeField]
		[Since("v3.4.0")]
		private float m_StartAngle;

		[SerializeField]
		[Since("v3.8.0")]
		private int m_GridIndex = -1;

		[SerializeField]
		private List<Indicator> m_IndicatorList = new List<Indicator>();

		public RadarCoordContext context = new RadarCoordContext();

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Show, value))
				{
					SetComponentDirty();
				}
			}
		}

		public int gridIndex
		{
			get
			{
				return m_GridIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_GridIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public Shape shape
		{
			get
			{
				return m_Shape;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Shape, value))
				{
					SetAllDirty();
				}
			}
		}

		public float radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Radius, value))
				{
					SetAllDirty();
				}
			}
		}

		public int splitNumber
		{
			get
			{
				return m_SplitNumber;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SplitNumber, value))
				{
					SetAllDirty();
				}
			}
		}

		public float[] center
		{
			get
			{
				return m_Center;
			}
			set
			{
				if (value != null)
				{
					m_Center = value;
					SetAllDirty();
				}
			}
		}

		public AxisLine axisLine
		{
			get
			{
				return m_AxisLine;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_AxisLine, value, notNull: true))
				{
					SetAllDirty();
				}
			}
		}

		public AxisName axisName
		{
			get
			{
				return m_AxisName;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_AxisName, value, notNull: true))
				{
					SetAllDirty();
				}
			}
		}

		public AxisSplitLine splitLine
		{
			get
			{
				return m_SplitLine;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SplitLine, value, notNull: true))
				{
					SetAllDirty();
				}
			}
		}

		public AxisSplitArea splitArea
		{
			get
			{
				return m_SplitArea;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SplitArea, value, notNull: true))
				{
					SetAllDirty();
				}
			}
		}

		public bool indicator
		{
			get
			{
				return m_Indicator;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Indicator, value))
				{
					SetComponentDirty();
				}
			}
		}

		public float indicatorGap
		{
			get
			{
				return m_IndicatorGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_IndicatorGap, value))
				{
					SetComponentDirty();
				}
			}
		}

		public double ceilRate
		{
			get
			{
				return m_CeilRate;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_CeilRate, (value < 0.0) ? 0.0 : value))
				{
					SetAllDirty();
				}
			}
		}

		public bool isAxisTooltip
		{
			get
			{
				return m_IsAxisTooltip;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_IsAxisTooltip, value))
				{
					SetAllDirty();
				}
			}
		}

		public PositionType positionType
		{
			get
			{
				return m_PositionType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_PositionType, value))
				{
					SetAllDirty();
				}
			}
		}

		public Color32 outRangeColor
		{
			get
			{
				return m_OutRangeColor;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_OutRangeColor, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool connectCenter
		{
			get
			{
				return m_ConnectCenter;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ConnectCenter, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool lineGradient
		{
			get
			{
				return m_LineGradient;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LineGradient, value))
				{
					SetAllDirty();
				}
			}
		}

		public float startAngle
		{
			get
			{
				return m_StartAngle;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_StartAngle, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public List<Indicator> indicatorList => m_IndicatorList;

		public bool IsPointerEnter()
		{
			return context.isPointerEnter;
		}

		public override void SetDefaultValue()
		{
			m_Show = true;
			m_GridIndex = -1;
			m_Shape = Shape.Polygon;
			m_Radius = 0.35f;
			m_SplitNumber = 5;
			m_Indicator = true;
			m_IndicatorList = new List<Indicator>(5)
			{
				new Indicator
				{
					name = "indicator1",
					max = 0.0
				},
				new Indicator
				{
					name = "indicator2",
					max = 0.0
				},
				new Indicator
				{
					name = "indicator3",
					max = 0.0
				},
				new Indicator
				{
					name = "indicator4",
					max = 0.0
				},
				new Indicator
				{
					name = "indicator5",
					max = 0.0
				}
			};
			center[0] = 0.5f;
			center[1] = 0.4f;
			splitLine.show = true;
			splitArea.show = true;
			axisName.show = true;
			axisName.name = null;
		}

		private bool IsEqualsIndicatorList(List<Indicator> indicators1, List<Indicator> indicators2)
		{
			if (indicators1.Count != indicators2.Count)
			{
				return false;
			}
			for (int i = 0; i < indicators1.Count; i++)
			{
				Indicator obj = indicators1[i];
				Indicator obj2 = indicators2[i];
				if (!obj.Equals(obj2))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsInIndicatorRange(int index, double value)
		{
			return GetIndicator(index)?.IsInRange(value) ?? true;
		}

		public double GetIndicatorMin(int index)
		{
			if (index >= 0 && index < m_IndicatorList.Count)
			{
				return m_IndicatorList[index].min;
			}
			return 0.0;
		}

		public double GetIndicatorMax(int index)
		{
			if (index >= 0 && index < m_IndicatorList.Count)
			{
				return m_IndicatorList[index].max;
			}
			return 0.0;
		}

		internal void UpdateRadarCenter(BaseChart chart)
		{
			if (center.Length < 2)
			{
				return;
			}
			Vector3 position = chart.chartPosition;
			float width = chart.chartWidth;
			float height = chart.chartHeight;
			if (gridIndex >= 0)
			{
				GridLayout chartComponent = chart.GetChartComponent<GridLayout>();
				if (chartComponent != null)
				{
					chartComponent.UpdateRuntimeData(chart);
					chartComponent.UpdateGridContext(gridIndex, ref position, ref width, ref height);
				}
			}
			float x = ((center[0] <= 1f) ? (width * center[0]) : center[0]);
			float y = ((center[1] <= 1f) ? (height * center[1]) : center[1]);
			context.center = position + new Vector3(x, y);
			if (radius <= 0f)
			{
				context.radius = 0f;
			}
			else if (radius <= 1f)
			{
				context.radius = Mathf.Min(width, height) * radius;
			}
			else
			{
				context.radius = radius;
			}
			if (shape == Shape.Polygon && positionType == PositionType.Between)
			{
				float f = MathF.PI / (float)indicatorList.Count;
				context.dataRadius = context.radius * Mathf.Cos(f);
			}
			else
			{
				context.dataRadius = context.radius;
			}
		}

		public Vector3 GetIndicatorPosition(int index)
		{
			int count = indicatorList.Count;
			float num = 0f;
			switch (positionType)
			{
			case PositionType.Vertice:
				num = MathF.PI * 2f / (float)count * (float)index;
				break;
			case PositionType.Between:
				num = MathF.PI * 2f / (float)count * ((float)index + 0.5f);
				break;
			}
			num += startAngle * MathF.PI / 180f;
			float x = context.center.x + (context.radius + indicatorGap) * Mathf.Sin(num);
			float y = context.center.y + (context.radius + indicatorGap) * Mathf.Cos(num);
			return new Vector3(x, y);
		}

		public void AddIndicator(Indicator indicator)
		{
			indicatorList.Add(indicator);
			SetAllDirty();
		}

		public Indicator AddIndicator(string name, double min, double max)
		{
			Indicator indicator = new Indicator();
			indicator.name = name;
			indicator.min = min;
			indicator.max = max;
			indicatorList.Add(indicator);
			SetAllDirty();
			return indicator;
		}

		[Since("v3.3.0")]
		public void AddIndicatorList(List<string> nameList, double min = 0.0, double max = 0.0)
		{
			foreach (string name in nameList)
			{
				AddIndicator(name, min, max);
			}
		}

		public bool UpdateIndicator(int indicatorIndex, string name, double min, double max)
		{
			Indicator indicator = GetIndicator(indicatorIndex);
			if (indicator == null)
			{
				return false;
			}
			indicator.name = name;
			indicator.min = min;
			indicator.max = max;
			SetAllDirty();
			return true;
		}

		public Indicator GetIndicator(int indicatorIndex)
		{
			if (indicatorIndex < 0 || indicatorIndex > indicatorList.Count - 1)
			{
				return null;
			}
			return indicatorList[indicatorIndex];
		}

		public string GetIndicatorName(int indicatorIndex)
		{
			Indicator indicator = GetIndicator(indicatorIndex);
			if (indicator == null)
			{
				return string.Empty;
			}
			return indicator.name;
		}

		public override void ClearData()
		{
			indicatorList.Clear();
		}

		public string GetFormatterIndicatorContent(int indicatorIndex)
		{
			Indicator indicator = GetIndicator(indicatorIndex);
			if (indicator == null)
			{
				return string.Empty;
			}
			return GetFormatterIndicatorContent(indicator.name);
		}

		public string GetFormatterIndicatorContent(string indicatorName)
		{
			if (string.IsNullOrEmpty(indicatorName))
			{
				return indicatorName;
			}
			if (string.IsNullOrEmpty(m_AxisName.labelStyle.formatter))
			{
				return indicatorName;
			}
			string content = m_AxisName.labelStyle.formatter;
			FormatterHelper.ReplaceAxisLabelContent(ref content, indicatorName);
			return content;
		}
	}
}
