using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class RadarHandler : SerieHandler<Radar>
	{
		private RadarCoord m_RadarCoord;

		public override void Update()
		{
			base.Update();
		}

		public override void DrawSerie(VertexHelper vh)
		{
			if (base.serie.show)
			{
				switch (base.serie.radarType)
				{
				case RadarType.Multiple:
					DrawMutipleRadar(vh);
					break;
				case RadarType.Single:
					DrawSingleRadar(vh);
					break;
				}
			}
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			if (!base.serie.context.pointerEnter)
			{
				return;
			}
			dataIndex = base.serie.context.pointerItemDataIndex;
			if (dataIndex < 0)
			{
				return;
			}
			RadarCoord chartComponent = base.chart.GetChartComponent<RadarCoord>(base.serie.radarIndex);
			if (chartComponent == null)
			{
				return;
			}
			if (base.serie.radarType == RadarType.Single)
			{
				int colorIndex = (base.serie.colorByData ? dataIndex : base.serie.context.colorIndex);
				category = chartComponent.GetIndicatorName(dataIndex);
				UpdateItemSerieParams(ref paramList, ref title, dataIndex, category, marker, itemFormatter, numericFormatter, ignoreDataDefaultContent, 1, colorIndex);
				return;
			}
			SerieData serieData = base.serie.GetSerieData(dataIndex);
			if (serieData == null)
			{
				return;
			}
			int index = (base.serie.colorByData ? base.chart.GetLegendRealShowNameIndex(serieData.legendName) : base.serie.context.colorIndex);
			SerieHelper.GetItemColor(out var color, out var _, base.serie, serieData, base.chart.theme, index, SerieState.Normal);
			title = serieData.name;
			for (int i = 0; i < serieData.data.Count; i++)
			{
				RadarCoord.Indicator indicator = chartComponent.GetIndicator(i);
				if (indicator != null)
				{
					SerieParams serieParams = new SerieParams();
					serieParams.serieName = base.serie.serieName;
					serieParams.serieIndex = base.serie.index;
					serieParams.dimension = i;
					serieParams.serieData = serieData;
					serieParams.dataCount = base.serie.dataCount;
					serieParams.value = serieData.GetData(i);
					serieParams.total = indicator.max;
					serieParams.color = color;
					serieParams.category = chartComponent.GetIndicatorName(i);
					serieParams.marker = SerieHelper.GetItemMarker(base.serie, serieData, marker);
					serieParams.itemFormatter = SerieHelper.GetItemFormatter(base.serie, serieData, itemFormatter);
					serieParams.numericFormatter = SerieHelper.GetNumericFormatter(base.serie, serieData, numericFormatter);
					serieParams.columns.Clear();
					serieParams.columns.Add(serieParams.marker);
					serieParams.columns.Add(indicator.name);
					serieParams.columns.Add(ChartCached.NumberToStr(serieData.GetData(i), serieParams.numericFormatter));
					paramList.Add(serieParams);
				}
			}
		}

		public override void UpdateSerieContext()
		{
			bool flag = m_LegendEnter || (base.chart.isPointerInChart && m_RadarCoord != null && m_RadarCoord.IsPointerEnter());
			bool needInteract = false;
			if (!flag)
			{
				if (m_LastCheckContextFlag == flag)
				{
					return;
				}
				m_LastCheckContextFlag = flag;
				base.serie.context.pointerItemDataIndex = -1;
				base.serie.context.pointerItemDataDimension = -1;
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
			base.serie.highlight = false;
			base.serie.context.pointerEnter = false;
			base.serie.context.pointerItemDataIndex = -1;
			base.serie.context.pointerItemDataDimension = -1;
			AreaStyle areaStyle = base.serie.areaStyle;
			float lineSymbolSize = base.chart.theme.serie.lineSymbolSize;
			switch (base.serie.radarType)
			{
			case RadarType.Multiple:
			{
				for (int k = 0; k < base.serie.data.Count; k++)
				{
					SerieData serieData4 = base.serie.data[k];
					float size = SerieHelper.GetSerieSymbol(base.serie, serieData4).GetSize(serieData4.data, base.chart.theme.serie.lineSymbolSize);
					if (m_LegendEnter)
					{
						serieData4.context.highlight = true;
						serieData4.interact.SetValue(ref needInteract, base.serie.animation.interaction.GetRadius(size));
						continue;
					}
					serieData4.context.highlight = false;
					for (int l = 0; l < serieData4.context.dataPoints.Count; l++)
					{
						Vector3 b = serieData4.context.dataPoints[l];
						if (Vector3.Distance(base.chart.pointerPos, b) < size * 2f)
						{
							base.serie.highlight = true;
							base.serie.context.pointerEnter = true;
							base.serie.context.pointerItemDataIndex = k;
							base.serie.context.pointerItemDataDimension = l;
							serieData4.context.highlight = true;
							break;
						}
					}
					if (!serieData4.context.highlight && areaStyle != null)
					{
						Vector3 center2 = m_RadarCoord.context.center;
						List<Vector3> dataPoints = serieData4.context.dataPoints;
						for (int m = 0; m < dataPoints.Count; m++)
						{
							Vector3 p = dataPoints[m];
							Vector3 p2 = ((m >= dataPoints.Count - 1) ? dataPoints[0] : dataPoints[m + 1]);
							if (UGLHelper.IsPointInTriangle(p, center2, p2, base.chart.pointerPos))
							{
								base.serie.highlight = true;
								base.serie.context.pointerEnter = true;
								base.serie.context.pointerItemDataIndex = k;
								base.serie.context.pointerItemDataDimension = m;
								serieData4.context.highlight = true;
								break;
							}
						}
					}
					if (serieData4.context.highlight)
					{
						serieData4.interact.SetValue(ref needInteract, base.serie.animation.interaction.GetRadius(size));
					}
					else
					{
						serieData4.interact.SetValue(ref needInteract, size);
					}
				}
				break;
			}
			case RadarType.Single:
			{
				needInteract = false;
				for (int i = 0; i < base.serie.data.Count; i++)
				{
					SerieData serieData = base.serie.data[i];
					float sysmbolSize = SerieHelper.GetSysmbolSize(base.serie, serieData, lineSymbolSize);
					if (Vector3.Distance(base.chart.pointerPos, serieData.context.position) < sysmbolSize * 2f)
					{
						base.serie.context.pointerEnter = true;
						base.serie.context.pointerItemDataIndex = i;
						base.serie.context.pointerItemDataDimension = 1;
						serieData.context.highlight = true;
						needInteract = true;
					}
					else
					{
						serieData.context.highlight = false;
					}
				}
				if (base.serie.context.pointerEnter || areaStyle == null)
				{
					break;
				}
				Vector3 center = m_RadarCoord.context.center;
				List<SerieData> data = base.serie.data;
				for (int j = 0; j < data.Count; j++)
				{
					SerieData serieData2 = data[j];
					SerieData serieData3 = ((j >= data.Count - 1) ? data[0] : data[j + 1]);
					if (UGLHelper.IsPointInTriangle(serieData2.context.position, center, serieData3.context.position, base.chart.pointerPos))
					{
						base.serie.context.pointerEnter = true;
						base.serie.context.pointerItemDataIndex = j;
						base.serie.context.pointerItemDataDimension = 1;
						serieData2.context.highlight = true;
						needInteract = true;
						break;
					}
				}
				break;
			}
			}
			if (needInteract)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		private void DrawMutipleRadar(VertexHelper vh)
		{
			if (!base.serie.show)
			{
				return;
			}
			m_RadarCoord = base.chart.GetChartComponent<RadarCoord>(base.serie.radarIndex);
			if (m_RadarCoord == null)
			{
				return;
			}
			base.serie.containerIndex = m_RadarCoord.index;
			base.serie.containterInstanceId = m_RadarCoord.instanceId;
			Vector3 vector = Vector3.zero;
			Vector3 zero = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			int count = m_RadarCoord.indicatorList.Count;
			float num = MathF.PI * 2f / (float)count;
			Vector3 center = m_RadarCoord.context.center;
			base.serie.animation.InitProgress(0f, 1f);
			if (!base.serie.show || base.serie.animation.HasFadeOut())
			{
				return;
			}
			float currRate = base.serie.animation.GetCurrRate();
			bool flag = false;
			bool interacting = false;
			SerieHelper.GetAllMinMaxData(base.serie, m_RadarCoord.ceilRate);
			float num2 = m_RadarCoord.startAngle * MathF.PI / 180f;
			float interactionDuration = base.serie.animation.GetInteractionDuration();
			for (int i = 0; i < base.serie.data.Count; i++)
			{
				SerieData serieData = base.serie.data[i];
				_ = serieData.name;
				if (!serieData.show)
				{
					continue;
				}
				SerieState serieState = SerieHelper.GetSerieState(base.serie, serieData, defaultSerieState: true);
				LineStyle lineStyle = SerieHelper.GetLineStyle(base.serie, serieData);
				SerieSymbol serieSymbol = SerieHelper.GetSerieSymbol(base.serie, serieData, serieState);
				int index = (base.serie.colorByData ? base.chart.GetLegendRealShowNameIndex(serieData.legendName) : base.serie.context.colorIndex);
				Color32 color;
				Color32 toColor;
				bool areaColor = SerieHelper.GetAreaColor(out color, out toColor, base.serie, serieData, base.chart.theme, index);
				Color32 lineColor = SerieHelper.GetLineColor(base.serie, serieData, base.chart.theme, index);
				float width = lineStyle.GetWidth(base.chart.theme.serie.lineWidth);
				int count2 = m_RadarCoord.indicatorList.Count;
				serieData.context.dataPoints.Clear();
				for (int j = 0; j < count2 && j < serieData.data.Count; j++)
				{
					double min = m_RadarCoord.GetIndicatorMin(j);
					double max = m_RadarCoord.GetIndicatorMax(j);
					double currData = serieData.GetCurrData(j, base.serie.animation);
					if (serieData.IsDataChanged())
					{
						flag = true;
					}
					if (max == 0.0)
					{
						if (base.serie.data.Count > 1)
						{
							SerieHelper.GetMinMaxData(base.serie, j, out min, out max);
							min = ChartHelper.GetMinDivisibleValue(min, 0.0);
							max = ChartHelper.GetMaxDivisibleValue(max, 0.0);
							if (min > 0.0)
							{
								min = 0.0;
							}
						}
						else
						{
							max = base.serie.context.dataMax;
						}
					}
					float num3 = (float)((double)m_RadarCoord.context.dataRadius * (currData - min) / (max - min));
					float f = num2 + ((float)j + ((m_RadarCoord.positionType == RadarCoord.PositionType.Between) ? 0.5f : 0f)) * num;
					num3 *= currRate;
					if (j == 0)
					{
						vector = new Vector3(center.x + num3 * Mathf.Sin(f), center.y + num3 * Mathf.Cos(f));
						vector2 = vector;
					}
					else
					{
						zero = new Vector3(center.x + num3 * Mathf.Sin(f), center.y + num3 * Mathf.Cos(f));
						if (areaColor && !base.serie.smooth)
						{
							UGL.DrawTriangle(vh, vector, zero, center, color, color, toColor);
						}
						if (lineStyle.show && !base.serie.smooth)
						{
							ChartDrawer.DrawLineStyle(vh, lineStyle.type, width, vector, zero, lineColor);
						}
						vector = zero;
					}
					serieData.context.dataPoints.Add(vector);
				}
				if (areaColor && !base.serie.smooth)
				{
					UGL.DrawTriangle(vh, vector, vector2, center, color, color, toColor);
				}
				if (lineStyle.show && !base.serie.smooth)
				{
					ChartDrawer.DrawLineStyle(vh, lineStyle.type, width, vector, vector2, lineColor);
				}
				if (base.serie.smooth)
				{
					UGL.DrawCurves(vh, serieData.context.dataPoints, width, lineColor, base.chart.settings.lineSmoothStyle, base.chart.settings.lineSmoothness, UGL.Direction.Random, float.NaN, closed: true);
				}
				if (!serieSymbol.show || serieSymbol.type == SymbolType.None)
				{
					continue;
				}
				float border = 0f;
				float[] cornerRadius = null;
				for (int k = 0; k < serieData.context.dataPoints.Count; k++)
				{
					Vector3 pos = serieData.context.dataPoints[k];
					float value = 0f;
					if (!serieData.interact.TryGetValue(ref value, ref interacting, interactionDuration))
					{
						value = SerieHelper.GetSysmbolSize(base.serie, serieData, base.chart.theme.serie.lineSymbolSize, serieState);
						serieData.interact.SetValue(ref interacting, value);
						value = base.serie.animation.GetSysmbolSize(value);
					}
					SerieHelper.GetItemColor(out var color2, out var toColor2, out var backgroundColor, base.serie, serieData, base.chart.theme, index, serieState);
					SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, base.serie, serieData, base.chart.theme, serieState);
					base.chart.DrawSymbol(vh, serieSymbol.type, value, border, pos, color2, toColor2, backgroundColor, borderColor, serieSymbol.gap, cornerRadius);
				}
			}
			if (!base.serie.animation.IsFinish())
			{
				base.serie.animation.CheckProgress(1.0);
				base.chart.RefreshPainter(base.serie);
			}
			if (flag || interacting)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		private void DrawSingleRadar(VertexHelper vh)
		{
			m_RadarCoord = base.chart.GetChartComponent<RadarCoord>(base.serie.radarIndex);
			if (m_RadarCoord == null)
			{
				return;
			}
			int count = m_RadarCoord.indicatorList.Count;
			float num = MathF.PI * 2f / (float)count;
			Vector3 center = m_RadarCoord.context.center;
			base.serie.animation.InitProgress(0f, 1f);
			if (!base.serie.show || base.serie.animation.HasFadeOut())
			{
				return;
			}
			Vector3 vector = Vector3.zero;
			Vector3 zero = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Color32 color = ColorUtil.clearColor32;
			Color32 color2 = ColorUtil.clearColor32;
			float currRate = base.serie.animation.GetCurrRate();
			bool flag = false;
			int startShowIndex = GetStartShowIndex(base.serie);
			int endShowIndex = GetEndShowIndex(base.serie);
			float num2 = m_RadarCoord.startAngle * MathF.PI / 180f;
			SerieHelper.UpdateMinMaxData(base.serie, 1, m_RadarCoord.ceilRate);
			for (int i = 0; i < base.serie.data.Count; i++)
			{
				SerieData serieData = base.serie.data[i];
				_ = serieData.name;
				if (!serieData.show)
				{
					serieData.context.labelPosition = Vector3.zero;
					continue;
				}
				LineStyle lineStyle = SerieHelper.GetLineStyle(base.serie, serieData);
				int num3 = (base.serie.colorByData ? i : base.serie.context.colorIndex);
				Color32 color3;
				Color32 toColor;
				bool areaColor = SerieHelper.GetAreaColor(out color3, out toColor, base.serie, serieData, base.chart.theme, num3 - 1);
				Color32 color4 = SerieHelper.GetLineColor(base.serie, serieData, base.chart.theme, num3);
				_ = m_RadarCoord.indicatorList.Count;
				int index = serieData.index;
				Vector3 center2 = m_RadarCoord.context.center;
				double num4 = m_RadarCoord.GetIndicatorMax(index);
				double currData = serieData.GetCurrData(1, base.serie.animation);
				if (serieData.IsDataChanged())
				{
					flag = true;
				}
				if (num4 == 0.0)
				{
					num4 = base.serie.context.dataMax;
				}
				if (!m_RadarCoord.IsInIndicatorRange(i, serieData.GetData(1)))
				{
					color4 = m_RadarCoord.outRangeColor;
				}
				float num5 = (float)((num4 < 0.0) ? ((double)m_RadarCoord.context.dataRadius - (double)m_RadarCoord.context.dataRadius * currData / num4) : ((double)m_RadarCoord.context.dataRadius * currData / num4));
				float f = num2 + ((float)index + ((m_RadarCoord.positionType == RadarCoord.PositionType.Between) ? 0.5f : 0f)) * num;
				num5 *= currRate;
				if (index == startShowIndex)
				{
					vector = new Vector3(center2.x + num5 * Mathf.Sin(f), center2.y + num5 * Mathf.Cos(f));
					vector2 = vector;
					color = color4;
					color2 = color4;
				}
				else
				{
					zero = new Vector3(center2.x + num5 * Mathf.Sin(f), center2.y + num5 * Mathf.Cos(f));
					if (areaColor && !base.serie.smooth)
					{
						UGL.DrawTriangle(vh, vector, zero, center2, color3, color3, toColor);
					}
					if (lineStyle.show && !base.serie.smooth)
					{
						if (m_RadarCoord.connectCenter)
						{
							ChartDrawer.DrawLineStyle(vh, lineStyle, vector, center, base.chart.theme.serie.lineWidth, LineStyle.Type.Solid, color, color);
						}
						ChartDrawer.DrawLineStyle(vh, lineStyle, vector, zero, base.chart.theme.serie.lineWidth, LineStyle.Type.Solid, m_RadarCoord.lineGradient ? color : color4, color4);
					}
					vector = zero;
					color = color4;
				}
				base.serie.context.dataPoints.Add(vector);
				base.serie.context.dataIndexs.Add(serieData.index);
				serieData.context.position = vector;
				serieData.context.labelPosition = vector;
				if (areaColor && i == endShowIndex && !base.serie.smooth)
				{
					SerieHelper.GetAreaColor(out color3, out toColor, base.serie, serieData, base.chart.theme, num3);
					UGL.DrawTriangle(vh, vector, vector2, center, color3, color3, toColor);
				}
				if (lineStyle.show && i == endShowIndex && !base.serie.smooth)
				{
					if (m_RadarCoord.connectCenter)
					{
						ChartDrawer.DrawLineStyle(vh, lineStyle, vector, center, base.chart.theme.serie.lineWidth, LineStyle.Type.Solid, color, color);
					}
					ChartDrawer.DrawLineStyle(vh, lineStyle, vector, vector2, base.chart.theme.serie.lineWidth, LineStyle.Type.Solid, color4, m_RadarCoord.lineGradient ? color2 : color4);
				}
			}
			if (base.serie.smooth)
			{
				float width = base.serie.lineStyle.GetWidth(base.chart.theme.serie.lineWidth);
				Color32 lineColor = SerieHelper.GetLineColor(base.serie, null, base.chart.theme, base.serie.context.colorIndex);
				UGL.DrawCurves(vh, base.serie.context.dataPoints, width, lineColor, base.chart.settings.lineSmoothStyle, base.chart.settings.lineSmoothness, UGL.Direction.Random, float.NaN, closed: true);
			}
			if (base.serie.symbol.show && base.serie.symbol.type != SymbolType.None)
			{
				float border = 0f;
				float[] cornerRadius = null;
				for (int j = 0; j < base.serie.data.Count; j++)
				{
					SerieData serieData2 = base.serie.data[j];
					if (serieData2.show)
					{
						SerieState serieState = SerieHelper.GetSerieState(base.serie, serieData2);
						float sysmbolSize = SerieHelper.GetSysmbolSize(base.serie, serieData2, base.chart.theme.serie.lineSymbolSize, serieState);
						int index2 = (base.serie.colorByData ? serieData2.index : base.serie.context.colorIndex);
						SerieHelper.GetItemColor(out var color5, out var toColor2, out var backgroundColor, base.serie, serieData2, base.chart.theme, index2, serieState);
						SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, base.serie, serieData2, base.chart.theme, serieState);
						if (!m_RadarCoord.IsInIndicatorRange(j, serieData2.GetData(1)))
						{
							color5 = m_RadarCoord.outRangeColor;
							toColor2 = m_RadarCoord.outRangeColor;
						}
						base.chart.DrawSymbol(vh, base.serie.symbol.type, sysmbolSize, border, serieData2.context.labelPosition, color5, toColor2, backgroundColor, borderColor, base.serie.symbol.gap, cornerRadius);
					}
				}
			}
			if (!base.serie.animation.IsFinish())
			{
				base.serie.animation.CheckProgress(1.0);
				base.chart.RefreshPainter(base.serie);
			}
			if (flag)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		private int GetStartShowIndex(Serie serie)
		{
			for (int i = 0; i < serie.dataCount; i++)
			{
				if (serie.data[i].show)
				{
					return i;
				}
			}
			return 0;
		}

		private int GetEndShowIndex(Serie serie)
		{
			for (int num = serie.dataCount - 1; num >= 0; num--)
			{
				if (serie.data[num].show)
				{
					return num;
				}
			}
			return 0;
		}
	}
}
