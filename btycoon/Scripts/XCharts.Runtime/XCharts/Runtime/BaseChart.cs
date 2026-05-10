using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[AddComponentMenu("XCharts/EmptyChart", 10)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform), typeof(CanvasRenderer))]
	[DisallowMultipleComponent]
	public class BaseChart : BaseGraph, ISerializationCallbackReceiver
	{
		private static List<MainComponent> list;

		[SerializeField]
		protected string m_ChartName;

		[SerializeField]
		protected ThemeStyle m_Theme = new ThemeStyle();

		[SerializeField]
		protected Settings m_Settings;

		[SerializeField]
		protected DebugInfo m_DebugInfo = new DebugInfo();

		[SerializeField]
		[ListForComponent(typeof(AngleAxis))]
		private List<AngleAxis> m_AngleAxes = new List<AngleAxis>();

		[SerializeField]
		[ListForComponent(typeof(Background))]
		private List<Background> m_Backgrounds = new List<Background>();

		[SerializeField]
		[ListForComponent(typeof(DataZoom))]
		private List<DataZoom> m_DataZooms = new List<DataZoom>();

		[SerializeField]
		[ListForComponent(typeof(GridCoord))]
		private List<GridCoord> m_Grids = new List<GridCoord>();

		[SerializeField]
		[ListForComponent(typeof(GridLayout))]
		private List<GridLayout> m_GridsLayout = new List<GridLayout>();

		[SerializeField]
		[ListForComponent(typeof(Legend))]
		private List<Legend> m_Legends = new List<Legend>();

		[SerializeField]
		[ListForComponent(typeof(MarkLine))]
		private List<MarkLine> m_MarkLines = new List<MarkLine>();

		[SerializeField]
		[ListForComponent(typeof(MarkArea))]
		private List<MarkArea> m_MarkAreas = new List<MarkArea>();

		[SerializeField]
		[ListForComponent(typeof(PolarCoord))]
		private List<PolarCoord> m_Polars = new List<PolarCoord>();

		[SerializeField]
		[ListForComponent(typeof(RadarCoord))]
		private List<RadarCoord> m_Radars = new List<RadarCoord>();

		[SerializeField]
		[ListForComponent(typeof(RadiusAxis))]
		private List<RadiusAxis> m_RadiusAxes = new List<RadiusAxis>();

		[SerializeField]
		[ListForComponent(typeof(Title))]
		private List<Title> m_Titles = new List<Title>();

		[SerializeField]
		[ListForComponent(typeof(Tooltip))]
		private List<Tooltip> m_Tooltips = new List<Tooltip>();

		[SerializeField]
		[ListForComponent(typeof(VisualMap))]
		private List<VisualMap> m_VisualMaps = new List<VisualMap>();

		[SerializeField]
		[ListForComponent(typeof(XAxis))]
		private List<XAxis> m_XAxes = new List<XAxis>();

		[SerializeField]
		[ListForComponent(typeof(YAxis))]
		private List<YAxis> m_YAxes = new List<YAxis>();

		[SerializeField]
		[ListForComponent(typeof(SingleAxis))]
		private List<SingleAxis> m_SingleAxes = new List<SingleAxis>();

		[SerializeField]
		[ListForComponent(typeof(ParallelCoord))]
		private List<ParallelCoord> m_Parallels = new List<ParallelCoord>();

		[SerializeField]
		[ListForComponent(typeof(ParallelAxis))]
		private List<ParallelAxis> m_ParallelAxes = new List<ParallelAxis>();

		[SerializeField]
		[ListForComponent(typeof(Comment))]
		private List<Comment> m_Comments = new List<Comment>();

		[SerializeField]
		[ListForSerie(typeof(Bar))]
		private List<Bar> m_SerieBars = new List<Bar>();

		[SerializeField]
		[ListForSerie(typeof(Candlestick))]
		private List<Candlestick> m_SerieCandlesticks = new List<Candlestick>();

		[SerializeField]
		[ListForSerie(typeof(EffectScatter))]
		private List<EffectScatter> m_SerieEffectScatters = new List<EffectScatter>();

		[SerializeField]
		[ListForSerie(typeof(Heatmap))]
		private List<Heatmap> m_SerieHeatmaps = new List<Heatmap>();

		[SerializeField]
		[ListForSerie(typeof(Line))]
		private List<Line> m_SerieLines = new List<Line>();

		[SerializeField]
		[ListForSerie(typeof(Pie))]
		private List<Pie> m_SeriePies = new List<Pie>();

		[SerializeField]
		[ListForSerie(typeof(Radar))]
		private List<Radar> m_SerieRadars = new List<Radar>();

		[SerializeField]
		[ListForSerie(typeof(Ring))]
		private List<Ring> m_SerieRings = new List<Ring>();

		[SerializeField]
		[ListForSerie(typeof(Scatter))]
		private List<Scatter> m_SerieScatters = new List<Scatter>();

		[SerializeField]
		[ListForSerie(typeof(Parallel))]
		private List<Parallel> m_SerieParallels = new List<Parallel>();

		[SerializeField]
		[ListForSerie(typeof(SimplifiedLine))]
		private List<SimplifiedLine> m_SerieSimplifiedLines = new List<SimplifiedLine>();

		[SerializeField]
		[ListForSerie(typeof(SimplifiedBar))]
		private List<SimplifiedBar> m_SerieSimplifiedBars = new List<SimplifiedBar>();

		[SerializeField]
		[ListForSerie(typeof(SimplifiedCandlestick))]
		private List<SimplifiedCandlestick> m_SerieSimplifiedCandlesticks = new List<SimplifiedCandlestick>();

		protected List<Serie> m_Series = new List<Serie>();

		protected List<MainComponent> m_Components = new List<MainComponent>();

		protected Dictionary<Type, FieldInfo> m_TypeListForComponent = new Dictionary<Type, FieldInfo>();

		protected Dictionary<Type, FieldInfo> m_TypeListForSerie = new Dictionary<Type, FieldInfo>();

		protected Dictionary<Type, List<MainComponent>> m_ComponentMaps = new Dictionary<Type, List<MainComponent>>();

		protected float m_ChartWidth;

		protected float m_ChartHeight;

		protected float m_ChartX;

		protected float m_ChartY;

		protected Vector3 m_ChartPosition = Vector3.zero;

		protected Vector2 m_ChartMinAnchor;

		protected Vector2 m_ChartMaxAnchor;

		protected Vector2 m_ChartPivot;

		protected Vector2 m_ChartSizeDelta;

		protected Rect m_ChartRect = new Rect(0f, 0f, 0f, 0f);

		protected Action m_OnInit;

		protected Action m_OnUpdate;

		protected Action<VertexHelper> m_OnDrawBase;

		protected Action<VertexHelper> m_OnDrawUpper;

		protected Action<VertexHelper> m_OnDrawTop;

		protected Action<VertexHelper, Serie> m_OnDrawSerieBefore;

		protected Action<VertexHelper, Serie> m_OnDrawSerieAfter;

		protected Action<SerieEventData> m_OnSerieClick;

		protected Action<SerieEventData> m_OnSerieDown;

		protected Action<SerieEventData> m_OnSerieEnter;

		protected Action<SerieEventData> m_OnSerieExit;

		protected Action<int, int> m_OnPointerEnterPie;

		protected Action<Axis, double> m_OnAxisPointerValueChanged;

		protected Action<Legend, int, string, bool> m_OnLegendClick;

		protected Action<Legend, int, string> m_OnLegendEnter;

		protected Action<Legend, int, string> m_OnLegendExit;

		protected CustomDrawGaugePointerFunction m_CustomDrawGaugePointerFunction;

		internal bool m_CheckAnimation;

		protected internal List<string> m_LegendRealShowName = new List<string>();

		protected List<Painter> m_PainterList = new List<Painter>();

		internal Painter m_PainterUpper;

		internal Painter m_PainterTop;

		internal int m_BasePainterVertCount;

		internal int m_UpperPainterVertCount;

		internal int m_TopPainterVertCount;

		private ThemeType m_CheckTheme;

		protected List<MainComponentHandler> m_ComponentHandlers = new List<MainComponentHandler>();

		protected List<SerieHandler> m_SerieHandlers = new List<SerieHandler>();

		private HashSet<string> barStackSet = new HashSet<string>();

		private List<string> tempList = new List<string>();

		public string chartName
		{
			get
			{
				return m_ChartName;
			}
			set
			{
				if (!string.IsNullOrEmpty(value) && XChartsMgr.ContainsChart(value))
				{
					Debug.LogError("chartName repeated:" + value);
				}
				else
				{
					m_ChartName = value;
				}
			}
		}

		public ThemeStyle theme
		{
			get
			{
				return m_Theme;
			}
			set
			{
				m_Theme = value;
			}
		}

		public Settings settings => m_Settings;

		public float chartX => m_ChartX;

		public float chartY => m_ChartY;

		public float chartWidth => m_ChartWidth;

		public float chartHeight => m_ChartHeight;

		public Vector2 chartMinAnchor => m_ChartMinAnchor;

		public Vector2 chartMaxAnchor => m_ChartMaxAnchor;

		public Vector2 chartPivot => m_ChartPivot;

		public Vector2 chartSizeDelta => m_ChartSizeDelta;

		public Vector3 chartPosition => m_ChartPosition;

		public Rect chartRect => m_ChartRect;

		public Action onInit
		{
			set
			{
				m_OnInit = value;
			}
		}

		public Action onUpdate
		{
			set
			{
				m_OnUpdate = value;
			}
		}

		public Action<VertexHelper> onDraw
		{
			set
			{
				m_OnDrawBase = value;
			}
		}

		public Action<VertexHelper, Serie> onDrawBeforeSerie
		{
			set
			{
				m_OnDrawSerieBefore = value;
			}
		}

		public Action<VertexHelper, Serie> onDrawAfterSerie
		{
			set
			{
				m_OnDrawSerieAfter = value;
			}
		}

		public Action<VertexHelper> onDrawUpper
		{
			set
			{
				m_OnDrawUpper = value;
			}
		}

		public Action<VertexHelper> onDrawTop
		{
			set
			{
				m_OnDrawTop = value;
			}
		}

		public CustomDrawGaugePointerFunction customDrawGaugePointerFunction
		{
			get
			{
				return m_CustomDrawGaugePointerFunction;
			}
			set
			{
				m_CustomDrawGaugePointerFunction = value;
			}
		}

		[Since("v3.6.0")]
		public Action<SerieEventData> onSerieClick
		{
			get
			{
				return m_OnSerieClick;
			}
			set
			{
				m_OnSerieClick = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		[Since("v3.6.0")]
		public Action<SerieEventData> onSerieDown
		{
			get
			{
				return m_OnSerieDown;
			}
			set
			{
				m_OnSerieDown = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		[Since("v3.6.0")]
		public Action<SerieEventData> onSerieEnter
		{
			get
			{
				return m_OnSerieEnter;
			}
			set
			{
				m_OnSerieEnter = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		[Since("v3.6.0")]
		public Action<SerieEventData> onSerieExit
		{
			get
			{
				return m_OnSerieExit;
			}
			set
			{
				m_OnSerieExit = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		[Obsolete("Use \"onSerieClick\" instead", true)]
		public Action<PointerEventData, int, int> onPointerClickPie { get; set; }

		[Since("v3.3.0")]
		[Obsolete("Use \"onSerieEnter\" instead", true)]
		public Action<int, int> onPointerEnterPie
		{
			get
			{
				return m_OnPointerEnterPie;
			}
			set
			{
				m_OnPointerEnterPie = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		[Obsolete("Use \"onSerieClick\" instead", true)]
		public Action<PointerEventData, int> onPointerClickBar { get; set; }

		public Action<Axis, double> onAxisPointerValueChanged
		{
			get
			{
				return m_OnAxisPointerValueChanged;
			}
			set
			{
				m_OnAxisPointerValueChanged = value;
			}
		}

		public Action<Legend, int, string, bool> onLegendClick
		{
			internal get
			{
				return m_OnLegendClick;
			}
			set
			{
				m_OnLegendClick = value;
			}
		}

		public Action<Legend, int, string> onLegendEnter
		{
			internal get
			{
				return m_OnLegendEnter;
			}
			set
			{
				m_OnLegendEnter = value;
			}
		}

		public Action<Legend, int, string> onLegendExit
		{
			internal get
			{
				return m_OnLegendExit;
			}
			set
			{
				m_OnLegendExit = value;
			}
		}

		public Dictionary<Type, FieldInfo> typeListForComponent => m_TypeListForComponent;

		public Dictionary<Type, FieldInfo> typeListForSerie => m_TypeListForSerie;

		public List<MainComponent> components => m_Components;

		public List<Serie> series => m_Series;

		public DebugInfo debug => m_DebugInfo;

		public override HideFlags chartHideFlags
		{
			get
			{
				if (!m_DebugInfo.showAllChartObject)
				{
					return HideFlags.HideInHierarchy;
				}
				return HideFlags.None;
			}
		}

		public void Init(bool defaultChart = true)
		{
			if (defaultChart)
			{
				OnInit();
				DefaultChart();
			}
			else
			{
				OnBeforeSerialize();
			}
		}

		public void RefreshChart()
		{
			m_RefreshChart = true;
			if ((bool)m_Painter)
			{
				m_Painter.Refresh();
			}
			foreach (Painter painter in m_PainterList)
			{
				painter.Refresh();
			}
			if ((bool)m_PainterUpper)
			{
				m_PainterUpper.Refresh();
			}
			if ((bool)m_PainterTop)
			{
				m_PainterTop.Refresh();
			}
		}

		public override void RefreshGraph()
		{
			RefreshChart();
		}

		public void RefreshChart(int serieIndex)
		{
			RefreshPainter(GetSerie(serieIndex));
		}

		public void RefreshChart(Serie serie)
		{
			if (serie != null)
			{
				RefreshPainter(serie);
			}
		}

		public virtual void ClearData()
		{
			ClearSerieData();
			ClearComponentData();
		}

		[Since("v3.4.0")]
		public virtual void ClearSerieData()
		{
			foreach (Serie item in m_Series)
			{
				item.ClearData();
			}
			m_CheckAnimation = false;
			RefreshChart();
		}

		[Since("v3.4.0")]
		public virtual void ClearComponentData()
		{
			foreach (MainComponent component in m_Components)
			{
				component.ClearData();
			}
			m_CheckAnimation = false;
			RefreshChart();
		}

		public virtual void RemoveData()
		{
			foreach (MainComponent component in m_Components)
			{
				component.ClearData();
			}
			m_Series.Clear();
			m_SerieHandlers.Clear();
			m_CheckAnimation = false;
			RefreshChart();
		}

		[Since("v3.2.0")]
		public virtual void RemoveAllSerie()
		{
			m_Series.Clear();
			m_SerieHandlers.Clear();
			m_CheckAnimation = false;
			RefreshChart();
		}

		public virtual void RemoveData(string serieName)
		{
			RemoveSerie(serieName);
			foreach (MainComponent component in m_Components)
			{
				if (component is Legend)
				{
					(component as Legend).RemoveData(serieName);
				}
			}
			RefreshChart();
		}

		public virtual void UpdateLegendColor(string legendName, bool active)
		{
			int num = m_LegendRealShowName.IndexOf(legendName);
			if (num < 0)
			{
				return;
			}
			foreach (MainComponent component in m_Components)
			{
				if (component is Legend)
				{
					Legend legend = component as Legend;
					Color iconColor = LegendHelper.GetIconColor(this, legend, num, legendName, active);
					Color contentColor = LegendHelper.GetContentColor(this, num, legendName, legend, m_Theme, active);
					legend.UpdateButtonColor(legendName, iconColor);
					legend.UpdateContentColor(legendName, contentColor);
				}
			}
		}

		public virtual bool IsActiveByLegend(string legendName)
		{
			foreach (Serie item in m_Series)
			{
				if (item.show && legendName.Equals(item.serieName))
				{
					return true;
				}
				foreach (SerieData datum in item.data)
				{
					if (datum.show && legendName.Equals(datum.name))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool UpdateTheme(ThemeType theme)
		{
			if (theme == ThemeType.Custom)
			{
				Debug.LogError("UpdateTheme: not support switch to Custom theme.");
				return false;
			}
			if (m_Theme.sharedTheme == null)
			{
				m_Theme.sharedTheme = XCThemeMgr.GetTheme(ThemeType.Default);
			}
			m_Theme.sharedTheme.CopyTheme(theme);
			return true;
		}

		public void UpdateTheme(Theme theme)
		{
			m_Theme.sharedTheme = theme;
			SetAllComponentDirty();
		}

		public void AnimationEnable(bool flag)
		{
			foreach (Serie item in m_Series)
			{
				item.AnimationEnable(flag);
			}
		}

		public void AnimationFadeIn(bool reset = true)
		{
			if (reset)
			{
				AnimationReset();
			}
			foreach (Serie item in m_Series)
			{
				item.AnimationFadeIn();
			}
		}

		public void AnimationFadeOut()
		{
			foreach (Serie item in m_Series)
			{
				item.AnimationFadeOut();
			}
		}

		public void AnimationPause()
		{
			foreach (Serie item in m_Series)
			{
				item.AnimationPause();
			}
		}

		public void AnimationResume()
		{
			foreach (Serie item in m_Series)
			{
				item.AnimationResume();
			}
		}

		public void AnimationReset()
		{
			foreach (Serie item in m_Series)
			{
				item.AnimationReset();
			}
		}

		public void ClickLegendButton(int legendIndex, string legendName, bool show)
		{
			OnLegendButtonClick(legendIndex, legendName, show);
			RefreshChart();
		}

		public bool IsInChart(Vector2 local)
		{
			return IsInChart(local.x, local.y);
		}

		public bool IsInChart(float x, float y)
		{
			if (x < m_ChartX || x > m_ChartX + m_ChartWidth || y < m_ChartY || y > m_ChartY + m_ChartHeight)
			{
				return false;
			}
			return true;
		}

		public void ClampInChart(ref Vector3 pos)
		{
			if (!IsInChart(pos.x, pos.y))
			{
				if (pos.x < m_ChartX)
				{
					pos.x = m_ChartX;
				}
				if (pos.x > m_ChartX + m_ChartWidth)
				{
					pos.x = m_ChartX + m_ChartWidth;
				}
				if (pos.y < m_ChartY)
				{
					pos.y = m_ChartY;
				}
				if (pos.y > m_ChartY + m_ChartHeight)
				{
					pos.y = m_ChartY + m_ChartHeight;
				}
			}
		}

		public Vector3 ClampInGrid(GridCoord grid, Vector3 pos)
		{
			if (grid.Contains(pos))
			{
				return pos;
			}
			if (pos.x < grid.context.x)
			{
				pos.x = grid.context.x;
			}
			if (pos.x > grid.context.x + grid.context.width)
			{
				pos.x = grid.context.x + grid.context.width;
			}
			if (pos.y < grid.context.y)
			{
				pos.y = grid.context.y;
			}
			if (pos.y > grid.context.y + grid.context.height)
			{
				pos.y = grid.context.y + grid.context.height;
			}
			return pos;
		}

		public void ConvertXYAxis(int index)
		{
			m_ComponentMaps.TryGetValue(typeof(XAxis), out var value);
			m_ComponentMaps.TryGetValue(typeof(YAxis), out var value2);
			if (index >= 0 && index <= 1)
			{
				XAxis obj = value[index] as XAxis;
				YAxis yAxis = value2[index] as YAxis;
				Axis axis = obj.Clone();
				obj.Copy(yAxis);
				yAxis.Copy(axis);
				obj.context.offset = 0f;
				yAxis.context.offset = 0f;
				obj.context.minValue = 0.0;
				obj.context.maxValue = 0.0;
				yAxis.context.minValue = 0.0;
				yAxis.context.maxValue = 0.0;
				RefreshChart();
			}
		}

		public void RefreshDataZoom()
		{
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				if (componentHandler is DataZoomHandler)
				{
					(componentHandler as DataZoomHandler).RefreshDataZoomLabel();
				}
			}
		}

		public void SetMaxCache(int maxCache)
		{
			foreach (Serie item in m_Series)
			{
				item.maxCache = maxCache;
			}
			foreach (MainComponent component in m_Components)
			{
				if (component is Axis)
				{
					(component as Axis).maxCache = maxCache;
				}
			}
		}

		public Vector3 GetTitlePosition(Title title)
		{
			return chartPosition + title.location.GetPosition(chartWidth, chartHeight);
		}

		public int GetLegendRealShowNameIndex(string name)
		{
			return m_LegendRealShowName.IndexOf(name);
		}

		public Color32 GetLegendRealShowNameColor(string name)
		{
			int legendRealShowNameIndex = GetLegendRealShowNameIndex(name);
			return theme.GetColor(legendRealShowNameIndex);
		}

		public void SetBasePainterMaterial(Material material)
		{
			settings.basePainterMaterial = material;
			if (m_Painter != null)
			{
				m_Painter.material = material;
			}
		}

		public void SetSeriePainterMaterial(Material material)
		{
			settings.basePainterMaterial = material;
			if (m_PainterList == null)
			{
				return;
			}
			foreach (Painter painter in m_PainterList)
			{
				painter.material = material;
			}
		}

		public void SetUpperPainterMaterial(Material material)
		{
			settings.upperPainterMaterial = material;
			if (m_PainterUpper != null)
			{
				m_PainterUpper.material = material;
			}
		}

		public void SetTopPainterMaterial(Material material)
		{
			settings.topPainterMaterial = material;
			if (m_PainterTop != null)
			{
				m_PainterTop.material = material;
			}
		}

		public Color32 GetChartBackgroundColor()
		{
			Background chartComponent = GetChartComponent<Background>();
			return theme.GetBackgroundColor(chartComponent);
		}

		[Since("v3.4.0")]
		public Color32 GetMarkColor(Serie serie, SerieData serieData)
		{
			ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
			if (ChartHelper.IsClearColor(itemStyle.markColor))
			{
				return GetItemColor(serie, serieData);
			}
			return itemStyle.markColor;
		}

		public Color32 GetItemColor(Serie serie, SerieData serieData)
		{
			SerieHelper.GetItemColor(out var result, out var _, serie, serieData, m_Theme);
			return result;
		}

		public Color32 GetItemColor(Serie serie, SerieData serieData, int colorIndex)
		{
			SerieHelper.GetItemColor(out var result, out var _, serie, serieData, m_Theme, colorIndex);
			return result;
		}

		public Color32 GetItemColor(Serie serie)
		{
			SerieHelper.GetItemColor(out var result, out var _, serie, null, m_Theme);
			return result;
		}

		[Since("v3.7.0")]
		public bool TriggerTooltip(int dataIndex)
		{
			Serie serie = GetSerie(0);
			if (serie == null)
			{
				return false;
			}
			List<Vector3> dataPoints = serie.context.dataPoints;
			Vector3 zero = Vector3.zero;
			if (dataPoints.Count == 0)
			{
				if (serie.dataCount == 0)
				{
					return false;
				}
				dataIndex %= serie.dataCount;
				if (serie.GetSerieData(dataIndex) == null)
				{
					return false;
				}
				zero = serie.GetSerieData(dataIndex).context.position;
			}
			else
			{
				dataIndex %= dataPoints.Count;
				zero = dataPoints[dataIndex];
			}
			return TriggerTooltip(zero);
		}

		[Since("v3.7.0")]
		public bool TriggerTooltip(Vector3 localPosition)
		{
			Vector2 position = LocalPointToScreenPoint(localPosition);
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = position;
			OnPointerEnter(pointerEventData);
			return true;
		}

		[Since("v3.7.0")]
		public void CancelTooltip()
		{
			GetChartComponent<Tooltip>()?.SetActive(flag: false);
		}

		public bool TryAddChartComponent<T>() where T : MainComponent
		{
			return TryAddChartComponent(typeof(T));
		}

		public bool TryAddChartComponent(Type type)
		{
			if (CanAddChartComponent(type))
			{
				AddChartComponent(type);
				return true;
			}
			return false;
		}

		public bool TryAddChartComponent<T>(out T component) where T : MainComponent
		{
			Type typeFromHandle = typeof(T);
			if (CanAddChartComponent(typeFromHandle))
			{
				component = AddChartComponent(typeFromHandle) as T;
				return true;
			}
			component = null;
			return false;
		}

		public T AddChartComponent<T>() where T : MainComponent
		{
			return (T)AddChartComponent(typeof(T));
		}

		public T AddChartComponentWhenNoExist<T>() where T : MainComponent
		{
			if (HasChartComponent<T>())
			{
				return null;
			}
			return AddChartComponent<T>();
		}

		public MainComponent AddChartComponent(Type type)
		{
			if (!CanAddChartComponent(type))
			{
				Debug.LogError("XCharts ERROR: CanAddChartComponent:" + type.Name);
				return null;
			}
			CheckAddRequireChartComponent(type);
			if (!(Activator.CreateInstance(type) is MainComponent mainComponent))
			{
				Debug.LogError("XCharts ERROR: CanAddChartComponent:" + type.Name);
				return null;
			}
			mainComponent.SetDefaultValue();
			if (mainComponent is IUpdateRuntimeData)
			{
				(mainComponent as IUpdateRuntimeData).UpdateRuntimeData(this);
			}
			AddComponent(mainComponent);
			m_Components.Sort();
			CreateComponentHandler(mainComponent);
			return mainComponent;
		}

		private void AddComponent(MainComponent component)
		{
			Type type = component.GetType();
			m_Components.Add(component);
			if (!m_ComponentMaps.TryGetValue(type, out var value))
			{
				value = new List<MainComponent>();
				m_ComponentMaps[type] = value;
			}
			component.index = value.Count;
			value.Add(component);
			m_Components.Sort((MainComponent a, MainComponent b) => a.GetType().Name.CompareTo(b.GetType().Name));
		}

		private void CheckAddRequireChartComponent(Type type)
		{
			if (!Attribute.IsDefined(type, typeof(RequireChartComponentAttribute)))
			{
				return;
			}
			object[] customAttributes = type.GetCustomAttributes(typeof(RequireChartComponentAttribute), inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				RequireChartComponentAttribute requireChartComponentAttribute = customAttributes[i] as RequireChartComponentAttribute;
				if (requireChartComponentAttribute.type0 != null && !HasChartComponent(requireChartComponentAttribute.type0))
				{
					AddChartComponent(requireChartComponentAttribute.type0);
				}
				if (requireChartComponentAttribute.type1 != null && !HasChartComponent(requireChartComponentAttribute.type1))
				{
					AddChartComponent(requireChartComponentAttribute.type1);
				}
				if (requireChartComponentAttribute.type2 != null && !HasChartComponent(requireChartComponentAttribute.type2))
				{
					AddChartComponent(requireChartComponentAttribute.type2);
				}
			}
		}

		private void CreateComponentHandler(MainComponent component)
		{
			if (!component.GetType().IsDefined(typeof(ComponentHandlerAttribute), inherit: false))
			{
				Debug.LogError("MainComponent no Handler:" + component.GetType());
				return;
			}
			ComponentHandlerAttribute attribute = component.GetType().GetAttribute<ComponentHandlerAttribute>();
			if (!(attribute.handler == null))
			{
				MainComponentHandler mainComponentHandler = (MainComponentHandler)Activator.CreateInstance(attribute.handler);
				mainComponentHandler.attribute = attribute;
				mainComponentHandler.chart = this;
				mainComponentHandler.SetComponent(component);
				component.handler = mainComponentHandler;
				m_ComponentHandlers.Add(mainComponentHandler);
			}
		}

		public bool RemoveChartComponent<T>(int index = 0) where T : MainComponent
		{
			return RemoveChartComponent(typeof(T), index);
		}

		public int RemoveChartComponents<T>() where T : MainComponent
		{
			return RemoveChartComponents(typeof(T));
		}

		public void RemoveAllChartComponent()
		{
			m_Components.Clear();
			InitComponentHandlers();
		}

		public bool RemoveChartComponent(Type type, int index = 0)
		{
			MainComponent component = null;
			for (int i = 0; i < m_Components.Count; i++)
			{
				if (m_Components[i].GetType() == type && m_Components[i].index == index)
				{
					component = m_Components[i];
					break;
				}
			}
			return RemoveChartComponent(component);
		}

		public int RemoveChartComponents(Type type)
		{
			int num = 0;
			for (int num2 = m_Components.Count - 1; num2 > 0; num2--)
			{
				if (m_Components[num2].GetType() == type)
				{
					RemoveChartComponent(m_Components[num2]);
					num++;
				}
			}
			return num;
		}

		public bool RemoveChartComponent(MainComponent component)
		{
			if (component == null)
			{
				return false;
			}
			if (m_Components.Remove(component))
			{
				if (component.gameObject != null)
				{
					ChartHelper.SetActive(component.gameObject, active: false);
				}
				InitComponentHandlers();
				RefreshChart();
				return true;
			}
			return false;
		}

		public bool CanAddChartComponent(Type type)
		{
			if (!type.IsSubclassOf(typeof(MainComponent)))
			{
				return false;
			}
			if (!m_TypeListForComponent.ContainsKey(type))
			{
				return false;
			}
			if (CanMultipleComponent(type))
			{
				return !HasChartComponent(type);
			}
			return true;
		}

		public bool HasChartComponent<T>() where T : MainComponent
		{
			return HasChartComponent(typeof(T));
		}

		public bool HasChartComponent(Type type)
		{
			foreach (MainComponent component in m_Components)
			{
				if (component != null && component.GetType() == type)
				{
					return true;
				}
			}
			return false;
		}

		public bool CanMultipleComponent(Type type)
		{
			return Attribute.IsDefined(type, typeof(DisallowMultipleComponent));
		}

		public int GetChartComponentNum<T>() where T : MainComponent
		{
			return GetChartComponentNum(typeof(T));
		}

		public int GetChartComponentNum(Type type)
		{
			if (m_ComponentMaps.TryGetValue(type, out list))
			{
				return list.Count;
			}
			return 0;
		}

		public T GetChartComponent<T>(int index = 0) where T : MainComponent
		{
			foreach (MainComponent component in m_Components)
			{
				if (component is T && component.index == index)
				{
					return component as T;
				}
			}
			return null;
		}

		public List<MainComponent> GetChartComponents<T>() where T : MainComponent
		{
			Type typeFromHandle = typeof(T);
			if (m_ComponentMaps.ContainsKey(typeFromHandle))
			{
				return m_ComponentMaps[typeFromHandle];
			}
			return null;
		}

		[Obsolete("'GetOrAddChartComponent' is obsolete, Use 'EnsureChartComponent' instead.")]
		public T GetOrAddChartComponent<T>() where T : MainComponent
		{
			T chartComponent = GetChartComponent<T>();
			if (chartComponent == null)
			{
				return AddChartComponent<T>();
			}
			return chartComponent;
		}

		[Since("v3.6.0")]
		public T EnsureChartComponent<T>() where T : MainComponent
		{
			T chartComponent = GetChartComponent<T>();
			if (chartComponent == null)
			{
				return AddChartComponent<T>();
			}
			return chartComponent;
		}

		public bool TryGetChartComponent<T>(out T component, int index = 0) where T : MainComponent
		{
			component = null;
			foreach (MainComponent component2 in m_Components)
			{
				if (component2 is T && component2.index == index)
				{
					component = (T)component2;
					return true;
				}
			}
			return false;
		}

		public GridCoord GetGrid(Vector2 local)
		{
			if (m_ComponentMaps.TryGetValue(typeof(GridCoord), out var value))
			{
				foreach (MainComponent item in value)
				{
					GridCoord gridCoord = item as GridCoord;
					if (gridCoord.Contains(local))
					{
						return gridCoord;
					}
				}
			}
			return null;
		}

		public GridCoord GetGridOfDataZoom(DataZoom dataZoom)
		{
			GridCoord gridCoord = null;
			if (dataZoom.xAxisIndexs != null && dataZoom.xAxisIndexs.Count > 0)
			{
				XAxis chartComponent = GetChartComponent<XAxis>(dataZoom.xAxisIndexs[0]);
				gridCoord = GetChartComponent<GridCoord>(chartComponent.gridIndex);
			}
			else if (dataZoom.yAxisIndexs != null && dataZoom.yAxisIndexs.Count > 0)
			{
				YAxis chartComponent2 = GetChartComponent<YAxis>(dataZoom.yAxisIndexs[0]);
				gridCoord = GetChartComponent<GridCoord>(chartComponent2.gridIndex);
			}
			if (gridCoord == null)
			{
				return GetChartComponent<GridCoord>();
			}
			return gridCoord;
		}

		public DataZoom GetDataZoomOfAxis(Axis axis)
		{
			foreach (MainComponent component in m_Components)
			{
				if (component is DataZoom)
				{
					DataZoom dataZoom = component as DataZoom;
					if (dataZoom.enable && dataZoom.IsContainsAxis(axis))
					{
						return dataZoom;
					}
				}
			}
			return null;
		}

		public VisualMap GetVisualMapOfSerie(Serie serie)
		{
			foreach (MainComponent component in m_Components)
			{
				if (component is VisualMap)
				{
					VisualMap visualMap = component as VisualMap;
					if (visualMap.serieIndex == serie.index)
					{
						return visualMap;
					}
				}
			}
			return null;
		}

		public void GetDataZoomOfSerie(Serie serie, out DataZoom xDataZoom, out DataZoom yDataZoom)
		{
			xDataZoom = null;
			yDataZoom = null;
			if (serie == null)
			{
				return;
			}
			foreach (MainComponent component in m_Components)
			{
				if (!(component is DataZoom))
				{
					continue;
				}
				DataZoom dataZoom = component as DataZoom;
				if (dataZoom.enable)
				{
					if (dataZoom.IsContainsXAxis(serie.xAxisIndex))
					{
						xDataZoom = dataZoom;
					}
					if (dataZoom.IsContainsYAxis(serie.yAxisIndex))
					{
						yDataZoom = dataZoom;
					}
				}
			}
		}

		public DataZoom GetXDataZoomOfSerie(Serie serie)
		{
			if (serie == null)
			{
				return null;
			}
			foreach (MainComponent component in m_Components)
			{
				if (component is DataZoom)
				{
					DataZoom dataZoom = component as DataZoom;
					if (dataZoom.enable && dataZoom.IsContainsXAxis(serie.xAxisIndex))
					{
						return dataZoom;
					}
				}
			}
			return null;
		}

		public bool IsAllAxisValue()
		{
			foreach (MainComponent component in m_Components)
			{
				if (component is Axis)
				{
					Axis axis = component as Axis;
					if (axis.show && !axis.IsValue() && !axis.IsLog() && !axis.IsTime())
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool IsAllAxisCategory()
		{
			foreach (MainComponent component in m_Components)
			{
				if (component is Axis)
				{
					Axis axis = component as Axis;
					if (axis.show && !axis.IsCategory())
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool IsInAnyGrid(Vector2 local)
		{
			if (m_ComponentMaps.TryGetValue(typeof(GridCoord), out var value))
			{
				foreach (MainComponent item in value)
				{
					if ((item as GridCoord).Contains(local))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal string GetTooltipCategory(int dataIndex, DataZoom dataZoom = null)
		{
			XAxis chartComponent = GetChartComponent<XAxis>();
			YAxis chartComponent2 = GetChartComponent<YAxis>();
			if (chartComponent2.IsCategory())
			{
				return chartComponent2.GetData((int)chartComponent2.context.pointerValue, dataZoom);
			}
			if (chartComponent.IsCategory())
			{
				return chartComponent.GetData((int)chartComponent.context.pointerValue, dataZoom);
			}
			return null;
		}

		internal string GetTooltipCategory(int dataIndex, Serie serie, DataZoom dataZoom = null)
		{
			XAxis chartComponent = GetChartComponent<XAxis>(serie.xAxisIndex);
			YAxis chartComponent2 = GetChartComponent<YAxis>(serie.yAxisIndex);
			if (chartComponent2.IsCategory())
			{
				return chartComponent2.GetData((int)chartComponent2.context.pointerValue, dataZoom);
			}
			if (chartComponent.IsCategory())
			{
				return chartComponent.GetData((int)chartComponent.context.pointerValue, dataZoom);
			}
			return null;
		}

		internal bool GetSerieGridCoordAxis(Serie serie, out Axis axis, out Axis relativedAxis)
		{
			YAxis chartComponent = GetChartComponent<YAxis>(serie.yAxisIndex);
			if (chartComponent == null)
			{
				axis = null;
				relativedAxis = null;
				return false;
			}
			bool num = chartComponent.IsCategory();
			if (num)
			{
				axis = chartComponent;
				relativedAxis = GetChartComponent<XAxis>(serie.xAxisIndex);
				return num;
			}
			axis = GetChartComponent<XAxis>(serie.xAxisIndex);
			relativedAxis = chartComponent;
			return num;
		}

		protected virtual void DefaultChart()
		{
		}

		protected override void InitComponent()
		{
			base.InitComponent();
			SeriesHelper.UpdateSerieNameList(this, ref m_LegendRealShowName);
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.InitComponent();
			}
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.InitComponent();
			}
			m_DebugInfo.Init(this);
		}

		protected override void Awake()
		{
			if (m_Settings == null)
			{
				m_Settings = Settings.DefaultSettings;
			}
			CheckTheme(firstInit: true);
			base.Awake();
			InitComponentHandlers();
			InitSerieHandlers();
			AnimationReset();
			AnimationFadeIn();
			XChartsMgr.AddChart(this);
		}

		protected void OnInit()
		{
			RemoveAllChartComponent();
			OnBeforeSerialize();
			EnsureChartComponent<Title>();
			EnsureChartComponent<Tooltip>();
			EnsureChartComponent<Title>().text = GetType().Name;
			if (m_Theme.sharedTheme != null)
			{
				m_Theme.sharedTheme.CopyTheme(ThemeType.Default);
			}
			else
			{
				m_Theme.sharedTheme = XCThemeMgr.GetTheme(ThemeType.Default);
			}
			Vector2 sizeDelta = base.rectTransform.sizeDelta;
			if (sizeDelta.x < 580f && sizeDelta.y < 300f)
			{
				base.rectTransform.sizeDelta = new Vector2(580f, 300f);
			}
			ChartHelper.HideAllObject(base.transform);
			if (m_OnInit != null)
			{
				m_OnInit();
			}
		}

		protected override void Start()
		{
			RefreshChart();
		}

		protected override void Update()
		{
			CheckTheme();
			base.Update();
			CheckPainter();
			CheckRefreshChart();
			Internal_CheckAnimation();
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.BeforeUpdate();
			}
			foreach (SerieHandler serieHandler2 in m_SerieHandlers)
			{
				serieHandler2.Update();
			}
			foreach (SerieHandler serieHandler3 in m_SerieHandlers)
			{
				serieHandler3.AfterUpdate();
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.Update();
			}
			m_DebugInfo.Update();
			if (m_OnUpdate != null)
			{
				m_OnUpdate();
			}
		}

		public Painter GetPainter(int index)
		{
			if (index >= 0 && index < m_PainterList.Count)
			{
				return m_PainterList[index];
			}
			return null;
		}

		public void RefreshBasePainter()
		{
			m_Painter.Refresh();
		}

		public void RefreshTopPainter()
		{
			m_PainterTop.Refresh();
		}

		public void RefreshUpperPainter()
		{
			m_PainterUpper.Refresh();
		}

		public void RefreshPainter(int index)
		{
			Painter painter = GetPainter(index);
			RefreshPainter(painter);
		}

		public void RefreshPainter(Serie serie)
		{
			if (serie != null)
			{
				RefreshPainter(GetPainterIndexBySerie(serie));
			}
		}

		internal override void RefreshPainter(Painter painter)
		{
			base.RefreshPainter(painter);
			if (painter != null && painter.type == Painter.Type.Serie)
			{
				m_PainterUpper.Refresh();
			}
		}

		public void SetPainterActive(int index, bool flag)
		{
			Painter painter = GetPainter(index);
			if (!(painter == null))
			{
				painter.SetActive(flag, m_DebugInfo.showAllChartObject);
			}
		}

		protected virtual void CheckTheme(bool firstInit = false)
		{
			if (m_Theme.sharedTheme == null)
			{
				m_Theme.sharedTheme = XCThemeMgr.GetTheme(ThemeType.Default);
			}
			if (firstInit)
			{
				m_CheckTheme = m_Theme.themeType;
			}
			if (m_Theme.sharedTheme != null && m_CheckTheme != m_Theme.themeType)
			{
				m_CheckTheme = m_Theme.themeType;
				m_Theme.sharedTheme.CopyTheme(m_CheckTheme);
				SetAllComponentDirty();
				OnThemeChanged();
			}
		}

		protected override void CheckComponent()
		{
			base.CheckComponent();
			if (m_Theme.anyDirty)
			{
				if (m_Theme.componentDirty)
				{
					SetAllComponentDirty();
				}
				if (m_Theme.vertsDirty)
				{
					RefreshChart();
				}
				m_Theme.ClearDirty();
			}
			foreach (MainComponent component in m_Components)
			{
				CheckComponentDirty(component);
			}
		}

		protected void CheckComponentDirty(MainComponent component)
		{
			if (component == null || !component.anyDirty)
			{
				return;
			}
			if (component.componentDirty)
			{
				if (component.refreshComponent != null)
				{
					component.refreshComponent();
				}
				else
				{
					component.handler.InitComponent();
				}
			}
			if (component.vertsDirty && component.painter != null)
			{
				RefreshPainter(component.painter);
			}
			component.ClearDirty();
		}

		protected override void SetAllComponentDirty()
		{
			base.SetAllComponentDirty();
			m_Theme.SetAllDirty();
			foreach (MainComponent component in m_Components)
			{
				component.SetAllDirty();
			}
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.InitComponent();
			}
			m_RefreshChart = true;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			XChartsMgr.RemoveChart(chartName);
			for (int num = base.transform.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.DestroyImmediate(base.transform.GetChild(num).gameObject);
			}
		}

		protected virtual void CheckPainter()
		{
			for (int i = 0; i < m_Series.Count; i++)
			{
				m_Series[i].index = i;
				SetPainterActive(i, flag: true);
			}
			if (base.transform.childCount - 3 != m_PainterTop.transform.GetSiblingIndex())
			{
				m_PainterTop.transform.SetSiblingIndex(base.transform.childCount - 3);
			}
		}

		protected override void InitPainter()
		{
			base.InitPainter();
			if (settings != null)
			{
				m_Painter.material = settings.basePainterMaterial;
				m_PainterList.Clear();
				Vector2 sizeDelta = new Vector2(m_GraphWidth, m_GraphHeight);
				for (int i = 0; i < settings.maxPainter; i++)
				{
					int num = (settings.reversePainter ? (settings.maxPainter - 1 - i) : i);
					Painter painter = ChartHelper.AddPainterObject("painter_" + num, base.transform, m_GraphMinAnchor, m_GraphMaxAnchor, m_GraphPivot, sizeDelta, chartHideFlags, 2 + num);
					painter.index = m_PainterList.Count;
					painter.type = Painter.Type.Serie;
					painter.onPopulateMesh = OnDrawPainterSerie;
					painter.SetActive(flag: false, m_DebugInfo.showAllChartObject);
					painter.material = settings.seriePainterMaterial;
					painter.transform.SetSiblingIndex(num + 1);
					m_PainterList.Add(painter);
				}
				m_PainterUpper = ChartHelper.AddPainterObject("painter_u", base.transform, m_GraphMinAnchor, m_GraphMaxAnchor, m_GraphPivot, sizeDelta, chartHideFlags, 2 + settings.maxPainter);
				m_PainterUpper.type = Painter.Type.Top;
				m_PainterUpper.onPopulateMesh = OnDrawPainterUpper;
				m_PainterUpper.SetActive(flag: true, m_DebugInfo.showAllChartObject);
				m_PainterUpper.material = settings.topPainterMaterial;
				m_PainterUpper.transform.SetSiblingIndex(settings.maxPainter + 1);
				m_PainterTop = ChartHelper.AddPainterObject("painter_t", base.transform, m_GraphMinAnchor, m_GraphMaxAnchor, m_GraphPivot, sizeDelta, chartHideFlags, 2 + settings.maxPainter);
				m_PainterTop.type = Painter.Type.Top;
				m_PainterTop.onPopulateMesh = OnDrawPainterTop;
				m_PainterTop.SetActive(flag: true, m_DebugInfo.showAllChartObject);
				m_PainterTop.material = settings.topPainterMaterial;
				m_PainterTop.transform.SetSiblingIndex(settings.maxPainter + 1);
			}
		}

		internal void InitComponentHandlers()
		{
			m_ComponentHandlers.Clear();
			m_Components.Sort();
			m_ComponentMaps.Clear();
			foreach (MainComponent component in m_Components)
			{
				Type type = component.GetType();
				if (!m_ComponentMaps.TryGetValue(type, out var value))
				{
					value = new List<MainComponent>();
					m_ComponentMaps[type] = value;
				}
				component.index = value.Count;
				value.Add(component);
				CreateComponentHandler(component);
			}
		}

		protected override void CheckRefreshChart()
		{
			if (!(m_Painter == null) && m_RefreshChart)
			{
				CheckRefreshPainter();
				m_RefreshChart = false;
			}
		}

		protected override void CheckRefreshPainter()
		{
			if (m_Painter == null)
			{
				return;
			}
			m_Painter.CheckRefresh();
			foreach (Painter painter in m_PainterList)
			{
				painter.CheckRefresh();
			}
			if (m_PainterUpper != null)
			{
				m_PainterUpper.CheckRefresh();
			}
			if (m_PainterTop != null)
			{
				m_PainterTop.CheckRefresh();
			}
		}

		public void Internal_CheckAnimation()
		{
			if (!m_CheckAnimation)
			{
				m_CheckAnimation = true;
				AnimationFadeIn();
			}
		}

		protected override void OnSizeChanged()
		{
			base.OnSizeChanged();
			m_ChartWidth = m_GraphWidth;
			m_ChartHeight = m_GraphHeight;
			m_ChartX = m_GraphX;
			m_ChartY = m_GraphY;
			m_ChartPosition = m_GraphPosition;
			m_ChartMinAnchor = m_GraphMinAnchor;
			m_ChartMaxAnchor = m_GraphMaxAnchor;
			m_ChartPivot = m_GraphPivot;
			m_ChartSizeDelta = m_GraphSizeDelta;
			m_ChartRect = m_GraphRect;
			SetAllComponentDirty();
			OnCoordinateChanged();
			RefreshChart();
		}

		internal virtual void OnSerieDataUpdate(int serieIndex)
		{
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnSerieDataUpdate(serieIndex);
			}
		}

		internal virtual void OnCoordinateChanged()
		{
			foreach (MainComponent component in m_Components)
			{
				if (component is Axis)
				{
					component.SetAllDirty();
				}
				if (component is IUpdateRuntimeData)
				{
					(component as IUpdateRuntimeData).UpdateRuntimeData(this);
				}
			}
		}

		protected override void OnLocalPositionChanged()
		{
			if (TryGetChartComponent<Background>(out var component))
			{
				component.SetAllDirty();
			}
		}

		protected virtual void OnThemeChanged()
		{
		}

		public virtual void OnDataZoomRangeChanged(DataZoom dataZoom)
		{
			foreach (int xAxisIndex in dataZoom.xAxisIndexs)
			{
				XAxis chartComponent = GetChartComponent<XAxis>(xAxisIndex);
				if (chartComponent != null && chartComponent.show)
				{
					chartComponent.SetAllDirty();
				}
			}
			foreach (int yAxisIndex in dataZoom.yAxisIndexs)
			{
				YAxis chartComponent2 = GetChartComponent<YAxis>(yAxisIndex);
				if (chartComponent2 != null && chartComponent2.show)
				{
					chartComponent2.SetAllDirty();
				}
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			m_DebugInfo.clickChartCount++;
			base.OnPointerClick(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnPointerClick(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnPointerClick(eventData);
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnPointerDown(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnPointerDown(eventData);
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnPointerUp(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnPointerUp(eventData);
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnPointerEnter(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnPointerEnter(eventData);
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnPointerExit(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnPointerExit(eventData);
			}
		}

		public override void OnBeginDrag(PointerEventData eventData)
		{
			base.OnBeginDrag(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnBeginDrag(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnBeginDrag(eventData);
			}
		}

		public override void OnDrag(PointerEventData eventData)
		{
			base.OnDrag(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnDrag(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnDrag(eventData);
			}
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			base.OnEndDrag(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnEndDrag(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnEndDrag(eventData);
			}
		}

		public override void OnScroll(PointerEventData eventData)
		{
			base.OnScroll(eventData);
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnScroll(eventData);
			}
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.OnScroll(eventData);
			}
		}

		public virtual void OnLegendButtonClick(int index, string legendName, bool show)
		{
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnLegendButtonClick(index, legendName, show);
			}
		}

		public virtual void OnLegendButtonEnter(int index, string legendName)
		{
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnLegendButtonEnter(index, legendName);
			}
		}

		public virtual void OnLegendButtonExit(int index, string legendName)
		{
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.OnLegendButtonExit(index, legendName);
			}
		}

		protected override void OnDrawPainterBase(VertexHelper vh, Painter painter)
		{
			vh.Clear();
			DrawBackground(vh);
			DrawPainterBase(vh);
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.DrawBase(vh);
			}
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.DrawBase(vh);
			}
			if (m_OnDrawBase != null)
			{
				m_OnDrawBase(vh);
			}
			m_BasePainterVertCount = vh.currentVertCount;
		}

		protected virtual void OnDrawPainterSerie(VertexHelper vh, Painter painter)
		{
			vh.Clear();
			int maxPainter = settings.maxPainter;
			int count = m_Series.Count;
			int num = Mathf.CeilToInt((float)count * 1f / (float)maxPainter);
			m_PainterUpper.Refresh();
			m_PainterTop.Refresh();
			m_DebugInfo.refreshCount++;
			for (int i = painter.index * num; i < (painter.index + 1) * num && i < count; i++)
			{
				Serie serie = m_Series[i];
				serie.context.colorIndex = GetLegendRealShowNameIndex(serie.legendName);
				serie.context.dataPoints.Clear();
				serie.context.dataIndexs.Clear();
				serie.context.dataIgnores.Clear();
				serie.animation.context.isAllItemAnimationEnd = true;
				if (serie.show && !serie.animation.HasFadeOut())
				{
					if (m_OnDrawSerieBefore != null)
					{
						m_OnDrawSerieBefore(vh, serie);
					}
					DrawPainterSerie(vh, serie);
					if (i >= 0 && i < m_SerieHandlers.Count)
					{
						SerieHandler serieHandler = m_SerieHandlers[i];
						serieHandler.DrawSerie(vh);
						serieHandler.RefreshLabelNextFrame();
					}
					if (m_OnDrawSerieAfter != null)
					{
						m_OnDrawSerieAfter(vh, serie);
					}
				}
				serie.context.vertCount = vh.currentVertCount;
			}
		}

		protected virtual void OnDrawPainterUpper(VertexHelper vh, Painter painter)
		{
			vh.Clear();
			DrawPainterUpper(vh);
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.DrawUpper(vh);
			}
			if (m_OnDrawUpper != null)
			{
				m_OnDrawUpper(vh);
			}
			m_UpperPainterVertCount = vh.currentVertCount;
		}

		protected virtual void OnDrawPainterTop(VertexHelper vh, Painter painter)
		{
			vh.Clear();
			DrawPainterTop(vh);
			foreach (MainComponentHandler componentHandler in m_ComponentHandlers)
			{
				componentHandler.DrawTop(vh);
			}
			if (m_OnDrawTop != null)
			{
				m_OnDrawTop(vh);
			}
			m_TopPainterVertCount = vh.currentVertCount;
		}

		protected virtual void DrawPainterSerie(VertexHelper vh, Serie serie)
		{
		}

		protected virtual void DrawPainterUpper(VertexHelper vh)
		{
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.DrawUpper(vh);
			}
		}

		protected virtual void DrawPainterTop(VertexHelper vh)
		{
			foreach (SerieHandler serieHandler in m_SerieHandlers)
			{
				serieHandler.DrawTop(vh);
			}
		}

		protected virtual void DrawBackground(VertexHelper vh)
		{
			Background chartComponent = GetChartComponent<Background>();
			if (chartComponent == null || !chartComponent.show)
			{
				Vector3 p = new Vector3(chartX, chartY + chartHeight);
				Vector3 p2 = new Vector3(chartX + chartWidth, chartY + chartHeight);
				Vector3 p3 = new Vector3(chartX + chartWidth, chartY);
				Vector3 p4 = new Vector3(chartX, chartY);
				UGL.DrawQuadrilateral(vh, p, p2, p3, p4, theme.backgroundColor);
			}
		}

		protected int GetPainterIndexBySerie(Serie serie)
		{
			int maxPainter = settings.maxPainter;
			int count = m_Series.Count;
			if (maxPainter >= count)
			{
				return serie.index;
			}
			int num = Mathf.CeilToInt((float)count * 1f / (float)maxPainter);
			return serie.index / num;
		}

		private void InitListForFieldInfos()
		{
			if (m_TypeListForSerie.Count != 0)
			{
				return;
			}
			m_TypeListForComponent.Clear();
			m_TypeListForSerie.Clear();
			FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo[] fields2 = GetType().BaseType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			List<FieldInfo> list = ListPool<FieldInfo>.Get();
			list.AddRange(fields);
			list.AddRange(fields2);
			foreach (FieldInfo item in list)
			{
				ListForSerie attribute = item.GetAttribute<ListForSerie>(check: false);
				if (attribute != null)
				{
					m_TypeListForSerie.Add(attribute.type, item);
				}
				ListForComponent attribute2 = item.GetAttribute<ListForComponent>(check: false);
				if (attribute2 != null)
				{
					m_TypeListForComponent.Add(attribute2.type, item);
				}
			}
			ListPool<FieldInfo>.Release(list);
		}

		public void OnBeforeSerialize()
		{
			InitListForFieldInfos();
			foreach (KeyValuePair<Type, FieldInfo> item in m_TypeListForSerie)
			{
				ReflectionUtil.InvokeListClear(this, item.Value);
			}
			foreach (KeyValuePair<Type, FieldInfo> item2 in m_TypeListForComponent)
			{
				ReflectionUtil.InvokeListClear(this, item2.Value);
			}
			foreach (MainComponent component in m_Components)
			{
				if (m_TypeListForComponent.TryGetValue(component.GetType(), out var value))
				{
					ReflectionUtil.InvokeListAdd(this, value, component);
				}
				else
				{
					Debug.LogError("No ListForComponent:" + component.GetType());
				}
			}
			foreach (Serie item3 in m_Series)
			{
				item3.OnBeforeSerialize();
				if (m_TypeListForSerie.TryGetValue(item3.GetType(), out var value2))
				{
					ReflectionUtil.InvokeListAdd(this, value2, item3);
				}
				else
				{
					Debug.LogError("No ListForSerie:" + item3.GetType());
				}
			}
		}

		public void OnAfterDeserialize()
		{
			InitListForFieldInfos();
			m_Components.Clear();
			m_Series.Clear();
			foreach (KeyValuePair<Type, FieldInfo> item in m_TypeListForComponent)
			{
				ReflectionUtil.InvokeListAddTo<MainComponent>(this, item.Value, AddComponent);
			}
			foreach (KeyValuePair<Type, FieldInfo> item2 in m_TypeListForSerie)
			{
				ReflectionUtil.InvokeListAddTo<Serie>(this, item2.Value, AddSerieAfterDeserialize);
			}
			m_Series.Sort();
			m_Components.Sort();
			InitComponentHandlers();
			InitSerieHandlers();
		}

		public virtual void InitAxisRuntimeData(Axis axis)
		{
		}

		public virtual void GetSeriesMinMaxValue(Axis axis, int axisIndex, out double tempMinValue, out double tempMaxValue)
		{
			if (IsAllAxisValue())
			{
				if (axis is XAxis)
				{
					SeriesHelper.GetXMinMaxValue(this, axisIndex, isValueAxis: true, axis.inverse, out tempMinValue, out tempMaxValue, isPolar: false, filterByDataZoom: false);
				}
				else
				{
					SeriesHelper.GetYMinMaxValue(this, axisIndex, isValueAxis: true, axis.inverse, out tempMinValue, out tempMaxValue);
				}
			}
			else
			{
				SeriesHelper.GetYMinMaxValue(this, axisIndex, isValueAxis: false, axis.inverse, out tempMinValue, out tempMaxValue);
			}
			AxisHelper.AdjustMinMaxValue(axis, ref tempMinValue, ref tempMaxValue, needFormat: true);
		}

		public void DrawClipPolygon(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Color32 color, bool clip, GridCoord grid)
		{
			DrawClipPolygon(vh, p1, p2, p3, p4, color, color, clip, grid);
		}

		public void DrawClipPolygon(VertexHelper vh, Vector3 p, float radius, Color32 color, bool clip, bool vertical, GridCoord grid)
		{
			if (IsInChart(p) && (!clip || (clip && grid.Contains(p))))
			{
				UGL.DrawSquare(vh, p, radius, color);
			}
		}

		public void DrawClipPolygon(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Color32 startColor, Color32 toColor, bool clip, GridCoord grid)
		{
			ClampInChart(ref p1);
			ClampInChart(ref p2);
			ClampInChart(ref p3);
			ClampInChart(ref p4);
			if (clip)
			{
				p1 = ClampInGrid(grid, p1);
				p2 = ClampInGrid(grid, p2);
				p3 = ClampInGrid(grid, p3);
				p4 = ClampInGrid(grid, p4);
			}
			if (!clip || (clip && grid.Contains(p1) && grid.Contains(p2) && grid.Contains(p3) && grid.Contains(p4)))
			{
				UGL.DrawQuadrilateral(vh, p1, p2, p3, p4, startColor, toColor);
			}
		}

		public void DrawClipPolygon(VertexHelper vh, ref Vector3 p1, ref Vector3 p2, ref Vector3 p3, ref Vector3 p4, Color32 startColor, Color32 toColor, bool clip, GridCoord grid)
		{
			ClampInChart(ref p1);
			ClampInChart(ref p2);
			ClampInChart(ref p3);
			ClampInChart(ref p4);
			if (clip)
			{
				p1 = ClampInGrid(grid, p1);
				p2 = ClampInGrid(grid, p2);
				p3 = ClampInGrid(grid, p3);
				p4 = ClampInGrid(grid, p4);
			}
			if (!clip || (clip && grid.Contains(p1) && grid.Contains(p2) && grid.Contains(p3) && grid.Contains(p4)))
			{
				UGL.DrawQuadrilateral(vh, p1, p2, p3, p4, startColor, toColor);
			}
		}

		public void DrawClipTriangle(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Color32 color, bool clip, GridCoord grid)
		{
			DrawClipTriangle(vh, p1, p2, p3, color, color, color, clip, grid);
		}

		public void DrawClipTriangle(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Color32 color, Color32 color2, Color32 color3, bool clip, GridCoord grid)
		{
			if (IsInChart(p1) && IsInChart(p2) && IsInChart(p3) && (!clip || (clip && (grid.Contains(p1) || grid.Contains(p2) || grid.Contains(p3)))))
			{
				UGL.DrawTriangle(vh, p1, p2, p3, color, color2, color3);
			}
		}

		public void DrawClipLine(VertexHelper vh, Vector3 p1, Vector3 p2, float size, Color32 color, bool clip, GridCoord grid)
		{
			if (IsInChart(p1) && IsInChart(p2) && (!clip || (clip && (grid.Contains(p1) || grid.Contains(p2)))))
			{
				UGL.DrawLine(vh, p1, p2, size, color);
			}
		}

		public void DrawClipSymbol(VertexHelper vh, SymbolType type, float symbolSize, float tickness, Vector3 pos, Color32 color, Color32 toColor, Color32 emptyColor, Color32 borderColor, float gap, bool clip, float[] cornerRadius, GridCoord grid, Vector3 startPos)
		{
			if (IsInChart(pos) && (!clip || (clip && grid.Contains(pos))))
			{
				DrawSymbol(vh, type, symbolSize, tickness, pos, color, toColor, emptyColor, borderColor, gap, cornerRadius, startPos);
			}
		}

		public void DrawClipZebraLine(VertexHelper vh, Vector3 p1, Vector3 p2, float size, float zebraWidth, float zebraGap, Color32 color, Color32 toColor, bool clip, GridCoord grid, float maxDistance)
		{
			ClampInChart(ref p1);
			ClampInChart(ref p2);
			UGL.DrawZebraLine(vh, p1, p2, size, zebraWidth, zebraGap, color, toColor, maxDistance);
		}

		public void DrawSymbol(VertexHelper vh, SymbolType type, float symbolSize, float tickness, Vector3 pos, Color32 color, Color32 toColor, Color32 emptyColor, Color32 borderColor, float gap, float[] cornerRadius)
		{
			DrawSymbol(vh, type, symbolSize, tickness, pos, color, toColor, emptyColor, borderColor, gap, cornerRadius, Vector3.zero);
		}

		public void DrawSymbol(VertexHelper vh, SymbolType type, float symbolSize, float tickness, Vector3 pos, Color32 color, Color32 toColor, Color32 emptyColor, Color32 borderColor, float gap, float[] cornerRadius, Vector3 startPos)
		{
			Color32 chartBackgroundColor = GetChartBackgroundColor();
			if (ChartHelper.IsClearColor(emptyColor))
			{
				emptyColor = chartBackgroundColor;
			}
			float cicleSmoothness = settings.cicleSmoothness;
			ChartDrawer.DrawSymbol(vh, type, symbolSize, tickness, pos, color, toColor, gap, cornerRadius, emptyColor, chartBackgroundColor, borderColor, cicleSmoothness, startPos);
		}

		public Color32 GetXLerpColor(Color32 areaColor, Color32 areaToColor, Vector3 pos, GridCoord grid)
		{
			if (ChartHelper.IsValueEqualsColor(areaColor, areaToColor))
			{
				return areaColor;
			}
			return Color32.Lerp(areaToColor, areaColor, (pos.y - grid.context.y) / grid.context.height);
		}

		public Color32 GetYLerpColor(Color32 areaColor, Color32 areaToColor, Vector3 pos, GridCoord grid)
		{
			if (ChartHelper.IsValueEqualsColor(areaColor, areaToColor))
			{
				return areaColor;
			}
			return Color32.Lerp(areaToColor, areaColor, (pos.x - grid.context.x) / grid.context.width);
		}

		public T AddSerie<T>(string serieName = null, bool show = true, bool addToHead = false) where T : Serie
		{
			if (!CanAddSerie<T>())
			{
				return null;
			}
			int index = -1;
			T val = InsertSerie(index, typeof(T), serieName, show, addToHead) as T;
			CreateSerieHandler(val);
			return val;
		}

		public T InsertSerie<T>(int index, string serieName = null, bool show = true) where T : Serie
		{
			if (!CanAddSerie<T>())
			{
				return null;
			}
			T result = InsertSerie(index, typeof(T), serieName, show) as T;
			InitSerieHandlers();
			return result;
		}

		public void InsertSerie(Serie serie, int index = -1, bool addToHead = false)
		{
			serie.AnimationRestart();
			AnimationStyleHelper.UpdateSerieAnimation(serie);
			if (addToHead)
			{
				m_Series.Insert(0, serie);
			}
			else if (index >= 0)
			{
				m_Series.Insert(index, serie);
			}
			else
			{
				m_Series.Add(serie);
			}
			ResetSeriesIndex();
			SeriesHelper.UpdateSerieNameList(this, ref m_LegendRealShowName);
		}

		public bool MoveUpSerie(int serieIndex)
		{
			if (serieIndex < 0 || serieIndex > m_Series.Count - 1)
			{
				return false;
			}
			if (serieIndex == 0)
			{
				return false;
			}
			Serie serie = GetSerie(serieIndex - 1);
			Serie serie2 = GetSerie(serieIndex);
			m_Series[serieIndex - 1] = serie2;
			m_Series[serieIndex] = serie;
			ResetSeriesIndex();
			InitSerieHandlers();
			RefreshChart();
			return true;
		}

		public bool MoveDownSerie(int serieIndex)
		{
			if (serieIndex < 0 || serieIndex > m_Series.Count - 1)
			{
				return false;
			}
			if (serieIndex == m_Series.Count - 1)
			{
				return false;
			}
			Serie serie = GetSerie(serieIndex + 1);
			Serie serie2 = GetSerie(serieIndex);
			m_Series[serieIndex + 1] = serie2;
			m_Series[serieIndex] = serie;
			ResetSeriesIndex();
			InitSerieHandlers();
			RefreshChart();
			return true;
		}

		public bool ResetDataIndex(int serieIndex)
		{
			return GetSerie(serieIndex)?.ResetDataIndex() ?? false;
		}

		public bool CanAddSerie<T>() where T : Serie
		{
			return CanAddSerie(typeof(T));
		}

		public bool CanAddSerie(Type type)
		{
			return m_TypeListForSerie.ContainsKey(type);
		}

		public bool HasSerie<T>() where T : Serie
		{
			return HasSerie(typeof(T));
		}

		public bool HasSerie(Type type)
		{
			if (!type.IsSubclassOf(typeof(Serie)))
			{
				return false;
			}
			foreach (Serie item in m_Series)
			{
				if (item.GetType() == type)
				{
					return true;
				}
			}
			return false;
		}

		public T GetSerie<T>() where T : Serie
		{
			foreach (Serie item in m_Series)
			{
				if (item is T)
				{
					return item as T;
				}
			}
			return null;
		}

		public Serie GetSerie(string serieName)
		{
			foreach (Serie item in m_Series)
			{
				if (string.IsNullOrEmpty(item.serieName))
				{
					if (string.IsNullOrEmpty(serieName))
					{
						return item;
					}
				}
				else if (item.serieName.Equals(serieName))
				{
					return item;
				}
			}
			return null;
		}

		public Serie GetSerie(int serieIndex)
		{
			if (serieIndex < 0 || serieIndex > m_Series.Count - 1)
			{
				return null;
			}
			return m_Series[serieIndex];
		}

		public T GetSerie<T>(int serieIndex) where T : Serie
		{
			if (serieIndex < 0 || serieIndex > m_Series.Count - 1)
			{
				return null;
			}
			return m_Series[serieIndex] as T;
		}

		public void RemoveSerie(string serieName)
		{
			for (int num = m_Series.Count - 1; num >= 0; num--)
			{
				Serie serie = m_Series[num];
				if (string.IsNullOrEmpty(serieName))
				{
					if (string.IsNullOrEmpty(serie.serieName))
					{
						RemoveSerie(serie);
					}
				}
				else if (serieName.Equals(serie.serieName))
				{
					RemoveSerie(serie);
				}
			}
		}

		public void RemoveSerie(int serieIndex)
		{
			if (serieIndex >= 0 && serieIndex <= m_Series.Count - 1)
			{
				RemoveSerie(m_Series[serieIndex]);
			}
		}

		public void RemoveSerie<T>() where T : Serie
		{
			for (int num = m_Series.Count - 1; num >= 0; num--)
			{
				Serie serie = m_Series[num];
				if (serie is T)
				{
					RemoveSerie(serie);
				}
			}
		}

		public void RemoveSerie(Serie serie)
		{
			serie.OnRemove();
			m_SerieHandlers.Remove(serie.handler);
			m_Series.Remove(serie);
			RefreshChart();
		}

		public bool ConvertSerie<T>(Serie serie) where T : Serie
		{
			return ConvertSerie(serie, typeof(T));
		}

		public bool ConvertSerie(Serie serie, Type type)
		{
			try
			{
				Serie newSerie = type.InvokeMember("ConvertSerie", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, new object[1] { serie }) as Serie;
				return ReplaceSerie(serie, newSerie);
			}
			catch
			{
				Debug.LogError($"ConvertSerie Failed: can't found {type.Name}.ConvertSerie(Serie serie)");
				return false;
			}
		}

		public bool ReplaceSerie(Serie oldSerie, Serie newSerie)
		{
			if (oldSerie == null || newSerie == null)
			{
				return false;
			}
			int num = m_Series.IndexOf(oldSerie);
			if (num < 0)
			{
				return false;
			}
			AnimationStyleHelper.UpdateSerieAnimation(newSerie);
			oldSerie.OnRemove();
			m_Series.RemoveAt(num);
			m_Series.Insert(num, newSerie);
			ResetSeriesIndex();
			InitSerieHandlers();
			RefreshAllComponent();
			RefreshChart();
			return true;
		}

		public SerieData AddData(string serieName, double data, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				SerieData result = serie.AddYData(data, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public SerieData AddData(int serieIndex, double data, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				SerieData result = serie.AddYData(data, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public SerieData AddData(string serieName, List<double> multidimensionalData, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				SerieData result = serie.AddData(multidimensionalData, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public SerieData AddData(int serieIndex, List<double> multidimensionalData, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				SerieData result = serie.AddData(multidimensionalData, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		[Since("v3.4.0")]
		public SerieData AddData(int serieIndex, params double[] multidimensionalData)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				SerieData result = serie.AddData(multidimensionalData);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		[Since("v3.4.0")]
		public SerieData AddData(string serieName, params double[] multidimensionalData)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				SerieData result = serie.AddData(multidimensionalData);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public SerieData AddData(string serieName, double xValue, double yValue, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				SerieData result = serie.AddXYData(xValue, yValue, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public SerieData AddData(int serieIndex, double xValue, double yValue, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				SerieData result = serie.AddXYData(xValue, yValue, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public SerieData AddData(string serieName, DateTime time, double yValue, string dataName = null, string dataId = null)
		{
			int timestamp = DateTimeUtil.GetTimestamp(time);
			return AddData(serieName, timestamp, yValue, dataName, dataId);
		}

		public SerieData AddData(int serieIndex, DateTime time, double yValue, string dataName = null, string dataId = null)
		{
			int timestamp = DateTimeUtil.GetTimestamp(time);
			return AddData(serieIndex, timestamp, yValue, dataName, dataId);
		}

		public SerieData AddData(int serieIndex, double indexOrTimestamp, double open, double close, double lowest, double heighest, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				SerieData result = serie.AddData(indexOrTimestamp, open, close, lowest, heighest, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public SerieData AddData(string serieName, double indexOrTimestamp, double open, double close, double lowest, double heighest, string dataName = null, string dataId = null)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				SerieData result = serie.AddData(indexOrTimestamp, open, close, lowest, heighest, dataName, dataId);
				RefreshPainter(serie.painter);
				return result;
			}
			return null;
		}

		public bool UpdateData(string serieName, int dataIndex, double value)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				serie.UpdateYData(dataIndex, value);
				RefreshPainter(serie);
				return true;
			}
			return false;
		}

		public bool UpdateData(int serieIndex, int dataIndex, double value)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				serie.UpdateYData(dataIndex, value);
				RefreshPainter(serie);
				return true;
			}
			return false;
		}

		public bool UpdateData(string serieName, int dataIndex, List<double> multidimensionalData)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				serie.UpdateData(dataIndex, multidimensionalData);
				RefreshPainter(serie);
				return true;
			}
			return false;
		}

		public bool UpdateData(int serieIndex, int dataIndex, List<double> multidimensionalData)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				serie.UpdateData(dataIndex, multidimensionalData);
				RefreshPainter(serie);
				return true;
			}
			return false;
		}

		public bool UpdateData(string serieName, int dataIndex, int dimension, double value)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				serie.UpdateData(dataIndex, dimension, value);
				RefreshPainter(serie);
				return true;
			}
			return false;
		}

		public bool UpdateData(int serieIndex, int dataIndex, int dimension, double value)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				serie.UpdateData(dataIndex, dimension, value);
				RefreshPainter(serie);
				return true;
			}
			return false;
		}

		public bool UpdateDataName(string serieName, int dataIndex, string dataName)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				serie.UpdateDataName(dataIndex, dataName);
				return true;
			}
			return false;
		}

		public bool UpdateDataName(int serieIndex, int dataIndex, string dataName)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				serie.UpdateDataName(dataIndex, dataName);
				return true;
			}
			return false;
		}

		public double GetData(string serieName, int dataIndex, int dimension = 1)
		{
			return GetSerie(serieName)?.GetData(dataIndex, dimension) ?? 0.0;
		}

		public double GetData(int serieIndex, int dataIndex, int dimension = 1)
		{
			return GetSerie(serieIndex)?.GetData(dataIndex, dimension) ?? 0.0;
		}

		public int GetAllSerieDataCount()
		{
			int num = 0;
			foreach (Serie item in m_Series)
			{
				num += item.dataCount;
			}
			return num;
		}

		public void SetSerieActive(string serieName, bool active)
		{
			Serie serie = GetSerie(serieName);
			if (serie != null)
			{
				SetSerieActive(serie, active);
			}
		}

		public void SetSerieActive(int serieIndex, bool active)
		{
			Serie serie = GetSerie(serieIndex);
			if (serie != null)
			{
				SetSerieActive(serie, active);
			}
		}

		public void SetSerieActive(Serie serie, bool active)
		{
			serie.show = active;
			serie.RefreshLabel();
			serie.AnimationReset();
			if (active)
			{
				serie.AnimationFadeIn();
			}
			UpdateLegendColor(serie.serieName, active);
		}

		public void AddXAxisData(string category, int xAxisIndex = 0)
		{
			GetChartComponent<XAxis>(xAxisIndex)?.AddData(category);
		}

		public void UpdateXAxisData(int index, string category, int xAxisIndex = 0)
		{
			GetChartComponent<XAxis>(xAxisIndex)?.UpdateData(index, category);
		}

		public void AddXAxisIcon(Sprite icon, int xAxisIndex = 0)
		{
			GetChartComponent<XAxis>(xAxisIndex)?.AddIcon(icon);
		}

		public void UpdateXAxisIcon(int index, Sprite icon, int xAxisIndex = 0)
		{
			GetChartComponent<XAxis>(xAxisIndex)?.UpdateIcon(index, icon);
		}

		public void AddYAxisData(string category, int yAxisIndex = 0)
		{
			GetChartComponent<YAxis>(yAxisIndex)?.AddData(category);
		}

		public void UpdateYAxisData(int index, string category, int yAxisIndex = 0)
		{
			GetChartComponent<YAxis>(yAxisIndex)?.UpdateData(index, category);
		}

		public void AddYAxisIcon(Sprite icon, int yAxisIndex = 0)
		{
			GetChartComponent<YAxis>(yAxisIndex)?.AddIcon(icon);
		}

		public void UpdateYAxisIcon(int index, Sprite icon, int yAxisIndex = 0)
		{
			GetChartComponent<YAxis>(yAxisIndex)?.UpdateIcon(index, icon);
		}

		public float GetSerieBarGap<T>() where T : Serie
		{
			float result = 0f;
			for (int i = 0; i < m_Series.Count; i++)
			{
				Serie serie = m_Series[i];
				if (serie.show && serie is T && serie.barGap != 0f)
				{
					result = serie.barGap;
				}
			}
			return result;
		}

		public double GetSerieSameStackTotalValue<T>(string stack, int dataIndex) where T : Serie
		{
			if (string.IsNullOrEmpty(stack))
			{
				return 0.0;
			}
			double num = 0.0;
			foreach (Serie item in m_Series)
			{
				if (item is T && stack.Equals(item.stack))
				{
					num += item.data[dataIndex].data[1];
				}
			}
			return num;
		}

		public int GetSerieBarRealCount<T>() where T : Serie
		{
			int num = 0;
			barStackSet.Clear();
			for (int i = 0; i < m_Series.Count; i++)
			{
				Serie serie = m_Series[i];
				if (!serie.show || !(serie is T))
				{
					continue;
				}
				if (!string.IsNullOrEmpty(serie.stack))
				{
					if (barStackSet.Contains(serie.stack))
					{
						continue;
					}
					barStackSet.Add(serie.stack);
				}
				num++;
			}
			return num;
		}

		public float GetSerieTotalWidth<T>(float categoryWidth, float gap, int realBarCount) where T : Serie
		{
			float num = 0f;
			float num2 = 0f;
			barStackSet.Clear();
			for (int i = 0; i < m_Series.Count; i++)
			{
				Serie serie = m_Series[i];
				if (!serie.show || !(serie is T))
				{
					continue;
				}
				if (!string.IsNullOrEmpty(serie.stack))
				{
					if (barStackSet.Contains(serie.stack))
					{
						continue;
					}
					barStackSet.Add(serie.stack);
				}
				float stackBarWidth = GetStackBarWidth<T>(categoryWidth, serie, realBarCount);
				if (gap == -1f)
				{
					if (stackBarWidth > num)
					{
						num = stackBarWidth;
					}
				}
				else
				{
					num2 = ChartHelper.GetActualValue(gap, stackBarWidth);
					num += stackBarWidth;
					num += num2;
				}
			}
			if (num > 0f && gap != -1f)
			{
				num -= num2;
			}
			return num;
		}

		public float GetSerieTotalGap<T>(float categoryWidth, float gap, int index) where T : Serie
		{
			if (index <= 0)
			{
				return 0f;
			}
			float num = 0f;
			int num2 = 0;
			int serieBarRealCount = GetSerieBarRealCount<T>();
			barStackSet.Clear();
			for (int i = 0; i < m_Series.Count; i++)
			{
				Serie serie = m_Series[i];
				if (!serie.show || !(serie is T))
				{
					continue;
				}
				if (!string.IsNullOrEmpty(serie.stack))
				{
					if (barStackSet.Contains(serie.stack))
					{
						continue;
					}
					barStackSet.Add(serie.stack);
				}
				float stackBarWidth = GetStackBarWidth<T>(categoryWidth, serie, serieBarRealCount);
				if (gap == -1f)
				{
					if (stackBarWidth > num)
					{
						num = stackBarWidth;
					}
				}
				else
				{
					num += stackBarWidth + ChartHelper.GetActualValue(gap, stackBarWidth);
				}
				if (num2 + 1 >= index)
				{
					break;
				}
				num2++;
			}
			return num;
		}

		private float GetStackBarWidth<T>(float categoryWidth, Serie now, int realBarCount) where T : Serie
		{
			if (string.IsNullOrEmpty(now.stack))
			{
				return now.GetBarWidth(categoryWidth, realBarCount);
			}
			float num = 0f;
			for (int i = 0; i < m_Series.Count; i++)
			{
				Serie serie = m_Series[i];
				if (serie is T && serie.show && now.stack.Equals(serie.stack) && serie.barWidth > num)
				{
					num = serie.barWidth;
				}
			}
			if (num == 0f)
			{
				float actualValue = ChartHelper.GetActualValue(0.6f, categoryWidth);
				if (realBarCount == 0)
				{
					if (!(actualValue < 1f))
					{
						return actualValue;
					}
					return categoryWidth;
				}
				return actualValue / (float)realBarCount;
			}
			return ChartHelper.GetActualValue(num, categoryWidth);
		}

		public int GetSerieIndexIfStack<T>(Serie currSerie) where T : Serie
		{
			tempList.Clear();
			int num = 0;
			for (int i = 0; i < m_Series.Count; i++)
			{
				Serie serie = m_Series[i];
				if (!serie.show || !(serie is T))
				{
					continue;
				}
				if (string.IsNullOrEmpty(serie.stack))
				{
					if (serie.index == currSerie.index)
					{
						return num;
					}
					tempList.Add(string.Empty);
					num++;
				}
				else if (!tempList.Contains(serie.stack))
				{
					if (serie.index == currSerie.index)
					{
						return num;
					}
					tempList.Add(serie.stack);
					num++;
				}
				else if (serie.index == currSerie.index)
				{
					return tempList.IndexOf(serie.stack);
				}
			}
			return 0;
		}

		internal void InitSerieHandlers()
		{
			m_SerieHandlers.Clear();
			for (int i = 0; i < m_Series.Count; i++)
			{
				Serie serie = m_Series[i];
				serie.index = i;
				CreateSerieHandler(serie);
			}
		}

		private void CreateSerieHandler(Serie serie)
		{
			if (serie == null)
			{
				throw new ArgumentNullException("serie is null");
			}
			if (serie.GetType().IsDefined(typeof(DefaultTooltipAttribute), inherit: false))
			{
				DefaultTooltipAttribute attribute = serie.GetType().GetAttribute<DefaultTooltipAttribute>();
				if (attribute != null)
				{
					serie.context.tooltipTrigger = attribute.trigger;
					serie.context.tooltipType = attribute.type;
				}
			}
			if (!serie.GetType().IsDefined(typeof(SerieHandlerAttribute), inherit: false))
			{
				Debug.LogError("Serie no Handler:" + serie.GetType());
				return;
			}
			SerieHandlerAttribute attribute2 = serie.GetType().GetAttribute<SerieHandlerAttribute>();
			SerieHandler serieHandler = (SerieHandler)Activator.CreateInstance(attribute2.handler);
			serieHandler.attribute = attribute2;
			serieHandler.chart = this;
			serieHandler.defaultDimension = 1;
			serieHandler.SetSerie(serie);
			serie.handler = serieHandler;
			m_SerieHandlers.Add(serieHandler);
		}

		private Serie InsertSerie(int index, Type type, string serieName, bool show = true, bool addToHead = false)
		{
			CheckAddRequireChartComponent(type);
			Serie serie = Activator.CreateInstance(type) as Serie;
			serie.show = show;
			serie.serieName = serieName;
			serie.serieType = type.Name;
			serie.index = m_Series.Count;
			if (type == typeof(Scatter))
			{
				serie.symbol.show = true;
				serie.symbol.type = SymbolType.Circle;
			}
			else if (type == typeof(Line))
			{
				serie.symbol.show = true;
				serie.symbol.type = SymbolType.EmptyCircle;
			}
			else if (type == typeof(Heatmap))
			{
				serie.symbol.show = true;
				serie.symbol.type = SymbolType.Rect;
			}
			else
			{
				serie.symbol.show = false;
			}
			InsertSerie(serie, index, addToHead);
			return serie;
		}

		private void ResetSeriesIndex()
		{
			for (int i = 0; i < m_Series.Count; i++)
			{
				m_Series[i].index = i;
			}
		}

		private void AddSerieAfterDeserialize(Serie serie)
		{
			serie.OnAfterDeserialize();
			m_Series.Add(serie);
		}

		public string GenerateDefaultSerieName()
		{
			return "serie" + m_Series.Count;
		}

		public bool IsSerieName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return false;
			}
			foreach (Serie item in m_Series)
			{
				if (name.Equals(item.serieName))
				{
					return true;
				}
			}
			return false;
		}
	}
}
