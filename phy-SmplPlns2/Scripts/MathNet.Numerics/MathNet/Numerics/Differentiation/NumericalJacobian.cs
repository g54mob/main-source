using System;

namespace MathNet.Numerics.Differentiation
{
	public class NumericalJacobian
	{
		private readonly NumericalDerivative _df;

		public int FunctionEvaluations => _df.Evaluations;

		public NumericalJacobian()
			: this(3, 1)
		{
		}

		public NumericalJacobian(int points, int center)
		{
			_df = new NumericalDerivative(points, center);
		}

		public double[] Evaluate(Func<double, double> f, double x)
		{
			return new double[1] { _df.EvaluateDerivative(f, x, 1) };
		}

		public double[] Evaluate(Func<double[], double> f, double[] x)
		{
			double[] array = new double[x.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _df.EvaluatePartialDerivative(f, x, i, 1);
			}
			return array;
		}

		public double[] Evaluate(Func<double[], double> f, double[] x, double currentValue)
		{
			double[] array = new double[x.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _df.EvaluatePartialDerivative(f, x, i, 1, currentValue);
			}
			return array;
		}

		public double[,] Evaluate(Func<double[], double>[] f, double[] x)
		{
			double[,] array = new double[f.Length, x.Length];
			for (int i = 0; i < f.Length; i++)
			{
				double[] array2 = Evaluate(f[i], x);
				for (int j = 0; j < array2.Length; j++)
				{
					array[i, j] = array2[j];
				}
			}
			return array;
		}

		public double[,] Evaluate(Func<double[], double>[] f, double[] x, double[] currentValues)
		{
			double[,] array = new double[f.Length, x.Length];
			for (int i = 0; i < f.Length; i++)
			{
				double[] array2 = Evaluate(f[i], x, currentValues[i]);
				for (int j = 0; j < array2.Length; j++)
				{
					array[i, j] = array2[j];
				}
			}
			return array;
		}

		public void ResetFunctionEvaluations()
		{
			_df.ResetEvaluations();
		}
	}
}
