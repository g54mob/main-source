namespace XCharts.Runtime
{
	public static class DataZoomHelper
	{
		public static void UpdateDataZoomRuntimeStartEndValue(DataZoom dataZoom, Serie serie)
		{
			if (dataZoom != null && serie != null)
			{
				double min = 0.0;
				double max = 0.0;
				SerieHelper.GetMinMaxData(serie, out min, out max);
				dataZoom.context.startValue = min + (max - min) * (double)dataZoom.start / 100.0;
				dataZoom.context.endValue = min + (max - min) * (double)dataZoom.end / 100.0;
			}
		}

		public static void UpdateDataZoomRuntimeStartEndValue<T>(BaseChart chart) where T : Serie
		{
			foreach (MainComponent component in chart.components)
			{
				if (!(component is DataZoom))
				{
					continue;
				}
				DataZoom dataZoom = component as DataZoom;
				if (!dataZoom.enable)
				{
					continue;
				}
				double num = double.MaxValue;
				double num2 = double.MinValue;
				foreach (Serie item in chart.series)
				{
					if (!item.show || !(item is T) || !dataZoom.IsContainsXAxis(item.xAxisIndex))
					{
						continue;
					}
					XAxis chartComponent = chart.GetChartComponent<XAxis>(item.xAxisIndex);
					if (chartComponent.minMaxType == Axis.AxisMinMaxType.Custom)
					{
						if (chartComponent.min < num)
						{
							num = chartComponent.min;
						}
						if (chartComponent.max > num2)
						{
							num2 = chartComponent.max;
						}
						continue;
					}
					double min = 0.0;
					double max = 0.0;
					SerieHelper.GetMinMaxData(item, out min, out max, null, 2);
					if (min < num)
					{
						num = min;
					}
					if (max > num2)
					{
						num2 = max;
					}
				}
				dataZoom.context.startValue = num + (num2 - num) * (double)dataZoom.start / 100.0;
				dataZoom.context.endValue = num + (num2 - num) * (double)dataZoom.end / 100.0;
			}
		}
	}
}
