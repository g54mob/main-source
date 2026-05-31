using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class MarkAreaHandler : MainComponentHandler<MarkArea>
	{
		private GameObject m_MarkLineLabelRoot;

		private bool m_NeedUpdateLabelPosition;

		public override void InitComponent()
		{
			m_MarkLineLabelRoot = ChartHelper.AddObject("markarea" + base.component.index, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
			m_MarkLineLabelRoot.hideFlags = base.chart.chartHideFlags;
			ChartHelper.HideAllObject(m_MarkLineLabelRoot);
			InitMarkArea(base.component);
		}

		public override void DrawBase(VertexHelper vh)
		{
			DrawMarkArea(vh, base.component);
		}

		public override void Update()
		{
			if (m_NeedUpdateLabelPosition)
			{
				m_NeedUpdateLabelPosition = false;
				if (base.component.runtimeLabel != null)
				{
					base.component.runtimeLabel.SetPosition(base.component.runtimeLabelPosition);
				}
			}
		}

		private void InitMarkArea(MarkArea markArea)
		{
			markArea.painter = base.chart.m_PainterUpper;
			markArea.refreshComponent = delegate
			{
				ChartLabel chartLabel = ChartHelper.AddChartLabel("label", m_MarkLineLabelRoot.transform, markArea.label, base.chart.theme.axis, base.component.text, Color.clear);
				UpdateRuntimeData(base.component);
				chartLabel.SetActive(markArea.label.show);
				chartLabel.SetPosition(base.component.runtimeLabelPosition);
				chartLabel.SetText(base.component.text);
				markArea.runtimeLabel = chartLabel;
			};
			markArea.refreshComponent();
		}

		private void DrawMarkArea(VertexHelper vh, MarkArea markArea)
		{
			if (markArea.show)
			{
				Serie serie = base.chart.GetSerie(markArea.serieIndex);
				if (serie != null && serie.show && markArea.show)
				{
					UpdateRuntimeData(markArea);
					int legendRealShowNameIndex = base.chart.GetLegendRealShowNameIndex(serie.legendName);
					Color32 lineColor = SerieHelper.GetLineColor(serie, null, base.chart.theme, legendRealShowNameIndex, SerieState.Normal);
					Color32 color = markArea.itemStyle.GetColor(lineColor);
					UGL.DrawRectangle(vh, markArea.runtimeRect, color, color);
				}
			}
		}

		private void UpdateRuntimeData(MarkArea markArea)
		{
			Serie serie = base.chart.GetSerie(markArea.serieIndex);
			if (serie != null && serie.show && markArea.show)
			{
				YAxis chartComponent = base.chart.GetChartComponent<YAxis>(serie.yAxisIndex);
				XAxis chartComponent2 = base.chart.GetChartComponent<XAxis>(serie.xAxisIndex);
				GridCoord chartComponent3 = base.chart.GetChartComponent<GridCoord>(chartComponent2.gridIndex);
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(chartComponent2);
				List<SerieData> dataList = serie.GetDataList(dataZoomOfAxis);
				Vector3 position = GetPosition(markArea.start, serie, dataZoomOfAxis, chartComponent2, chartComponent, chartComponent3, dataList, start: true);
				Vector3 position2 = GetPosition(markArea.end, serie, dataZoomOfAxis, chartComponent2, chartComponent, chartComponent3, dataList, start: false);
				Vector3 vector = new Vector3(position.x, position2.y);
				markArea.runtimeRect = new Rect(vector.x, vector.y, position2.x - vector.x, position.y - vector.y);
				UpdateLabelPosition(markArea);
			}
		}

		private void UpdateLabelPosition(MarkArea markArea)
		{
			if (markArea.label.show)
			{
				m_NeedUpdateLabelPosition = true;
				Rect runtimeRect = markArea.runtimeRect;
				switch (markArea.label.position)
				{
				case LabelStyle.Position.Center:
					markArea.runtimeLabelPosition = runtimeRect.center;
					break;
				case LabelStyle.Position.Left:
					markArea.runtimeLabelPosition = runtimeRect.center + new Vector2(runtimeRect.width / 2f, 0f);
					break;
				case LabelStyle.Position.Right:
					markArea.runtimeLabelPosition = runtimeRect.center - new Vector2(runtimeRect.width / 2f, 0f);
					break;
				case LabelStyle.Position.Top:
					markArea.runtimeLabelPosition = runtimeRect.center + new Vector2(0f, runtimeRect.height / 2f);
					break;
				case LabelStyle.Position.Bottom:
					markArea.runtimeLabelPosition = runtimeRect.center - new Vector2(0f, runtimeRect.height / 2f);
					break;
				default:
					markArea.runtimeLabelPosition = runtimeRect.center + new Vector2(0f, runtimeRect.height / 2f);
					break;
				}
				markArea.runtimeLabelPosition += markArea.label.offset;
			}
		}

		private Vector3 GetPosition(MarkAreaData data, Serie serie, DataZoom dataZoom, XAxis xAxis, YAxis yAxis, GridCoord grid, List<SerieData> showData, bool start)
		{
			Vector3 zero = Vector3.zero;
			switch (data.type)
			{
			case MarkAreaType.Min:
				data.runtimeValue = SerieHelper.GetMinData(serie, data.dimension, dataZoom);
				return GetPosition(xAxis, yAxis, grid, data.runtimeValue, start);
			case MarkAreaType.Max:
				data.runtimeValue = SerieHelper.GetMaxData(serie, data.dimension, dataZoom);
				return GetPosition(xAxis, yAxis, grid, data.runtimeValue, start);
			case MarkAreaType.Average:
				data.runtimeValue = SerieHelper.GetAverageData(serie, data.dimension, dataZoom);
				return GetPosition(xAxis, yAxis, grid, data.runtimeValue, start);
			case MarkAreaType.Median:
				data.runtimeValue = SerieHelper.GetMedianData(serie, data.dimension, dataZoom);
				return GetPosition(xAxis, yAxis, grid, data.runtimeValue, start);
			case MarkAreaType.None:
				if (data.xPosition != 0f || data.yPosition != 0f)
				{
					float x = grid.context.x + data.xPosition;
					float y = grid.context.y + data.yPosition;
					return new Vector3(x, y);
				}
				if (data.yValue != 0.0)
				{
					data.runtimeValue = data.yValue;
					if (yAxis.IsCategory())
					{
						float axisPosition = AxisHelper.GetAxisPosition(grid, yAxis, data.yValue, showData.Count, dataZoom);
						if (!start)
						{
							return new Vector3(grid.context.x + grid.context.width, axisPosition);
						}
						return new Vector3(grid.context.x, axisPosition);
					}
					return GetPosition(xAxis, yAxis, grid, data.runtimeValue, start);
				}
				data.runtimeValue = data.xValue;
				if (xAxis.IsCategory())
				{
					float axisPosition2 = AxisHelper.GetAxisPosition(grid, xAxis, data.xValue, showData.Count, dataZoom);
					if (!start)
					{
						return new Vector3(axisPosition2, grid.context.y);
					}
					return new Vector3(axisPosition2, grid.context.y + grid.context.height);
				}
				return GetPosition(xAxis, yAxis, grid, data.xValue, start);
			default:
				return zero;
			}
		}

		private Vector3 GetPosition(Axis xAxis, Axis yAxis, GridCoord grid, double value, bool start)
		{
			if (yAxis.IsCategory())
			{
				float axisPosition = AxisHelper.GetAxisPosition(grid, xAxis, value);
				if (!start)
				{
					return new Vector3(axisPosition, grid.context.y);
				}
				return new Vector3(axisPosition, grid.context.y + grid.context.height);
			}
			float axisPosition2 = AxisHelper.GetAxisPosition(grid, yAxis, value);
			if (!start)
			{
				return new Vector3(grid.context.x + grid.context.width, axisPosition2);
			}
			return new Vector3(grid.context.x, axisPosition2 + grid.context.height);
		}
	}
}
