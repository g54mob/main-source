using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class Serie : BaseSerie, IComparable
	{
		[SerializeField]
		private int m_Index;

		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private string m_CoordSystem = "GridCoord";

		[SerializeField]
		private string m_SerieType = "";

		[SerializeField]
		private string m_SerieName;

		[SerializeField]
		[Since("v3.2.0")]
		private SerieState m_State;

		[SerializeField]
		[Since("v3.2.0")]
		private SerieColorBy m_ColorBy;

		[SerializeField]
		private string m_Stack;

		[SerializeField]
		private int m_XAxisIndex;

		[SerializeField]
		private int m_YAxisIndex;

		[SerializeField]
		private int m_RadarIndex;

		[SerializeField]
		private int m_VesselIndex;

		[SerializeField]
		private int m_PolarIndex;

		[SerializeField]
		private int m_SingleAxisIndex;

		[SerializeField]
		private int m_ParallelIndex;

		[SerializeField]
		[Since("v3.8.0")]
		private int m_GridIndex = -1;

		[SerializeField]
		protected int m_MinShow;

		[SerializeField]
		protected int m_MaxShow;

		[SerializeField]
		protected int m_MaxCache;

		[SerializeField]
		private float m_SampleDist;

		[SerializeField]
		private SampleType m_SampleType = SampleType.Average;

		[SerializeField]
		private float m_SampleAverage;

		[SerializeField]
		private LineType m_LineType;

		[SerializeField]
		[Since("v3.4.0")]
		private bool m_SmoothLimit;

		[SerializeField]
		private BarType m_BarType;

		[SerializeField]
		private bool m_BarPercentStack;

		[SerializeField]
		private float m_BarWidth;

		[SerializeField]
		[Since("v3.5.0")]
		private float m_BarMaxWidth;

		[SerializeField]
		private float m_BarGap = 0.1f;

		[SerializeField]
		private float m_BarZebraWidth = 4f;

		[SerializeField]
		private float m_BarZebraGap = 2f;

		[SerializeField]
		private float m_Min;

		[SerializeField]
		private float m_Max;

		[SerializeField]
		private float m_MinSize;

		[SerializeField]
		private float m_MaxSize = 1f;

		[SerializeField]
		private float m_StartAngle;

		[SerializeField]
		private float m_EndAngle;

		[SerializeField]
		private float m_MinAngle;

		[SerializeField]
		private bool m_Clockwise = true;

		[SerializeField]
		private bool m_RoundCap;

		[SerializeField]
		private int m_SplitNumber;

		[SerializeField]
		private bool m_ClickOffset = true;

		[SerializeField]
		private RoseType m_RoseType;

		[SerializeField]
		private float m_Gap;

		[SerializeField]
		private float[] m_Center = new float[2] { 0.5f, 0.48f };

		[SerializeField]
		private float[] m_Radius = new float[2] { 0f, 0.28f };

		[SerializeField]
		[Since("v3.8.0")]
		private float m_MinRadius;

		[SerializeField]
		[Range(2f, 10f)]
		private int m_ShowDataDimension;

		[SerializeField]
		private bool m_ShowDataName;

		[SerializeField]
		private bool m_Clip;

		[SerializeField]
		private bool m_Ignore;

		[SerializeField]
		private double m_IgnoreValue;

		[SerializeField]
		private bool m_IgnoreLineBreak;

		[SerializeField]
		private bool m_ShowAsPositiveNumber;

		[SerializeField]
		private bool m_Large = true;

		[SerializeField]
		private int m_LargeThreshold = 200;

		[SerializeField]
		private bool m_AvoidLabelOverlap;

		[SerializeField]
		private RadarType m_RadarType;

		[SerializeField]
		private bool m_PlaceHolder;

		[SerializeField]
		private SerieDataSortType m_DataSortType = SerieDataSortType.Descending;

		[SerializeField]
		private Orient m_Orient = Orient.Vertical;

		[SerializeField]
		private Align m_Align;

		[SerializeField]
		private float m_Left;

		[SerializeField]
		private float m_Right;

		[SerializeField]
		private float m_Top;

		[SerializeField]
		private float m_Bottom;

		[SerializeField]
		private bool m_InsertDataToHead;

		[SerializeField]
		private LineStyle m_LineStyle = new LineStyle();

		[SerializeField]
		private SerieSymbol m_Symbol = new SerieSymbol();

		[SerializeField]
		private AnimationStyle m_Animation = new AnimationStyle();

		[SerializeField]
		private ItemStyle m_ItemStyle = new ItemStyle();

		[SerializeField]
		private List<SerieData> m_Data = new List<SerieData>();

		[NonSerialized]
		internal int m_FilterStart;

		[NonSerialized]
		internal int m_FilterEnd;

		[NonSerialized]
		internal double m_FilterStartValue;

		[NonSerialized]
		internal double m_FilterEndValue;

		[NonSerialized]
		internal int m_FilterMinShow;

		[NonSerialized]
		internal bool m_NeedUpdateFilterData;

		[NonSerialized]
		public List<SerieData> m_FilterData = new List<SerieData>();

		[NonSerialized]
		private bool m_NameDirty;

		public static Dictionary<Type, string> extraComponentMap = new Dictionary<Type, string>
		{
			{
				typeof(LabelStyle),
				"m_Labels"
			},
			{
				typeof(LabelLine),
				"m_LabelLines"
			},
			{
				typeof(EndLabelStyle),
				"m_EndLabels"
			},
			{
				typeof(LineArrow),
				"m_LineArrows"
			},
			{
				typeof(AreaStyle),
				"m_AreaStyles"
			},
			{
				typeof(TitleStyle),
				"m_TitleStyles"
			},
			{
				typeof(EmphasisStyle),
				"m_EmphasisStyles"
			},
			{
				typeof(BlurStyle),
				"m_BlurStyles"
			},
			{
				typeof(SelectStyle),
				"m_SelectStyles"
			}
		};

		[SerializeField]
		[IgnoreDoc]
		private List<LabelStyle> m_Labels = new List<LabelStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<LabelLine> m_LabelLines = new List<LabelLine>();

		[SerializeField]
		[IgnoreDoc]
		private List<EndLabelStyle> m_EndLabels = new List<EndLabelStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<LineArrow> m_LineArrows = new List<LineArrow>();

		[SerializeField]
		[IgnoreDoc]
		private List<AreaStyle> m_AreaStyles = new List<AreaStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<TitleStyle> m_TitleStyles = new List<TitleStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<EmphasisStyle> m_EmphasisStyles = new List<EmphasisStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<BlurStyle> m_BlurStyles = new List<BlurStyle>();

		[SerializeField]
		[IgnoreDoc]
		private List<SelectStyle> m_SelectStyles = new List<SelectStyle>();

		public Action<SerieEventData> onClick { get; set; }

		public Action<SerieEventData> onDown { get; set; }

		public Action<SerieEventData> onEnter { get; set; }

		public Action<SerieEventData> onExit { get; set; }

		public int index
		{
			get
			{
				return m_Index;
			}
			internal set
			{
				m_Index = value;
			}
		}

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
					SetVerticesDirty();
					SetSerieNameDirty();
				}
			}
		}

		public string coordSystem
		{
			get
			{
				return m_CoordSystem;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_CoordSystem, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public string serieType
		{
			get
			{
				return m_SerieType;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SerieType, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public string serieName
		{
			get
			{
				return m_SerieName;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_SerieName, value))
				{
					SetVerticesDirty();
					SetSerieNameDirty();
				}
			}
		}

		public string legendName
		{
			get
			{
				if (!string.IsNullOrEmpty(serieName))
				{
					return serieName;
				}
				return ChartCached.IntToStr(index);
			}
		}

		public SerieState state
		{
			get
			{
				return m_State;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_State, value))
				{
					SetAllDirty();
				}
			}
		}

		public SerieColorBy colorBy
		{
			get
			{
				if (m_ColorBy != SerieColorBy.Default)
				{
					return m_ColorBy;
				}
				return defaultColorBy;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ColorBy, value))
				{
					SetAllDirty();
				}
			}
		}

		public string stack
		{
			get
			{
				return m_Stack;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Stack, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int xAxisIndex
		{
			get
			{
				return m_XAxisIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_XAxisIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int yAxisIndex
		{
			get
			{
				return m_YAxisIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_YAxisIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int radarIndex
		{
			get
			{
				return m_RadarIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_RadarIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int vesselIndex
		{
			get
			{
				return m_VesselIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_VesselIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int polarIndex
		{
			get
			{
				return m_PolarIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_PolarIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int singleAxisIndex
		{
			get
			{
				return m_SingleAxisIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SingleAxisIndex, value))
				{
					SetAllDirty();
				}
			}
		}

		public int parallelIndex
		{
			get
			{
				return m_ParallelIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ParallelIndex, value))
				{
					SetAllDirty();
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
					SetAllDirty();
				}
			}
		}

		public int minShow
		{
			get
			{
				return m_MinShow;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MinShow, (value >= 0) ? value : 0))
				{
					SetVerticesDirty();
				}
			}
		}

		public int maxShow
		{
			get
			{
				return m_MaxShow;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MaxShow, (value >= 0) ? value : 0))
				{
					SetVerticesDirty();
				}
			}
		}

		public int maxCache
		{
			get
			{
				return m_MaxCache;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MaxCache, (value >= 0) ? value : 0))
				{
					SetVerticesDirty();
				}
			}
		}

		public SerieSymbol symbol
		{
			get
			{
				return m_Symbol;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Symbol, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public LineType lineType
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

		public bool smoothLimit
		{
			get
			{
				return m_SmoothLimit;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SmoothLimit, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float sampleDist
		{
			get
			{
				return m_SampleDist;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SampleDist, (value < 0f) ? 0f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public SampleType sampleType
		{
			get
			{
				return m_SampleType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SampleType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float sampleAverage
		{
			get
			{
				return m_SampleAverage;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SampleAverage, value))
				{
					SetVerticesDirty();
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
				if (PropertyUtil.SetClass(ref m_LineStyle, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public BarType barType
		{
			get
			{
				return m_BarType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BarType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool barPercentStack
		{
			get
			{
				return m_BarPercentStack;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BarPercentStack, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float barWidth
		{
			get
			{
				return m_BarWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BarWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float barMaxWidth
		{
			get
			{
				return m_BarMaxWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BarMaxWidth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float barGap
		{
			get
			{
				return m_BarGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BarGap, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float barZebraWidth
		{
			get
			{
				return m_BarZebraWidth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BarZebraWidth, (value < 0f) ? 0f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float barZebraGap
		{
			get
			{
				return m_BarZebraGap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BarZebraGap, (value < 0f) ? 0f : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool pieClickOffset
		{
			get
			{
				return m_ClickOffset;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ClickOffset, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public RoseType pieRoseType
		{
			get
			{
				return m_RoseType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_RoseType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float gap
		{
			get
			{
				return m_Gap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Gap, value))
				{
					SetVerticesDirty();
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
				if (value != null && value.Length == 2)
				{
					m_Center = value;
					SetVerticesDirty();
				}
			}
		}

		public float[] radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				if (value != null && value.Length == 2)
				{
					m_Radius = value;
					SetVerticesDirty();
				}
			}
		}

		public float minRadius
		{
			get
			{
				return m_MinRadius;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MinRadius, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float min
		{
			get
			{
				return m_Min;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Min, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float max
		{
			get
			{
				return m_Max;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Max, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float minSize
		{
			get
			{
				return m_MinSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MinSize, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float maxSize
		{
			get
			{
				return m_MaxSize;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MaxSize, value))
				{
					SetVerticesDirty();
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

		public float endAngle
		{
			get
			{
				return m_EndAngle;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_EndAngle, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public float minAngle
		{
			get
			{
				return m_MinAngle;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_MinAngle, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool clockwise
		{
			get
			{
				return m_Clockwise;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Clockwise, value))
				{
					SetVerticesDirty();
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
				if (PropertyUtil.SetStruct(ref m_SplitNumber, (value > 36) ? 36 : value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool roundCap
		{
			get
			{
				return m_RoundCap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_RoundCap, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool ignore
		{
			get
			{
				return m_Ignore;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Ignore, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public double ignoreValue
		{
			get
			{
				return m_IgnoreValue;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_IgnoreValue, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool ignoreLineBreak
		{
			get
			{
				return m_IgnoreLineBreak;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_IgnoreLineBreak, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public RadarType radarType
		{
			get
			{
				return m_RadarType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_RadarType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public AnimationStyle animation
		{
			get
			{
				return m_Animation;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Animation, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public ItemStyle itemStyle
		{
			get
			{
				return m_ItemStyle;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_ItemStyle, value, notNull: true))
				{
					SetVerticesDirty();
				}
			}
		}

		public int showDataDimension
		{
			get
			{
				return m_ShowDataDimension;
			}
			set
			{
				m_ShowDataDimension = Mathf.Clamp(2, 10, value);
			}
		}

		public bool showDataName
		{
			get
			{
				return m_ShowDataName;
			}
			set
			{
				m_ShowDataName = value;
			}
		}

		public bool clip
		{
			get
			{
				return m_Clip;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Clip, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showAsPositiveNumber
		{
			get
			{
				return m_ShowAsPositiveNumber;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowAsPositiveNumber, value))
				{
					SetComponentDirty();
				}
			}
		}

		public bool large
		{
			get
			{
				return m_Large;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Large, value))
				{
					SetAllDirty();
				}
			}
		}

		public int largeThreshold
		{
			get
			{
				return m_LargeThreshold;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_LargeThreshold, value))
				{
					SetAllDirty();
				}
			}
		}

		public bool avoidLabelOverlap
		{
			get
			{
				return m_AvoidLabelOverlap;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_AvoidLabelOverlap, value))
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
					SetAllDirty();
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
					SetAllDirty();
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
					SetAllDirty();
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
					SetAllDirty();
				}
			}
		}

		public bool insertDataToHead
		{
			get
			{
				return m_InsertDataToHead;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_InsertDataToHead, value))
				{
					SetAllDirty();
				}
			}
		}

		public SerieDataSortType dataSortType
		{
			get
			{
				return m_DataSortType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_DataSortType, value))
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

		public Align align
		{
			get
			{
				return m_Align;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Align, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool placeHolder
		{
			get
			{
				return m_PlaceHolder;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_PlaceHolder, value))
				{
					SetAllDirty();
				}
			}
		}

		public List<SerieData> data => m_Data;

		public bool colorByData => colorBy == SerieColorBy.Data;

		public override bool vertsDirty
		{
			get
			{
				if (!m_VertsDirty && !symbol.vertsDirty && !lineStyle.vertsDirty && !itemStyle.vertsDirty && !BaseSerie.IsVertsDirty(lineArrow) && !BaseSerie.IsVertsDirty(areaStyle) && !BaseSerie.IsVertsDirty(label) && !BaseSerie.IsVertsDirty(labelLine) && !BaseSerie.IsVertsDirty(titleStyle) && !BaseSerie.IsVertsDirty(emphasisStyle) && !BaseSerie.IsVertsDirty(blurStyle) && !BaseSerie.IsVertsDirty(selectStyle))
				{
					return AnySerieDataVerticesDirty();
				}
				return true;
			}
		}

		public override bool componentDirty
		{
			get
			{
				if (!m_ComponentDirty && !symbol.componentDirty && !BaseSerie.IsComponentDirty(titleStyle) && !BaseSerie.IsComponentDirty(label) && !BaseSerie.IsComponentDirty(labelLine) && !BaseSerie.IsComponentDirty(emphasisStyle) && !BaseSerie.IsComponentDirty(blurStyle))
				{
					return BaseSerie.IsComponentDirty(selectStyle);
				}
				return true;
			}
		}

		public bool highlight { get; internal set; }

		public int dataCount => m_Data.Count;

		public bool nameDirty => m_NameDirty;

		public bool labelDirty { get; set; }

		public bool titleDirty { get; set; }

		public bool dataDirty { get; set; }

		public bool interactDirty { get; set; }

		public double yMax
		{
			get
			{
				double num = double.MinValue;
				foreach (SerieData datum in data)
				{
					if (datum.show && !IsIgnoreValue(datum, datum.data[1]) && datum.data[1] > num)
					{
						num = datum.data[1];
					}
				}
				return num;
			}
		}

		public double xMax
		{
			get
			{
				double num = double.MinValue;
				foreach (SerieData datum in data)
				{
					if (datum.show && !IsIgnoreValue(datum, datum.data[0]) && datum.data[0] > num)
					{
						num = datum.data[0];
					}
				}
				return num;
			}
		}

		public double yMin
		{
			get
			{
				double num = double.MaxValue;
				foreach (SerieData datum in data)
				{
					if (datum.show && !IsIgnoreValue(datum, datum.data[1]) && datum.data[1] < num)
					{
						num = datum.data[1];
					}
				}
				return num;
			}
		}

		public double xMin
		{
			get
			{
				double num = double.MaxValue;
				foreach (SerieData datum in data)
				{
					if (datum.show && !IsIgnoreValue(datum, datum.data[0]) && datum.data[0] < num)
					{
						num = datum.data[0];
					}
				}
				return num;
			}
		}

		public double yTotal
		{
			get
			{
				double num = 0.0;
				if (IsPerformanceMode())
				{
					foreach (SerieData datum in data)
					{
						if (datum.show && !IsIgnoreValue(datum, datum.data[1]))
						{
							num += datum.data[1];
						}
					}
				}
				else
				{
					float changeDuration = animation.GetChangeDuration();
					float additionDuration = animation.GetAdditionDuration();
					bool unscaledTime = animation.unscaledTime;
					foreach (SerieData datum2 in data)
					{
						if (datum2.show && !IsIgnoreValue(datum2, datum2.data[1]))
						{
							num += datum2.GetCurrData(1, additionDuration, changeDuration, unscaledTime);
						}
					}
				}
				return num;
			}
		}

		public double xTotal
		{
			get
			{
				double num = 0.0;
				foreach (SerieData datum in data)
				{
					if (datum.show && !IsIgnoreValue(datum, datum.data[1]))
					{
						num += datum.data[0];
					}
				}
				return num;
			}
		}

		public AreaStyle areaStyle
		{
			get
			{
				if (m_AreaStyles.Count <= 0)
				{
					return null;
				}
				return m_AreaStyles[0];
			}
		}

		public LabelStyle label
		{
			get
			{
				if (m_Labels.Count <= 0)
				{
					return null;
				}
				return m_Labels[0];
			}
		}

		public LabelStyle endLabel
		{
			get
			{
				if (m_EndLabels.Count <= 0)
				{
					return null;
				}
				return m_EndLabels[0];
			}
		}

		public LabelLine labelLine
		{
			get
			{
				if (m_LabelLines.Count <= 0)
				{
					return null;
				}
				return m_LabelLines[0];
			}
		}

		public LineArrow lineArrow
		{
			get
			{
				if (m_LineArrows.Count <= 0)
				{
					return null;
				}
				return m_LineArrows[0];
			}
		}

		public TitleStyle titleStyle
		{
			get
			{
				if (m_TitleStyles.Count <= 0)
				{
					return null;
				}
				return m_TitleStyles[0];
			}
		}

		public EmphasisStyle emphasisStyle
		{
			get
			{
				if (m_EmphasisStyles.Count <= 0)
				{
					return null;
				}
				return m_EmphasisStyles[0];
			}
		}

		public BlurStyle blurStyle
		{
			get
			{
				if (m_BlurStyles.Count <= 0)
				{
					return null;
				}
				return m_BlurStyles[0];
			}
		}

		public SelectStyle selectStyle
		{
			get
			{
				if (m_SelectStyles.Count <= 0)
				{
					return null;
				}
				return m_SelectStyles[0];
			}
		}

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			if (!IsPerformanceMode())
			{
				foreach (SerieData datum in m_Data)
				{
					datum.ClearVerticesDirty();
				}
			}
			symbol.ClearVerticesDirty();
			lineStyle.ClearVerticesDirty();
			itemStyle.ClearVerticesDirty();
			BaseSerie.ClearVerticesDirty(areaStyle);
			BaseSerie.ClearVerticesDirty(label);
			BaseSerie.ClearVerticesDirty(emphasisStyle);
			BaseSerie.ClearVerticesDirty(blurStyle);
			BaseSerie.ClearVerticesDirty(selectStyle);
			BaseSerie.ClearVerticesDirty(lineArrow);
			BaseSerie.ClearVerticesDirty(titleStyle);
		}

		public override void ClearComponentDirty()
		{
			base.ClearComponentDirty();
			if (!IsPerformanceMode())
			{
				foreach (SerieData datum in m_Data)
				{
					datum.ClearComponentDirty();
				}
			}
			symbol.ClearComponentDirty();
			lineStyle.ClearComponentDirty();
			itemStyle.ClearComponentDirty();
			BaseSerie.ClearComponentDirty(areaStyle);
			BaseSerie.ClearComponentDirty(label);
			BaseSerie.ClearComponentDirty(emphasisStyle);
			BaseSerie.ClearComponentDirty(blurStyle);
			BaseSerie.ClearComponentDirty(selectStyle);
			BaseSerie.ClearComponentDirty(lineArrow);
			BaseSerie.ClearComponentDirty(titleStyle);
		}

		public override void SetAllDirty()
		{
			base.SetAllDirty();
			labelDirty = true;
			titleDirty = true;
		}

		public override void SetVerticesDirty()
		{
			base.SetVerticesDirty();
			interactDirty = true;
		}

		private bool AnySerieDataVerticesDirty()
		{
			if (IsPerformanceMode())
			{
				return false;
			}
			if (this is ISimplifiedSerie)
			{
				return false;
			}
			foreach (SerieData datum in m_Data)
			{
				if (datum.vertsDirty)
				{
					return true;
				}
			}
			return false;
		}

		private bool AnySerieDataComponentDirty()
		{
			if (IsPerformanceMode())
			{
				return false;
			}
			if (this is ISimplifiedSerie)
			{
				return false;
			}
			foreach (SerieData datum in m_Data)
			{
				if (datum.componentDirty)
				{
					return true;
				}
			}
			return false;
		}

		private void SetSerieNameDirty()
		{
			m_NameDirty = true;
		}

		public void ClearSerieNameDirty()
		{
			m_NameDirty = false;
		}

		public override void ClearDirty()
		{
			base.ClearDirty();
		}

		public void ResetInteract()
		{
			interact.Reset();
			foreach (SerieData datum in m_Data)
			{
				datum.interact.Reset();
			}
		}

		public bool ResetDataIndex()
		{
			bool result = false;
			for (int i = 0; i < m_Data.Count; i++)
			{
				if (m_Data[i].index != i)
				{
					m_Data[i].index = i;
					result = true;
				}
			}
			return result;
		}

		public override void ClearData()
		{
			while (m_Data.Count > 0)
			{
				RemoveData(0);
			}
			m_Data.Clear();
			m_NeedUpdateFilterData = true;
			dataDirty = true;
			SetVerticesDirty();
		}

		public void RemoveData(int index)
		{
			if (index >= 0 && index < m_Data.Count)
			{
				if (!string.IsNullOrEmpty(m_Data[index].name))
				{
					SetSerieNameDirty();
				}
				SetVerticesDirty();
				SerieData serieData = m_Data[index];
				SerieDataPool.Release(serieData);
				if (serieData.labelObject != null)
				{
					SerieLabelPool.Release(serieData.labelObject.gameObject);
				}
				m_Data.RemoveAt(index);
				m_NeedUpdateFilterData = true;
				labelDirty = true;
				dataDirty = true;
			}
		}

		public SerieData AddYData(double value, string dataName = null, string dataId = null)
		{
			CheckMaxCache();
			int count = m_Data.Count;
			SerieData serieData = SerieDataPool.Get();
			serieData.data.Add(count);
			serieData.data.Add(value);
			serieData.name = dataName;
			serieData.index = count;
			serieData.id = dataId;
			AddSerieData(serieData);
			m_ShowDataDimension = 2;
			SetVerticesDirty();
			CheckDataName(dataName);
			labelDirty = true;
			dataDirty = true;
			return serieData;
		}

		public void AddSerieData(SerieData serieData)
		{
			if (m_InsertDataToHead)
			{
				m_Data.Insert(0, serieData);
			}
			else
			{
				m_Data.Add(serieData);
			}
			serieData.OnAdd(animation);
			context.totalDataIndex++;
			SetVerticesDirty();
			dataDirty = true;
			m_NeedUpdateFilterData = true;
		}

		private void CheckDataName(string dataName)
		{
			if (string.IsNullOrEmpty(dataName))
			{
				SetSerieNameDirty();
			}
			else
			{
				m_ShowDataName = true;
			}
		}

		public SerieData AddXYData(double xValue, double yValue, string dataName = null, string dataId = null)
		{
			CheckMaxCache();
			SerieData serieData = SerieDataPool.Get();
			serieData.data.Clear();
			serieData.data.Add(xValue);
			serieData.data.Add(yValue);
			serieData.name = dataName;
			serieData.index = m_Data.Count;
			serieData.id = dataId;
			AddSerieData(serieData);
			m_ShowDataDimension = 2;
			SetVerticesDirty();
			CheckDataName(dataName);
			labelDirty = true;
			return serieData;
		}

		public SerieData AddData(double indexOrTimestamp, double open, double close, double lowest, double heighest, string dataName = null, string dataId = null)
		{
			CheckMaxCache();
			SerieData serieData = SerieDataPool.Get();
			serieData.data.Clear();
			serieData.data.Add(indexOrTimestamp);
			serieData.data.Add(open);
			serieData.data.Add(close);
			serieData.data.Add(lowest);
			serieData.data.Add(heighest);
			serieData.name = dataName;
			serieData.index = m_Data.Count;
			serieData.id = dataId;
			AddSerieData(serieData);
			m_ShowDataDimension = 5;
			SetVerticesDirty();
			CheckDataName(dataName);
			labelDirty = true;
			return serieData;
		}

		public SerieData AddData(List<double> valueList, string dataName = null, string dataId = null)
		{
			if (valueList == null || valueList.Count == 0)
			{
				return null;
			}
			if (valueList.Count == 1)
			{
				return AddYData(valueList[0], dataName, dataId);
			}
			if (valueList.Count == 2)
			{
				return AddXYData(valueList[0], valueList[1], dataName, dataId);
			}
			CheckMaxCache();
			m_ShowDataDimension = valueList.Count;
			SerieData serieData = SerieDataPool.Get();
			serieData.name = dataName;
			serieData.index = m_Data.Count;
			serieData.id = dataId;
			for (int i = 0; i < valueList.Count; i++)
			{
				serieData.data.Add(valueList[i]);
			}
			AddSerieData(serieData);
			SetVerticesDirty();
			CheckDataName(dataName);
			labelDirty = true;
			return serieData;
		}

		public SerieData AddData(params double[] values)
		{
			if (values == null || values.Length == 0)
			{
				return null;
			}
			string text = null;
			string text2 = null;
			if (values.Length == 1)
			{
				return AddYData(values[0], text, text2);
			}
			if (values.Length == 2)
			{
				return AddXYData(values[0], values[1], text, text2);
			}
			CheckMaxCache();
			m_ShowDataDimension = values.Length;
			SerieData serieData = SerieDataPool.Get();
			serieData.name = text;
			serieData.index = m_Data.Count;
			serieData.id = text2;
			for (int i = 0; i < values.Length; i++)
			{
				serieData.data.Add(values[i]);
			}
			AddSerieData(serieData);
			SetVerticesDirty();
			CheckDataName(text);
			labelDirty = true;
			return serieData;
		}

		public SerieData AddChildData(SerieData parent, double value, string name, string id)
		{
			SerieData serieData = new SerieData();
			serieData.name = name;
			serieData.index = m_Data.Count;
			serieData.id = id;
			serieData.data.Add(m_Data.Count);
			serieData.data.Add(value);
			AddChildData(parent, serieData);
			return serieData;
		}

		public SerieData AddChildData(SerieData parent, List<double> value, string name, string id)
		{
			SerieData serieData = new SerieData();
			serieData.name = name;
			serieData.index = m_Data.Count;
			serieData.id = id;
			serieData.data.AddRange(value);
			AddChildData(parent, serieData);
			return serieData;
		}

		public void AddChildData(SerieData parent, SerieData serieData)
		{
			serieData.parentId = parent.id;
			serieData.context.parent = parent;
			if (!m_Data.Contains(serieData))
			{
				AddSerieData(serieData);
			}
			if (!parent.context.children.Contains(serieData))
			{
				parent.context.children.Add(serieData);
			}
		}

		private void CheckMaxCache()
		{
			if (m_MaxCache <= 0)
			{
				return;
			}
			while (m_Data.Count >= m_MaxCache)
			{
				m_NeedUpdateFilterData = true;
				if (m_InsertDataToHead)
				{
					RemoveData(m_Data.Count - 1);
				}
				else
				{
					RemoveData(0);
				}
			}
		}

		public double GetData(int index, int dimension, DataZoom dataZoom = null)
		{
			if (index < 0 || dimension < 0)
			{
				return 0.0;
			}
			SerieData serieData = GetSerieData(index, dataZoom);
			if (serieData != null && dimension < serieData.data.Count)
			{
				double num = serieData.GetData(dimension);
				if (showAsPositiveNumber)
				{
					num = Math.Abs(num);
				}
				return num;
			}
			return 0.0;
		}

		public double GetYData(int index, DataZoom dataZoom = null)
		{
			if (index < 0)
			{
				return 0.0;
			}
			List<SerieData> dataList = GetDataList(dataZoom);
			if (index < dataList.Count)
			{
				double num = dataList[index].data[1];
				if (showAsPositiveNumber)
				{
					num = Math.Abs(num);
				}
				return num;
			}
			return 0.0;
		}

		public double GetYCurrData(int index, DataZoom dataZoom = null)
		{
			if (index < 0)
			{
				return 0.0;
			}
			List<SerieData> dataList = GetDataList(dataZoom);
			if (index < dataList.Count)
			{
				double num = dataList[index].GetCurrData(1, 0f, animation.GetChangeDuration(), animation.unscaledTime);
				if (showAsPositiveNumber)
				{
					num = Math.Abs(num);
				}
				return num;
			}
			return 0.0;
		}

		public void GetYData(int index, out double yData, out string dataName, DataZoom dataZoom = null)
		{
			yData = 0.0;
			dataName = null;
			if (index < 0)
			{
				return;
			}
			List<SerieData> dataList = GetDataList(dataZoom);
			if (index < dataList.Count)
			{
				yData = dataList[index].data[1];
				if (showAsPositiveNumber)
				{
					yData = Math.Abs(yData);
				}
				dataName = dataList[index].name;
			}
		}

		public SerieData GetSerieData(int index, DataZoom dataZoom = null)
		{
			List<SerieData> dataList = GetDataList(dataZoom);
			if (index >= 0 && index <= dataList.Count - 1)
			{
				return dataList[index];
			}
			return null;
		}

		public SerieData GetSerieData(string id, DataZoom dataZoom = null)
		{
			foreach (SerieData data in GetDataList(dataZoom))
			{
				SerieData serieData = GetSerieData(data, id);
				if (serieData != null)
				{
					return serieData;
				}
			}
			return null;
		}

		public SerieData GetSerieData(SerieData parent, string id)
		{
			if (id.Equals(parent.id))
			{
				return parent;
			}
			foreach (SerieData child in parent.context.children)
			{
				SerieData serieData = GetSerieData(child, id);
				if (serieData != null)
				{
					return serieData;
				}
			}
			return null;
		}

		public void GetXYData(int index, DataZoom dataZoom, out double xValue, out double yVlaue)
		{
			xValue = 0.0;
			yVlaue = 0.0;
			if (index < 0)
			{
				return;
			}
			List<SerieData> dataList = GetDataList(dataZoom);
			if (index < dataList.Count)
			{
				SerieData serieData = dataList[index];
				xValue = serieData.data[0];
				yVlaue = serieData.data[1];
				if (showAsPositiveNumber)
				{
					xValue = Math.Abs(xValue);
					yVlaue = Math.Abs(yVlaue);
				}
			}
		}

		public virtual double GetDataTotal(int dimension, SerieData serieData = null)
		{
			if (m_Max > 0f)
			{
				return m_Max;
			}
			double num = 0.0;
			foreach (SerieData datum in data)
			{
				if (datum.show)
				{
					num += datum.GetData(dimension);
				}
			}
			return num;
		}

		public List<SerieData> GetDataList(DataZoom dataZoom = null)
		{
			if (dataZoom != null && dataZoom.enable && (dataZoom.IsContainsXAxis(xAxisIndex) || dataZoom.IsContainsYAxis(yAxisIndex)))
			{
				SerieHelper.UpdateFilterData(this, dataZoom);
				return m_FilterData;
			}
			if (!useSortData || context.sortedData.Count <= 0)
			{
				return m_Data;
			}
			return context.sortedData;
		}

		public bool UpdateYData(int index, double value)
		{
			UpdateData(index, 1, value);
			return true;
		}

		public bool UpdateXYData(int index, double xValue, double yValue)
		{
			bool num = UpdateData(index, 0, xValue);
			bool flag = UpdateData(index, 1, yValue);
			return num || flag;
		}

		public bool UpdateData(int index, int dimension, double value)
		{
			if (index >= 0 && index < m_Data.Count)
			{
				bool enable = animation.enable;
				float changeDuration = animation.GetChangeDuration();
				bool unscaledTime = animation.unscaledTime;
				bool num = m_Data[index].UpdateData(dimension, value, enable, unscaledTime, changeDuration);
				if (num)
				{
					SetVerticesDirty();
					dataDirty = true;
				}
				return num;
			}
			return false;
		}

		public bool UpdateData(int index, List<double> values)
		{
			if (index >= 0 && index < m_Data.Count && values != null)
			{
				SerieData serieData = m_Data[index];
				bool enable = animation.enable;
				float changeDuration = animation.GetChangeDuration();
				bool unscaledTime = animation.unscaledTime;
				for (int i = 0; i < values.Count; i++)
				{
					serieData.UpdateData(i, values[i], enable, unscaledTime, changeDuration);
				}
				SetVerticesDirty();
				dataDirty = true;
				return true;
			}
			return false;
		}

		public bool UpdateDataName(int index, string name)
		{
			if (index >= 0 && index < m_Data.Count)
			{
				SerieData serieData = m_Data[index];
				serieData.name = name;
				SetSerieNameDirty();
				if (serieData.labelObject != null)
				{
					serieData.labelObject.SetText((name == null) ? "" : name);
				}
				return true;
			}
			return false;
		}

		public void ClearHighlight()
		{
			highlight = false;
			foreach (SerieData datum in m_Data)
			{
				datum.context.highlight = false;
			}
		}

		public void SetHighlight(int index, bool flag)
		{
			SerieData serieData = GetSerieData(index);
			if (serieData != null)
			{
				serieData.context.highlight = flag;
			}
		}

		public float GetBarWidth(float categoryWidth, int barCount = 0)
		{
			float num = 0f;
			if (categoryWidth < 2f)
			{
				num = categoryWidth;
			}
			else if (m_BarWidth == 0f)
			{
				float actualValue = ChartHelper.GetActualValue(0.6f, categoryWidth);
				num = ((barCount != 0) ? (actualValue / (float)barCount) : ((actualValue < 1f) ? categoryWidth : actualValue));
			}
			else
			{
				num = ChartHelper.GetActualValue(m_BarWidth, categoryWidth);
			}
			if (m_BarMaxWidth == 0f)
			{
				return num;
			}
			float actualValue2 = ChartHelper.GetActualValue(m_BarMaxWidth, categoryWidth);
			if (!(num > actualValue2))
			{
				return num;
			}
			return actualValue2;
		}

		public bool IsIgnoreIndex(int index, int dimension = 1)
		{
			SerieData serieData = GetSerieData(index);
			if (serieData != null)
			{
				return IsIgnoreValue(serieData, dimension);
			}
			return false;
		}

		public bool IsIgnoreValue(SerieData serieData, int dimension = 1)
		{
			return IsIgnoreValue(serieData, serieData.GetData(dimension));
		}

		public bool IsIgnoreValue(double value)
		{
			if (m_Ignore)
			{
				return MathUtil.Approximately(value, m_IgnoreValue);
			}
			return false;
		}

		public bool IsIgnoreValue(SerieData serieData, double value)
		{
			if (!serieData.ignore)
			{
				return IsIgnoreValue(value);
			}
			return true;
		}

		public bool IsIgnorePoint(int index)
		{
			if (index >= 0 && index < dataCount)
			{
				return ChartHelper.IsIngore(data[index].context.position);
			}
			return false;
		}

		public bool IsSerie<T>() where T : Serie
		{
			return this is T;
		}

		public bool IsUseCoord<T>() where T : CoordSystem
		{
			return ChartCached.GetTypeName<T>().Equals(m_CoordSystem);
		}

		public bool SetCoord<T>() where T : CoordSystem
		{
			if (GetType().IsDefined(typeof(CoordOptionsAttribute), inherit: false) && GetType().GetAttribute<CoordOptionsAttribute>().Contains<T>())
			{
				m_CoordSystem = typeof(T).Name;
				return true;
			}
			Debug.LogError("not support coord system:" + typeof(T));
			return false;
		}

		public bool IsPerformanceMode()
		{
			if (m_Large)
			{
				return m_Data.Count >= m_LargeThreshold;
			}
			return false;
		}

		public bool IsLegendName(string legendName)
		{
			if (colorBy == SerieColorBy.Data)
			{
				if (!IsSerieDataLegendName(legendName))
				{
					return IsSerieLegendName(legendName);
				}
				return true;
			}
			return IsSerieLegendName(legendName);
		}

		public bool IsSerieLegendName(string legendName)
		{
			return legendName.Equals(this.legendName);
		}

		public bool IsSerieDataLegendName(string legendName)
		{
			foreach (SerieData datum in m_Data)
			{
				if (legendName.Equals(datum.legendName))
				{
					return true;
				}
			}
			return false;
		}

		public void AnimationEnable(bool flag)
		{
			if (animation.enable)
			{
				animation.enable = flag;
			}
			SetVerticesDirty();
		}

		public void AnimationFadeIn()
		{
			ResetInteract();
			if (animation.enable)
			{
				animation.FadeIn();
			}
			SetVerticesDirty();
		}

		public void AnimationFadeOut()
		{
			ResetInteract();
			if (animation.enable)
			{
				animation.FadeOut();
			}
			SetVerticesDirty();
		}

		public void AnimationPause()
		{
			if (animation.enable)
			{
				animation.Pause();
			}
			SetVerticesDirty();
		}

		public void AnimationResume()
		{
			if (animation.enable)
			{
				animation.Resume();
			}
			SetVerticesDirty();
		}

		public void AnimationReset()
		{
			if (animation.enable)
			{
				animation.Reset();
			}
			SetVerticesDirty();
		}

		public void AnimationRestart()
		{
			if (animation.enable)
			{
				animation.Restart();
			}
			SetVerticesDirty();
		}

		public int CompareTo(object obj)
		{
			return index.CompareTo((obj as Serie).index);
		}

		public T Clone<T>() where T : Serie
		{
			T val = Activator.CreateInstance<T>();
			SerieHelper.CopySerie(this, val);
			return val;
		}

		public Serie Clone()
		{
			Serie serie = Activator.CreateInstance(GetType()) as Serie;
			SerieHelper.CopySerie(this, serie);
			return serie;
		}

		public void RemoveAllComponents()
		{
			Type type = GetType();
			foreach (KeyValuePair<Type, string> item in extraComponentMap)
			{
				ReflectionUtil.InvokeListClear(this, type.GetField(item.Value));
			}
			SetAllDirty();
		}

		[Obsolete("Use EnsureComponent<T>() instead.")]
		public T AddExtraComponent<T>() where T : ChildComponent, ISerieComponent
		{
			return EnsureComponent<T>();
		}

		public T GetComponent<T>() where T : ChildComponent, ISerieComponent
		{
			return GetComponent(typeof(T)) as T;
		}

		public T EnsureComponent<T>() where T : ChildComponent, ISerieComponent
		{
			return EnsureComponent(typeof(T)) as T;
		}

		public bool CanAddComponent<T>() where T : ChildComponent, ISerieComponent
		{
			return CanAddComponent(typeof(T));
		}

		public bool CanAddComponent(Type type)
		{
			if (GetType().IsDefined(typeof(SerieComponentAttribute), inherit: false) && GetType().GetAttribute<SerieComponentAttribute>().Contains(type))
			{
				return true;
			}
			return false;
		}

		public ISerieComponent GetComponent(Type type)
		{
			if (GetType().IsDefined(typeof(SerieComponentAttribute), inherit: false) && GetType().GetAttribute<SerieComponentAttribute>().Contains(type))
			{
				string value = string.Empty;
				if (extraComponentMap.TryGetValue(type, out value))
				{
					FieldInfo field = typeof(Serie).GetField(value, BindingFlags.Instance | BindingFlags.NonPublic);
					if (ReflectionUtil.InvokeListCount(this, field) > 0)
					{
						return ReflectionUtil.InvokeListGet<ISerieComponent>(this, field, 0);
					}
				}
			}
			return null;
		}

		public ISerieComponent EnsureComponent(Type type)
		{
			if (GetType().IsDefined(typeof(SerieComponentAttribute), inherit: false) && GetType().GetAttribute<SerieComponentAttribute>().Contains(type))
			{
				string value = string.Empty;
				if (extraComponentMap.TryGetValue(type, out value))
				{
					FieldInfo field = typeof(Serie).GetField(value, BindingFlags.Instance | BindingFlags.NonPublic);
					if (ReflectionUtil.InvokeListCount(this, field) <= 0)
					{
						ISerieComponent serieComponent = Activator.CreateInstance(type) as ISerieComponent;
						ReflectionUtil.InvokeListAdd(this, field, serieComponent);
						SetAllDirty();
						return serieComponent;
					}
					return ReflectionUtil.InvokeListGet<ISerieComponent>(this, field, 0);
				}
			}
			throw new Exception($"Serie {GetType().Name} not support component: {type.Name}");
		}

		public void RemoveComponent<T>() where T : ISerieComponent
		{
			RemoveComponent(typeof(T));
		}

		public void RemoveComponent(Type type)
		{
			if (GetType().IsDefined(typeof(SerieComponentAttribute), inherit: false) && GetType().GetAttribute<SerieComponentAttribute>().Contains(type))
			{
				string value = string.Empty;
				if (extraComponentMap.TryGetValue(type, out value))
				{
					FieldInfo field = typeof(Serie).GetField(value, BindingFlags.Instance | BindingFlags.NonPublic);
					ReflectionUtil.InvokeListClear(this, field);
					SetAllDirty();
				}
			}
		}
	}
}
