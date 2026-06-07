using System;

namespace MathNet.Numerics.Integration.GaussRule
{
	internal static class GaussLegendrePointFactory
	{
		[ThreadStatic]
		private static GaussPoint _gaussLegendrePoint;

		public static GaussPoint GetGaussPoint(int order)
		{
			if ((_gaussLegendrePoint == null || _gaussLegendrePoint.Order != order) && !GaussLegendrePoint.PreComputed.TryGetValue(order, out _gaussLegendrePoint))
			{
				_gaussLegendrePoint = GaussLegendrePoint.Generate(order, 1E-10);
			}
			return _gaussLegendrePoint;
		}

		public static GaussPoint GetGaussPoint(double intervalBegin, double intervalEnd, int order)
		{
			return Map(intervalBegin, intervalEnd, GetGaussPoint(order));
		}

		private static GaussPoint Map(double intervalBegin, double intervalEnd, GaussPoint gaussPoint)
		{
			double[] array = new double[gaussPoint.Order];
			double[] array2 = new double[gaussPoint.Order];
			double num = 0.5 * (intervalEnd - intervalBegin);
			double num2 = 0.5 * (intervalEnd + intervalBegin);
			int num3 = gaussPoint.Order + 1 >> 1;
			double[] abscissas = gaussPoint.Abscissas;
			double[] weights = gaussPoint.Weights;
			for (int i = 1; i <= num3; i++)
			{
				int num4 = gaussPoint.Order - i;
				int num5 = i - 1;
				int num6 = num3 - i;
				array[num4] = abscissas[num6] * num + num2;
				array[num5] = (0.0 - abscissas[num6]) * num + num2;
				array2[num4] = weights[num6] * num;
				array2[num5] = weights[num6] * num;
			}
			return new GaussPoint(intervalBegin, intervalEnd, gaussPoint.Order, array, array2);
		}
	}
}
