using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class SimplifiedBarHandler : SerieHandler<SimplifiedBar>
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
			DrawBarSerie(vh, base.serie, base.serie.context.colorIndex);
		}

		public override void UpdateSerieContext()
		{
			if (m_SerieGrid == null)
			{
				return;
			}
			bool flag = (base.chart.isPointerInChart && m_SerieGrid.IsPointerEnter()) || m_LegendEnter;
			bool needInteract = false;
			Color32 color;
			Color32 toColor;
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
					SerieHelper.GetItemColor(out color, out toColor, base.serie, datum, base.chart.theme, SerieState.Normal);
					datum.interact.SetColor(ref needInteract, color, toColor);
				}
				if (needInteract)
				{
					base.chart.RefreshPainter(base.serie);
				}
				return;
			}
			m_LastCheckContextFlag = flag;
			if (m_LegendEnter)
			{
				base.serie.context.pointerEnter = true;
				foreach (SerieData datum2 in base.serie.data)
				{
					SerieHelper.GetItemColor(out color, out toColor, base.serie, datum2, base.chart.theme, SerieState.Emphasis);
					datum2.interact.SetColor(ref needInteract, color, toColor);
				}
			}
			else
			{
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerEnter = false;
				foreach (SerieData datum3 in base.serie.data)
				{
					if (datum3.context.rect.Contains(base.chart.pointerPos))
					{
						base.serie.context.pointerItemDataIndex = datum3.index;
						base.serie.context.pointerEnter = true;
						datum3.context.highlight = true;
						SerieHelper.GetItemColor(out color, out toColor, base.serie, datum3, base.chart.theme, SerieState.Emphasis);
						datum3.interact.SetColor(ref needInteract, color, toColor);
					}
					else
					{
						datum3.context.highlight = false;
						SerieHelper.GetItemColor(out color, out toColor, base.serie, datum3, base.chart.theme, SerieState.Normal);
						datum3.interact.SetColor(ref needInteract, color, toColor);
					}
				}
			}
			if (needInteract)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		private void DrawBarSerie(VertexHelper vh, SimplifiedBar serie, int colorIndex)
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
			List<SerieData> dataList = serie.GetDataList(dataZoomOfAxis);
			if (dataList.Count <= 0)
			{
				return;
			}
			float num = (serieGridCoordAxis ? m_SerieGrid.context.height : m_SerieGrid.context.width);
			float num2 = (serieGridCoordAxis ? m_SerieGrid.context.y : m_SerieGrid.context.x);
			int serieBarRealCount = base.chart.GetSerieBarRealCount<SimplifiedBar>();
			float dataWidth = AxisHelper.GetDataWidth(axis, num, dataList.Count, dataZoomOfAxis);
			float serieBarGap = base.chart.GetSerieBarGap<SimplifiedBar>();
			float serieTotalWidth = base.chart.GetSerieTotalWidth<SimplifiedBar>(dataWidth, serieBarGap, serieBarRealCount);
			float barWidth = serie.GetBarWidth(dataWidth, serieBarRealCount);
			float num3 = (dataWidth - serieTotalWidth) * 0.5f;
			float num4 = barWidth + barWidth * serieBarGap;
			float gap = ((serie.barGap == -1f) ? num3 : (num3 + (float)serie.index * num4));
			int num5 = ((serie.maxShow <= 0) ? dataList.Count : ((serie.maxShow > dataList.Count) ? dataList.Count : serie.maxShow));
			bool flag = false;
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
			serie.animation.InitProgress(num2, num2 + num);
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
					flag = true;
				}
				bool highlight = serieData.context.highlight || serie.highlight;
				ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData);
				double value = (axis.IsCategory() ? ((double)i) : serieData.GetData(0, axis.inverse));
				double currData = serieData.GetCurrData(1, additionDuration, changeDuration, relativedAxis.inverse, minValue, maxValue, serie.animation.unscaledTime);
				float borderWidth = ((currData == 0.0) ? 0f : itemStyle.runtimeBorderWidth);
				if (!serieData.interact.TryGetColor(ref color, ref toColor, ref interacting, interactionDuration))
				{
					SerieHelper.GetItemColor(out color, out toColor, serie, serieData, base.chart.theme);
					serieData.interact.SetColor(ref interacting, color, toColor);
				}
				float pX = 0f;
				float pY = 0f;
				UpdateXYPosition(m_SerieGrid, serieGridCoordAxis, axis, relativedAxis, i, dataWidth, barWidth, value, ref pX, ref pY);
				float axisValueLength = AxisHelper.GetAxisValueLength(m_SerieGrid, relativedAxis, dataWidth, currData);
				float currHig = AnimationStyleHelper.CheckDataAnimation(base.chart, serie, i, axisValueLength);
				UpdateRectPosition(m_SerieGrid, serieGridCoordAxis, currData, pX, pY, gap, borderWidth, barWidth, currHig, out var plb, out var plt, out var prt, out var prb, out var top);
				serieData.context.stackHeight = axisValueLength;
				serieData.context.position = top;
				serieData.context.rect = Rect.MinMaxRect(plb.x, plb.y, prb.x, prt.y);
				serie.context.dataPoints.Add(top);
				serie.context.dataIndexs.Add(serieData.index);
				DrawNormalBar(vh, serie, serieData, itemStyle, colorIndex, highlight, gap, barWidth, pX, pY, plb, plt, prt, prb, isYAxis: false, m_SerieGrid, color, toColor);
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
			if (flag || interacting)
			{
				base.chart.RefreshPainter(serie);
			}
		}

		private void UpdateXYPosition(GridCoord grid, bool isY, Axis axis, Axis relativedAxis, int i, float categoryWidth, float barWidth, double value, ref float pX, ref float pY)
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
					pY = grid.context.y + (float)((value - axis.context.minValue) / axis.context.minMaxRange) * (grid.context.height - barWidth);
				}
				pX = AxisHelper.GetAxisValuePosition(grid, relativedAxis, categoryWidth, 0.0);
			}
			else
			{
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
					pX = grid.context.x + (float)((value - axis.context.minValue) / axis.context.minMaxRange) * (grid.context.width - barWidth);
				}
				pY = AxisHelper.GetAxisValuePosition(grid, relativedAxis, categoryWidth, 0.0);
			}
		}

		private void UpdateRectPosition(GridCoord grid, bool isY, double yValue, float pX, float pY, float gap, float borderWidth, float barWidth, float currHig, out Vector3 plb, out Vector3 plt, out Vector3 prt, out Vector3 prb, out Vector3 top)
		{
			if (isY)
			{
				if (yValue < 0.0)
				{
					plt = new Vector3(pX - borderWidth, pY + gap + barWidth - borderWidth);
					prt = new Vector3(pX + currHig + borderWidth, pY + gap + barWidth - borderWidth);
					prb = new Vector3(pX + currHig + borderWidth, pY + gap + borderWidth);
					plb = new Vector3(pX - borderWidth, pY + gap + borderWidth);
				}
				else
				{
					plt = new Vector3(pX + borderWidth, pY + gap + barWidth - borderWidth);
					prt = new Vector3(pX + currHig - borderWidth, pY + gap + barWidth - borderWidth);
					prb = new Vector3(pX + currHig - borderWidth, pY + gap + borderWidth);
					plb = new Vector3(pX + borderWidth, pY + gap + borderWidth);
				}
				top = new Vector3(pX + currHig - borderWidth, pY + gap + barWidth / 2f);
			}
			else
			{
				if (yValue < 0.0)
				{
					plb = new Vector3(pX + gap + borderWidth, pY - borderWidth);
					plt = new Vector3(pX + gap + borderWidth, pY + currHig + borderWidth);
					prt = new Vector3(pX + gap + barWidth - borderWidth, pY + currHig + borderWidth);
					prb = new Vector3(pX + gap + barWidth - borderWidth, pY - borderWidth);
				}
				else
				{
					plb = new Vector3(pX + gap + borderWidth, pY + borderWidth);
					plt = new Vector3(pX + gap + borderWidth, pY + currHig - borderWidth);
					prt = new Vector3(pX + gap + barWidth - borderWidth, pY + currHig - borderWidth);
					prb = new Vector3(pX + gap + barWidth - borderWidth, pY + borderWidth);
				}
				top = new Vector3(pX + gap + barWidth / 2f, pY + currHig - borderWidth);
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

		private void DrawNormalBar(VertexHelper vh, Serie serie, SerieData serieData, ItemStyle itemStyle, int colorIndex, bool highlight, float gap, float barWidth, float pX, float pY, Vector3 plb, Vector3 plt, Vector3 prt, Vector3 prb, bool isYAxis, GridCoord grid, Color32 areaColor, Color32 areaToColor)
		{
			float runtimeBorderWidth = itemStyle.runtimeBorderWidth;
			if (isYAxis)
			{
				if (serie.clip)
				{
					prb = base.chart.ClampInGrid(grid, prb);
					plb = base.chart.ClampInGrid(grid, plb);
					plt = base.chart.ClampInGrid(grid, plt);
					prt = base.chart.ClampInGrid(grid, prt);
				}
				float num = Mathf.Abs(prb.x - plt.x);
				float num2 = Mathf.Abs(prt.y - plb.y);
				Vector3 center = new Vector3((plt.x + prb.x) / 2f, (prt.y + plb.y) / 2f);
				if (num > 0f && num2 > 0f)
				{
					bool flag = center.x < plb.x;
					if (itemStyle.IsNeedCorner())
					{
						UGL.DrawRoundRectangle(vh, center, num, num2, areaColor, areaToColor, 0f, itemStyle.cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag);
					}
					else
					{
						base.chart.DrawClipPolygon(vh, plb, plt, prt, prb, areaColor, areaToColor, serie.clip, grid);
					}
					UGL.DrawBorder(vh, center, num, num2, runtimeBorderWidth, itemStyle.borderColor, itemStyle.borderToColor, 0f, itemStyle.cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag);
				}
				return;
			}
			if (serie.clip)
			{
				prb = base.chart.ClampInGrid(grid, prb);
				plb = base.chart.ClampInGrid(grid, plb);
				plt = base.chart.ClampInGrid(grid, plt);
				prt = base.chart.ClampInGrid(grid, prt);
			}
			float num3 = Mathf.Abs(prt.x - plb.x);
			float num4 = Mathf.Abs(plt.y - prb.y);
			Vector3 center2 = new Vector3((plb.x + prt.x) / 2f, (plt.y + prb.y) / 2f);
			if (num3 > 0f && num4 > 0f)
			{
				bool flag2 = center2.y < plb.y;
				if (itemStyle.IsNeedCorner())
				{
					UGL.DrawRoundRectangle(vh, center2, num3, num4, areaColor, areaToColor, 0f, itemStyle.cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag2);
				}
				else
				{
					base.chart.DrawClipPolygon(vh, ref prb, ref plb, ref plt, ref prt, areaColor, areaToColor, serie.clip, grid);
				}
				UGL.DrawBorder(vh, center2, num3, num4, runtimeBorderWidth, itemStyle.borderColor, itemStyle.borderToColor, 0f, itemStyle.cornerRadius, isYAxis, base.chart.settings.cicleSmoothness, flag2);
			}
		}
	}
}
