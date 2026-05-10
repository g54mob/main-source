using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	public abstract class SerieHandler
	{
		public BaseChart chart { get; internal set; }

		public SerieHandlerAttribute attribute { get; internal set; }

		public virtual int defaultDimension { get; internal set; }

		public virtual void InitComponent()
		{
		}

		public virtual void RemoveComponent()
		{
		}

		public virtual void CheckComponent(StringBuilder sb)
		{
		}

		public virtual void BeforeUpdate()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void AfterUpdate()
		{
		}

		public virtual void DrawBase(VertexHelper vh)
		{
		}

		public virtual void DrawSerie(VertexHelper vh)
		{
		}

		public virtual void DrawUpper(VertexHelper vh)
		{
		}

		public virtual void DrawTop(VertexHelper vh)
		{
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		public virtual void OnScroll(PointerEventData eventData)
		{
		}

		public virtual void RefreshLabelNextFrame()
		{
		}

		public virtual void RefreshLabelInternal()
		{
		}

		public virtual void ForceUpdateSerieContext()
		{
		}

		public virtual void UpdateSerieContext()
		{
		}

		public virtual void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
		}

		public virtual void OnLegendButtonClick(int index, string legendName, bool show)
		{
		}

		public virtual void OnLegendButtonEnter(int index, string legendName)
		{
		}

		public virtual void OnLegendButtonExit(int index, string legendName)
		{
		}

		internal abstract void SetSerie(Serie serie);

		public virtual int GetPointerItemDataIndex()
		{
			return -1;
		}

		public virtual int GetPointerItemDataDimension()
		{
			return 1;
		}
	}
	public abstract class SerieHandler<T> : SerieHandler where T : Serie
	{
		private static readonly string s_SerieLabelObjectName = "label";

		private static readonly string s_SerieTitleObjectName = "title";

		private static readonly string s_SerieRootObjectName = "serie";

		private static readonly string s_SerieEndLabelObjectName = "end_label";

		protected GameObject m_SerieRoot;

		protected GameObject m_SerieLabelRoot;

		protected bool m_InitedLabel;

		protected bool m_NeedInitComponent;

		protected bool m_RefreshLabel;

		protected bool m_LastCheckContextFlag;

		protected bool m_LegendEnter;

		protected bool m_LegendExiting;

		protected bool m_ForceUpdateSerieContext;

		protected int m_LegendEnterIndex;

		protected ChartLabel m_EndLabel;

		private float[] m_LastRadius = new float[2];

		private float[] m_LastCenter = new float[2];

		private bool m_LastPointerEnter;

		private int m_LastPointerDataIndex;

		private int m_LastPointerDataDimension;

		public T serie { get; internal set; }

		public GameObject labelObject => m_SerieLabelRoot;

		internal override void SetSerie(Serie serie)
		{
			this.serie = (T)serie;
			this.serie.context.param.serieType = typeof(T);
			m_NeedInitComponent = true;
			AnimationStyleHelper.UpdateSerieAnimation(serie);
		}

		public override void BeforeUpdate()
		{
			m_LastPointerEnter = serie.context.pointerEnter;
			m_LastPointerDataIndex = serie.context.pointerItemDataIndex;
			m_LastPointerDataDimension = GetPointerItemDataDimension();
			serie.context.pointerEnter = false;
			serie.context.pointerItemDataIndex = -1;
		}

		public override void Update()
		{
			CheckConfigurationChanged();
			if (m_NeedInitComponent)
			{
				m_NeedInitComponent = false;
				InitComponent();
			}
			if (m_RefreshLabel)
			{
				m_RefreshLabel = false;
				RefreshLabelInternal();
				RefreshEndLabelInternal();
			}
			if (serie.dataDirty)
			{
				SeriesHelper.UpdateSerieNameList(base.chart, ref base.chart.m_LegendRealShowName);
				serie.OnDataUpdate();
				serie.dataDirty = false;
			}
			if (serie.label != null && (serie.labelDirty || serie.label.componentDirty))
			{
				serie.labelDirty = false;
				serie.label.ClearComponentDirty();
				InitSerieLabel();
				InitSerieEndLabel();
			}
			if (serie.endLabel != null && serie.endLabel.componentDirty)
			{
				serie.endLabel.ClearComponentDirty();
				InitSerieEndLabel();
			}
			if (serie.titleStyle != null && (serie.titleDirty || serie.titleStyle.componentDirty))
			{
				serie.titleDirty = false;
				serie.titleStyle.ClearComponentDirty();
				InitSerieTitle();
			}
			if (serie.nameDirty)
			{
				foreach (MainComponent component in base.chart.components)
				{
					if (component is Legend)
					{
						component.SetAllDirty();
					}
				}
				base.chart.RefreshChart();
				serie.ClearSerieNameDirty();
			}
			if (serie.vertsDirty)
			{
				base.chart.RefreshPainter(serie);
				serie.ClearVerticesDirty();
			}
			if (serie.interactDirty)
			{
				serie.interactDirty = false;
				m_ForceUpdateSerieContext = true;
			}
		}

		public override void AfterUpdate()
		{
			UpdateSerieContextInternal();
		}

		public override void ForceUpdateSerieContext()
		{
			m_ForceUpdateSerieContext = true;
		}

		private void CheckConfigurationChanged()
		{
			if (m_LastRadius[0] != serie.radius[0] || m_LastRadius[1] != serie.radius[1])
			{
				m_LastRadius[0] = serie.radius[0];
				m_LastRadius[1] = serie.radius[1];
				serie.SetVerticesDirty();
			}
			if (m_LastCenter[0] != serie.center[0] || m_LastCenter[1] != serie.center[1])
			{
				m_LastCenter[0] = serie.center[0];
				m_LastCenter[1] = serie.center[1];
				serie.SetVerticesDirty();
			}
		}

		private void UpdateSerieContextInternal()
		{
			UpdateSerieContext();
			m_ForceUpdateSerieContext = false;
			if ((m_LastPointerEnter == serie.context.pointerEnter && m_LastPointerDataIndex == serie.context.pointerItemDataIndex) || (base.chart.onSerieEnter == null && base.chart.onSerieExit == null && serie.onEnter == null && serie.onExit == null))
			{
				return;
			}
			if (serie.context.pointerEnter)
			{
				if ((serie.onExit != null || base.chart.onSerieExit != null) && m_LastPointerDataIndex >= 0)
				{
					double data = serie.GetData(m_LastPointerDataIndex, m_LastPointerDataDimension);
					SerieEventData serieEventData = SerieEventDataPool.Get(base.chart.pointerPos, serie.index, m_LastPointerDataIndex, m_LastPointerDataDimension, data);
					if (serie.onExit != null)
					{
						serie.onExit(serieEventData);
					}
					if (base.chart.onSerieExit != null)
					{
						base.chart.onSerieExit(serieEventData);
					}
					SerieEventDataPool.Release(serieEventData);
				}
				int pointerItemDataIndex = GetPointerItemDataIndex();
				int pointerItemDataDimension = GetPointerItemDataDimension();
				double data2 = serie.GetData(pointerItemDataIndex, pointerItemDataDimension);
				SerieEventData serieEventData2 = SerieEventDataPool.Get(base.chart.pointerPos, serie.index, pointerItemDataIndex, pointerItemDataDimension, data2);
				if (serie.onEnter != null)
				{
					serie.onEnter(serieEventData2);
				}
				if (base.chart.onSerieEnter != null)
				{
					base.chart.onSerieEnter(serieEventData2);
				}
				SerieEventDataPool.Release(serieEventData2);
			}
			else if (m_LastPointerDataIndex >= 0)
			{
				double data3 = serie.GetData(m_LastPointerDataIndex, m_LastPointerDataDimension);
				SerieEventData serieEventData3 = SerieEventDataPool.Get(base.chart.pointerPos, serie.index, m_LastPointerDataIndex, m_LastPointerDataDimension, data3);
				if (serie.onExit != null)
				{
					serie.onExit(serieEventData3);
				}
				if (base.chart.onSerieExit != null)
				{
					base.chart.onSerieExit(serieEventData3);
				}
				SerieEventDataPool.Release(serieEventData3);
			}
		}

		public override void RefreshLabelNextFrame()
		{
			m_RefreshLabel = true;
		}

		public override void InitComponent()
		{
			m_InitedLabel = false;
			serie.context.totalDataIndex = serie.dataCount - 1;
			InitRoot();
			InitSerieLabel();
			InitSerieTitle();
			InitSerieEndLabel();
		}

		public override void RemoveComponent()
		{
			ChartHelper.SetActive(m_SerieRoot, active: false);
		}

		public override void OnLegendButtonClick(int index, string legendName, bool show)
		{
			if (serie.colorByData && serie.IsSerieDataLegendName(legendName))
			{
				LegendHelper.CheckDataShow(serie, legendName, show);
				base.chart.UpdateLegendColor(legendName, show);
				base.chart.RefreshPainter(serie);
			}
			else if (serie.IsLegendName(legendName))
			{
				base.chart.SetSerieActive(serie, show);
				base.chart.RefreshPainter(serie);
			}
		}

		public override void OnLegendButtonEnter(int index, string legendName)
		{
			if (serie.colorByData && serie.IsSerieDataLegendName(legendName))
			{
				m_LegendEnterIndex = LegendHelper.CheckDataHighlighted(serie, legendName, heighlight: true);
				m_LegendEnter = true;
				base.chart.RefreshPainter(serie);
			}
			else if (serie.IsLegendName(legendName))
			{
				m_LegendEnter = true;
				base.chart.RefreshPainter(serie);
			}
		}

		public override void OnLegendButtonExit(int index, string legendName)
		{
			if (serie.colorByData && serie.IsSerieDataLegendName(legendName))
			{
				LegendHelper.CheckDataHighlighted(serie, legendName, heighlight: false);
				m_LegendEnter = false;
				m_LegendExiting = true;
				base.chart.RefreshPainter(serie);
			}
			else if (serie.IsLegendName(legendName))
			{
				m_LegendEnter = false;
				m_LegendExiting = true;
				base.chart.RefreshPainter(serie);
			}
		}

		private void InitRoot()
		{
			if (m_SerieRoot != null)
			{
				RectTransform rectTransform = ChartHelper.EnsureComponent<RectTransform>(m_SerieRoot);
				rectTransform.localPosition = Vector3.zero;
				rectTransform.sizeDelta = base.chart.chartSizeDelta;
				rectTransform.anchorMin = base.chart.chartMinAnchor;
				rectTransform.anchorMax = base.chart.chartMaxAnchor;
				rectTransform.pivot = base.chart.chartPivot;
			}
			else
			{
				string name = s_SerieRootObjectName + "_" + serie.index;
				m_SerieRoot = ChartHelper.AddObject(name, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				m_SerieRoot.hideFlags = base.chart.chartHideFlags;
				ChartHelper.SetActive(m_SerieRoot, active: true);
				ChartHelper.HideAllObject(m_SerieRoot);
			}
		}

		private void InitSerieLabel()
		{
			InitRoot();
			m_SerieLabelRoot = ChartHelper.AddObject(s_SerieLabelObjectName, m_SerieRoot.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
			m_SerieLabelRoot.hideFlags = base.chart.chartHideFlags;
			SerieLabelPool.ReleaseAll(m_SerieLabelRoot.transform);
			int count = 0;
			SerieHelper.UpdateCenter(serie, base.chart);
			for (int i = 0; i < serie.data.Count; i++)
			{
				SerieData serieData = serie.data[i];
				serieData.index = i;
				serieData.labelObject = null;
				if (AddSerieLabel(m_SerieLabelRoot, serieData, ref count))
				{
					m_InitedLabel = true;
					count++;
				}
			}
			RefreshLabelInternal();
		}

		protected bool AddSerieLabel(GameObject serieLabelRoot, SerieData serieData, ref int count)
		{
			if (serieData == null)
			{
				return false;
			}
			if (serieLabelRoot == null)
			{
				return false;
			}
			if (serie.IsPerformanceMode())
			{
				return false;
			}
			if (count == -1)
			{
				count = serie.dataCount;
			}
			LabelStyle serieLabel = SerieHelper.GetSerieLabel(serie, serieData);
			if (serieLabel == null)
			{
				return false;
			}
			Color serieDataAutoColor = GetSerieDataAutoColor(serieData);
			serieData.context.dataLabels.Clear();
			if (serie.multiDimensionLabel)
			{
				for (int i = 0; i < serieData.data.Count; i++)
				{
					ChartLabel chartLabel = ChartHelper.AddChartLabel($"{s_SerieLabelObjectName}_{serie.index}_{serieData.index}_{i}", serieLabelRoot.transform, serieLabel, base.chart.theme.common, "", serieDataAutoColor);
					chartLabel.SetActive(serieLabel.show);
					serieData.context.dataLabels.Add(chartLabel);
				}
			}
			else
			{
				ChartLabel chartLabel2 = ChartHelper.AddChartLabel(ChartCached.GetSerieLabelName(s_SerieLabelObjectName, serie.index, serieData.index), serieLabelRoot.transform, serieLabel, base.chart.theme.common, "", serieDataAutoColor);
				chartLabel2.SetActive(serieLabel.show);
				serieData.labelObject = chartLabel2;
			}
			if (serieData.context.children.Count > 0)
			{
				foreach (SerieData child in serieData.context.children)
				{
					AddSerieLabel(serieLabelRoot, child, ref count);
					count++;
				}
			}
			return true;
		}

		private void InitSerieEndLabel()
		{
			if (serie.endLabel == null)
			{
				if (m_EndLabel != null)
				{
					m_EndLabel.SetActive(flag: false);
					m_EndLabel = null;
				}
			}
			else
			{
				InitRoot();
				Color autoColor = base.chart.GetLegendRealShowNameColor(serie.legendName);
				m_EndLabel = ChartHelper.AddChartLabel(s_SerieEndLabelObjectName, m_SerieRoot.transform, serie.endLabel, base.chart.theme.common, "", autoColor, TextAnchor.MiddleLeft);
				m_EndLabel.SetActive(serie.endLabel.show);
				RefreshEndLabelInternal();
			}
		}

		private void InitSerieTitle()
		{
			InitRoot();
			GameObject gameObject = ChartHelper.AddObject(s_SerieTitleObjectName, m_SerieRoot.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
			gameObject.hideFlags = base.chart.chartHideFlags;
			SerieLabelPool.ReleaseAll(gameObject.transform);
			ChartHelper.RemoveComponent<Text>(gameObject);
			SerieHelper.UpdateCenter(serie, base.chart);
			if (serie.titleJustForSerie)
			{
				TitleStyle titleStyle = SerieHelper.GetTitleStyle(serie, null);
				if (titleStyle != null)
				{
					Color32 itemColor = base.chart.GetItemColor(serie, null);
					string empty = string.Empty;
					if (string.IsNullOrEmpty(titleStyle.formatter))
					{
						empty = serie.serieName;
					}
					else
					{
						empty = titleStyle.formatter;
						FormatterHelper.ReplaceContent(ref empty, 0, titleStyle.numericFormatter, serie, base.chart);
					}
					ChartLabel chartLabel = ChartHelper.AddChartLabel("title_" + 0, gameObject.transform, titleStyle, base.chart.theme.common, empty, itemColor);
					serie.context.titleObject = chartLabel;
					chartLabel.SetActive(titleStyle.show);
					Vector3 serieDataTitlePosition = GetSerieDataTitlePosition(null, titleStyle);
					Vector3 offset = titleStyle.GetOffset(serie.context.insideRadius);
					chartLabel.SetPosition(serieDataTitlePosition + offset);
				}
				return;
			}
			for (int i = 0; i < serie.dataCount; i++)
			{
				SerieData serieData = serie.data[i];
				TitleStyle titleStyle2 = SerieHelper.GetTitleStyle(serie, serieData);
				if (titleStyle2 != null)
				{
					Color32 itemColor2 = base.chart.GetItemColor(serie, serieData);
					string empty2 = string.Empty;
					if (string.IsNullOrEmpty(titleStyle2.formatter))
					{
						empty2 = serieData.name;
					}
					else
					{
						empty2 = titleStyle2.formatter;
						FormatterHelper.ReplaceContent(ref empty2, 0, titleStyle2.numericFormatter, serie, base.chart);
					}
					FormatterHelper.ReplaceContent(ref empty2, i, titleStyle2.numericFormatter, serie, base.chart);
					ChartLabel chartLabel2 = (serieData.titleObject = ChartHelper.AddChartLabel("title_" + i, gameObject.transform, titleStyle2, base.chart.theme.common, empty2, itemColor2));
					chartLabel2.SetActive(titleStyle2.show);
					Vector3 serieDataTitlePosition2 = GetSerieDataTitlePosition(serieData, titleStyle2);
					Vector3 offset2 = titleStyle2.GetOffset(serie.context.insideRadius);
					chartLabel2.SetPosition(serieDataTitlePosition2 + offset2);
				}
			}
		}

		public override void RefreshLabelInternal()
		{
			if (!m_InitedLabel)
			{
				return;
			}
			float changeDuration = serie.animation.GetChangeDuration();
			float additionDuration = serie.animation.GetAdditionDuration();
			bool unscaledTime = serie.animation.unscaledTime;
			bool flag = serie.context.dataIndexs.Count > 0;
			foreach (SerieData datum in serie.data)
			{
				if (datum.labelObject == null && datum.context.dataLabels.Count <= 0)
				{
					continue;
				}
				if (flag && !serie.context.dataIndexs.Contains(datum.index))
				{
					datum.SetLabelActive(flag: false);
					continue;
				}
				LabelStyle serieLabel = SerieHelper.GetSerieLabel(serie, datum);
				bool flag2 = serie.IsIgnoreIndex(datum.index, defaultDimension);
				if (serie.show && serieLabel != null && serieLabel.show && datum.context.canShowLabel && !datum.context.isClip && !flag2)
				{
					if (serie.multiDimensionLabel)
					{
						double totalData = datum.GetTotalData();
						Color32 itemColor = base.chart.GetItemColor(serie, datum);
						for (int i = 0; i < datum.context.dataLabels.Count; i++)
						{
							if (i >= datum.context.dataPoints.Count)
							{
								continue;
							}
							ChartLabel chartLabel = datum.context.dataLabels[i];
							double currData = datum.GetCurrData(i, additionDuration, changeDuration, unscaledTime);
							string text = (string.IsNullOrEmpty(serieLabel.formatter) ? ChartCached.NumberToStr(currData, serieLabel.numericFormatter) : SerieLabelHelper.GetFormatterContent(serie, datum, currData, totalData, serieLabel, itemColor));
							Vector3 serieDataLabelOffset = GetSerieDataLabelOffset(datum, serieLabel);
							chartLabel.SetActive(serieLabel.show && !flag2);
							chartLabel.SetText(text);
							chartLabel.SetPosition(datum.context.dataPoints[i] + serieDataLabelOffset);
							chartLabel.UpdateIcon(serieLabel.icon);
							if (serieLabel.textStyle.autoColor)
							{
								Color serieDataAutoColor = GetSerieDataAutoColor(datum);
								if (!ChartHelper.IsClearColor(serieDataAutoColor))
								{
									chartLabel.SetTextColor(serieDataAutoColor);
								}
							}
						}
						continue;
					}
					double currData2 = datum.GetCurrData(defaultDimension, additionDuration, changeDuration, unscaledTime);
					double dataTotal = serie.GetDataTotal(defaultDimension, datum);
					Color32 itemColor2 = base.chart.GetItemColor(serie, datum);
					string text2 = (string.IsNullOrEmpty(serieLabel.formatter) ? ChartCached.NumberToStr(currData2, serieLabel.numericFormatter) : SerieLabelHelper.GetFormatterContent(serie, datum, currData2, dataTotal, serieLabel, itemColor2));
					datum.SetLabelActive(serieLabel.show && !flag2);
					datum.labelObject.UpdateIcon(serieLabel.icon);
					datum.labelObject.SetText(text2);
					UpdateLabelPosition(datum, serieLabel);
					if (serieLabel.textStyle.autoColor)
					{
						Color serieDataAutoColor2 = GetSerieDataAutoColor(datum);
						if (!ChartHelper.IsClearColor(serieDataAutoColor2))
						{
							datum.labelObject.SetTextColor(serieDataAutoColor2);
						}
					}
				}
				else
				{
					datum.SetLabelActive(flag: false);
				}
			}
		}

		public virtual void RefreshEndLabelInternal()
		{
			if (m_EndLabel == null)
			{
				return;
			}
			LabelStyle endLabel = serie.endLabel;
			if (endLabel != null)
			{
				int count = serie.context.dataPoints.Count;
				bool flag = endLabel.show && count > 0;
				m_EndLabel.SetActive(flag);
				if (flag)
				{
					double lineEndValue = serie.context.lineEndValue;
					string formatterContent = SerieLabelHelper.GetFormatterContent(serie, null, lineEndValue, 0.0, endLabel, Color.clear);
					m_EndLabel.SetText(formatterContent);
					m_EndLabel.SetPosition(serie.context.lineEndPostion + endLabel.offset);
				}
				m_EndLabel.isAnimationEnd = serie.animation.IsFinish();
			}
		}

		protected void UpdateLabelPosition(SerieData serieData, LabelStyle currLabel)
		{
			Vector3 serieDataLabelPosition = GetSerieDataLabelPosition(serieData, currLabel);
			Vector3 serieDataLabelOffset = GetSerieDataLabelOffset(serieData, currLabel);
			serieData.labelObject.SetPosition(serieDataLabelPosition + serieDataLabelOffset);
			if (currLabel.autoRotate && serieData.context.angle != 0f)
			{
				if (serieData.context.angle > 90f && serieData.context.angle < 270f)
				{
					serieData.labelObject.SetRotate(180f - serieData.context.angle + currLabel.rotate);
				}
				else
				{
					serieData.labelObject.SetRotate(0f - serieData.context.angle + currLabel.rotate);
				}
			}
		}

		public virtual Vector3 GetSerieDataLabelPosition(SerieData serieData, LabelStyle label)
		{
			if (!ChartHelper.IsZeroVector(serieData.context.labelPosition))
			{
				return serieData.context.labelPosition;
			}
			return serieData.context.position;
		}

		public virtual Vector3 GetSerieDataLabelOffset(SerieData serieData, LabelStyle label)
		{
			return label.GetOffset(serie.context.insideRadius);
		}

		public virtual Vector3 GetSerieDataTitlePosition(SerieData serieData, TitleStyle titleStyle)
		{
			return serieData.context.position;
		}

		public virtual Color GetSerieDataAutoColor(SerieData serieData)
		{
			int index = (serie.colorByData ? serieData.index : serie.index);
			SerieHelper.GetItemColor(out var color, out var _, serie, serieData, base.chart.theme, index, SerieState.Normal, opacity: false);
			return color;
		}

		protected void UpdateCoordSerieParams(ref List<SerieParams> paramList, ref string title, int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent)
		{
			int num = 1;
			if (dataIndex < 0)
			{
				dataIndex = serie.context.pointerItemDataIndex;
			}
			if (dataIndex < 0)
			{
				return;
			}
			SerieData serieData = serie.GetSerieData(dataIndex);
			if (serieData == null)
			{
				return;
			}
			bool flag = serie.IsIgnoreValue(serieData, num);
			if (!flag || !string.IsNullOrEmpty(ignoreDataDefaultContent))
			{
				itemFormatter = SerieHelper.GetItemFormatter(serie, serieData, itemFormatter);
				if (!serie.placeHolder && !TooltipHelper.IsIgnoreFormatter(itemFormatter))
				{
					SerieParams param = serie.context.param;
					param.serieName = serie.serieName;
					param.serieIndex = serie.index;
					param.category = category;
					param.dimension = num;
					param.serieData = serieData;
					param.dataCount = serie.dataCount;
					param.value = serieData.GetData(num);
					param.ignore = flag;
					param.total = serie.yTotal;
					param.color = base.chart.GetMarkColor(serie, serieData);
					param.marker = SerieHelper.GetItemMarker(serie, serieData, marker);
					param.itemFormatter = itemFormatter;
					param.numericFormatter = SerieHelper.GetNumericFormatter(serie, serieData, numericFormatter);
					param.columns.Clear();
					param.columns.Add(param.marker);
					param.columns.Add(showCategory ? category : serie.serieName);
					param.columns.Add(flag ? ignoreDataDefaultContent : ChartCached.NumberToStr(param.value, param.numericFormatter));
					paramList.Add(param);
				}
			}
		}

		protected void UpdateItemSerieParams(ref List<SerieParams> paramList, ref string title, int dataIndex, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, int dimension = 1, int colorIndex = -1)
		{
			if (dataIndex < 0)
			{
				dataIndex = serie.context.pointerItemDataIndex;
			}
			if (dataIndex < 0)
			{
				return;
			}
			SerieData serieData = serie.GetSerieData(dataIndex);
			if (serieData == null)
			{
				return;
			}
			bool flag = serie.IsIgnoreValue(serieData, dimension);
			if (flag && string.IsNullOrEmpty(ignoreDataDefaultContent))
			{
				return;
			}
			itemFormatter = SerieHelper.GetItemFormatter(serie, serieData, itemFormatter);
			if (!serie.placeHolder && !TooltipHelper.IsIgnoreFormatter(itemFormatter))
			{
				if (colorIndex < 0)
				{
					colorIndex = (serie.colorByData ? dataIndex : base.chart.GetLegendRealShowNameIndex(serieData.name));
				}
				SerieHelper.GetItemColor(out var color, out var _, serie, serieData, base.chart.theme, colorIndex, SerieState.Normal);
				SerieParams param = serie.context.param;
				param.serieName = serie.serieName;
				param.serieIndex = serie.index;
				param.category = category;
				param.dimension = dimension;
				param.serieData = serieData;
				param.dataCount = serie.dataCount;
				param.value = serieData.GetData(param.dimension);
				param.ignore = flag;
				param.total = (serie.multiDimensionLabel ? serieData.GetTotalData() : serie.GetDataTotal(defaultDimension));
				param.color = color;
				param.marker = SerieHelper.GetItemMarker(serie, serieData, marker);
				param.itemFormatter = itemFormatter;
				param.numericFormatter = SerieHelper.GetNumericFormatter(serie, serieData, numericFormatter);
				param.columns.Clear();
				param.columns.Add(param.marker);
				param.columns.Add(serieData.name);
				param.columns.Add(flag ? ignoreDataDefaultContent : ChartCached.NumberToStr(param.value, param.numericFormatter));
				paramList.Add(param);
			}
		}

		public void DrawLabelLineSymbol(VertexHelper vh, LabelLine labelLine, Vector3 startPos, Vector3 endPos, Color32 defaultColor)
		{
			if (labelLine.startSymbol != null && labelLine.startSymbol.show)
			{
				DrawSymbol(vh, labelLine.startSymbol, startPos, defaultColor);
			}
			if (labelLine.endSymbol != null && labelLine.endSymbol.show)
			{
				DrawSymbol(vh, labelLine.endSymbol, endPos, defaultColor);
			}
		}

		private void DrawSymbol(VertexHelper vh, SymbolStyle symbol, Vector3 pos, Color32 defaultColor)
		{
			Color32 color = symbol.GetColor(defaultColor);
			base.chart.DrawSymbol(vh, symbol.type, symbol.size, 1f, pos, color, color, ColorUtil.clearColor32, color, symbol.gap, null);
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if ((serie.onDown == null && base.chart.onSerieDown == null) || !serie.context.pointerEnter)
			{
				return;
			}
			int pointerItemDataIndex = GetPointerItemDataIndex();
			if (pointerItemDataIndex >= 0)
			{
				int pointerItemDataDimension = GetPointerItemDataDimension();
				double data = serie.GetData(pointerItemDataIndex, pointerItemDataDimension);
				SerieEventData serieEventData = SerieEventDataPool.Get(base.chart.pointerPos, serie.index, pointerItemDataIndex, pointerItemDataDimension, data);
				if (base.chart.onSerieDown != null)
				{
					base.chart.onSerieDown(serieEventData);
				}
				if (serie.onDown != null)
				{
					serie.onDown(serieEventData);
				}
				SerieEventDataPool.Release(serieEventData);
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if ((serie.onClick == null && base.chart.onSerieClick == null) || !serie.context.pointerEnter)
			{
				return;
			}
			int pointerItemDataIndex = GetPointerItemDataIndex();
			if (pointerItemDataIndex >= 0)
			{
				int pointerItemDataDimension = GetPointerItemDataDimension();
				double data = serie.GetData(pointerItemDataIndex, pointerItemDataDimension);
				SerieEventData serieEventData = SerieEventDataPool.Get(base.chart.pointerPos, serie.index, pointerItemDataIndex, pointerItemDataDimension, data);
				if (base.chart.onSerieClick != null)
				{
					base.chart.onSerieClick(serieEventData);
				}
				if (serie.onClick != null)
				{
					serie.onClick(serieEventData);
				}
				SerieEventDataPool.Release(serieEventData);
			}
		}

		public override int GetPointerItemDataIndex()
		{
			return serie.context.pointerItemDataIndex;
		}

		public override int GetPointerItemDataDimension()
		{
			return serie.context.pointerItemDataDimension;
		}
	}
}
