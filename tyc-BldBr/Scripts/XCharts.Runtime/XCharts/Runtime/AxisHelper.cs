using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class AxisHelper
	{
		public static float GetAxisLineArrowOffset(Axis axis)
		{
			if (axis.axisLine.show && axis.axisLine.showArrow && axis.axisLine.arrow.offset > 0f)
			{
				return axis.axisLine.arrow.offset;
			}
			return 0f;
		}

		public static int GetTotalSplitGridNum(Axis axis)
		{
			if (axis.IsCategory())
			{
				return axis.data.Count;
			}
			return ((axis.splitNumber <= 0) ? GetSplitNumber(axis, 0f, null) : axis.splitNumber) * axis.minorTick.splitNumber;
		}

		public static int GetSplitNumber(Axis axis, float coordinateWid, DataZoom dataZoom)
		{
			if (axis.type == Axis.AxisType.Value)
			{
				return axis.context.labelValueList.Count - 1;
			}
			if (axis.type == Axis.AxisType.Time)
			{
				return axis.context.labelValueList.Count;
			}
			if (axis.type == Axis.AxisType.Log)
			{
				if (axis.splitNumber <= 0)
				{
					return 4;
				}
				return axis.splitNumber;
			}
			if (axis.type == Axis.AxisType.Category)
			{
				int num = axis.GetDataList(dataZoom).Count;
				if (!axis.boundaryGap)
				{
					num--;
				}
				if (num <= 0)
				{
					num = 1;
				}
				if (axis.splitNumber <= 0)
				{
					float num2 = coordinateWid / (float)num;
					int num3 = ((axis is YAxis) ? 20 : 80);
					if (num2 > (float)num3)
					{
						return num;
					}
					int num4 = Mathf.CeilToInt((float)num3 / num2);
					return num / num4;
				}
				if (axis.splitNumber <= 0 || axis.splitNumber > num)
				{
					return num;
				}
				if (num >= axis.splitNumber * 2)
				{
					return axis.splitNumber;
				}
				return num;
			}
			return 0;
		}

		public static float GetDataWidth(Axis axis, float coordinateWidth, int dataCount, DataZoom dataZoom)
		{
			if (dataCount < 1)
			{
				dataCount = 1;
			}
			if (axis.IsValue())
			{
				if (dataCount <= 1)
				{
					return coordinateWidth;
				}
				return coordinateWidth / (float)(dataCount - 1);
			}
			int dataCount2 = axis.GetDataCount(dataZoom);
			int num = (axis.boundaryGap ? dataCount2 : (dataCount2 - 1));
			num = ((num <= 0) ? dataCount : num);
			if (num <= 0)
			{
				num = 1;
			}
			return coordinateWidth / (float)num;
		}

		public static string GetLabelName(Axis axis, float coordinateWidth, int index, double minValue, double maxValue, DataZoom dataZoom, bool forcePercent)
		{
			int splitNumber = GetSplitNumber(axis, coordinateWidth, dataZoom);
			if (axis.type == Axis.AxisType.Value)
			{
				if (minValue == 0.0 && maxValue == 0.0)
				{
					maxValue = ((axis.max != 0.0) ? axis.max : 1.0);
				}
				double num = 0.0;
				if (forcePercent)
				{
					maxValue = 100.0;
				}
				num = axis.GetLabelValue(index);
				if (axis.inverse)
				{
					num = 0.0 - num;
					minValue = 0.0 - minValue;
					maxValue = 0.0 - maxValue;
				}
				if (forcePercent)
				{
					return $"{(int)num}%";
				}
				return axis.axisLabel.GetFormatterContent(index, num, minValue, maxValue);
			}
			if (axis.type == Axis.AxisType.Log)
			{
				double num2 = (axis.logBaseE ? Math.Exp(axis.GetLogMinIndex() + (double)index) : Math.Pow(axis.logBase, axis.GetLogMinIndex() + (double)index));
				if (axis.inverse)
				{
					num2 = 0.0 - num2;
					minValue = 0.0 - minValue;
					maxValue = 0.0 - maxValue;
				}
				return axis.axisLabel.GetFormatterContent(index, num2, minValue, maxValue, isLog: true);
			}
			if (axis.type == Axis.AxisType.Time)
			{
				if (minValue == 0.0 && maxValue == 0.0)
				{
					return string.Empty;
				}
				if (index > axis.context.labelValueList.Count - 1)
				{
					return string.Empty;
				}
				double labelValue = axis.GetLabelValue(index);
				return axis.axisLabel.GetFormatterDateTime(index, labelValue, minValue, maxValue);
			}
			List<string> dataList = axis.GetDataList(dataZoom);
			int count = dataList.Count;
			if (count <= 0)
			{
				return "";
			}
			int num3 = (axis.boundaryGap ? (count / splitNumber) : ((count - 1) / splitNumber));
			if (num3 == 0)
			{
				num3 = 1;
			}
			if (axis.insertDataToHead)
			{
				if (index > 0)
				{
					int num4 = count - 1 - splitNumber * num3 + (index - 1) * num3;
					if (num4 < 0)
					{
						num4 = 0;
					}
					return axis.axisLabel.GetFormatterContent(num4, dataList[num4]);
				}
				if (axis.boundaryGap && coordinateWidth / (float)count > 5f)
				{
					return string.Empty;
				}
				return axis.axisLabel.GetFormatterContent(0, dataList[0]);
			}
			int num5 = index * num3;
			if (num5 < count)
			{
				return axis.axisLabel.GetFormatterContent(num5, dataList[num5]);
			}
			int num6 = num5 - count;
			if (axis.boundaryGap && ((num6 > 0 && (float)(num6 / num3) < 0.4f) || count >= axis.data.Count))
			{
				return string.Empty;
			}
			return axis.axisLabel.GetFormatterContent(count - 1, dataList[count - 1]);
		}

		public static int GetScaleNumber(Axis axis, float coordinateWidth, DataZoom dataZoom = null)
		{
			int splitNumber = GetSplitNumber(axis, coordinateWidth, dataZoom);
			if (splitNumber == 0)
			{
				return 0;
			}
			if (axis.IsCategory())
			{
				int count = axis.GetDataList(dataZoom).Count;
				int num = 0;
				if (axis.boundaryGap)
				{
					return (count > 1 && count % splitNumber == 0) ? (splitNumber + 1) : (splitNumber + 2);
				}
				return splitNumber + 1;
			}
			if (axis.IsTime())
			{
				return splitNumber;
			}
			return splitNumber + 1;
		}

		public static float GetScaleWidth(Axis axis, float coordinateWidth, int index, DataZoom dataZoom = null)
		{
			if (index < 0)
			{
				return 0f;
			}
			int num = GetScaleNumber(axis, coordinateWidth, dataZoom);
			int splitNumber = GetSplitNumber(axis, coordinateWidth, dataZoom);
			if (num <= 0)
			{
				num = 1;
			}
			if (axis.IsTime() || axis.IsValue())
			{
				double labelValue = axis.GetLabelValue(index);
				double labelValue2 = axis.GetLabelValue(index - 1);
				if (axis.context.minMaxRange != 0.0)
				{
					return (float)((double)coordinateWidth * (labelValue - labelValue2) / axis.context.minMaxRange);
				}
				return 0f;
			}
			List<string> dataList = axis.GetDataList(dataZoom);
			if (axis.IsCategory() && dataList.Count > 0 && splitNumber > 0)
			{
				int num2 = (axis.boundaryGap ? dataList.Count : (dataList.Count - 1));
				int num3 = num2 / splitNumber;
				if (num2 <= 0)
				{
					return 0f;
				}
				float num4 = coordinateWidth / (float)num2;
				if (axis.insertDataToHead)
				{
					int num5 = (axis.boundaryGap ? splitNumber : (splitNumber - 1));
					if (index == 1)
					{
						if (axis.axisTick.alignWithLabel)
						{
							return num4 * (float)num3;
						}
						return coordinateWidth - num4 * (float)num3 * (float)num5;
					}
					if (num2 < splitNumber)
					{
						return num4;
					}
					return num4 * (float)(num2 / splitNumber);
				}
				int num6 = (axis.boundaryGap ? (num - 1) : num);
				if (index >= num6)
				{
					if (axis.axisTick.alignWithLabel)
					{
						return num4 * (float)num3;
					}
					return coordinateWidth - num4 * (float)num3 * (float)(index - 1);
				}
				if (num2 < splitNumber)
				{
					return num4;
				}
				return num4 * (float)(num2 / splitNumber);
			}
			if (splitNumber <= 0)
			{
				return 0f;
			}
			return coordinateWidth / (float)splitNumber;
		}

		public static float GetEachWidth(Axis axis, float coordinateWidth, DataZoom dataZoom = null)
		{
			List<string> dataList = axis.GetDataList(dataZoom);
			if (dataList.Count > 0)
			{
				int num = (axis.boundaryGap ? dataList.Count : (dataList.Count - 1));
				if (num <= 0)
				{
					return coordinateWidth;
				}
				return coordinateWidth / (float)num;
			}
			int num2 = GetScaleNumber(axis, coordinateWidth, dataZoom) - 1;
			if (num2 <= 0)
			{
				return coordinateWidth;
			}
			return coordinateWidth / (float)num2;
		}

		public static void AdjustMinMaxValue(Axis axis, ref double minValue, ref double maxValue, bool needFormat, double ceilRate = 0.0)
		{
			if (axis.type == Axis.AxisType.Log)
			{
				int splitNumber = 0;
				int splitNumber2 = 0;
				maxValue = ChartHelper.GetMaxLogValue(maxValue, axis.logBase, axis.logBaseE, out splitNumber2);
				minValue = ChartHelper.GetMinLogValue(minValue, axis.logBase, axis.logBaseE, out splitNumber);
				int num = ((splitNumber > 0 && splitNumber2 > 0) ? (splitNumber2 + splitNumber - 1) : (splitNumber2 + splitNumber));
				if (num > 15)
				{
					num = 15;
				}
				axis.splitNumber = num;
			}
			else
			{
				if (axis.type == Axis.AxisType.Time)
				{
					return;
				}
				if (axis.minMaxType == Axis.AxisMinMaxType.Custom)
				{
					if (axis.min != 0.0 || axis.max != 0.0)
					{
						if (axis.inverse)
						{
							minValue = 0.0 - axis.max;
							maxValue = 0.0 - axis.min;
						}
						else
						{
							minValue = axis.min;
							maxValue = axis.max;
						}
					}
					return;
				}
				if (ceilRate == 0.0)
				{
					ceilRate = axis.ceilRate;
				}
				switch (axis.minMaxType)
				{
				case Axis.AxisMinMaxType.Default:
					if (minValue != 0.0 || maxValue != 0.0)
					{
						if (minValue > 0.0 && maxValue > 0.0)
						{
							minValue = 0.0;
							maxValue = (needFormat ? ChartHelper.GetMaxDivisibleValue(maxValue, ceilRate) : maxValue);
						}
						else if (minValue < 0.0 && maxValue < 0.0)
						{
							minValue = (needFormat ? ChartHelper.GetMinDivisibleValue(minValue, ceilRate) : minValue);
							maxValue = 0.0;
						}
						else
						{
							minValue = (needFormat ? ChartHelper.GetMinDivisibleValue(minValue, ceilRate) : minValue);
							maxValue = (needFormat ? ChartHelper.GetMaxDivisibleValue(maxValue, ceilRate) : maxValue);
						}
					}
					break;
				case Axis.AxisMinMaxType.MinMax:
					if (ceilRate != 0.0)
					{
						minValue = ChartHelper.GetMinCeilRate(minValue, ceilRate);
						maxValue = ChartHelper.GetMaxCeilRate(maxValue, ceilRate);
					}
					break;
				case Axis.AxisMinMaxType.MinMaxAuto:
					minValue = (needFormat ? ChartHelper.GetMinDivisibleValue(minValue, ceilRate) : minValue);
					maxValue = (needFormat ? ChartHelper.GetMaxDivisibleValue(maxValue, ceilRate) : maxValue);
					break;
				case Axis.AxisMinMaxType.Custom:
					break;
				}
			}
		}

		public static bool NeedShowSplit(Axis axis)
		{
			if (!axis.show)
			{
				return false;
			}
			if (axis.IsCategory() && axis.GetDataList().Count <= 0)
			{
				return false;
			}
			return true;
		}

		public static void AdjustCircleLabelPos(ChartLabel txt, Vector3 pos, Vector3 cenPos, float txtHig, Vector3 offset)
		{
			float preferredWidth = txt.text.GetPreferredWidth();
			Vector2 sizeDelta = new Vector2(preferredWidth, txt.text.GetPreferredHeight());
			txt.text.SetSizeDelta(sizeDelta);
			float num = pos.x - cenPos.x;
			if (num < -1f)
			{
				pos = new Vector3(pos.x - preferredWidth / 2f, pos.y);
			}
			else if (num > 1f)
			{
				pos = new Vector3(pos.x + preferredWidth / 2f, pos.y);
			}
			else
			{
				float y = ((pos.y > cenPos.y) ? (pos.y + txtHig / 2f) : (pos.y - txtHig / 2f));
				pos = new Vector3(pos.x, y);
			}
			txt.SetPosition(pos + offset);
		}

		public static void AdjustRadiusAxisLabelPos(ChartLabel txt, Vector3 pos, Vector3 cenPos, float txtHig, Vector3 offset)
		{
			float preferredWidth = txt.text.GetPreferredWidth();
			Vector2 sizeDelta = new Vector2(preferredWidth, txt.text.GetPreferredHeight());
			txt.text.SetSizeDelta(sizeDelta);
			float num = pos.y - cenPos.y;
			if (num > 20f)
			{
				pos = new Vector3(pos.x - preferredWidth / 2f, pos.y);
			}
			else if (num < -20f)
			{
				pos = new Vector3(pos.x + preferredWidth / 2f, pos.y);
			}
			else
			{
				float y = ((pos.y > cenPos.y) ? (pos.y + txtHig / 2f) : (pos.y - txtHig / 2f));
				pos = new Vector3(pos.x, y);
			}
			txt.SetPosition(pos);
		}

		public static float GetAxisPosition(GridCoord grid, Axis axis, double value, int dataCount = 0, DataZoom dataZoom = null)
		{
			float num = ((axis is YAxis) ? grid.context.height : grid.context.width);
			float num2 = ((axis is YAxis) ? grid.context.y : grid.context.x);
			if (axis.IsCategory())
			{
				if (dataCount == 0)
				{
					dataCount = axis.data.Count;
				}
				int num3 = (int)value;
				float dataWidth = GetDataWidth(axis, num, dataCount, dataZoom);
				return num2 + (axis.boundaryGap ? (dataWidth / 2f) : 0f) + dataWidth * (float)num3;
			}
			float num4 = ((axis.context.minMaxRange == 0.0) ? 0f : ((float)((value - axis.context.minValue) / axis.context.minMaxRange * (double)num)));
			return num2 + num4;
		}

		public static double GetAxisPositionValue(GridCoord grid, Axis axis, Vector3 pos)
		{
			if (axis is YAxis)
			{
				return GetAxisPositionValue(pos.y, grid.context.height, axis.context.minMaxRange, grid.context.y, axis.context.offset);
			}
			if (axis is XAxis)
			{
				return GetAxisPositionValue(pos.x, grid.context.width, axis.context.minMaxRange, grid.context.x, axis.context.offset);
			}
			return 0.0;
		}

		public static double GetAxisPositionValue(float xy, float axisLength, double axisRange, float axisStart, float axisOffset)
		{
			return axisRange / (double)axisLength * (double)(xy - axisStart - axisOffset);
		}

		public static float GetAxisValuePosition(GridCoord grid, Axis axis, float scaleWidth, double value)
		{
			return GetAxisPositionInternal(grid, axis, scaleWidth, value, includeGridXY: true, realLength: false);
		}

		public static float GetAxisValueDistance(GridCoord grid, Axis axis, float scaleWidth, double value)
		{
			return GetAxisPositionInternal(grid, axis, scaleWidth, value, includeGridXY: false, realLength: false);
		}

		public static float GetAxisValueLength(GridCoord grid, Axis axis, float scaleWidth, double value)
		{
			return GetAxisPositionInternal(grid, axis, scaleWidth, value, includeGridXY: false, realLength: true);
		}

		public static int GetAxisValueSplitIndex(Axis axis, double value, int totalSplitNumber = -1)
		{
			if (axis.IsCategory())
			{
				return (int)value;
			}
			if (value == axis.context.minValue)
			{
				return 0;
			}
			if (totalSplitNumber == -1)
			{
				totalSplitNumber = GetTotalSplitGridNum(axis);
			}
			if (axis.minMaxType == Axis.AxisMinMaxType.Custom)
			{
				return Mathf.CeilToInt((float)((value - axis.min) / axis.max) * (float)totalSplitNumber - 1f);
			}
			return Mathf.CeilToInt((float)((value - axis.context.minValue) / axis.context.minMaxRange) * (float)totalSplitNumber - 1f);
		}

		private static float GetAxisPositionInternal(GridCoord grid, Axis axis, float scaleWidth, double value, bool includeGridXY, bool realLength)
		{
			bool num = axis is YAxis;
			float num2 = (num ? grid.context.height : grid.context.width);
			float num3 = (num ? grid.context.y : grid.context.x);
			if (axis.IsLog())
			{
				double logMinIndex = axis.GetLogMinIndex();
				float logValue = axis.GetLogValue(value);
				if (!includeGridXY)
				{
					return (float)(((double)logValue - logMinIndex) / (double)axis.splitNumber * (double)num2);
				}
				return (float)((double)num3 + ((double)logValue - logMinIndex) / (double)axis.splitNumber * (double)num2);
			}
			if (axis.IsCategory())
			{
				int num4 = (int)value;
				if (!includeGridXY)
				{
					return (axis.boundaryGap ? (scaleWidth / 2f) : 0f) + scaleWidth * (float)num4;
				}
				return num3 + (axis.boundaryGap ? (scaleWidth / 2f) : 0f) + scaleWidth * (float)num4;
			}
			float num5 = 0f;
			if (axis.context.minMaxRange != 0.0)
			{
				num5 = ((!realLength) ? ((float)((value - axis.context.minValue) / axis.context.minMaxRange * (double)num2)) : ((float)(value * (double)num2 / axis.context.minMaxRange)));
			}
			if (!includeGridXY)
			{
				return num5;
			}
			return num3 + num5;
		}

		public static float GetAxisXOrY(GridCoord grid, Axis axis, Axis relativedAxis)
		{
			if (axis is XAxis)
			{
				return GetXAxisXOrY(grid, axis, relativedAxis);
			}
			if (axis is YAxis)
			{
				return GetYAxisXOrY(grid, axis, relativedAxis);
			}
			if (axis is SingleAxis)
			{
				return axis.context.y + axis.offset;
			}
			if (axis is ParallelAxis)
			{
				return axis.context.y;
			}
			return axis.context.x;
		}

		public static float GetXAxisXOrY(GridCoord grid, Axis xAxis, Axis relativedAxis)
		{
			float num = grid.context.y + xAxis.offset;
			if (xAxis.IsTop())
			{
				num += grid.context.height;
			}
			else if (xAxis.axisLine.onZero && relativedAxis != null && relativedAxis.IsValue() && relativedAxis.gridIndex == xAxis.gridIndex)
			{
				num += relativedAxis.context.offset;
			}
			return num;
		}

		public static float GetYAxisXOrY(GridCoord grid, Axis yAxis, Axis relativedAxis)
		{
			float num = grid.context.x + yAxis.offset;
			if (yAxis.IsRight())
			{
				num += grid.context.width;
			}
			else if (yAxis.axisLine.onZero && relativedAxis != null && relativedAxis.IsValue() && relativedAxis.gridIndex == yAxis.gridIndex)
			{
				num += relativedAxis.context.offset;
			}
			return num;
		}
	}
}
