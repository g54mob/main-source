using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class BarHandler : SerieHandler<Bar>
	{
		private List<List<SerieData>> m_StackSerieData = new List<List<SerieData>>();

		private GridCoord m_SerieGrid;

		private float[] m_CapusleDefaultCornerRadius = new float[4] { 1f, 1f, 1f, 1f };

		private PolarCoord m_SeriePolar;

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

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			UpdateCoordSerieParams(ref paramList, ref title, dataIndex, showCategory, category, marker, itemFormatter, numericFormatter, ignoreDataDefaultContent);
		}

		public override void DrawSerie(VertexHelper vh)
		{
			if (base.serie.IsUseCoord<PolarCoord>())
			{
				DrawPolarBar(vh, base.serie);
			}
			else if (base.serie.IsUseCoord<GridCoord>())
			{
				DrawBarSerie(vh, base.serie);
			}
		}

		public override Vector3 GetSerieDataLabelPosition(SerieData serieData, LabelStyle label)
		{
			if (base.serie.IsUseCoord<PolarCoord>())
			{
				switch (label.position)
				{
				case LabelStyle.Position.Bottom:
				{
					Vector3 areaCenter2 = serieData.context.areaCenter;
					float halfAngle = serieData.context.halfAngle;
					float outsideRadius = serieData.context.insideRadius;
					return ChartHelper.GetPosition(areaCenter2, halfAngle, outsideRadius);
				}
				case LabelStyle.Position.Top:
				{
					Vector3 areaCenter = serieData.context.areaCenter;
					float halfAngle = serieData.context.halfAngle;
					float outsideRadius = serieData.context.outsideRadius;
					return ChartHelper.GetPosition(areaCenter, halfAngle, outsideRadius);
				}
				default:
					return serieData.context.position;
				}
			}
			switch (label.position)
			{
			case LabelStyle.Position.Bottom:
			{
				Vector2 center = serieData.context.rect.center;
				return new Vector3(center.x, center.y - serieData.context.rect.height / 2f);
			}
			case LabelStyle.Position.Inside:
			case LabelStyle.Position.Center:
				return serieData.context.rect.center;
			default:
				return serieData.context.position;
			}
		}

		private void UpdateSerieGridContext()
		{
			if (m_SerieGrid == null)
			{
				return;
			}
			bool flag = (base.chart.isPointerInChart && m_SerieGrid.IsPointerEnter() && !base.serie.placeHolder) || m_LegendEnter;
			bool needInteract = false;
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
					datum.interact.Reset();
				}
				base.chart.RefreshPainter(base.serie);
				return;
			}
			m_LastCheckContextFlag = flag;
			Color32 color;
			Color32 toColor;
			if (m_LegendEnter)
			{
				base.serie.context.pointerEnter = true;
				foreach (SerieData datum2 in base.serie.data)
				{
					SerieHelper.GetItemColor(out color, out toColor, base.serie, datum2, base.chart.theme);
					datum2.interact.SetColor(ref needInteract, color, toColor);
				}
			}
			else
			{
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				foreach (SerieData datum3 in base.serie.data)
				{
					if (base.serie.context.pointerAxisDataIndexs.Contains(datum3.index) || datum3.context.rect.Contains(base.chart.pointerPos))
					{
						base.serie.context.pointerItemDataIndex = datum3.index;
						base.serie.context.pointerEnter = true;
						datum3.context.highlight = true;
					}
					else
					{
						datum3.context.highlight = false;
					}
					SerieState serieState = SerieHelper.GetSerieState(base.serie, datum3, defaultSerieState: true);
					SerieHelper.GetItemColor(out color, out toColor, base.serie, datum3, base.chart.theme, serieState);
					datum3.interact.SetColor(ref needInteract, color, toColor);
				}
			}
			if (needInteract)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		private void DrawBarSerie(VertexHelper vh, Bar serie)
		{
			if (!serie.show || serie.animation.HasFadeOut())
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
			DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
			List<SerieData> dataList = serie.GetDataList(dataZoomOfAxis);
			if (dataList.Count <= 0)
			{
				return;
			}
			float num = (serieGridCoordAxis ? m_SerieGrid.context.height : m_SerieGrid.context.width);
			float num2 = (serieGridCoordAxis ? m_SerieGrid.context.width : m_SerieGrid.context.height);
			float num3 = (serieGridCoordAxis ? m_SerieGrid.context.y : m_SerieGrid.context.x);
			bool flag = SeriesHelper.IsStack<Bar>(base.chart.series, serie.stack);
			if (flag)
			{
				SeriesHelper.UpdateStackDataList(base.chart.series, serie, dataZoomOfAxis, m_StackSerieData);
			}
			int serieBarRealCount = base.chart.GetSerieBarRealCount<Bar>();
			float dataWidth = AxisHelper.GetDataWidth(axis, num, dataList.Count, dataZoomOfAxis);
			float serieBarGap = base.chart.GetSerieBarGap<Bar>();
			float serieTotalWidth = base.chart.GetSerieTotalWidth<Bar>(dataWidth, serieBarGap, serieBarRealCount);
			float barWidth = serie.GetBarWidth(dataWidth, serieBarRealCount);
			float num4 = (dataWidth - serieTotalWidth) * 0.5f;
			int serieIndexIfStack = base.chart.GetSerieIndexIfStack<Bar>(serie);
			float gap = ((serie.barGap == -1f) ? num4 : (num4 + base.chart.GetSerieTotalGap<Bar>(dataWidth, serieBarGap, serieIndexIfStack)));
			int num5 = ((serie.maxShow <= 0) ? dataList.Count : ((serie.maxShow > dataList.Count) ? dataList.Count : serie.maxShow));
			bool flag2 = SeriesHelper.IsPercentStack<Bar>(base.chart.series, serie.stack);
			bool flag3 = false;
			float changeDuration = serie.animation.GetChangeDuration();
			float additionDuration = serie.animation.GetAdditionDuration();
			float interactionDuration = serie.animation.GetInteractionDuration();
			double minValue = relativedAxis.context.minValue;
			double maxValue = relativedAxis.context.maxValue;
			Color32 color = ColorUtil.clearColor32;
			Color32 toColor = ColorUtil.clearColor32;
			bool interacting = false;
			serie.containerIndex = m_SerieGrid.index;
			serie.containterInstanceId = m_SerieGrid.instanceId;
			serie.animation.InitProgress(num3, num3 + num);
			for (int i = serie.minShow; i < num5; i++)
			{
				SerieData serieData = dataList[i];
				if (!serieData.show || serie.IsIgnoreValue(serieData))
				{
					serie.context.dataPoints.Add(Vector3.zero);
					serie.context.dataIndexs.Add(serieData.index);
					continue;
				}
				if (serieData.IsDataChanged())
				{
					flag3 = true;
				}
				SerieState serieState = SerieHelper.GetSerieState(serie, serieData);
				ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData, serieState);
				double value = (axis.IsCategory() ? ((double)i) : serieData.GetData(0, axis.inverse));
				double currData = serieData.GetCurrData(1, additionDuration, changeDuration, relativedAxis.inverse, minValue, maxValue, serie.animation.unscaledTime);
				float num6 = ((currData == 0.0) ? 0f : itemStyle.runtimeBorderWidth);
				float num7 = ((currData == 0.0) ? 0f : itemStyle.borderGap);
				float num8 = num6 + num7;
				Color32 backgroundColor = itemStyle.backgroundColor;
				if (!serieData.interact.TryGetColor(ref color, ref toColor, ref interacting, interactionDuration))
				{
					SerieHelper.GetItemColor(out color, out toColor, serie, serieData, base.chart.theme);
					serieData.interact.SetColor(ref interacting, color, toColor);
				}
				float pX = 0f;
				float pY = 0f;
				UpdateXYPosition(m_SerieGrid, serieGridCoordAxis, axis, relativedAxis, i, dataWidth, barWidth, flag, value, ref pX, ref pY);
				float num9 = 0f;
				if (flag2)
				{
					double serieSameStackTotalValue = base.chart.GetSerieSameStackTotalValue<Bar>(serie.stack, i);
					num9 = ((serieSameStackTotalValue != 0.0) ? ((float)(currData / serieSameStackTotalValue * (double)num2)) : 0f);
				}
				else
				{
					num9 = AxisHelper.GetAxisValueLength(m_SerieGrid, relativedAxis, dataWidth, currData);
				}
				float currHig = AnimationStyleHelper.CheckDataAnimation(base.chart, serie, i, num9);
				UpdateRectPosition(m_SerieGrid, serieGridCoordAxis, currData, pX, pY, gap, num6, barWidth, currHig, out var plb, out var plt, out var prt, out var prb, out var top);
				serieData.context.stackHeight = num9;
				serieData.context.position = top;
				serieData.context.rect = Rect.MinMaxRect(plb.x + num8, plb.y + num8, prt.x - num8, prt.y - num8);
				serieData.context.backgroundRect = (serieGridCoordAxis ? Rect.MinMaxRect(m_SerieGrid.context.x, plb.y, m_SerieGrid.context.x + num2, prt.y) : Rect.MinMaxRect(plb.x, m_SerieGrid.context.y, prb.x, m_SerieGrid.context.y + num2));
				if (serie.clip && (!serie.clip || !m_SerieGrid.Contains(top)))
				{
					continue;
				}
				serie.context.dataPoints.Add(top);
				serie.context.dataIndexs.Add(serieData.index);
				if (serie.show && !serie.placeHolder)
				{
					switch (serie.barType)
					{
					case BarType.Normal:
					case BarType.Capsule:
						DrawNormalBar(vh, serie, serieData, itemStyle, backgroundColor, gap, barWidth, pX, pY, plb, plt, prt, prb, serieGridCoordAxis, m_SerieGrid, axis, color, toColor, currData);
						break;
					case BarType.Zebra:
						DrawZebraBar(vh, serie, serieData, itemStyle, backgroundColor, gap, barWidth, pX, pY, plb, plt, prt, prb, serieGridCoordAxis, m_SerieGrid, axis, color, toColor);
						break;
					}
				}
				if (serie.animation.CheckDetailBreak(top, serieGridCoordAxis))
				{
					break;
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress();
				base.chart.RefreshPainter(serie);
			}
			if (flag3 || interacting)
			{
				base.chart.RefreshPainter(serie);
			}
		}

		private void UpdateXYPosition(GridCoord grid, bool isY, Axis axis, Axis relativedAxis, int i, float categoryWidth, float barWidth, bool isStack, double value, ref float pX, ref float pY)
		{
			if (isY)
			{
				if (axis.IsCategory())
				{
					pY = grid.context.y + (float)i * categoryWidth + (axis.boundaryGap ? 0f : ((0f - categoryWidth) * 0.5f));
				}
				else if (axis.context.minMaxRange <= 0.0)
				{
					pY = grid.context.y;
				}
				else
				{
					float num = (float)((value - axis.context.minValue) / axis.context.minMaxRange) * grid.context.height;
					pY = grid.context.y + num - categoryWidth * 0.5f;
				}
				pX = AxisHelper.GetAxisValuePosition(grid, relativedAxis, categoryWidth, 0.0);
				if (isStack)
				{
					for (int j = 0; j < m_StackSerieData.Count - 1; j++)
					{
						pX += m_StackSerieData[j][i].context.stackHeight;
					}
				}
				return;
			}
			if (axis.IsCategory())
			{
				pX = grid.context.x + (float)i * categoryWidth + (axis.boundaryGap ? 0f : ((0f - categoryWidth) * 0.5f));
			}
			else if (axis.context.minMaxRange <= 0.0)
			{
				pX = grid.context.x;
			}
			else
			{
				float num2 = (float)((value - axis.context.minValue) / axis.context.minMaxRange) * grid.context.width;
				pX = grid.context.x + num2 - categoryWidth * 0.5f;
			}
			pY = AxisHelper.GetAxisValuePosition(grid, relativedAxis, categoryWidth, 0.0);
			if (isStack)
			{
				for (int k = 0; k < m_StackSerieData.Count - 1; k++)
				{
					pY += m_StackSerieData[k][i].context.stackHeight;
				}
			}
		}

		private void UpdateRectPosition(GridCoord grid, bool isY, double yValue, float pX, float pY, float gap, float borderWidth, float barWidth, float currHig, out Vector3 plb, out Vector3 plt, out Vector3 prt, out Vector3 prb, out Vector3 top)
		{
			if (isY)
			{
				if (yValue < 0.0)
				{
					plt = new Vector3(pX + currHig, pY + gap + barWidth);
					prt = new Vector3(pX, pY + gap + barWidth);
					prb = new Vector3(pX, pY + gap);
					plb = new Vector3(pX + currHig, pY + gap);
				}
				else
				{
					plt = new Vector3(pX, pY + gap + barWidth);
					prt = new Vector3(pX + currHig, pY + gap + barWidth);
					prb = new Vector3(pX + currHig, pY + gap);
					plb = new Vector3(pX, pY + gap);
				}
				top = new Vector3(pX + currHig, pY + gap + barWidth / 2f);
			}
			else
			{
				if (yValue < 0.0)
				{
					plb = new Vector3(pX + gap, pY + currHig);
					plt = new Vector3(pX + gap, pY);
					prt = new Vector3(pX + gap + barWidth, pY);
					prb = new Vector3(pX + gap + barWidth, pY + currHig);
				}
				else
				{
					plb = new Vector3(pX + gap, pY);
					plt = new Vector3(pX + gap, pY + currHig);
					prt = new Vector3(pX + gap + barWidth, pY + currHig);
					prb = new Vector3(pX + gap + barWidth, pY);
				}
				top = new Vector3(pX + gap + barWidth / 2f, pY + currHig);
			}
			if (base.serie.clip)
			{
				plb = base.chart.ClampInGrid(grid, plb);
				plt = base.chart.ClampInGrid(grid, plt);
				prt = base.chart.ClampInGrid(grid, prt);
				prb = base.chart.ClampInGrid(grid, prb);
				top = base.chart.ClampInGrid(grid, top);
			}
		}

		private void DrawNormalBar(VertexHelper vh, Serie serie, SerieData serieData, ItemStyle itemStyle, Color32 backgroundColor, float gap, float barWidth, float pX, float pY, Vector3 plb, Vector3 plt, Vector3 prt, Vector3 prb, bool isYAxis, GridCoord grid, Axis axis, Color32 areaColor, Color32 areaToColor, double value)
		{
			float runtimeBorderWidth = itemStyle.runtimeBorderWidth;
			float[] cornerRadius = ((serie.barType == BarType.Capsule && !itemStyle.IsNeedCorner()) ? m_CapusleDefaultCornerRadius : itemStyle.cornerRadius);
			bool flag = value < 0.0;
			if (!ChartHelper.IsClearColor(backgroundColor))
			{
				UGL.DrawRoundRectangle(vh, serieData.context.backgroundRect, backgroundColor, backgroundColor, 0f, cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag);
			}
			UGL.DrawRoundRectangle(vh, serieData.context.rect, areaColor, areaToColor, 0f, cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag);
			if (serie.barType == BarType.Capsule)
			{
				UGL.DrawBorder(vh, serieData.context.backgroundRect, runtimeBorderWidth, itemStyle.borderColor, 0f, cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag, 0f - runtimeBorderWidth);
			}
			else
			{
				UGL.DrawBorder(vh, serieData.context.rect, runtimeBorderWidth, itemStyle.borderColor, 0f, cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag, itemStyle.borderGap);
			}
		}

		private void DrawZebraBar(VertexHelper vh, Serie serie, SerieData serieData, ItemStyle itemStyle, Color32 backgroundColor, float gap, float barWidth, float pX, float pY, Vector3 plb, Vector3 plt, Vector3 prt, Vector3 prb, bool isYAxis, GridCoord grid, Axis axis, Color32 barColor, Color32 barToColor)
		{
			if (!ChartHelper.IsClearColor(backgroundColor))
			{
				UGL.DrawRoundRectangle(vh, serieData.context.backgroundRect, backgroundColor, backgroundColor, 0f, null, isYAxis, base.chart.settings.cicleSmoothness);
			}
			if (isYAxis)
			{
				plt = (plb + plt) / 2f;
				prt = (prt + prb) / 2f;
				base.chart.DrawClipZebraLine(vh, plt, prt, barWidth / 2f, serie.barZebraWidth, serie.barZebraGap, barColor, barToColor, serie.clip, grid, grid.context.width);
			}
			else
			{
				plb = (prb + plb) / 2f;
				plt = (plt + prt) / 2f;
				base.chart.DrawClipZebraLine(vh, plb, plt, barWidth / 2f, serie.barZebraWidth, serie.barZebraGap, barColor, barToColor, serie.clip, grid, grid.context.height);
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

		private void DrawPolarBar(VertexHelper vh, Serie serie)
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
			float startAngle = angleAxis.context.startAngle;
			float curr = 0f;
			int count = data.Count;
			serie.animation.InitProgress(curr, count);
			bool flag = SeriesHelper.IsStack<Bar>(base.chart.series, serie.stack);
			if (flag)
			{
				SeriesHelper.UpdateStackDataList(base.chart.series, serie, null, m_StackSerieData);
			}
			int serieBarRealCount = base.chart.GetSerieBarRealCount<Bar>();
			float num = (angleAxis.IsCategory() ? AxisHelper.GetDataWidth(angleAxis, 360f, data.Count, null) : AxisHelper.GetDataWidth(radiusAxis, m_SeriePolar.context.radius, data.Count, null));
			float serieBarGap = base.chart.GetSerieBarGap<Bar>();
			float serieTotalWidth = base.chart.GetSerieTotalWidth<Bar>(num, serieBarGap, serieBarRealCount);
			float barWidth = serie.GetBarWidth(num, serieBarRealCount);
			float num2 = (num - serieTotalWidth) * 0.5f;
			int serieIndexIfStack = base.chart.GetSerieIndexIfStack<Bar>(serie);
			float num3 = ((serie.barGap == -1f) ? num2 : (num2 + base.chart.GetSerieTotalGap<Bar>(num, serieBarGap, serieIndexIfStack)));
			Color32 color = ColorUtil.clearColor32;
			Color32 toColor = ColorUtil.clearColor32;
			bool interacting = false;
			float interactionDuration = serie.animation.GetInteractionDuration();
			for (int i = 0; i < data.Count && !serie.animation.CheckDetailBreak(i); i++)
			{
				SerieData serieData = data[i];
				ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
				float borderWidth = itemStyle.borderWidth;
				Color32 borderColor = itemStyle.borderColor;
				double data2 = serieData.GetData(0);
				double data3 = serieData.GetData(1);
				float num4;
				float num5;
				float num6;
				float num7;
				if (angleAxis.IsCategory())
				{
					num4 = (float)((double)startAngle + (double)num * data3 + (double)num3);
					num5 = num4 + barWidth;
					num6 = m_SeriePolar.context.insideRadius;
					if (flag)
					{
						for (int j = 0; j < m_StackSerieData.Count - 1; j++)
						{
							num6 += m_StackSerieData[j][i].context.stackHeight;
						}
					}
					num7 = num6 + radiusAxis.GetValueLength(data2, m_SeriePolar.context.radius);
					serieData.context.stackHeight = num7 - num6;
				}
				else
				{
					num4 = startAngle;
					if (flag)
					{
						for (int k = 0; k < m_StackSerieData.Count - 1; k++)
						{
							num4 += m_StackSerieData[k][i].context.stackHeight;
						}
					}
					num5 = num4 + angleAxis.GetValueLength(data3, 360f);
					serieData.context.stackHeight = num5 - num4;
					num6 = m_SeriePolar.context.insideRadius + num * (float)data2 + num3;
					num7 = num6 + barWidth;
				}
				serieData.context.startAngle = num4;
				serieData.context.toAngle = num5;
				serieData.context.halfAngle = (num4 + num5) / 2f;
				if (!serieData.interact.TryGetColor(ref color, ref toColor, ref interacting, interactionDuration))
				{
					SerieHelper.GetItemColor(out color, out toColor, serie, serieData, base.chart.theme);
					serieData.interact.SetColor(ref interacting, color, toColor);
				}
				bool roundCap = serie.roundCap && num6 > 0f;
				serieData.context.insideRadius = num6;
				serieData.context.outsideRadius = num7;
				serieData.context.areaCenter = m_SeriePolar.context.center;
				serieData.context.position = ChartHelper.GetPosition(m_SeriePolar.context.center, (num4 + num5) / 2f, (num6 + num7) / 2f);
				UGL.DrawDoughnut(vh, m_SeriePolar.context.center, num6, num7, color, toColor, ColorUtil.clearColor32, num4, num5, borderWidth, borderColor, serie.gap / 2f, base.chart.settings.cicleSmoothness, roundCap);
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
