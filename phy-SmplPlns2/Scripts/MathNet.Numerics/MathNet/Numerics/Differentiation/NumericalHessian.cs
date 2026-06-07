using System;

namespace MathNet.Numerics.Differentiation
{
	public class NumericalHessian
	{
		private readonly NumericalDerivative _df;

		public int FunctionEvaluations => _df.Evaluations;

		public NumericalHessian()
			: this(3, 1)
		{
		}

		public NumericalHessian(int points, int center)
		{
			_df = new NumericalDerivative(points, center);
		}

		public double[] Evaluate(Func<double, double> f, double x)
		{
			return new double[1] { _df.EvaluateDerivative(f, x, 2) };
		}

		public double[,] Evaluate(Func<double[], double> f, double[] x)
		{
			double[,] array = new double[x.Length, x.Length];
			for (int i = 0; i < x.Length; i++)
			{
				array[i, i] = _df.EvaluatePartialDerivative(f, x, i, 2);
			}
			for (int j = 0; j < x.Length; j++)
			{
				for (int k = 0; k < j; k++)
				{
					array[k, j] = (array[j, k] = _df.EvaluateMixedPartialDerivative(f, x, new int[2] { j, k }, 2));
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
