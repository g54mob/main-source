using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Preserve]
	internal class BaseScatterHandler<T> : SerieHandler<T> where T : BaseScatter
	{
		private GridCoord m_Grid;

		public override void Update()
		{
			base.Update();
		}

		public override void UpdateTooltipSerieParams(int dataIndex, bool showCategory, string category, string marker, string itemFormatter, string numericFormatter, string ignoreDataDefaultContent, ref List<SerieParams> paramList, ref string title)
		{
			dataIndex = base.serie.context.pointerItemDataIndex;
			if (dataIndex < 0)
			{
				return;
			}
			SerieData serieData = base.serie.GetSerieData(dataIndex);
			if (serieData != null)
			{
				title = base.serie.serieName;
				SerieParams param = base.serie.context.param;
				param.serieName = base.serie.serieName;
				param.serieIndex = base.serie.index;
				param.category = category;
				param.dimension = 1;
				param.dataCount = base.serie.dataCount;
				param.serieData = serieData;
				param.color = base.chart.GetMarkColor(base.serie, serieData);
				param.marker = SerieHelper.GetItemMarker(base.serie, serieData, marker);
				param.itemFormatter = SerieHelper.GetItemFormatter(base.serie, serieData, itemFormatter);
				param.numericFormatter = SerieHelper.GetNumericFormatter(base.serie, serieData, numericFormatter);
				param.columns.Clear();
				param.columns.Add(param.marker);
				if (!string.IsNullOrEmpty(serieData.name))
				{
					param.columns.Add(serieData.name);
				}
				param.columns.Add(ChartCached.NumberToStr(serieData.GetData(1), param.numericFormatter));
				paramList.Add(param);
			}
		}

		public override void DrawSerie(VertexHelper vh)
		{
			if (base.serie.IsUseCoord<SingleAxisCoord>())
			{
				DrawSingAxisScatterSerie(vh, base.serie);
			}
			else if (base.serie.IsUseCoord<GridCoord>())
			{
				DrawScatterSerie(vh, base.serie);
			}
		}

		public override void UpdateSerieContext()
		{
			bool flag = m_LegendEnter || (base.chart.isPointerInChart && (m_Grid == null || m_Grid.IsPointerEnter()));
			bool flag2 = false;
			if (!flag)
			{
				if (m_LastCheckContextFlag == flag)
				{
					return;
				}
				flag2 = true;
			}
			m_LastCheckContextFlag = flag;
			base.serie.context.pointerItemDataIndex = -1;
			base.serie.context.pointerEnter = false;
			float scatterSymbolSize = base.chart.theme.serie.scatterSymbolSize;
			bool needInteract = false;
			for (int num = base.serie.dataCount - 1; num >= 0; num--)
			{
				SerieData serieData = base.serie.data[num];
				float sysmbolSize = SerieHelper.GetSysmbolSize(base.serie, serieData, scatterSymbolSize);
				if (m_LegendEnter || (!flag2 && Vector3.Distance(serieData.context.position, base.chart.pointerPos) <= sysmbolSize))
				{
					base.serie.context.pointerItemDataIndex = num;
					base.serie.context.pointerEnter = true;
					serieData.context.highlight = true;
				}
				else
				{
					serieData.context.highlight = false;
				}
				SerieState serieState = SerieHelper.GetSerieState(base.serie, serieData, defaultSerieState: true);
				sysmbolSize = SerieHelper.GetSysmbolSize(base.serie, serieData, scatterSymbolSize, serieState);
				serieData.interact.SetValue(ref needInteract, sysmbolSize);
			}
			if (needInteract)
			{
				base.chart.RefreshPainter(base.serie);
			}
		}

		protected virtual void DrawScatterSerie(VertexHelper vh, BaseScatter serie)
		{
			if (serie.animation.HasFadeOut() || !serie.show || !base.chart.TryGetChartComponent<XAxis>(out var component, serie.xAxisIndex) || !base.chart.TryGetChartComponent<YAxis>(out var component2, serie.yAxisIndex) || !base.chart.TryGetChartComponent<GridCoord>(out m_Grid, component.gridIndex))
			{
				return;
			}
			base.chart.GetDataZoomOfSerie(serie, out var xDataZoom, out var _);
			ThemeStyle theme = base.chart.theme;
			int dataCount = ((serie.maxShow <= 0) ? serie.dataCount : ((serie.maxShow > serie.dataCount) ? serie.dataCount : serie.maxShow));
			serie.animation.InitProgress(0f, 1f);
			float currRate = serie.animation.GetCurrRate();
			float changeDuration = serie.animation.GetChangeDuration();
			float interactionDuration = serie.animation.GetInteractionDuration();
			bool flag = serie.animation.IsFadeOut();
			bool unscaledTime = serie.animation.unscaledTime;
			bool flag2 = false;
			bool interacting = false;
			List<SerieData> dataList = serie.GetDataList(xDataZoom);
			bool flag3 = serie is EffectScatter;
			int colorIndex = serie.context.colorIndex;
			serie.containerIndex = m_Grid.index;
			serie.containterInstanceId = m_Grid.instanceId;
			float border = 0f;
			float[] cornerRadius = null;
			foreach (SerieData item in dataList)
			{
				SerieSymbol serieSymbol = SerieHelper.GetSerieSymbol(serie, item);
				if (!serieSymbol.ShowSymbol(item.index, dataCount))
				{
					continue;
				}
				SerieState serieState = SerieHelper.GetSerieState(serie, item, defaultSerieState: true);
				SerieHelper.GetItemColor(out var color, out var toColor, out var backgroundColor, serie, item, base.chart.theme, colorIndex, serieState);
				SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, serie, item, base.chart.theme, serieState);
				double currData = item.GetCurrData(0, 0f, flag ? 0f : changeDuration, unscaledTime, component.inverse);
				double currData2 = item.GetCurrData(1, 0f, flag ? 0f : changeDuration, unscaledTime, component2.inverse);
				if (item.IsDataChanged())
				{
					flag2 = true;
				}
				float num = m_Grid.context.x + component.axisLine.GetWidth(theme.axis.lineWidth);
				float num2 = m_Grid.context.y + component2.axisLine.GetWidth(theme.axis.lineWidth);
				float dataHig = GetDataHig(component, currData, m_Grid.context.width);
				float dataHig2 = GetDataHig(component2, currData2, m_Grid.context.height);
				Vector3 vector = new Vector3(num + dataHig, num2 + dataHig2);
				if (!m_Grid.Contains(vector))
				{
					continue;
				}
				serie.context.dataPoints.Add(vector);
				serie.context.dataIndexs.Add(item.index);
				item.context.position = vector;
				_ = item.data;
				float value = 0f;
				if (flag || !item.interact.TryGetValue(ref value, ref interacting, interactionDuration))
				{
					value = SerieHelper.GetSysmbolSize(serie, item, base.chart.theme.serie.scatterSymbolSize, serieState);
					if (!flag)
					{
						item.interact.SetValue(ref interacting, value, previousValueZero: true);
						item.interact.TryGetValue(ref value, ref interacting, interactionDuration);
					}
				}
				value *= currRate;
				if (flag3)
				{
					for (int i = 0; i < serieSymbol.animationSize.Count; i++)
					{
						float num3 = serieSymbol.animationSize[i];
						color.a = (byte)(255f * (value - num3) / value);
						base.chart.DrawSymbol(vh, serieSymbol.type, num3, border, vector, color, toColor, backgroundColor, borderColor, serieSymbol.gap, cornerRadius);
					}
					base.chart.RefreshPainter(serie);
				}
				else
				{
					base.chart.DrawSymbol(vh, serieSymbol.type, value, border, vector, color, toColor, backgroundColor, borderColor, serieSymbol.gap, cornerRadius);
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress(1.0);
				base.chart.RefreshPainter(serie);
			}
			if (flag2 || interacting)
			{
				base.chart.RefreshPainter(serie);
			}
		}

		protected virtual void DrawSingAxisScatterSerie(VertexHelper vh, BaseScatter serie)
		{
			if (serie.animation.HasFadeOut() || !serie.show)
			{
				return;
			}
			SingleAxis chartComponent = base.chart.GetChartComponent<SingleAxis>(serie.singleAxisIndex);
			if (chartComponent == null)
			{
				return;
			}
			base.chart.GetDataZoomOfSerie(serie, out var xDataZoom, out var _);
			_ = base.chart.theme;
			int dataCount = ((serie.maxShow <= 0) ? serie.dataCount : ((serie.maxShow > serie.dataCount) ? serie.dataCount : serie.maxShow));
			serie.animation.InitProgress(0f, 1f);
			float currRate = serie.animation.GetCurrRate();
			float changeDuration = serie.animation.GetChangeDuration();
			bool unscaledTime = serie.animation.unscaledTime;
			bool flag = false;
			List<SerieData> dataList = serie.GetDataList(xDataZoom);
			bool flag2 = serie is EffectScatter;
			int colorIndex = serie.context.colorIndex;
			serie.containerIndex = chartComponent.index;
			serie.containterInstanceId = chartComponent.instanceId;
			float border = 0f;
			float[] cornerRadius = null;
			foreach (SerieData item in dataList)
			{
				SerieSymbol serieSymbol = SerieHelper.GetSerieSymbol(serie, item);
				if (!serieSymbol.ShowSymbol(item.index, dataCount))
				{
					continue;
				}
				SerieState serieState = SerieHelper.GetSerieState(serie, item, defaultSerieState: true);
				SerieHelper.GetItemColor(out var color, out var toColor, out var backgroundColor, serie, item, base.chart.theme, colorIndex, serieState);
				SerieHelper.GetSymbolInfo(out var borderColor, out border, out cornerRadius, serie, item, base.chart.theme, serieState);
				if (item.IsDataChanged())
				{
					flag = true;
				}
				Vector3 zero = Vector3.zero;
				double currData = item.GetCurrData(0, 0f, changeDuration, unscaledTime, chartComponent.inverse);
				if (chartComponent.orient == Orient.Horizonal)
				{
					float dataHig = GetDataHig(chartComponent, currData, chartComponent.context.width);
					float num = chartComponent.context.height / 2f;
					zero = new Vector3(chartComponent.context.x + dataHig, chartComponent.context.y + num);
				}
				else
				{
					float dataHig2 = GetDataHig(chartComponent, currData, chartComponent.context.width);
					float num2 = chartComponent.context.height / 2f;
					zero = new Vector3(chartComponent.context.x + num2, chartComponent.context.y + dataHig2);
				}
				serie.context.dataPoints.Add(zero);
				serie.context.dataIndexs.Add(item.index);
				item.context.position = zero;
				_ = item.data;
				float sysmbolSize = SerieHelper.GetSysmbolSize(serie, item, base.chart.theme.serie.scatterSymbolSize, serieState);
				sysmbolSize *= currRate;
				if (flag2)
				{
					if (sysmbolSize > 100f)
					{
						sysmbolSize = 100f;
					}
					for (int i = 0; i < serieSymbol.animationSize.Count; i++)
					{
						float num3 = serieSymbol.animationSize[i];
						color.a = (byte)(255f * (sysmbolSize - num3) / sysmbolSize);
						base.chart.DrawSymbol(vh, serieSymbol.type, num3, border, zero, color, toColor, backgroundColor, borderColor, serieSymbol.gap, cornerRadius);
					}
					base.chart.RefreshPainter(serie);
				}
				else
				{
					if (sysmbolSize > 100f)
					{
						sysmbolSize = 100f;
					}
					base.chart.DrawSymbol(vh, serieSymbol.type, sysmbolSize, border, zero, color, toColor, backgroundColor, borderColor, serieSymbol.gap, cornerRadius);
				}
			}
			if (!serie.animation.IsFinish())
			{
				serie.animation.CheckProgress(1.0);
				base.chart.RefreshPainter(serie);
			}
			if (flag)
			{
				base.chart.RefreshPainter(serie);
			}
		}

		private static float GetDataHig(Axis axis, double value, float totalWidth)
		{
			if (axis.IsLog())
			{
				double logMinIndex = axis.GetLogMinIndex();
				return (float)(((double)axis.GetLogValue(value) - logMinIndex) / (double)axis.splitNumber * (double)totalWidth);
			}
			if (axis.IsCategory())
			{
				if (axis.boundaryGap)
				{
					float num = (float)((double)totalWidth / (axis.context.minMaxRange + 1.0));
					return num / 2f + (float)(value - axis.context.minValue) * num;
				}
				return (float)((value - axis.context.minValue) / axis.context.minMaxRange * (double)totalWidth);
			}
			return (float)((value - axis.context.minValue) / axis.context.minMaxRange * (double)totalWidth);
		}
	}
}
