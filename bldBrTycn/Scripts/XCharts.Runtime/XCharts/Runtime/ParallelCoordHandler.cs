using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class ParallelCoordHandler : MainComponentHandler<ParallelCoord>
	{
		private Dictionary<int, double> m_SerieDimMin = new Dictionary<int, double>();

		private Dictionary<int, double> m_SerieDimMax = new Dictionary<int, double>();

		private double m_LastInterval;

		private int m_LastSplitNumber;

		public override void InitComponent()
		{
			ParallelCoord grid = base.component;
			grid.painter = base.chart.painter;
			grid.refreshComponent = delegate
			{
				grid.UpdateRuntimeData(base.chart);
				base.chart.OnCoordinateChanged();
			};
			grid.refreshComponent();
		}

		public override void CheckComponent(StringBuilder sb)
		{
			ParallelCoord parallelCoord = base.component;
			if (parallelCoord.left >= base.chart.chartWidth)
			{
				sb.Append("warning:grid->left > chartWidth\n");
			}
			if (parallelCoord.right >= base.chart.chartWidth)
			{
				sb.Append("warning:grid->right > chartWidth\n");
			}
			if (parallelCoord.top >= base.chart.chartHeight)
			{
				sb.Append("warning:grid->top > chartHeight\n");
			}
			if (parallelCoord.bottom >= base.chart.chartHeight)
			{
				sb.Append("warning:grid->bottom > chartHeight\n");
			}
			if (parallelCoord.left + parallelCoord.right >= base.chart.chartWidth)
			{
				sb.Append("warning:grid.left + grid.right > chartWidth\n");
			}
			if (parallelCoord.top + parallelCoord.bottom >= base.chart.chartHeight)
			{
				sb.Append("warning:grid.top + grid.bottom > chartHeight\n");
			}
		}

		public override void Update()
		{
			UpdatePointerEnter();
			UpdateParallelAxisMinMaxValue();
		}

		public override void DrawBase(VertexHelper vh)
		{
			if (!SeriesHelper.IsAnyClipSerie(base.chart.series))
			{
				DrawCoord(vh);
			}
		}

		public override void DrawUpper(VertexHelper vh)
		{
			if (SeriesHelper.IsAnyClipSerie(base.chart.series))
			{
				DrawCoord(vh);
			}
		}

		private void DrawCoord(VertexHelper vh)
		{
			ParallelCoord parallelCoord = base.component;
			if (parallelCoord.show && !ChartHelper.IsClearColor(parallelCoord.backgroundColor))
			{
				Vector2 vector = new Vector2(parallelCoord.context.x, parallelCoord.context.y);
				Vector2 vector2 = new Vector2(parallelCoord.context.x, parallelCoord.context.y + parallelCoord.context.height);
				Vector2 vector3 = new Vector2(parallelCoord.context.x + parallelCoord.context.width, parallelCoord.context.y + parallelCoord.context.height);
				UGL.DrawQuadrilateral(p4: new Vector2(parallelCoord.context.x + parallelCoord.context.width, parallelCoord.context.y), vh: vh, p1: vector, p2: vector2, p3: vector3, color: parallelCoord.backgroundColor);
			}
		}

		private void UpdatePointerEnter()
		{
			if (base.chart.isPointerInChart)
			{
				base.component.context.runtimeIsPointerEnter = base.component.Contains(base.chart.pointerPos);
			}
			else
			{
				base.component.context.runtimeIsPointerEnter = false;
			}
		}

		private void UpdateParallelAxisMinMaxValue()
		{
			if (base.chart.GetChartComponents<ParallelAxis>().Count != base.component.context.parallelAxes.Count)
			{
				base.component.context.parallelAxes.Clear();
				foreach (MainComponent chartComponent in base.chart.GetChartComponents<ParallelAxis>())
				{
					ParallelAxis parallelAxis = chartComponent as ParallelAxis;
					if (parallelAxis.parallelIndex == base.component.index)
					{
						base.component.context.parallelAxes.Add(parallelAxis);
					}
				}
			}
			m_SerieDimMin.Clear();
			m_SerieDimMax.Clear();
			foreach (Serie item in base.chart.series)
			{
				if (!(item is Parallel) || item.parallelIndex != base.component.index)
				{
					continue;
				}
				foreach (SerieData datum in item.data)
				{
					for (int i = 0; i < datum.data.Count; i++)
					{
						double num = datum.data[i];
						if (!m_SerieDimMin.ContainsKey(i))
						{
							m_SerieDimMin[i] = num;
						}
						else if (m_SerieDimMin[i] > num)
						{
							m_SerieDimMin[i] = num;
						}
						if (!m_SerieDimMax.ContainsKey(i))
						{
							m_SerieDimMax[i] = num;
						}
						else if (m_SerieDimMax[i] < num)
						{
							m_SerieDimMax[i] = num;
						}
					}
				}
			}
			for (int j = 0; j < base.component.context.parallelAxes.Count; j++)
			{
				ParallelAxis parallelAxis2 = base.component.context.parallelAxes[j];
				if (parallelAxis2.IsCategory())
				{
					m_SerieDimMax[j] = ((parallelAxis2.data.Count > 0) ? (parallelAxis2.data.Count - 1) : 0);
					m_SerieDimMin[j] = 0.0;
				}
				else if (parallelAxis2.minMaxType == Axis.AxisMinMaxType.Custom)
				{
					m_SerieDimMin[j] = parallelAxis2.min;
					m_SerieDimMax[j] = parallelAxis2.max;
				}
				else if (m_SerieDimMax.ContainsKey(j))
				{
					double minValue = m_SerieDimMin[j];
					double maxValue = m_SerieDimMax[j];
					AxisHelper.AdjustMinMaxValue(parallelAxis2, ref minValue, ref maxValue, needFormat: true);
					m_SerieDimMin[j] = minValue;
					m_SerieDimMax[j] = maxValue;
				}
			}
			for (int k = 0; k < base.component.context.parallelAxes.Count; k++)
			{
				if (m_SerieDimMax.ContainsKey(k))
				{
					ParallelAxis parallelAxis3 = base.component.context.parallelAxes[k];
					double num2 = m_SerieDimMin[k];
					double num3 = m_SerieDimMax[k];
					if (num2 != parallelAxis3.context.minValue || num3 != parallelAxis3.context.maxValue || m_LastInterval != parallelAxis3.interval || m_LastSplitNumber != parallelAxis3.splitNumber)
					{
						m_LastSplitNumber = parallelAxis3.splitNumber;
						m_LastInterval = parallelAxis3.interval;
						parallelAxis3.UpdateMinMaxValue(num2, num3);
						parallelAxis3.context.offset = 0f;
						parallelAxis3.context.lastCheckInverse = parallelAxis3.inverse;
						(parallelAxis3.handler as ParallelAxisHander).UpdateAxisTickValueList(parallelAxis3);
						(parallelAxis3.handler as ParallelAxisHander).UpdateAxisLabelText(parallelAxis3);
						base.chart.RefreshChart();
					}
				}
			}
		}
	}
}
