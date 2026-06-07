using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathNet.Numerics.Differentiation
{
	public class FiniteDifferenceCoefficients
	{
		private double[][,] _coefficients;

		private int _points;

		public int Points
		{
			get
			{
				return _points;
			}
			set
			{
				CalculateCoefficients(value);
				_points = value;
			}
		}

		public FiniteDifferenceCoefficients(int points)
		{
			Points = points;
			CalculateCoefficients(Points);
		}

		public double[] GetCoefficients(int center, int order)
		{
			if (center >= _coefficients.Length)
			{
				throw new ArgumentOutOfRangeException("center", "Center position must be within the point range.");
			}
			if (order >= _coefficients.Length)
			{
				throw new ArgumentOutOfRangeException("order", "Maximum difference order is points-1.");
			}
			int length = _coefficients[center].GetLength(1);
			double[] array = new double[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = _coefficients[center][order, i];
			}
			return array;
		}

		public double[,] GetCoefficientsForAllOrders(int center)
		{
			if (center >= _coefficients.Length)
			{
				throw new ArgumentOutOfRangeException("center", "Center position must be within the point range.");
			}
			return _coefficients[center];
		}

		private void CalculateCoefficients(int points)
		{
			double[][,] array = new double[points][,];
			for (int i = 0; i < points; i++)
			{
				DenseMatrix denseMatrix = new DenseMatrix(points);
				int num = points - i - 1;
				for (int num2 = points - 1; num2 >= 0; num2--)
				{
					denseMatrix[num2, 0] = 1.0;
					for (int j = 1; j < points; j++)
					{
						denseMatrix[num2, j] = denseMatrix[num2, j - 1] * (double)num / (double)j;
					}
					num--;
				}
				array[i] = denseMatrix.Inverse().ToArray();
				double num3 = SpecialFunctions.Factorial(points);
				for (int k = 0; k < points; k++)
				{
					for (int l = 0; l < points; l++)
					{
						array[i][k, l] = Math.Round(array[i][k, l] * num3, MidpointRounding.AwayFromZero) / num3;
					}
				}
			}
			_coefficients = array;
		}
	}
}
