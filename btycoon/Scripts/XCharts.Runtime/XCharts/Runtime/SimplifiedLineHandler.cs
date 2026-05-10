using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class SimplifiedLineHandler : SerieHandler<SimplifiedLine>
	{
		private GridCoord m_SerieGrid;

		public override void Update()
		{
			base.Update();
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			UpdateCoordSerieParams(ref paramList, ref title, dataIndex, showCategory, category, marker, itemFormatter, numericFormatter, ignoreDataDefaultContent);
		}

		public override void DrawSerie(VertexHelper vh)
		{
			DrawLineSerie(vh, base.serie);
		}

		public override void UpdateSerieContext()
		{
			if (m_SerieGrid == null)
			{
				return;
			}
			bool flag = (base.chart.isPointerInChart && m_SerieGrid.IsPointerEnter()) || m_LegendEnter;
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
			else if (base.serie.context.isTriggerByAxis)
			{
				base.serie.context.pointerEnter = true;
				base.serie.interact.SetValue(ref needInteract2, base.serie.animation.interaction.GetWidth(num));
				for (int j = 0; j < base.serie.dataCount; j++)
				{
					SerieData serieData2 = base.serie.data[j];
					bool flag2 = j == base.serie.context.pointerItemDataIndex;
					serieData2.context.highlight = flag2;
					SerieState serieState = SerieHelper.GetSerieState(base.serie, serieData2, defaultSerieState: true);
					float sysmbolSize2 = SerieHelper.GetSysmbolSize(base.serie, serieData2, lineSymbolSize, serieState);
					serieData2.interact.SetValue(ref needInteract2, sysmbolSize2);
					if (flag2)
					{
						base.serie.context.pointerEnter = true;
						base.serie.context.pointerItemDataIndex = j;
					}
				}
			}
			else
			{
				int pointerItemDataIndex = base.serie.context.pointerItemDataIndex;
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				for (int k = 0; k < base.serie.dataCount; k++)
				{
					SerieData serieData3 = base.serie.data[k];
					float num2 = Vector3.Distance(base.chart.pointerPos, serieData3.context.position);
					float sysmbolSize3 = SerieHelper.GetSysmbolSize(base.serie, serieData3, lineSymbolSize);
					bool flag3 = num2 <= sysmbolSize3;
					serieData3.context.highlight = flag3;
					SerieState serieState2 = SerieHelper.GetSerieState(base.serie, serieData3, defaultSerieState: true);
					sysmbolSize3 = SerieHelper.GetSysmbolSize(base.serie, serieData3, lineSymbolSize, serieState2);
					serieData3.interact.SetValue(ref needInteract2, sysmbolSize3);
					if (flag3)
					{
						base.serie.context.pointerEnter = true;
						base.serie.context.pointerItemDataIndex = serieData3.index;
						base.serie.interact.SetValue(ref needInteract2, base.serie.animation.interaction.GetWidth(num));
					}
				}
				if (pointerItemDataIndex != base.serie.context.pointerItemDataIndex)
				{
					needInteract2 = true;
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

		private void DrawLineSerie(VertexHelper vh, SimplifiedLine serie)
		{
			if (!serie.show || serie.animation.HasFadeOut())
			{
				return;
			}
			Axis axis;
			Axis relativedAxis;
			bool serieGridCoordAxis = base.chart.GetSerieGridCoordAxis(serie, out axis, out relativedAxis);
			m_SerieGrid = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
			if (axis == null || relativedAxis == null || m_SerieGrid == null)
			{
				return;
			}
			DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
			List<SerieData> showData = serie.GetDataList(dataZoomOfAxis);
			if (showData.Count <= 0)
			{
				return;
			}
			float coordinateWidth = (serieGridCoordAxis ? m_SerieGrid.context.height : m_SerieGrid.context.width);
			float dataWidth = AxisHelper.GetDataWidth(axis, coordinateWidth, showData.Count, dataZoomOfAxis);
			int num = ((serie.maxShow <= 0) ? showData.Count : ((serie.maxShow > showData.Count) ? showData.Count : serie.maxShow));
			int dataAverageRate = LineHelper.GetDataAverageRate(serie, m_SerieGrid, num, isYAxis: false);
			double totalAverage = ((serie.sampleAverage > 0f) ? ((double)serie.sampleAverage) : DataHelper.DataAverage(ref showData, serie.sampleType, serie.minShow, num, dataAverageRate));
			bool dataChanging = false;
			float changeDuration = serie.animation.GetChangeDuration();
			float additionDuration = serie.animation.GetAdditionDuration();
			bool unscaledTime = serie.animation.unscaledTime;
			bool interacting = false;
			float lineWidth = LineHelper.GetLineWidth(ref interacting, serie, base.chart.theme.serie.lineWidth);
			axis.context.scaleWidth = dataWidth;
			serie.containerIndex = m_SerieGrid.index;
			serie.containterInstanceId = m_SerieGrid.instanceId;
			for (int i = serie.minShow; i < num; i += dataAverageRate)
			{
				SerieData serieData = showData[i];
				if (serie.IsIgnoreValue(serieData))
				{
					serieData.context.stackHeight = 0f;
					serieData.context.position = Vector3.zero;
					if (serie.ignoreLineBreak && serie.context.dataIgnores.Count > 0)
					{
						serie.context.dataIgnores[serie.context.dataIgnores.Count - 1] = true;
					}
				}
				else
				{
					Vector3 np = Vector3.zero;
					double xValue = (axis.IsCategory() ? ((double)i) : serieData.GetData(0, axis.inverse));
					double yValue = DataHelper.SampleValue(ref showData, serie.sampleType, dataAverageRate, serie.minShow, num, totalAverage, i, additionDuration, changeDuration, ref dataChanging, relativedAxis, unscaledTime);
					serieData.context.stackHeight = GetDataPoint(serieGridCoordAxis, axis, relativedAxis, m_SerieGrid, xValue, yValue, i, dataWidth, isStack: false, ref np);
					serieData.context.position = np;
					serie.context.dataPoints.Add(np);
					serie.context.dataIndexs.Add(serieData.index);
					serie.context.dataIgnores.Add(item: false);
				}
			}
			if (dataChanging || interacting)
			{
				base.chart.RefreshPainter(serie);
			}
			if (serie.context.dataPoints.Count > 0)
			{
				serie.animation.InitProgress(serie.context.dataPoints, serieGridCoordAxis);
				LineHelper.UpdateSerieDrawPoints(serie, base.chart.settings, base.chart.theme, null, lineWidth, serieGridCoordAxis);
				LineHelper.DrawSerieLineArea(vh, serie, null, base.chart.theme, null, serieGridCoordAxis, axis, relativedAxis, m_SerieGrid);
				LineHelper.DrawSerieLine(vh, base.chart.theme, serie, null, m_SerieGrid, axis, relativedAxis, lineWidth);
				serie.context.vertCount = vh.currentVertCount;
				if (!serie.animation.IsFinish())
				{
					serie.animation.CheckProgress();
					base.chart.RefreshPainter(serie);
				}
			}
		}

		private float GetDataPoint(bool isY, Axis axis, Axis relativedAxis, GridCoord grid, double xValue, double yValue, int i, float scaleWid, bool isStack, ref Vector3 np)
		{
			float num = (isY ? grid.context.x : grid.context.y);
			float x;
			float num2;
			if (isY)
			{
				float axisValueDistance = AxisHelper.GetAxisValueDistance(grid, relativedAxis, scaleWid, yValue);
				axisValueDistance = AnimationStyleHelper.CheckDataAnimation(base.chart, base.serie, i, axisValueDistance);
				x = num + axisValueDistance;
				num2 = AxisHelper.GetAxisValuePosition(grid, axis, scaleWid, xValue);
			}
			else
			{
				float axisValueDistance2 = AxisHelper.GetAxisValueDistance(grid, relativedAxis, scaleWid, yValue);
				axisValueDistance2 = AnimationStyleHelper.CheckDataAnimation(base.chart, base.serie, i, axisValueDistance2);
				num2 = num + axisValueDistance2;
				x = AxisHelper.GetAxisValuePosition(grid, axis, scaleWid, xValue);
			}
			np = new Vector3(x, num2);
			return num2;
		}
	}
}
