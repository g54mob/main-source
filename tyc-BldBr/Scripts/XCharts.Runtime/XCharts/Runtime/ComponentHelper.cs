using System.Collections.Generic;

namespace XCharts.Runtime
{
	public static class ComponentHelper
	{
		public static AngleAxis GetAngleAxis(List<MainComponent> components, int polarIndex)
		{
			foreach (MainComponent component in components)
			{
				if (component is AngleAxis)
				{
					AngleAxis angleAxis = component as AngleAxis;
					if (angleAxis.polarIndex == polarIndex)
					{
						return angleAxis;
					}
				}
			}
			return null;
		}

		public static RadiusAxis GetRadiusAxis(List<MainComponent> components, int polarIndex)
		{
			foreach (MainComponent component in components)
			{
				if (component is RadiusAxis)
				{
					RadiusAxis radiusAxis = component as RadiusAxis;
					if (radiusAxis.polarIndex == polarIndex)
					{
						return radiusAxis;
					}
				}
			}
			return null;
		}

		public static float GetXAxisOnZeroOffset(List<MainComponent> components, XAxis axis)
		{
			if (!axis.axisLine.onZero)
			{
				return 0f;
			}
			foreach (MainComponent component in components)
			{
				if (component is YAxis)
				{
					YAxis yAxis = component as YAxis;
					if (yAxis.IsValue() && yAxis.gridIndex == axis.gridIndex)
					{
						return yAxis.context.offset;
					}
				}
			}
			return 0f;
		}

		public static float GetYAxisOnZeroOffset(List<MainComponent> components, YAxis axis)
		{
			if (!axis.axisLine.onZero)
			{
				return 0f;
			}
			foreach (MainComponent component in components)
			{
				if (component is XAxis)
				{
					XAxis xAxis = component as XAxis;
					if (xAxis.IsValue() && xAxis.gridIndex == axis.gridIndex)
					{
						return xAxis.context.offset;
					}
				}
			}
			return 0f;
		}

		public static bool IsAnyCategoryOfYAxis(List<MainComponent> components)
		{
			foreach (MainComponent component in components)
			{
				if (component is YAxis && (component as YAxis).type == Axis.AxisType.Category)
				{
					return true;
				}
			}
			return false;
		}
	}
}
