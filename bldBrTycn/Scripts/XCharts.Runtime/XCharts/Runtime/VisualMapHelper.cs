using System;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class VisualMapHelper
	{
		public static void AutoSetLineMinMax(VisualMap visualMap, Serie serie, bool isY, Axis axis, Axis relativedAxis)
		{
			if (IsNeedGradient(visualMap) && visualMap.autoMinMax)
			{
				double num = 0.0;
				double num2 = 0.0;
				Axis axis2 = (isY ? relativedAxis : axis);
				Axis axis3 = (isY ? axis : relativedAxis);
				if (visualMap.dimension == 0)
				{
					num = (axis2.IsCategory() ? 0.0 : axis2.context.minValue);
					num2 = (axis2.IsCategory() ? ((double)(serie.dataCount - 1)) : axis2.context.maxValue);
					SetMinMax(visualMap, num, num2);
				}
				else
				{
					num = (axis3.IsCategory() ? 0.0 : axis3.context.minValue);
					num2 = (axis3.IsCategory() ? ((double)(serie.dataCount - 1)) : axis3.context.maxValue);
					SetMinMax(visualMap, num, num2);
				}
			}
		}

		public static void SetMinMax(VisualMap visualMap, double min, double max)
		{
			if (visualMap.min != min || visualMap.max != max)
			{
				if (!(max >= min))
				{
					throw new Exception("SetMinMax:max < min:" + min + "," + max);
				}
				visualMap.min = min;
				visualMap.max = max;
			}
		}

		public static void GetLineGradientColor(VisualMap visualMap, float xValue, float yValue, out Color32 startColor, out Color32 toColor)
		{
			startColor = ChartConst.clearColor32;
			toColor = ChartConst.clearColor32;
			if (visualMap.dimension == 0)
			{
				startColor = (visualMap.IsPiecewise() ? visualMap.GetColor(xValue) : visualMap.GetColor(xValue - 1f));
				toColor = (visualMap.IsPiecewise() ? startColor : visualMap.GetColor(xValue));
			}
			else
			{
				startColor = (visualMap.IsPiecewise() ? visualMap.GetColor(yValue) : visualMap.GetColor(yValue - 1f));
				toColor = (visualMap.IsPiecewise() ? startColor : visualMap.GetColor(yValue));
			}
		}

		public static Color32 GetLineGradientColor(VisualMap visualMap, Vector3 pos, GridCoord grid, Axis axis, Axis relativedAxis, Color32 defaultColor)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			if (visualMap.dimension == 0)
			{
				num2 = axis.context.minValue;
				num3 = axis.context.maxValue;
				if (axis.IsCategory() && axis.boundaryGap)
				{
					float num4 = grid.context.x + axis.context.scaleWidth / 2f;
					num = num2 + (double)((pos.x - num4) / (grid.context.width - axis.context.scaleWidth)) * (num3 - num2);
					if (visualMap.IsPiecewise())
					{
						num = (int)num;
					}
				}
				else
				{
					num = num2 + (double)((pos.x - grid.context.x) / grid.context.width) * (num3 - num2);
				}
			}
			else
			{
				num2 = relativedAxis.context.minValue;
				num3 = relativedAxis.context.maxValue;
				if (relativedAxis.IsCategory() && relativedAxis.boundaryGap)
				{
					float num5 = grid.context.y + relativedAxis.context.scaleWidth / 2f;
					num = num2 + (double)((pos.y - num5) / (grid.context.height - relativedAxis.context.scaleWidth)) * (num3 - num2);
					if (visualMap.IsPiecewise())
					{
						num = (int)num;
					}
				}
				else
				{
					num = num2 + (double)((pos.y - grid.context.y) / grid.context.height) * (num3 - num2);
				}
			}
			Color32 color = visualMap.GetColor(num);
			if (ChartHelper.IsClearColor(color))
			{
				return defaultColor;
			}
			if (color.a != 0)
			{
				color.a = defaultColor.a;
			}
			return color;
		}

		public static Color32 GetItemStyleGradientColor(ItemStyle itemStyle, Vector3 pos, BaseChart chart, Axis axis, Color32 defaultColor)
		{
			double minValue = axis.context.minValue;
			double maxValue = axis.context.maxValue;
			GridCoord chartComponent = chart.GetChartComponent<GridCoord>(axis.gridIndex);
			double num = (minValue + (double)((pos.x - chartComponent.context.x) / chartComponent.context.width) * (maxValue - minValue) - minValue) / (maxValue - minValue);
			Color32 gradientColor = itemStyle.GetGradientColor((float)num, defaultColor);
			if (ChartHelper.IsClearColor(gradientColor))
			{
				return defaultColor;
			}
			return gradientColor;
		}

		public static Color32 GetLineStyleGradientColor(LineStyle lineStyle, Vector3 pos, GridCoord grid, Axis axis, Color32 defaultColor)
		{
			double minValue = axis.context.minValue;
			double maxValue = axis.context.maxValue;
			double num = (minValue + (double)((pos.x - grid.context.x) / grid.context.width) * (maxValue - minValue) - minValue) / (maxValue - minValue);
			Color32 gradientColor = lineStyle.GetGradientColor((float)num, defaultColor);
			if (ChartHelper.IsClearColor(gradientColor))
			{
				return defaultColor;
			}
			return gradientColor;
		}

		public static bool IsNeedGradient(VisualMap visualMap)
		{
			if (visualMap == null)
			{
				return false;
			}
			if (!visualMap.show || (!visualMap.workOnLine && !visualMap.workOnArea))
			{
				return false;
			}
			if (visualMap.inRange.Count <= 0)
			{
				return false;
			}
			return true;
		}

		public static bool IsNeedLineGradient(VisualMap visualMap)
		{
			if (visualMap == null)
			{
				return false;
			}
			if (!visualMap.show || !visualMap.workOnLine)
			{
				return false;
			}
			if (visualMap.inRange.Count <= 0)
			{
				return false;
			}
			return true;
		}

		public static bool IsNeedAreaGradient(VisualMap visualMap)
		{
			if (visualMap == null)
			{
				return false;
			}
			if (!visualMap.show || !visualMap.workOnArea)
			{
				return false;
			}
			if (visualMap.inRange.Count <= 0)
			{
				return false;
			}
			return true;
		}

		public static int GetDimension(VisualMap visualMap, int defaultDimension)
		{
			if (visualMap == null || !visualMap.show)
			{
				return defaultDimension;
			}
			if (visualMap == null || visualMap.dimension < 0)
			{
				return defaultDimension;
			}
			return visualMap.dimension;
		}
	}
}
