using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class PolarCoordHandler : MainComponentHandler<PolarCoord>
	{
		public override void Update()
		{
			base.Update();
			PolarHelper.UpdatePolarCenter(base.component, base.chart.chartPosition, base.chart.chartWidth, base.chart.chartHeight);
			if (base.chart.isPointerInChart)
			{
				base.component.context.isPointerEnter = base.component.Contains(base.chart.pointerPos);
			}
			else
			{
				base.component.context.isPointerEnter = false;
			}
		}

		public override void DrawBase(VertexHelper vh)
		{
			DrawPolar(vh, base.component);
		}

		private void DrawPolar(VertexHelper vh, PolarCoord polar)
		{
			PolarHelper.UpdatePolarCenter(polar, base.chart.chartPosition, base.chart.chartWidth, base.chart.chartHeight);
			if (polar.show && !ChartHelper.IsClearColor(polar.backgroundColor))
			{
				if (polar.context.insideRadius > 0f)
				{
					UGL.DrawDoughnut(vh, polar.context.center, polar.context.insideRadius, polar.context.outsideRadius, polar.backgroundColor, ColorUtil.clearColor32);
				}
				else
				{
					UGL.DrawCricle(vh, polar.context.center, polar.context.outsideRadius, polar.backgroundColor);
				}
			}
		}
	}
}
