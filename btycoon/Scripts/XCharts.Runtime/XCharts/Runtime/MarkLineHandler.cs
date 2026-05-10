using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class MarkLineHandler : MainComponentHandler<MarkLine>
	{
		private GameObject m_MarkLineLabelRoot;

		private bool m_RefreshLabel;

		private Dictionary<int, List<MarkLineData>> m_TempGroupData = new Dictionary<int, List<MarkLineData>>();

		public override void InitComponent()
		{
			m_MarkLineLabelRoot = ChartHelper.AddObject("markline", base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
			m_MarkLineLabelRoot.hideFlags = base.chart.chartHideFlags;
			ChartHelper.HideAllObject(m_MarkLineLabelRoot);
			InitMarkLine(base.component);
		}

		public override void DrawUpper(VertexHelper vh)
		{
			DrawMarkLine(vh, base.component);
		}

		public override void Update()
		{
			if (!m_RefreshLabel)
			{
				return;
			}
			m_RefreshLabel = false;
			Serie serie = base.chart.GetSerie(base.component.serieIndex);
			if (!serie.show || !base.component.show)
			{
				return;
			}
			foreach (MarkLineData datum in base.component.data)
			{
				if (datum.runtimeLabel != null)
				{
					Vector3 labelPosition = MarkLineHelper.GetLabelPosition(datum);
					datum.runtimeLabel.SetActive(datum.label.show && datum.runtimeInGrid);
					datum.runtimeLabel.SetPosition(labelPosition);
					datum.runtimeLabel.SetText(MarkLineHelper.GetFormatterContent(serie, datum));
				}
			}
		}

		private void InitMarkLine(MarkLine markLine)
		{
			Serie serie = base.chart.GetSerie(markLine.serieIndex);
			if (!serie.show || !markLine.show)
			{
				return;
			}
			ResetTempMarkLineGroupData(markLine);
			Color serieColor = base.chart.GetItemColor(serie);
			if (m_TempGroupData.Count > 0)
			{
				foreach (KeyValuePair<int, List<MarkLineData>> tempGroupDatum in m_TempGroupData)
				{
					if (tempGroupDatum.Value.Count >= 2)
					{
						MarkLineData data = tempGroupDatum.Value[0];
						InitMarkLineLabel(serie, data, serieColor);
					}
				}
			}
			foreach (MarkLineData datum in markLine.data)
			{
				if (datum.group == 0)
				{
					InitMarkLineLabel(serie, datum, serieColor);
				}
			}
		}

		private void InitMarkLineLabel(Serie serie, MarkLineData data, Color serieColor)
		{
			data.painter = base.chart.m_PainterUpper;
			data.refreshComponent = delegate
			{
				ChartLabel chartLabel = ChartHelper.AddChartLabel($"markLine_{base.component.index}_{data.index}", content: MarkLineHelper.GetFormatterContent(serie, data), parent: m_MarkLineLabelRoot.transform, labelStyle: data.label, theme: base.chart.theme.axis, autoColor: Color.clear);
				Vector3 labelPosition = MarkLineHelper.GetLabelPosition(data);
				chartLabel.SetIconActive(flag: false);
				chartLabel.SetActive(data.label.show && data.runtimeInGrid);
				chartLabel.SetPosition(labelPosition);
				data.runtimeLabel = chartLabel;
			};
			data.refreshComponent();
		}

		private void DrawMarkLine(VertexHelper vh, MarkLine markLine)
		{
			Serie serie = base.chart.GetSerie(markLine.serieIndex);
			if (!serie.show || !markLine.show || markLine.data.Count == 0)
			{
				return;
			}
			YAxis chartComponent = base.chart.GetChartComponent<YAxis>(serie.yAxisIndex);
			XAxis chartComponent2 = base.chart.GetChartComponent<XAxis>(serie.xAxisIndex);
			GridCoord chartComponent3 = base.chart.GetChartComponent<GridCoord>(chartComponent2.gridIndex);
			DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(chartComponent2);
			AnimationStyle animation = markLine.animation;
			List<SerieData> dataList = serie.GetDataList(dataZoomOfAxis);
			Vector3 sp = Vector3.zero;
			Vector3 ep = Vector3.zero;
			int legendRealShowNameIndex = base.chart.GetLegendRealShowNameIndex(serie.serieName);
			Color32 lineColor = SerieHelper.GetLineColor(serie, null, base.chart.theme, legendRealShowNameIndex, SerieState.Normal);
			animation.InitProgress(0f, 1f);
			ResetTempMarkLineGroupData(markLine);
			if (m_TempGroupData.Count > 0)
			{
				foreach (KeyValuePair<int, List<MarkLineData>> tempGroupDatum in m_TempGroupData)
				{
					if (tempGroupDatum.Value.Count >= 2)
					{
						sp = GetSinglePos(chartComponent2, chartComponent, chartComponent3, serie, dataZoomOfAxis, tempGroupDatum.Value[0], dataList.Count);
						ep = GetSinglePos(chartComponent2, chartComponent, chartComponent3, serie, dataZoomOfAxis, tempGroupDatum.Value[1], dataList.Count);
						tempGroupDatum.Value[0].runtimeStartPosition = sp;
						tempGroupDatum.Value[1].runtimeEndPosition = ep;
						DrawMakLineData(vh, tempGroupDatum.Value[0], animation, serie, chartComponent3, lineColor, sp, ep);
					}
				}
			}
			foreach (MarkLineData datum in markLine.data)
			{
				if (datum.group != 0)
				{
					continue;
				}
				switch (datum.type)
				{
				case MarkLineType.Min:
					datum.runtimeValue = SerieHelper.GetMinData(serie, datum.dimension, dataZoomOfAxis);
					GetStartEndPos(chartComponent2, chartComponent, chartComponent3, datum.runtimeValue, ref sp, ref ep);
					break;
				case MarkLineType.Max:
					datum.runtimeValue = SerieHelper.GetMaxData(serie, datum.dimension, dataZoomOfAxis);
					GetStartEndPos(chartComponent2, chartComponent, chartComponent3, datum.runtimeValue, ref sp, ref ep);
					break;
				case MarkLineType.Average:
					datum.runtimeValue = SerieHelper.GetAverageData(serie, datum.dimension, dataZoomOfAxis);
					GetStartEndPos(chartComponent2, chartComponent, chartComponent3, datum.runtimeValue, ref sp, ref ep);
					break;
				case MarkLineType.Median:
					datum.runtimeValue = SerieHelper.GetMedianData(serie, datum.dimension, dataZoomOfAxis);
					GetStartEndPos(chartComponent2, chartComponent, chartComponent3, datum.runtimeValue, ref sp, ref ep);
					break;
				case MarkLineType.None:
					if (datum.xPosition != 0f)
					{
						datum.runtimeValue = datum.xPosition;
						float x = chartComponent3.context.x + datum.xPosition;
						sp = new Vector3(x, chartComponent3.context.y);
						ep = new Vector3(x, chartComponent3.context.y + chartComponent3.context.height);
					}
					else if (datum.yPosition != 0f)
					{
						datum.runtimeValue = datum.yPosition;
						float y = chartComponent3.context.y + datum.yPosition;
						sp = new Vector3(chartComponent3.context.x, y);
						ep = new Vector3(chartComponent3.context.x + chartComponent3.context.width, y);
					}
					else if (datum.yValue != 0.0 || (datum.xValue == 0.0 && datum.yValue == 0.0 && chartComponent.IsValue()))
					{
						datum.runtimeValue = datum.yValue;
						if (chartComponent.IsCategory())
						{
							float axisPosition = AxisHelper.GetAxisPosition(chartComponent3, chartComponent, datum.yValue, dataList.Count, dataZoomOfAxis);
							sp = new Vector3(chartComponent3.context.x, axisPosition);
							ep = new Vector3(chartComponent3.context.x + chartComponent3.context.width, axisPosition);
						}
						else
						{
							GetStartEndPos(chartComponent2, chartComponent, chartComponent3, datum.yValue, ref sp, ref ep);
						}
					}
					else
					{
						datum.runtimeValue = datum.xValue;
						if (chartComponent2.IsCategory())
						{
							float axisPosition2 = AxisHelper.GetAxisPosition(chartComponent3, chartComponent2, datum.xValue, dataList.Count, dataZoomOfAxis);
							sp = new Vector3(axisPosition2, chartComponent3.context.y);
							ep = new Vector3(axisPosition2, chartComponent3.context.y + chartComponent3.context.height);
						}
						else
						{
							GetStartEndPos(chartComponent2, chartComponent, chartComponent3, datum.xValue, ref sp, ref ep);
						}
					}
					break;
				}
				datum.runtimeStartPosition = sp;
				datum.runtimeEndPosition = ep;
				DrawMakLineData(vh, datum, animation, serie, chartComponent3, lineColor, sp, ep);
			}
			if (!animation.IsFinish())
			{
				animation.CheckProgress(1.0);
				base.chart.RefreshTopPainter();
			}
		}

		private void ResetTempMarkLineGroupData(MarkLine markLine)
		{
			m_TempGroupData.Clear();
			for (int i = 0; i < markLine.data.Count; i++)
			{
				MarkLineData markLineData = markLine.data[i];
				markLineData.index = i;
				if (markLineData.group != 0)
				{
					if (!m_TempGroupData.ContainsKey(markLineData.group))
					{
						m_TempGroupData[markLineData.group] = new List<MarkLineData>();
					}
					m_TempGroupData[markLineData.group].Add(markLineData);
				}
			}
		}

		private void DrawMakLineData(VertexHelper vh, MarkLineData data, AnimationStyle animation, Serie serie, GridCoord grid, Color32 serieColor, Vector3 sp, Vector3 ep)
		{
			if (!animation.IsFinish())
			{
				ep = Vector3.Lerp(sp, ep, animation.GetCurrDetail());
			}
			if ((!base.chart.IsInChart(sp) && !base.chart.IsInChart(ep)) || (serie.clip && !grid.Contains(sp) && !grid.Contains(ep)))
			{
				data.runtimeInGrid = false;
				m_RefreshLabel = true;
				return;
			}
			data.runtimeCurrentEndPosition = ep;
			if (sp != Vector3.zero || ep != Vector3.zero)
			{
				data.runtimeInGrid = true;
				m_RefreshLabel = true;
				base.chart.ClampInChart(ref sp);
				base.chart.ClampInChart(ref ep);
				AxisTheme axis = base.chart.theme.axis;
				Color32 color = (ChartHelper.IsClearColor(data.lineStyle.color) ? serieColor : data.lineStyle.color);
				float themeWidth = ((data.lineStyle.width == 0f) ? axis.lineWidth : data.lineStyle.width);
				ChartDrawer.DrawLineStyle(vh, data.lineStyle, sp, ep, themeWidth, LineStyle.Type.Dashed, color, color);
				if (data.startSymbol != null && data.startSymbol.show)
				{
					DrawMarkLineSymbol(vh, data.startSymbol, serie, grid, base.chart.theme, sp, sp, color);
				}
				if (data.endSymbol != null && data.endSymbol.show)
				{
					DrawMarkLineSymbol(vh, data.endSymbol, serie, grid, base.chart.theme, ep, sp, color);
				}
			}
		}

		private void DrawMarkLineSymbol(VertexHelper vh, SymbolStyle symbol, Serie serie, GridCoord grid, ThemeStyle theme, Vector3 pos, Vector3 startPos, Color32 lineColor)
		{
			float border = 0f;
			float[] cornerRadius = null;
			SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, serie, null, base.chart.theme);
			base.chart.DrawClipSymbol(vh, symbol.type, symbol.size, border, pos, lineColor, lineColor, ColorUtil.clearColor32, borderColor, symbol.gap, serie.clip, cornerRadius, grid, startPos);
		}

		private void GetStartEndPos(Axis xAxis, Axis yAxis, GridCoord grid, double value, ref Vector3 sp, ref Vector3 ep)
		{
			if (xAxis.IsCategory())
			{
				float axisPosition = AxisHelper.GetAxisPosition(grid, yAxis, value);
				sp = new Vector3(grid.context.x, axisPosition);
				ep = new Vector3(grid.context.x + grid.context.width, axisPosition);
			}
			else
			{
				float axisPosition2 = AxisHelper.GetAxisPosition(grid, xAxis, value);
				sp = new Vector3(axisPosition2, grid.context.y);
				ep = new Vector3(axisPosition2, grid.context.y + grid.context.height);
			}
		}

		private float GetAxisPosition(GridCoord grid, Axis axis, DataZoom dataZoom, int dataCount, double value)
		{
			return AxisHelper.GetAxisPosition(grid, axis, value, dataCount, dataZoom);
		}

		private Vector3 GetSinglePos(Axis xAxis, Axis yAxis, GridCoord grid, Serie serie, DataZoom dataZoom, MarkLineData data, int serieDataCount)
		{
			switch (data.type)
			{
			case MarkLineType.Min:
			{
				SerieData maxSerieData = SerieHelper.GetMinSerieData(serie, data.dimension, dataZoom);
				data.runtimeValue = maxSerieData.GetData(data.dimension);
				float axisPosition2 = GetAxisPosition(grid, xAxis, dataZoom, serieDataCount, maxSerieData.index);
				float y = GetAxisPosition(grid, yAxis, dataZoom, serieDataCount, data.runtimeValue);
				return new Vector3(axisPosition2, y);
			}
			case MarkLineType.Max:
			{
				SerieData maxSerieData = SerieHelper.GetMaxSerieData(serie, data.dimension, dataZoom);
				data.runtimeValue = maxSerieData.GetData(data.dimension);
				float axisPosition = GetAxisPosition(grid, xAxis, dataZoom, serieDataCount, maxSerieData.index);
				float y = GetAxisPosition(grid, yAxis, dataZoom, serieDataCount, data.runtimeValue);
				return new Vector3(axisPosition, y);
			}
			case MarkLineType.None:
			{
				if (data.zeroPosition)
				{
					data.runtimeValue = 0.0;
					return grid.context.position;
				}
				float x = ((data.xPosition != 0f) ? (grid.context.x + data.xPosition) : GetAxisPosition(grid, xAxis, dataZoom, serieDataCount, data.xValue));
				float y = ((data.yPosition != 0f) ? (grid.context.y + data.yPosition) : GetAxisPosition(grid, yAxis, dataZoom, serieDataCount, data.yValue));
				data.runtimeValue = data.yValue;
				return new Vector3(x, y);
			}
			default:
				return grid.context.position;
			}
		}
	}
}
