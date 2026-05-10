using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class ParallelAxisHander : AxisHandler<ParallelAxis>
	{
		private Orient m_Orient;

		private ParallelCoord m_Parallel;

		protected override Orient orient => m_Orient;

		public override void InitComponent()
		{
			InitParallelAxis(base.component);
		}

		public override void Update()
		{
			UpdateContext(base.component);
		}

		public override void DrawBase(VertexHelper vh)
		{
			UpdateContext(base.component);
			DrawParallelAxisSplit(vh, base.component);
			DrawParallelAxisLine(vh, base.component);
			DrawParallelAxisTick(vh, base.component);
		}

		private void UpdateContext(ParallelAxis axis)
		{
			ParallelCoord chartComponent = base.chart.GetChartComponent<ParallelCoord>(axis.parallelIndex);
			if (chartComponent != null)
			{
				m_Orient = chartComponent.orient;
				m_Parallel = chartComponent;
				int chartComponentNum = base.chart.GetChartComponentNum<ParallelAxis>();
				if (m_Orient == Orient.Horizonal)
				{
					float num = ((chartComponentNum > 1) ? (chartComponent.context.height / (float)(chartComponentNum - 1)) : 0f);
					axis.context.x = chartComponent.context.x;
					axis.context.y = chartComponent.context.y + (float)axis.index * num;
					axis.context.width = chartComponent.context.width;
				}
				else
				{
					float num2 = ((chartComponentNum > 1) ? (chartComponent.context.width / (float)(chartComponentNum - 1)) : 0f);
					axis.context.x = chartComponent.context.x + (float)axis.index * num2;
					axis.context.y = chartComponent.context.y;
					axis.context.width = chartComponent.context.height;
				}
				axis.context.orient = m_Orient;
				axis.context.height = 0f;
				axis.context.position = new Vector3(axis.context.x, axis.context.y);
			}
		}

		private void InitParallelAxis(ParallelAxis axis)
		{
			_ = base.chart.theme;
			_ = axis.index;
			axis.painter = base.chart.painter;
			axis.refreshComponent = delegate
			{
				UpdateContext(axis);
				InitAxis(null, m_Orient, axis.context.x, axis.context.y, axis.context.width, axis.context.height);
			};
			axis.refreshComponent();
		}

		internal override void UpdateAxisLabelText(Axis axis)
		{
			base.UpdateAxisLabelText(axis);
			if (!axis.IsTime() && !axis.IsValue())
			{
				return;
			}
			for (int i = 0; i < axis.context.labelObjectList.Count; i++)
			{
				ChartLabel chartLabel = axis.context.labelObjectList[i];
				if (chartLabel != null)
				{
					Vector3 labelPosition = GetLabelPosition(0f, i);
					chartLabel.SetPosition(labelPosition);
					CheckValueLabelActive(base.component, i, chartLabel, labelPosition);
				}
			}
		}

		protected override Vector3 GetLabelPosition(float scaleWid, int i)
		{
			if (m_Parallel == null)
			{
				return Vector3.zero;
			}
			return AxisHandler<ParallelAxis>.GetLabelPosition(i, m_Orient, base.component, null, base.chart.theme.axis, scaleWid, base.component.context.x, base.component.context.y, base.component.context.width, base.component.context.height);
		}

		private void DrawParallelAxisSplit(VertexHelper vh, ParallelAxis axis)
		{
			if (AxisHelper.NeedShowSplit(axis) && m_Parallel != null)
			{
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
				DrawAxisSplit(vh, base.chart.theme.axis, dataZoomOfAxis, m_Orient, axis.context.x, axis.context.y, axis.context.width, axis.context.height);
			}
		}

		private void DrawParallelAxisTick(VertexHelper vh, ParallelAxis axis)
		{
			if (AxisHelper.NeedShowSplit(axis) && m_Parallel != null)
			{
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
				AxisHandler<ParallelAxis>.DrawAxisTick(vh, axis, base.chart.theme.axis, dataZoomOfAxis, m_Orient, axis.context.x, axis.context.y, axis.context.width);
			}
		}

		private void DrawParallelAxisLine(VertexHelper vh, ParallelAxis axis)
		{
			if (axis.show && axis.axisLine.show && m_Parallel != null)
			{
				AxisHandler<ParallelAxis>.DrawAxisLine(vh, axis, base.chart.theme.axis, m_Orient, axis.context.x, axis.context.y, axis.context.width);
			}
		}

		internal override float GetAxisLineXOrY()
		{
			return base.component.context.x;
		}
	}
}
