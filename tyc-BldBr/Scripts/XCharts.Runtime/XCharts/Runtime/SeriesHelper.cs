using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class SeriesHelper
	{
		private static HashSet<string> _setForStack = new HashSet<string>();

		private static Dictionary<string, int> sets = new Dictionary<string, int>();

		private static Dictionary<int, List<Serie>> _stackSeriesForMinMax = new Dictionary<int, List<Serie>>();

		private static Dictionary<int, double> _serieTotalValueForMinMax = new Dictionary<int, double>();

		private static DataZoom xDataZoom;

		private static DataZoom yDataZoom;

		public static bool IsLegalLegendName(string name)
		{
			int result = -1;
			if (int.TryParse(name, out result) && result >= 0 && result < 100)
			{
				return false;
			}
			return true;
		}

		public static List<string> GetLegalSerieNameList(List<Serie> series)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < series.Count; i++)
			{
				Serie serie = series[i];
				if (serie.placeHolder)
				{
					continue;
				}
				if (serie.colorByData)
				{
					for (int j = 0; j < serie.data.Count; j++)
					{
						string name = serie.data[j].name;
						if (!string.IsNullOrEmpty(name) && IsLegalLegendName(name) && !list.Contains(name))
						{
							list.Add(name);
						}
					}
				}
				else if (!string.IsNullOrEmpty(serie.serieName) && !list.Contains(serie.serieName) && IsLegalLegendName(serie.serieName))
				{
					list.Add(serie.serieName);
				}
			}
			return list;
		}

		public static void UpdateSerieNameList(BaseChart chart, ref List<string> serieNameList)
		{
			serieNameList.Clear();
			for (int i = 0; i < chart.series.Count; i++)
			{
				Serie serie = chart.series[i];
				if (serie.placeHolder)
				{
					continue;
				}
				if (serie.colorByData)
				{
					for (int j = 0; j < serie.data.Count; j++)
					{
						SerieData serieData = serie.data[j];
						if (!(serie is Pie) || !serie.IsIgnoreValue(serieData))
						{
							if (string.IsNullOrEmpty(serieData.name))
							{
								serieNameList.Add(ChartCached.IntToStr(j));
							}
							else if (!serieNameList.Contains(serieData.name))
							{
								serieNameList.Add(serieData.name);
							}
						}
					}
				}
				else if (string.IsNullOrEmpty(serie.serieName))
				{
					serieNameList.Add(ChartCached.IntToStr(i));
				}
				else if (!serieNameList.Contains(serie.serieName))
				{
					serieNameList.Add(serie.serieName);
				}
			}
		}

		public static Color GetNameColor(BaseChart chart, int index, string name)
		{
			Serie serie = null;
			SerieData serieData = null;
			List<Serie> series = chart.series;
			for (int i = 0; i < series.Count; i++)
			{
				Serie serie2 = series[i];
				if (serie2.placeHolder)
				{
					continue;
				}
				if (serie2.colorByData)
				{
					bool flag = false;
					for (int j = 0; j < serie2.data.Count; j++)
					{
						if (name.Equals(serie2.data[j].name))
						{
							serie = serie2;
							serieData = serie2.data[j];
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (name.Equals(serie2.serieName))
				{
					serie = serie2;
					serieData = null;
					break;
				}
			}
			ItemStyle itemStyle = SerieHelper.GetItemStyle(serie, serieData, SerieState.Normal);
			if (ChartHelper.IsClearColor(itemStyle.markColor))
			{
				SerieHelper.GetItemColor(out var color, out var _, serie, serieData, chart.theme, index, SerieState.Normal);
				return color;
			}
			return itemStyle.markColor;
		}

		public static bool IsAnyClipSerie(List<Serie> series)
		{
			foreach (Serie item in series)
			{
				if (item.clip)
				{
					return true;
				}
			}
			return false;
		}

		public static Serie GetLastStackSerie(List<Serie> series, Serie serie)
		{
			if (serie == null || string.IsNullOrEmpty(serie.stack))
			{
				return null;
			}
			for (int num = serie.index - 1; num >= 0; num--)
			{
				Serie serie2 = series[num];
				if (serie2.show && serie.stack.Equals(serie2.stack))
				{
					return serie2;
				}
			}
			return null;
		}

		public static bool IsStack(List<Serie> series)
		{
			_setForStack.Clear();
			foreach (Serie item in series)
			{
				if (!string.IsNullOrEmpty(item.stack))
				{
					if (_setForStack.Contains(item.stack))
					{
						return true;
					}
					_setForStack.Add(item.stack);
				}
			}
			return false;
		}

		public static bool IsStack<T>(List<Serie> series, string stackName) where T : Serie
		{
			if (string.IsNullOrEmpty(stackName))
			{
				return false;
			}
			int num = 0;
			foreach (Serie item in series)
			{
				if (item.show && item is T)
				{
					if (stackName.Equals(item.stack))
					{
						num++;
					}
					if (num >= 2)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsPercentStack<T>(List<Serie> series) where T : Serie
		{
			int num = 0;
			bool flag = false;
			foreach (Serie item in series)
			{
				if (!item.show || !(item is T))
				{
					continue;
				}
				if (!string.IsNullOrEmpty(item.stack))
				{
					num++;
					if (item.barPercentStack)
					{
						flag = true;
					}
				}
				if (num >= 2 && flag)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPercentStack<T>(List<Serie> series, string stackName) where T : Serie
		{
			if (string.IsNullOrEmpty(stackName))
			{
				return false;
			}
			int num = 0;
			bool flag = false;
			foreach (Serie item in series)
			{
				if (!item.show || !(item is T))
				{
					continue;
				}
				if (stackName.Equals(item.stack))
				{
					num++;
					if (item.barPercentStack)
					{
						flag = true;
					}
				}
				if (num >= 2 && flag)
				{
					return true;
				}
			}
			return false;
		}

		public static void GetStackSeries(List<Serie> series, ref Dictionary<int, List<Serie>> stackSeries)
		{
			int num = 0;
			int count = series.Count;
			sets.Clear();
			if (stackSeries == null)
			{
				stackSeries = new Dictionary<int, List<Serie>>(count);
			}
			else
			{
				foreach (KeyValuePair<int, List<Serie>> item in stackSeries)
				{
					item.Value.Clear();
				}
			}
			for (int i = 0; i < count; i++)
			{
				Serie serie = series[i];
				serie.index = i;
				if (string.IsNullOrEmpty(serie.stack))
				{
					if (!stackSeries.ContainsKey(num))
					{
						stackSeries[num] = new List<Serie>(count);
					}
					stackSeries[num].Add(serie);
					num++;
				}
				else if (!sets.ContainsKey(serie.stack))
				{
					sets.Add(serie.stack, num);
					if (!stackSeries.ContainsKey(num))
					{
						stackSeries[num] = new List<Serie>(count);
					}
					stackSeries[num].Add(serie);
					num++;
				}
				else
				{
					int key = sets[serie.stack];
					stackSeries[key].Add(serie);
				}
			}
		}

		public static void UpdateStackDataList(List<Serie> series, Serie currSerie, DataZoom dataZoom, List<List<SerieData>> dataList)
		{
			dataList.Clear();
			for (int i = 0; i <= currSerie.index; i++)
			{
				Serie serie = series[i];
				if (serie.show && serie.GetType() == currSerie.GetType() && ChartHelper.IsValueEqualsString(serie.stack, currSerie.stack))
				{
					dataList.Add(serie.GetDataList(dataZoom));
				}
			}
		}

		public static void GetXMinMaxValue(BaseChart chart, int axisIndex, bool isValueAxis, bool inverse, out double minValue, out double maxValue, bool isPolar = false, bool filterByDataZoom = true)
		{
			GetMinMaxValue(chart, axisIndex, isValueAxis, inverse, yValue: false, out minValue, out maxValue, isPolar, filterByDataZoom);
		}

		public static void GetYMinMaxValue(BaseChart chart, int axisIndex, bool isValueAxis, bool inverse, out double minValue, out double maxValue, bool isPolar = false, bool filterByDataZoom = true)
		{
			GetMinMaxValue(chart, axisIndex, isValueAxis, inverse, yValue: true, out minValue, out maxValue, isPolar, filterByDataZoom);
		}

		public static void GetMinMaxValue(BaseChart chart, int axisIndex, bool isValueAxis, bool inverse, bool yValue, out double minValue, out double maxValue, bool isPolar = false, bool filterByDataZoom = true)
		{
			double num = double.MaxValue;
			double num2 = double.MinValue;
			List<Serie> series = chart.series;
			bool flag = IsPercentStack<Bar>(series);
			if (!IsStack(series))
			{
				for (int i = 0; i < series.Count; i++)
				{
					Serie serie = series[i];
					if ((isPolar && serie.polarIndex != axisIndex) || (!isPolar && serie.yAxisIndex != axisIndex) || !serie.show)
					{
						continue;
					}
					float changeDuration = serie.animation.GetChangeDuration();
					float additionDuration = serie.animation.GetAdditionDuration();
					bool unscaledTime = serie.animation.unscaledTime;
					if (flag && IsPercentStack<Bar>(series, serie.serieName))
					{
						if (100.0 > num2)
						{
							num2 = 100.0;
						}
						if (0.0 < num)
						{
							num = 0.0;
						}
						continue;
					}
					List<SerieData> dataList = serie.GetDataList(filterByDataZoom ? chart.GetXDataZoomOfSerie(serie) : null);
					if (serie is Candlestick || serie is SimplifiedCandlestick)
					{
						foreach (SerieData item in dataList)
						{
							item.GetMinMaxData(1, inverse, out var min, out var max);
							if (max > num2)
							{
								num2 = max;
							}
							if (min < num)
							{
								num = min;
							}
						}
						continue;
					}
					bool flag2 = serie.IsPerformanceMode();
					foreach (SerieData item2 in dataList)
					{
						double num3 = (flag2 ? item2.GetData(yValue ? 1 : 0, inverse) : item2.GetCurrData(yValue ? 1 : 0, additionDuration, changeDuration, unscaledTime, inverse));
						if (!serie.IsIgnoreValue(item2, num3))
						{
							if (num3 > num2)
							{
								num2 = num3;
							}
							if (num3 < num)
							{
								num = num3;
							}
						}
					}
				}
			}
			else
			{
				GetStackSeries(series, ref _stackSeriesForMinMax);
				foreach (KeyValuePair<int, List<Serie>> item3 in _stackSeriesForMinMax)
				{
					_serieTotalValueForMinMax.Clear();
					for (int j = 0; j < item3.Value.Count; j++)
					{
						Serie serie2 = item3.Value[j];
						if ((isPolar && serie2.polarIndex != axisIndex) || (!isPolar && serie2.yAxisIndex != axisIndex) || !serie2.show)
						{
							continue;
						}
						List<SerieData> dataList2 = serie2.GetDataList(filterByDataZoom ? chart.GetXDataZoomOfSerie(serie2) : null);
						if (IsPercentStack<Bar>(series, serie2.stack))
						{
							for (int k = 0; k < dataList2.Count; k++)
							{
								_serieTotalValueForMinMax[k] = 100.0;
							}
							continue;
						}
						float changeDuration2 = serie2.animation.GetChangeDuration();
						float additionDuration2 = serie2.animation.GetAdditionDuration();
						bool unscaledTime2 = serie2.animation.unscaledTime;
						for (int l = 0; l < dataList2.Count; l++)
						{
							if (!_serieTotalValueForMinMax.ContainsKey(l))
							{
								_serieTotalValueForMinMax[l] = 0.0;
							}
							double num4 = 0.0;
							num4 = ((!(serie2 is Candlestick)) ? dataList2[l].GetCurrData(yValue ? 1 : 0, additionDuration2, changeDuration2, unscaledTime2, inverse) : dataList2[l].GetMaxData());
							if (!serie2.IsIgnoreValue(dataList2[l], num4))
							{
								_serieTotalValueForMinMax[l] += num4;
							}
						}
					}
					double num5 = double.MinValue;
					double num6 = double.MaxValue;
					foreach (KeyValuePair<int, double> item4 in _serieTotalValueForMinMax)
					{
						if (item4.Value > num5)
						{
							num5 = item4.Value;
						}
						if (item4.Value < num6)
						{
							num6 = item4.Value;
						}
					}
					if (num5 > num2)
					{
						num2 = num5;
					}
					if (num6 < num)
					{
						num = num6;
					}
				}
			}
			if (num2 == double.MinValue && num == double.MaxValue)
			{
				minValue = 0.0;
				maxValue = 0.0;
			}
			else if (num == 0.0 && num2 == 0.0)
			{
				minValue = 0.0;
				maxValue = 1.0;
			}
			else
			{
				minValue = num;
				maxValue = num2;
			}
		}

		public static int GetMaxSerieDataCount(List<Serie> series)
		{
			int num = 0;
			foreach (Serie item in series)
			{
				if (item.dataCount > num)
				{
					num = item.dataCount;
				}
			}
			return num;
		}
	}
}
