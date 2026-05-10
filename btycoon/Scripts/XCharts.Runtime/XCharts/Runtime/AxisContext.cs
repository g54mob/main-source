using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	public class AxisContext : MainComponentContext
	{
		public Orient orient;

		public float x;

		public float y;

		public float zeroX;

		public float zeroY;

		public float width;

		public float height;

		public Vector3 position;

		public float left;

		public float right;

		public float bottom;

		public float top;

		public double minValue;

		public double maxValue;

		public float offset;

		public double minMaxRange;

		public double tickValue;

		public float scaleWidth;

		public float startAngle;

		public double pointerValue;

		public Vector3 pointerLabelPosition;

		public double axisTooltipValue;

		public TextAnchor aligment;

		public int dataZoomStartIndex;

		internal List<string> filterData;

		internal bool lastCheckInverse;

		internal bool isNeedUpdateFilterData;

		private int filterStart;

		private int filterEnd;

		private int filterMinShow;

		private List<ChartLabel> m_AxisLabelList = new List<ChartLabel>();

		private List<double> m_LabelValueList = new List<double>();

		private List<string> m_RuntimeData = new List<string>();

		private List<string> m_EmptyFliter = new List<string>();

		public List<string> runtimeData => m_RuntimeData;

		public List<double> labelValueList => m_LabelValueList;

		public List<ChartLabel> labelObjectList => m_AxisLabelList;

		internal void Clear()
		{
			m_RuntimeData.Clear();
		}

		internal void UpdateFilterData(List<string> data, DataZoom dataZoom)
		{
			int num = 0;
			int num2 = 0;
			int num3 = Mathf.RoundToInt((float)data.Count * (dataZoom.end - dataZoom.start) / 100f);
			if (num3 <= 0)
			{
				num3 = 1;
			}
			if (dataZoom.context.invert)
			{
				num2 = Mathf.RoundToInt((float)data.Count * dataZoom.end / 100f);
				num = num2 - num3;
				if (num < 0)
				{
					num = 0;
				}
			}
			else
			{
				num = Mathf.RoundToInt((float)data.Count * dataZoom.start / 100f);
				num2 = num + num3;
				if (num2 > data.Count)
				{
					num2 = data.Count;
				}
			}
			if (num != filterStart || num2 != filterEnd || dataZoom.minShowNum != filterMinShow || isNeedUpdateFilterData)
			{
				filterStart = num;
				filterEnd = num2;
				filterMinShow = dataZoom.minShowNum;
				isNeedUpdateFilterData = false;
				if (data.Count > 0)
				{
					if (num3 < dataZoom.minShowNum)
					{
						num3 = ((dataZoom.minShowNum <= data.Count) ? dataZoom.minShowNum : data.Count);
					}
					if (num3 > data.Count - num)
					{
						num = data.Count - num3;
					}
					if (num >= 0)
					{
						dataZoomStartIndex = num;
						filterData = data.GetRange(num, num3);
					}
					else
					{
						dataZoomStartIndex = 0;
						filterData = data;
					}
				}
				else
				{
					dataZoomStartIndex = 0;
					filterData = data;
				}
			}
			else if (num2 == 0)
			{
				dataZoomStartIndex = 0;
				filterData = m_EmptyFliter;
			}
		}
	}
}
