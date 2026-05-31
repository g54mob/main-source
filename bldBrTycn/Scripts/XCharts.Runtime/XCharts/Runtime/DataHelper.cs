using System.Collections.Generic;

namespace XCharts.Runtime
{
	internal static class DataHelper
	{
		public static double DataAverage(ref List<SerieData> showData, SampleType sampleType, int minCount, int maxCount, int rate)
		{
			double result = 0.0;
			if (rate > 1 && sampleType == SampleType.Peak)
			{
				double num = 0.0;
				for (int i = minCount; i < maxCount; i++)
				{
					num += showData[i].data[1];
				}
				result = num / (double)(maxCount - minCount);
			}
			return result;
		}

		public static double SampleValue(ref List<SerieData> showData, SampleType sampleType, int rate, int minCount, int maxCount, double totalAverage, int index, float dataAddDuration, float dataChangeDuration, ref bool dataChanging, Axis axis, bool unscaledTime)
		{
			bool inverse = axis.inverse;
			double minValue = axis.context.minValue;
			double maxValue = axis.context.maxValue;
			if (rate <= 1 || index == minCount)
			{
				if (showData[index].IsDataChanged())
				{
					dataChanging = true;
				}
				return showData[index].GetCurrData(1, dataAddDuration, dataChangeDuration, inverse, minValue, maxValue, unscaledTime);
			}
			switch (sampleType)
			{
			case SampleType.Average:
			case SampleType.Sum:
			{
				double num5 = 0.0;
				int num7 = 0;
				for (int num8 = index; num8 > index - rate; num8--)
				{
					num7++;
					num5 += showData[num8].GetCurrData(1, dataAddDuration, dataChangeDuration, inverse, minValue, maxValue, unscaledTime);
					if (showData[num8].IsDataChanged())
					{
						dataChanging = true;
					}
				}
				if (sampleType == SampleType.Average)
				{
					return num5 / (double)rate;
				}
				return num5;
			}
			case SampleType.Max:
			{
				double num = double.MinValue;
				for (int num2 = index; num2 > index - rate; num2--)
				{
					double currData = showData[num2].GetCurrData(1, dataAddDuration, dataChangeDuration, inverse, minValue, maxValue, unscaledTime);
					if (currData > num)
					{
						num = currData;
					}
					if (showData[num2].IsDataChanged())
					{
						dataChanging = true;
					}
				}
				return num;
			}
			case SampleType.Min:
			{
				double num3 = double.MaxValue;
				for (int num4 = index; num4 > index - rate; num4--)
				{
					double currData2 = showData[num4].GetCurrData(1, dataAddDuration, dataChangeDuration, inverse, minValue, maxValue, unscaledTime);
					if (currData2 < num3)
					{
						num3 = currData2;
					}
					if (showData[num4].IsDataChanged())
					{
						dataChanging = true;
					}
				}
				return num3;
			}
			case SampleType.Peak:
			{
				double num = double.MinValue;
				double num3 = double.MaxValue;
				double num5 = 0.0;
				for (int num6 = index; num6 > index - rate; num6--)
				{
					double currData3 = showData[num6].GetCurrData(1, dataAddDuration, dataChangeDuration, inverse, minValue, maxValue, unscaledTime);
					num5 += currData3;
					if (currData3 < num3)
					{
						num3 = currData3;
					}
					if (currData3 > num)
					{
						num = currData3;
					}
					if (showData[num6].IsDataChanged())
					{
						dataChanging = true;
					}
				}
				if (num5 / (double)rate >= totalAverage)
				{
					return num;
				}
				return num3;
			}
			default:
				if (showData[index].IsDataChanged())
				{
					dataChanging = true;
				}
				return showData[index].GetCurrData(1, dataAddDuration, dataChangeDuration, inverse, minValue, maxValue, unscaledTime);
			}
		}
	}
}
