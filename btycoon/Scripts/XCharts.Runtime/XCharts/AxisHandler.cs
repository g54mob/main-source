using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XCharts.Runtime;
using XUGL;

namespace XCharts
{
	public abstract class AxisHandler<T> : MainComponentHandler where T : Axis
	{
		private static readonly string s_DefaultAxisName = "name";

		private double m_LastInterval = double.MinValue;

		private int m_LastSplitNumber = int.MinValue;

		public T component { get; internal set; }

		protected virtual Orient orient { get; set; }

		internal override void SetComponent(MainComponent component)
		{
			this.component = (T)component;
		}

		protected virtual Vector3 GetLabelPosition(float scaleWid, int i)
		{
			return Vector3.zero;
		}

		internal virtual float GetAxisLineXOrY()
		{
			return 0f;
		}

		protected virtual void UpdatePointerValue(Axis axis)
		{
			GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
			if (chartComponent == null)
			{
				return;
			}
			if (!chartComponent.context.isPointerEnter)
			{
				axis.context.pointerValue = double.NaN;
				return;
			}
			double pointerValue = axis.context.pointerValue;
			if (axis.IsCategory())
			{
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
				int dataCount = ((base.chart.series.Count > 0) ? base.chart.series[0].GetDataList(dataZoomOfAxis).Count : 0);
				Vector2 pointerPos = base.chart.pointerPos;
				if (axis is YAxis)
				{
					float dataWidth = AxisHelper.GetDataWidth(axis, chartComponent.context.height, dataCount, dataZoomOfAxis);
					for (int i = 0; i < axis.GetDataCount(dataZoomOfAxis); i++)
					{
						float num = chartComponent.context.y + (float)i * dataWidth;
						if ((axis.boundaryGap && pointerPos.y > num && pointerPos.y <= num + dataWidth) || (!axis.boundaryGap && pointerPos.y > num - dataWidth / 2f && pointerPos.y <= num + dataWidth / 2f))
						{
							axis.context.pointerValue = i;
							axis.context.pointerLabelPosition = axis.GetLabelObjectPosition(i);
							if ((double)i != pointerValue && base.chart.onAxisPointerValueChanged != null)
							{
								base.chart.onAxisPointerValueChanged(axis, i);
							}
							break;
						}
					}
					return;
				}
				float dataWidth2 = AxisHelper.GetDataWidth(axis, chartComponent.context.width, dataCount, dataZoomOfAxis);
				for (int j = 0; j < axis.GetDataCount(dataZoomOfAxis); j++)
				{
					float num2 = chartComponent.context.x + (float)j * dataWidth2;
					if ((axis.boundaryGap && pointerPos.x > num2 && pointerPos.x <= num2 + dataWidth2) || (!axis.boundaryGap && pointerPos.x > num2 - dataWidth2 / 2f && pointerPos.x <= num2 + dataWidth2 / 2f))
					{
						axis.context.pointerValue = j;
						axis.context.pointerLabelPosition = axis.GetLabelObjectPosition(j);
						if ((double)j != pointerValue && base.chart.onAxisPointerValueChanged != null)
						{
							base.chart.onAxisPointerValueChanged(axis, j);
						}
						break;
					}
				}
			}
			else if (axis is YAxis)
			{
				double num3 = axis.context.minMaxRange / (double)chartComponent.context.height * (double)(base.chart.pointerPos.y - chartComponent.context.y - axis.context.offset);
				if (axis.context.minValue > 0.0)
				{
					num3 += axis.context.minValue;
				}
				float x = axis.GetLabelObjectPosition(0).x;
				axis.context.pointerValue = num3;
				axis.context.pointerLabelPosition = new Vector3(x, base.chart.pointerPos.y);
				if (num3 != pointerValue && base.chart.onAxisPointerValueChanged != null)
				{
					base.chart.onAxisPointerValueChanged(axis, num3);
				}
			}
			else
			{
				double num4 = axis.context.minMaxRange / (double)chartComponent.context.width * (double)(base.chart.pointerPos.x - chartComponent.context.x - axis.context.offset);
				if (axis.context.minValue > 0.0)
				{
					num4 += axis.context.minValue;
				}
				float y = axis.GetLabelObjectPosition(0).y;
				axis.context.pointerValue = num4;
				axis.context.pointerLabelPosition = new Vector3(base.chart.pointerPos.x, y);
				if (num4 != pointerValue && base.chart.onAxisPointerValueChanged != null)
				{
					base.chart.onAxisPointerValueChanged(axis, num4);
				}
			}
		}

		internal void UpdateAxisMinMaxValue(int axisIndex, Axis axis, bool updateChart = true)
		{
			if (!axis.show)
			{
				return;
			}
			if (axis.IsCategory())
			{
				axis.context.minValue = 0.0;
				axis.context.maxValue = SeriesHelper.GetMaxSerieDataCount(base.chart.series) - 1;
				axis.context.minMaxRange = axis.context.maxValue;
				return;
			}
			double tempMinValue = 0.0;
			double tempMaxValue = 0.0;
			base.chart.GetSeriesMinMaxValue(axis, axisIndex, out tempMinValue, out tempMaxValue);
			DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
			if (dataZoomOfAxis != null && dataZoomOfAxis.enable)
			{
				if (axis is XAxis)
				{
					dataZoomOfAxis.SetXAxisIndexValueInfo(axisIndex, ref tempMinValue, ref tempMaxValue);
				}
				else
				{
					dataZoomOfAxis.SetYAxisIndexValueInfo(axisIndex, ref tempMinValue, ref tempMaxValue);
				}
			}
			if (tempMinValue == axis.context.minValue && tempMaxValue == axis.context.maxValue && m_LastInterval == axis.interval && m_LastSplitNumber == axis.splitNumber)
			{
				return;
			}
			m_LastSplitNumber = axis.splitNumber;
			m_LastInterval = axis.interval;
			axis.UpdateMinMaxValue(tempMinValue, tempMaxValue);
			axis.context.offset = 0f;
			axis.context.lastCheckInverse = axis.inverse;
			UpdateAxisTickValueList(axis);
			if (tempMinValue != 0.0 || tempMaxValue != 0.0)
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
				if (chartComponent != null && axis is XAxis && axis.IsValue())
				{
					axis.UpdateZeroOffset(chartComponent.context.width);
				}
				if (chartComponent != null && axis is YAxis && axis.IsValue())
				{
					axis.UpdateZeroOffset(chartComponent.context.height);
				}
			}
			if (updateChart)
			{
				UpdateAxisLabelText(axis);
				base.chart.RefreshChart();
			}
		}

		internal virtual void UpdateAxisLabelText(Axis axis)
		{
			GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
			if (chartComponent != null && axis != null)
			{
				float coordinateWidth = ((axis is XAxis) ? chartComponent.context.width : chartComponent.context.height);
				bool forcePercent = SeriesHelper.IsPercentStack<Bar>(base.chart.series);
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
				axis.UpdateLabelText(coordinateWidth, dataZoomOfAxis, forcePercent);
			}
		}

		internal void UpdateAxisTickValueList(Axis axis)
		{
			if (axis.IsTime())
			{
				int count = axis.context.labelValueList.Count;
				axis.context.tickValue = DateTimeUtil.UpdateTimeAxisDateTimeList(axis.context.labelValueList, (int)axis.context.minValue, (int)axis.context.maxValue, axis.splitNumber);
				if (axis.context.labelValueList.Count != count)
				{
					axis.SetAllDirty();
				}
			}
			else
			{
				if (!axis.IsValue())
				{
					return;
				}
				List<double> labelValueList = axis.context.labelValueList;
				int count2 = labelValueList.Count;
				labelValueList.Clear();
				double num = axis.context.maxValue - axis.context.minValue;
				if (num <= 0.0)
				{
					return;
				}
				double num2 = axis.interval;
				if (axis.interval == 0.0)
				{
					if (axis.splitNumber > 0)
					{
						num2 = num / (double)axis.splitNumber;
					}
					else
					{
						double tick = GetTick(num);
						num2 = tick;
						if (num / 4.0 % tick == 0.0)
						{
							num2 = num / 4.0;
						}
						else if (num / num2 > 8.0)
						{
							num2 = 2.0 * tick;
						}
						else if (num / num2 < 4.0)
						{
							num2 = tick / 2.0;
						}
					}
				}
				double num3 = 0.0;
				axis.context.tickValue = num2;
				if (Mathf.Approximately((float)(axis.context.minValue % num2), 0f))
				{
					num3 = axis.context.minValue;
				}
				else
				{
					labelValueList.Add(axis.context.minValue);
					num3 = Math.Ceiling(axis.context.minValue / num2) * num2;
				}
				float axisMaxSplitNumber = base.chart.settings.axisMaxSplitNumber;
				while (num3 <= axis.context.maxValue)
				{
					labelValueList.Add(num3);
					num3 += num2;
					if (axisMaxSplitNumber > 0f && (float)labelValueList.Count > axisMaxSplitNumber)
					{
						break;
					}
				}
				if (!ChartHelper.IsEquals(axis.context.maxValue, labelValueList[labelValueList.Count - 1]))
				{
					labelValueList.Add(axis.context.maxValue);
				}
				if (count2 != labelValueList.Count)
				{
					axis.SetAllDirty();
				}
			}
		}

		private static double GetTick(double max)
		{
			if (max <= 1.0)
			{
				return max / 5.0;
			}
			if (max > 1.0 && max < 10.0)
			{
				return 1.0;
			}
			double num = Math.Ceiling(Math.Abs(max));
			int i;
			for (i = 1; num / (double)Mathf.Pow(10f, i) > 10.0; i++)
			{
			}
			return Math.Pow(10.0, i);
		}

		internal void CheckValueLabelActive(Axis axis, int i, ChartLabel label, Vector3 pos)
		{
			if (!axis.show || !axis.axisLabel.show)
			{
				label.SetTextActive(flag: false);
			}
			else
			{
				if (!axis.IsValue())
				{
					return;
				}
				if (orient == Orient.Horizonal)
				{
					if (i == 0)
					{
						float num = GetLabelPosition(0f, 1).x - pos.x;
						label.SetTextActive(axis.IsNeedShowLabel(i) && num > label.text.GetPreferredWidth());
					}
					else if (i == axis.context.labelValueList.Count - 1)
					{
						float num2 = pos.x - GetLabelPosition(0f, i - 1).x;
						label.SetTextActive(axis.IsNeedShowLabel(i) && num2 > label.text.GetPreferredWidth());
					}
				}
				else if (i == 0)
				{
					float num3 = GetLabelPosition(0f, 1).y - pos.y;
					label.SetTextActive(axis.IsNeedShowLabel(i) && num3 > label.text.GetPreferredHeight());
				}
				else if (i == axis.context.labelValueList.Count - 1)
				{
					float num4 = pos.y - GetLabelPosition(0f, i - 1).y;
					label.SetTextActive(axis.IsNeedShowLabel(i) && num4 > label.text.GetPreferredHeight());
				}
			}
		}

		protected void InitAxis(Axis relativedAxis, Orient orient, float axisStartX, float axisStartY, float axisLength, float relativedLength)
		{
			Axis axis = component;
			base.chart.InitAxisRuntimeData(axis);
			GameObject gameObject = ChartHelper.AddObject(ChartCached.GetComponentObjectName(axis), base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
			gameObject.SetActive(axis.show);
			gameObject.hideFlags = base.chart.chartHideFlags;
			ChartHelper.HideAllObject(gameObject);
			axis.gameObject = gameObject;
			axis.context.labelObjectList.Clear();
			if (!axis.show)
			{
				return;
			}
			_ = axis.axisLabel.textStyle;
			DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
			int num = AxisHelper.GetScaleNumber(axis, axisLength, dataZoomOfAxis);
			float num2 = 0f;
			float eachWidth = AxisHelper.GetEachWidth(axis, axisLength, dataZoomOfAxis);
			float num3 = (axis.boundaryGap ? (eachWidth / 2f) : 0f);
			float x = ((axis.axisLabel.width > 0f) ? axis.axisLabel.width : ((orient == Orient.Horizonal) ? AxisHelper.GetScaleWidth(axis, axisLength, 0, dataZoomOfAxis) : (axisStartX - base.chart.chartX)));
			float y = ((axis.axisLabel.height > 0f) ? axis.axisLabel.height : 20f);
			bool forcePercent = SeriesHelper.IsPercentStack<Bar>(base.chart.series);
			bool inside = axis.axisLabel.inside;
			TextAnchor textAnchor = ((orient == Orient.Horizonal) ? TextAnchor.MiddleCenter : (((inside && axis.IsLeft()) || (!inside && axis.IsRight())) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight));
			if (axis.IsCategory() && axis.boundaryGap)
			{
				num--;
			}
			axis.context.aligment = textAnchor;
			for (int i = 0; i < num; i++)
			{
				float scaleWidth = AxisHelper.GetScaleWidth(axis, axisLength, i + 1, dataZoomOfAxis);
				string labelName = AxisHelper.GetLabelName(axis, axisLength, i, axis.context.minValue, axis.context.maxValue, dataZoomOfAxis, forcePercent);
				ChartLabel chartLabel = ChartHelper.AddAxisLabelObject(num, i, ChartCached.GetAxisLabelName(i), gameObject.transform, new Vector2(x, y), axis, base.chart.theme.axis, labelName, Color.clear, textAnchor, base.chart.theme.GetColor(i));
				if (i == 0)
				{
					axis.axisLabel.SetRelatedText(chartLabel.text, scaleWidth);
				}
				Vector3 labelPosition = GetLabelPosition(num2 + num3, i);
				chartLabel.SetPosition(labelPosition);
				CheckValueLabelActive(axis, i, chartLabel, labelPosition);
				axis.context.labelObjectList.Add(chartLabel);
				num2 += scaleWidth;
			}
			if (!axis.axisName.show)
			{
				return;
			}
			float num4 = relativedAxis?.context.offset ?? 0f;
			Vector3 vector = new Vector3(axisStartX, axisStartY + num4);
			Vector3 offset = axis.axisName.labelStyle.offset;
			Color32 color = axis.axisLine.GetColor(base.chart.theme.axis.lineColor);
			if (orient == Orient.Horizonal)
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
				float num5 = ((!axis.axisName.onZero && chartComponent != null) ? chartComponent.context.y : (GetAxisLineXOrY() + offset.y));
				switch (axis.axisName.labelStyle.position)
				{
				case LabelStyle.Position.Start:
				{
					ChartLabel chartLabel4 = ChartHelper.AddChartLabel(s_DefaultAxisName, gameObject.transform, axis.axisName.labelStyle, base.chart.theme.axis, axis.axisName.name, color, TextAnchor.MiddleRight);
					chartLabel4.SetActive(axis.axisName.labelStyle.show);
					chartLabel4.SetPosition((axis.position == Axis.AxisPosition.Top) ? new Vector2(vector.x - offset.x, axisStartY + relativedLength + offset.y + axis.offset) : new Vector2(vector.x - offset.x, num5 + offset.y));
					break;
				}
				case LabelStyle.Position.Middle:
				{
					ChartLabel chartLabel3 = ChartHelper.AddChartLabel(s_DefaultAxisName, gameObject.transform, axis.axisName.labelStyle, base.chart.theme.axis, axis.axisName.name, color);
					chartLabel3.SetActive(axis.axisName.labelStyle.show);
					chartLabel3.SetPosition((axis.position == Axis.AxisPosition.Top) ? new Vector2(axisStartX + axisLength / 2f + offset.x, axisStartY + relativedLength - offset.y + axis.offset) : new Vector2(axisStartX + axisLength / 2f + offset.x, num5 + offset.y));
					break;
				}
				default:
				{
					ChartLabel chartLabel2 = ChartHelper.AddChartLabel(s_DefaultAxisName, gameObject.transform, axis.axisName.labelStyle, base.chart.theme.axis, axis.axisName.name, color, TextAnchor.MiddleLeft);
					chartLabel2.SetActive(axis.axisName.labelStyle.show);
					chartLabel2.SetPosition((axis.position == Axis.AxisPosition.Top) ? new Vector2(axisStartX + axisLength + offset.x, axisStartY + relativedLength + offset.y + axis.offset) : new Vector2(axisStartX + axisLength + offset.x, num5 + offset.y));
					break;
				}
				}
			}
			else
			{
				GridCoord chartComponent2 = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
				float num6 = ((!axis.axisName.onZero && chartComponent2 != null) ? chartComponent2.context.x : (GetAxisLineXOrY() + offset.x));
				switch (axis.axisName.labelStyle.position)
				{
				case LabelStyle.Position.Start:
				{
					ChartLabel chartLabel7 = ChartHelper.AddChartLabel(s_DefaultAxisName, gameObject.transform, axis.axisName.labelStyle, base.chart.theme.axis, axis.axisName.name, color);
					chartLabel7.SetActive(axis.axisName.labelStyle.show);
					chartLabel7.SetPosition((axis.position == Axis.AxisPosition.Right) ? new Vector2(axisStartX + relativedLength + offset.x + axis.offset, axisStartY - offset.y) : new Vector2(num6 + offset.x, axisStartY - offset.y));
					break;
				}
				case LabelStyle.Position.Middle:
				{
					ChartLabel chartLabel6 = ChartHelper.AddChartLabel(s_DefaultAxisName, gameObject.transform, axis.axisName.labelStyle, base.chart.theme.axis, axis.axisName.name, color);
					chartLabel6.SetActive(axis.axisName.labelStyle.show);
					chartLabel6.SetPosition((axis.position == Axis.AxisPosition.Right) ? new Vector2(axisStartX + relativedLength - offset.x + axis.offset, axisStartY + axisLength / 2f + offset.y) : new Vector2(num6 + offset.x, axisStartY + axisLength / 2f + offset.y));
					break;
				}
				default:
				{
					ChartLabel chartLabel5 = ChartHelper.AddChartLabel(s_DefaultAxisName, gameObject.transform, axis.axisName.labelStyle, base.chart.theme.axis, axis.axisName.name, color);
					chartLabel5.SetActive(axis.axisName.labelStyle.show);
					chartLabel5.SetPosition((axis.position == Axis.AxisPosition.Right) ? new Vector2(axisStartX + relativedLength + offset.x + axis.offset, axisStartY + axisLength + offset.y) : new Vector2(num6 + offset.x, axisStartY + axisLength + offset.y));
					break;
				}
				}
			}
		}

		internal static Vector3 GetLabelPosition(int i, Orient orient, Axis axis, Axis relativedAxis, AxisTheme theme, float scaleWid, float axisStartX, float axisStartY, float axisLength, float relativedLength)
		{
			bool inside = axis.axisLabel.inside;
			int fontSize = axis.axisLabel.textStyle.GetFontSize(theme);
			float offset = axis.offset;
			if (axis.IsTime() || axis.IsValue())
			{
				scaleWid = ((axis.context.minMaxRange != 0.0) ? axis.GetDistance(axis.GetLabelValue(i), axisLength) : 0f);
			}
			if (orient == Orient.Horizonal)
			{
				if (axis.axisLabel.onZero && relativedAxis != null)
				{
					axisStartY += relativedAxis.context.offset;
				}
				if (axis.IsTop())
				{
					axisStartY += relativedLength;
				}
				offset = (((!inside || !axis.IsBottom()) && (inside || !axis.IsTop())) ? (offset + (axisStartY - axis.axisLabel.distance - (float)(fontSize / 2))) : (offset + (axisStartY + axis.axisLabel.distance + (float)(fontSize / 2))));
				return new Vector3(axisStartX + scaleWid, offset) + axis.axisLabel.offset;
			}
			if (axis.axisLabel.onZero && relativedAxis != null)
			{
				axisStartX += relativedAxis.context.offset;
			}
			if (axis.IsRight())
			{
				axisStartX += relativedLength;
			}
			offset = (((!inside || !axis.IsLeft()) && (inside || !axis.IsRight())) ? (offset + (axisStartX - axis.axisLabel.distance)) : (offset + (axisStartX + axis.axisLabel.distance)));
			return new Vector3(offset, axisStartY + scaleWid) + axis.axisLabel.offset;
		}

		internal static void DrawAxisLine(VertexHelper vh, Axis axis, AxisTheme theme, Orient orient, float startX, float startY, float axisLength)
		{
			bool flag = axis.IsValue() && axis.inverse;
			float axisLineArrowOffset = AxisHelper.GetAxisLineArrowOffset(axis);
			float width = axis.axisLine.GetWidth(theme.lineWidth);
			LineStyle.Type type = axis.axisLine.GetType(theme.lineType);
			Color32 color = axis.axisLine.GetColor(theme.lineColor);
			if (orient == Orient.Horizonal)
			{
				Vector3 startPos = new Vector3(startX - width - (flag ? axisLineArrowOffset : 0f), startY);
				Vector3 endPos = new Vector3(startX + axisLength + width + ((!flag) ? axisLineArrowOffset : 0f), startY);
				ChartDrawer.DrawLineStyle(vh, type, width, startPos, endPos, color);
			}
			else
			{
				Vector3 startPos2 = new Vector3(startX, startY - width - (flag ? axisLineArrowOffset : 0f));
				Vector3 endPos2 = new Vector3(startX, startY + axisLength + width + ((!flag) ? axisLineArrowOffset : 0f));
				ChartDrawer.DrawLineStyle(vh, type, width, startPos2, endPos2, color);
			}
		}

		internal static void DrawAxisTick(VertexHelper vh, Axis axis, AxisTheme theme, DataZoom dataZoom, Orient orient, float startX, float startY, float axisLength)
		{
			float width = axis.axisLine.GetWidth(theme.lineWidth);
			float length = axis.axisTick.GetLength(theme.tickLength);
			if (AxisHelper.NeedShowSplit(axis))
			{
				int num = AxisHelper.GetScaleNumber(axis, axisLength, dataZoom);
				if (axis.IsTime())
				{
					num++;
					if (!ChartHelper.IsEquals(axis.GetLastLabelValue(), axis.context.maxValue))
					{
						num++;
					}
				}
				float width2 = axis.axisTick.GetWidth(theme.tickWidth);
				Color32 color = axis.axisTick.GetColor(theme.tickColor);
				float num2 = ((orient == Orient.Horizonal) ? startX : startY);
				float num3 = num2 + axisLength;
				float num4 = num2;
				float num5 = num2;
				int num6 = ((axis.minorTick.splitNumber <= 0) ? 5 : axis.minorTick.splitNumber);
				float valueLength = axis.GetValueLength(axis.context.tickValue / (double)num6, axisLength);
				Color32 color2 = axis.minorTick.GetColor(theme.tickColor);
				float width3 = axis.minorTick.GetWidth(theme.tickWidth);
				float length2 = axis.minorTick.GetLength(theme.tickLength * 0.6f);
				int num7 = ((!axis.IsTime()) ? 1 : 0);
				for (int i = 0; i < num; i++)
				{
					float scaleWidth = AxisHelper.GetScaleWidth(axis, axisLength, i + 1, dataZoom);
					bool flag = (i == 0 && (!axis.axisTick.showStartTick || axis.axisTick.alignWithLabel)) || (i == num - 1 && !axis.axisTick.showEndTick);
					if (axis.axisTick.show)
					{
						if (orient == Orient.Horizonal)
						{
							float num8 = (axis.IsTime() ? (startX + axis.GetDistance(axis.GetLabelValue(i), axisLength)) : num2);
							if (axis.boundaryGap && axis.axisTick.alignWithLabel)
							{
								num8 -= scaleWidth / 2f;
							}
							float num9 = 0f;
							float num10 = 0f;
							float num11 = 0f;
							if ((axis.axisTick.inside && axis.IsBottom()) || (!axis.axisTick.inside && axis.IsTop()))
							{
								num9 = startY + width;
								num10 = num9 + length;
								num11 = num9 + length2;
							}
							else
							{
								num9 = startY - width;
								num10 = num9 - length;
								num11 = num9 - length2;
							}
							if (!flag)
							{
								UGL.DrawLine(vh, new Vector3(num8, num9), new Vector3(num8, num10), width2, color);
							}
							if (axis.minorTick.show && i >= num7 && valueLength > 0f)
							{
								if (num4 <= axis.context.zeroX || (i == num7 && num8 > axis.context.zeroX))
								{
									for (float num12 = num8 - valueLength; num12 > num4; num12 -= valueLength)
									{
										UGL.DrawLine(vh, new Vector3(num12, num9), new Vector3(num12, num11), width3, color2);
									}
								}
								else
								{
									for (float num13 = num4 + valueLength; num13 < num8; num13 += valueLength)
									{
										UGL.DrawLine(vh, new Vector3(num13, num9), new Vector3(num13, num11), width3, color2);
									}
								}
								if (i == num - 1)
								{
									for (float num14 = num8 + valueLength; num14 < num3; num14 += valueLength)
									{
										UGL.DrawLine(vh, new Vector3(num14, num9), new Vector3(num14, num11), width3, color2);
									}
								}
							}
							num4 = num8;
						}
						else
						{
							float num15 = (axis.IsTime() ? (startY + axis.GetDistance(axis.GetLabelValue(i), axisLength)) : num2);
							if (axis.boundaryGap && axis.axisTick.alignWithLabel)
							{
								num15 -= scaleWidth / 2f;
							}
							float num16 = 0f;
							float num17 = 0f;
							float num18 = 0f;
							if ((axis.axisTick.inside && axis.IsLeft()) || (!axis.axisTick.inside && axis.IsRight()))
							{
								num16 = startX + width;
								num17 = num16 + length;
								num18 = num16 + length2;
							}
							else
							{
								num16 = startX - width;
								num17 = num16 - length;
								num18 = num16 - length2;
							}
							if (!flag)
							{
								UGL.DrawLine(vh, new Vector3(num16, num15), new Vector3(num17, num15), width2, color);
							}
							if (axis.minorTick.show && i >= num7 && valueLength > 0f)
							{
								if (num5 <= axis.context.zeroY || (i == num7 && num15 > axis.context.zeroY))
								{
									for (float num19 = num15 - valueLength; num19 > num5; num19 -= valueLength)
									{
										UGL.DrawLine(vh, new Vector3(num16, num19), new Vector3(num18, num19), width3, color2);
									}
								}
								else
								{
									for (float num20 = num5 + valueLength; num20 < num15; num20 += valueLength)
									{
										UGL.DrawLine(vh, new Vector3(num16, num20), new Vector3(num18, num20), width3, color2);
									}
								}
								if (i == num - 1)
								{
									for (float num21 = num15 + valueLength; num21 < num3; num21 += valueLength)
									{
										UGL.DrawLine(vh, new Vector3(num16, num21), new Vector3(num18, num21), width3, color2);
									}
								}
							}
							num5 = num15;
						}
					}
					num2 += scaleWidth;
				}
			}
			if (!axis.show || !axis.axisLine.show || !axis.axisLine.showArrow)
			{
				return;
			}
			float y = startY + axis.offset;
			bool flag2 = axis.IsValue() && axis.inverse;
			ArrowStyle arrow = axis.axisLine.arrow;
			if (orient == Orient.Horizonal)
			{
				if (flag2)
				{
					Vector3 startPoint = new Vector3(startX + axisLength, y);
					Vector3 arrowPoint = new Vector3(startX, y);
					UGL.DrawArrow(vh, startPoint, arrowPoint, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(axis.axisLine.GetColor(theme.lineColor)));
				}
				else
				{
					float x = startX + axisLength + width;
					Vector3 startPoint2 = new Vector3(startX, y);
					Vector3 arrowPoint2 = new Vector3(x, y);
					UGL.DrawArrow(vh, startPoint2, arrowPoint2, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(axis.axisLine.GetColor(theme.lineColor)));
				}
			}
			else if (flag2)
			{
				Vector3 startPoint3 = new Vector3(startX, startY + axisLength);
				Vector3 arrowPoint3 = new Vector3(startX, startY);
				UGL.DrawArrow(vh, startPoint3, arrowPoint3, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(axis.axisLine.GetColor(theme.lineColor)));
			}
			else
			{
				Vector3 startPoint4 = new Vector3(startX, startY);
				Vector3 arrowPoint4 = new Vector3(startX, startY + axisLength + width);
				UGL.DrawArrow(vh, startPoint4, arrowPoint4, arrow.width, arrow.height, arrow.offset, arrow.dent, arrow.GetColor(axis.axisLine.GetColor(theme.lineColor)));
			}
		}

		protected void DrawAxisSplit(VertexHelper vh, AxisTheme theme, DataZoom dataZoom, Orient orient, float startX, float startY, float axisLength, float splitLength, Axis relativedAxis = null)
		{
			Axis axis = component;
			float width = axis.axisLine.GetWidth(theme.lineWidth);
			splitLength -= width;
			Color32 color = axis.splitLine.GetColor(theme.splitLineColor);
			float width2 = axis.splitLine.GetWidth(theme.lineWidth);
			LineStyle.Type type = axis.splitLine.GetType(theme.splitLineType);
			int num = AxisHelper.GetScaleNumber(axis, axisLength, dataZoom);
			if (axis.IsTime())
			{
				num++;
				if (!ChartHelper.IsEquals(axis.GetLastLabelValue(), axis.context.maxValue))
				{
					num++;
				}
			}
			float num2 = ((orient == Orient.Horizonal) ? startX : startY);
			float num3 = num2 + axisLength;
			float num4 = 0f;
			float num5 = 0f;
			int num6 = ((axis.minorTick.splitNumber <= 0) ? 5 : axis.minorTick.splitNumber);
			float valueLength = axis.GetValueLength(axis.context.tickValue / (double)num6, axisLength);
			Color32 color2 = axis.minorSplitLine.GetColor(theme.minorSplitLineColor);
			float width3 = axis.minorSplitLine.GetWidth(theme.lineWidth);
			LineStyle.Type type2 = axis.minorSplitLine.GetType(theme.splitLineType);
			int num7 = ((!axis.IsTime()) ? 1 : 0);
			for (int i = 0; i < num; i++)
			{
				float scaleWidth = AxisHelper.GetScaleWidth(axis, axisLength, axis.IsTime() ? i : (i + 1), dataZoom);
				if (axis.boundaryGap && axis.axisTick.alignWithLabel)
				{
					num2 -= scaleWidth / 2f;
				}
				if (axis.splitArea.show && i <= num - 1)
				{
					if (orient == Orient.Horizonal)
					{
						UGL.DrawQuadrilateral(vh, new Vector2(num2, startY), new Vector2(num2, startY + splitLength), new Vector2(num2 + scaleWidth, startY + splitLength), new Vector2(num2 + scaleWidth, startY), axis.splitArea.GetColor(i, theme));
					}
					else
					{
						UGL.DrawQuadrilateral(vh, new Vector2(startX, num2), new Vector2(startX + splitLength, num2), new Vector2(startX + splitLength, num2 + scaleWidth), new Vector2(startX, num2 + scaleWidth), axis.splitArea.GetColor(i, theme));
					}
				}
				if (axis.splitLine.show && axis.splitLine.NeedShow(i, num))
				{
					if (orient == Orient.Horizonal)
					{
						if (relativedAxis == null || !relativedAxis.axisLine.show || !MathUtil.Approximately(num2, relativedAxis.context.x))
						{
							ChartDrawer.DrawLineStyle(vh, type, width2, new Vector3(num2, startY), new Vector3(num2, startY + splitLength), color);
						}
						if (axis.minorSplitLine.show && i >= num7 && valueLength > 0f)
						{
							if (num4 <= axis.context.zeroX || (i == num7 && num2 > axis.context.zeroX))
							{
								float num8 = num2 - valueLength;
								int num9 = 0;
								while (num8 > num4 && num9 < num6 - 1)
								{
									ChartDrawer.DrawLineStyle(vh, type2, width3, new Vector3(num8, startY), new Vector3(num8, startY + splitLength), color2);
									num9++;
									num8 -= valueLength;
								}
							}
							else
							{
								float num10 = num4 + valueLength;
								int num11 = 0;
								for (; num10 < num2; num10 += valueLength)
								{
									if (num11 >= num6 - 1)
									{
										break;
									}
									ChartDrawer.DrawLineStyle(vh, type2, width3, new Vector3(num10, startY), new Vector3(num10, startY + splitLength), color2);
									num11++;
								}
							}
							if (i == num - 1)
							{
								float num12 = num2 + valueLength;
								int num13 = 0;
								for (; num12 < num3; num12 += valueLength)
								{
									if (num13 >= num6 - 1)
									{
										break;
									}
									ChartDrawer.DrawLineStyle(vh, type2, width3, new Vector3(num12, startY), new Vector3(num12, startY + splitLength), color2);
									num13++;
								}
							}
						}
						num4 = num2;
					}
					else
					{
						if (relativedAxis == null || !relativedAxis.axisLine.show || !MathUtil.Approximately(num2, relativedAxis.context.y))
						{
							ChartDrawer.DrawLineStyle(vh, type, width2, new Vector3(startX, num2), new Vector3(startX + splitLength, num2), color);
						}
						if (axis.minorSplitLine.show && i >= num7 && valueLength > 0f)
						{
							if (num5 <= axis.context.zeroY || (i == num7 && num2 > axis.context.zeroY))
							{
								float num14 = num2 - valueLength;
								int num15 = 0;
								while (num14 > num5 && num15 < num6 - 1)
								{
									ChartDrawer.DrawLineStyle(vh, type2, width3, new Vector3(startX, num14), new Vector3(startX + splitLength, num14), color2);
									num15++;
									num14 -= valueLength;
								}
							}
							else
							{
								float num16 = num5 + valueLength;
								int num17 = 0;
								for (; num16 < num2; num16 += valueLength)
								{
									if (num17 >= num6 - 1)
									{
										break;
									}
									ChartDrawer.DrawLineStyle(vh, type2, width3, new Vector3(startX, num16), new Vector3(startX + splitLength, num16), color2);
									num17++;
								}
							}
							if (i == num - 1)
							{
								float num18 = num2 + valueLength;
								int num19 = 0;
								for (; num18 < num3; num18 += valueLength)
								{
									if (num19 >= num6 - 1)
									{
										break;
									}
									ChartDrawer.DrawLineStyle(vh, type2, width3, new Vector3(startX, num18), new Vector3(startX + splitLength, num18), color2);
									num19++;
								}
							}
						}
						num5 = num2;
					}
				}
				num2 += scaleWidth;
			}
		}
	}
}
