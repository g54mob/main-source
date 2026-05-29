using UnityEngine;

namespace XCharts.Runtime
{
	internal static class PolarHelper
	{
		public static void UpdatePolarCenter(PolarCoord polar, Vector3 chartPosition, float chartWidth, float chartHeight)
		{
			if (polar.center.Length >= 2)
			{
				float x = ((polar.center[0] <= 1f) ? (chartWidth * polar.center[0]) : polar.center[0]);
				float y = ((polar.center[1] <= 1f) ? (chartHeight * polar.center[1]) : polar.center[1]);
				float total = Mathf.Min(chartWidth, chartHeight);
				polar.context.center = chartPosition + new Vector3(x, y);
				polar.context.insideRadius = (polar.context.outsideRadius = 0f);
				if (polar.radius.Length >= 2)
				{
					polar.context.insideRadius = ChartHelper.GetActualValue(polar.radius[0], total, 1f);
					polar.context.outsideRadius = ChartHelper.GetActualValue(polar.radius[1], total, 1f);
				}
				else if (polar.radius.Length >= 1)
				{
					polar.context.outsideRadius = ChartHelper.GetActualValue(polar.radius[0], total, 1f);
				}
				polar.context.radius = polar.context.outsideRadius - polar.context.insideRadius;
			}
		}

		public static Vector3 UpdatePolarAngleAndPos(PolarCoord polar, AngleAxis angleAxis, RadiusAxis radiusAxis, SerieData serieData)
		{
			double data = serieData.GetData(0);
			float valueAngle = angleAxis.GetValueAngle(serieData.GetData(1));
			float radius = polar.context.insideRadius + radiusAxis.GetValueLength(data, polar.context.radius);
			valueAngle = (valueAngle + 360f) % 360f;
			serieData.context.angle = valueAngle;
			serieData.context.position = ChartHelper.GetPos(polar.context.center, radius, valueAngle, isDegree: true);
			return serieData.context.position;
		}
	}
}
