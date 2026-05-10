using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class HeatmapHandler : SerieHandler<Heatmap>
	{
		private GridCoord m_SerieGrid;

		private Dictionary<int, int> m_CountDict = new Dictionary<int, int>();

		private PolarCoord m_SeriePolar;

		public override int defaultDimension => 2;

		public static int GetGridKey(int x, int y)
		{
			return x * 100000 + y;
		}

		public static void GetGridXYByKey(int key, out int x, out int y)
		{
			x = key / 100000;
			y = key % 100000;
		}

		public override void Update()
		{
			base.Update();
		}

		public override void DrawSerie(VertexHelper vh)
		{
			if (base.serie.heatmapType == HeatmapType.Count)
			{
				DrawCountHeatmapSerie(vh, base.serie);
			}
			else if (base.serie.IsUseCoord<PolarCoord>())
			{
				DrawPolarHeatmap(vh, base.serie);
			}
			else if (base.serie.IsUseCoord<GridCoord>())
			{
				DrawDataHeatmapSerie(vh, base.serie);
			}
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			dataIndex = base.serie.context.pointerItemDataIndex;
			if (base.serie.heatmapType == HeatmapType.Count)
			{
				if (m_CountDict.TryGetValue(dataIndex, out var value))
				{
					VisualMap visualMapOfSerie = base.chart.GetVisualMapOfSerie(base.serie);
					int dimension = VisualMapHelper.GetDimension(visualMapOfSerie, defaultDimension);
					title = base.serie.serieName;
					SerieParams param = base.serie.context.param;
					param.serieName = base.serie.serieName;
					param.serieIndex = base.serie.index;
					param.dimension = dimension;
					param.dataCount = base.serie.dataCount;
					param.serieData = null;
					param.color = visualMapOfSerie.GetColor(value);
					param.marker = SerieHelper.GetItemMarker(base.serie, null, marker);
					param.itemFormatter = SerieHelper.GetItemFormatter(base.serie, null, itemFormatter);
					param.numericFormatter = SerieHelper.GetNumericFormatter(base.serie, null, numericFormatter);
					param.columns.Clear();
					param.columns.Add(param.marker);
					param.columns.Add("count");
					param.columns.Add(ChartCached.NumberToStr(value, param.numericFormatter));
					paramList.Add(param);
				}
			}
			else
			{
				if (dataIndex < 0)
				{
					return;
				}
				SerieData serieData = base.serie.GetSerieData(dataIndex);
				if (serieData == null)
				{
					return;
				}
				int dimension2 = VisualMapHelper.GetDimension(base.chart.GetVisualMapOfSerie(base.serie), defaultDimension);
				if (string.IsNullOrEmpty(category))
				{
					XAxis chartComponent = base.chart.GetChartComponent<XAxis>(base.serie.xAxisIndex);
					if (chartComponent != null)
					{
						category = chartComponent.GetData((int)serieData.GetData(0));
					}
				}
				title = base.serie.serieName;
				SerieParams param2 = base.serie.context.param;
				param2.serieName = base.serie.serieName;
				param2.serieIndex = base.serie.index;
				param2.dimension = dimension2;
				param2.dataCount = base.serie.dataCount;
				param2.serieData = serieData;
				param2.color = serieData.context.color;
				param2.marker = SerieHelper.GetItemMarker(base.serie, serieData, marker);
				param2.itemFormatter = SerieHelper.GetItemFormatter(base.serie, serieData, itemFormatter);
				param2.numericFormatter = SerieHelper.GetNumericFormatter(base.serie, serieData, numericFormatter);
				param2.columns.Clear();
				param2.columns.Add(param2.marker);
				param2.columns.Add(category);
				param2.columns.Add(ChartCached.NumberToStr(serieData.GetData(dimension2), param2.numericFormatter));
				paramList.Add(param2);
			}
		}

		public override void UpdateSerieContext()
		{
			if (base.serie.IsUseCoord<GridCoord>())
			{
				UpdateSerieGridContext();
			}
			else if (base.serie.IsUseCoord<PolarCoord>())
			{
				UpdateSeriePolarContext();
			}
		}

		private void UpdateSerieGridContext()
		{
			if (m_SerieGrid == null)
			{
				return;
			}
			bool flag = (base.chart.isPointerInChart && m_SerieGrid.IsPointerEnter()) || m_LegendEnter;
			bool flag2 = false;
			if (!flag)
			{
				if (m_LastCheckContextFlag == flag)
				{
					return;
				}
				m_LastCheckContextFlag = flag;
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				foreach (SerieData datum in base.serie.data)
				{
					datum.context.highlight = false;
				}
				base.chart.RefreshPainter(base.serie);
			}
			else
			{
				if (base.serie.heatmapType == HeatmapType.Count)
				{
					return;
				}
				m_LastCheckContextFlag = flag;
				if (m_LegendEnter)
				{
					base.serie.context.pointerEnter = true;
					foreach (SerieData datum2 in base.serie.data)
					{
						datum2.context.highlight = true;
					}
				}
				else
				{
					base.serie.context.pointerItemDataIndex = -1;
					base.serie.context.pointerEnter = false;
					foreach (SerieData datum3 in base.serie.data)
					{
						if (!flag2 && datum3.context.rect.Contains(base.chart.pointerPos))
						{
							base.serie.context.pointerItemDataIndex = datum3.index;
							base.serie.context.pointerEnter = true;
							datum3.context.highlight = true;
							flag2 = true;
						}
						else
						{
							datum3.context.highlight = false;
						}
					}
				}
				if (flag2)
				{
					base.chart.RefreshPainter(base.serie);
				}
			}
		}

		private void DrawDataHeatmapSerie(VertexHelper vh, Heatmap serie)
		{
			if (!serie.show || serie.animation.HasFadeOut() || !base.chart.TryGetChartComponent<XAxis>(out var component, serie.xAxisIndex) || !base.chart.TryGetChartComponent<YAxis>(out var component2, serie.yAxisIndex))
			{
				return;
			}
			VisualMap visualMapOfSerie = base.chart.GetVisualMapOfSerie(serie);
			if (visualMapOfSerie == null)
			{
				return;
			}
			m_SerieGrid = base.chart.GetChartComponent<GridCoord>(component.gridIndex);
			component.boundaryGap = true;
			component2.boundaryGap = true;
			EmphasisStyle emphasisStyle = serie.emphasisStyle;
			int totalSplitGridNum = AxisHelper.GetTotalSplitGridNum(component);
			int totalSplitGridNum2 = AxisHelper.GetTotalSplitGridNum(component2);
			float num = m_SerieGrid.context.width / (float)totalSplitGridNum;
			float num2 = m_SerieGrid.context.height / (float)totalSplitGridNum2;
			float x = m_SerieGrid.context.x;
			float y = m_SerieGrid.context.y;
			float num3 = (serie.itemStyle.show ? serie.itemStyle.borderWidth : 0f);
			float num4 = num - 2f * num3;
			float num5 = num2 - 2f * num3;
			float defaultSize = Mathf.Min(num4, num5) * 0.25f;
			serie.animation.InitProgress(0f, totalSplitGridNum);
			int currIndex = serie.animation.GetCurrIndex();
			float changeDuration = serie.animation.GetChangeDuration();
			float additionDuration = serie.animation.GetAdditionDuration();
			bool unscaledTime = serie.animation.unscaledTime;
			bool flag = false;
			serie.containerIndex = m_SerieGrid.index;
			serie.containterInstanceId = m_SerieGrid.instanceId;
			int dimension = VisualMapHelper.GetDimension(visualMapOfSerie, defaultDimension);
			if (visualMapOfSerie.autoMinMax)
			{
				SerieHelper.GetMinMaxData(serie, dimension, out var min, out var max);
				VisualMapHelper.SetMinMax(visualMapOfSerie, min, max);
			}
			double rangeMin = visualMapOfSerie.rangeMin;
			double rangeMax = visualMapOfSerie.rangeMax;
			Color32 color = base.chart.theme.GetColor(serie.index);
			float border = 0f;
			float[] cornerRadius = null;
			for (int i = 0; i < serie.dataCount; i++)
			{
				SerieData serieData = serie.data[i];
				double data = serieData.GetData(0);
				double data2 = serieData.GetData(1);
				int axisValueSplitIndex = AxisHelper.GetAxisValueSplitIndex(component, data, totalSplitGridNum);
				int axisValueSplitIndex2 = AxisHelper.GetAxisValueSplitIndex(component2, data2, totalSplitGridNum2);
				if (serie.IsIgnoreValue(serieData, dimension))
				{
					serie.context.dataPoints.Add(Vector3.zero);
					serie.context.dataIndexs.Add(serieData.index);
					continue;
				}
				SerieState serieState = SerieHelper.GetSerieState(serie, serieData, defaultSerieState: true);
				SerieSymbol serieSymbol = SerieHelper.GetSerieSymbol(serie, serieData, serieState);
				bool flag2 = serieSymbol.type == SymbolType.Rect;
				SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, serie, serieData, base.chart.theme, serieState);
				double currData = serieData.GetCurrData(dimension, additionDuration, changeDuration, component2.inverse, component2.context.minValue, component2.context.maxValue, unscaledTime);
				if (serieData.IsDataChanged())
				{
					flag = true;
				}
				Vector3 vector = new Vector3(x + ((float)axisValueSplitIndex + 0.5f) * num, y + ((float)axisValueSplitIndex2 + 0.5f) * num2);
				serie.context.dataPoints.Add(vector);
				serie.context.dataIndexs.Add(serieData.index);
				serieData.context.position = vector;
				serieData.context.canShowLabel = false;
				if ((currData < rangeMin && rangeMin != visualMapOfSerie.min) || (currData > rangeMax && rangeMax != visualMapOfSerie.max) || !visualMapOfSerie.IsInSelectedValue(currData) || (currIndex >= 0 && axisValueSplitIndex > currIndex))
				{
					continue;
				}
				color = visualMapOfSerie.GetColor(currData);
				if (serieData.context.highlight)
				{
					color = ChartHelper.GetHighlightColor(color);
				}
				serieData.context.canShowLabel = true;
				serieData.context.color = color;
				bool flag3 = serieData.context.highlight || visualMapOfSerie.context.pointerIndex > 0;
				float num6 = 0f;
				float num7 = 0f;
				if (flag2)
				{
					if (serieSymbol.size == 0f && serieSymbol.sizeType == SymbolSizeType.Custom)
					{
						num6 = num4;
						num7 = num5;
					}
					else
					{
						num7 = (num6 = SerieHelper.GetSysmbolSize(serie, serieData, defaultSize, serieState));
					}
					serieData.context.rect = new Rect(vector.x - num6 / 2f, vector.y - num7 / 2f, num6, num7);
					UGL.DrawRectangle(vh, serieData.context.rect, color);
					if (num3 > 0f && !ChartHelper.IsClearColor(borderColor))
					{
						UGL.DrawBorder(vh, vector, num6, num7, num3, borderColor, borderColor);
					}
				}
				else
				{
					float sysmbolSize = SerieHelper.GetSysmbolSize(serie, serieData, defaultSize, serieState);
					Color32 itemBackgroundColor = SerieHelper.GetItemBackgroundColor(serie, serieData, base.chart.theme, serie.context.colorIndex, serieState);
					serieData.context.rect = new Rect(vector.x - sysmbolSize / 2f, vector.y - sysmbolSize / 2f, sysmbolSize, sysmbolSize);
					base.chart.DrawSymbol(vh, serieSymbol.type, sysmbolSize, border, vector, color, color, itemBackgroundColor, borderColor, serieSymbol.gap, cornerRadius);
				}
				if (visualMapOfSerie.hoverLink && flag3 && emphasisStyle != null && emphasisStyle.itemStyle.borderWidth > 0f)
				{
					ItemStyle itemStyle = emphasisStyle.itemStyle;
					float borderWidth = itemStyle.borderWidth;
					Color32 color2 = ((itemStyle.opacity > 0f) ? itemStyle.borderColor : ChartConst.clearColor32);
					Color32 toColor = ((itemStyle.opacity > 0f) ? itemStyle.borderToColor : ChartConst.clearColor32);
					UGL.DrawBorder(vh, vector, num6, num7, borderWidth, color2, toColor);
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress(totalSplitGridNum);
				base.chart.RefreshPainter(serie);
			}
			if (flag)
			{
				base.chart.RefreshPainter(serie);
			}
		}

		private void DrawCountHeatmapSerie(VertexHelper vh, Heatmap serie)
		{
			if (!serie.show || serie.animation.HasFadeOut() || !base.chart.TryGetChartComponent<XAxis>(out var component, serie.xAxisIndex) || !base.chart.TryGetChartComponent<YAxis>(out var component2, serie.yAxisIndex))
			{
				return;
			}
			m_SerieGrid = base.chart.GetChartComponent<GridCoord>(component.gridIndex);
			component.boundaryGap = true;
			component2.boundaryGap = true;
			VisualMap visualMapOfSerie = base.chart.GetVisualMapOfSerie(serie);
			EmphasisStyle emphasisStyle = serie.emphasisStyle;
			int totalSplitGridNum = AxisHelper.GetTotalSplitGridNum(component);
			int totalSplitGridNum2 = AxisHelper.GetTotalSplitGridNum(component2);
			float num = m_SerieGrid.context.width / (float)totalSplitGridNum;
			float num2 = m_SerieGrid.context.height / (float)totalSplitGridNum2;
			float x = m_SerieGrid.context.x;
			float y = m_SerieGrid.context.y;
			float num3 = (serie.itemStyle.show ? serie.itemStyle.borderWidth : 0f);
			float num4 = num - 2f * num3;
			float num5 = num2 - 2f * num3;
			float defaultSize = Mathf.Min(num4, num5) * 0.25f;
			serie.animation.InitProgress(0f, totalSplitGridNum);
			int currIndex = serie.animation.GetCurrIndex();
			bool flag = false;
			serie.containerIndex = m_SerieGrid.index;
			serie.containterInstanceId = m_SerieGrid.instanceId;
			m_CountDict.Clear();
			double min = 0.0;
			double num6 = 0.0;
			foreach (SerieData datum in serie.data)
			{
				double data = datum.GetData(0);
				double data2 = datum.GetData(1);
				int axisValueSplitIndex = AxisHelper.GetAxisValueSplitIndex(component, data, totalSplitGridNum);
				int axisValueSplitIndex2 = AxisHelper.GetAxisValueSplitIndex(component2, data2, totalSplitGridNum2);
				int gridKey = GetGridKey(axisValueSplitIndex, axisValueSplitIndex2);
				int value = 0;
				value = ((!m_CountDict.TryGetValue(gridKey, out value)) ? 1 : (value + 1));
				if ((double)value > num6)
				{
					num6 = value;
				}
				m_CountDict[gridKey] = value;
			}
			if (visualMapOfSerie.autoMinMax)
			{
				VisualMapHelper.SetMinMax(visualMapOfSerie, min, num6);
			}
			double rangeMin = visualMapOfSerie.rangeMin;
			double rangeMax = visualMapOfSerie.rangeMax;
			int x2 = -1;
			int y2 = -1;
			if (serie.context.pointerItemDataIndex > 0 && m_CountDict.ContainsKey(serie.context.pointerItemDataIndex))
			{
				GetGridXYByKey(serie.context.pointerItemDataIndex, out x2, out y2);
			}
			SerieState serieState = SerieHelper.GetSerieState(serie, null, defaultSerieState: true);
			SerieSymbol serieSymbol = SerieHelper.GetSerieSymbol(serie, null, serieState);
			float sysmbolSize = SerieHelper.GetSysmbolSize(serie, null, defaultSize, serieState);
			bool flag2 = serieSymbol.type == SymbolType.Rect;
			float border = 0f;
			float[] cornerRadius = null;
			SerieHelper.GetItemColor(out var color, out var _, out var backgroundColor, serie, null, base.chart.theme, serie.context.colorIndex, serieState);
			SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, serie, null, base.chart.theme, serieState);
			foreach (KeyValuePair<int, int> item in m_CountDict)
			{
				GetGridXYByKey(item.Key, out var x3, out var y3);
				int value2 = item.Value;
				if (serie.IsIgnoreValue(value2) || ((double)value2 < rangeMin && rangeMin != visualMapOfSerie.min) || ((double)value2 > rangeMax && rangeMax != visualMapOfSerie.max) || !visualMapOfSerie.IsInSelectedValue(value2) || (currIndex >= 0 && x3 > currIndex))
				{
					continue;
				}
				bool flag3 = x3 == x2 && y3 == y2;
				color = visualMapOfSerie.GetColor(value2);
				if (flag3)
				{
					color = ChartHelper.GetHighlightColor(color);
				}
				Vector3 vector = new Vector3(x + ((float)x3 + 0.5f) * num, y + ((float)y3 + 0.5f) * num2);
				float num7 = 0f;
				float num8 = 0f;
				if (flag2)
				{
					if (serieSymbol.size == 0f && serieSymbol.sizeType == SymbolSizeType.Custom)
					{
						num7 = num4;
						num8 = num5;
					}
					else
					{
						num7 = sysmbolSize;
						num8 = sysmbolSize;
					}
					Rect rect = new Rect(vector.x - num7 / 2f, vector.y - num8 / 2f, num7, num8);
					UGL.DrawRectangle(vh, rect, color);
					if (num3 > 0f && !ChartHelper.IsClearColor(borderColor))
					{
						UGL.DrawBorder(vh, vector, num7, num8, num3, borderColor, borderColor);
					}
				}
				else
				{
					base.chart.DrawSymbol(vh, serieSymbol.type, sysmbolSize, border, vector, color, color, backgroundColor, borderColor, serieSymbol.gap, cornerRadius);
				}
				if (visualMapOfSerie.hoverLink && flag3 && emphasisStyle != null && emphasisStyle.itemStyle.borderWidth > 0f)
				{
					ItemStyle itemStyle = emphasisStyle.itemStyle;
					float borderWidth = itemStyle.borderWidth;
					Color32 color2 = ((itemStyle.opacity > 0f) ? itemStyle.borderColor : ChartConst.clearColor32);
					Color32 toColor2 = ((itemStyle.opacity > 0f) ? itemStyle.borderToColor : ChartConst.clearColor32);
					UGL.DrawBorder(vh, vector, num7, num8, borderWidth, color2, toColor2);
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress(totalSplitGridNum);
				base.chart.RefreshPainter(serie);
			}
			if (flag)
			{
				base.chart.RefreshPainter(serie);
			}
		}

		private void UpdateSeriePolarContext()
		{
			if (m_SeriePolar == null)
			{
				return;
			}
			bool flag = (base.chart.isPointerInChart && m_SeriePolar.IsPointerEnter()) || m_LegendEnter;
			float num = 0f;
			if (!flag)
			{
				if (m_LastCheckContextFlag == flag)
				{
					return;
				}
				bool needInteract = false;
				num = base.serie.lineStyle.GetWidth(base.chart.theme.serie.lineWidth);
				m_LastCheckContextFlag = flag;
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				base.serie.interact.SetValue(ref needInteract, num);
				foreach (SerieData datum in base.serie.data)
				{
					float size = SerieHelper.GetSerieSymbol(base.serie, datum).GetSize(datum.data, base.chart.theme.serie.lineSymbolSize);
					datum.context.highlight = false;
					datum.interact.SetValue(ref needInteract, size);
				}
				if (needInteract)
				{
					if (SeriesHelper.IsStack(base.chart.series))
					{
						base.chart.RefreshTopPainter();
					}
					else
					{
						base.chart.RefreshPainter(base.serie);
					}
				}
				return;
			}
			m_LastCheckContextFlag = flag;
			float lineSymbolSize = base.chart.theme.serie.lineSymbolSize;
			num = base.serie.lineStyle.GetWidth(base.chart.theme.serie.lineWidth);
			bool needInteract2 = false;
			if (m_LegendEnter)
			{
				base.serie.context.pointerEnter = true;
				base.serie.interact.SetValue(ref needInteract2, base.serie.animation.interaction.GetWidth(num));
				for (int i = 0; i < base.serie.dataCount; i++)
				{
					SerieData serieData = base.serie.data[i];
					float sysmbolSize = SerieHelper.GetSysmbolSize(base.serie, serieData, lineSymbolSize, SerieState.Emphasis);
					serieData.context.highlight = true;
					serieData.interact.SetValue(ref needInteract2, sysmbolSize);
				}
			}
			else
			{
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				Vector2 to = base.chart.pointerPos - new Vector2(m_SeriePolar.context.center.x, m_SeriePolar.context.center.y);
				float angle = ChartHelper.GetAngle360(Vector2.up, to);
				float num2 = Vector2.Distance(base.chart.pointerPos, m_SeriePolar.context.center);
				for (int j = 0; j < base.serie.dataCount; j++)
				{
					SerieData serieData2 = base.serie.data[j];
					if (angle >= serieData2.context.startAngle && angle < serieData2.context.toAngle && num2 >= serieData2.context.insideRadius && num2 < serieData2.context.outsideRadius)
					{
						base.serie.context.pointerItemDataIndex = j;
						base.serie.context.pointerEnter = true;
						serieData2.context.highlight = true;
					}
					else
					{
						serieData2.context.highlight = false;
					}
					SerieState serieState = SerieHelper.GetSerieState(base.serie, serieData2, defaultSerieState: true);
					SerieHelper.GetItemColor(out var color, out var toColor, base.serie, serieData2, base.chart.theme, serieState);
					serieData2.interact.SetColor(ref needInteract2, color, toColor);
				}
			}
			if (needInteract2)
			{
				if (SeriesHelper.IsStack(base.chart.series))
				{
					base.chart.RefreshTopPainter();
				}
				else
				{
					base.chart.RefreshPainter(base.serie);
				}
			}
		}

		private void DrawPolarHeatmap(VertexHelper vh, Serie serie)
		{
			List<SerieData> data = serie.data;
			if (data.Count <= 0)
			{
				return;
			}
			m_SeriePolar = base.chart.GetChartComponent<PolarCoord>(serie.polarIndex);
			if (m_SeriePolar == null)
			{
				return;
			}
			AngleAxis angleAxis = ComponentHelper.GetAngleAxis(base.chart.components, m_SeriePolar.index);
			RadiusAxis radiusAxis = ComponentHelper.GetRadiusAxis(base.chart.components, m_SeriePolar.index);
			if (angleAxis == null || radiusAxis == null)
			{
				return;
			}
			VisualMap visualMapOfSerie = base.chart.GetVisualMapOfSerie(serie);
			float startAngle = angleAxis.context.startAngle;
			float curr = 0f;
			int count = data.Count;
			int totalSplitGridNum = AxisHelper.GetTotalSplitGridNum(radiusAxis);
			int totalSplitGridNum2 = AxisHelper.GetTotalSplitGridNum(angleAxis);
			float num = m_SeriePolar.context.radius / (float)totalSplitGridNum;
			int num2 = 360 / totalSplitGridNum2;
			serie.animation.InitProgress(curr, count);
			int dimension = VisualMapHelper.GetDimension(visualMapOfSerie, defaultDimension);
			if (visualMapOfSerie.autoMinMax)
			{
				SerieHelper.GetMinMaxData(serie, dimension, out var min, out var max);
				VisualMapHelper.SetMinMax(visualMapOfSerie, min, max);
			}
			double rangeMin = visualMapOfSerie.rangeMin;
			double rangeMax = visualMapOfSerie.rangeMax;
			Color32 color = base.chart.theme.GetColor(serie.index);
			for (int i = 0; i < data.Count && !serie.animation.CheckDetailBreak(i); i++)
			{
				SerieData serieData = data[i];
				ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
				float borderWidth = itemStyle.borderWidth;
				Color32 borderColor = itemStyle.borderColor;
				double data2 = serieData.GetData(0);
				double data3 = serieData.GetData(1);
				double data4 = serieData.GetData(2);
				int axisValueSplitIndex = AxisHelper.GetAxisValueSplitIndex(radiusAxis, data2, totalSplitGridNum);
				int axisValueSplitIndex2 = AxisHelper.GetAxisValueSplitIndex(angleAxis, data3, totalSplitGridNum2);
				float num3 = startAngle + (float)(axisValueSplitIndex2 * num2);
				float num4 = num3 + (float)num2;
				float num5 = m_SeriePolar.context.insideRadius + (float)axisValueSplitIndex * num;
				float num6 = num5 + num;
				serieData.context.startAngle = num3;
				serieData.context.toAngle = num4;
				serieData.context.halfAngle = (num3 + num4) / 2f;
				serieData.context.insideRadius = num5;
				serieData.context.outsideRadius = num6;
				if ((!(data4 < rangeMin) || rangeMin == visualMapOfSerie.min) && (!(data4 > rangeMax) || rangeMax == visualMapOfSerie.max) && visualMapOfSerie.IsInSelectedValue(data4))
				{
					color = visualMapOfSerie.GetColor(data4);
					if (serieData.context.highlight)
					{
						color = ChartHelper.GetHighlightColor(color);
					}
					bool roundCap = serie.roundCap && num5 > 0f;
					serieData.context.insideRadius = num5;
					serieData.context.outsideRadius = num6;
					serieData.context.areaCenter = m_SeriePolar.context.center;
					serieData.context.position = ChartHelper.GetPosition(m_SeriePolar.context.center, (num3 + num4) / 2f, (num5 + num6) / 2f);
					UGL.DrawDoughnut(vh, m_SeriePolar.context.center, num5, num6, color, color, ColorUtil.clearColor32, num3, num4, borderWidth, borderColor, serie.gap / 2f, base.chart.settings.cicleSmoothness, roundCap);
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress(count);
				serie.animation.CheckSymbol(serie.symbol.GetSize(null, base.chart.theme.serie.lineSymbolSize));
				base.chart.RefreshChart();
			}
		}
	}
}
