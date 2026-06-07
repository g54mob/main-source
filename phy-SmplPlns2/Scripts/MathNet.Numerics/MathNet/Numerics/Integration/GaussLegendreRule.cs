using System;
using System.Numerics;
using MathNet.Numerics.Integration.GaussRule;

namespace MathNet.Numerics.Integration
{
	public class GaussLegendreRule
	{
		private readonly GaussPoint _gaussLegendrePoint;

		public double[] Abscissas => _gaussLegendrePoint.Abscissas.Clone() as double[];

		public double[] Weights => _gaussLegendrePoint.Weights.Clone() as double[];

		public int Order => _gaussLegendrePoint.Order;

		public double IntervalBegin => _gaussLegendrePoint.IntervalBegin;

		public double IntervalEnd => _gaussLegendrePoint.IntervalEnd;

		public GaussLegendreRule(double intervalBegin, double intervalEnd, int order)
		{
			_gaussLegendrePoint = GaussLegendrePointFactory.GetGaussPoint(intervalBegin, intervalEnd, order);
		}

		public double GetAbscissa(int index)
		{
			return _gaussLegendrePoint.Abscissas[index];
		}

		public double GetWeight(int index)
		{
			return _gaussLegendrePoint.Weights[index];
		}

		public static double Integrate(Func<double, double> f, double invervalBegin, double invervalEnd, int order)
		{
			GaussPoint gaussPoint = GaussLegendrePointFactory.GetGaussPoint(order);
			int num = order + 1 >> 1;
			double num2 = 0.5 * (invervalEnd - invervalBegin);
			double num3 = 0.5 * (invervalEnd + invervalBegin);
			double[] weights = gaussPoint.Weights;
			double[] abscissas = gaussPoint.Abscissas;
			double num4;
			if (order.IsOdd())
			{
				num4 = weights[0] * f(num3);
				for (int i = 1; i < num; i++)
				{
					double num5 = num2 * abscissas[i];
					num4 += weights[i] * (f(num3 + num5) + f(num3 - num5));
				}
			}
			else
			{
				num4 = 0.0;
				for (int i = 0; i < num; i++)
				{
					double num5 = num2 * abscissas[i];
					num4 += weights[i] * (f(num3 + num5) + f(num3 - num5));
				}
			}
			return num2 * num4;
		}

		public static Complex ContourIntegrate(Func<double, Complex> f, double invervalBegin, double invervalEnd, int order)
		{
			GaussPoint gaussPoint = GaussLegendrePointFactory.GetGaussPoint(order);
			int num = order + 1 >> 1;
			double num2 = 0.5 * (invervalEnd - invervalBegin);
			double num3 = 0.5 * (invervalEnd + invervalBegin);
			double[] weights = gaussPoint.Weights;
			double[] abscissas = gaussPoint.Abscissas;
			Complex complex;
			if (order.IsOdd())
			{
				complex = weights[0] * f(num3);
				for (int i = 1; i < num; i++)
				{
					double num4 = num2 * abscissas[i];
					complex += weights[i] * (f(num3 + num4) + f(num3 - num4));
				}
			}
			else
			{
				complex = 0.0;
				for (int i = 0; i < num; i++)
				{
					double num4 = num2 * abscissas[i];
					complex += weights[i] * (f(num3 + num4) + f(num3 - num4));
				}
			}
			return num2 * complex;
		}

		public static double Integrate(Func<double, double, double> f, double invervalBeginA, double invervalEndA, double invervalBeginB, double invervalEndB, int order)
		{
			GaussPoint gaussPoint = GaussLegendrePointFactory.GetGaussPoint(order);
			int num = order + 1 >> 1;
			double num2 = 0.5 * (invervalEndA - invervalBeginA);
			double num3 = 0.5 * (invervalEndA + invervalBeginA);
			double num4 = 0.5 * (invervalEndB - invervalBeginB);
			double num5 = 0.5 * (invervalEndB + invervalBeginB);
			double[] weights = gaussPoint.Weights;
			double[] abscissas = gaussPoint.Abscissas;
			double num6;
			if (order.IsOdd())
			{
				num6 = weights[0] * weights[0] * f(num3, num5);
				int i = 1;
				double num7 = 0.0;
				for (; i < num; i++)
				{
					double num8 = num4 * abscissas[i];
					num7 += weights[i] * (f(num3, num5 + num8) + f(num3, num5 - num8));
				}
				num6 += weights[0] * num7;
				int j = 1;
				num7 = 0.0;
				for (; j < num; j++)
				{
					double num9 = num2 * abscissas[j];
					num7 += weights[j] * (f(num3 + num9, num5) + f(num3 - num9, num5));
				}
				num6 += weights[0] * num7;
				for (j = 1; j < num; j++)
				{
					double num9 = num2 * abscissas[j];
					for (i = 1; i < num; i++)
					{
						double num8 = num4 * abscissas[i];
						num6 += weights[j] * weights[i] * (f(num3 + num9, num5 + num8) + f(num9 + num3, num5 - num8) + f(num3 - num9, num5 + num8) + f(num3 - num9, num5 - num8));
					}
				}
			}
			else
			{
				num6 = 0.0;
				for (int j = 0; j < num; j++)
				{
					double num9 = num2 * abscissas[j];
					for (int i = 0; i < num; i++)
					{
						double num8 = num4 * abscissas[i];
						num6 += weights[j] * weights[i] * (f(num3 + num9, num5 + num8) + f(num9 + num3, num5 - num8) + f(num3 - num9, num5 + num8) + f(num3 - num9, num5 - num8));
					}
				}
			}
			return num4 * num2 * num6;
		}

		public static double Integrate(Func<double, double, double, double> f, double invervalBeginA, double invervalEndA, double invervalBeginB, double invervalEndB, double invervalBeginC, double invervalEndC, int order)
		{
			return Integrate((double z) => Integrate((double x, double y) => f(x, y, z), invervalBeginA, invervalEndA, invervalBeginB, invervalEndB, order), invervalBeginC, invervalEndC, order);
		}
	}
}
