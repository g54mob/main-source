using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathNet.Numerics.RootFinding
{
	public static class Broyden
	{
		public static double[] FindRoot(Func<double[], double[]> f, double[] initialGuess, double accuracy = 1E-08, int maxIterations = 100, double jacobianStepSize = 0.0001)
		{
			if (TryFindRootWithJacobianStep(f, initialGuess, accuracy, maxIterations, jacobianStepSize, out var root))
			{
				return root;
			}
			throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds.");
		}

		public static bool TryFindRootWithJacobianStep(Func<double[], double[]> f, double[] initialGuess, double accuracy, int maxIterations, double jacobianStepSize, out double[] root)
		{
			if (accuracy <= 0.0)
			{
				throw new ArgumentOutOfRangeException("accuracy", "Must be greater than zero.");
			}
			DenseVector denseVector = new DenseVector(initialGuess);
			double[] array = f(initialGuess);
			DenseVector denseVector2 = new DenseVector(array);
			double num = denseVector2.L2Norm();
			Matrix<double> matrix = CalculateApproximateJacobian(f, initialGuess, array, jacobianStepSize);
			try
			{
				for (int i = 0; i <= maxIterations; i++)
				{
					DenseVector denseVector3 = (DenseVector)(-matrix.LU().Solve(denseVector2));
					DenseVector denseVector4 = denseVector + denseVector3;
					DenseVector denseVector5 = new DenseVector(f(denseVector4.Values));
					double num2 = denseVector5.L2Norm();
					if (num2 > num)
					{
						double num3 = num * num;
						double num4 = num3 / (num3 + num2 * num2);
						if (num4 == 0.0)
						{
							num4 = 0.0001;
						}
						denseVector3 = num4 * denseVector3;
						denseVector4 = denseVector + denseVector3;
						denseVector5 = new DenseVector(f(denseVector4.Values));
						num2 = denseVector5.L2Norm();
					}
					if (num2 < accuracy)
					{
						root = denseVector4.Values;
						return true;
					}
					Matrix<double> matrix2 = (denseVector5 - denseVector2 - matrix.Multiply(denseVector3)).ToColumnMatrix() * denseVector3.Multiply(1.0 / Math.Pow(denseVector3.L2Norm(), 2.0)).ToRowMatrix();
					matrix += matrix2;
					denseVector = denseVector4;
					denseVector2 = denseVector5;
					num = num2;
				}
			}
			catch (InvalidParameterException)
			{
				root = null;
				return false;
			}
			root = null;
			return false;
		}

		public static bool TryFindRoot(Func<double[], double[]> f, double[] initialGuess, double accuracy, int maxIterations, out double[] root)
		{
			return TryFindRootWithJacobianStep(f, initialGuess, accuracy, maxIterations, 0.0001, out root);
		}

		private static Matrix<double> CalculateApproximateJacobian(Func<double[], double[]> f, double[] x0, double[] y0, double jacobianStepSize)
		{
			int num = x0.Length;
			DenseMatrix denseMatrix = new DenseMatrix(num);
			double[] array = new double[num];
			Array.Copy(x0, 0, array, 0, num);
			for (int i = 0; i < num; i++)
			{
				double num2 = (1.0 + Math.Abs(x0[i])) * jacobianStepSize;
				double num3 = array[i];
				array[i] = num3 + num2;
				double[] array2 = f(array);
				array[i] = num3;
				for (int j = 0; j < num; j++)
				{
					denseMatrix.At(j, i, (array2[j] - y0[j]) / num2);
				}
			}
			return denseMatrix;
		}
	}
}
