using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class LineHandler : SerieHandler<Line>
	{
		private List<List<SerieData>> m_StackSerieData = new List<List<SerieData>>();

		private GridCoord m_SerieGrid;

		private PolarCoord m_SeriePolar;

		public override void Update()
		{
			base.Update();
			if (base.serie.IsUseCoord<GridCoord>())
			{
				UpdateSerieGridContext();
			}
			else if (base.serie.IsUseCoord<PolarCoord>())
			{
				UpdateSeriePolarContext();
			}
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			UpdateCoordSerieParams(ref paramList, ref title, dataIndex, showCategory, category, marker, itemFormatter, numericFormatter, ignoreDataDefaultContent);
		}

		public override void DrawSerie(VertexHelper vh)
		{
			if (base.serie.IsUseCoord<PolarCoord>())
			{
				DrawPolarLine(vh, base.serie);
				DrawPolarLineSymbol(vh);
				DrawPolarLineArrow(vh, base.serie);
			}
			else if (base.serie.IsUseCoord<GridCoord>())
			{
				DrawLineSerie(vh, base.serie);
				if (!SeriesHelper.IsStack(base.chart.series))
				{
					DrawLinePoint(vh, base.serie);
					DrawLineArrow(vh, base.serie);
				}
			}
		}

		public override void DrawUpper(VertexHelper vh)
		{
			if (base.serie.IsUseCoord<GridCoord>() && SeriesHelper.IsStack(base.chart.series))
			{
				DrawLinePoint(vh, base.serie);
				DrawLineArrow(vh, base.serie);
			}
		}

		public override void RefreshEndLabelInternal()
		{
			base.RefreshEndLabelInternal();
			if (m_SerieGrid == null || !base.serie.animation.IsFinish())
			{
				return;
			}
			List<ChartLabel> endLabelList = m_SerieGrid.context.endLabelList;
			if (endLabelList.Count <= 1)
			{
				return;
			}
			endLabelList.Sort((ChartLabel a, ChartLabel b) => (a == null || b == null) ? 1 : b.transform.position.y.CompareTo(a.transform.position.y));
			float num = float.NaN;
			for (int num2 = 0; num2 < endLabelList.Count; num2++)
			{
				ChartLabel chartLabel = endLabelList[num2];
				if (chartLabel == null || !chartLabel.isAnimationEnd)
				{
					continue;
				}
				Vector3 localPosition = chartLabel.transform.localPosition;
				if (float.IsNaN(num))
				{
					num = localPosition.y;
					continue;
				}
				float textHeight = chartLabel.GetTextHeight();
				if (localPosition.y + textHeight > num)
				{
					chartLabel.SetPosition(new Vector3(localPosition.x, num - textHeight, localPosition.z));
				}
				num = chartLabel.transform.localPosition.y;
			}
		}

		public override Vector3 GetSerieDataLabelOffset(SerieData serieData, LabelStyle label)
		{
			if (label.autoOffset && SerieHelper.IsDownPoint(base.serie, serieData.index) && (base.serie.areaStyle == null || !base.serie.areaStyle.show))
			{
				Vector3 offset = label.GetOffset(base.serie.context.insideRadius);
				return new Vector3(offset.x, 0f - offset.y, offset.z);
			}
			return label.GetOffset(base.serie.context.insideRadius);
		}

		private void UpdateSerieGridContext()
		{
			if (m_SerieGrid == null)
			{
				return;
			}
			bool flag = (base.chart.isPointerInChart && m_SerieGrid.IsPointerEnter()) || m_LegendEnter;
			if (!flag)
			{
				if (m_LastCheckContextFlag == flag)
				{
					return;
				}
				m_LastCheckContextFlag = flag;
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				base.serie.highlight = false;
				base.serie.ResetInteract();
				foreach (SerieData datum in base.serie.data)
				{
					datum.context.highlight = false;
				}
				if (SeriesHelper.IsStack(base.chart.series))
				{
					base.chart.RefreshTopPainter();
				}
				else
				{
					base.chart.RefreshPainter(base.serie);
				}
				return;
			}
			m_LastCheckContextFlag = flag;
			float width = base.serie.lineStyle.GetWidth(base.chart.theme.serie.lineWidth);
			float lineSymbolSize = base.chart.theme.serie.lineSymbolSize;
			bool needInteract = false;
			base.serie.ResetDataIndex();
			if (m_LegendEnter)
			{
				base.serie.context.pointerEnter = true;
				base.serie.interact.SetValue(ref needInteract, base.serie.animation.interaction.GetWidth(width));
				for (int i = 0; i < base.serie.dataCount; i++)
				{
					SerieData serieData = base.serie.data[i];
					float sysmbolSize = SerieHelper.GetSysmbolSize(base.serie, serieData, lineSymbolSize, SerieState.Emphasis);
					serieData.context.highlight = true;
					serieData.interact.SetValue(ref needInteract, sysmbolSize);
				}
			}
			else if (base.serie.context.isTriggerByAxis)
			{
				base.serie.context.pointerEnter = false;
				base.serie.interact.SetValue(ref needInteract, base.serie.animation.interaction.GetWidth(width));
				for (int j = 0; j < base.serie.dataCount; j++)
				{
					SerieData serieData2 = base.serie.data[j];
					bool flag2 = j == base.serie.context.pointerItemDataIndex;
					serieData2.context.highlight = flag2;
					SerieState serieState = SerieHelper.GetSerieState(base.serie, serieData2, defaultSerieState: true);
					float sysmbolSize2 = SerieHelper.GetSysmbolSize(base.serie, serieData2, lineSymbolSize, serieState);
					serieData2.interact.SetValue(ref needInteract, sysmbolSize2);
					if (flag2)
					{
						base.serie.context.pointerEnter = true;
						base.serie.context.pointerItemDataIndex = j;
						needInteract = true;
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
					float num = Vector3.Distance(base.chart.pointerPos, serieData3.context.position);
					float sysmbolSize3 = SerieHelper.GetSysmbolSize(base.serie, serieData3, lineSymbolSize);
					bool flag3 = num <= sysmbolSize3;
					serieData3.context.highlight = flag3;
					SerieState serieState2 = SerieHelper.GetSerieState(base.serie, serieData3, defaultSerieState: true);
					sysmbolSize3 = SerieHelper.GetSysmbolSize(base.serie, serieData3, lineSymbolSize, serieState2);
					serieData3.interact.SetValue(ref needInteract, sysmbolSize3);
					if (flag3)
					{
						base.serie.context.pointerEnter = true;
						base.serie.context.pointerItemDataIndex = serieData3.index;
					}
				}
				if (pointerItemDataIndex != base.serie.context.pointerItemDataIndex)
				{
					needInteract = true;
				}
				if (base.serie.context.pointerItemDataIndex >= 0)
				{
					base.serie.interact.SetValue(ref needInteract, base.serie.animation.interaction.GetWidth(width));
				}
				else
				{
					base.serie.interact.SetValue(ref needInteract, width);
				}
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
		}

		private void DrawLinePoint(VertexHelper vh, Serie serie)
		{
			if (!serie.show || serie.IsPerformanceMode() || m_SerieGrid == null)
			{
				return;
			}
			int count = serie.context.dataPoints.Count;
			bool clip = SeriesHelper.IsAnyClipSerie(base.chart.series);
			ThemeStyle theme = base.chart.theme;
			bool interacting = false;
			LineArrow lineArrow = serie.lineArrow;
			VisualMap visualMapOfSerie = base.chart.GetVisualMapOfSerie(serie);
			bool flag = VisualMapHelper.IsNeedLineGradient(visualMapOfSerie);
			float interactionDuration = serie.animation.GetInteractionDuration();
			base.chart.GetSerieGridCoordAxis(serie, out var axis, out var relativedAxis);
			for (int i = 0; i < count; i++)
			{
				int num = serie.context.dataIndexs[i];
				SerieData serieData = serie.GetSerieData(num);
				if (serieData == null || serieData.context.isClip)
				{
					continue;
				}
				SerieState serieState = SerieHelper.GetSerieState(serie, serieData, defaultSerieState: true);
				SerieSymbol serieSymbol = SerieHelper.GetSerieSymbol(serie, serieData, serieState);
				if (!serieSymbol.show || !serieSymbol.ShowSymbol(num, count))
				{
					continue;
				}
				Vector3 pos = serie.context.dataPoints[i];
				if ((lineArrow == null || !lineArrow.show || ((lineArrow.position != LineArrow.Position.Start || i != 0) && (lineArrow.position != LineArrow.Position.End || i != count - 1))) && !ChartHelper.IsIngore(pos))
				{
					float value = 0f;
					if (!serieData.interact.TryGetValue(ref value, ref interacting, interactionDuration))
					{
						value = SerieHelper.GetSysmbolSize(serie, serieData, base.chart.theme.serie.lineSymbolSize, serieState);
						serieData.interact.SetValue(ref interacting, value);
						value = serie.animation.GetSysmbolSize(value);
					}
					float border = 0f;
					float[] cornerRadius = null;
					SerieHelper.GetItemColor(out var color, out var toColor, out var backgroundColor, serie, serieData, theme, serie.context.colorIndex);
					SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, serie, null, base.chart.theme, serieState);
					if (flag)
					{
						color = VisualMapHelper.GetLineGradientColor(visualMapOfSerie, pos, m_SerieGrid, axis, relativedAxis, color);
						toColor = color;
					}
					base.chart.DrawClipSymbol(vh, serieSymbol.type, value, border, pos, color, toColor, backgroundColor, borderColor, serieSymbol.gap, clip, cornerRadius, m_SerieGrid, (i > 0) ? serie.context.dataPoints[i - 1] : m_SerieGrid.context.position);
				}
			}
			if (interacting)
			{
				if (SeriesHelper.IsStack(base.chart.series))
				{
					base.chart.RefreshTopPainter();
				}
				else
				{
					base.chart.RefreshPainter(serie);
				}
			}
		}

		private void DrawLineArrow(VertexHelper vh, Serie serie)
		{
			if (!serie.show || serie.lineArrow == null || !serie.lineArrow.show || serie.context.dataPoints.Count < 2)
			{
				return;
			}
			Color32 lineColor = SerieHelper.GetLineColor(serie, null, base.chart.theme, serie.context.colorIndex);
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			ArrowStyle arrow = serie.lineArrow.arrow;
			List<PointInfo> drawPoints = serie.context.drawPoints;
			switch (serie.lineArrow.position)
			{
			case LineArrow.Position.End:
				if (drawPoints.Count < 3)
				{
					zero = drawPoints[drawPoints.Count - 2].position;
					zero2 = drawPoints[drawPoints.Count - 1].position;
				}
				else
				{
					zero = drawPoints[drawPoints.Count - 3].position;
					zero2 = drawPoints[drawPoints.Count - 2].position;
				}
				UGL.DrawArrow(vh, zero, zero2, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(lineColor));
				break;
			case LineArrow.Position.Start:
				zero = drawPoints[1].position;
				zero2 = drawPoints[0].position;
				UGL.DrawArrow(vh, zero, zero2, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(lineColor));
				break;
			}
		}

		private void DrawLineSerie(VertexHelper vh, Line serie)
		{
			if (serie.animation.HasFadeOut())
			{
				return;
			}
			Axis axis;
			Axis relativedAxis;
			bool serieGridCoordAxis = base.chart.GetSerieGridCoordAxis(serie, out axis, out relativedAxis);
			if (axis == null || relativedAxis == null)
			{
				return;
			}
			m_SerieGrid = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
			if (m_SerieGrid == null)
			{
				return;
			}
			if (m_EndLabel != null && !m_SerieGrid.context.endLabelList.Contains(m_EndLabel))
			{
				m_SerieGrid.context.endLabelList.Add(m_EndLabel);
			}
			VisualMap visualMapOfSerie = base.chart.GetVisualMapOfSerie(serie);
			DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
			List<SerieData> showData = serie.GetDataList(dataZoomOfAxis);
			if (showData.Count <= 0)
			{
				return;
			}
			float coordinateWidth = (serieGridCoordAxis ? m_SerieGrid.context.height : m_SerieGrid.context.width);
			int num = ((serie.maxShow <= 0) ? showData.Count : ((serie.maxShow > showData.Count) ? showData.Count : serie.maxShow));
			num -= serie.context.dataZoomStartIndexOffset;
			float dataWidth = AxisHelper.GetDataWidth(axis, coordinateWidth, num, dataZoomOfAxis);
			int dataAverageRate = LineHelper.GetDataAverageRate(serie, m_SerieGrid, num, isYAxis: false);
			double totalAverage = ((serie.sampleAverage > 0f) ? ((double)serie.sampleAverage) : DataHelper.DataAverage(ref showData, serie.sampleType, serie.minShow, num, dataAverageRate));
			bool dataChanging = false;
			float changeDuration = serie.animation.GetChangeDuration();
			bool unscaledTime = serie.animation.unscaledTime;
			bool interacting = false;
			float lineWidth = LineHelper.GetLineWidth(ref interacting, serie, base.chart.theme.serie.lineWidth);
			axis.context.scaleWidth = dataWidth;
			serie.containerIndex = m_SerieGrid.index;
			serie.containterInstanceId = m_SerieGrid.instanceId;
			Serie lastStackSerie = null;
			bool flag = SeriesHelper.IsStack<Line>(base.chart.series, serie.stack);
			if (flag)
			{
				lastStackSerie = SeriesHelper.GetLastStackSerie(base.chart.series, serie);
				SeriesHelper.UpdateStackDataList(base.chart.series, serie, dataZoomOfAxis, m_StackSerieData);
			}
			_ = Vector3.zero;
			for (int i = serie.minShow; i < showData.Count; i += dataAverageRate)
			{
				SerieData serieData = showData[i];
				int num2 = i - serie.context.dataZoomStartIndexOffset;
				if (serie.IsIgnoreValue(serieData))
				{
					serieData.context.stackHeight = 0f;
					serieData.context.position = Vector3.zero;
					if (serie.ignoreLineBreak && serie.context.dataIgnores.Count > 0)
					{
						serie.context.dataIgnores[serie.context.dataIgnores.Count - 1] = true;
					}
					continue;
				}
				Vector3 np = Vector3.zero;
				double xValue = (axis.IsCategory() ? ((double)num2) : serieData.GetData(0, axis.inverse));
				double yValue = DataHelper.SampleValue(ref showData, serie.sampleType, dataAverageRate, serie.minShow, num, totalAverage, i, 0f, changeDuration, ref dataChanging, relativedAxis, unscaledTime);
				serieData.context.stackHeight = GetDataPoint(serieGridCoordAxis, axis, relativedAxis, m_SerieGrid, xValue, yValue, i, dataWidth, flag, ref np);
				serieData.context.isClip = false;
				if (serie.clip && !m_SerieGrid.Contains(np))
				{
					serieData.context.isClip = true;
				}
				serie.context.dataIgnores.Add(item: false);
				serieData.context.position = np;
				serie.context.dataPoints.Add(np);
				serie.context.dataIndexs.Add(serieData.index);
			}
			if (dataChanging || interacting)
			{
				base.chart.RefreshPainter(serie);
			}
			if (serie.context.dataPoints.Count > 0)
			{
				serie.animation.InitProgress(serie.context.dataPoints, serieGridCoordAxis);
				VisualMapHelper.AutoSetLineMinMax(visualMapOfSerie, serie, serieGridCoordAxis, axis, relativedAxis);
				LineHelper.UpdateSerieDrawPoints(serie, base.chart.settings, base.chart.theme, visualMapOfSerie, lineWidth, serieGridCoordAxis);
				LineHelper.DrawSerieLineArea(vh, serie, lastStackSerie, base.chart.theme, visualMapOfSerie, serieGridCoordAxis, axis, relativedAxis, m_SerieGrid);
				LineHelper.DrawSerieLine(vh, base.chart.theme, serie, visualMapOfSerie, m_SerieGrid, axis, relativedAxis, lineWidth);
				serie.context.vertCount = vh.currentVertCount;
				if (!serie.animation.IsFinish())
				{
					serie.animation.CheckProgress();
					serie.animation.CheckSymbol(serie.symbol.GetSize(null, base.chart.theme.serie.lineSymbolSize));
					base.chart.RefreshPainter(serie);
				}
			}
		}

		private float GetDataPoint(bool isY, Axis axis, Axis relativedAxis, GridCoord grid, double xValue, double yValue, int i, float scaleWid, bool isStack, ref Vector3 np)
		{
			float num = (isY ? grid.context.x : grid.context.y);
			float num2 = 0f;
			num2 = AxisHelper.GetAxisValueDistance(grid, relativedAxis, scaleWid, yValue);
			num2 = AnimationStyleHelper.CheckDataAnimation(base.chart, base.serie, i, num2);
			float num3;
			float num4;
			if (isY)
			{
				num3 = num + num2;
				num4 = AxisHelper.GetAxisValuePosition(grid, axis, scaleWid, xValue);
				if (isStack)
				{
					for (int j = 0; j < m_StackSerieData.Count - 1; j++)
					{
						num3 += m_StackSerieData[j][i].context.stackHeight;
					}
				}
			}
			else
			{
				num4 = num + num2;
				num3 = AxisHelper.GetAxisValuePosition(grid, axis, scaleWid, xValue);
				if (isStack)
				{
					for (int k = 0; k < m_StackSerieData.Count - 1; k++)
					{
						num4 += m_StackSerieData[k][i].context.stackHeight;
					}
				}
			}
			np = new Vector3(num3, num4);
			return AxisHelper.GetAxisValueLength(grid, relativedAxis, scaleWid, yValue);
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
				for (int j = 0; j < base.serie.dataCount; j++)
				{
					SerieData serieData2 = base.serie.data[j];
					float angle2 = serieData2.context.angle;
					float num2 = ((j >= base.serie.dataCount - 1) ? angle2 : base.serie.data[j + 1].context.angle);
					if (angle >= angle2 && angle < num2)
					{
						base.serie.context.pointerItemDataIndex = j;
						base.serie.context.pointerEnter = true;
						serieData2.context.highlight = true;
					}
					else
					{
						serieData2.context.highlight = false;
					}
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

		private void DrawPolarLine(VertexHelper vh, Serie serie)
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
			_ = angleAxis.startAngle;
			SerieData serieData = data[0];
			Vector3 lp = PolarHelper.UpdatePolarAngleAndPos(m_SeriePolar, angleAxis, radiusAxis, serieData);
			Vector3 zero = Vector3.zero;
			Color32 lineColor = SerieHelper.GetLineColor(serie, null, base.chart.theme, serie.context.colorIndex);
			float width = serie.lineStyle.GetWidth(base.chart.theme.serie.lineWidth);
			float curr = 0f;
			int count = data.Count;
			serie.animation.InitProgress(curr, count);
			Vector3 ltp = Vector3.zero;
			Vector3 lbp = Vector3.zero;
			Vector3 ntp = Vector3.zero;
			Vector3 nbp = Vector3.zero;
			Vector3 itp = Vector3.zero;
			Vector3 ibp = Vector3.zero;
			Vector3 clp = Vector3.zero;
			Vector3 crp = Vector3.zero;
			bool bitp = true;
			bool bibp = true;
			if (data.Count <= 2)
			{
				for (int i = 0; i < data.Count; i++)
				{
					SerieData serieData2 = data[i];
					zero = PolarHelper.UpdatePolarAngleAndPos(m_SeriePolar, angleAxis, radiusAxis, data[i]);
					serieData2.context.position = zero;
					serie.context.dataPoints.Add(zero);
				}
				UGL.DrawLine(vh, serie.context.dataPoints, width, lineColor, smooth: false);
			}
			else
			{
				for (int j = 1; j < data.Count && !serie.animation.CheckDetailBreak(j); j++)
				{
					SerieData serieData3 = data[j];
					zero = PolarHelper.UpdatePolarAngleAndPos(m_SeriePolar, angleAxis, radiusAxis, data[j]);
					serieData3.context.position = zero;
					serie.context.dataPoints.Add(zero);
					Vector3 np = ((j == data.Count - 1) ? zero : PolarHelper.UpdatePolarAngleAndPos(m_SeriePolar, angleAxis, radiusAxis, data[j + 1]));
					UGLHelper.GetLinePoints(lp, zero, np, width, ref ltp, ref lbp, ref ntp, ref nbp, ref itp, ref ibp, ref clp, ref crp, ref bitp, ref bibp, j);
					if (j == 1)
					{
						UGL.AddVertToVertexHelper(vh, ltp, lbp, lineColor, needTriangle: false);
					}
					if (bitp == bibp)
					{
						if (bitp)
						{
							UGL.AddVertToVertexHelper(vh, itp, ibp, lineColor);
						}
						else
						{
							UGL.AddVertToVertexHelper(vh, ltp, clp, lineColor);
							UGL.AddVertToVertexHelper(vh, ltp, crp, lineColor);
						}
					}
					else if (bitp)
					{
						UGL.AddVertToVertexHelper(vh, itp, clp, lineColor);
						UGL.AddVertToVertexHelper(vh, itp, crp, lineColor);
					}
					else if (bibp)
					{
						UGL.AddVertToVertexHelper(vh, clp, ibp, lineColor);
						UGL.AddVertToVertexHelper(vh, crp, ibp, lineColor);
					}
					lp = zero;
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress(count);
				serie.animation.CheckSymbol(serie.symbol.GetSize(null, base.chart.theme.serie.lineSymbolSize));
				base.chart.RefreshChart();
			}
		}

		private void DrawPolarLineArrow(VertexHelper vh, Serie serie)
		{
			if (!serie.show || serie.lineArrow == null || !serie.lineArrow.show || serie.context.dataPoints.Count < 2)
			{
				return;
			}
			Color32 lineColor = SerieHelper.GetLineColor(serie, null, base.chart.theme, serie.context.colorIndex);
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			ArrowStyle arrow = serie.lineArrow.arrow;
			List<Vector3> dataPoints = serie.context.dataPoints;
			switch (serie.lineArrow.position)
			{
			case LineArrow.Position.End:
				if (dataPoints.Count < 3)
				{
					zero = dataPoints[dataPoints.Count - 2];
					zero2 = dataPoints[dataPoints.Count - 1];
				}
				else
				{
					zero = dataPoints[dataPoints.Count - 3];
					zero2 = dataPoints[dataPoints.Count - 2];
				}
				UGL.DrawArrow(vh, zero, zero2, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(lineColor));
				break;
			case LineArrow.Position.Start:
				zero = dataPoints[1];
				zero2 = dataPoints[0];
				UGL.DrawArrow(vh, zero, zero2, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(lineColor));
				break;
			}
		}

		private void DrawPolarLineSymbol(VertexHelper vh)
		{
			for (int i = 0; i < base.chart.series.Count; i++)
			{
				Serie serie = base.chart.series[i];
				if (!serie.show || !(serie is Line))
				{
					continue;
				}
				int dataCount = serie.dataCount;
				float border = 0f;
				float[] cornerRadius = null;
				for (int j = 0; j < dataCount; j++)
				{
					SerieData serieData = serie.GetSerieData(j);
					SerieState serieState = SerieHelper.GetSerieState(serie, serieData, defaultSerieState: true);
					SerieSymbol serieSymbol = SerieHelper.GetSerieSymbol(serie, serieData, serieState);
					if (!ChartHelper.IsIngore(serieData.context.position) && serieSymbol.show && serieSymbol.ShowSymbol(j, dataCount))
					{
						float sysmbolSize = SerieHelper.GetSysmbolSize(serie, serieData, base.chart.theme.serie.lineSymbolSize, serieState);
						SerieHelper.GetItemColor(out var color, out var toColor, out var backgroundColor, serie, serieData, base.chart.theme, i);
						SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, serie, null, base.chart.theme, serieState);
						sysmbolSize = serie.animation.GetSysmbolSize(sysmbolSize);
						base.chart.DrawSymbol(vh, serieSymbol.type, sysmbolSize, border, serieData.context.position, color, toColor, backgroundColor, borderColor, serieSymbol.gap, cornerRadius);
					}
				}
			}
		}
	}
}
