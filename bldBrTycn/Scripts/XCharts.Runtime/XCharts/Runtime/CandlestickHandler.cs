using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class CandlestickHandler : SerieHandler<Candlestick>
	{
		public override void DrawSerie(VertexHelper vh)
		{
			DrawCandlestickSerie(vh, base.serie);
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			if (dataIndex < 0)
			{
				dataIndex = base.serie.context.pointerItemDataIndex;
			}
			if (dataIndex < 0)
			{
				return;
			}
			SerieData serieData = base.serie.GetSerieData(dataIndex);
			if (serieData != null)
			{
				title = category;
				Color32 markColor = base.chart.GetMarkColor(base.serie, serieData);
				string itemMarker = SerieHelper.GetItemMarker(base.serie, serieData, marker);
				string itemFormatter2 = SerieHelper.GetItemFormatter(base.serie, serieData, itemFormatter);
				string numericFormatter2 = SerieHelper.GetNumericFormatter(base.serie, serieData, numericFormatter);
				SerieParams param = base.serie.context.param;
				param.serieName = base.serie.serieName;
				param.serieIndex = base.serie.index;
				param.category = category;
				param.dimension = 1;
				param.serieData = serieData;
				param.dataCount = base.serie.dataCount;
				param.value = 0.0;
				param.total = 0.0;
				param.color = markColor;
				param.marker = itemMarker;
				param.itemFormatter = itemFormatter2;
				param.numericFormatter = numericFormatter2;
				param.columns.Clear();
				param.columns.Add(param.marker);
				param.columns.Add(base.serie.serieName);
				param.columns.Add(string.Empty);
				paramList.Add(param);
				for (int i = 1; i < 5; i++)
				{
					param = new SerieParams();
					param.serieName = base.serie.serieName;
					param.serieIndex = base.serie.index;
					param.dimension = i;
					param.serieData = serieData;
					param.dataCount = base.serie.dataCount;
					param.value = serieData.GetData(i);
					param.total = SerieHelper.GetMaxData(base.serie, i);
					param.color = markColor;
					param.marker = itemMarker;
					param.itemFormatter = itemFormatter2;
					param.numericFormatter = numericFormatter2;
					param.columns.Clear();
					param.columns.Add(param.marker);
					param.columns.Add(XCSettings.lang.GetCandlestickDimensionName(i - 1));
					param.columns.Add(ChartCached.NumberToStr(param.value, param.numericFormatter));
					paramList.Add(param);
				}
			}
		}

		private void DrawCandlestickSerie(VertexHelper vh, Candlestick serie)
		{
			if (!serie.show || serie.animation.HasFadeOut() || !base.chart.TryGetChartComponent<XAxis>(out var component, serie.xAxisIndex) || !base.chart.TryGetChartComponent<YAxis>(out var component2, serie.yAxisIndex) || !base.chart.TryGetChartComponent<GridCoord>(out var component3, component.gridIndex))
			{
				return;
			}
			ThemeStyle theme = base.chart.theme;
			DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(component);
			List<SerieData> dataList = serie.GetDataList(dataZoomOfAxis);
			float dataWidth = AxisHelper.GetDataWidth(component, component3.context.width, dataList.Count, dataZoomOfAxis);
			float barWidth = serie.GetBarWidth(dataWidth);
			float num = (dataWidth - barWidth) / 2f;
			int num2 = ((serie.maxShow <= 0) ? dataList.Count : ((serie.maxShow > dataList.Count) ? dataList.Count : serie.maxShow));
			bool flag = false;
			float changeDuration = serie.animation.GetChangeDuration();
			float additionDuration = serie.animation.GetAdditionDuration();
			bool unscaledTime = serie.animation.unscaledTime;
			double minValue = component2.context.minValue;
			double maxValue = component2.context.maxValue;
			bool horizontal = false;
			serie.containerIndex = component3.index;
			serie.containterInstanceId = component3.instanceId;
			bool flag2 = component3.context.width / (float)(num2 - serie.minShow) < 0.6f;
			for (int i = serie.minShow; i < num2; i++)
			{
				SerieData serieData = dataList[i];
				if (!serieData.show || serie.IsIgnoreValue(serieData))
				{
					serie.context.dataPoints.Add(Vector3.zero);
					serie.context.dataIndexs.Add(serieData.index);
					continue;
				}
				SerieState serieState = SerieHelper.GetSerieState(serie, serieData);
				ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData, serieState);
				int num3 = ((serieData.data.Count > 4) ? 1 : 0);
				double currData = serieData.GetCurrData(num3, additionDuration, changeDuration, component2.inverse, minValue, maxValue, unscaledTime);
				double currData2 = serieData.GetCurrData(num3 + 1, additionDuration, changeDuration, component2.inverse, minValue, maxValue, unscaledTime);
				double currData3 = serieData.GetCurrData(num3 + 2, additionDuration, changeDuration, component2.inverse, minValue, maxValue, unscaledTime);
				double currData4 = serieData.GetCurrData(num3 + 3, additionDuration, changeDuration, component2.inverse, minValue, maxValue, unscaledTime);
				bool flag3 = (component2.inverse ? (currData2 < currData) : (currData2 > currData));
				float num4 = ((currData == 0.0) ? 0f : ((itemStyle.runtimeBorderWidth == 0f) ? theme.serie.candlestickBorderWidth : itemStyle.runtimeBorderWidth));
				if (serieData.IsDataChanged())
				{
					flag = true;
				}
				float num5 = component3.context.x + (float)i * dataWidth;
				float num6 = component3.context.y + component2.context.offset;
				if (!component.boundaryGap)
				{
					num5 -= dataWidth / 2f;
				}
				float num7 = num6;
				float num8 = 0f;
				double num9 = maxValue - minValue;
				double num10 = ((minValue > 0.0) ? minValue : 0.0);
				if (num9 != 0.0)
				{
					num8 = (float)((currData2 - currData) / num9 * (double)component3.context.height);
					num7 += (float)((currData - num10) / num9 * (double)component3.context.height);
				}
				serieData.context.stackHeight = num8;
				float num11 = AnimationStyleHelper.CheckDataAnimation(base.chart, serie, i, num8);
				Vector3 p = new Vector3(num5 + num + num4, num7 + num4);
				Vector3 p2 = new Vector3(num5 + num + num4, num7 + num11 - num4);
				Vector3 p3 = new Vector3(num5 + num + barWidth - num4, num7 + num11 - num4);
				Vector3 p4 = new Vector3(num5 + num + barWidth - num4, num7 + num4);
				Vector3 vector = new Vector3(num5 + num + barWidth / 2f, num7 + num11 - num4);
				if (serie.clip)
				{
					p = base.chart.ClampInGrid(component3, p);
					p2 = base.chart.ClampInGrid(component3, p2);
					p3 = base.chart.ClampInGrid(component3, p3);
					p4 = base.chart.ClampInGrid(component3, p4);
					vector = base.chart.ClampInGrid(component3, vector);
				}
				serie.context.dataPoints.Add(vector);
				serie.context.dataIndexs.Add(serieData.index);
				Color32 color = (flag3 ? itemStyle.GetColor(theme.serie.candlestickColor) : itemStyle.GetColor0(theme.serie.candlestickColor0));
				Color32 color2 = (flag3 ? itemStyle.GetBorderColor(theme.serie.candlestickBorderColor) : itemStyle.GetBorderColor0(theme.serie.candlestickBorderColor0));
				float num12 = Mathf.Abs(p3.x - p.x);
				float num13 = Mathf.Abs(p2.y - p4.y);
				Vector3 center = new Vector3((p.x + p3.x) / 2f, (p2.y + p4.y) / 2f);
				Vector3 vector2 = new Vector3(center.x, num6 + (float)((currData3 - num10) / num9 * (double)component3.context.height));
				Vector3 endPoint = new Vector3(center.x, num6 + (float)((currData4 - num10) / num9 * (double)component3.context.height));
				Vector3 startPoint = new Vector3(center.x, p4.y);
				Vector3 vector3 = new Vector3(center.x, p3.y);
				if (flag2)
				{
					UGL.DrawLine(vh, vector2, endPoint, num4, color2);
					continue;
				}
				if (barWidth > 2f * num4)
				{
					if (num12 > 0f && num13 > 0f)
					{
						if (itemStyle.IsNeedCorner())
						{
							UGL.DrawRoundRectangle(vh, center, num12, num13, color, color, 0f, itemStyle.cornerRadius, horizontal, 0.5f);
						}
						else
						{
							base.chart.DrawClipPolygon(vh, ref p4, ref p, ref p2, ref p3, color, color, serie.clip, component3);
						}
						UGL.DrawBorder(vh, center, num12, num13, 2f * num4, color2, 0f, itemStyle.cornerRadius, horizontal, 0.5f);
					}
				}
				else
				{
					UGL.DrawLine(vh, startPoint, vector3, Mathf.Max(num4, barWidth / 2f), color2);
				}
				if (flag3)
				{
					UGL.DrawLine(vh, startPoint, vector2, num4, color2);
					UGL.DrawLine(vh, vector3, endPoint, num4, color2);
				}
				else
				{
					UGL.DrawLine(vh, vector3, vector2, num4, color2);
					UGL.DrawLine(vh, startPoint, endPoint, num4, color2);
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress();
			}
			if (flag)
			{
				base.chart.RefreshPainter(serie);
			}
		}
	}
}
