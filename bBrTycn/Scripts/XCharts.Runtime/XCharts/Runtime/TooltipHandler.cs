using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class TooltipHandler : MainComponentHandler<Tooltip>
	{
		private Dictionary<string, ChartLabel> m_IndicatorLabels = new Dictionary<string, ChartLabel>();

		private GameObject m_LabelRoot;

		private ISerieContainer m_PointerContainer;

		public override void InitComponent()
		{
			InitTooltip(base.component);
		}

		public override void Update()
		{
			UpdateTooltip(base.component);
			UpdateTooltipIndicatorLabelText(base.component);
			if (base.component.view != null)
			{
				base.component.view.Update();
			}
		}

		public override void DrawUpper(VertexHelper vh)
		{
			DrawTooltipIndicator(vh, base.component);
		}

		private void InitTooltip(Tooltip tooltip)
		{
			tooltip.painter = base.chart.m_PainterUpper;
			tooltip.refreshComponent = delegate
			{
				string componentObjectName = ChartCached.GetComponentObjectName(tooltip);
				tooltip.gameObject = ChartHelper.AddObject(componentObjectName, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				GameObject gameObject = tooltip.gameObject;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.hideFlags = base.chart.chartHideFlags;
				Transform transform = gameObject.transform;
				ChartHelper.HideAllObject(gameObject.transform);
				tooltip.view = TooltipView.CreateView(tooltip, base.chart.theme, transform);
				tooltip.SetActive(flag: false);
				m_LabelRoot = ChartHelper.AddObject("label", tooltip.gameObject.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				ChartHelper.HideAllObject(m_LabelRoot);
				m_IndicatorLabels.Clear();
				foreach (MainComponent component in base.chart.components)
				{
					if (component is Axis)
					{
						Axis axis = component as Axis;
						TextAnchor alignment = ((component is AngleAxis) ? TextAnchor.MiddleCenter : axis.context.aligment);
						string componentObjectName2 = ChartCached.GetComponentObjectName(axis);
						ChartLabel chartLabel = ChartHelper.AddTooltipIndicatorLabel(base.component, componentObjectName2, m_LabelRoot.transform, base.chart.theme, alignment, axis.indicatorLabel);
						chartLabel.SetActive(flag: false);
						m_IndicatorLabels[componentObjectName2] = chartLabel;
					}
				}
			};
			tooltip.refreshComponent();
		}

		private ChartLabel GetIndicatorLabel(Axis axis)
		{
			if (m_LabelRoot == null)
			{
				return null;
			}
			string componentObjectName = ChartCached.GetComponentObjectName(axis);
			if (m_IndicatorLabels.ContainsKey(componentObjectName))
			{
				return m_IndicatorLabels[componentObjectName];
			}
			ChartLabel chartLabel = ChartHelper.AddTooltipIndicatorLabel(base.component, componentObjectName, m_LabelRoot.transform, base.chart.theme, TextAnchor.MiddleCenter, axis.indicatorLabel);
			m_IndicatorLabels[componentObjectName] = chartLabel;
			return chartLabel;
		}

		private void UpdateTooltip(Tooltip tooltip)
		{
			if (tooltip.trigger == Tooltip.Trigger.None)
			{
				return;
			}
			if (!base.chart.isPointerInChart || !tooltip.show)
			{
				if (tooltip.IsActive())
				{
					tooltip.ClearValue();
					tooltip.SetActive(flag: false);
				}
				return;
			}
			bool flag = false;
			for (int num = base.chart.series.Count - 1; num >= 0; num--)
			{
				Serie serie = base.chart.series[num];
				if (!(serie is INeedSerieContainer) && SetSerieTooltip(tooltip, serie))
				{
					flag = true;
					base.chart.RefreshTopPainter();
					return;
				}
			}
			List<Serie> list = ListPool<Serie>.Get();
			UpdatePointerContainerAndSeriesAndTooltip(tooltip, ref list);
			if (list.Count > 0 && SetSerieTooltip(tooltip, list))
			{
				flag = true;
			}
			ListPool<Serie>.Release(list);
			if (!flag)
			{
				if (tooltip.context.type == Tooltip.Type.Corss && m_PointerContainer != null && m_PointerContainer.IsPointerEnter())
				{
					tooltip.SetActive(flag: true);
					tooltip.SetContentActive(flag: false);
				}
				else
				{
					tooltip.SetActive(flag: false);
				}
			}
			else
			{
				base.chart.RefreshUpperPainter();
			}
		}

		private void UpdateTooltipTypeAndTrigger(Tooltip tootip)
		{
		}

		private void UpdateTooltipIndicatorLabelText(Tooltip tooltip)
		{
			if (!tooltip.show || tooltip.context.type == Tooltip.Type.None || m_PointerContainer == null || tooltip.context.type != Tooltip.Type.Corss)
			{
				return;
			}
			if (m_PointerContainer is GridCoord)
			{
				GridCoord gridCoord = m_PointerContainer as GridCoord;
				ChartHelper.HideAllObject(m_LabelRoot);
				{
					foreach (MainComponent component in base.chart.components)
					{
						if (component is XAxis || component is YAxis)
						{
							Axis axis = component as Axis;
							if (axis.gridIndex == gridCoord.index)
							{
								ChartLabel indicatorLabel = GetIndicatorLabel(axis);
								SetTooltipIndicatorLabel(tooltip, axis, indicatorLabel);
							}
						}
					}
					return;
				}
			}
			if (!(m_PointerContainer is PolarCoord))
			{
				return;
			}
			PolarCoord polarCoord = m_PointerContainer as PolarCoord;
			ChartHelper.HideAllObject(m_LabelRoot);
			foreach (MainComponent component2 in base.chart.components)
			{
				if (component2 is AngleAxis || component2 is RadiusAxis)
				{
					Axis axis2 = component2 as Axis;
					if (axis2.polarIndex == polarCoord.index)
					{
						ChartLabel indicatorLabel2 = GetIndicatorLabel(axis2);
						SetTooltipIndicatorLabel(tooltip, axis2, indicatorLabel2);
					}
				}
			}
		}

		private void SetTooltipIndicatorLabel(Tooltip tooltip, Axis axis, ChartLabel label)
		{
			if (!(label == null) && !double.IsNaN(axis.context.pointerValue))
			{
				label.SetActive(flag: true);
				label.SetTextActive(flag: true);
				label.SetPosition(axis.context.pointerLabelPosition + axis.indicatorLabel.offset);
				if (axis.IsCategory())
				{
					int num = (int)axis.context.pointerValue;
					string data = axis.GetData(num);
					label.SetText(axis.indicatorLabel.GetFormatterContent(num, data));
				}
				else if (axis.IsTime())
				{
					label.SetText(axis.indicatorLabel.GetFormatterDateTime(0, axis.context.pointerValue, axis.context.minValue, axis.context.maxValue));
				}
				else
				{
					label.SetText(axis.indicatorLabel.GetFormatterContent(0, axis.context.pointerValue, axis.context.minValue, axis.context.maxValue, axis.IsLog()));
				}
				Color color = axis.axisLabel.textStyle.GetColor(base.chart.theme.axis.textColor);
				if (ChartHelper.IsClearColor(axis.indicatorLabel.background.color))
				{
					label.color = color;
				}
				else
				{
					label.color = axis.indicatorLabel.background.color;
				}
				if (ChartHelper.IsClearColor(axis.indicatorLabel.textStyle.color))
				{
					label.SetTextColor(Color.white);
				}
				else
				{
					label.SetTextColor(axis.indicatorLabel.textStyle.color);
				}
			}
		}

		private void UpdatePointerContainerAndSeriesAndTooltip(Tooltip tooltip, ref List<Serie> list)
		{
			list.Clear();
			m_PointerContainer = null;
			bool flag = false;
			for (int num = base.chart.components.Count - 1; num >= 0; num--)
			{
				MainComponent mainComponent = base.chart.components[num];
				if (mainComponent is ISerieContainer)
				{
					ISerieContainer serieContainer = mainComponent as ISerieContainer;
					if (serieContainer.IsPointerEnter())
					{
						foreach (Serie item in base.chart.series)
						{
							if (item is INeedSerieContainer && (item as INeedSerieContainer).containterInstanceId == mainComponent.instanceId && !item.placeHolder)
							{
								if (!flag)
								{
									flag = true;
									tooltip.context.type = ((tooltip.type == Tooltip.Type.Auto) ? item.context.tooltipType : tooltip.type);
									tooltip.context.trigger = ((tooltip.trigger == Tooltip.Trigger.Auto) ? item.context.tooltipTrigger : tooltip.trigger);
								}
								bool flag2 = tooltip.IsTriggerAxis();
								if (serieContainer is GridCoord)
								{
									XAxis chartComponent = base.chart.GetChartComponent<XAxis>(item.xAxisIndex);
									YAxis chartComponent2 = base.chart.GetChartComponent<YAxis>(item.yAxisIndex);
									UpdateAxisPointerDataIndex(item, chartComponent, chartComponent2, serieContainer as GridCoord, flag2);
								}
								else if (serieContainer is PolarCoord)
								{
									AngleAxis angleAxis = ComponentHelper.GetAngleAxis(base.chart.components, serieContainer.index);
									tooltip.context.angle = (float)angleAxis.context.pointerValue;
								}
								list.Add(item);
								if (!flag2)
								{
									base.chart.RefreshTopPainter();
								}
							}
						}
						m_PointerContainer = serieContainer;
					}
				}
			}
		}

		private void UpdateAxisPointerDataIndex(Serie serie, XAxis xAxis, YAxis yAxis, GridCoord grid, bool isTriggerAxis)
		{
			serie.context.pointerAxisDataIndexs.Clear();
			if (xAxis == null || yAxis == null)
			{
				return;
			}
			if (serie is Heatmap)
			{
				GetSerieDataByXYAxis(serie, xAxis, yAxis);
			}
			else if (yAxis.IsCategory())
			{
				if (isTriggerAxis)
				{
					serie.context.pointerEnter = true;
					serie.context.pointerAxisDataIndexs.Add((int)yAxis.context.pointerValue);
					yAxis.context.axisTooltipValue = yAxis.context.pointerValue;
				}
			}
			else if (yAxis.IsTime())
			{
				serie.context.pointerEnter = true;
				if (isTriggerAxis)
				{
					GetSerieDataIndexByAxis(serie, yAxis, grid);
				}
				else
				{
					GetSerieDataIndexByItem(serie, yAxis, grid);
				}
			}
			else if (xAxis.IsCategory())
			{
				if (isTriggerAxis)
				{
					int num = serie.context.dataZoomStartIndex + (int)xAxis.context.pointerValue;
					serie.context.pointerEnter = true;
					serie.context.pointerAxisDataIndexs.Add(num);
					serie.context.pointerItemDataIndex = num;
					xAxis.context.axisTooltipValue = xAxis.context.pointerValue;
				}
			}
			else
			{
				serie.context.pointerEnter = true;
				if (isTriggerAxis)
				{
					GetSerieDataIndexByAxis(serie, xAxis, grid);
				}
				else
				{
					GetSerieDataIndexByItem(serie, xAxis, grid);
				}
			}
		}

		private void GetSerieDataByXYAxis(Serie serie, Axis xAxis, Axis yAxis)
		{
			int axisValueSplitIndex = AxisHelper.GetAxisValueSplitIndex(xAxis, xAxis.context.pointerValue);
			int axisValueSplitIndex2 = AxisHelper.GetAxisValueSplitIndex(yAxis, yAxis.context.pointerValue);
			serie.context.pointerItemDataIndex = -1;
			if (serie is Heatmap && (serie as Heatmap).heatmapType == HeatmapType.Count)
			{
				serie.context.pointerItemDataIndex = HeatmapHandler.GetGridKey(axisValueSplitIndex, axisValueSplitIndex2);
				return;
			}
			foreach (SerieData datum in serie.data)
			{
				int axisValueSplitIndex3 = AxisHelper.GetAxisValueSplitIndex(xAxis, datum.GetData(0));
				int axisValueSplitIndex4 = AxisHelper.GetAxisValueSplitIndex(yAxis, datum.GetData(1));
				if (axisValueSplitIndex == axisValueSplitIndex3 && axisValueSplitIndex4 == axisValueSplitIndex2)
				{
					serie.context.pointerItemDataIndex = datum.index;
					break;
				}
			}
		}

		private void GetSerieDataIndexByAxis(Serie serie, Axis axis, GridCoord grid, int dimension = 0)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double pointerValue = axis.context.pointerValue;
			bool num4 = axis.IsTime();
			int dataCount = serie.dataCount;
			_ = base.chart.theme.serie.scatterSymbolSize;
			List<SerieData> list = serie.data;
			if (!num4)
			{
				serie.context.sortedData.Clear();
				for (int i = 0; i < dataCount; i++)
				{
					SerieData item = serie.data[i];
					serie.context.sortedData.Add(item);
				}
				serie.context.sortedData.Sort((SerieData a, SerieData b) => a.GetData(dimension).CompareTo(b.GetData(dimension)));
				list = serie.context.sortedData;
			}
			serie.context.pointerAxisDataIndexs.Clear();
			for (int num5 = 0; num5 < dataCount; num5++)
			{
				SerieData serieData = list[num5];
				num = serieData.GetData(dimension);
				if (num5 == 0 && num5 + 1 < dataCount)
				{
					num3 = list[num5 + 1].GetData(dimension);
					if (pointerValue <= num + (num3 - num) / 2.0)
					{
						serie.context.pointerAxisDataIndexs.Add(serieData.index);
						break;
					}
				}
				else if (num5 == dataCount - 1)
				{
					if (pointerValue > num2 + (num - num2) / 2.0)
					{
						serie.context.pointerAxisDataIndexs.Add(serieData.index);
						break;
					}
				}
				else if (num5 + 1 < dataCount)
				{
					num3 = list[num5 + 1].GetData(dimension);
					if (pointerValue > num - (num - num2) / 2.0 && pointerValue <= num + (num3 - num) / 2.0)
					{
						serie.context.pointerAxisDataIndexs.Add(serieData.index);
						break;
					}
				}
				num2 = num;
			}
			if (serie.context.pointerAxisDataIndexs.Count > 0)
			{
				int num6 = serie.context.pointerAxisDataIndexs[0];
				serie.context.pointerItemDataIndex = num6;
				axis.context.axisTooltipValue = serie.GetSerieData(num6).GetData(dimension);
			}
			else
			{
				serie.context.pointerItemDataIndex = -1;
				axis.context.axisTooltipValue = 0.0;
			}
		}

		private void GetSerieDataIndexByItem(Serie serie, Axis axis, GridCoord grid, int dimension = 0)
		{
			if (serie.context.pointerItemDataIndex >= 0)
			{
				axis.context.axisTooltipValue = serie.GetSerieData(serie.context.pointerItemDataIndex).GetData(dimension);
			}
			else if (base.component.type == Tooltip.Type.Corss)
			{
				axis.context.axisTooltipValue = axis.context.pointerValue;
			}
			else
			{
				axis.context.axisTooltipValue = 0.0;
			}
		}

		private bool SetSerieTooltip(Tooltip tooltip, Serie serie)
		{
			if (serie.context.pointerItemDataIndex < 0)
			{
				return false;
			}
			tooltip.context.type = ((tooltip.type == Tooltip.Type.Auto) ? serie.context.tooltipType : tooltip.type);
			tooltip.context.trigger = ((tooltip.trigger == Tooltip.Trigger.Auto) ? serie.context.tooltipTrigger : tooltip.trigger);
			if (tooltip.context.trigger == Tooltip.Trigger.None)
			{
				return false;
			}
			tooltip.context.data.param.Clear();
			tooltip.context.data.title = serie.serieName;
			tooltip.context.pointer = base.chart.pointerPos;
			serie.handler.UpdateTooltipSerieParams(serie.context.pointerItemDataIndex, showCategory: false, null, tooltip.marker, tooltip.itemFormatter, tooltip.numericFormatter, tooltip.ignoreDataDefaultContent, ref tooltip.context.data.param, ref tooltip.context.data.title);
			TooltipHelper.ResetTooltipParamsByItemFormatter(tooltip, base.chart);
			tooltip.SetActive(flag: true);
			tooltip.view.Refresh();
			TooltipHelper.LimitInRect(tooltip, base.chart.chartRect);
			return true;
		}

		private bool SetSerieTooltip(Tooltip tooltip, List<Serie> series)
		{
			if (tooltip.context.trigger == Tooltip.Trigger.None)
			{
				return false;
			}
			if (series.Count <= 0)
			{
				return false;
			}
			string category = null;
			bool showCategory = false;
			bool flag = false;
			bool flag2 = false;
			int dataIndex = -1;
			tooltip.context.data.param.Clear();
			tooltip.context.pointer = base.chart.pointerPos;
			if (m_PointerContainer is GridCoord)
			{
				GetAxisCategory(m_PointerContainer.index, ref dataIndex, ref category);
				if (tooltip.context.trigger == Tooltip.Trigger.Axis)
				{
					flag = true;
					if (series.Count <= 1)
					{
						showCategory = true;
						tooltip.context.data.title = series[0].serieName;
					}
					else
					{
						tooltip.context.data.title = category;
					}
				}
				else if (tooltip.context.trigger == Tooltip.Trigger.Item)
				{
					flag2 = true;
					showCategory = series.Count <= 1;
				}
			}
			for (int i = 0; i < series.Count; i++)
			{
				Serie serie = series[i];
				if (serie.show && (!flag2 || serie.context.pointerItemDataIndex >= 0))
				{
					serie.context.isTriggerByAxis = flag;
					if (flag && dataIndex >= 0 && serie.context.pointerItemDataIndex < 0)
					{
						serie.context.pointerItemDataIndex = dataIndex;
					}
					serie.handler.UpdateTooltipSerieParams(dataIndex, showCategory, category, tooltip.marker, tooltip.itemFormatter, tooltip.numericFormatter, tooltip.ignoreDataDefaultContent, ref tooltip.context.data.param, ref tooltip.context.data.title);
				}
			}
			TooltipHelper.ResetTooltipParamsByItemFormatter(tooltip, base.chart);
			if (tooltip.context.data.param.Count > 0)
			{
				tooltip.SetActive(flag: true);
				if (tooltip.view != null)
				{
					tooltip.view.Refresh();
				}
				TooltipHelper.LimitInRect(tooltip, base.chart.chartRect);
				return true;
			}
			return false;
		}

		private bool GetAxisCategory(int gridIndex, ref int dataIndex, ref string category)
		{
			foreach (MainComponent component in base.chart.components)
			{
				if (component is Axis)
				{
					Axis axis = component as Axis;
					if (axis.gridIndex == gridIndex && axis.IsCategory())
					{
						dataIndex = (double.IsNaN(axis.context.pointerValue) ? axis.context.dataZoomStartIndex : (axis.context.dataZoomStartIndex + (int)axis.context.pointerValue));
						category = axis.GetData(dataIndex);
						return true;
					}
				}
			}
			return false;
		}

		private void DrawTooltipIndicator(VertexHelper vh, Tooltip tooltip)
		{
			if (!tooltip.show || tooltip.context.type == Tooltip.Type.None || !IsAnySerieNeedTooltip())
			{
				return;
			}
			if (m_PointerContainer is GridCoord)
			{
				GridCoord gridCoord = m_PointerContainer as GridCoord;
				if (gridCoord.context.isPointerEnter)
				{
					if (IsYCategoryOfGrid(gridCoord.index))
					{
						DrawYAxisIndicator(vh, tooltip, gridCoord);
					}
					else
					{
						DrawXAxisIndicator(vh, tooltip, gridCoord);
					}
				}
			}
			else if (m_PointerContainer is PolarCoord)
			{
				DrawPolarIndicator(vh, tooltip, m_PointerContainer as PolarCoord);
			}
		}

		private bool IsYCategoryOfGrid(int gridIndex)
		{
			foreach (MainComponent chartComponent in base.chart.GetChartComponents<YAxis>())
			{
				YAxis yAxis = chartComponent as YAxis;
				if (yAxis.gridIndex == gridIndex && yAxis.IsCategory())
				{
					return true;
				}
			}
			return false;
		}

		private void DrawXAxisIndicator(VertexHelper vh, Tooltip tooltip, GridCoord grid)
		{
			List<MainComponent> chartComponents = base.chart.GetChartComponents<XAxis>();
			LineStyle.Type type = tooltip.lineStyle.GetType(base.chart.theme.tooltip.lineType);
			float width = tooltip.lineStyle.GetWidth(base.chart.theme.tooltip.lineWidth);
			foreach (MainComponent item in chartComponents)
			{
				XAxis xAxis = item as XAxis;
				if (xAxis.gridIndex != grid.index || double.IsInfinity(xAxis.context.pointerValue))
				{
					continue;
				}
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(xAxis);
				int dataCount = ((base.chart.series.Count > 0) ? base.chart.series[0].GetDataList(dataZoomOfAxis).Count : 0);
				float dataWidth = AxisHelper.GetDataWidth(xAxis, grid.context.width, dataCount, dataZoomOfAxis);
				switch (tooltip.context.type)
				{
				case Tooltip.Type.Line:
				case Tooltip.Type.Corss:
				{
					float num2 = grid.context.x;
					num2 += (xAxis.IsCategory() ? ((float)(xAxis.context.pointerValue * (double)dataWidth + (double)(xAxis.boundaryGap ? (dataWidth / 2f) : 0f))) : xAxis.GetDistance(xAxis.context.axisTooltipValue, grid.context.width));
					if (!(num2 < grid.context.x))
					{
						Vector2 vector = new Vector2(num2, grid.context.y);
						Vector2 vector2 = new Vector2(num2, grid.context.y + grid.context.height);
						Color32 lineColor2 = TooltipHelper.GetLineColor(tooltip, base.chart.theme.tooltip.lineColor);
						ChartDrawer.DrawLineStyle(vh, type, width, vector, vector2, lineColor2);
						if (tooltip.context.type == Tooltip.Type.Corss)
						{
							vector = new Vector2(grid.context.x, base.chart.pointerPos.y);
							ChartDrawer.DrawLineStyle(endPos: new Vector2(grid.context.x + grid.context.width, base.chart.pointerPos.y), vh: vh, lineType: type, lineWidth: width, startPos: vector, color: lineColor2);
						}
					}
					break;
				}
				case Tooltip.Type.Shadow:
					if (xAxis.IsCategory() && !double.IsInfinity(xAxis.context.pointerValue))
					{
						float num = ((dataWidth < 1f) ? 1f : dataWidth);
						float num2 = (float)((double)grid.context.x + (double)dataWidth * xAxis.context.pointerValue - (double)(xAxis.boundaryGap ? 0f : (dataWidth / 2f)));
						if (!(num2 < grid.context.x))
						{
							float y = grid.context.y + grid.context.height;
							Vector3 p = base.chart.ClampInGrid(grid, new Vector3(num2, grid.context.y));
							Vector3 p2 = base.chart.ClampInGrid(grid, new Vector3(num2, y));
							Vector3 p3 = base.chart.ClampInGrid(grid, new Vector3(num2 + num, y));
							Vector3 p4 = base.chart.ClampInGrid(grid, new Vector3(num2 + num, grid.context.y));
							Color32 lineColor = TooltipHelper.GetLineColor(tooltip, base.chart.theme.tooltip.areaColor);
							UGL.DrawQuadrilateral(vh, p, p2, p3, p4, lineColor);
						}
					}
					break;
				}
			}
		}

		private bool IsAnySerieNeedTooltip()
		{
			foreach (Serie item in base.chart.series)
			{
				if (item.context.pointerEnter)
				{
					return true;
				}
			}
			return false;
		}

		private void DrawYAxisIndicator(VertexHelper vh, Tooltip tooltip, GridCoord grid)
		{
			List<MainComponent> chartComponents = base.chart.GetChartComponents<YAxis>();
			LineStyle.Type type = tooltip.lineStyle.GetType(base.chart.theme.tooltip.lineType);
			float width = tooltip.lineStyle.GetWidth(base.chart.theme.tooltip.lineWidth);
			foreach (MainComponent item in chartComponents)
			{
				YAxis yAxis = item as YAxis;
				if (yAxis.gridIndex != grid.index || double.IsInfinity(yAxis.context.pointerValue))
				{
					continue;
				}
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(yAxis);
				int dataCount = ((base.chart.series.Count > 0) ? base.chart.series[0].GetDataList(dataZoomOfAxis).Count : 0);
				float dataWidth = AxisHelper.GetDataWidth(yAxis, grid.context.height, dataCount, dataZoomOfAxis);
				switch (tooltip.context.type)
				{
				case Tooltip.Type.Line:
				case Tooltip.Type.Corss:
				{
					float num2 = (float)((double)grid.context.y + yAxis.context.pointerValue * (double)dataWidth + (double)(yAxis.boundaryGap ? (dataWidth / 2f) : 0f));
					if (!(num2 < grid.context.y))
					{
						Vector2 vector = new Vector2(grid.context.x, num2);
						Vector2 vector2 = new Vector2(grid.context.x + grid.context.width, num2);
						Color32 lineColor = TooltipHelper.GetLineColor(tooltip, base.chart.theme.tooltip.lineColor);
						ChartDrawer.DrawLineStyle(vh, type, width, vector, vector2, lineColor);
						if (tooltip.context.type == Tooltip.Type.Corss)
						{
							vector = new Vector2(base.chart.pointerPos.x, grid.context.y);
							ChartDrawer.DrawLineStyle(endPos: new Vector2(base.chart.pointerPos.x, grid.context.y + grid.context.height), vh: vh, lineType: type, lineWidth: width, startPos: vector, color: lineColor);
						}
					}
					break;
				}
				case Tooltip.Type.Shadow:
					if (yAxis.IsCategory())
					{
						float num = ((dataWidth < 1f) ? 1f : dataWidth);
						float x = grid.context.x + grid.context.width;
						float num2 = (float)((double)grid.context.y + (double)dataWidth * yAxis.context.pointerValue - (double)(yAxis.boundaryGap ? 0f : (dataWidth / 2f)));
						if (!(num2 < grid.context.y))
						{
							Vector3 p = new Vector3(grid.context.x, num2);
							Vector3 p2 = new Vector3(grid.context.x, num2 + num);
							Vector3 p3 = new Vector3(x, num2 + num);
							Vector3 p4 = new Vector3(x, num2);
							UGL.DrawQuadrilateral(vh, p, p2, p3, p4, base.chart.theme.tooltip.areaColor);
						}
					}
					break;
				}
			}
		}

		private void DrawPolarIndicator(VertexHelper vh, Tooltip tooltip, PolarCoord m_Polar)
		{
			if (tooltip.context.angle < 0f)
			{
				return;
			}
			ThemeStyle theme = base.chart.theme;
			AngleAxis angleAxis = ComponentHelper.GetAngleAxis(base.chart.components, m_Polar.index);
			Color32 lineColor = TooltipHelper.GetLineColor(tooltip, theme.tooltip.lineColor);
			LineStyle.Type type = tooltip.lineStyle.GetType(theme.tooltip.lineType);
			float width = tooltip.lineStyle.GetWidth(theme.tooltip.lineWidth);
			Vector3 center = m_Polar.context.center;
			float outsideRadius = m_Polar.context.outsideRadius;
			float valueAngle = angleAxis.GetValueAngle(tooltip.context.angle);
			Vector3 pos = ChartHelper.GetPos(m_Polar.context.center, m_Polar.context.insideRadius, valueAngle, isDegree: true);
			Vector3 pos2 = ChartHelper.GetPos(m_Polar.context.center, m_Polar.context.outsideRadius, valueAngle, isDegree: true);
			switch (tooltip.context.type)
			{
			case Tooltip.Type.Corss:
			{
				ChartDrawer.DrawLineStyle(vh, type, width, pos, pos2, lineColor);
				float num = Vector2.Distance(base.chart.pointerPos, center);
				if (num > outsideRadius)
				{
					num = outsideRadius;
				}
				float outsideRadius2 = num + tooltip.lineStyle.GetWidth(theme.tooltip.lineWidth) * 2f;
				UGL.DrawDoughnut(vh, center, num, outsideRadius2, lineColor, Color.clear);
				break;
			}
			case Tooltip.Type.Line:
				ChartDrawer.DrawLineStyle(vh, type, width, pos, pos2, lineColor);
				break;
			case Tooltip.Type.Shadow:
				UGL.DrawSector(vh, center, outsideRadius, lineColor, valueAngle - 2f, valueAngle + 2f, base.chart.settings.cicleSmoothness);
				break;
			case Tooltip.Type.None:
				break;
			}
		}
	}
}
