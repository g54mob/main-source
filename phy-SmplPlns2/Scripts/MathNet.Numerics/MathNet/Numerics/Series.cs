using System;
using System.Collections.Generic;

namespace MathNet.Numerics
{
	public static class Series
	{
		public static double Evaluate(Func<double> nextSummand)
		{
			double num = 0.0;
			double num2 = nextSummand();
			double num3;
			do
			{
				num3 = nextSummand();
				double num4 = num3 - num;
				double num5 = num2 + num4;
				num = num5 - num2;
				num -= num4;
				num2 = num5;
			}
			while (Math.Abs(num2) < Math.Abs(65536.0 * num3));
			return num2;
		}

		public static double Evaluate(IEnumerable<double> infiniteSummands)
		{
			double num = 0.0;
			double num2;
			using (IEnumerator<double> enumerator = infiniteSummands.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					return 0.0;
				}
				num2 = enumerator.Current;
				if (!enumerator.MoveNext())
				{
					return num2;
				}
				double current;
				do
				{
					current = enumerator.Current;
					double num3 = current - num;
					double num4 = num2 + num3;
					num = num4 - num2;
					num -= num3;
					num2 = num4;
				}
				while (Math.Abs(num2) < Math.Abs(65536.0 * current) && enumerator.MoveNext());
			}
			return num2;
		}
	}
}
