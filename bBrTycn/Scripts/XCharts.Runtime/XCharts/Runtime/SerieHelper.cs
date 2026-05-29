using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class SerieHelper
	{
		private static List<double> s_TempList = new List<double>();

		public static double GetMinData(Serie serie, int dimension = 1, DataZoom dataZoom = null)
		{
			double num = double.MaxValue;
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (serieData.show && serieData.data.Count > dimension)
				{
					double num2 = serieData.data[dimension];
					if (num2 < num && !serie.IsIgnoreValue(serieData, num2))
					{
						num = num2;
					}
				}
			}
			if (num != double.MaxValue)
			{
				return num;
			}
			return 0.0;
		}

		public static SerieData GetMinSerieData(Serie serie, int dimension = 1, DataZoom dataZoom = null)
		{
			double num = double.MaxValue;
			SerieData result = null;
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (serieData.show && serieData.data.Count > dimension)
				{
					double num2 = serieData.data[dimension];
					if (num2 < num && !serie.IsIgnoreValue(serieData, num2))
					{
						num = num2;
						result = serieData;
					}
				}
			}
			return result;
		}

		public static double GetMaxData(Serie serie, int dimension = 1, DataZoom dataZoom = null)
		{
			double num = double.MinValue;
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (serieData.show && serieData.data.Count > dimension)
				{
					double num2 = serieData.data[dimension];
					if (num2 > num && !serie.IsIgnoreValue(serieData, num2))
					{
						num = num2;
					}
				}
			}
			if (num != double.MinValue)
			{
				return num;
			}
			return 0.0;
		}

		public static SerieData GetMaxSerieData(Serie serie, int dimension = 1, DataZoom dataZoom = null)
		{
			double num = double.MinValue;
			SerieData result = null;
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (serieData.show && serieData.data.Count > dimension)
				{
					double num2 = serieData.data[dimension];
					if (num2 > num && !serie.IsIgnoreValue(serieData, num2))
					{
						num = num2;
						result = serieData;
					}
				}
			}
			return result;
		}

		public static double GetAverageData(Serie serie, int dimension = 1, DataZoom dataZoom = null)
		{
			double num = 0.0;
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (serieData.show && serieData.data.Count > dimension)
				{
					double num2 = serieData.data[dimension];
					if (!serie.IsIgnoreValue(serieData, num2))
					{
						num += num2;
					}
				}
			}
			if (num == 0.0)
			{
				return 0.0;
			}
			return num / (double)dataList.Count;
		}

		public static double GetMedianData(Serie serie, int dimension = 1, DataZoom dataZoom = null)
		{
			s_TempList.Clear();
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (serieData.show && serieData.data.Count > dimension)
				{
					double num = serieData.data[dimension];
					if (!serie.IsIgnoreValue(serieData, num))
					{
						s_TempList.Add(num);
					}
				}
			}
			s_TempList.Sort();
			int count = s_TempList.Count;
			if (count % 2 == 0)
			{
				return (s_TempList[count / 2] + s_TempList[count / 2 - 1]) / 2.0;
			}
			return s_TempList[count / 2];
		}

		public static void GetMinMaxData(Serie serie, int dimension, out double min, out double max, DataZoom dataZoom = null)
		{
			max = double.MinValue;
			min = double.MaxValue;
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (!serieData.show || serieData.data.Count <= dimension)
				{
					continue;
				}
				double num = serieData.data[dimension];
				if (!serie.IsIgnoreValue(serieData, num))
				{
					if (num > max)
					{
						max = num;
					}
					if (num < min)
					{
						min = num;
					}
				}
			}
			if (min == double.MaxValue && max == double.MinValue)
			{
				min = 0.0;
				max = 0.0;
			}
		}

		public static void GetMinMaxData(Serie serie, out double min, out double max, DataZoom dataZoom = null, int dimension = 0)
		{
			max = double.MinValue;
			min = double.MaxValue;
			List<SerieData> dataList = serie.GetDataList(dataZoom);
			for (int i = 0; i < dataList.Count; i++)
			{
				SerieData serieData = dataList[i];
				if (!serieData.show)
				{
					continue;
				}
				int num = 0;
				num = ((dimension <= 0) ? ((serie.showDataDimension > serieData.data.Count) ? serieData.data.Count : serie.showDataDimension) : dimension);
				for (int j = 0; j < num; j++)
				{
					double num2 = serieData.data[j];
					if (!serie.IsIgnoreValue(serieData, num2))
					{
						if (num2 > max)
						{
							max = num2;
						}
						if (num2 < min)
						{
							min = num2;
						}
					}
				}
			}
			if (min == double.MaxValue && max == double.MinValue)
			{
				min = 0.0;
				max = 0.0;
			}
		}

		public static bool IsAllZeroValue(Serie serie, int dimension = 1)
		{
			foreach (SerieData datum in serie.data)
			{
				if (datum.GetData(dimension) != 0.0)
				{
					return false;
				}
			}
			return true;
		}

		public static void UpdateCenter(Serie serie, BaseChart chart)
		{
			if (serie.center.Length >= 2)
			{
				Vector3 position = chart.chartPosition;
				float width = chart.chartWidth;
				float height = chart.chartHeight;
				if (serie.gridIndex >= 0)
				{
					chart.GetChartComponent<GridLayout>()?.UpdateGridContext(serie.gridIndex, ref position, ref width, ref height);
				}
				float x = ((serie.center[0] <= 1f) ? (width * serie.center[0]) : serie.center[0]);
				float y = ((serie.center[1] <= 1f) ? (height * serie.center[1]) : serie.center[1]);
				serie.context.center = position + new Vector3(x, y);
				float num = Mathf.Min(width, height);
				serie.context.insideRadius = ((serie.radius[0] <= 1f) ? (num * serie.radius[0]) : serie.radius[0]);
				serie.context.outsideRadius = ((serie.radius[1] <= 1f) ? (num * serie.radius[1]) : serie.radius[1]);
			}
		}

		public static void UpdateRect(Serie serie, Vector3 chartPosition, float chartWidth, float chartHeight)
		{
			if (serie.left != 0f || serie.right != 0f || serie.top != 0f || serie.bottom != 0f)
			{
				float num = ((serie.left <= 1f) ? (serie.left * chartWidth) : serie.left);
				float num2 = ((serie.bottom <= 1f) ? (serie.bottom * chartHeight) : serie.bottom);
				float num3 = ((serie.top <= 1f) ? (serie.top * chartHeight) : serie.top);
				float num4 = ((serie.right <= 1f) ? (serie.right * chartWidth) : serie.right);
				serie.context.x = chartPosition.x + num;
				serie.context.y = chartPosition.y + num2;
				serie.context.width = chartWidth - num - num4;
				serie.context.height = chartHeight - num3 - num2;
				serie.context.center = new Vector3(serie.context.x + serie.context.width / 2f, serie.context.y + serie.context.height / 2f);
				serie.context.rect = new Rect(serie.context.x, serie.context.y, serie.context.width, serie.context.height);
			}
			else
			{
				serie.context.x = chartPosition.x;
				serie.context.y = chartPosition.y;
				serie.context.width = chartWidth;
				serie.context.height = chartHeight;
				serie.context.center = chartPosition + new Vector3(chartWidth / 2f, chartHeight / 2f);
				serie.context.rect = new Rect(serie.context.x, serie.context.y, serie.context.width, serie.context.height);
			}
		}

		public static SerieState GetSerieState(Serie serie)
		{
			if (serie.highlight)
			{
				return SerieState.Emphasis;
			}
			return serie.state;
		}

		public static SerieState GetSerieState(SerieData serieData)
		{
			if (serieData.context.highlight)
			{
				return SerieState.Emphasis;
			}
			return serieData.state;
		}

		public static SerieState GetSerieState(Serie serie, SerieData serieData, bool defaultSerieState = false)
		{
			if (serieData == null)
			{
				return GetSerieState(serie);
			}
			if (serieData.context.highlight)
			{
				return SerieState.Emphasis;
			}
			if (serieData.state == SerieState.Auto)
			{
				if (!defaultSerieState)
				{
					return GetSerieState(serie);
				}
				return serie.state;
			}
			return serieData.state;
		}

		public static Color32 GetItemBackgroundColor(Serie serie, SerieData serieData, ThemeStyle theme, int index, SerieState state = SerieState.Auto, bool useDefault = false)
		{
			Color32 clearColor = ChartConst.clearColor32;
			clearColor = GetStateStyle(serie, serieData, state)?.itemStyle.backgroundColor ?? GetItemStyle(serie, serieData, SerieState.Normal).backgroundColor;
			if (useDefault && ChartHelper.IsClearColor(clearColor))
			{
				clearColor = theme.GetColor(index);
				clearColor.a = 50;
			}
			return clearColor;
		}

		public static void GetItemColor(out Color32 color, out Color32 toColor, Serie serie, SerieData serieData, ThemeStyle theme, SerieState state = SerieState.Auto)
		{
			int index = ((serieData != null && serie.colorByData) ? serieData.index : serie.context.colorIndex);
			GetItemColor(out color, out toColor, serie, serieData, theme, index, state);
		}

		public static void GetItemColor(out Color32 color, out Color32 toColor, Serie serie, SerieData serieData, ThemeStyle theme, int index, SerieState state = SerieState.Auto, bool opacity = true)
		{
			color = ColorUtil.clearColor32;
			toColor = ColorUtil.clearColor32;
			if (serie == null)
			{
				return;
			}
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle == null)
			{
				ItemStyle itemStyle = GetItemStyle(serie, serieData, SerieState.Normal);
				GetColor(ref color, itemStyle.color, itemStyle.color, itemStyle.opacity, theme, index, opacity);
				GetColor(ref toColor, itemStyle.toColor, color, itemStyle.opacity, theme, index, opacity);
				switch (state)
				{
				case SerieState.Emphasis:
					color = ChartHelper.GetHighlightColor(color);
					toColor = ChartHelper.GetHighlightColor(toColor);
					break;
				case SerieState.Blur:
					color = ChartHelper.GetBlurColor(color);
					toColor = ChartHelper.GetBlurColor(toColor);
					break;
				case SerieState.Select:
					color = ChartHelper.GetSelectColor(color);
					toColor = ChartHelper.GetSelectColor(toColor);
					break;
				}
			}
			else
			{
				GetColor(ref color, stateStyle.itemStyle.color, stateStyle.itemStyle.color, stateStyle.itemStyle.opacity, theme, index, opacity);
				GetColor(ref toColor, stateStyle.itemStyle.toColor, color, stateStyle.itemStyle.opacity, theme, index, opacity);
			}
		}

		public static void GetItemColor(out Color32 color, out Color32 toColor, out Color32 backgroundColor, Serie serie, SerieData serieData, ThemeStyle theme, int index, SerieState state = SerieState.Auto, bool opacity = true)
		{
			color = ColorUtil.clearColor32;
			toColor = ColorUtil.clearColor32;
			backgroundColor = ColorUtil.clearColor32;
			if (serie == null)
			{
				return;
			}
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle == null)
			{
				ItemStyle itemStyle = GetItemStyle(serie, serieData, SerieState.Normal);
				GetColor(ref color, itemStyle.color, itemStyle.color, itemStyle.opacity, theme, index, opacity);
				GetColor(ref toColor, itemStyle.toColor, color, itemStyle.opacity, theme, index, opacity);
				backgroundColor = itemStyle.backgroundColor;
				switch (state)
				{
				case SerieState.Emphasis:
					color = ChartHelper.GetHighlightColor(color);
					toColor = ChartHelper.GetHighlightColor(toColor);
					break;
				case SerieState.Blur:
					color = ChartHelper.GetBlurColor(color);
					toColor = ChartHelper.GetBlurColor(toColor);
					break;
				case SerieState.Select:
					color = ChartHelper.GetSelectColor(color);
					toColor = ChartHelper.GetSelectColor(toColor);
					break;
				}
			}
			else
			{
				backgroundColor = stateStyle.itemStyle.backgroundColor;
				GetColor(ref color, stateStyle.itemStyle.color, stateStyle.itemStyle.color, stateStyle.itemStyle.opacity, theme, index, opacity);
				GetColor(ref toColor, stateStyle.itemStyle.toColor, color, stateStyle.itemStyle.opacity, theme, index, opacity);
			}
		}

		public static Color32 GetItemColor(Serie serie, SerieData serieData, ThemeStyle theme, int index, SerieState state = SerieState.Auto, bool opacity = true)
		{
			Color32 color = ColorUtil.clearColor32;
			if (serie == null)
			{
				return color;
			}
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle == null || !stateStyle.itemStyle.show)
			{
				ItemStyle itemStyle = GetItemStyle(serie, serieData);
				GetColor(ref color, itemStyle.color, itemStyle.color, itemStyle.opacity, theme, index, opacity);
				switch (state)
				{
				case SerieState.Emphasis:
					color = ChartHelper.GetHighlightColor(color);
					break;
				case SerieState.Blur:
					color = ChartHelper.GetBlurColor(color);
					break;
				case SerieState.Select:
					color = ChartHelper.GetSelectColor(color);
					break;
				}
			}
			else
			{
				GetColor(ref color, stateStyle.itemStyle.color, stateStyle.itemStyle.color, stateStyle.itemStyle.opacity, theme, index, opacity);
			}
			return color;
		}

		public static bool IsDownPoint(Serie serie, int index)
		{
			List<Vector3> dataPoints = serie.context.dataPoints;
			if (dataPoints.Count < 2)
			{
				return false;
			}
			if (index > 0 && index < dataPoints.Count - 1)
			{
				Vector3 vector = dataPoints[index - 1];
				Vector3 vector2 = dataPoints[index + 1];
				Vector3 vector3 = dataPoints[index];
				return Vector3.Cross(vector2 - vector, vector3 - vector2).z < 0f;
			}
			if (index == 0)
			{
				return dataPoints[0].y < dataPoints[1].y;
			}
			if (index == dataPoints.Count - 1)
			{
				return dataPoints[index].y < dataPoints[index - 1].y;
			}
			return false;
		}

		public static ItemStyle GetItemStyle(Serie serie, SerieData serieData, SerieState state = SerieState.Auto)
		{
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle == null || !stateStyle.show)
			{
				if (serieData == null || serieData.itemStyle == null)
				{
					return serie.itemStyle;
				}
				return serieData.itemStyle;
			}
			return stateStyle.itemStyle;
		}

		public static LabelStyle GetSerieLabel(Serie serie, SerieData serieData, SerieState state = SerieState.Auto)
		{
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			if (state == SerieState.Normal)
			{
				if (serieData == null || serieData.labelStyle == null)
				{
					return serie.label;
				}
				return serieData.labelStyle;
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle != null && stateStyle.show)
			{
				return stateStyle.label;
			}
			return serie.label;
		}

		public static LabelLine GetSerieLabelLine(Serie serie, SerieData serieData, SerieState state = SerieState.Auto)
		{
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			if (state == SerieState.Normal)
			{
				if (serieData == null || serieData.labelLine == null)
				{
					return serie.labelLine;
				}
				return serieData.labelLine;
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle != null && stateStyle.show)
			{
				return stateStyle.labelLine;
			}
			return serie.labelLine;
		}

		public static SerieSymbol GetSerieSymbol(Serie serie, SerieData serieData, SerieState state = SerieState.Auto)
		{
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			if (state == SerieState.Normal)
			{
				if (serieData == null || serieData.symbol == null)
				{
					return serie.symbol;
				}
				return serieData.symbol;
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle != null && stateStyle.show)
			{
				return stateStyle.symbol;
			}
			return serie.symbol;
		}

		public static LineStyle GetLineStyle(Serie serie, SerieData serieData)
		{
			if (serieData != null && serieData.lineStyle != null)
			{
				return serieData.lineStyle;
			}
			return serie.lineStyle;
		}

		public static AreaStyle GetAreaStyle(Serie serie, SerieData serieData)
		{
			if (serieData != null && serieData.areaStyle != null)
			{
				return serieData.areaStyle;
			}
			return serie.areaStyle;
		}

		public static TitleStyle GetTitleStyle(Serie serie, SerieData serieData)
		{
			if (serieData != null && serieData.titleStyle != null)
			{
				return serieData.titleStyle;
			}
			return serie.titleStyle;
		}

		public static EmphasisStyle GetEmphasisStyle(Serie serie, SerieData serieData)
		{
			if (serieData != null && serieData.emphasisStyle != null)
			{
				return serieData.emphasisStyle;
			}
			return serie.emphasisStyle;
		}

		public static BlurStyle GetBlurStyle(Serie serie, SerieData serieData)
		{
			if (serieData != null && serieData.blurStyle != null)
			{
				return serieData.blurStyle;
			}
			return serie.blurStyle;
		}

		public static SelectStyle GetSelectStyle(Serie serie, SerieData serieData)
		{
			if (serieData != null && serieData.selectStyle != null)
			{
				return serieData.selectStyle;
			}
			return serie.selectStyle;
		}

		public static StateStyle GetStateStyle(Serie serie, SerieData serieData, SerieState state)
		{
			return state switch
			{
				SerieState.Emphasis => GetEmphasisStyle(serie, serieData), 
				SerieState.Blur => GetBlurStyle(serie, serieData), 
				SerieState.Select => GetSelectStyle(serie, serieData), 
				_ => null, 
			};
		}

		public static bool GetAreaColor(out Color32 color, out Color32 toColor, Serie serie, SerieData serieData, ThemeStyle theme, int index)
		{
			bool innerFill;
			bool toTop;
			return GetAreaColor(out color, out toColor, out innerFill, out toTop, serie, serieData, theme, index);
		}

		public static bool GetAreaColor(out Color32 color, out Color32 toColor, out bool innerFill, out bool toTop, Serie serie, SerieData serieData, ThemeStyle theme, int index)
		{
			color = ChartConst.clearColor32;
			toColor = ChartConst.clearColor32;
			innerFill = false;
			toTop = true;
			SerieState serieState = GetSerieState(serie, serieData);
			StateStyle stateStyle = GetStateStyle(serie, serieData, serieState);
			if (stateStyle == null)
			{
				AreaStyle areaStyle = GetAreaStyle(serie, serieData);
				if (areaStyle == null || !areaStyle.show)
				{
					return false;
				}
				innerFill = areaStyle.innerFill;
				toTop = areaStyle.toTop;
				GetColor(ref color, areaStyle.color, serie.itemStyle.color, areaStyle.opacity, theme, index);
				GetColor(ref toColor, areaStyle.toColor, color, areaStyle.opacity, theme, index);
				switch (serieState)
				{
				case SerieState.Emphasis:
					color = ChartHelper.GetHighlightColor(color);
					toColor = ChartHelper.GetHighlightColor(toColor);
					break;
				case SerieState.Blur:
					color = ChartHelper.GetBlurColor(color);
					toColor = ChartHelper.GetBlurColor(toColor);
					break;
				case SerieState.Select:
					color = ChartHelper.GetSelectColor(color);
					toColor = ChartHelper.GetSelectColor(toColor);
					break;
				}
			}
			else
			{
				if (!stateStyle.areaStyle.show)
				{
					return false;
				}
				innerFill = stateStyle.areaStyle.innerFill;
				toTop = stateStyle.areaStyle.toTop;
				GetColor(ref color, stateStyle.areaStyle.color, stateStyle.itemStyle.color, stateStyle.areaStyle.opacity, theme, index);
				GetColor(ref color, stateStyle.areaStyle.toColor, color, stateStyle.areaStyle.opacity, theme, index);
			}
			return true;
		}

		public static Color32 GetLineColor(Serie serie, SerieData serieData, ThemeStyle theme, int index, SerieState state = SerieState.Auto)
		{
			Color32 color = ChartConst.clearColor32;
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle == null)
			{
				LineStyle lineStyle = GetLineStyle(serie, serieData);
				GetColor(ref color, lineStyle.color, serie.itemStyle.color, lineStyle.opacity, theme, index);
				return state switch
				{
					SerieState.Emphasis => ChartHelper.GetHighlightColor(color), 
					SerieState.Blur => ChartHelper.GetBlurColor(color), 
					SerieState.Select => ChartHelper.GetSelectColor(color), 
					_ => color, 
				};
			}
			GetColor(ref color, stateStyle.lineStyle.color, stateStyle.itemStyle.color, stateStyle.lineStyle.opacity, theme, index);
			return color;
		}

		private static void GetColor(ref Color32 color, Color32 checkColor, Color32 itemColor, float opacity, ThemeStyle theme, int colorIndex, bool setOpacity = true)
		{
			if (!ChartHelper.IsClearColor(checkColor))
			{
				color = checkColor;
			}
			else if (!ChartHelper.IsClearColor(itemColor))
			{
				color = itemColor;
			}
			if (ChartHelper.IsClearColor(color) && colorIndex >= 0)
			{
				color = theme.GetColor(colorIndex);
			}
			if (setOpacity)
			{
				ChartHelper.SetColorOpacity(ref color, opacity);
			}
		}

		public static void GetSymbolInfo(out Color32 borderColor, out float border, out float[] cornerRadius, Serie serie, SerieData serieData, ThemeStyle theme, SerieState state = SerieState.Auto)
		{
			borderColor = ChartConst.clearColor32;
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			if (stateStyle == null)
			{
				ItemStyle itemStyle = GetItemStyle(serie, serieData, SerieState.Normal);
				border = ((itemStyle.borderWidth != 0f) ? itemStyle.borderWidth : (serie.lineStyle.GetWidth(theme.serie.lineWidth) * 1.8f));
				cornerRadius = itemStyle.cornerRadius;
				GetColor(ref borderColor, itemStyle.borderColor, itemStyle.borderColor, 1f, theme, -1);
				switch (state)
				{
				case SerieState.Emphasis:
					borderColor = ChartHelper.GetHighlightColor(borderColor);
					break;
				case SerieState.Blur:
					borderColor = ChartHelper.GetBlurColor(borderColor);
					break;
				case SerieState.Select:
					borderColor = ChartHelper.GetSelectColor(borderColor);
					break;
				}
			}
			else
			{
				ItemStyle itemStyle2 = stateStyle.itemStyle;
				border = ((itemStyle2.borderWidth != 0f) ? itemStyle2.borderWidth : (stateStyle.lineStyle.GetWidth(theme.serie.lineWidth) * 1.8f));
				cornerRadius = itemStyle2.cornerRadius;
				GetColor(ref borderColor, stateStyle.itemStyle.borderColor, ColorUtil.clearColor32, 1f, theme, -1);
			}
		}

		public static float GetSysmbolSize(Serie serie, SerieData serieData, float defaultSize, SerieState state = SerieState.Auto, bool checkAnimation = false)
		{
			if (serie == null)
			{
				return defaultSize;
			}
			if (state == SerieState.Auto)
			{
				state = GetSerieState(serie, serieData);
			}
			StateStyle stateStyle = GetStateStyle(serie, serieData, state);
			float num = 0f;
			if (stateStyle == null)
			{
				num = GetSerieSymbol(serie, serieData, SerieState.Normal).GetSize(serieData?.data, defaultSize);
				if (state == SerieState.Emphasis || state == SerieState.Select)
				{
					num = serie.animation.interaction.GetRadius(num);
				}
			}
			else
			{
				num = stateStyle.symbol.GetSize(serieData?.data, defaultSize);
			}
			if (serieData != null && checkAnimation)
			{
				num = (float)serieData.GetAddAnimationData(0.0, num, serie.animation.GetAdditionDuration());
			}
			return num;
		}

		public static string GetNumericFormatter(Serie serie, SerieData serieData, string defaultFormatter = null)
		{
			ItemStyle itemStyle = GetItemStyle(serie, serieData);
			if (!string.IsNullOrEmpty(itemStyle.numericFormatter))
			{
				return itemStyle.numericFormatter;
			}
			return defaultFormatter;
		}

		public static string GetItemFormatter(Serie serie, SerieData serieData, string defaultFormatter = null)
		{
			ItemStyle itemStyle = GetItemStyle(serie, serieData);
			if (!string.IsNullOrEmpty(itemStyle.itemFormatter))
			{
				return itemStyle.itemFormatter;
			}
			return defaultFormatter;
		}

		public static string GetItemMarker(Serie serie, SerieData serieData, string defaultMarker = null)
		{
			ItemStyle itemStyle = GetItemStyle(serie, serieData);
			if (!string.IsNullOrEmpty(itemStyle.itemMarker))
			{
				return itemStyle.itemMarker;
			}
			return defaultMarker;
		}

		public static void UpdateMinMaxData(Serie serie, int dimension, double ceilRate = 0.0, DataZoom dataZoom = null)
		{
			double min = 0.0;
			double max = 0.0;
			GetMinMaxData(serie, dimension, out min, out max, dataZoom);
			if (ceilRate < 0.0)
			{
				serie.context.dataMin = min;
				serie.context.dataMax = max;
			}
			else
			{
				serie.context.dataMin = ChartHelper.GetMinDivisibleValue(min, ceilRate);
				serie.context.dataMax = ChartHelper.GetMaxDivisibleValue(max, ceilRate);
			}
		}

		public static void GetAllMinMaxData(Serie serie, double ceilRate = 0.0, DataZoom dataZoom = null)
		{
			double min = 0.0;
			double max = 0.0;
			GetMinMaxData(serie, out min, out max, dataZoom);
			if (ceilRate < 0.0)
			{
				serie.context.dataMin = min;
				serie.context.dataMax = max;
			}
			else
			{
				serie.context.dataMin = ChartHelper.GetMinDivisibleValue(min, ceilRate);
				serie.context.dataMax = ChartHelper.GetMaxDivisibleValue(max, ceilRate);
			}
		}

		public static void UpdateFilterData(Serie serie, DataZoom dataZoom)
		{
			if (dataZoom == null || !dataZoom.enable)
			{
				serie.m_NeedUpdateFilterData = true;
				serie.context.dataZoomStartIndex = 0;
				serie.context.dataZoomStartIndexOffset = 0;
			}
			else if (dataZoom.IsContainsXAxis(serie.xAxisIndex))
			{
				if (dataZoom.IsXAxisIndexValue(serie.xAxisIndex))
				{
					double min = 0.0;
					double max = 0.0;
					dataZoom.GetXAxisIndexValue(serie.xAxisIndex, out min, out max);
					UpdateFilterData_XAxisValue(serie, dataZoom, 0, min, max);
				}
				else
				{
					UpdateFilterData_Category(serie, dataZoom);
				}
			}
			else if (dataZoom.IsContainsYAxis(serie.yAxisIndex))
			{
				if (dataZoom.IsYAxisIndexValue(serie.yAxisIndex))
				{
					double min2 = 0.0;
					double max2 = 0.0;
					dataZoom.GetYAxisIndexValue(serie.yAxisIndex, out min2, out max2);
					UpdateFilterData_XAxisValue(serie, dataZoom, 0, min2, max2);
				}
				else
				{
					UpdateFilterData_Category(serie, dataZoom);
				}
			}
		}

		private static void UpdateFilterData_XAxisValue(Serie serie, DataZoom dataZoom, int dimension, double min, double max)
		{
			List<SerieData> data = serie.data;
			double num = max;
			if (num < min)
			{
				num = min;
			}
			if (min != serie.m_FilterStartValue || num != serie.m_FilterEndValue || dataZoom.minShowNum != serie.m_FilterMinShow || serie.m_NeedUpdateFilterData)
			{
				serie.m_FilterStartValue = min;
				serie.m_FilterEndValue = num;
				serie.m_FilterMinShow = dataZoom.minShowNum;
				serie.m_NeedUpdateFilterData = false;
				if (serie.m_FilterData == data)
				{
					serie.m_FilterData = new List<SerieData>();
				}
				serie.m_FilterData.Clear();
				{
					foreach (SerieData item in data)
					{
						double data2 = item.GetData(dimension);
						if (data2 >= min && data2 <= num)
						{
							serie.m_FilterData.Add(item);
						}
					}
					return;
				}
			}
			if (num == 0.0)
			{
				if (serie.m_FilterData == null)
				{
					serie.m_FilterData = new List<SerieData>();
				}
				else if (serie.m_FilterData.Count > 0)
				{
					serie.m_FilterData.Clear();
				}
			}
		}

		private static void UpdateFilterData_Category(Serie serie, DataZoom dataZoom)
		{
			List<SerieData> data = serie.data;
			int num = Mathf.RoundToInt((float)data.Count * (dataZoom.end - dataZoom.start) / 100f);
			if (num <= 0)
			{
				num = 1;
			}
			int num2 = 0;
			int num3 = 0;
			if (dataZoom.context.invert)
			{
				num3 = Mathf.RoundToInt((float)data.Count * dataZoom.end / 100f);
				num2 = num3 - num;
				if (num2 < 0)
				{
					num2 = 0;
				}
			}
			else
			{
				num2 = Mathf.RoundToInt((float)data.Count * dataZoom.start / 100f);
				num3 = num2 + num;
				if (num3 > data.Count)
				{
					num3 = data.Count;
				}
			}
			if (num2 != serie.m_FilterStart || num3 != serie.m_FilterEnd || dataZoom.minShowNum != serie.m_FilterMinShow || serie.m_NeedUpdateFilterData)
			{
				serie.m_FilterStart = num2;
				serie.m_FilterEnd = num3;
				serie.m_FilterMinShow = dataZoom.minShowNum;
				serie.m_NeedUpdateFilterData = false;
				if (data.Count > 0)
				{
					if (num < dataZoom.minShowNum)
					{
						num = ((dataZoom.minShowNum <= data.Count) ? dataZoom.minShowNum : data.Count);
					}
					if (num > data.Count - num2)
					{
						num2 = data.Count - num;
					}
					if (num2 >= 0)
					{
						serie.context.dataZoomStartIndex = num2;
						serie.context.dataZoomStartIndexOffset = 0;
						serie.m_FilterData = data.GetRange(num2, num);
						int count = serie.m_FilterData.Count;
						if (count <= 0)
						{
							return;
						}
						if (serie.IsIgnoreValue(serie.m_FilterData[count - 1]))
						{
							for (int i = num2 + num; i < data.Count; i++)
							{
								serie.m_FilterData.Add(data[i]);
								if (!serie.IsIgnoreValue(data[i]))
								{
									break;
								}
							}
						}
						if (!serie.IsIgnoreValue(serie.m_FilterData[0]))
						{
							return;
						}
						int num4 = num2 - 1;
						while (num4 >= 0)
						{
							serie.m_FilterData.Insert(0, data[num4]);
							serie.context.dataZoomStartIndexOffset++;
							if (serie.IsIgnoreValue(data[num4]))
							{
								num4--;
								continue;
							}
							break;
						}
					}
					else
					{
						serie.context.dataZoomStartIndex = 0;
						serie.context.dataZoomStartIndexOffset = 0;
						serie.m_FilterData = data;
					}
				}
				else
				{
					serie.context.dataZoomStartIndex = 0;
					serie.context.dataZoomStartIndexOffset = 0;
					serie.m_FilterData = data;
				}
			}
			else if (num3 == 0)
			{
				serie.context.dataZoomStartIndex = 0;
				serie.context.dataZoomStartIndexOffset = 0;
				if (serie.m_FilterData == null)
				{
					serie.m_FilterData = new List<SerieData>();
				}
				else if (serie.m_FilterData.Count > 0)
				{
					serie.m_FilterData.Clear();
				}
			}
		}

		public static void UpdateSerieRuntimeFilterData(Serie serie, bool filterInvisible = true)
		{
			serie.context.sortedData.Clear();
			foreach (SerieData datum in serie.data)
			{
				if (!filterInvisible || (filterInvisible && datum.show))
				{
					serie.context.sortedData.Add(datum);
				}
			}
			switch (serie.dataSortType)
			{
			case SerieDataSortType.Ascending:
				serie.context.sortedData.Sort(delegate(SerieData data1, SerieData data2)
				{
					double data3 = data1.GetData(1);
					double data4 = data2.GetData(1);
					if (data3 == data4)
					{
						return 0;
					}
					return (data3 > data4) ? 1 : (-1);
				});
				break;
			case SerieDataSortType.Descending:
				serie.context.sortedData.Sort(delegate(SerieData data1, SerieData data2)
				{
					double data3 = data1.GetData(1);
					double data4 = data2.GetData(1);
					if (data3 == data4)
					{
						return 0;
					}
					return (!(data3 > data4)) ? 1 : (-1);
				});
				break;
			case SerieDataSortType.None:
				break;
			}
		}

		public static T CloneSerie<T>(Serie serie) where T : Serie
		{
			T val = Activator.CreateInstance<T>();
			CopySerie(serie, val);
			return val;
		}

		public static void CopySerie(Serie oldSerie, Serie newSerie)
		{
			FieldInfo[] fields = typeof(Serie).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.IsDefined(typeof(SerializeField), inherit: false))
				{
					object value = fieldInfo.GetValue(oldSerie);
					if (value != null && value.GetType().IsClass)
					{
						fieldInfo.SetValue(newSerie, ReflectionUtil.DeepCloneSerializeField(value));
					}
				}
			}
		}
	}
}
